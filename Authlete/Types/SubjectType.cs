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
    /// Subject types. See
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#SubjectIDTypes">8.
    /// Subject Identifier Types</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for details.
    /// </summary>
    public enum SubjectType
    {
        /// <summary>
        /// This provides the same <c>sub</c> (subject) value to
        /// all Clients. It is the default if the provider has no
        /// <c>subject_types_supported</c> element in its discovery
        /// document.
        /// </summary>
        PUBLIC = 1,


        /// <summary>
        /// This provides a different <c>sub</c> (subject) value to
        /// each Client, so as not to enable Clients to correlate
        /// the End-User's activities without permission.
        /// </summary>
        PAIRWISE,
    }
}
