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


namespace Authlete.Dto
{
    /// <summary>
    /// Failure reasons of backchannel authentication requests.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationFailReason
    {
        /// <summary>
        /// The "login_hint_token" included in the backchannel
        /// authentication request is not valid because it has
        /// expired.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that the CIBA Core specification does not describe
        /// the format of <c>login_hint_token</c> and how to detect
        /// expiration.
        /// </para>
        ///
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"expired_login_hint_token"</c>.
        /// </para>
        /// </remarks>
        EXPIRED_LOGIN_HINT_TOKEN,


        /// <summary>
        /// The authorization server is not able to identify which
        /// end-user the client wishes to be authenticated by means
        /// of the hint (<c>login_hint_token</c>, <c>id_token_hint</c>
        /// or <c>login_hint</c>) included in the backchannel
        /// authentication request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"unknown_user_id"</c>.
        /// </para>
        /// </remarks>
        UNKNOWN_USER_ID,


        /// <summary>
        /// The client is not authorized to use the CIBA flow.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that <c>/api/backchannel/authentication</c> API
        /// does not return <c>action=USER_IDENTIFICATION</c> in
        /// cases where the client does not exist or client
        /// authentication has failed. Therefore, the authorization
        /// server implementation will never have to call
        /// <c>/api/backchannel/authentication/fail</c> API with
        /// <c>reason=UNAUTHORIZED_CLIENT</c> unless the server has
        /// intentionally implemented custom rules to reject
        /// backchannel authentication requests from particular
        /// clients.
        /// </para>
        ///
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"unauthorized_client"</c>.
        /// </para>
        /// </remarks>
        UNAUTHORIZED_CLIENT,


        /// <summary>
        /// A user code is required but the backchannel
        /// authentication request does not contain it.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that <c>/api/backchannel/authentication</c> API
        /// does not return <c>action=USER_IDENTIFICATION</c> when
        /// both the <c>backchannel_user_code_parameter_supported</c>
        /// metadata of the server and the
        /// <c>backchannel_user_code_parameter</c> metadata of the
        /// client are <c>true</c> and the backchannel
        /// authentication request does not include the
        /// <c>user_code</c> request parameter. In this case,
        /// <c>/api/backchannel/authentication</c> API returns
        /// <c>action=BAD_REQUEST</c> with JSON containing
        /// <c>"error":"missing_user_code"</c>.
        /// </para>
        ///
        /// <para>
        /// Therefore, the authorization server implementation will
        /// never have to call
        /// <c>/api/backchannel/authentication/fail</c> API with
        /// <c>reason=MISSING_USER_CODE</c> unless the server has
        /// intentionally implemented custom rules to require a
        /// user code even in the case where the
        /// <c>backchannel_user_code_parameter</c> metadata of the
        /// client which has made the backchannel authentication
        /// request is <c>false</c>.
        /// </para>
        ///
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"missing_user_code"</c>.
        /// </para>
        /// </remarks>
        MISSING_USER_CODE,


        /// <summary>
        /// The user code included in the backchannel authentication
        /// request is invalid.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"invalid_user_code"</c>.
        /// </para>
        /// </remarks>
        INVALID_USER_CODE,


        /// <summary>
        /// The binding message is invalid or unacceptable for use
        /// in the context of the given backchannel authentication
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"invalid_binding_message"</c>.
        /// </para>
        /// </remarks>
        INVALID_BINDING_MESSAGE,


        /// <summary>
        /// The resource owner or the authorization server denied
        /// the request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Calling <c>/api/backchannel/authentication/fail</c> API
        /// with this reason implies that the backchannel
        /// authentication endpoint is going to return an error of
        /// <c>access_denied</c> to the client application without
        /// asking the end-user whether she authorizes or rejects
        /// the request.
        /// </para>
        ///
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"access_denied"</c>.
        /// </para>
        /// </remarks>
        ACCESS_DENIED,


        /// <summary>
        /// The backchannel authentication request cannot be
        /// processed successfully due to a server-side error.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Using this reason will result in
        /// <c>"error":"server_error"</c>.
        /// </para>
        /// </remarks>
        SERVER_ERROR,
    }
}
