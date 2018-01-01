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
    /// <c>"alg"</c> (Algorithm) Header Parameter Values for JWE
    /// defined in
    /// <a href="https://tools.ietf.org/html/rfc7518">RFC 7518</a>.
    /// </summary>
    public enum JWEAlg
    {
        /// <summary>
        /// RSAES-PKCS1-V1_5.
        /// </summary>
        RSA1_5 = 1,


        /// <summary>
        /// RSAES OAEP using default parameters.
        /// </summary>
        RSA_OAEP,


        /// <summary>
        /// RSAES OAEP using SHA-256 and MGF1 with SHA-256.
        /// </summary>
        RSA_OAEP_256,


        /// <summary>
        /// AES Key Wrap with default initial value using 128 bit key.
        /// </summary>
        A128KW,


        /// <summary>
        /// AES Key Wrap with default initial value using 192 bit key.
        /// </summary>
        A192KW,


        /// <summary>
        /// AES Key Wrap with default initial value using 256 bit key.
        /// </summary>
        A256KW,


        /// <summary>
        /// Direct use of a shared symmetric key as the CEK.
        /// </summary>
        DIR,


        /// <summary>
        /// Elliptic Curve Diffie-Hellman Ephemeral Static key
        /// agreement using Concat KDF.
        /// </summary>
        ECDH_ES,


        /// <summary>
        /// ECDH-ES using Concat KDF and CEK wrapped with "A128KW".
        /// </summary>
        ECDH_ES_A128KW,


        /// <summary>
        /// ECDH-ES using Concat KDF and CEK wrapped with "A192KW".
        /// </summary>
        ECDH_ES_A192KW,


        /// <summary>
        /// ECDH-ES using Concat KDF and CEK wrapped with "A256KW".
        /// </summary>
        ECDH_ES_A256KW,


        /// <summary>
        /// Key wrapping with AES GCM using 128 bit key.
        /// </summary>
        A128GCMKW,


        /// <summary>
        /// Key wrapping with AES GCM using 192 bit key.
        /// </summary>
        A192GCMKW,


        /// <summary>
        /// Key wrapping with AES GCM using 256 bit key.
        /// </summary>
        A256GCMKW,


        /// <summary>
        /// PBES2 with HMAC SHA-256 and "A128KW".
        /// </summary>
        PBES2_HS256_A128KW,


        /// <summary>
        /// PBES2 with HMAC SHA-384 and "A192KW".
        /// </summary>
        PBES2_HS384_A192KW,


        /// <summary>
        /// PBES2 with HMAC SHA-512 and "A256KW".
        /// </summary>
        PBES2_HS512_A256KW,
    }
}
