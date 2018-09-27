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
    /// Service profile.
    /// </summary>
    public enum ServiceProfile
    {
        /// <summary>
        /// <a href="https://openid.net/wg/fapi/">Financial-grade API</a>.
        /// </summary>
        FAPI = 1,


        /// <summary>
        /// <a href="https://www.openbanking.org.uk/">Open Banking</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        OPEN_BANKING = 2,
    }
}
