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


using Authlete.Dto;


namespace Authlete.Handler.Spi
{
    /// <summary>
    /// The base interface for Service Provider Interfaces for
    /// authorization request handlers. Common methods for
    /// <c>INoInteractionHandlerSpi</c> and
    /// <c>IAuthorizationRequestDecisionHandlerSpi</c>.
    /// </summary>
    public interface IAuthorizationRequestHandlerSpi
        : IUserClaimProvider
    {
        /// <summary>
        /// Get the time when the end-user was authenticated.
        /// </summary>
        ///
        /// <returns>
        /// The time when the current end-user was authenticated.
        /// The number of seconds since the Unix epoch (1970-Jan-1).
        /// 0 means that the time is unknown.
        /// </returns>
        long GetUserAuthenticatedAt();


        /// <summary>
        /// Get the subject (= unique identifier) of the end-user.
        /// It must consist of only ASCII letters and its length
        /// must not exceed 100.
        /// </summary>
        ///
        /// <returns>
        /// The subject of the end-user.
        /// </returns>
        string GetUserSubject();


        /// <summary>
        /// The value of the <c>"sub"</c> claim that will be
        /// embedded in an ID token. If this method returns
        /// <c>null</c>, the value returned from
        /// <c>GetUserSubject</c> will be used.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The main purpose of this method is to hide the actual
        /// value of the subject from client applications.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The value of the <c>"sub"</c> claim.
        /// </returns>
        string GetSub();


        /// <summary>
        /// Get the authentication context class reference (ACR)
        /// that was satisfied when the end-user was authenticated.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value returned from this method has an important
        /// meaning only when the <c>"acr"</c> claim is requested
        /// as an essential claim. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#acrSemantics">5.5.1.1.
        /// Requesting the "acr" Claim</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The ACR that was satisfied when the end-user was
        /// authenticated. If your system does not recognize ACR,
        /// <c>null</c> should be returned.
        /// </returns>
        string GetAcr();


        /// <summary>
        /// Get arbitrary key-value pairs to be associated with
        /// an access token and/or an authorization code.
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
        /// </remarks>
        ///
        /// <returns>
        /// Arbitrary key-value pairs to be associated with an
        /// access token and/or an authorization code.
        /// </returns>
        Property[] GetProperties();


        /// <summary>
        /// Get scopes to be associated with an access token and/or
        /// an authorization code.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If <c>null</c> is returned, the scopes specified in the
        /// original authorization request from the client
        /// application are used. In other cases, the specified
        /// scopes by this method will replace the original scopes.
        /// </para>
        ///
        /// <para>
        /// Even scopes that are not included in the original
        /// authorization request can be specified. However, as an
        /// exception, the <c>"openid"</c> scope is ignored on
        /// Authlete server side if it is not included in the
        /// original request. It is because the existence of the
        /// <c>"openid"</c> scope considerably changes the
        /// validation steps and because adding <c>"openid"</c>
        /// triggers generation of an ID token (although the client
        /// application has not requested it) and the behavior is a
        /// major violation against the specification.
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
        /// <c>"scopes"</c> parameter.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// Scopes which replace the scopes of the original
        /// authorization request. If <c>null</c> is returned, the
        /// scopes will not be replaced.
        /// </returns>
        string[] GetScopes();
    }
}
