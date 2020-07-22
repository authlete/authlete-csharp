//
// Copyright (C) 2018-2020 Authlete, Inc.
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
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
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
    /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
    /// (OAuth 2.0 Bearer Token Usage), so if the resource server
    /// has selected <c>"Bearer"</c> as the token type, the string
    /// returned from the <c>ResponseContent</c> property can be
    /// used directly as the value for the <c>WWW-Authenticate</c>
    /// header. However, if the service has selected another
    /// different token type, the resource server has to generate
    /// error message for itself.
    /// </para>
    ///
    /// <hr/>
    ///
    /// <para>
    /// Since version 2.1, Authlete provides a feature to issue
    /// access tokens in JWT format. This feature can be enabled by
    /// setting a non-null value to the <c>AccessTokenSignAlg</c>
    /// property of the service (see the description of the
    /// <c>Service</c> class for details).
    /// <c>/api/auth/introspection</c> API can accept access tokens
    /// in JWT format. However, note that the API does not return
    /// information contained in a given JWT-based access token but
    /// returns information stored in the database record which
    /// corresponds to the given JWT-based access token. Because
    /// attributes of the database record can be modified after the
    /// access token is issued (for example, by using
    /// <c>/api/auth/token/update</c> API), information returned by
    /// <c>/api/auth/introspection</c> API and information the
    /// given JWT-based access token holds may be different.
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
        public bool IsExistent { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token is
        /// usable (= exists and has not expired).
        /// </summary>
        [JsonProperty("usable")]
        public bool IsUsable { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token
        /// covers the required scopes.
        /// </summary>
        [JsonProperty("sufficient")]
        public bool IsSufficient { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token can
        /// be refreshed using the associated refresh token. Even
        /// if there exists a refresh token associated with the
        /// access token, this property returns <c>false</c> if the
        /// refresh token has already expired.
        /// </summary>
        [JsonProperty("refreshable")]
        public bool IsRefreshable { get; set; }


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


        /// <summary>
        /// The flag which indicates whether the access token is
        /// active (= exists and has not expired). This property is
        /// just an alias of the `IsUsable` property. The reason
        /// this property was added is to mitigate confusion that
        /// those who are familiar with
        /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>
        /// (OAuth 2.0 Token Introspection) may have.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.6.
        /// </para>
        /// </remarks>
        public bool IsActive
        {
            get {
                return IsUsable;
            }

            set {
                IsUsable = value;
            }
        }


        /// <summary>
        /// Arbitrary properties associated with the access token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.1.0.</para>
        /// </remarks>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// The client ID alias when the authorization request or
        /// the token request for the access token was made. Note
        /// that this value may be different from the current
        /// client ID alias.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.1.0.</para>
        /// </remarks>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was sed when the authorization request or the token
        /// request for the access token was made.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.1.0.</para>
        /// </remarks>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The thumbprint of the client certificate which is
        /// associated with the access token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the access token is bound to a client certificate,
        /// this property holds the thumbprint of the client
        /// certificate.
        /// </para>
        ///
        /// <para>
        /// Since version 1.0.9.
        /// </para>
        /// </remarks>
        [JsonProperty("certificateThumbprint")]
        public string CertificateThumbprint { get; set; }


        /// <summary>
        /// The target resources. This represents the resources specified by the
        /// <c>resource</c> request parameters or by the <c>resource</c>
        /// property in the request object. See
        /// <a href="https://www.rfc-editor.org/rfc/rfc8707.html">RFC 8707</a>
        /// (Resource Indicators for OAuth 2.0) for details.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("resources")]
        public string[] Resources { get; set; }


        /// <summary>
        /// The target resources of the access token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The target resources held by this property may be the same as or
        /// different from the ones held by the <c>Resources</c> property.
        /// </para>
        ///
        /// <para>
        /// In some flows, the initial request and the subsequent token request
        /// are sent to different endpoints. Example flows are the authorization
        /// code flow, the refresh token flow, the CIBA Ping mode, the CIBA Poll
        /// mode and the device flow. In these flows, not only the initial
        /// request but also the subsequent token request can include the
        /// <c>resource</c> request parameters. The purpose of the <c>resource</c>
        /// request parameters in the token request is to narrow the range of
        /// the target resources from the original set of target resources
        /// requested by the preceding initial request. If narrowing down is
        /// performed, the target resources held by the <c>Resources</c>
        /// property and the ones held by this <c>AccessTokenResources</c>
        /// property are different. This property holds the narrowed set of
        /// target resources.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenResources")]
        public string[] AccessTokenResources { get; set; }
    }
}
