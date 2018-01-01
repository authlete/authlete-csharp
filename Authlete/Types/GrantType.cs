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
    /// Grant types.
    /// </summary>
    public enum GrantType
    {
        /// <summary>
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.1">Authorization
        /// Code flow</a>, a grant type to request an access token
        /// and/or an ID token, and optionally a refresh token,
        /// using an authorization code.
        /// </summary>
        AUTHORIZATION_CODE = 1,


        /// <summary>
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.2">Implicit
        /// flow</a>, which is not a valid value for the
        /// <c>"grant_type"</c> request parameter of token requests
        /// but is listed in this enum because
        /// <a href="http://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> uses
        /// <c>"implicit"</c> as a value of <c>"grant_types"</c> of
        /// client metadata.
        /// </summary>
        IMPLICIT,


        /// <summary>
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials flow</a>, a grant type to
        /// request an access token using a resource owner's
        /// <c>username</c> and <c>password</c>.
        /// </summary>
        PASSWORD,


        /// <summary>
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.4">Client
        /// Credentials flow</a>, a grant type to request an access
        /// token using a client's credentials.
        /// </summary>
        CLIENT_CREDENTIALS,


        /// <summary>
        /// <a href="https://tools.ietf.org/html/rfc6749#section-6">Refresh
        /// Token flow</a>, a grant type to request an access token,
        /// and optionally an ID token and/or a refresh token,
        /// using a refresh token.
        /// </summary>
        REFRESH_TOKEN,
    }
}
