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
    /// <c>"enc"</c> (Encryption Algorithm) Header Parameter Values
    /// for JWE defined in
    /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
    /// </summary>
    public enum JWEEnc
    {
        /// <summary>
        /// Algorithm defined in
        /// <a href="https://tools.ietf.org/html/rfc7518#section-5.2.3">5.2.3.
        /// AES_128_CBC_HMAC_SHA_256</a> of
        /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
        /// </summary>
        A128CBC_HS256 = 1,


        /// <summary>
        /// Algorithm defined in
        /// <a href="https://tools.ietf.org/html/rfc7518#section-5.2.4">5.2.4.
        /// AES_192_CBC_HMAC_SHA_384</a> of
        /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
        /// </summary>
        A192CBC_HS384,


        /// <summary>
        /// Algorithm defined in
        /// <a href="https://tools.ietf.org/html/rfc7518#section-5.2.5">5.2.5.
        /// AES_256_CBC_HMAC_SHA_512</a> of
        /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
        /// </summary>
        A256CBC_HS512,


        /// <summary>
        /// AES GCM using 128 bit key.
        /// </summary>
        A128GCM,


        /// <summary>
        /// AES GCM using 192 bit key.
        /// </summary>
        A192GCM,


        /// <summary>
        /// AES GCM using 256 bit key.
        /// </summary>
        A256GCM,
    }
}
