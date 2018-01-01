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


namespace Authlete.Dto
{
    /// <summary>
    /// Authentication request from Authlete to a service
    /// implementation.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete provides an implementation of authorization
    /// endpoint at
    /// <c>/api/auth/authorization/direct/<i>{service-api-key}</i></c>.
    /// We call it <i>"direct authorization endpoint"</i>. The
    /// direct endpoint is provided for development purposes only
    /// and it is not suitable for production use. Basically,
    /// Authlete users should implement their own authorization
    /// endpoints using <c>/api/auth/authorization</c> API,
    /// <c>/api/auth/authorization/issue</c> API and
    /// <c>/api/auth/authorization/fail</c> API.
    /// </para>
    ///
    /// <para>
    /// If a client application accesses the direct authorization
    /// endpoint, the endpoint returns an authorization page
    /// (unless the endpoint is disabled by the configuration).
    /// After the end-user tries end-user authentication at the UI
    /// (by inputting his/her login ID and password to the input
    /// fields or by signing in an SNS such as Facebook), Authlete
    /// makes an <i>authentication request</i> to the authentication
    /// endpoint of your system. This class represents the format
    /// of the authentication request.
    /// </para>
    ///
    /// <para>
    /// When the end-user tried end-user authentication by
    /// inputting his/her credentials to the input fields of the
    /// form, the <c>"id"</c> and <c>"password"</c> parameters in
    /// an authentication request are the values that the end-user
    /// input.
    /// </para>
    ///
    /// <para>
    /// On the other hand, when the end-user tried end-user
    /// authentication by signing in an SNS such as Facebook, the
    /// <c>"id"</c> parameter represents the subject (= unique
    /// identifier) of the end-user in the SNS and the
    /// <c>"password"</c> parameter has no meaning. In this case,
    /// the <c>"sns"</c> and <c>"accessToken"</c> parameters are
    /// not <c>null</c>. The <c>"accessToken"</c> in an
    /// authentication request is the value of the access token
    /// issued by the SNS which an implementation of an
    /// authentication callback endpoint may use as necessary.
    /// </para>
    ///
    /// <para>
    /// Some notes specific to respective SNSes.
    /// </para>
    ///
    /// <list type="bullet">
    /// <item>
    /// <term>Facebook</term>
    /// <description>
    /// <para>
    /// The value of the <c>"id"</c> parameter is unique to each
    /// Facebook application and cannot be used across different
    /// applications. If you need the third party ID, make an API
    /// call to <c>/me</c> API with <c>fields=third_party_id</c>
    /// and <c>access_token=<i>{accessToken}</i></c>. See the API
    /// document of Facebook for details.
    /// </para>
    /// <para>
    /// The value of the <c>"rawTokenResponse"</c> parameter is in
    /// the form of <c>application/x-www-form-urlencoded</c> (not
    /// <c>application/json</c>). This is a violation against RFC
    /// 6749.
    /// </para>
    /// <para>
    /// The value of the <c>"refreshToken"</c> parameter is empty.
    /// </para>
    /// <para>
    /// The value of the <c>"expiresIn"</c> parameter is the value
    /// of <c>"expires"</c> in the response from the token endpoint
    /// of Facebook.
    /// </para>
    /// </description>
    /// </item>
    /// </list>
    ///
    /// <hr/>
    ///
    /// <para>
    /// Authlete provides an implementation of token endpoint at
    /// <c>/api/auth/token/direct/<i>{service-api-key}</i></c>.
    /// We call it <i>"direct token endpoint"</i>. The direct
    /// endpoint is provided for development purposes only and
    /// it is not suitable for production use. Basically, Authlete
    /// users should implement their own token endpoints using
    /// <c>/api/auth/token</c> API, <c>/api/auth/token/issue</c>
    /// API and <c>/api/auth/token/fail</c> API.
    /// </para>
    ///
    /// <para>
    /// If a client application accesses the direct token endpoint
    /// using
    /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
    /// Owner Password Credentials</a> flow, Authlete makes an
    /// authentication request to your system unless the direct
    /// endpoint is disabled by the configuration.
    /// </para>
    /// </remarks>
    public class AuthenticationCallbackRequest
    {
        /// <summary>
        /// The API key of the target service. This property is
        /// always set when Authlete makes an authentication
        /// request.
        /// </summary>
        [JsonProperty("serviceApiKey")]
        public long ServiceApiKey { get; set; }


