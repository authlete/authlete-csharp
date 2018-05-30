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


using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Dto;
using Authlete.Handler.Spi;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for token requests to a
    /// <a href="https://tools.ietf.org/html/rfc6749#section-3.2">token
    /// endpoint</a> of OAuth 2.0
    /// (<a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>).
    /// </summary>
    public class TokenRequestHandler : BaseRequestHandler
    {
        // WWW-Authenticate: Basic realm="token"
        static readonly AuthenticationHeaderValue CHALLENGE =
            new AuthenticationHeaderValue("Basic", "realm=\"token\"");


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
        public TokenRequestHandler(
            IAuthleteApi api, ITokenRequestHandlerSpi spi)
            : base(api)
        {
            Spi = spi;
        }


        ITokenRequestHandlerSpi Spi { get; }


        /// <summary>
        /// Handle a token request to a token endpoint. This method
        /// calls Authlete's <c>/api/auth/token</c> API and
        /// conditionally <c>/api/auth/token/issue</c> API or
        /// <c>/api/token/issue/fail</c> API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the token
        /// endpoint implementation to the client application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Form parameters of the token request in
        /// <c>application/x-www-form-urlencoded</c> format.
        /// The value can be obtained by calling
        /// <c>HttpRequestMessage.Content.ReadAsStringAsync</c>.
        /// </param>
        ///
        /// <param name="authorization">
        /// The value of the <c>Authorization</c> header of the
        /// token request. The value can be obtained by calling
        /// <c>HttpRequestMessage.Headers.Authorization</c>.
        /// Note that token requests don't always have an
        /// <c>Authorization</c> header.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            string parameters, AuthenticationHeaderValue authorization)
        {
            // Convert the value of the Authorization header
            // (credentials of the client application), if any,
            // into BasicCredentials.
            BasicCredentials credentials =
                BasicCredentials.Parse(authorization);

            return await Handle(parameters, credentials);
        }


        /// <summary>
        /// Handle a token request to a token endpoint. This method
        /// calls Authlete's <c>/api/auth/token</c> API and
        /// conditionally <c>/api/auth/token/issue</c> API or
        /// <c>/api/token/issue/fail</c> API.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.3
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the token
        /// endpoint implementation to the client application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Form parameters of the token request in
        /// <c>application/x-www-form-urlencoded</c> format.
        /// The value can be obtained by calling
        /// <c>HttpRequestMessage.Content.ReadAsStringAsync</c>.
        /// </param>
        ///
        /// <param name="authorizationHeaderValue">
        /// The value of the <c>Authorization</c> header of the
        /// token request. The value can be obtained by calling
        /// <c>HttpRequestMessage.Headers.Authorization</c>.
        /// Note that token requests don't always have an
        /// <c>Authorization</c> header.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            string parameters, string authorizationHeaderValue)
        {
            // Convert the value of the Authorization header
            // (credentials of the client application), if any,
            // into BasicCredentials.
            BasicCredentials credentials =
                BasicCredentials.Parse(authorizationHeaderValue);

            return await Handle(parameters, credentials);
        }


        /// <summary>
        /// Handle a token request to a token endpoint. This method
        /// calls Authlete's <c>/api/auth/token</c> API and
        /// conditionally <c>/api/auth/token/issue</c> API or
        /// <c>/api/token/issue/fail</c> API.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.3
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the token
        /// endpoint implementation to the client application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Form parameters of the token request in
        /// <c>application/x-www-form-urlencoded</c> format.
        /// The value can be obtained by calling
        /// <c>HttpRequestMessage.Content.ReadAsStringAsync</c>.
        /// </param>
        ///
        /// <param name="credentials">
        /// The pair of client ID and client secret that might be
        /// embedded in the <c>Authorization</c> header of the
        /// token request.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            string parameters, BasicCredentials credentials)
        {
            // Call Authlete's /api/auth/token API.
            TokenResponse response =
                await CallTokenApi(parameters, credentials);

            // 'action' in the response denotes the next action which
            // the implementation of the token endpoint should take.
            TokenAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case TokenAction.INVALID_CLIENT:
                    // 401 Unauthorized
                    return ResponseUtility.Unauthorized(CHALLENGE, content);

                case TokenAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case TokenAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case TokenAction.PASSWORD:
                    // Process the token request whose flow is
                    // "Resource Owner Password Credentials".
                    return await HandlePassword(response);

                case TokenAction.OK:
                    // 200 OK
                    return ResponseUtility.OkJson(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/token");
            }
        }


        async Task<TokenResponse> CallTokenApi(
            string parameters, BasicCredentials credentials)
        {
            if (parameters == null)
            {
                // Authlete returns different error codes for null
                // and an empty string. 'null' is regarded as a
                // caller's error. An empty string is regarded as
                // a client application's error.
                parameters = "";
            }

            // Prepare a request for Authlete's /api/auth/token API.
            TokenRequest request = new TokenRequest
            {
                Parameters   = parameters,
                ClientId     = (credentials == null)
                             ? null : credentials.UserId,
                ClientSecret = (credentials == null)
                             ? null : credentials.Password,
                Properties   = Spi.GetProperties()
            };

            // Call Authlete's /api/auth/token API.
            return await Api.Token(request);
        }


        async Task<HttpResponseMessage> HandlePassword(TokenResponse response)
        {
            // The ticket to call Authlete's /api/auth/token/* API.
            string ticket = response.Ticket;

            // The credentials of the resource owner.
            string username = response.Username;
            string password = response.Password;

            // Validate the credentials.
            string subject = Spi.AuthenticateUser(username, password);

            // If the credentials of the resource owner are invalid.
            if (subject == null)
            {
                // The credentials are invalid. Nothing is issued.
                return await TokenFail(
                    ticket, TokenFailReason.INVALID_RESOURCE_OWNER_CREDENTIALS);
            }

            // Issue an access token and optionally an ID token.
            return await TokenIssue(ticket, subject);
        }


        async Task<HttpResponseMessage> TokenIssue(
            string ticket, string subject)
        {
            // Call Authlete's /api/auth/token/issue API.
            TokenIssueResponse response =
                await CallTokenIssueApi(ticket, subject);

            // 'action' in the response denotes the next action
            // which this service implementation should take.
            TokenIssueAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case TokenIssueAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case TokenIssueAction.OK:
                    // 200 OK
                    return ResponseUtility.OkJson(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/token/issue");
            }
        }


        async Task<TokenIssueResponse> CallTokenIssueApi(
            string ticket, string subject)
        {
            // Prepare a request for Authlete's /api/auth/token/issue API.
            TokenIssueRequest request = new TokenIssueRequest
            {
                Ticket     = ticket,
                Subject    = subject,
                Properties = Spi.GetProperties()
            };

            // Call Authlete's /api/auth/token/issue API.
            return await Api.TokenIssue(request);
        }


        async Task<HttpResponseMessage> TokenFail(string ticket, TokenFailReason reason)
        {
            // Call Authlete's /api/auth/token/fail API.
            TokenFailResponse response = await CallTokenFailApi(ticket, reason);

            // 'action' in the response denotes the next action which
            // this service implementation should take.
            TokenFailAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case TokenFailAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case TokenFailAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/token/fail");
            }
        }


        async Task<TokenFailResponse> CallTokenFailApi(string ticket, TokenFailReason reason)
        {
            // Prepare a request for Authlete's /api/auth/token/fail API.
            TokenFailRequest request = new TokenFailRequest
            {
                Ticket = ticket,
                Reason = reason
            };

            // Call Authlete's /api/auth/token/fail API.
            return await Api.TokenFail(request);
        }
    }
}
