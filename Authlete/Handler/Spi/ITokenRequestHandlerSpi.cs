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


using Authlete.Dto;


namespace Authlete.Handler.Spi
{
    /// <summary>
    /// Service Provider Interface for <c>TokenRequestHandler</c>.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An implementation of this interface needs to be given to
    /// the constructor of <c>TokenRequestHandler</c>.
    /// </para>
    ///
    /// <para>
    /// <c>TokenRequestHandlerSpiAdapter</c> is an empty
    /// implementation of this interface.
    /// </para>
    /// </remarks>
    public interface ITokenRequestHandlerSpi
    {
        /// <summary>
        /// Authenticate an end-user.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This method is called only when
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials Grant</a> was used.
        /// Therefore, if you have no plan to support the flow,
        /// always return <c>null</c>. In most cases, you don't
        /// have to support the flow. FYI:
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>
        /// says <i>"The authorization server should take special
        /// care when enabling this grant type and only allow it
        /// when other flows are not viable."</i>
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The subject (= unique identifier) of the authenticated
        /// end-user. If the pair of <c>username</c> and
        /// <c>password</c> is invalid, <c>null</c> should be
        /// returned.
        /// </returns>
        ///
        /// <param name="username">
        /// The value of the <c>"username"</c> request parameter
        /// of the token request.
        /// </param>
        ///
        /// <param name="password">
        /// The value of the <c>"password"</c> request parameter
        /// of the token request.
        /// </param>
        string AuthenticateUser(string username, string password);


        /// <summary>
        /// Get arbitrary key-value pairs to be associated with
        /// an access token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Properties returned from this method will appear as
        /// top-level entries (unless they are marked as hidden) in
        /// a JSON response from the authorization server as shown
        /// in
        /// <a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </para>
        ///
        /// <para>
        /// Keys listed below should not be used and they would be
        /// ignored on Authlete side even if they were used. It is
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
        /// properties. On Authlete side, the properties will be
        /// (1) converted to a multidimensional string array, (2)
        /// converted to JSON, (3) encrypted by AES/CBC/PKCS5Padding,
        /// (4) encoded by base64url, and then stored into the
        /// database. The length of the resultant string must not
        /// exceed 65,535 in bytes. This is the upper limit, but
        /// we think it is big enough.
        /// </para>
        ///
        /// <para>
        /// When the value of the <c>"grant_type"</c> parameter of
        /// a token request is <c>"authorization_code"</c> or
        /// <c>"refresh_token"</c>, properties are merged. Rules
        /// are described below.
        /// </para>
        ///
        /// <list type="bullet">
        /// <item>
        /// <term>grant_type=authorization_code</term>
        /// <description>
        /// If the authorization code presented by the client
        /// application already has extra properties (this happens
        /// if <c>IAuthorizationDecisionHandlerSpi.GetProperties</c>
        /// returned extra properties when the authorization code
        /// was issued), extra properties returned by this method
        /// will be merged into the existing extra properties. Note
        /// that the existing extra properties will be overwritten
        /// if extra properties returned by this method have the
        /// same keys.
        /// For example, if an authorization code has two extra
        /// properties, <c>a=1</c> and <c>b=2</c>, and if this
        /// method returns two extra properties, <c>a=A</c> and
        /// <c>c=3</c>, the resultant access token will have three
        /// extra properties, <c>a=A</c>, <c>b=2</c> and <c>c=3</c>.
        /// </description>
        /// </item>
        ///
        /// <item>
        /// <term>grant_type=refresh_token</term>
        /// <description>
        /// If the access token associated with the refresh token
        /// already has extra properties, extra properties returned
        /// by this method will be merged into the existing extra
        /// properties. Note that the existing extra properties
        /// will be overwritten if extra properties returned by
        /// this method have the same keys.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        ///
        /// <returns>
        /// Arbitrary key-value pairs to be associated with an
        /// access token.
        /// </returns>
        Property[] GetProperties();
    }
}
