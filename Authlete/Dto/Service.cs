﻿//
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
    /// Information about a service which represents an
    /// authorization server / OpenID provider.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Some properties correspond to the ones listed in
    /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
    /// OpenID Provider Metadata</a> of
    /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Connect Discovery 1.0</a>
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para><b>JWT-based access token</b></para>
    ///
    /// <para>
    /// When the <c>AccessTokenSignAlg</c> property holds a
    /// non-null value, access tokens issued by this service become
    /// JWTs. The value held by the property is used as the
    /// signature algorithm of the JWTs. When the property holds
    /// null, access tokens issued by this service are random
    /// strings as before.
    /// </para>
    ///
    /// <para>
    /// A JWT-based access token has the following claims.
    /// </para>
    ///
    /// <list type="bullet">
    /// <item>
    /// <term><c>scope</c></term>
    /// <description>
    /// (string) : Space-delimited scope names.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>client_id</c></term>
    /// <description>
    /// (string) : Client ID.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>exp</c></term>
    /// <description>
    /// (integer) : Time at which this access token will expire.
    /// Seconds since the Unix epoch.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>iat</c></term>
    /// <description>
    /// (integer) : Time at which this access token was issued.
    /// Seconds since the Unix epoch.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>sub</c></term>
    /// <description>
    /// (string) : The subject (unique identifier) of the resource
    /// owner who approved issue of this access token. This claim
    /// does not exist or its value is null if this access token
    /// was issued by resource owner password credentials flow.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>iss</c></term>
    /// <description>
    /// (string) : The issuer identifier of this service.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>jti</c></term>
    /// <description>
    /// (string) : The unique identifier of this JWT. The value of
    /// this claim itself is the random-string version of this
    /// access token.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>cnf</c></term>
    /// <description>
    /// (object) : If this access token is bound to a client
    /// certificate, this claim is included. The type of its value
    /// is object and the sub object contains a
    /// <c>x5t</c><c>#</c><c>S256</c> claim. The value of the
    /// <c>x5t</c><c>#</c><c>S256</c> claim is the X.509
    /// Certificate SHA-256 thumbprint of the client certificate.
    /// See <i>"3.1. X.509 Certificate Thumbprint Confirmation
    /// Method for JWT"</i> of
    /// <i><a href="https://datatracker.ietf.org/doc/draft-ietf-oauth-mtls/?include_text=1">OAuth
    /// 2.0 Mutual TLS Client Authentication and Certificate Bound
    /// Access Tokens</a></i> for details.
    /// </description>
    /// </item>
    /// </list>
    ///
    /// <para>
    /// Visible (= not-hidden) extra properties of the access token
    /// are embedded in the JWT as custom claims. Regarding extra
    /// properties, see the Authlete API document.
    /// </para>
    ///
    /// <para>
    /// This feature of JWT-based access token is available since
    /// Authlete 2.1. Access tokens issued by older Authlete
    /// versions are always random strings.
    /// </para>
    /// </remarks>
    public class Service
    {
        /// <summary>
        /// The service name.
        /// </summary>
        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }


        /// <summary>
        /// The API key of this service.
        /// </summary>
        [JsonProperty("apiKey")]
        public long ApiKey { get; set; }


        /// <summary>
        /// The API secret of this service.
        /// </summary>
        [JsonProperty("apiSecret")]
        public string ApiSecret { get; set; }


        /// <summary>
        /// The issuer identifier of this OpenID provider. This
        /// property corresponds to the <c>"issuer"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("issuer")]
        public Uri Issuer { get; set; }


        /// <summary>
        /// The URI of the authorization endpoint
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.1">3.1.
        /// Authorization Endpoint</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>).
        /// This property corresponds to the
        /// <c>"authorization_endpoint"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("authorizationEndpoint")]
        public Uri AuthorizationEndpoint { get; set; }


        /// <summary>
        /// The URI of the token endpoint
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.2">3.2.
        /// Token Endpoint</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>).
        /// This property corresponds to the <c>"token_endpoint"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("tokenEndpoint")]
        public Uri TokenEndpoint { get; set; }


        /// <summary>
        /// The URI of the revocation endpoint
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>). This property corresponds to the
        /// <c>"revocation_endpoint"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("revocationEndpoint")]
        public Uri RevocationEndpoint { get; set; }


        /// <summary>
        /// Client authentication methods at the revocation
        /// endpoint supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>"revocation_endpoint_auth_methods_supported"</c>
        /// metadata defined in "OAuth 2.0 Authorization Server
        /// Metadata".
        /// </para>
        ///
        /// <para>
        /// Since version 1.0.9.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedRevocationAuthMethods", ItemConverterType = typeof(StringEnumConverter))]
        public ClientAuthMethod[] SupportedRevocationAuthMethods { get; set; }


        /// <summary>
        /// The URI of the UserInfo endpoint
        /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">5.3.
        /// UserInfo Endpoint</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>). This property corresponds to the
        /// <c>"userinfo_endpoint"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("userInfoEndpoint")]
        public Uri UserInfoEndpoint { get; set; }


        /// <summary>
        /// The URI of the JWK Set of this service. This property
        /// corresponds to the <c>"jwks_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("jwksUri")]
        public Uri JwksUri { get; set; }


        /// <summary>
        /// The JWK Set of this service.
        /// </summary>
        [JsonProperty("jwks")]
        public string Jwks { get; set; }


        /// <summary>
        /// The URI of the registration endpoint
        /// (<a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientRegistration">3.
        /// Client Registration Endpoint</a>) of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a>). This
        /// property corresponds to the
        /// <c>"registration_endpoint"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("registrationEndpoint")]
        public Uri RegistrationEndpoint { get; set; }


        /// <summary>
        /// The URI of the registration management endpoint. If dynamic client
        /// registration is supported and this property is set, the URI will be
        /// used as the basis of the client's management endpoint by appending
        /// <c>/clientID/</c> to it as a path element. If this property is unset,
        /// the value of the <c>RegistrationEndpoint</c> property will be used
        /// as the URI base instead.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("registrationManagementEndpoint")]
        public Uri RegistrationManagementEndpoint { get; set; }


        /// <summary>
        /// Scopes supported by this service
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.3">3.3.
        /// Access Token Scope</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC
        /// 6749</a>). This property corresponds to the
        /// <c>"scopes_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedScopes")]
        public Scope[] SupportedScopes { get; set; }


        /// <summary>
        /// Response types supported by this service
        /// (<a href="https://openid.net/specs/oauth-v2-multiple-response-types-1_0.html">OAuth
        /// 2.0 Multiple Response Type Encoding Practices</a>).
        /// This property corresponds to the
        /// <c>"response_types_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedResponseTypes", ItemConverterType = typeof(StringEnumConverter))]
        public ResponseType[] SupportedResponseTypes { get; set; }


        /// <summary>
        /// Grant types supported by this service. This property
        /// corresponds to the <c>"grant_types_supported"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedGrantTypes", ItemConverterType = typeof(StringEnumConverter))]
        public GrantType[] SupportedGrantTypes { get; set; }


        /// <summary>
        /// ACR (Authentication Context Class Reference) values
        /// supported by this service. This property corresponds to
        /// the <c>"acr_values_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedAcrs")]
        public string[] SupportedAcrs { get; set; }


        /// <summary>
        /// Client authentication methods at the token endpoint
        /// supported by this service. This property corresponds to
        /// the <c>"token_endpoint_auth_methods_supported"</c>
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedTokenAuthMethods", ItemConverterType = typeof(StringEnumConverter))]
        public ClientAuthMethod[] SupportedTokenAuthMethods { get; set; }


        /// <summary>
        /// Values of the <c>"display"</c> request parameter
        /// supported by this service. This property corresponds to
        /// the <c>"display_values_supported"</c> metadata defined
        /// in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedDisplays", ItemConverterType = typeof(StringEnumConverter))]
        public Display[] SupportedDisplays { get; set; }


        /// <summary>
        /// Claim types supported by this service
        /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimTypes">5.6.
        /// Claim Types</a> in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>). This property corresponds to the
        /// <c>"claim_types_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedClaimTypes", ItemConverterType = typeof(StringEnumConverter))]
        public ClaimType[] SupportedClaimTypes { get; set; }


        /// <summary>
        /// Claims supported by this service. This property
        /// corresponds to the <c>"claims_supported"</c> metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedClaims")]
        public string[] SupportedClaims { get; set; }


        /// <summary>
        /// The URI of a page containing human-readable information
        /// that developers might want or need to know when using
        /// this OpenID Provider. This property corresponds to the
        /// <c>"service_documentation"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("serviceDocumentation")]
        public Uri ServiceDocumentation { get; set; }


        /// <summary>
        /// Language and scripts for claim values supported by this
        /// service. This property corresponds to the
        /// <c>"claims_locales_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedClaimLocales")]
        public string[] SupportedClaimLocales { get; set; }


        /// <summary>
        /// Languages and scripts for the user interface supported
        /// by this service. This property corresponds to the
        /// <c>"ui_locales_supported"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("supportedUiLocales")]
        public string[] SupportedUiLocales { get; set; }


        /// <summary>
        /// The URI that this OpenID Provider provides to the
        /// person registering the client to read about the OP's
        /// requirements on how the Relying Party can use the data
        /// provided by the OP. This property corresponds to the
        /// <c>"op_policy_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("policyUri")]
        public Uri PolicyUri { get; set; }


        /// <summary>
        /// The URI that this OpenID Provider provides to the person
        /// registering the client to read about the OP's terms of
        /// service. This property corresponds to the
        /// <c>"op_tos_uri"</c> metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
        /// OpenID Provider Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        [JsonProperty("tosUri")]
        public Uri TosUri { get; set; }


        /// <summary>
        /// The URI of the authentication callback endpoint.
        /// </summary>
        [JsonProperty("authenticationCallbackEndpoint")]
        public Uri AuthenticationCallbackEndpoint { get; set; }


        /// <summary>
        /// The API key to access the authentication callback
        /// endpoint.
        /// </summary>
        [JsonProperty("authenticationCallbackApiKey")]
        public string AuthenticationCallbackApiKey { get; set; }


        /// <summary>
        /// The API secret to access the authentication callback
        /// endpoint.
        /// </summary>
        [JsonProperty("authenticationCallbackApiSecret")]
        public string AuthenticationCallbackApiSecret { get; set; }


        /// <summary>
        /// The list of supported SNSes for social login at the
        /// direct authorization endpoint.
        /// </summary>
        [JsonProperty("supportedSnses", ItemConverterType = typeof(StringEnumConverter))]
        public Sns[] SupportedSnses { get; set; }


        /// <summary>
        /// The list of SNS credentials that Authlete uses to
        /// support social login.
        /// </summary>
        [JsonProperty("snsCredentials")]
        public SnsCredentials[] SnsCredentials { get; set; }


        /// <summary>
        /// The time at which this service was created. The value
        /// is milliseconds since the Unix epoch (1970-Jan-1).
        /// </summary>
        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }


        /// <summary>
        /// The time at which this service was last modified. The
        /// value is milliseconds since the Unix epoch (1970-Jan-1).
        /// </summary>
        [JsonProperty("modifiedAt")]
        public long ModifiedAt { get; set; }


        /// <summary>
        /// The URI of the developer authentication callback
        /// endpoint.
        /// </summary>
        [JsonProperty("developerAuthenticationCallbackEndpoint")]
        public Uri DeveloperAuthenticationCallbackEndpoint { get; set; }


        /// <summary>
        /// The API key to access the developer authentication
        /// callback endpoint.
        /// </summary>
        [JsonProperty("developerAuthenticationCallbackApiKey")]
        public string DeveloperAuthenticationCallbackApiKey { get; set; }


        /// <summary>
        /// The API secret to access the developer authentication
        /// callback endpoint.
        /// </summary>
        [JsonProperty("developerAuthenticationCallbackApiSecret")]
        public string DeveloperAuthenticationCallbackApiSecret { get; set; }


        /// <summary>
        /// The list of supported SNSes for social login at the
        /// developer console. However, this feature is not
        /// implemented yet.
        /// </summary>
        [JsonProperty("supportedDeveloperSnses", ItemConverterType = typeof(StringEnumConverter))]
        public Sns[] SupportedDeveloperSnses { get; set; }


        /// <summary>
        /// The list of SNS credentials that Authlete uses to
        /// support social login at the developer console.
        /// </summary>
        [JsonProperty("developerSnsCredentials")]
        public SnsCredentials[] DeveloperSnsCredentials { get; set; }


        /// <summary>
        /// The number of client applications that one developer
        /// can have. <c>0</c> means that developers can have as many
        /// client applications as they want.
        /// </summary>
        [JsonProperty("clientsPerDeveloper")]
        public int ClientsPerDeveloper { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct authorization
        /// endpoint is enabled or not. The path of the endpoint is
        /// <c>/api/auth/authorization/direct/{serviceApiKey}</c>.
        /// The default value is <c>true</c>, but it is recommended
        /// to disable the endpoint for production use.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides APIs for developers to implement an
        /// authorization endpoint
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.1">3.1.
        /// Authorization Endpoint</a>) such as
        /// <c>/api/auth/authorization</c>,
        /// <c>/api/auth/authorization/issue</c> and
        /// <c>/api/auth/authorization/fail</c>. On the other hand,
        /// the direct authorization endpoint is an implementation
        /// that directly works as an authorization endpoint.
        /// However, the endpoint exists mainly for development /
        /// experiment purposes, so it is recommended to disable it
        /// in a production environment.
        /// </para>
        /// </remarks>
        [JsonProperty("directAuthorizationEndpointEnabled")]
        public bool IsDirectAuthorizationEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct token
        /// endpoint is enabled or not. The path of the endpoint is
        /// <c>/api/auth/token/direct/{serviceApiKey}</c>. The
        /// default value is <c>true</c>, but it is recommended to
        /// disable the endpoint for production use.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides APIs for developers to implement a
        /// token endpoint
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.2">3.2.
        /// Token Endpoint</a>) such as <c>/api/auth/token</c>,
        /// <c>/api/auth/token/issue</c> and
        /// <c>/api/auth/token/fail</c>. On the other hand, the
        /// direct token endpoint is an implementation that
        /// directly works as a token endpoint. However, the
        /// endpoint exists mainly for development / experiment
        /// purposes, so it is recommended to disable it in a
        /// production environment.
        /// </para>
        /// </remarks>
        [JsonProperty("directTokenEndpointEnabled")]
        public bool IsDirectTokenEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct revocation
        /// endpoint is enabled or not. The path of the endpoint is
        /// <c>/api/auth/revocation/direct/{serviceApiKey}</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides an API (<c>/api/auth/revocation</c>)
        /// for developers to implement a revocation endpoint
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>). On the other hand, the direct revocation
        /// endpoint is an implementation that directly works as a
        /// revocation endpoint.
        /// </para>
        /// </remarks>
        [JsonProperty("directRevocationEndpointEnabled")]
        public bool IsDirectRevocationEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct userinfo
        /// endpoint is enabled or not. However, this feature has
        /// not been implemented yet.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides APIs for developers to implement a
        /// userinfo endpoint
        /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">5.3.
        /// UserInfo Endpoint</a>) such as <c>/api/auth/userinfo</c>
        /// and <c>/api/auth/userinfo/issue</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("directUserInfoEndpointEnabled")]
        public bool IsDirectUserInfoEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct JWK Set
        /// endpoint is enabled or not. The path of the endpoint is
        /// <c>/api/service/jwks/get/direct/{serviceApiKey}</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides an API (<c>/api/service/jwks/get</c>)
        /// for developers to implement a JWK Set endpoint which
        /// exposes the JWK Set
        /// (<a href="https://tools.ietf.org/html/rfc7517">RFC
        /// 7517</a>) of the service. On the other hand, the direct
        /// JWK Set endpoint is an implementation that directly
        /// works as a JWK Set endpoint.
        /// </para>
        /// </remarks>
        [JsonProperty("directJwksEndpointEnabled")]
        public bool IsDirectJwksEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the direct introspection
        /// endpoint is enabled or not. The path of the endpoint is
        /// <c>/api/auth/introspection/standard/direct</c>. The API
        /// is protected by pairs of API key and API secret of
        /// services.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Authlete provides an API
        /// (<c>/api/auth/introspection/standard</c>) for
        /// developers to implement an introspection endpoint
        /// (<a href="https://tools.ietf.org/html/rfc7662">RFC
        /// 7662</a>). On the other hand, the direct introspection
        /// endpoint is an implementation that directly works as an
        /// introspection endpoint.
        /// </para>
        ///
        /// <para>
        /// Note that Authlete provides another different
        /// introspection API (<c>/api/auth/introspection</c>).
        /// It does not comply with RFC 7662 but is much more
        /// useful for developers who implement protected resource
        /// endpoints.
        /// </para>
        /// </remarks>
        [JsonProperty("directIntrospectionEndpointEnabled")]
        public bool IsDirectIntrospectionEndpointEnabled { get; set; }


        /// <summary>
        /// The flag which indicates whether the number of access
        /// tokens per subject (and per client) is at most one or
        /// can be more. If this flag is <c>true</c>, an attempt to
        /// issue a new access token invalidates existing access
        /// tokens which are associated with the same subject and
        /// the same client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that, however, attempts by Client Credentials Flow
        /// do not invalidate existing access tokens because access
        /// tokens issued by Client Credentials Flow are not
        /// associated with any end-user's subject. Also note that
        /// an attempt by Refresh Token Flow invalidates the
        /// coupled access token only and this invalidation is
        /// always performed regardless of whether this flag is
        /// <c>true</c> or <c>false</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("singleAccessTokenPerSubject")]
        public bool IsSingleAccessTokenPerSubject { get; set; }


        /// <summary>
        /// The flag which indicates whether the use of Proof Key
        /// for Code Exchange (PKCE) is always required for
        /// authorization requests using
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.1">Authorization
        /// Code Flow</a>. See
        /// <a href="https://tools.ietf.org/html/rfc7636">RFC
        /// 7636</a> (Proof Key for Code Exchange by OAuth Public
        /// Clients) for details.
        /// </summary>
        [JsonProperty("pkceRequired")]
        public bool IsPkceRequired { get; set; }


        /// <summary>
        /// The flag which indicates whether a refresh token remains
        /// valid or gets renewed after its use.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("refreshTokenKept")]
        public bool IsRefreshTokenKept { get; set; }


        /// <summary>
        /// The flag which indicates whether the remaining duration of the used
        /// refresh token is taken over to the newly issued one.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("refreshTokenDurationKept")]
        public bool IsRefreshTokenDurationKept { get; set; }


        /// <summary>
        /// The flag which indicates whether the
        /// <c>error_description</c> response parameter is omitted.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// According to RFC 6749, authorization servers may
        /// include the <c>error_description</c> response parameter
        /// in error responses. When this property is <c>True</c>,
        /// Authlete does not embed the <c>error_description</c>
        /// response parameter in error responses.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("errorDescriptionOmitted")]
        public bool IsErrorDescriptionOmitted { get; set; }


        /// <summary>
        /// The flag which indicates whether the <c>error_uri</c>
        /// response parameter is omitted.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// According to RFC 6749, authorization servers may
        /// include the <c>error_uri</c> response parameter in
        /// error responses. When this property is <c>True</c>,
        /// Authlete does not embed the <c>error_uri</c> response
        /// parameter in error responses.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("errorUriOmitted")]
        public bool IsErrorUriOmitted { get; set; }


        /// <summary>
        /// Get the flag which indicates whether the "Client ID
        /// Alias" feature is enabled or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When a new client is created, Authlete generates a
        /// numeric value and assigns it as a client ID to the
        /// newly created client. In addition to the client ID,
        /// each client can have a client ID alias. The client ID
        /// alias is, however, recognized only when this property
        /// is <c>True</c>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("clientIdAliasEnabled")]
        public bool IsClientIdAliasEnabled { get; set; }


        /// <summary>
        /// Service profiles supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.8.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedServiceProfiles", ItemConverterType = typeof(StringEnumConverter))]
        public ServiceProfile[] SupportedServiceProfiles { get; set; }


        /// <summary>
        /// The flag which indicates whether this service supports
        /// "client certificate bound access tokens".
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this property is <c>true</c>, client applications
        /// whose <c>IsClientCertificateBoundAccessTokens</c>
        /// property is <c>true</c> are required to present a
        /// client certificate on token requests to the
        /// authorization server and on API calls to the resource
        /// server.
        /// </para>
        ///
        /// <para>
        /// Since version 1.1.0.
        /// </para>
        /// </remarks>
        [JsonProperty("tlsClientCertificateBoundAccessTokens")]
        public bool IsTlsClientCertificateBoundAccessTokens { get; set; }


        /// <summary>
        /// The URI of the introspection endpoint
        /// (<a href="https://tools.ietf.org/html/rfc7662">RFC 7662:
        /// OAuth 2.0 Token Introspection</a>).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.0.9.
        /// </para>
        /// </remarks>
        [JsonProperty("introspectionEndpoint")]
        public Uri IntrospectionEndpoint { get; set; }


        /// <summary>
        /// Client authentication methods at the introspection
        /// endpoint supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>"introspection_endpoint_auth_methods_supported"</c>
        /// metadata defined in "OAuth 2.0 Authorization Server
        /// Metadata".
        /// </para>
        ///
        /// <para>
        /// Since version 1.0.9.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedIntrospectionAuthMethods", ItemConverterType = typeof(StringEnumConverter))]
        public ClientAuthMethod[] SupportedIntrospectionAuthMethods { get; set; }


        /// <summary>
        /// The flag which indicates whether this service validates
        /// certificate chains during PKI-based client mutual TLS
        /// authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.1.0.
        /// </para>
        /// </remarks>
        [JsonProperty("mutualTlsValidatePkiCertChain")]
        public bool IsMutualTlsValidatePkiCertChain { get; set; }


        /// <summary>
        /// The list of root certificates trusted by this service
        /// for PKI-based client mutual TLS authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.1.0.
        /// </para>
        /// </remarks>
        [JsonProperty("trustedRootCertificates")]
        public string[] TrustedRootCertificates { get; set; }


        /// <summary>
        /// The flag which indicates whether dynamic client registration is
        /// supported.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("dynamicRegistratinoSupported")]
        public bool IsDynamicRegistrationSupported { get; set; }


        /// <summary>
        /// The end session endpoint for the service. This endpoint is used by
        /// clients to signal to the IdP that the user's session should be
        /// terminated. See
        /// <a href="https://openid.net/specs/openid-connect-session-1_0.html">OpenID
        /// Connect Session Management 1.0</a> for details.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("endSessionEndpoint")]
        public Uri EndSessionEndpoint { get; set; }


        /// <summary>
        /// The description about this service.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// The token type of access tokens issued by this
        /// authorization server. It is the value of the
        /// <c>"token_type"</c> parameter in access token responses
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>).
        /// <c>"Bearer"</c> is recommended
        /// (<a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>).
        /// </summary>
        [JsonProperty("accessTokenType")]
        public string AccessTokenType { get; set; }


        /// <summary>
        /// The signature algorithm of access tokens.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the value of this property is null, access tokens
        /// issued by this service are just random strings. On the
        /// other hand, when this property holds a non-null value,
        /// access tokens issued by this service are JWTs and the
        /// value of this property represents the signature
        /// algorithm of the JWTs. Regarding the format, see the
        /// description of this <c>Service</c> class.
        /// </para>
        ///
        /// <para>
        /// This feature is available since Authlete 2.1. Access
        /// tokens generated by older Authlete versions are always
        /// random strings.
        /// </para>
        ///
        /// <para>
        /// Note that symmetric algorithms (<c>HS256</c>, <c>HS384</c>
        /// and <c>HS512</c>) are not supported.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenSignAlg")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JWSAlg AccessTokenSignAlg { get; set; }


        /// <summary>
        /// The duration of access tokens in seconds. It is the
        /// value of the <c>"expires_in"</c> parameter in access
        /// token responses
        /// (<a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>).
        /// </summary>
        [JsonProperty("accessTokenDuration")]
        public long AccessTokenDuration { get; set; }


        /// <summary>
        /// The duration of refresh tokens in seconds.
        /// </summary>
        [JsonProperty("refreshTokenDuration")]
        public long RefreshTokenDuration { get; set; }


        /// <summary>
        /// The duration of ID tokens in seconds.
        /// </summary>
        [JsonProperty("idTokenDuration")]
        public long IdTokenDuration { get; set; }


        /// <summary>
        /// The duration of authorization response JWTs in seconds.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html">Financial-grade
        /// API: JWT Secured Authorization Response Mode for OAuth
        /// 2.0 (JARM)</a> defines new values for the
        /// <c>response_mode</c> request parameter. They are
        /// <c>query.jwt</c>, <c>fragment.jwt</c>,
        /// <c>form_post.jwt</c> and <c>jwt</c>. If one of them is
        /// specified as the response mode, response parameters
        /// from the authorization endpoint will be packed into a
        /// JWT. This property is used to compute the value of the
        /// <c>exp</c> claim of the JWT.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationResponseDuration")]
        public long AuthorizationResponseDuration { get; set; }


        /// <summary>
        /// The duration of pushed authorization requests.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// "OAuth 2.0 Pushed Authorization Requests" (PAR) defines an endpoint
        /// (called "pushed authorization request endpoint") which client
        /// applications can register authorization requests into and get
        /// corresponding URIs (called "request URI") from. The issued request
        /// URIs represent the registered authorization requests. The client
        /// applications can use the URIs as the value of the <c>request_uri</c>
        /// request parameter in an authorization request.
        /// </para>
        ///
        /// <para>
        /// The value held by this property represents the duration in seconds
        /// of registered authorization requests and is used as the value of the
        /// <c>expires_in</c> parameter in responses from the pushed
        /// authorization request endpoint.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("pushedAuthReqDuration")]
        public long PushedAuthReqDuration { get; set; }


        /// <summary>
        /// The key ID to identify a JWK used for signing access
        /// tokens.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A JWK Set can be registered as a property of a Service.
        /// A JWK Set can contain 0 or more JWKs (see
        /// <a href="https://tools.ietf.org/html/rfc7517">RFC 7517</a>
        /// for details about JWK). Authlete Server has to pick up
        /// one JWK for signing from the JWK Set when it generates
        /// a JWT-based access token (see the description of the
        /// <c>AccessTokenSignAlg</c> for details about JWT-based
        /// access token). Authlete Server searches the registered
        /// JWK Set for a JWK which satisfies conditions for access
        /// token signature. If the number of JWK candidates which
        /// satisfy the conditions is 1, there is no problem. On
        /// the other hand, if there exist multiple candidates, a
        /// <a href="https://tools.ietf.org/html/rfc7517#section-4.5">Key
        /// ID</a> is needed to be specified so that Authlete
        /// Server can pick up one JWK from among the JWK
        /// candidates.
        /// </para>
        ///
        /// <para>
        /// This property exists for the purpose described above.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenSignatureKeyId")]
        public string AccessTokenSignatureKeyId { get; set; }


        /// <summary>
        /// The key ID to identify a JWK used for signing
        /// authorization responses using an asymmetric key.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <a href="https://openid.net/specs/openid-financial-api-jarm.html">Financial-grade
        /// API: JWT Secured Authorization Response Mode for OAuth
        /// 2.0 (JARM)</a> has added new values for the
        /// <c>response_mode</c> request parameter. They are
        /// <c>query.jwt</c>, <c>fragment.jwt</c>,
        /// <c>form_post.jwt</c> and <c>jwt</c>. If one of them is
        /// used, response parameters returned from the
        /// authorization endpoint will be packed into a JWT. The
        /// JWT is always signed. For the signature of the JWT,
        /// Authlete Server has to pick up one JWK from the
        /// service's JWK Set.
        /// </para>
        ///
        /// <para>
        /// Authlete Server searches the JWK Set for a JWK which
        /// satisfies conditions for authorization response
        /// signature. If the number of JWK candidates which
        /// satisfy the conditions is 1, there is no problem. On
        /// the other hand, if there exist multiple candidates, a
        /// <a href="https://tools.ietf.org/html/rfc7517#section-4.5">Key
        /// ID</a> is needed to be specified so that Authlete
        /// Server can pick up one JWK from among the JWK
        /// candidates. This property exists to specify the key ID.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("authorizationSignatureKeyId")]
        public string AuthorizationSignatureKeyId { get; set; }


        /// <summary>
        /// The key ID to identify a JWK used for ID token
        /// signature using an asymmetric key.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A JWK Set can be registered as a property of a Service.
        /// A JWK Set can contain 0 or more JWKs (see
        /// <a href="https://tools.ietf.org/html/rfc7517">RFC 7517</a>
        /// for details about JWK). Authlete Server has to pick up
        /// one JWK for signature from the JWK Set when it
        /// generates an ID token and signature using an asymmetric
        /// key. Authlete Server searches the registered JWK Set
        /// for a JWK which satisfies conditions for ID token
        /// signature. If the number of JWK candidates which
        /// satisfy the conditions is 1, there is no problem. On
        /// the other hand, if there exist multiple candidates, a
        /// <a href="https://tools.ietf.org/html/rfc7517#section-4.5">Key
        /// ID</a> is needed to be specified so that Authlete
        /// Server can pick up one JWK from among the JWK
        /// candidates.
        /// </para>
        ///
        /// <para>
        /// This property exists for the purpose described above.
        /// For key rotation (OpenID Connect Core 1.0,
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#RotateSigKeys">10.1.1.
        /// Rotation of Asymmetric Signing Keys</a>), this
        /// mechanism is needed.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("idTokenSignatureKeyId")]
        public string IdTokenSignatureKeyId { get; set; }


        /// <summary>
        /// The key ID to identify a JWK used for user info
        /// signature using an asymmetric key.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A JWK Set can be registered as a property of a Service.
        /// A JWK Set can contain 0 or more JWKs (see
        /// <a href="https://tools.ietf.org/html/rfc7517">RFC 7517</a>
        /// for details about JWK). Authlete Server has to pick up
        /// one JWK for signature from the JWK Set when it is
        /// required to sign user info (which is returned from
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">UserInfo
        /// Endpoint</a>) using an asymmetric key. Authlete Server
        /// searches the registered JWK Set for a JWK which
        /// satisfies conditions for user info signature. If the
        /// number of JWK candidates which satisfy the conditions
        /// is 1, there is no problem. On the other hand, if there
        /// exist multiple candidates, a
        /// <a href="https://tools.ietf.org/html/rfc7517#section-4.5">Key
        /// ID</a> is needed to be specified so that Authlete
        /// Server can pick up one JWK from among the JWK
        /// candidates.
        /// </para>
        ///
        /// <para>
        /// This property exists for the purpose described above.
        /// For key rotation (OpenID Connect Core 1.0,
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#RotateSigKeys">10.1.1.
        /// Rotation of Asymmetric Signing Keys</a>), this
        /// mechanism is needed.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("userInfoSignatureKeyId")]
        public string UserInfoSignatureKeyId { get; set; }


        /// <summary>
        /// The supported backchannel token delivery modes. This
        /// property corresponds to the
        /// <c>backchannel_token_delivery_modes_supported</c>
        /// metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Backchannel token delivery modes are defined in the
        /// specification of CIBA (Client Initiated Backchannel
        /// Authentication).
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedBackchannelTokenDeliveryModes", ItemConverterType = typeof(StringEnumConverter))]
        public DeliveryMode[] SupportedBackchannelTokenDeliveryModes { get; set; }


        /// <summary>
        /// The URI of the backchannel authentication endpoint.
        /// This property corresponds to the
        /// <c>backchannel_authentication_endpoint</c> metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Backchannel authentication endpoint is defined in the
        /// specification of CIBA (Client Initiated Backchannel
        /// Authentication).
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("backchannelAuthenticationEndpoint")]
        public Uri BackchannelAuthenticationEndpoint { get; set; }


        /// <summary>
        /// The boolean flag which indicates whether the
        /// <c>user_code</c> request parameter is supported at the
        /// backchannel authentication endpoint. This property
        /// corresponds to the
        /// <c>backchannel_user_code_parameter_supported</c>
        /// metadata.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("backchannelUserCodeParameterSupported")]
        public bool IsBackchannelUserCodeParameterSupported { get; set; }


        /// <summary>
        /// The duration of backchannel authentication request IDs
        /// issued from the backchannel authentication endpoint in
        /// seconds. This is used as the value of the
        /// <c>expires_in</c> property in responses from the
        /// backchannel authentication endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("backchannelAuthReqIdDuration")]
        public int BackchannelAuthReqIdDuration { get; set; }


        /// <summary>
        /// The minimum interval between polling requests to the
        /// token endpoint from client applications in seconds.
        /// This is used as the value of the <c>interval</c>
        /// property in responses from the backchannel
        /// authentication endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("backchannelPollingInterval")]
        public int BackchannelPollingInterval { get; set; }


        /// <summary>
        /// The boolean flag which indicates whether the <c>binding_message</c>
        /// request parameter is always required whenever a backchannel
        /// authentication request is judged as a request for Financial-grade
        /// API.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("backchannelBindingMessageRequiredInFapi")]
        public bool IsBackchannelBindingMessageRequiredInFapi { get; set; }


        /// <summary>
        /// The allowable clock skew between the server and clients
        /// in seconds. Must be in between 0 and 65,535.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The clock skew is taken into consideration when
        /// time-related claims in a JWT (e.g. <c>exp</c>,
        /// <c>iat</c>, <c>nbf</c>) are verified.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("allowableClockSkew")]
        public int AllowableClockSkew { get; set; }


        /// <summary>
        /// The URI of the device authorization endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the <c>device_authorization_endpoint</c>
        /// server metadata defined in
        /// <a href="https://tools.ietf.org/html/rfc8628">RFC 8628</a> (OAuth
        /// 2.0 Device Authorization Grant).
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("deviceAuthorizationEndpoint")]
        public Uri DeviceAuthorizationEndpoint { get; set; }


        /// <summary>
        /// The verification URI for Device Flow
        /// (<a href="https://tools.ietf.org/html/rfc8628">RFC 8628</a>). This
        /// URI is used as the value of the <c>verification_uri</c> parameter in
        /// responses from the device authorization endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("deviceVerificationUri")]
        public Uri DeviceVerificationUri { get; set; }


        /// <summary>
        /// The verification URI for Device Flow
        /// (<a href="https://tools.ietf.org/html/rfc8628">RFC 8628</a>) with a
        /// placeholder for a user code. This URI is used to build the value of
        /// the <c>verification_uri_complete</c> parameter in responses from the
        /// device authorization endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected that the URI contains a fixed string <c>USER_CODE</c>
        /// somewhere as a placeholder for a user code. For example, like the
        /// following.
        /// </para>
        ///
        /// <code>
        /// https://example.com/device?user_code=USER_CODE
        /// </code>
        ///
        /// <para>
        /// The fixed string is replaced with an actual user code when Authlete
        /// builds a verification URI with a user code for the
        /// <c>verification_uri_complete</c> parameter.
        /// </para>
        ///
        /// <para>
        /// If this URI is not set, the <c>verification_uri_complete</c>
        /// parameter won't appear in device authorization responses.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("deviceVerificationUriComplete")]
        public Uri DeviceVerificationUriComplete { get; set; }


        /// <summary>
        /// The duration of device verification codes and end-user verification
        /// codes issued from the device authorization endpoint in seconds.
        /// This is used as the value of the <c>expires_in</c> property in
        /// responses from the device authorization endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("deviceFlowCodeDuration")]
        public int DeviceFlowCodeDuration { get; set; }


        /// <summary>
        /// The minimum interval between polling requests to the token endpoint
        /// from client applications in seconds in Device Flow
        /// (<a href="https://tools.ietf.org/html/rfc8628">RFC 8628</a>). This
        /// is used as the value of the <c>interval</c> property in responses
        /// from the device authorization endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value must be in between 0 and 65535.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("deviceFlowPollingInterval")]
        public int DeviceFlowPollingInterval { get; set; }


        /// <summary>
        /// The character set for end-user verification codes (<c>user_code</c>)
        /// for Device Flow (<a href="https://tools.ietf.org/html/rfc8628">RFC
        /// 8628</a>).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("userCodeCharset")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserCodeCharset UserCodeCharset { get; set; }


        /// <summary>
        /// The length of end-user verification codes (<c>user_code</c>) for
        /// Device Flow (<a href="https://tools.ietf.org/html/rfc8628">RFC
        /// 8628</a>).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value must not be negative and must not be greater than 255.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("userCodeLength")]
        public int UserCodeLength { get; set; }


        /// <summary>
        /// The URI of the pushed authorization request endpoint.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>pushed_authorization_request_endpoint</c> server metadata defined
        /// in "OAuth 2.0 Pushed Authorization Requests" (PAR).
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("pushedAuthReqEndpoint")]
        public Uri PushedAuthReqEndpoint { get; set; }


        /// <summary>
        /// The MTLS endpoint aliases.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the <c>mtls_endpoint_aliases</c> server
        /// metadata defined in
        /// <a href="https://www.rfc-editor.org/rfc/rfc8705.html">RFC 8705</a>
        /// (OAuth 2.0 Mutual-TLS Client Authentication and Certificate-Bound
        /// Access Tokens).
        /// </para>
        ///
        /// <para>
        /// The aliases will be embedded in the response from the discovery
        /// endpoint like the following.
        /// </para>
        ///
        /// <code>
        /// {
        ///     ......,
        ///     "mtls_endpoint_aliases": {
        ///         "token_endpoint":         "https://mtls.example.com/token",
        ///         "revocation_endpoint":    "https://mtls.example.com/revo",
        ///         "introspection_endpoint": "https://mtls.example.com/introspect"
        ///     }
        /// }
        /// </code>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("mtlsEndpointAliases")]
        public NamedUri[] MtlsEndpointAliases { get; set; }


        /// <summary>
        /// The supported data types that can be used as values of the <c>type</c>
        /// field in <c>authorization_details</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>authorization_data_types_supported</c> server metadata defined in
        /// "OAuth 2.0 Rich Authorization Requests" (RAR).
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedAuthorizationDataTypes")]
        public string[] SupportedAuthorizationDataTypes { get; set; }


        /// <summary>
        /// Trust frameworks supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the <c>trust_frameworks_supported</c> server
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedTrustFrameworks")]
        public string[] SupportedTrustFrameworks { get; set; }


        /// <summary>
        /// Evidence supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the <c>evidence_supported</c> server metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedEvidence")]
        public string[] SupportedEvidence { get; set; }


        /// <summary>
        /// Identity documents supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the <c>id_documents_supported</c> server
        /// metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedIdentityDocuments")]
        public string[] SupportedIdentityDocuments { get; set; }


        /// <summary>
        /// Verification methods supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the
        /// <c>id_documents_verification_methods_supported</c> server metadata
        /// defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedVerificationMethods")]
        public string[] SupportedVerificationMethods { get; set; }


        /// <summary>
        /// Verified claims supported by this service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the <c>claims_in_verified_claims_supported</c>
        /// server metadata defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("supportedVerifiedClaims")]
        public string[] SupportedVerifiedClaims { get; set; }


        /// <summary>
        /// The flag which indicates whether token requests from public clients
        /// without the <c>client_id</c> request parameter are allowed when the
        /// client can be guessed from <c>authorization_code</c> or
        /// <c>refresh_token</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property should not be set to true unless you have special
        /// reasons.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("missingClientIdAllowed")]
        public bool IsMissingClientIdAllowed { get; set; }


        /// <summary>
        /// The flag which indicates whether this service requires that clients
        /// use PAR (Pushed Authorization Request).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property corresponds to the
        /// <c>require_pushed_authorization_requests</c> server metadata defined
        /// in "OAuth 2.0 Pushed Authorization Requests".
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("parRequired")]
        public bool IsParRequired { get; set; }


        /// <summary>
        /// The flag which indicates whether this service requires that
        /// authorization requests always utilize a request object by using
        /// either <c>request</c> or <c>request_uri</c> request parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this flag is true and
        /// <c>IsTraditionalRequestObjectProcessingApplied</c> property is
        /// false, the value of <c>require_signed_request_object</c> server
        /// metadata of this service is reported as true in the discovery
        /// document. The metadata is defined in JAR (JWT Secured Authorization
        /// Request). That <c>require_signed_request_object</c> is true means
        /// that authorization requests which don't conform to the JAR
        /// specification are rejected.
        /// </para>
        ///
        /// <para>
        /// Since version 1.5.0.
        /// </para>
        /// </remarks>
        [JsonProperty("requestObjectRequired")]
        public bool IsRequestObjectRequired { get; set; }


        /// <summary>
        /// The flag which indicates whether a request object is processed based
        /// on rules defined in OpenID Connect Core 1.0 or JAR (JWT Secured
        /// Authorization Request).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Differences between rules in OpenID Connect Core 1.0 and ones in JAR
        /// are as follows.
        /// </para>
        ///
        /// <para>
        /// 1. JAR requires that a request object be always signed.
        /// </para>
        ///
        /// <para>
        /// 2. JAR does not allow request parameters outside a request object to
        /// be referred to.
        /// </para>
        ///
        /// <para>
        /// 3. OIDC Core 1.0 requires that <c>response_type</c> request
        /// parameter exist outside a request object even if the request object
        /// includes the request parameter.
        /// </para>
        ///
        /// <para>
        /// 4. OIDC Core 1.0 requires that <c>scope</c> request parameter exist
        /// outside a request object if the authorization request is an OIDC
        /// request even if the request object includes the request parameter.
        /// </para>
        ///
        /// <para>
        /// If this flag is false and <c>IsRequestObjectRequired</c> property is
        /// true, the value of <c>require_signed_request_object</c> server
        /// metadata of this service is reported as true in the discovery
        /// document. The metadata is defined in JAR (JWT Secured Authorization
        /// Request). That <c>require_signed_request_object</c> is true means
        /// that authorization requests which don't conform to the JAR
        /// specification are rejected.
        /// </para>
        ///
        /// <para>
        /// Since version 1.5.0.
        /// </para>
        /// </remarks>
        [JsonProperty("traditionalRequestObjectProcessingApplied")]
        public bool IsTraditionalRequestObjectProcessingApplied { get; set; }


        /// <summary>
        /// The flag which indicates whether claims specified by shortcut scopes
        /// (e.g. <c>profile</c>) are included in the issued ID token only when
        /// no access token is issued.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// To strictly conform to the description below excerpted from OpenID
        /// Connect Core 1.0 Section 5.4, this flag has to be true.
        /// </para>
        ///
        /// <para>
        /// "The Claims requested by the <c>profile</c>, <c>email</c>,
        /// <c>address</c>, and <c>phone</c> scope values are returned from the
        /// UserInfo Endpoint, as described in Section 5.3.2, when a
        /// <c>response_type</c> value is used that results in an Access Token
        /// being issued. However, when no Access Token is issued (which is the
        /// case for the <c>response_type</c> value <c>id_token</c>), the
        /// resulting Claims are returned in the ID Token."
        /// </para>
        ///
        /// <para>
        /// Since version 1.5.0.
        /// </para>
        /// </remarks>
        [JsonProperty("claimShortcutRestrictive")]
        public bool IsClaimShortcutRestrictive { get; set; }


        /// <summary>
        /// The flag which indicates whether requests that request no scope are
        /// rejected or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When a request has no explicit <c>scope</c> parameter and the
        /// service's pre-defined default scope set is empty, the authorization
        /// server regards the request requests no scope. When this flag is
        /// true, requests that request no scope are rejected.
        /// </para>
        ///
        /// <para>
        /// The requirement below excerpted from RFC 6749 Section 3.3 does not
        /// explicitly mention the case where the default scope set is empty.
        /// </para>
        ///
        /// <para>
        /// "If the client omits the <c>scope</c> parameter when requesting
        /// authorization, the authorization server MUST either process the
        /// request using a pre-defined default value or fail the request
        /// indicating an invalid scope."
        /// </para>
        ///
        /// <para>
        /// However, if you interpret the state "the default scope set exists
        /// but is empty" as "the default scope set does not exist" and want to
        /// strictly conform to the requirement above, this flag has to be true.
        /// </para>
        ///
        /// <para>
        /// Since version 1.5.0.
        /// </para>
        /// </remarks>
        [JsonProperty("scopeRequired")]
        public bool IsScopeRequired { get; set; }
    }
}
