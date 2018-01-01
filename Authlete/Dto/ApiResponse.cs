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
    /// The base class for classes that represent responses from
    /// Authlete APIs.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// The code of the result of an Authlete API call.
        /// For example, <c>"A004001"</c>.
        /// </summary>
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }


        /// <summary>
        /// The message of the result of an Authlete API call.
        /// For example, <i>"[A001202] /client/get/list,
        /// Authorization header is missing."</i>
        /// </summary>
        [JsonProperty("resultMessage")]
        public string ResultMessage { get; set; }
    }
}
