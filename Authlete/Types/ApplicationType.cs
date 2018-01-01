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
    /// Values for the <c>"application_type"</c> metadata defined in
    /// <a href="http://openid.net/specs/openid-connect-registration-1_0.html">OpenID
    /// Connect Dynamic Client Registration 1.0</a>.
    /// </summary>
    public enum ApplicationType
    {
        /// <summary>
        /// Web client application.
        /// </summary>
        WEB = 1,


        /// <summary>
        /// Native client application.
        /// </summary>
        NATIVE,
    }
}
