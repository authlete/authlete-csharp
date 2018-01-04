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
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for revocation requests to a revocation endpoint
    /// (<a href="https://tools.ietf.org/html/rfc7009">RFC 7009</a>).
    /// </summary>
    public class RevocationRequestHandler : BaseRequestHandler
    {
        static readonly AuthenticationHeaderValue CHALLENGE =
            new AuthenticationHeaderValue("Basic", "realm=\"revocation\"");


        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public RevocationRequestHandler(IAuthleteApi api)
            : base(api)
        {
        }


        /// <summary>
        /// Handle a revocation request
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>). This method calls Authlete's
        /// <c>/api/auth/revocation</c> API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// revocation endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Request parameters of a revocation request.
        /// </param>
        ///
        /// <param name="authorization">
        /// The value of the <c>Authorization</c> header in the
        /// revocation request. A client application may embed its
        /// pair of client ID and client secret in a revocation
        /// request using Basic Authentication.
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
        /// Handle a revocation request
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>). This method calls Authlete's
        /// <c>/api/auth/revocation</c> API.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.3
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// revocation endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Request parameters of a revocation request.
        /// </param>
        ///
        /// <param name="authorizationHeaderValue">
        /// The value of the <c>Authorization</c> header in the
        /// revocation request. A client application may embed its
        /// pair of client ID and client secret in a revocation
        /// request using Basic Authentication.
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
        /// Handle a revocation request
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>). This method calls Authlete's
        /// <c>/api/auth/revocation</c> API.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.3
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// revocation endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Request parameters of a revocation request.
        /// </param>
        ///
        /// <param name="credentials">
        /// The pair of client ID and client secret that might be
        /// embedded in the <c>Authorization</c> header of the
        /// revocation request.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(
            string parameters, BasicCredentials credentials)
        {
            // Call Authlete's /api/auth/revocation API.
            RevocationResponse response =
                await CallRevocationApi(parameters, credentials);

            // 'action' in the response denotes the next action which
            // the implementation of revocation endpoint should take.
            RevocationAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case RevocationAction.INVALID_CLIENT:
                    // 401 Unauthorized
                    return ResponseUtility.Unauthorized(CHALLENGE, content);

                case RevocationAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case RevocationAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case RevocationAction.OK:
                    // 200 OK
                    return ResponseUtility.OkJavaScript(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/revocation");
            }
        }


        async Task<RevocationResponse> CallRevocationApi(
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

            // Prepare a request for Authlete's /api/auth/revocation API.
            var request = new RevocationRequest
            {
                Parameters   = parameters,
                ClientId     = (credentials == null)
                             ? null : credentials.UserId,
                ClientSecret = (credentials == null)
                             ? null : credentials.Password
            };

            // Call Authlete's /api/auth/revocation API.
            return await Api.Revocation(request);
        }
    }
}
