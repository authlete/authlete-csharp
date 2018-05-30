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


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for end-user's decision on the authorization
    /// request.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An authorization endpoint returns an authorization page
    /// (HTML) to an end-user, and the end-user will select either
    /// <i>"authorize"</i> or <i>"deny"</i> the authorization
    /// request. The <c>Handle</c> method handles the decision and
    /// calls Authlete's <c>/api/auth/authorization/issue</c> API
    /// or <c>/api/auth/authorization/fail</c> API.
    /// </para>
    /// </remarks>
    public class AuthorizationRequestDecisionHandler
        : AuthorizationRequestBaseHandler
    {
        // Separator between a claim name and a language tag.
        static readonly char[] CLAIM_SEPARATOR = { '#' };


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
        public AuthorizationRequestDecisionHandler(
            IAuthleteApi api, IAuthorizationRequestDecisionHandlerSpi spi)
            : base(api)
        {
            Spi = spi;
        }


        IAuthorizationRequestDecisionHandlerSpi Spi { get; }


        /// <summary>
        /// Handle an end-user's decision on an authorization
        /// request.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned to the user
        /// agent.
        /// </returns>
        ///
        /// <param name="ticket">
        /// A ticket issued by Authlete's
        /// <c>/api/auth/authorization</c> API.
        /// </param>
        ///
        /// <param name="claimNames">
        /// Names of requested claims. Use the value of the
        /// <c>"claims"</c> parameter in a response from Authlete's
        /// <c>/api/auth/authorization</c> API.
        /// </param>
        ///
        /// <param name="claimLocales">
        /// Requested claim locales. Use the value of the
        /// <c>"claimsLocales"</c> parameter in a response from
        /// Authlete's <c>/api/auth/authorization</c> API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            string ticket, string[] claimNames, string[] claimLocales)
        {
            // If the end-user did not grant authorization to the
            // client application.
            if (Spi.IsClientAuthorized() == false)
            {
                // The end-user denied the authorization request.
                return await AuthorizationFail(
                    ticket, AuthorizationFailReason.DENIED);
            }

            // The subject (= unique identifier) of the end-user.
            string subject = Spi.GetUserSubject();

            // If the subject of the end-user is not available.
            if (string.IsNullOrEmpty(subject))
            {
                // The end-user is not authenticated.
                return await AuthorizationFail(
                    ticket, AuthorizationFailReason.NOT_AUTHENTICATED);
            }

            // Get the value of the "sub" claim. This is optional.
            // When 'sub' is null, the value of 'subject' will be
            // used as the value of the "sub" claim.
            string sub = Spi.GetSub();

            // The time when the end-user was authenticated.
            long authTime = Spi.GetUserAuthenticatedAt();

            // The ACR (Authentication Context Class Reference) of
            // the end-user authentication.
            string acr = Spi.GetAcr();

            // Collect claim values.
            IDictionary<string, object> claims =
                new ClaimCollector(
                    subject, claimNames, claimLocales, Spi).Collect();

            // Properties to be associated with an access token
            // and/or an authorization code.
            Property[] properties = Spi.GetProperties();

            // Scopes associated with an access token and/or an
            // authorization code. If a non-null value is returned
            // from Spi.GetScopes(), the scope set replaces the
            // scopes that were given by the original authorization
            // request.
            string[] scopes = Spi.GetScopes();

            // Authorize the authorization request.
            return await AuthorizationIssue(
                ticket, subject, authTime, acr, claims,
                properties, scopes, sub);
        }
    }
}
