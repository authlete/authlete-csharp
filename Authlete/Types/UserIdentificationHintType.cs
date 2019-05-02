//
// Copyright (C) 2019 Authlete, Inc.
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
    /// Types of hints for end-user identification.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum UserIdentificationHintType
    {
        /// <summary>
        /// "id_token_hint"; an ID token previously issued to the
        /// client application.
        /// </summary>
        ID_TOKEN_HINT = 1,


        /// <summary>
        /// "login_hint"; an arbitrary string whose interpretation
        /// varies depending on implementations.
        /// </summary>
        LOGIN_HINT,


        /// <summary>
        /// "login_hint_token"; a token whose format is deployment
        /// or profile specific.
        /// </summary>
        LOGIN_HINT_TOKEN,
    }
}
