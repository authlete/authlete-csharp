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


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/auth/userinfo/issue</c>
    /// API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/userinfo/issue</c> API returns JSON
    /// which can be mapped to this class. The
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
    /// endpoint</a> implementation should retrieve the value of
    /// the <c>"action"</c> response parameter (which can be
    /// obtained via the <c>Action</c> property of this class) from
    /// the response and take the following steps according to the
    /// value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the request from your system was wrong or that an
    /// error occurred in Authlete. In either case, from a
    /// viewpoint of the client application, it is an error on the
    /// server side. Therefore, the userinfo endpoint
    /// implementation should generate a response to the client
    /// application with the HTTP status of <c>"500 Internal Server
    /// Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so the userinfo endpoint
    /// implementation of your system can use the string returned
    /// from the property as the value of the <c>WWW-Authenticate</c>
    /// header. The following is an example response which complies
    /// with RFC 6750. Note that OpenID Connect Core 1.0 requires
    /// that an error response from the userinfo endpoint comply
    /// with RFC 6750. See
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#UserInfoError">5.3.3.
    /// UserInfoResponse</a> for details.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// WWW-Authenticate: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragram: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.BAD_REQUEST</c>, it means that the
    /// request from the client application does not contain an
    /// access token (= the request from your system to Authlete
    /// does not contain the <c>"token"</c> request parameter).
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so the userinfo endpoint
    /// implementation can use the string returned from the
    /// property as the value of the <c>WWW-Authenticate</c> header.
    /// The following is an example response from the userinfo
    /// endpoint to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// WWW-Authenticate: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.UNAUTHORIZED</c>, it means that the
    /// access token does not exist, has expired, or is not
    /// associated with any subject (= any end-user).
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so the userinfo endpoint
    /// implementation can use the string returned from the
    /// property as the value of the <c>WWW-Authenticate</c> header.
    /// The following is an example response from the userinfo
    /// endpoint to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 401 Unauthorized
    /// WWW-Authenticate: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.FORBIDDEN</c>, it means that the
    /// access token does not have the <c>"openid"</c> scope.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so the userinfo endpoint
    /// implementation can use the string returned from the
    /// property as the value of the <c>WWW-Authenticate</c> header.
    /// The following is an example response from the userinfo
    /// endpoint to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 403 Forbidden
    /// WWW-Authenticate: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.JSON</c>, it means that the access
    /// token which the client application presented is valid and
    /// a userinfo response was successfully generated in the
    /// format of JSON.
    /// </para>
    ///
    /// <para>
    /// The userinfo endpoint of your system is expected to
    /// generate a response to the client application. The content
    /// type of the response must be <c>"application/json"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a userinfo response in JSON format, so a response to the
    /// client can be built like below.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// Content-Type: application/json;charset=UTF-8
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoIssueAction.JWT</c>, it means that the access
    /// token which the client application presented is valid and
    /// a userinfo response was successfully generated in the
    /// format of JWT
    /// (<a href="https://tools.ietf.org/html/rfc7519">RFC 7519</a>).
    /// </para>
    ///
    /// <para>
    /// The userinfo endpoint of your system is expected to
    /// generate a response to the client application. The content
    /// type of the response must be <c>"application/jwt"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a userinfo response in JWT format, so a response to the
    /// client can be built like below.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// Content-Type: application/jwt
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    /// </remarks>
    public class UserInfoIssueResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the userinfo endpoint should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserInfoIssueAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned from the userinfo
        /// endpoint implementation to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }
    }
}
