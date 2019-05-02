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
    /// <c>/api/backchannel/authentication/fail</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationFailAction
    {
        /// <summary>
        /// The implementation of the backchannel authentication
        /// endpoint should return a <c>400 Bad Request</c>
        /// response to the client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The implementation of the backchannel authentication
        /// endpoint should return a <c>403 Forbidden</c> response
        /// to the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <c>BackchannelAuthenticationFailResponse.Action</c>
        /// holds this value only when the <c>reason</c> request
        /// parameter of the API call was
        /// <c>BackchannelAuthenticationFailReason.ACCESS_DENIED</c>.
        /// </para>
        /// </remarks>
        FORBIDDEN,


        /// <summary>
        /// The implementation of the backchannel authentication
        /// endpoint should return a <c>500 Internal Server Error</c>
        /// response to the client application. However, in most
        /// cases, commercial implementations prefer to use other
        /// HTTP status code than <c>5xx</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <c>BackchannelAuthenticationFailResponse.Action</c>
        /// holds this value only when (1) the <c>reason</c> request
        /// parameter of the API call was
        /// <c>BackchannelAuthenticationFailReason.SERVER_ERROR</c>,
        /// (2) an error occurred on Authlete side, or (3) the
        /// request parameters of the API call were wrong.
        /// </para>
        /// </remarks>
        INTERNAL_SERVER_ERROR,
    }
}
