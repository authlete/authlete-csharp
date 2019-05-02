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
    /// <c>/api/backchannel/authentication/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationCompleteResult
    {
        /// <summary>
        /// The end-user was authenticated and has granted
        /// authorization to the client application.
        /// </summary>
        AUTHORIZED = 1,


        /// <summary>
        /// The end-user denied the backchannel authentication
        /// request.
        /// </summary>
        ACCESS_DENIED,


        /// <summary>
        /// The authorization server could not get the result of
        /// end-user authentication and authorization from the
        /// authentication device for some reasons.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// For example, the authorization server failed to
        /// communicate with the authentication device due to a
        /// network error, the device did not return a response
        /// within a reasonable time, etc.
        /// </para>
        ///
        /// <para>
        /// This result can be used as a generic error.
        /// </para>
        /// </remarks>
        TRANSACTION_FAILED,
    }
}
