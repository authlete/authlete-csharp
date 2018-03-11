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
    /// A pair of a string key and a string value.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.0.8.
    /// </para>
    /// </remarks>
    public class Pair
    {
        /// <summary>
        /// The default constructor. This is an alias of
        /// <c>Pair(null, null)</c>.
        /// </summary>
        public Pair()
            : this(null, null)
        {
        }


        /// <summary>
        /// Constructor with a pair of key and value.
        /// </summary>
        ///
        /// <param name="key">
        /// The key.
        /// </param>
        ///
        /// <param name="value">
        /// The value.
        /// </param>
        public Pair(string key, string value)
        {
            Key   = key;
            Value = value;
        }


        /// <summary>
        /// The name.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }


        /// <summary>
        /// The value.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
