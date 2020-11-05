//
// Copyright (C) 2020 Authlete, Inc.
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
    /// Valid values of <c>result</c> in requests to Authlete's
    /// <c>/api/device/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public enum DeviceCompleteResult
    {
        /// <summary>
        /// The end-user was authenticated and has granted
        /// authorization to the client application.
        /// </summary>
        AUTHORIZED,


        /// <summary>
        /// The end-user denied the device authorization request.
        /// </summary>
        ACCESS_DENIED,


        /// <summary>
        /// The authorization server could not get decision from
        /// the end-user for some reasons.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This result can be used as a generic error.
        /// </para>
        /// </remarks>
        TRANSACTION_FAILED,
    }
}
