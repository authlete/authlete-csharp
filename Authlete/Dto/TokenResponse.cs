//
// Copyright (C) 2018-2019 Authlete, Inc.
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
using Authlete.Types;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/auth/token</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/token</c> API returns JSON which
    /// can be mapped to this class. The token endpoint
    /// implementation should retrieve the value of the
    /// <c>"action"</c> response parameter (which can be obtained
    /// via the <c>Action</c> property of this class) from the
    /// response and take the following steps according to the
    /// value.
    /// </para>
    ///
    /// <hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenAction.INVALID_CLIENT</c>, it means that
    /// authentication of the client failed. In this case, the HTTP
    /// status of the response to the client application should be
    /// either <c>"400 Bad Request"</c> or <c>"401 Unauthorized"</c>.
    /// This requirement comes from
    /// <a href="https://tools.ietf.org/html/rfc6749#section-5.2">5.2.
    /// Error Response</a> of
    /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
    /// The description about <c>"invalid_client"</c> shown below
    /// is an excerpt from RFC 6749.
    /// </para>
    ///
    /// <para>
    /// <i>Client authentication failed (e.g., unknown client, no
    /// client authentication included, or unsupported
    /// authentication method). The authorization server MAY return
    /// an HTTP 401 (Unauthorized) status code to indicate which
    /// HTTP authentication schemes are supported. If the client
    /// attempted to authenticate via the "Authorization" request
    /// header field, the authorization server MUST respond with an
    /// HTTP 401 (Unauthorized) status code and include the
    /// <a href="https://tools.ietf.org/html/rfc2616#section-14.47">"WWW-Authenticate"</a>
    /// response header field matching the authentication scheme
    /// used by the client.</i>
    /// </para>
    ///
    /// <para>
    /// In either case, the JSON string returned by the
    /// <c>ResponseContent</c> property can be used as the entity
    /// body of the response to the client application. The
    /// following illustrates the response which the token endpoint
    /// implementation should generate and return to the client
    /// application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <code>
    /// HTTP/1.1 401 Unauthorized
    /// WWW-Authenticate: <i>(challenge)</i>
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenAction.INTERNAL_SERVER_ERROR</c>, it means that the
    /// request from your system was wrong or that an error
    /// occurred in Authlete. In either case, from a viewpoint of
    /// the client application, it is an error on the server side.
    /// Therefore, the token endpoint implementation should
    /// generate a response to the client application with the HTTP
    /// status of <c>"500 Internal Server Error"</c>.
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
    /// <hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenAction.BAD_REQUEST</c>, it means that the request
    /// from the client application is invalid. The HTTP status of
    /// the response returned to the client application must be
    /// <c>"400 Bad Request"</c> and the content type must be
    /// <c>"application/json"</c>.
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
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenAction.PASSWORD</c>, it means that the request from
    /// the client application is valid and the value of the
    /// <c>"grant_type"</c> request parameter was <c>"password"</c>.
    /// This indicates that the flow is
    /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
    /// Owner Password Credentials Flow</a>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>Username</c> property returns the
    /// value of the <c>"username"</c> request parameter and the
    /// <c>Password</c> property returns the value of the
    /// <c>"password"</c> request parameter which were contained
    /// in the token request from the client application. The token
    /// endpoint implementation must validate the credentials of
    /// the resource owner (= end-user) and take either of the
    /// actions below according to the validation result.
    /// </para>
    ///
    /// <para>
    /// (1) When the credentials are valid, call Authlete's
    /// <c>/api/auth/token/issue</c> API to generate an access. The
    /// API requires a <c>"ticket"</c> request parameter and a
    /// <c>"subject"</c> request parameter. Use the value returned
    /// from the <c>TokenResponse.Ticket</c> property as the value
    /// for the <c>"ticket"</c> request parameter.
    /// </para>
    ///
    /// <para>
    /// The response from <c>/api/auth/token/issue</c> API
    /// (<c>TokenIssueResponse</c>) contains data (an access token
    /// and others) which should be returned to the client
    /// application. Use the data to generate a response to the
    /// client application.
    /// </para>
    ///
    /// <para>
    /// (2) When the credentials are invalid, call Authlete's
    /// <c>/api/auth/token/fail</c> API with
    /// <c>reason=INVALID_RESOURCE_OWNER_CREDENTIALS</c> to
    /// generate an error response for the client application. The
    /// API requires a <c>"ticket"</c> request parameter. Use the
    /// value returned from the <c>TokenResponse.Ticket</c>
    /// property as the value for the <c>"ticket"</c> request
    /// parameter.
    /// </para>
    ///
    /// <para>
    /// The response from <c>/api/auth/token/fail</c> API
    /// (<c>TokenFailResponse</c>) contains error information which
    /// should be returned to the client application. Use it to
    /// generate a response to the client application.
    /// </para>
    ///
    /// <hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenAction.OK</c>, it means that the request from the
    /// client application is valid, and an access token and
    /// optionally an ID token are ready to be issued. The HTTP
    /// status of the response returned to the client application
    /// must be <c>"200 OK"</c> and the content type must be
    /// <c>"application/json"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// JSON string which contains an access token (and optionally
    /// an ID token), so it can be used as the entity body of the
    /// response. The following illustrates the response which the
    /// token endpoint implementation should generate and return to
    /// the client application.
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
    public class TokenResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the token endpoint should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The value of the <c>"username"</c> request parameter
        /// contained in the token request from the client
        /// application.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }


        /// <summary>
        /// The value of the <c>"password"</c> request parameter
        /// contained in the token request from the client
        /// application.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }


        /// <summary>
        /// A ticket issued from Authlete's <c>/api/auth/token</c>
        /// API. The value is to be used as the value of the
        /// <c>"ticket"</c> rquest parameter when you call
        /// <c>/api/auth/token/issue</c> API or
        /// <c>/api/auth/token/fail</c> API.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The newly issued access token. This property returns a
        /// non-null value only when the <c>Action</c> property
        /// returns <c>TokenAction.OK</c>.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The date in milliseconds since the Unix epoch
        /// (1970-Jan-1) at which the access token will expire.
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
        /// returns <c>TokenAction.OK</c> and the service is
        /// configured to support the
        /// <a href="https://tools.ietf.org/html/rfc6749#section-6">refresh
        /// token flow</a>.
        /// </summary>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The date in milliseconds since the Unix epoch
        /// (1970-Jan-1) at which the refresh token will expire.
        /// </summary>
        [JsonProperty("refreshTokenExpiresAt")]
        public long RefreshTokenExpiresAt { get; set; }


        /// <summary>
        /// The duration of the refresh token in seconds.
        /// </summary>
        [JsonProperty("refreshTokenDuration")]
        public long RefreshTokenDuration { get; set; }


        /// <summary>
        /// The newly issued ID token. An
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#IDToken">ID
        /// token</a> is issued from a token endpoint when the
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.1">authorization
        /// code flow</a> is used and <c>"openid"</c> is included
        /// in the scope list.
        /// </summary>
        [JsonProperty("idToken")]
        public string IdToken { get; set; }


        /// <summary>
        /// The grant type of the token request.
        /// </summary>
        [JsonProperty("grantType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GrantType GrantType { get; set; }


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
        ///
        /// <remarks>
        /// Even if an access token was issued by the call of
        /// <c>/api/auth/token</c> API, this property returns
        /// <c>null</c> if the flow of the token request was
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.4">Client
        /// Credentials Flow</a> (<c>grant_type=client_credentials</c>)
        /// because access tokens are not associated with any
        /// specific end-user in the flow.
        /// </remarks>
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


        /// <summary>
        /// The newly issued access token in JWT format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the authorization server is configured to issue
        /// JWT-based access tokens (= if the
        /// <c>AccessTokenSignAlg</c> property of the
        /// <c>Service</c> holds a non-null value), a JWT-based
        /// access token is issued along with the original
        /// random-string one.
        /// </para>
        ///
        /// <para>
        /// Regarding the detailed format of the JWT-based access
        /// token, see the description of the <c>Service</c> class.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("jwtAccessToken")]
        public string JwtAccessToken { get; set; }
    }
}
