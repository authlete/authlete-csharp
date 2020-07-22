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
using System;


namespace Authlete.Dto
{
    /// <summary>
    /// Information about a client application.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Some properties correspond to the ones listed in
    /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
    /// Client Metadata</a> of
    /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
    /// Connect Dynamic Client Registration 1.0</a>.
    /// </para>
    /// </remarks>
    public class Client
    {
        /// <summary>
        /// The unique ID of the developer of this client
        /// application.
        /// </summary>
        [JsonProperty("developer")]
        public string Developer { get; set; }


        /// <summary>
        /// The client ID which is expected to be used as the value
        /// of the <c>"client_id"</c> request parameter of
        /// authorization requests and token requests.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The alias of the client ID.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that the client ID alias is recognized only when
        /// this client's <c>IsClientIdAliasEnabled</c> property is
        /// <c>true</c> AND the <c>Service</c>'s
        /// <c>IsClientIdAliasEnabled</c> property is also <c>true</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias is
        /// enabled or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that <c>Service</c> class also has
        /// <c>IsClientIdAliasEnabled</c> property. If the service's
        /// <c>IsClientIdAliasEnabled</c> property is <c>false</c>,
        /// the client ID alias of this client is not recognized
        /// even if this client's <c>IsClientIdAliasEnabled</c>
        /// property is <c>true</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("clientIdAliasEnabled")]
        public bool IsClientIdAliasEnabled { get; set; }


        /// <summary>
        /// The client secret which is expected to be used as the
        /// value of the <c>"client_secret"</c> request parameter
        /// of token requests.
        /// </summary>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }


        /// <summary>
        /// The client type, either <c>ClientType.PUBLIC</c> or
        /// <c>ClientType.CONFIDENTIAL</c>. The definition of
        /// <i>"Client Type"</i> is described in
        /// <a href="https://tools.ietf.org/html/rfc6749#section-2.1">2.1.
        /// Client Types</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </summary>
        [JsonProperty("clientType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientType ClientType { get; set; }


        /// <summary>
        /// Redirect URIs. See
        /// <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">3.1.2.
        /// Redirection Endpoint</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </summary>
        [JsonProperty("redirectUris")]
        public string[] RedirectUris { get; set; }


        /// <summary>
        /// The <c>"response_type"</c> values that this client
        /// application is declaring that it will restrict itself
        /// to using. This property corresponds to the
        /// <c>"response_types"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("responseTypes", ItemConverterType = typeof(StringEnumConverter))]
        public ResponseType[] ResponseTypes { get; set; }


        /// <summary>
        /// The <c>"grant_type"</c> values that this client
        /// application is declaring that it will restrict itself
        /// to using. This property corresponds to the
        /// <c>"grant_types"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("grantTypes", ItemConverterType = typeof(StringEnumConverter))]
        public GrantType[] GrantTypes { get; set; }


        /// <summary>
        /// The application type of this client application.
        /// <c>WEB</c>, <c>NATIVE</c> or <c>null</c>. This property
        /// corresponds to the <c>"application_type"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("applicationType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplicationType ApplicationType { get; set; }


        /// <summary>
        /// The email addresses of contacts for this client
        /// application. This property corresponds to the
        /// <c>"contacts"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("contacts")]
        public string[] Contacts { get; set; }


        /// <summary>
        /// The name of this client application. This property
        /// corresponds to the <c>"client_name"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("clientName")]
        public string ClientName { get; set; }


        /// <summary>
        /// Localized names of this client application.
        /// </summary>
        [JsonProperty("clientNames")]
        public TaggedValue[] ClientNames { get; set; }


        /// <summary>
        /// The URI of the logo image of this client application.
        /// This property corresponds to the <c>"logo_uri"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("logoUri")]
        public Uri LogoUri { get; set; }


        /// <summary>
        /// URIs of localized logo images of this client application.
        /// </summary>
        [JsonProperty("logoUris")]
        public TaggedValue[] LogoUris { get; set; }


        /// <summary>
        /// The URI of the home page of this client application.
        /// This property corresponds to the <c>"client_uri"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("clientUri")]
        public Uri ClientUri { get; set; }


        /// <summary>
        /// URIs of localized home pages of this client application.
        /// </summary>
        [JsonProperty("clientUris")]
        public TaggedValue[] ClientUris { get; set; }


        /// <summary>
        /// The URI of the policy page which describes how this
        /// client application uses the profile data of the
        /// end-user. This property corresponds to the
        /// <c>"policy_uri"</c> defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("policyUri")]
        public Uri PolicyUri { get; set; }


        /// <summary>
        /// URIs of localized policy pages of this client
        /// application.
        /// </summary>
        [JsonProperty("policyUris")]
        public TaggedValue[] PolicyUris { get; set; }


        /// <summary>
        /// The URI of the "Terms Of Service" page of this
        /// client application. This property corresponds to the
        /// <c>"tos_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("tosUri")]
        public Uri TosUri { get; set; }


        /// <summary>
        /// URIs of localized "Terms Of Service" pages of this
        /// client application.
        /// </summary>
        [JsonProperty("tosUris")]
        public TaggedValue[] TosUris { get; set; }


        /// <summary>
        /// The URI of the JSON Web Key Set of this client
        /// application. This property corresponds to the
        /// <c>"jwks_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("jwksUri")]
        public Uri JwksUri { get; set; }


        /// <summary>
        /// The JSON Web Key Set of this client application. This
        /// property corresponds to the
        /// <c>"jwks"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("jwks")]
        public String Jwks { get; set; }


        /// <summary>
        /// The sector identifier host component as derived from either the
        /// <c>sector_identifier_uri</c> or the registered <c>redirect_uri</c>.
        /// If no <c>sector_identifier_uri</c> is registered and multiple
        /// redirect URIs are registered, this value is undefined and this
        /// property holds null.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <a href="https://openid.net/specs/openid-connect-core-1_0.html#PairwiseAlg">8.1.
        /// Pairwise Identifier Algorithm</a> of OpenID Connect Core 1.0 for
        /// details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("derivedSectorIdentifier")]
        public String DerivedSectorIdentifier { get; set; }


        /// <summary>
        /// The sector identifier URI. This property corresponds to
        /// the <c>"sector_identifier_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>. See
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#SectorIdentifierValidation">5.
        /// "sector_identifier_uri" Validation</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> for details.
        /// </summary>
        [JsonProperty("sectorIdentifierUri")]
        public Uri SectorIdentifierUri { get; set; }


        /// <summary>
        /// The subject type. This property corresponds to the
        /// <c>"subject_type"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#SubjectIDTypes">8.
        /// Subject Identifier Types</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </summary>
        [JsonProperty("subjectType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubjectType SubjectType { get; set; }


        /// <summary>
        /// The JWS <c>"alg"</c> algorithm for signing ID tokens
        /// issued to this client application. This property
        /// corresponds to the <c>"id_token_signed_response_alg"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("idTokenSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg IdTokenSignAlg { get; set; }


        /// <summary>
        /// The JWE <c>"alg"</c> algorithm for encrypting ID tokens
        /// issued to this client application. This property
        /// corresponds to the <c>"id_token_encrypted_response_alg"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("idTokenEncryptionAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEAlg IdTokenEncryptionAlg { get; set; }


        /// <summary>
        /// The JWE <c>"enc"</c> algorithm for encrypting ID tokens
        /// issued to this client application. This property
        /// corresponds to the <c>"id_token_encrypted_response_enc"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("idTokenEncryptionEnc")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEEnc IdTokenEncryptionEnc { get; set; }


        /// <summary>
        /// The JWS <c>"alg"</c> algorithm for signing UserInfo
        /// responses. This property corresponds to the
        /// <c>"userinfo_signed_response_alg"</c> metadata defined
        /// in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("userInfoSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg UserInfoSignAlg { get; set; }


        /// <summary>
        /// The JWE <c>"alg"</c> algorithm for encrypting UserInfo
        /// responses. This property corresponds to the
        /// <c>"userinfo_encrypted_response_alg"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("userInfoEncryptionAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEAlg UserInfoEncryptionAlg { get; set; }


        /// <summary>
        /// The JWE <c>"enc"</c> algorithm for encrypting UserInfo
        /// responses. This property corresponds to the
        /// <c>"userinfo_encrypted_response_enc"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("userInfoEncryptionEnc")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEEnc UserInfoEncryptionEnc { get; set; }


        /// <summary>
        /// The JWS <c>"alg"</c> algorithm for signing request
        /// objects. This property corresponds to the
        /// <c>"request_object_signing_alg"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("requestSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg RequestSignAlg { get; set; }


        /// <summary>
        /// The JWE <c>"alg"</c> algorithm for encrypting request
        /// objects. This property corresponds to the
        /// <c>"request_object_encryption_alg"</c> metadata defined
        /// in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("requestEncryptionAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEAlg RequestEncryptionAlg { get; set; }


        /// <summary>
        /// The JWE <c>"enc"</c> algorithm for encrypting request
        /// objects. This property corresponds to the
        /// <c>"request_object_encryption_enc"</c> metadata defined
        /// in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("requestEncryptionEnc")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEEnc RequestEncryptionEnc { get; set; }


        /// <summary>
        /// The client authentication method for the token endpoint.
        /// This property corresponds to the
        /// <c>"token_endpoint_auth_method"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("tokenAuthMethod")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientAuthMethod TokenAuthMethod { get; set; }


        /// <summary>
        /// The JWS <c>"alg"</c> algorithm for signing the JWT used
        /// to authenticate the client at the token endpoint. This
        /// property corresponds to the
        /// <c>"token_endpoint_auth_signing_alg"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("tokenAuthSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg TokenAuthSignAlg { get; set; }


        /// <summary>
        /// The default value of the maximum authentication age in
        /// seconds. This property corresponds to the
        /// <c>"default_max_age"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("defaultMaxAge")]
        public int DefaultMaxAge { get; set; }


        /// <summary>
        /// The flag which indicates whether this client requires
        /// <c>"auth_time"</c> claim to be embedded in ID tokens.
        /// This property corresponds to the
        /// <c>"require_auth_time"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("authTimeRequired")]
        public bool IsAuthTimeRequired { get; set; }


        /// <summary>
        /// The default list of Authentication Context Class
        /// References. This property corresponds to the
        /// <c>"default_acr_values"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("defaultAcrs")]
        public string[] DefaultAcrs { get; set; }


        /// <summary>
        /// The URL that can initiate a login for this client
        /// application. This property corresponds to the
        /// <c>"initiate_login_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("loginUri")]
        public Uri LoginUri { get; set; }


        /// <summary>
        /// The request URIs that this client declares it may use.
        /// This property corresponds to the
        /// <c>"request_uris"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>.
        /// </summary>
        [JsonProperty("requestUris")]
        public string[] RequestUris { get; set; }


        /// <summary>
        /// The description about this client application.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// Localized descriptions of this client application.
        /// </summary>
        [JsonProperty("descriptions")]
        public TaggedValue[] Descriptions { get; set; }


        /// <summary>
        /// The time at which this client was created. The value is
        /// represented as milliseconds since the Unix epoch
        /// (1970-Jan-1).
        /// </summary>
        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }


        /// <summary>
        /// The time at which this client was last modified. The
        /// value is represented as milliseconds since the Unix
        /// epoch (1970-Jan-1).
        /// </summary>
        [JsonProperty("modifiedAt")]
        public long ModifiedAt { get; set; }


        /// <summary>
        /// The extended information about this client application.
        /// </summary>
        [JsonProperty("extension")]
        public ClientExtension Extension { get; set; }


        /// <summary>
        /// The string representation of the expected subject
        /// distinguished name of the certificate this client will
        /// use in mutual TLS authentication. See
        /// <c>"tls_client_auth_subject_dn"</c> in
        /// 2.3. Dynamic Client Registration in Mutual TLS Profile
        /// for OAuth Clients for details.
        /// </summary>
        [JsonProperty("tlsClientAuthSubjectDn")]
        public string TlsClientAuthSubjectDn { get; set; }


        /// <summary>
        /// The string representation of the expected DNS subject
        /// alternative name of the certificate this client will
        /// use in mutual TLS authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <c>tls_client_auth_san_dns</c> in "2.3. Dynamic
        /// Client Registration" in "Mutual TLS Profiles for OAuth
        /// Clients" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientAuthSanDns")]
        public string TlsClientAuthSanDns { get; set; }


        /// <summary>
        /// The string representation of the expected URI subject
        /// alternative name of the certificate this client will
        /// use in mutual TLS authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <c>tls_client_auth_san_uri</c> in "2.3. Dynamic
        /// Client Registration" in "Mutual TLS Profiles for OAuth
        /// Clients" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientAuthSanUri")]
        public Uri TlsClientAuthSanUri { get; set; }


        /// <summary>
        /// The string representation of the expected IP address
        /// subject alternative name of the certificate this client
        /// will use in mutual TLS authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <c>tls_client_auth_san_ip</c> in "2.3. Dynamic
        /// Client Registration" in "Mutual TLS Profiles for OAuth
        /// Clients" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientAuthSanIp")]
        public string TlsClientAuthSanIp { get; set; }


        /// <summary>
        /// The string representation of the expected email address
        /// subject alternative name of the certificate this client
        /// will use in mutual TLS authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See <c>tls_client_auth_san_email</c> in "2.3. Dynamic
        /// Client Registration" in "Mutual TLS Profiles for OAuth
        /// Clients" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientAuthSanEmail")]
        public string TlsClientAuthSanEmail { get; set; }


        /// <summary>
        /// The flag which indicates whether this client uses
        /// "client certificate bound access tokens".
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this property is <c>true</c> (and if the service
        /// supports "client certificate bound access tokens"),
        /// this client must present its client certificate (1)
        /// when it makes token requests to the authorization server
        /// and (2) when it makes API calls to the resource server.
        /// </para>
        ///
        /// <para>
        /// Since version 1.1.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientCertificateBoundAccessTokens")]
        public bool IsTlsClientCertificateBoundAccessTokens { get; set; }


        /// <summary>
        /// The key ID of a JWK containing a self-signed certificate
        /// of this client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See "2.2. Self-Signed Certificate Mutual TLS OAuth Client
        /// Authentication Method" in "OAuth 2.0 Mutual TLS Client
        /// Authentication and Certificate Bound Access Tokens" for
        /// details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.1.0.
        /// </para>
        /// </remarks>
        [JsonProperty("selfSignedCertificateKeyId")]
        public string SelfSignedCertificateKeyId { get; set; }


        /// <summary>
        /// The unique identifier string assigned by the client
        /// developer or software publisher used by registration
        /// endpoints to identify the client software to be
        /// dynamically registered.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the <c>software_id</c>
        /// metadata defined in
        /// <a href="https://tools.ietf.org/html/rfc7591#section-2">2.
        /// Client Metadata</a> of
        /// <a href="https://tools.ietf.org/html/rfc7591">RFC 7591</a>
        /// (OAuth 2.0 Dynamic Client Registration Protocol).
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("softwareId")]
        public string SoftwareId { get; set; }


        /// <summary>
        /// The version identifier string for the client software
        /// identified by the software ID.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>software_version</c> metadata defined in
        /// <a href="https://tools.ietf.org/html/rfc7591#section-2">2.
        /// Client Metadata</a> of
        /// <a href="https://tools.ietf.org/html/rfc7591">RFC 7591</a>
        /// (OAuth 2.0 Dynamic Client Registration Protocol).
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("softwareVersion")]
        public string SoftwareVersion { get; set; }


        /// <summary>
        /// The JWS <c>"alg"</c> algorithm for signing authorization
        /// responses. This property corresponds to the
        /// <c>"authorization_signed_response_alg"</c> in
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">5.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">Financial-grade
        /// API: JWT Secured Authorization Response Mode for OAuth
        /// 2.0 (JARM)</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg AuthorizationSignAlg { get; set; }


        /// <summary>
        /// The JWE <c>"alg"</c> algorithm for encrypting
        /// authorization responses. This property corresponds to
        /// the <c>"authorization_encrypted_response_alg"</c> in
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">5.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">Financial-grade
        /// API: JWT Secured Authorization Response Mode for OAuth
        /// 2.0 (JARM)</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationEncryptionAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEAlg AuthorizationEncryptionAlg { get; set; }


        /// <summary>
        /// The JWE <c>"enc"</c> algorithm for encrypting
        /// authorization responses. This property corresponds to
        /// the <c>"authorization_encrypted_response_enc"</c> in
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">5.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html#client-metadata">Financial-grade
        /// API: JWT Secured Authorization Response Mode for OAuth
        /// 2.0 (JARM)</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationEncryptionEnc")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWEEnc AuthorizationEncryptionEnc { get; set; }


        /// <summary>
        /// The backchannel token delivery mode. This property
        /// corresponds to the <c>backchannel_token_delivery_mode</c>
        /// metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The backchannel token delivery mode is defined in the
        /// specification of CIBA (Client Initiated Backchannel
        /// Authentication).
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("bcDeliveryMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryMode BcDeliveryMode { get; set; }


        /// <summary>
        /// The backchannel client notification endpoint. This
        /// property corresponds to the
        /// <c>backchannel_client_notification_endpoint</c>
        /// metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The backchannel client notification endpoint is defined
        /// in the specification of CIBA (Client Initiated
        /// Backchannel Authentication).
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("bcNotificationEndpoint")]
        public Uri BcNotificationEndpoint { get; set; }


        /// <summary>
        /// The signature algorithm of the request to the
        /// backchannel authentication endpoint. This property
        /// corresponds to the
        /// <c>backchannel_authentication_request_signing_alg</c>
        /// metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The specification of CIBA (Client Initiated Backchannel
        /// Authentication) allows asymmetric algorithms only.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("bcRequestSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg BcRequestSignAlg { get; set; }


        /// <summary>
        /// The boolean flag which indicates whether a user code is
        /// required when this client makes a backchannel
        /// authentication request. This property corresponds to
        /// the <c>backchannel_user_code_parameter</c> metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("bcUserCodeRequired")]
        public bool IsBcUserCodeRequired { get; set; }


        /// <summary>
        /// The boolean flag which indicates whether this client has been
        /// registered dynamically.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("dynamicallyRegistered")]
        public bool IsDynamicallyRegistered { get; set; }


        /// <summary>
        /// The hash of the registration access token for this client.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("registrationAccessTokenHash")]
        public string RegistrationAccessTokenHash { get; set; }


        /// <summary>
        /// The data types that this client may use as values of the <c>type</c>
        /// field in <c>authorization_details</c>. This property corresponds to
        /// the <c>authorization_data_types</c> client metadata defined in
        /// "OAuth 2.0 Rich Authorization Requests" (RAR).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationDataTypes")]
        public string[] AuthorizationDataTypes { get; set; }


        /// <summary>
        /// The boolean flag which indicates whether this client is required to
        /// use PAR (Pushed Authorization Request). This property corresponds to
        /// the <c>require_pushed_authorization_requests</c> client metadata
        /// defined in "OAuth 2.0 Pushed Authorization Requests" (PAR).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("parRequired")]
        public bool IsParRequired { get; set; }
    }
}
