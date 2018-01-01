//
// Copyright (C) 2018 Authlete, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific
// language governing permissions and limitations under the
// License.
//


using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Dto;
using Authlete.Handler.Spi;
using Authlete.Util;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for the case where an authorization request should
    /// be processed without user interaction.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// A response from Authlete's <c>/api/auth/authorization</c>
    /// API contains a <c>"action"</c> response parameter. When the
    /// value of the response parameter is <c>"NO_INTERACTION"</c>,
    /// the authorization request needs to be processed without
    /// user interaction. This class is a handler for the case.
    /// </para>
    /// </remarks>
    public class NoInteractionHandler
        : AuthorizationRequestBaseHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        ///
        /// <param name="spi">
        /// An implementation of the Service Provider Interface.
        /// It is the customization point.
        /// </param>
        public NoInteractionHandler(
            IAuthleteApi api, INoInteractionHandlerSpi spi)
            : base(api)
        {
            Spi = spi;
        }


        INoInteractionHandlerSpi Spi { get; }


        /// <summary>
        /// Handle an authorization request without user
        /// interaction. This method calls Authlete's
        /// <c>/api/auth/authorization/issue</c> API or
        /// <c>/api/auth/authorization/fail</c> API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned to the user
        /// agent. If <c>response.Action</c> is not
        /// <c>AuthorizationAction.NO_INTERACTION</c>, this method
        /// returns <c>null</c>.
        /// </returns>
        ///
        /// <param name="response">
        /// A response from Authlete's <c>/api/auth/authorization</c>
        /// API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            AuthorizationResponse response)
        {
            // If the value of the "action" parameter in the
            // response from Authlete's /api/auth/authorization API
            // is not "NO_INTERACTION".
            if (response.Action != AuthorizationAction.NO_INTERACTION)
            {
                // This handler does not handle other cases than
                // NO_INTERACTION.
                return null;
            }

            // Check 1: End-User Authentication
            if (CheckUserAuthentication() == false)
            {
                // A user must have logged in.
                return await AuthorizationFail(
                    response.Ticket, AuthorizationFailReason.NOT_LOGGED_IN);
            }

            // Get the last time when the user was authenticated.
            long authTime = Spi.GetUserAuthenticatedAt();

            // Check 2: Max Age
            if (CheckMaxAge(response, authTime) == false)
            {
                // The maximum authentication age has elapsed since
                // the last time when the end-user was authenticated.
                return await AuthorizationFail(
                    response.Ticket, AuthorizationFailReason.EXCEEDS_MAX_AGE);
            }

            // The subject (unique ID) of the current user.
            string subject = Spi.GetUserSubject();

            // Check 3: Subject
            if (CheckSubject(response, subject) == false)
            {
                // The requested subject and that of the current
                // user do not match.
                return await AuthorizationFail(
                    response.Ticket, AuthorizationFailReason.DIFFERENT_SUBJECT);
            }

            // Get the value of the "sub" claim. This is optional.
            // When 'sub' is null, the value of 'subject' will be
            // used as the value of the "sub" claim.
            string sub = Spi.GetSub();

            // Get the ACR that was satisfied when the current user
            // was authenticated.
            string acr = Spi.GetAcr();

            // Check 4: ACR
            if (CheckAcr(response, acr) == false)
            {
                // None of the requested ACRs is satisfied.
                return await AuthorizationFail(
                    response.Ticket, AuthorizationFailReason.ACR_NOT_SATISFIED);
            }

            // Collect claim values.
            IDictionary<string, object> claims =
                new ClaimCollector(
                    subject, response.Claims,
                    response.ClaimsLocales, Spi).Collect();

            // Extra properties that will be associated with an
            // access token and/or an authorization code.
            Property[] properties = Spi.GetProperties();

            // Scopes that will be associated with an access token
            // and/or an authorization code. If a non-null value is
            // returned from Spi.GetScopes(), the scope set replaces
            // the scopes that were specified in the original
            // authorization request.
            string[] scopes = Spi.GetScopes();

            // Issue tokens without user interaction.
            return await AuthorizationIssue(
                response.Ticket, subject, authTime, acr, claims,
                properties, scopes, sub);
        }


        bool CheckUserAuthentication()
        {
            return Spi.IsUserAuthenticated();
        }


        bool CheckMaxAge(AuthorizationResponse response, long authTime)
        {
            // Get the requested maximum authentication age.
            int maxAge = response.MaxAge;

            // If no maximum authentication age is requested.
            if (maxAge == 0)
            {
                // No need to care about the maximum authentication age.
                return true;
            }

            // The time in seconds when the authentication expires.
            long expiresAt = authTime + maxAge;

            // If the authentication has not expired yet.
            if (TimeUtility.CurrentTimeSeconds() < expiresAt)
            {
                // Not exceeded.
                return true;
            }

            // Exceeded.
            return false;
        }


        bool CheckSubject(AuthorizationResponse response, string subject)
        {
            // Get the requested subject.
            string requestedSubject = response.Subject;

            // If no subject is requested.
            if (requestedSubject == null)
            {
                // No need to care about the subject.
                return true;
            }

            // If the requested subject matches that of
            // the current user.
            if (requestedSubject.Equals(subject))
            {
                // The subjects match.
                return true;
            }

            // The subjects do not match.
            return false;
        }


        bool CheckAcr(AuthorizationResponse response, string acr)
        {
            // Get the list of requested ACRs.
            string[] requestedAcrs = response.Acrs;

            // If no ACR is requested.
            if (requestedAcrs == null || requestedAcrs.Length == 0)
            {
                // No need to care about ACR.
                return true;
            }

            // For each requested ACR.
            foreach (string requestedAcr in requestedAcrs)
            {
                if (requestedAcr.Equals(acr))
                {
                    // OK. The ACR satisfied when the current
                    // user was authenticated matches one of
                    // the requested ACRs.
                    return true;
                }
            }

            // If one of the requested ACRs must be satisfied.
            if (response.IsAcrEssential)
            {
                // None of the requested ACRs is satisfied.
                return false;
            }

            // The ACR satisfied when the current user was
            // authenticated does not match any one of the
            // requested ACRs, but the authorization request
            // from the client application did not request
            // ACR as essential. Therefore, it is not necessary
            // to raise an error here.
            return true;
        }
    }
}
