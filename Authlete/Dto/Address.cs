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
    /// Address claim that represents a physical mailing address.
    /// See
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AddressClaim">5.1.1.
    /// Address Claim</a> in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for details.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The full mailing address, formatted for display or use
        /// on a mailing label.
        /// </summary>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }


        /// <summary>
        /// The full street address component, which MAY include
        /// house number, street name, Post Office Box, and
        /// multi-line extended street address information.
        /// </summary>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }


        /// <summary>
        /// The city or locality component.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }


        /// <summary>
        /// The state, province, prefecture, or region component.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }


        /// <summary>
        /// The zip code or postal code component.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }


        /// <summary>
        /// The country name component.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
