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
    /// Request to Authlete's <c>/api/auth/token/update</c> API.
    /// </summary>
    public class TokenUpdateRequest
    {
        /// <summary>
        /// An access token to be updated.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// A new date at which the acces token will expire. The
        /// value needs to be expressed in milliseconds since the
        /// Unix epoch (1970-Jan-1). If <c>0</c> or a negative
        /// value is given, the expiration date of the access token
        /// is not changed.
        /// </summary>
        [JsonProperty("accessTokenExpiresAt")]
        public long AccessTokenExpiresAt { get; set; }


        /// <summary>
        /// A new set of scopes assigned to the access token. If
        /// <c>null</c> is given, the scope set associated with
        /// the access token is not changed.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// A new set of properties assigned to the access token.
        /// If <c>null</c> is given, the property set associated
        /// with the access token is not changed.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