        /// <summary>
        /// The ID of the client application that triggered this
        /// authentication request.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The ID of the end-user.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the value of the <c>Sns</c> property is
        /// <c>null</c>, this property holds (1) the value of the
        /// login ID that the end-user entered to the login ID
        /// field in the authorization page displayed at the direct
        /// authorization endpoint
        /// (<c>/api/auth/authorization/direct/<i>{service-api-key}</i></c>),
        /// or (2) the value of the <c>"username"</c> request
        /// parameter of a request to the direct token endpoint
        /// (<c>/api/auth/token/direct/<i>{service-api-key}</i></c>)
        /// in the case of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials</a> flow.
        /// </para>
        ///
        /// <para>
        /// On the other hand, if the <c>Sns</c> property is not
        /// <c>null</c>, this property holds the subject (= unique
        /// identifier) of the end-user in the SNS.
        /// </para>
        ///
        /// <para>
        /// This property is always set when Authlete makes an
        /// authentication request.
        /// </para>
        /// </remarks>
        [JsonProperty("id")]
        public string Id { get; set; }


        /// <summary>
        /// The password of the end-user.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property holds (1) the value of the password that
        /// the end-user entered to the password field in the
        /// authorization page displayed at the direct
        /// authorization endpoint
        /// (<c>/api/auth/authorization/direct/<i>{service-api-key}</i></c>),
        /// or (2) the value of the <c>"password"</c> request
        /// parameter of a request to the direct token endpoint
        /// (<c>/api/auth/token/direct/<i>{service-api-key}</i></c>)
        /// in the case of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials</a> flow.
        /// </para>
        ///
        /// <para>
        /// If the <c>Sns</c> property is <c>null</c>, it is
        /// ensured that this property is not <c>null</c>. In such
        /// a case, authentication should be performed on the pair
        /// of the <c>Id</c> property and this <c>Password</c>
        /// property. On the other hand, if the <c>Sns</c> property
        /// is not <c>null</c>, this property has no meaning
        /// because authentication was performed by the SNS.
        /// </para>
        /// </remarks>
        [JsonProperty("password")]
        public string Password { get; set; }


        /// <summary>
        /// The list of claims requested by the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A <i>claim</i> is a piece of information about an
        /// end-user. Some standard claim names such as
        /// <c>given_name</c> and <c>email</c> are defined in
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
        /// Standard Claims</a> of
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>. The implementation of the
        /// authentication callback endpoint should extract data
        /// corresponding to the claims from its database and
        /// return them to Authlete. The data will be embedded in
        /// an ID token.
        /// </para>
        ///
        /// <para>
        /// This property is <c>null</c> when claim data are not
        /// necessary (= when an ID token is not necessary to be
        /// generated).
        /// </para>
        /// </remarks>
        [JsonProperty("claims")]
        public string[] Claims { get; set; }


        /// <summary>
        /// The list of locales for claims.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property holds the value of the
        /// <c>"claims_locales"</c> request parameter contained in
        /// an authorization request. The values are the end-user's
        /// preferred languages and scripts for claims. See
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#ClaimsLanguagesAndScripts">5.2.
        /// Claims Languages and Scripts</a> of
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </para>
        ///
        /// <para>
        /// This property is <c>null</c> when claim data are not
        /// necessary (= when an ID token is not necessary to be
        /// generated).
        /// </para>
        /// </remarks>
        [JsonProperty("claimsLocales")]
        public string[] ClaimsLocales { get; set; }


        /// <summary>
        /// The SNS that the end-user used for social login.
        /// <c>null</c> if the end-user did not use social login.
        /// </summary>
        [JsonProperty("sns")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Sns Sns { get; set; }


        /// <summary>
        /// The access token returned by the SNS which the end-user
        /// used for social login.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The refresh token returned by the SNS which the
        /// end-user used for social login.
        /// </summary>
        /// <value>The refresh token.</value>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The lifetime of the access token in seconds.
        /// </summary>
        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }


        /// <summary>
        /// The raw response from the token endpoint of the SNS.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the SNS complies with RFC 6749, the format is JSON.
        /// Note that Facebook returns data formatted in
        /// <c>application/x-www-form-urlencoded</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("rawTokenResponse")]
        public string RawTokenResponse { get; set; }
    }
}
