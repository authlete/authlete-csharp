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
    /// Claim types defined in
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#ClaimTypes">5.6.
    /// Claim Types</a> in
    /// <a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </summary>
    public enum ClaimType
    {
        /// <summary>
        /// Claims that are directly asserted by the OpenID
        /// Provider.
        /// </summary>
        NORMAL = 1,


        /// <summary>
        /// Claims that are asserted by a Claims Provider other
        /// than the OpenID Provider but are returned by the OpenID
        /// Provider.
        /// </summary>
        AGGREGATED,


        /// <summary>
        /// Claims that are asserted by a Claims Provider other
        /// than the OpenID Provider but are returned as references
        /// by the OpenID Provider.
        /// </summary>
        DISTRIBUTED,
    }
}
