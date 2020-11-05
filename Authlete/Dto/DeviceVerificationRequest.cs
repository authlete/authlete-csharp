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


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's <c>/api/device/verification</c> API.
    /// The API is used to get information associated with a user
    /// code.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// A response from the device authorization endpoint of the
    /// authorization server is JSON which contains a device code,
    /// a user code, a verification URI and other parameters.
    /// The definition of the response is described in Section
    /// 3.2 of <a href="https://www.rfc-editor.org/rfc/rfc8628.html">RFC 8628</a>
    /// OAuth 2.0 Device Authorization Grant.
    /// </para>
    ///
    /// <para>
    /// After receiving a response from the device authorization
    /// endpoint of the authorization server, the client
    /// application shows the end-user the user code and the
    /// verification URI which are included in the device
    /// authorization response. Then, the end-user will access
    /// the verification URI using a web browser on another
    /// device (typically, s smart phone). In normal
    /// implementations, the verification endpoint will return
    /// an HTML page with an input form where the end-user
    /// inputs a user code. The authorization server will
    /// receive a user code from the form.
    /// </para>
    ///
    /// <para>
    /// After receiving a user code, the authorization server
    /// should call Authlete's <c>/api/device/verification</c>
    /// API with the user code. The API will return information
    /// associated with the user code such as client information
    /// and requested scopes. Using the information, the
    /// authorization server should generate an HTML page that
    /// confirms the end-user's consent and send the page back
    /// to the web browser.
    /// </para>
    ///
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public class DeviceVerificationRequest
    {
        /// <summary>
        /// The user code input by the end-user.
        /// </summary>
        [JsonProperty("userCode")]
        public string UserCode { get; set; }
    }
}
