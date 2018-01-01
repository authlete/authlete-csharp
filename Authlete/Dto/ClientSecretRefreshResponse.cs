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
    /// Response from Authlete's <c>/api/client/secret/refresh</c>
    /// API.
    /// </summary>
    public class ClientSecretRefreshResponse : ApiResponse
    {
        /// <summary>
        /// The new client secret.
        /// </summary>
        [JsonProperty("newClientSecret")]
        public string NewClientSecret { get; set; }


        /// <summary>
        /// The old client secret.
        /// </summary>
        [JsonProperty("oldClientSecret")]
        public string OldClientSecret { get; set; }
    }
}
