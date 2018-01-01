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
using Authlete.Util;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// The base class for request handlers that are used in the
    /// implementation of an authorization endpoint.
    /// </summary>
    public class AuthorizationRequestBaseHandler : BaseRequestHandler
    {
        /// <summary>
        /// Consturctor with an implementation of the
        /// <c>IAuthleteApi</c> interface which will be passed to
        /// the constructor of the super class.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public AuthorizationRequestBaseHandler(IAuthleteApi api)
            : base(api)
        {
        }


        /// <summary>
        /// Call Authlete's <c>/api/auth/authorization/issue</c>
        /// API and generate an <c>HttpResponseMessage</c> instance
        /// according to the value of the <c>"action"</c> parameter
        /// in the response from the API. Read the description of
        /// <c>AuthorizationIssueRequest</c> for details about the
        /// parameters given to this method.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// authorization endpoint implementation to the user
        /// agent.
        /// </returns>
        ///
        /// <param name="ticket">
        /// The ticket which was issued from Authlete's
        /// <c>/api/auth/authorization</c> API.
        /// </param>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of the end-user.
        /// </param>
        ///
        /// <param name="authTime">
        /// The time at which the end-user was authenticated.
        /// The value should be seconds since the Unix epoch
        /// (1970-Jan-1).
        /// </param>
        ///
        /// <param name="acr">
        /// The Authentication Context Class Reference performed
        /// for the end-user authentication.
        /// </param>
        ///
        /// <param name="claims">
        /// The claims about the end-user in JSON format.
        /// </param>
        ///
        /// <param name="properties">
        /// Arbitrary properties to be associated with an access
        /// token and/or an authorization code.
        /// </param>
        ///
        /// <param name="scopes">
        /// Scopes to be associated with an access token and/or an
        /// authorization code.
        /// </param>
        ///
        /// <param name="sub">
        /// The value of the "sub" claim which is embedded in an ID
        /// token. If this argument is null, the value of 'subject'
        /// will be used instead.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        protected async Task<HttpResponseMessage> AuthorizationIssue(
            string ticket, string subject, long authTime, string acr,
            IDictionary<string, object> claims, Property[] properties,
            string[] scopes, string sub)
        {
            // Call Authlete's /api/auth/authorization/issue API.
            AuthorizationIssueResponse response =
                await CallAuthorizationIssueApi(
                    ticket, subject, authTime, acr, claims,
                    properties, scopes, sub);

            // 'action' in the response denotes the next action which
            // the implementation of authorization endpoint should take.
            AuthorizationIssueAction action = response.Action;

            // The content of the response to the client application.
            // The format of the content varies depending on the action.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case AuthorizationIssueAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case AuthorizationIssueAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case AuthorizationIssueAction.LOCATION:
                    // 302 Found
                    return ResponseUtility.Location(content);

                case AuthorizationIssueAction.FORM:
                    // 200 OK
                    return ResponseUtility.OkHtml(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/authorization/issue");
            }
        }


        async Task<AuthorizationIssueResponse> CallAuthorizationIssueApi(
            string ticket, string subject, long authTime, string acr,
            IDictionary<string, object> claims, Property[] properties,
            string[] scopes, string sub)
        {
            // Prepare a request for Authlete's
            // /api/auth/authorization/issue API.
            var request = new AuthorizationIssueRequest
            {
                Ticket     = ticket,
                Subject    = subject,
                AuthTime   = authTime,
                Acr        = acr,
                Claims     = TextUtility.ToJson(claims),
                Properties = properties,
                Scopes     = scopes,
                Sub        = sub
            };

            // Call Authlete's /api/auth/authorization/issue API.
            return await Api.AuthorizationIssue(request);
        }


        /// <summary>
        /// Call Authlete's <c>/api/auth/authorization/fail</c> API
        /// and generate an <c>HttpResponseMessage</c> instance
        /// according to the value of the <c>"action"</c> parameter
        /// in the response from the API. Read the description of
        /// <c>AuthorizationFailRequest</c> for details about the
        /// parameters given to this method.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// authorization endpoint implementation to the user
        /// agent.
        /// </returns>
        ///
        /// <param name="ticket">
        /// The ticket which was issued from Authlete's
        /// <c>/api/auth/authorization</c> API.
        /// </param>
        ///
        /// <param name="reason">
        /// The reason of the failure of the authorization request.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        protected async Task<HttpResponseMessage> AuthorizationFail(
            string ticket, AuthorizationFailReason reason)
        {
            // Call Authlete's /api/auth/authorization/fail API.
            AuthorizationFailResponse response =
                await CallAuthorizationFailApi(ticket, reason);

            // 'action' in the response denotes the next action which
            // the implementation of authorization decision endpoint
            // should take.
            AuthorizationFailAction action = response.Action;

            // The content of the response to the client application.
            // The format of the content varies depending on the action.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case AuthorizationFailAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case AuthorizationFailAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case AuthorizationFailAction.LOCATION:
                    // 302 Found
                    return ResponseUtility.Location(content);

                case AuthorizationFailAction.FORM:
                    // 200 OK
                    return ResponseUtility.OkHtml(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/authorization/fail");
            }
        }


        async Task<AuthorizationFailResponse> CallAuthorizationFailApi(
            string ticket, AuthorizationFailReason reason)
        {
            // Create a request for Authlete's
            // /api/auth/authorizatin/fail API.
            var request = new AuthorizationFailRequest
            {
                Ticket = ticket,
                Reason = reason
            };

            // Call Authlete's /api/auth/authorization/fail API.
            return await Api.AuthorizationFail(request);
        }
    }
}
