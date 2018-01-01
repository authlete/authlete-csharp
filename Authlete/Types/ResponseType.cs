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
    /// Response types. See
    /// <a href="https://openid.net/specs/oauth-v2-multiple-response-types-1_0.html">OAuth
    /// 2.0 Multiple Response Type Encoding Practices</a> for
    /// details.
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// <c>"none"</c>; a <c>response_type</c> to request no
        /// access credentials.
        /// </summary>
        NONE,


        /// <summary>
        /// <c>"code"</c>; a <c>response_type</c> to request an
        /// authorization code.
        /// </summary>
        CODE,


        /// <summary>
        /// <c>"token"</c>; a <c>response_type</c> to request an
        /// access token.
        /// </summary>
        TOKEN,


        /// <summary>
        /// <c>"id_token"</c>; a <c>response_type</c> to request an
        /// ID token.
        /// </summary>
        ID_TOKEN,


        /// <summary>
        /// <c>"code token"</c>; a <c>response_type</c> to request
        /// an authorization code and an access token.
        /// </summary>
        CODE_TOKEN,


        /// <summary>
        /// <c>"code id_token"</c>; a <c>response_type</c> to
        /// request an authorization code and an ID token.
        /// </summary>
        CODE_ID_TOKEN,


        /// <summary>
        /// <c>"id_token token"</c>; a <c>response_type</c> to
        /// request an ID token and an access token.
        /// </summary>
        ID_TOKEN_TOKEN,


        /// <summary>
        /// <c>"code id_token token"</c>; a <c>response_type</c> to
        /// request an authorization code, an ID token and an
        /// access token.
        /// </summary>
        CODE_ID_TOKEN_TOKEN,
    }
}
