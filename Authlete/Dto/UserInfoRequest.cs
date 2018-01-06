﻿//
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
    /// Request to Authlete's <c>/api/auth/userinfo</c> API.
    /// </summary>
    public class UserInfoRequest
    {
        /// <summary>
        /// The access token that the
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation received from the client
        /// application.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}