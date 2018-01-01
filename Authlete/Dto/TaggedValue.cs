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
    /// A string value with a
    /// <a href="http://en.wikipedia.org/wiki/IETF_language_tag">language
    /// tag</a>.
    /// </summary>
    public class TaggedValue
    {
        /// <summary>
        /// The default constructor. This is an alias of
        /// <c>TaggedValue(null, null)</c>.
        /// </summary>
        public TaggedValue() : this(null, null)
        {
        }


        /// <summary>
        /// A constructor with a pair of language tag and value.
        /// </summary>
        ///
        /// <param name="tag">
        /// A <a href="http://en.wikipedia.org/wiki/IETF_language_tag">language
        /// tag</a>
        /// </param>
        ///
        /// <param name="value">
        /// An arbitrary value.
        /// </param>
        public TaggedValue(string tag, string value)
        {
            Tag   = tag;
            Value = value;
        }


        /// <summary>
        /// <a href="http://en.wikipedia.org/wiki/IETF_language_tag">Language
        /// tag</a>.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }


        /// <summary>
        /// A value.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
