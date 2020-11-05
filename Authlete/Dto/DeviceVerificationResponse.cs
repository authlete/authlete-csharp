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
    /// Response from Authlete's <c>/api/device/verification</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/device/verification</c> API returns
    /// JSON which can be mapped to this class. The authorization
    /// server implementation should retrieve the value of the
    /// <c>action</c> response parameter (which can be obtained via
    /// the <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceVerificationAction.BAD_REQUEST</c>, it means that
    /// the user code exists, has not expired, and belongs to the
    /// service. The authorization server implementation should
    /// interact with the end-user to ask whether she approves or
    /// rejects the authorization request from the device.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceVerificationAction.EXPIRED</c>, it means that the
    /// user code has expired. The authorization server
    /// implementation should tell the end-user that the user code
    /// has expired and urge her to re-initiate a device flow.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceVerificationAction.NOT_EXIST</c>, it means that
    /// the user code does not exist. The authorization server
    /// implementation should tell the end-user that the user
    /// code is invalid and urge her to retry to input a valid
    /// user code.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceVerificationAction.SERVER_ERROR</c>, it means
    /// that an error occurred on Authlete side. The authorization
    /// server implementation should tell the end-user that
    /// something wrong happened and urge her to re-initiate a
    /// device flow.
    /// </para>
    ///
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public class DeviceVerificationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceVerificationAction Action { get; set; }


        /// <summary>
        /// The client ID of the client application to which
        /// the user code has been issued.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The client ID alias of the client application to
        /// which the user code has been issued.
        /// </summary>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was used in the device authorization request.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The name of the client application to which the
        /// user code has been issued.
        /// </summary>
        [JsonProperty("clientName")]
        public string ClientName { get; set; }


        /// <summary>
        /// The scopes requested by the device authorization
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that <c>Description</c> property and
        /// <c>Descriptions</c> property of each element (<c>Scope</c>
        /// instance) in the array held by this property always
        /// null even if descriptions of the scopes are registered.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public Scope[] Scopes { get; set; }


        /// <summary>
        /// The names of the claims which were requested indirectly
        /// via some special scopes. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">5.4.
        /// Requesting Claims using Scope Values</a> in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property always holds null if the <c>scope</c>
        /// request parameter of the device authorization request
        /// does not include the <c>openid</c> scope even if
        /// special scopes (such as <c>profile</c>) are included
        /// in the request (unless the <c>openid</c> scope is
        /// included in the default set of scopes which is used
        /// when the <c>scope</c> request parameter is omitted).
        /// </para>
        /// </remarks>
        [JsonProperty("claimNames")]
        public string[] ClaimNames { get; set; }


        /// <summary>
        /// The list of ACRs (Authentication Context Class
        /// References) requested by the device authorization
        /// request.
        /// </summary>
        [JsonProperty("acrs")]
        public string[] Acrs { get; set; }


        /// <summary>
        /// The date in milliseconds since the Unix epoch
        /// (1970-Jan-1) at which the user code will expire.
        /// </summary>
        [JsonProperty("expiresAt")]
        public long ExpiresAt { get; set; }


        /// <summary>
        /// The resources specified by the <c>resource</c> request
        /// parameters in the preceding device authorization request.
        /// See
        /// <a href="https://www.rfc-editor.org/rfc/rfc8707.html">RFC 8707</a>
        /// (Resource Indicators for OAuth 2.0) for details.
        /// </summary>
        [JsonProperty("resources")]
        public string[] Resources { get; set; }
    }
}
