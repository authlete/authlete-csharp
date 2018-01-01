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
    /// Response from Authlete's <c>/api/auth/token/issue</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/token/issue</c> API returns JSON
    /// which can be mapped to this class. The token endpoint
    /// implementation should retrieve the value of the
    /// <c>"action"</c> response parameter (which can be obtained
    /// via the <c>Action</c> property of this class) from the
    /// response and take the following steps according to the
    /// value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenIssueAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the request from your system was wrong or that an
    /// error occurred in Authlete. In either case, from a
    /// viewpoint of the client application, it is an error on the
    /// server side. Therefore, the token endpoint implementation
    /// should generate a response to the client application with
    /// the HTTP status of <c>"500 Internal Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// JSON string which describes the error, so it can be used as
    /// the entity body of the response. The following illustrates
    /// the response which the token endpoint implementation should
    /// generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenIssueAction.OK</c>, it means that Authlete's
    /// <c>/api/auth/token/issue</c> API successfully generated an
    /// access token. The HTTP status of the response returned to
    /// the client application must be <c>"200 OK"</c> and the
    /// content type must be <c>"application/json"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// JSON string which contains the issued access token, so it
    /// can be used as the entity body of the response. The
    /// following illustrates the response which the token endpoint
    /// implementation should generate and return to the client
    /// application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    /// </remarks>
    public class TokenIssueResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the token endpoint implementation
        /// should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenIssueAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The newly issued access token. This property returns
        /// a non-null value only when the <c>Action</c> property
        /// returns <c>TokenIssueAction.OK</c>.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The date at which the access token will expire. The
        /// value is expressed in milliseconds since the Unix epoch
        /// (1970-Jan-1).
        /// </summary>
        [JsonProperty("accessTokenExpiresAt")]
        public long AccessTokenExpiresAt { get; set; }


        /// <summary>
        /// The duration of the access token in seconds.
        /// </summary>
        [JsonProperty("accessTokenDuration")]
        public long AccessTokenDuration { get; set; }


        /// <summary>
        /// The newly issued refresh token. This property returns
        /// a non-null value only when the <c>Action</c> property
        /// returns <c>TokenIssueAction.OK</c> and the service is
        /// configured to support the
        /// <a href="https://tools.ietf.org/html/rfc6749#section-6">refresh
        /// token flow</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If <i>"Refresh Token Continuous Use"</i> conifiguration
        /// parameter of the service is <c>NO</c>
        /// (= <c>refreshTokenKept=false</c>), a new refresh token
        /// is issued and the old refresh token used in the refresh
        /// token flow is invalidated. On the contrary, if the
        /// configuration parameter is <c>YES</c>, the refresh
        /// token itself is not refreshed.
        /// </para>
        /// </remarks>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The date at which the refresh token will expire. The
        /// value is expressed in milliseconds since the Unix epoch
        /// (1970-Jan-1).
        /// </summary>
        [JsonProperty("refreshTokenExpiresAt")]
        public long RefreshTokenExpiresAt { get; set; }


        /// <summary>
        /// The duration of the refresh token in seconds.
        /// </summary>
        [JsonProperty("refreshTokenDuration")]
        public long RefreshTokenDuration { get; set; }


        /// <summary>
        /// The ID of the client application associated with the
        /// access token.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The client ID alias. If no alias is assigned to the
        /// client application, this property returns <c>null</c>.
        /// </summary>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was used when the token request was made.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the user
        /// (= resource owner) of the access token.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The scopes covered by the access token.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// Extra properties associated with the access token.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
