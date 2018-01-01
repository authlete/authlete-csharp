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


using Authlete.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Sns credentials.
    /// </summary>
    public class SnsCredentials
    {
        /// <summary>
        /// The identifier of the SNS.
        /// </summary>
        [JsonProperty("sns", ItemConverterType = typeof(StringEnumConverter))]
        public Sns Sns { get; set; }


        /// <summary>
        /// The API key assigned by the SNS.
        /// </summary>
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }


        /// <summary>
        /// The API secret assigned by the SNS.
        /// </summary>
        [JsonProperty("apiSecret")]
        public string ApiSecret { get; set; }
    }
}
