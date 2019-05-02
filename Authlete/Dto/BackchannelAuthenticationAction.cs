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
    /// The value of <c>action</c> in responses from Authlete's
    /// <c>/api/backchannel/authentication</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationAction
    {
        /// <summary>
        /// The backchannel authentication request is invalid. The
        /// authorization server implementation should return an
        /// error response with <c>400 Bad Request</c> and
        /// <c>application/json</c> to the client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// Client authentication of the backchannel authentication
        /// request failed. The authorization server implementation
        /// should return an error response with <c>401 Unauthorized</c>
        /// and <c>application/json</c> to the client application.
        /// </summary>
        UNAUTHORIZED,


        /// <summary>
        /// The API call from the authorization server implementation
        /// was wrong or an error occurred on Authlete side. The
        /// authorization server implementation should return an
        /// error response with <c>500 Internal Server Error</c>
        /// and <c>application/json</c> to the client application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The backchannel authentication request was valid. The
        /// authorization server implementation is required to (1)
        /// identify the subject of the end-user from the given
        /// hint, (2) issue <c>auth_req_id</c> to the client
        /// application, (3) communicate with an authentication
        /// device of the end-user to perform end-user
        /// authentication and authorization, etc. See the API
        /// document of <c>BackchannelAuthenticationResponse</c>
        /// for details.
        /// </summary>
        USER_IDENTIFICATION,
    }
}
