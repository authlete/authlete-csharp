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
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's <c>/api/auth/authorization/fail</c>
    /// API. An authorization endpoint implementation is supposed
    /// to call the API to generate an error response to a client
    /// application.
    /// </summary>
    public class AuthorizationFailRequest
    {
        /// <summary>
        /// The ticket issued by Authlete's
        /// <c>/api/auth/authorization</c> API. The ticket is
        /// necessary to call Authlete's
        /// <c>/api/auth/authorization/fail</c> API. This request
        /// parameter is mandatory.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The reason of the failure of the authorization request.
        /// This request parameter is mandatory.
        /// </summary>
        [JsonProperty("reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthorizationFailReason Reason { get; set; }


        /// <summary>
        /// The custom description about the authorization failure.
        /// This request parameter is optional.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
