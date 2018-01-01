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
    /// <c>"alg"</c> (Algorithm) Header Parameter Values for JWS
    /// defined in
    /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
    /// </summary>
    public enum JWSAlg
    {
        /// <summary>
        /// No digital signature or MAC performed.
        /// </summary>
        NONE,


        /// <summary>
        /// HMAC using SHA-256.
        /// </summary>
        HS256,


        /// <summary>
        /// HMAC using SHA-384.
        /// </summary>
        HS384,


        /// <summary>
        /// HMAC using SHA-512.
        /// </summary>
        HS512,


        /// <summary>
        /// RSASSA-PKCS-v1_5 using SHA-256.
        /// </summary>
        RS256,


        /// <summary>
        /// RSASSA-PKCS-v1_5 using SHA-384.
        /// </summary>
        RS384,


        /// <summary>
        /// RSASSA-PKCS-v1_5 using SHA-512.
        /// </summary>
        RS512,


        /// <summary>
        /// ECDSA using P-256 and SHA-256.
        /// </summary>
        ES256,


        /// <summary>
        /// ECDSA using P-384 and SHA-384.
        /// </summary>
        ES384,


        /// <summary>
        /// ECDSA using P-521 and SHA-512.
        /// </summary>
        ES512,


        /// <summary>
        /// RSASSA-PSS using SHA-256 and MGF1 with SHA-256.
        /// </summary>
        PS256,


        /// <summary>
        /// RSASSA-PSS using SHA-384 and MGF1 with SHA-384.
        /// </summary>
        PS384,


        /// <summary>
        /// RSASSA-PSS using SHA-512 and MGF1 with SHA-512.
        /// </summary>
        PS512,
    }
}
