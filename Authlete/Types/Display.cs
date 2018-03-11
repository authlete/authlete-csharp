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
    /// Values for the <c>"display"</c> request parameter defined in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> and for the
    /// <c>"display_values_supported"</c> metadata defined in
    /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Connect Discovery 1.0</a>.
    /// </summary>
    public enum Display
    {
        /// <summary>
        /// The Authorization Server SHOULD display the
        /// authentication and consent UI consistent with a full
        /// User Agent page view. If the <c>display</c> parameter
        /// is not specified, this is the display mode.
        /// </summary>
        PAGE = 1,


        /// <summary>
        /// The Authorization Server SHOULD display the
        /// authentication and consent UI consistent with a popup
        /// User Agent window. The popup User Agent window should
        /// be of an appropriate size for a login-focused dialog
        /// and should not obscure the entire window that it is
        /// popping up over.
        /// </summary>
        POPUP,


        /// <summary>
        /// The Authorization Server SHOULD display the
        /// authentication and consent UI consistent with a device
        /// that leverages a touch interface.
        /// </summary>
        TOUCH,


        /// <summary>
        /// The Authorization Server SHOULD display the
        /// authentication and consent UI consistent with a
        /// "feature phone" type display.
        /// </summary>
        WAP,
    }
}
