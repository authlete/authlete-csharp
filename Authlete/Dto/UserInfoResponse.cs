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
    /// Response from Authlete's <c>/api/auth/userinfo</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/userinfo</c> API returns JSON which
    /// can be mapped to this class. The
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
    /// endpoint</a> implementation should retrieve the value of
    /// the <c>"action"</c> response parameter (which can be
    /// obtained via the <c>Action</c> property of this class) and
    /// take the following steps according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoAction.INTERNAL_SERVER_ERROR</c>, it means that
    /// the request from your system was wrong or that an error
    /// occurred in Authlete. In either case, from a viewpoint of
    /// the client application, it is an error on the server side.
    /// Therefore, the userinfo endpoint implementation should
    /// generate a response to the client application with the HTTP
    /// status of <c>"500 Internal Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a string which describes the error in the format of
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so the userinfo endpoint
    /// implementation can use the string returned from the
    /// property as the value of the <c>WWW-Authenticate</c> header.
    /// </para>
    ///
    /// <para>
    /// The following is an example response which complies with
    /// RFC 6750. Note that OpenID Connect Core 1.0 requires that
    /// an error response from the userinfo endpoint comply with
    /// RFC 6750. See
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfoError">5.3.3.
    /// UserInfo Error Response</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for details.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// WWW-Authenticate: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>UserInfoAction.BAD_REQUEST</c>, it means that the
    /// request from the client application does not contain an
    /// access token (= the request from your system to Authlete
    /// does not contain the <c>"token"</c> request parameter).
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <c>UserInfoAction.UNAUTHORIZED</c>, it means that the
    /// access token does not exist, has expired, or is not
    /// associated with any subject (= any end-user).
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <c>UserInfoAction.FORBIDDEN</c>, it means that the access
    /// token does not have the <c>"openid"</c> scope.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <c>UserInfoAction.OK</c>, it means that the access token
    /// which the client application presented is valid. To be
    /// concrete, it means that the access token exists, has not
    /// expired, has the <c>"openid"</c> scope, and is associated
    /// with a subject (= an end-user).
    /// </para>
    ///
    /// <para>
    /// What the
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
    /// endpoint</a> implementation of your system should do next
    /// is to collect information about the subject (end-user) from
    /// your database. The value of the subject can be obtained
    /// from the <c>Subject</c> property, and the names of data,
    /// i.e., the claim names, can be obtained from the <c>Claims</c>
    /// property. For example, if the <c>Subject</c> property
    /// returns <c>"joe123"</c> and the <c>Claims</c> property
    /// returns <c>["given_name", "email"]</c>, you need to extract
    /// information about <c>joe123</c>'s given name and email from
    /// your database.
    /// </para>
    ///
    /// <para>
    /// Then, call Authlete's <c>/api/auth/userinfo/issue</c> API
    /// with the collected information and the access token in
    /// order to make Authlete generate a userinfo response. See
    /// the description of <c>UserInfoIssueRequest</c> and
    /// <c>UserInfoIssueResponse</c> for details about
    /// <c>/api/auth/userinfo/issue</c> API.
    /// </para>
    ///
    /// <para>
    /// If an error occurred during the above steps, generate an
    /// error response to the client application. The response
    /// should comply with RFC 6750. For example, if the subject
    /// associated with the access token does not exist in your
    /// database any longer, you may feel like generating a
    /// response like below.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// WWW-Authenticate: Bearer error="invalid_token",
    ///   error_description="The user does not exist any longer."
    /// Cache-Control: no-store
    /// Pragram: no-cache
    /// </code>
    ///
    /// <para>
    /// Also, an error might occur on database access. If you treat
    /// the error as an internal server error, then the response
    /// would be like the following.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// WWW-Authenticate: Bearer error="server_error",
    ///   error_description="Failed to access the database."
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    /// </remarks>
    public class UserInfoResponse
    {
        /// <summary>
        /// The next action that the userinfo endpoint should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserInfoAction Action { get; set; }


        /// <summary>
        /// The ID of the client application to which the access
        /// token has been issued.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of an end-user which
        /// is associated with the access token.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The scopes that the access token covers.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The list of claims that the client application requests
        /// to be embedded in the userinfo response. The value
        /// comes from the <c>"scope"</c> and/or <c>"claims"</c>
        /// request parameters of the original authorization
        /// request. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">5.4.
        /// Requesting Claims using Scope Values</a> and
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsParameter">5.5.
        /// Requesting Claims using the "claims" Request Parameter</a>
        /// of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </summary>
        [JsonProperty("claims")]
        public string[] Claims { get; set; }


        /// <summary>
        /// The access token that the userinfo endpoint of your
        /// system received from the client application and sent to
        /// Authlete's <c>/api/auth/userinfo</c> API.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }


        /// <summary>
        /// The response content which can be used as a part of the
        /// response to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// Properties associated with the access token.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// The client ID alias when the authorization request for
        /// the access token was made. Note that this value may be
        /// different from the current client ID alias.
        /// </summary>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was used when the authorization request for the access
        /// token was made.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool ClientIdAliasUsed { get; set; }
    }
}
