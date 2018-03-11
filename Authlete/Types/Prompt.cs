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
    /// Values for the <c>"prompt"</c> request parameter defined in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </summary>
    public enum Prompt
    {
        /// <summary>
        /// The Authorization Server MUST NOT display any
        /// authentication or consent user interface pages.
        /// An error is returned if an End-User is not already
        /// authenticated or the Client does not have
        /// pre-configured consent for the requested Claims or
        /// does not fulfill other conditions for processing
        /// the request. The error code will typically be
        /// <c>login_required</c>, <c>interaction_required</c>,
        /// or another code defined in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthError">Section
        /// 3.1.2.6</a>. This can be used as a method to check
        /// for existing authentication and/or consent.
        /// </summary>
        NONE,


        /// <summary>
        /// The Authorization Server SHOULD prompt the End-User
        /// for reauthentication. If it cannot reauthenticate
        /// the End-User, it MUST return an error, typically
        /// <c>login_required</c>.
        /// </summary>
        LOGIN,


        /// <summary>
        /// The Authorization Server SHOULD prompt the End-User
        /// for consent before returning information to the
        /// Client. If it cannot obtain consent, it MUST return
        /// an error, typically <c>consent_required</c>.
        /// </summary>
        CONSENT,


        /// <summary>
        /// The Authorization Server SHOULD prompt the End-User
        /// to select a user account. This enables an End-User
        /// who has multiple accounts at the Authorization
        /// Server to select amongst the multiple accounts that
        /// they might have current sessions for. If it cannot
        /// obtain an account selection choice made by the
        /// End-User, it MUST return an error, typically
        /// <c>account_selection_required</c>.
        /// </summary>
        SELECT_ACCOUNT,
    }
}
