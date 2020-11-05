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


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/device/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/device/complete</c> API returns JSON
    /// which can be mapped to this class. The authorization server
    /// implementation should retrieve the value of the
    /// <c>action</c> response parameter (which can be obtained via
    /// the <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceCompleteAction.SUCCESS</c>, it means that the API
    /// call has been processed successfully. The authorization
    /// server should return a successful response to the web
    /// browser the end-user is using.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceCompleteAction.INVALID_REQUEST</c>, it means that
    /// the API call is invalid. Probably, the authorization server
    /// implementation has some bugs.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceCompleteAction.USER_CODE_EXPIRED</c>, it means
    /// that the user code included in the API call has expired.
    /// The authorization server implementation should tell the
    /// end-user that the user code has expired and urge her to
    /// re-initiate a device flow.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceCompleteAction.USER_CODE_NOT_EXIST</c>, it
    /// means that the user code included in the API call does
    /// not exist. The authorization server implementation
    /// should tell the end-user that the user code has been
    /// invalidated and urge her to re-initiate a device flow.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceCompleteAction.SERVER_ERROR</c>, it means that
    /// an error occurred on Authlete side. The authorization
    /// server implementation should tell the end-user that
    /// something wrong happened and urge her to re-initiate a
    /// device flow.
    /// </para>
    ///
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public class DeviceCompleteResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceCompleteAction Action { get; set; }
    }
}
