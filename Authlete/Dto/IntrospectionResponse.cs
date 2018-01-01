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
    /// Response from Authlete's <c>/api/auth/introspection</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/introspection</c> API returns JSON
    /// which can be mapped to this class. The resource server
    /// should retrieve the value of the <c>"action"</c> response
    /// parameter from the response and take the following steps
    /// according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>IntrospectionAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the request from the resource server was wrong or that
    /// an error occurred in Authlete. In either case, from a
    /// viewpoint of the client application, it is an error on the
    /// server side. Therefore, the resource server should generate
    /// a response to the client application with the HTTP status
    /// of <c>"500 Internal Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the protected
    /// resource of the resource server wants to return an error
    /// response to the client application in the way that complies
    /// with RFC 6750, the string returned from the
    /// <c>ResponseContent</c> property can be used as the value of
    /// the <c>WWW-Authenticate</c> header. The following is an
    /// example response which complies with RFC 6750.
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
    /// <c>IntrospectionAction.BAD_REQUEST</c>, it means that the
    /// request from the client application does not contain an
    /// access token (= the request from the resource server to
    /// Authlete does not contain the <c>"token"</c> request
    /// parameter).
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the protected
    /// resource of the resource server wants to return an error
    /// response to the client application in the way that complies
    /// with RFC 6750, the string returned from the
    /// <c>ResponseContent</c> property can be used as the value of
    /// the <c>WWW-Authenticate</c> header. The following is an
    /// example response which complies with RFC 6750.
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
    /// <c>IntrospectionAction.UNAUTHORIZED</c>, it means that the
    /// access token does not exist or has expired. Or the client
    /// application associated with the access token does not exist
    /// any longer.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the protected
    /// resource of the resource server wants to return an error
    /// response to the client application in the way that complies
    /// with RFC 6750, the string returned from the
    /// <c>ResponseContent</c> property can be used as the value of
    /// the <c>WWW-Authenticate</c> header. The following is an
    /// example response which complies with RFC 6750.
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
    /// <c>IntrospectionAction.FORBIDDEN</c>, it means that the
    /// access token does not cover the required scopes or that the
    /// subject associated with the access token is different from
    /// the subject specified by the API call.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the protected
    /// resource of the resource server wants to return an error
    /// response to the client application in the way that complies
    /// with RFC 6750, the string returned from the
    /// <c>ResponseContent</c> property can be used as the value of
    /// the <c>WWW-Authenticate</c> header. The following is an
    /// example response which complies with RFC 6750.
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
    /// <c>IntrospectionAction.OK</c>, it means that the access
    /// token which the client application presented is valid (=
    /// exists and has not expired). The resource server is
    /// supposed to return the proteced resource to the client
    /// application.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// <c>"Bearer error=\"invalid_request\""</c>. This is the
    /// simplest string which can be used as the value of the
    /// <c>WWW-Authenticate</c> header to indicate <c>"400 Bad
    /// Request"</c>. The resource server may use this string to
    /// tell the client application that the request was bad. But
    /// in such a case, if possible, the resource server should
    /// generate a more informative error message to help
    /// developers of client applications. The following is an
    /// example error response which complies with RFC 6750.
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
    /// Basically, the <c>ResponseContent</c> property returns a
    /// string which describes the error in the format of
    /// <a href="http://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the resource server
    /// has selected <c>"Bearer"</c> as the token type, the string
    /// returned from the <c>ResponseContent</c> property can be
    /// used directly as the value for the <c>WWW-Authenticate</c>
    /// header. However, if the service has selected another
    /// different token type, the resource server has to generate
    /// error message for itself.
    /// </para>
    /// </remarks>
    public class IntrospectionResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the resource server should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IntrospectionAction Action { get; set; }


        /// <summary>
        /// The client ID of the client application to which the
        /// access token has been issued.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the end-user
        /// (= resource owner) who allowed the authorization server
        /// to issue the access token to the client application.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// Scopes that are associated with the access token.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token
        /// exists or not.
        /// </summary>
        [JsonProperty("existent")]
        public bool Existent { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token is
        /// usable (= exists and has not expired).
        /// </summary>
        [JsonProperty("usable")]
        public bool Usable { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token
        /// covers the required scopes.
        /// </summary>
        [JsonProperty("sufficient")]
        public bool Sufficient { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token can
        /// be refreshed using the associated refresh token. Even
        /// if there exists a refresh token associated with the
        /// access token, this property returns <c>false</c> if the
        /// refresh token has already expired.
        /// </summary>
        [JsonProperty("refreshable")]
        public bool Refreshable { get; set; }


        /// <summary>
        /// The response content which can be used as a part of the
        /// response to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The time at which the access token will expire. The
        /// value is represented as milliseconds since the Unix
        /// epoch (1970-Jan-1).
        /// </summary>
        [JsonProperty("expiresAt")]
        public long ExpiresAt { get; set; }
    }
}
