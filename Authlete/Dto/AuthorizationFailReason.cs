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


namespace Authlete.Dto
{
    /// <summary>
    /// The value of <c>reason</c> in requests to Authlete's
    /// <c>/api/auth/authorization/fail</c> API.
    /// </summary>
    public enum AuthorizationFailReason
    {
        /// <summary>
        /// Unknown reason. Using this reason will result in
        /// <c>error=server_error</c>.
        /// </summary>
        UNKNOWN,


        /// <summary>
        /// The authorization request from the client application
        /// contained <c>prompt=none</c>, but any end-user has not
        /// logged in. Using this reason will result in
        /// <c>error=login_required</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"prompt"</c> request
        /// parameter.
        /// </para>
        /// </remarks>
        NOT_LOGGED_IN,


        /// <summary>
        /// The authorization request from the client application
        /// contained the <c>"max_age"</c> request parameter with a
        /// non-zero value or the client's configuration has a
        /// non-zero value for the <c>"default_max_age"</c>
        /// configuration parameter, but the authorization server
        /// implementation cannot behave properly based on the max
        /// age value mainly because the authorization server
        /// implementation does not manage authentication time of
        /// end-users. Using this reason will result in
        /// <c>error=login_required</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"max_age"</c> request
        /// parameter.
        /// </para>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> for the
        /// <c>"default_max_age"</c> configuration parameter.
        /// </para>
        /// </remarks>
        MAX_AGE_NOT_SUPPORTED,


        /// <summary>
        /// The authorization request from the client application
        /// contained <c>prompt=none</c>, but the time specified by
        /// the <c>"max_age"</c> request parameter or by the
        /// <c>"default_max_age"</c> configuration parameter has
        /// passed since the time at which the end-user logged in.
        /// Using this reason will result in
        /// <c>error=login_required</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"prompt"</c> and
        /// <c>"max_age"</c> request parameters.
        /// </para>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> for the
        /// <c>"default_max_age"</c> configuration parameter.
        /// </para>
        /// </remarks>
        EXCEEDS_MAX_AGE,


        /// <summary>
        /// The authorization request from the client application
        /// requested a specific value for the <c>"sub"</c> claim,
        /// but the current end-user (in the case of
        /// <c>prompt=none</c>) or the end-user after the
        /// authentication is different from the specified value.
        /// Using this reason will result in
        /// <c>error=login_required</c>.
        /// </summary>
        DIFFERENT_SUBJECT,


        /// <summary>
        /// The authorization request from the client application
        /// contained the <c>"acr"</c> claim in the <c>"claims"</c>
        /// request parameter and the claim was marked as essential,
        /// but the ACR performed for the end-user does not match
        /// any one of the requested ACRs. Using this reason will
        /// result in <c>error=login_required</c>.
        /// </summary>
        ACR_NOT_SATISFIED,


        /// <summary>
        /// The end-user denied the authorization request from the
        /// client application. Using this reason will result in
        /// <c>error=access_denied</c>.
        /// </summary>
        DENIED,


        /// <summary>
        /// Server error. Using this reason will result in
        /// <c>error=server_error</c>.
        /// </summary>
        SERVER_ERROR,


        /// <summary>
        /// The end-user was not authenticated. Using this reason
        /// will result in <c>error=login_required</c>.
        /// </summary>
        NOT_AUTHENTICATED,


        /// <summary>
        /// The authorization server cannot obtain an account
        /// selection choice made by the end-user. Using this
        /// reason will result in
        /// <c>error=account_selection_required</c>.
        /// </summary>
        ACCOUNT_SELECTION_REQUIRED,


        /// <summary>
        /// The authorization server cannot obtain consent from the
        /// end-user. Using this reason will result in
        /// <c>error=consent_required</c>.
        /// </summary>
        CONSENT_REQUIRED,


        /// <summary>
        /// The authorization server needs interaction with the
        /// end-user. Using this reason will result in
        /// <c>error=interaction_required</c>.
        /// </summary>
        INTERACTION_REQUIRED,
    }
}
