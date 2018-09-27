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
        /// Get the key ID to identify a JWK used for signing
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
        /// Get the key ID to identify a JWK used for ID token
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
        /// Get the key ID to identify a JWK used for user info
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
    }
}
