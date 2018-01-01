//
// Copyright (C) 2018 Authlete, Inc.
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
    /// Request to Authlete's <c>/api/auth/token/issue</c> API.
    /// </summary>
    public class TokenIssueRequest
    {
        /// <summary>
        /// The ticket issued by Authlete's <c>/api/auth/token</c>
        /// API. It is the value of the <c>"ticket"</c> response
        /// parameter in the response from the API. This request
        /// parameter is mandatory.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the authenticated
        /// user.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// Extra properties to be associated with a newly created
        /// access token. Note that the <c>"properties"</c> request
        /// parameter is accepted only when <c>Content-Type</c> of
        /// the request is <c>"application/json"</c>, so don't use
        /// <c>"application/x-www-form-urlencoded"</c> if you want
        /// to use the <c>"properties"</c> request paramerer.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
