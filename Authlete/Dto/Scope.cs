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
    /// Information about a scope
    /// (<a href="https://tools.ietf.org/html/rfc6749#section-3.3">3.3.
    /// Access Token Scope</a>).
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// The scope name. Valid characters for scope names are
        /// listed in
        /// <a href="https://tools.ietf.org/html/rfc6749#section-3.3">3.3.
        /// Access Token Scope</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// The flag which indicates whether this scope is included
        /// in the default scope set.
        /// </summary>
        [JsonProperty("defaultEntry")]
        public bool IsDefault { get; set; }


        /// <summary>
        /// The description of this scope.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// Localized descriptions of this scope.
        /// </summary>
        [JsonProperty("descriptions")]
        public TaggedValue[] Descriptions { get; set; }
    }
}
