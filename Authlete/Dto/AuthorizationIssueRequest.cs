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


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's <c>/api/auth/authorization/issue</c>
    /// API.
    /// </summary>
    public class AuthorizationIssueRequest
    {
        /// <summary>
        /// The ticket issued by Authlete's
        /// <c>/api/auth/authorization</c> API to the authorization
        /// server implementation. It is the value returned from
        /// <c>AuthorizationResponse.Ticket</c>. The ticket is
        /// necessary to call Authlete's
        /// <c>/api/auth/authorization/issue</c> API. This request
        /// parameter is mandatory.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the end-user who
        /// has granted authorization to the client application.
        /// This request parameter is required unless the
        /// authorization request has come with
        /// <c>response_type=none</c> (which means the cient
        /// application did not request any token to be returned).
        /// See
        /// <a href="https://openid.net/specs/oauth-v2-multiple-response-types-1_0.html#none">4.
        /// None Response Type</a> of
        /// <a href="https://openid.net/specs/oauth-v2-multiple-response-types-1_0.html">OAuth
        /// 2.0 Multiple Response Type Encoding Practices</a> for
        /// details about <c>response_type=none</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property is used as the value of the subject
        /// associated with the access token (if one is issued)
        /// and as the value of the <c>"sub"</c> claim in the ID
        /// token (if one is issued).
        /// </para>
        ///
        /// <para>
        /// Note that, if the <c>Sub</c> property returns a
        /// non-empty value, it is used as the value of the
        /// <c>"sub"</c> claim in the ID token. However, even in
        /// such a case, the value of the subject associated with
        /// the access token is still the value of this
        /// <c>Subject</c> property.
        /// </para>
        /// </remarks>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The value of the <c>"sub"</c> claim used in the ID
        /// token which is to be issued. If this property returns
        /// <c>null</c> or its value is empty, the value of the
        /// <c>Subject</c> property is used as the value of the
        /// <c>"sub"</c> claim. The main purpose of this <c>Sub</c>
        /// property is to hide the actual value of the subject
        /// from client applications.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that the value of the <c>Subject</c> property is
        /// used as the value of the subject associated with the
        /// access token regardless of whether this <c>Sub</c>
        /// property holds a non-empty value or not.
        /// </para>
        /// </remarks>
        [JsonProperty("sub")]
        public string Sub { get; set; }


        /// <summary>
        /// The time when the authentication of the end-user
        /// occurred. It should represent the elapsed time since
        /// the Unix epoch (1970-Jan-1) in seconds.
        /// </summary>
        [JsonProperty("authTime")]
        public long AuthTime { get; set; }


        /// <summary>
        /// The Authentication Context Class Reference performed
        /// for the end-user authentication.
        /// </summary>
        [JsonProperty("acr")]
        public string Acr { get; set; }


        /// <summary>
        /// The claims of the end-user (= pieces of information
        /// about the end-user) in JSON format. This request
        /// parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The authorization server implementation is required to
        /// retrieve claims of the subject (= information about the
        /// end-user) from its database and format them in JSON
        /// format.
        /// </para>
        ///
        /// <para>
        /// For example, if <c>"given_name"</c> claim,
        /// <c>"family_name"</c> claim and <c>"email"</c> claim are
        /// requested, the authorization server implementation
        /// should generate a JSON object like the following and
        /// set its string representation to this <c>Claims</c>
        /// property.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "given_name": "Takahiko",
        ///   "family_name": "Kawasaki",
        ///   "email": "takahiko.kawasaki@example.com"
        /// }
        /// </code>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
        /// Standard Claims</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details about the format.
        /// </para>
        /// </remarks>
        [JsonProperty("claims")]
        public string Claims { get; set; }


        /// <summary>
        /// Extra properties that you want to associate with an
        /// access token and/or an authorization code which will be
        /// issued. This request parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Extra properties will be returned to the client
        /// application together with an access token unless they
        /// are marked as hidden. For example, if you set one extra
        /// property as follows:
        /// </para>
        ///
        /// <code>
        /// request.Properties = new Property[] {
        ///     new Property("example_parameter", "example_value")
        /// };
        /// </code>
        ///
        /// <para>
        /// The property will be contained in the final response
        /// from the authorization server as follows:
        /// </para>
        ///
        /// <code>
        /// HTTP/1.1 200 OK
        /// Content-Type: application/json;charset=UTF-8
        /// Cache-Control: no-store
        /// Pragma: no-cache
        ///
        /// {
        ///   "access_token":"2YotnFZFEjr1zCsicMWpAA",
        ///   "token_type":"example",
        ///   "expires_in":3600,
        ///   "refresh_token":"tGzv3JOkF0XG5Qx2TlKWIA",
        ///   "example_parameter":"example_value"
        /// }
        /// </code>
        ///
        /// <para>
        /// The above example is an excerpt from
        /// <a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> in
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </para>
        ///
        /// <para>
        /// Keys listed below should not be used and they would be
        /// ignored on Authlete side even if they were used. It's
        /// because they are reserved in
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>
        /// and
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>.
        /// </para>
        ///
        /// <list type="bullet">
        ///   <item><description><c>access_token</c></description></item>
        ///   <item><description><c>token_type</c></description></item>
        ///   <item><description><c>expires_in</c></description></item>
        ///   <item><description><c>refresh_token</c></description></item>
        ///   <item><description><c>scope</c></description></item>
        ///   <item><description><c>error</c></description></item>
        ///   <item><description><c>error_description</c></description></item>
        ///   <item><description><c>error_uri</c></description></item>
        ///   <item><description><c>id_token</c></description></item>
        /// </list>
        ///
        /// <para>
        /// Note that there is an upper limit on the total size of
        /// extra properties. On Authlete side, the properties will
        /// be (1) converted to a multidimensional string array, (2)
        /// converted to JSON, (3) encrypted by AES/CBC/PKCS5Padding,
        /// (4) encoded by base64url, and then stored into the
        /// database. The length of the resultant string must not
        /// exceed 65,535 in bytes. This is the upper limit, but we
        /// think it is big enough.
        /// </para>
        ///
        /// <para>
        /// You can know extra properties associated with an access
        /// token by calling Authlete's <c>/api/auth/introspection</c>
        /// API.
        /// </para>
        /// </remarks>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// Scopes that should be associated with an authorization
        /// code and/or an access token. If <c>null</c> (the default
        /// value) is set, the scopes specified in the original
        /// authorization request from the client application are
        /// used. In other cases, the scopes set to this property
        /// will replace the original scopes contained in the
        /// original request. This request parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Even scopes that are not included in the original
        /// authorization request can be specified. However, as an
        /// exception, <c>"openid"</c> scope is ignored on Authlete
        /// side if it is not included in the original request (to
        /// be exact, if <c>"openid"</c> was not included in the
        /// <c>parameters</c> request parameter of the request to
        /// <c>/api/auth/authorization</c> API). It is because the
        /// existence of the <c>"openid"</c> scope considerably
        /// changes the validation steps and because adding
        /// <c>"openid"</c> triggers generation of an ID token
        /// (although the client application has not requested it)
        /// and the behavior is a major violation against the
        /// specification.
        /// </para>
        ///
        /// <para>
        /// If you add the <c>"offline_access"</c> scope although
        /// it is not included in the original request, keep in
        /// mind that the specification requires explicit consent
        /// from the end-user for the scope
        /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#OfflineAccess">11.
        /// Offline Access</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>). When <c>"offline_access"</c> is
        /// included in the original authorization request, the
        /// current implementation of Authlete's
        /// <c>/api/auth/authorization</c> API checks whether the
        /// authorization request has come along with the
        /// <c>"prompt"</c> request parameter and its value includes
        /// <c>"consent"</c>. However, note that the implementation
        /// of Authlete's <c>/api/auth/authorization/issue</c> API
        /// does not perform the same validation even if the
        /// <c>"offline_access"</c> scope is newly added via this
        /// <c>Scopes</c> property.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// JSON that represents additional JWS header parameters for ID tokens
        /// that may be issued based on the authorization request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("idtHeaderParams")]
        public string IdtHeaderParams { get; set; }
    }
}
