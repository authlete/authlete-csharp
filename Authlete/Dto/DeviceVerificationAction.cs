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
    /// <c>/api/device/verification</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public enum DeviceVerificationAction
    {
        /// <summary>
        /// The user code is valid. This means that the user code
        /// exists, has not expired, and belongs to the service.
        /// The authorization server implementation should
        /// interact with the end-user to ask whether she approves
        /// or rejects the authorization request from the device.
        /// </summary>
        VALID,


        /// <summary>
        /// The user code has expired. The authorization server
        /// implementation should tell the end-user that the user
        /// code has expired and urge her to re-initiate a device
        /// flow.
        /// </summary>
        EXPIRED,


        /// <summary>
        /// The user code does not exist. The authorization server
        /// implementation should tell the end-user that the user
        /// code is invalid and urge her to retry to input a valid
        /// user code.
        /// </summary>
        NOT_EXIST,


        /// <summary>
        /// An error occurred on Authlete side. The authorization
        /// server implementation should tell the end-user that
        /// something wrong happened and urge her to re-initiate
        /// a device flow.
        /// </summary>
        SERVER_ERROR,
    }
}
