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
    /// Request to Authlete's <c>/api/client/secret/update</c> API.
    /// The API replaces the client secret with the specified value.
    /// </summary>
    public class ClientSecretUpdateRequest
    {
        /// <summary>
        /// A value of the new client secret.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Valid characters for a client secret are <c>A-Z</c>,
        /// <c>a-z</c>, <c>0-9</c>, <c>-</c>, and <c>_</c>.
        /// The maximum length of a client secret is 86.
        /// </para>
        /// </remarks>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }
    }
}
