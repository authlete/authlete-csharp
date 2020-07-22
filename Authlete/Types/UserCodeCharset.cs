//
// Copyright (C) 2020 Authlete, Inc.
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
    /// Character set for end-user verification codes in the device flow.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// See <a href="https://tools.ietf.org/html/rfc8628#section-6.1">6.1.
    /// User Code Recommendations</a> in
    /// <a href="https://tools.ietf.org/html/rfc8628">RFC 8628</a> (OAuth 2.0
    /// Device Authorization Grant) for recommendations for use code values.
    /// </para>
    ///
    /// <para>
    /// Since version 1.4.0.
    /// </para>
    /// </remarks>
    public enum UserCodeCharset
    {
        /// <summary>
        /// "BCDFGHJKLMNPQRSTVWXZ"; 20 upper-case non-vowel characters.
        /// </summary>
        BASE20 = 1,


        /// <summary>
        /// "0123456789"; 10 digit characters from 0 to 9.
        /// </summary>
        NUMERIC,
    }
}
