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


using Authlete.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's <c>/api/auth/token/create</c> API.
    /// The API can be used to create an arbitrary access token
    /// without using standard flows.
    /// </summary>
    public class TokenCreateRequest
    {
        /// <summary>
        /// The grant type to be emulated for a newly created
        /// access token. When this property is either
        /// <c>GrantType.IMPLICIT</c> or
        /// <c>GrantType.CLIENT_CREDENTIALS</c>, a refresh token is
        /// not issued. This request parameter is mandatory.
        /// </summary>
        [JsonProperty("grantType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GrantType GrantType { get; set; }


        /// <summary>
        /// The ID of the client application which will be
        /// associated with a newly created access token. This
        /// request parameter is mandatory.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the user who will
        /// be associated with a newly created access token. This
        /// request parameter is required unless the grant type is
        /// <c>GrantType.CLIENT_CREDENTIALS</c>. The value must
        /// consist of only ASCII characters and its length must
        /// not exceed 100.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The scopes which will be associated with a newly
        /// created access token. Scopes that are not supported by
        /// the service cannot be specified and requesting them
        /// will cause an error. This request parameter is optional.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The duration of a newly created access token in seconds.
        /// If the value is <c>0</c>, the duration is determined
        /// according to the settings of the service. This request
        /// parameter is optional.
        /// </summary>
        [JsonProperty("accessTokenDuration")]
        public long AccessTokenDuration { get; set; }


        /// <summary>
        /// The duration of a newly created refresh token in
        /// seconds. If the value is <c>0</c>, the duration is
        /// determined according to the settings of the service.
        /// This request parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A refresh token is not created (1) if the service is
        /// configured not to support <c>GrantType.REFRESH_TOKEN</c>,
        /// or (2) if the specified grant type is either
        /// <c>GrantType.IMPLICIT</c> or
        /// <c>GrantType.CLIENT_CREDENTIALS</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("refreshTokenDuration")]
        public long RefreshTokenDuration { get; set; }


        /// <summary>
        /// Extra properties to be associated with a newly created
        /// access token. Note that the <c>"properties"</c> request
        /// parameter is accepted only when <c>Content-Type</c> of
        /// the request is <c>"application/json"</c>, so don't use
        /// <c>"application/x-www-form-urlencoded"</c> if you want
        /// to use this <c>"properties"</c> request parameter.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// The flag which indicates whether to emulate that the
        /// client ID alias is used instead of the original numeric
        /// client ID when a new access token is created.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This has an effect only on the value of the <c>"aud"</c>
        /// claim in a response from a
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a>. When you access the userinfo endpoint
        /// (which is expected to be implemented using Authlete's
        /// <c>/api/auth/userinfo</c> API and
        /// <c>/api/auth/userinfo/issue</c> API) with an access
        /// token which has been created using Authlete's
        /// <c>/api/auth/token/create</c> API with this property
        /// (<c>IsClientIdAliasUsed</c>) <c>true</c>, the client ID
        /// alias is used as the value of the <c>"aud"</c> claim in
        /// a response from the userinfo endpoint.
        /// </para>
        ///
        /// <para>
        /// Note that if a client ID alias is not assigned to the
        /// client when Authlete's <c>/api/auth/token/create</c>
        /// API is called, this property has no effect (it is
        /// always regarded as <c>false</c>).
        /// </para>
        /// </remarks>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The value of the new access token. This request
        /// parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The <c>/api/auth/token/create</c> API generates an
        /// access token. Therefore, callers of the API do not have
        /// to specify values of newly created access tokens.
        /// However, in some cases, for example, if you want to
        /// migrate existing access tokens from an old system to
        /// Authlete, you may want to specify values of access
        /// tokens. In such a case, you can specify the value of a
        /// newly created access token by passing a non-null value
        /// as the value of the <c>"accessToken"</c> request
        /// parameter. The implementation of the
        /// <c>/api/auth/token/create</c> API uses the value of the
        /// <c>"accessToken"</c> request parameter instead of
        /// generating a new value when the request parameter holds
        /// a non-null value.
        /// </para>
        ///
        /// <para>
        /// Note that if the hash value of the specified access
        /// token already exists in Authlete's database, the access
        /// token cannot be inserted and the
        /// <c>/api/auth/token/create</c> API will report an error.
        /// </para>
        /// </remarks>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The value of the new refresh token. This request
        /// parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The <c>/api/auth/token/create</c> API generates a
        /// refresh token as necessary. Therefore, callers of the
        /// API do not have to specify values of newly created
        /// refresh tokens. However, in some cases, for example, if
        /// you want to migrate existing refresh tokens from an old
        /// system to Authlete, you may want to specify values of
        /// refresh tokens. In such a case, you can specify the
        /// value of a newly created refresh token by passing a
        /// non-null value as the value of the <c>"refreshToken"</c>
        /// request parameter. The implementation of the
        /// <c>/api/auth/token/create</c> API uses the value of the
        /// <c>"refreshToken"</c> request parameter instead of
        /// generating a new value when the request parameter holds
        /// a non-null value.
        /// </para>
        ///
        /// <para>
        /// Note that if the hash value of the specified refresh
        /// token already exists in Authlete's database, the
        /// refresh token cannot be inserted and the
        /// <c>/api/auth/token/create</c> API will report an error.
        /// </para>
        /// </remarks>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token
        /// expires or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// By default, all access tokens expire after a period of
        /// time determined by their service. If this request
        /// parameter is <c>true</c> then the access token will not
        /// automatically expire and must be revoked or deleted
        /// manually at the service.
        /// </para>
        ///
        /// <para>
        /// If this request parameter is <c>true</c>, the
        /// <c>accessTokenDuration</c> request parameter is ignored.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenPersistent")]
        public bool IsAccessTokenPersistent { get; set; }


        /// <summary>
        /// The thumbprint of the client certificate bound to the token. If this
        /// property is set, a certificate whose thumbprint matches the value
        /// must be presented with the access token when it is used by a client.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <a href="https://www.rfc-editor.org/rfc/rfc8705.html">RFC 8705</a>
        /// (OAuth 2.0 Mutual-TLS Client Authentication and Certificate-Bound
        /// Access Tokens) for details.
        /// </para>
        ///
        /// <para>
        /// The value should be a base64url-encoded SHA-256 certificate thumbprint.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("certificateThumbprint")]
        public string CertificateThumbprint { get; set; }


        /// <summary>
        /// The thumbprint of the public key used for DPoP presentation of the
        /// token. If this property is set, a DPoP proof JWT signed with the
        /// corresponding private key must be presented with the access token
        /// when it is used by a client.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See "OAuth 2.0 Demonstration of Proof-of-Possession at the
        /// Application Layer (DPoP)" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("dpopKeyThumbprint")]
        public string DpopKeyThumbprint { get; set; }
    }
}
