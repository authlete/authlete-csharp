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
    /// The value of <c>action</c> in responses from Authlete's
    /// <c>/api/device/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public enum DeviceCompleteAction
    {
        /// <summary>
        /// The API call has been processed successfully. The
        /// authorization server should return a successful
        /// response to the web browser the end-user is using.
        /// </summary>
        SUCCESS,


        /// <summary>
        /// The API call is invalid. Probably, the authorization
        /// server implementation has some bugs.
        /// </summary>
        INVALID_REQUEST,


        /// <summary>
        /// The user code has expired. The authorization server
        /// implementation should tell the end-user that the user
        /// code has expired and urge her to re-initiate a device
        /// flow.
        /// </summary>
        USER_CODE_EXPIRED,


        /// <summary>
        /// The user code does not exist. The authorization server
        /// implementation should tell the end-user that the user
        /// code has been invalidated and urge her to re-initiate
        /// a device flow.
        /// </summary>
        USER_CODE_NOT_EXIST,


        /// <summary>
        /// An error occurred on Authlete side. The authorization
        /// server implementation should tell the end-user that
        /// something wrong happened and urge her to re-initiate
        /// a device flow.
        /// </summary>
        SERVER_ERROR,
    }
}
