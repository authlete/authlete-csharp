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


using Authlete.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's
    /// <c>/api/backchannel/authentication/issue</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/backchannel/authentication/issue</c> API
    /// returns JSON which can be mapped to this class. The
    /// authorization server implementation should retrieve the
    /// value of the <c>action</c> response parameter (which can be
    /// obtained via the <c>Action</c> property) from the response
    /// and take the following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationIssueAction.OK</c>, it means
    /// that Authlete has succeeded in preparing JSON that contains
    /// an <c>auth_req_id</c>. The JSON should be used as the
    /// response body of the response which is returned to the
    /// client from the backchannel authentication endpoint. The
    /// <c>ResponseContent</c> property holds the JSON.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationIssueAction.INTERNAL_SERVER_Error</c>,
    /// it means that an error occurred in Authlete.
    /// </para>
    ///
    /// <para>
    /// From a viewpoint of the client application, this is an error
    /// on the server side. Therefore, the authorization server
    /// implementation should generate a response to the client
    /// application with <c>500 Internal Server Error</c> and
    /// <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationIssueAction.INVALID_TICKET</c>,
    /// it means that the ticket included in the API call was
    /// invalid. For example, it does not exist or has expired.
    /// </para>
    ///
    /// <para>
    /// From a viewpoint of the client application, this is an error
    /// on the server side. Therefore, the authorization server
    /// implementation should generate a response to the client
    /// application with <c>500 Internal Server Error</c> and
    /// <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// You can build an error response in the same way as shown in
    /// the description for the case of <c>INTERNAL_SERVER_ERROR</c>.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationIssueResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BackchannelAuthenticationIssueAction Action { get; set; }


        /// <summary>
        /// The content of the response body of the response to the
        /// client application. Its format is JSON.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// In successful cases, the content contains
        /// <c>auth_req_id</c>. In error cases, the content
        /// contains <c>error</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The issued authentication request ID. This corresponds
        /// to the <c>auth_req_id</c> property in the response to
        /// the client application.
        /// </summary>
        [JsonProperty("authReqId")]
        public string AuthReqId { get; set; }


        /// <summary>
        /// The duration of the issued authentication request ID in
        /// seconds. This corresponds to the <c>expires_in</c>
        /// property in the response to the client application.
        /// </summary>
        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }


        /// <summary>
        /// The minimum amount of time in seconds that the client
        /// must wait for between polling requests to the token
        /// endpoint. This corresponds to the <c>interval</c>
        /// property in the response to the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value held by this property has no meaning when the
        /// backchannel token delivery mode is "push".
        /// </para>
        /// </remarks>
        [JsonProperty("interval")]
        public int Interval { get; set; }
    }
}
