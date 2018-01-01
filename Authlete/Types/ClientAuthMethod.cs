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


namespace Authlete.Types
{
    /// <summary>
    /// Client authentication methods.
    /// </summary>
    public enum ClientAuthMethod
    {
        /// <summary>
        /// No client authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Client authentication is not performed at endpoints of
        /// the authorization server, either because the client
        /// uses only the implicit flow or because the client type
        /// of the client is "public".
        /// </para>
        /// </remarks>
        NONE,


        /// <summary>
        /// Client authentication using Basic Authentication as
        /// defined in
        /// <a href="http://tools.ietf.org/html/rfc6749#section-3.2.1">3.2.1.
        /// Client Authentication</a> of
        /// <a href="http://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </summary>
        CLIENT_SECRET_BASIC,


        /// <summary>
        /// Client authentication using the <c>"client_secret"</c>
        /// request parameter in the request body as defined in
        /// <a href="http://tools.ietf.org/html/rfc6749#section-3.2.1">3.2.1.
        /// Client Authentication</a> of
        /// <a href="http://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// </summary>
        CLIENT_SECRET_POST,


        /// <summary>
        /// Client authentication using JWT signed by the shared
        /// client secret as defined in
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#OAuth.JWT">JSON
        /// Web Token (JWT) Profile for OAuth 2.0 Client
        /// Authentication and Authorization Grants</a>.
        /// </summary>
        CLIENT_SECRET_JWT,


        /// <summary>
        /// Client authentication using JWT signed by the client's
        /// private key as defined in
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#OAuth.JWT">JSON
        /// Web Token (JWT) Profile for OAuth 2.0 Client
        /// Authentication and Authorization Grants</a>.
        /// </summary>
        PRIVATE_KEY_JWT,


        /// <summary>
        /// Client authentication using X.509 certificates as
        /// defined in "Mutual TLS Profiles for OAuth Clients".
        /// </summary>
        TLS_CLIENT_AUTH,


        /// <summary>
        /// Client authentication using self-signed certificates
        /// as defined in "Mutual TLS Profiles for OAuth Clients".
        /// </summary>
        SELF_SIGNED_TLS_CLIENT_AUTH,
    }
}
