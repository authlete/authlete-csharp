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
    /// Request to Authlete's
    /// <c>/api/client/authorization/update/{clientId}</c> API.
    /// The API updates attributes of all existing access tokens
    /// issued to a client application by an end-user.
    /// </summary>
    public class ClientAuthorizationUpdateRequest
    {
        /// <summary>
        /// The subject (= unique identifier) of an end-user.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// A new set of scopes assigned to existing access tokens.
        /// If <c>null</c> is given, the scope set associated with
        /// existing access tokens will not be changed.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }
    }
}
