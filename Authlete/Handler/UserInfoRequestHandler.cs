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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Dto;
using Authlete.Handler.Spi;
using Authlete.Util;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for userinfo requests to a
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
    /// endpoint</a> defined in
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </summary>
    public class UserInfoRequestHandler : BaseRequestHandler
    {
        // The value of the WWW-Authenticate header of the response
        // from the UserInfo endpoint when the UserInfo request does
        // not contain an access token.
        static readonly AuthenticationHeaderValue CHALLENGE =
            new AuthenticationHeaderValue(
                "Bearer",
                "error=\"invalid_token\",error_description=\"" +
                "An access token must be sent as a Bearer Token. " +
                "See 'OpenID Connect Core 1.0, 5.3.1. UserInfo" +
                "Request' for details.\"");


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
        public UserInfoRequestHandler(
            IAuthleteApi api, IUserInfoRequestHandlerSpi spi)
            : base(api)
        {
            Spi = spi;
        }


        IUserInfoRequestHandlerSpi Spi { get; }


        /// <summary>
        /// Handle a userinfo request. This method calls Authlete's
        /// <c>/api/auth/userinfo</c> API and conditionally
        /// <c>/api/auth/userinfo/issue</c> API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// userinfo endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="accessToken">
        /// An access token that the client application presented
        /// at the userinfo endpoint.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(string accessToken)
        {
            if (accessToken == null)
            {
                // 400 Bad Request with a WWW-Authenticate header.
                return ResponseUtility.WwwAuthenticate(
                    HttpStatusCode.BadRequest, CHALLENGE);
            }

            // Call Authlete's /api/auth/userinfo API.
            UserInfoResponse response = await CallUserInfoApi(accessToken);

            // 'action' in the response denotes the next action which
            // the implementation of userinfo endpoint should take.
            UserInfoAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case UserInfoAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.InternalServerError, content);

                case UserInfoAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.BadRequest, content);

                case UserInfoAction.UNAUTHORIZED:
                    // 401 Unauthorized
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.Unauthorized, content);

                case UserInfoAction.FORBIDDEN:
                    // 403 Forbidden
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.Forbidden, content);

                case UserInfoAction.OK:
                    // Return the user information.
                    return await GetUserInfo(response);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/userinfo");
            }
        }


        async Task<UserInfoResponse> CallUserInfoApi(string accessToken)
        {
            // Prepare a request for Authlete's /api/auth/userinfo API.
            UserInfoRequest request = new UserInfoRequest
            {
                Token = accessToken
            };

            // Call Authlete's /api/auth/userinfo API.
            return await Api.UserInfo(request);
        }


        async Task<HttpResponseMessage> GetUserInfo(UserInfoResponse response)
        {
            // Collect claim values of the user.
            IDictionary<string, object> claims =
                new ClaimCollector(
                    response.Subject, response.Claims, null, Spi)
                    .Collect();

            // The value of the 'sub' claim (optional).
            string sub = Spi.GetSub();

            // Generate a response from the userinfo endpoint.
            return await UserInfoIssue(response.Token, claims, sub);
        }


        async Task<HttpResponseMessage> UserInfoIssue(
            string token, IDictionary<string, object> claims, string sub)
        {
            // Call Authlete's /api/auth/userinfo/issue API.
            UserInfoIssueResponse response =
                await CallUserInfoIssueApi(token, claims, sub);

            // 'action' in the response denotes the next action which
            // this service implementation should take.
            UserInfoIssueAction action = response.Action;

            // The content of the response to the client application.
            // The format of the content varies depending on the action.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case UserInfoIssueAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.InternalServerError, content);

                case UserInfoIssueAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.BadRequest, content);

                case UserInfoIssueAction.UNAUTHORIZED:
                    // 401 Unauthorized
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.Unauthorized, content);

                case UserInfoIssueAction.FORBIDDEN:
                    // 403 Forbidden
                    return ResponseUtility.WwwAuthenticate(
                        HttpStatusCode.Forbidden, content);

                case UserInfoIssueAction.JSON:
                    // 200 OK, application/json; charset=UTF-8
                    return ResponseUtility.OkJson(content);

                case UserInfoIssueAction.JWT:
                    // 200 OK, application/jwt
                    return ResponseUtility.OkJwt(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/userinfo/issue");
            }
        }


        async Task<UserInfoIssueResponse> CallUserInfoIssueApi(
            string token, IDictionary<string, object> claims, string sub)
        {
            // Prepare a request for Authlete's /api/auth/userinfo/issue API.
            UserInfoIssueRequest request = new UserInfoIssueRequest
            {
                Token  = token,
                Claims = TextUtility.ToJson(claims),
                Sub    = sub
            };

            // Call Authlete's /api/auth/userinfo/issue API.
            return await Api.UserInfoIssue(request);
        }
    }
}
