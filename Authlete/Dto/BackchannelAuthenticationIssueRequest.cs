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


using Newtonsoft.Json;


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's
    /// <c>/api/backchannel/authentication/issue</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The API prepares JSON that contains an <c>auth_req_id</c>.
    /// The JSON should be used as the response body of the
    /// response which is returned to the client application from
    /// the backchannel authentication endpoint.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationIssueRequest
    {
        /// <summary>
        /// The ticket which is necessary to call Authlete's
        /// <c>/api/backchannel/authentication/issue</c> API. It is
        /// the ticket previously issued by Authlete's
        /// <c>/api/backchannel/authentication</c> API.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
    }
}
