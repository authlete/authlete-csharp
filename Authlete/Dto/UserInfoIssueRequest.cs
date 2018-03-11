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
    /// Request to Authlete's <c>/api/auth/userinfo/issue</c> API.
    /// </summary>
    public class UserInfoIssueRequest
    {
        /// <summary>
        /// The access token contained in the
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfoRequest">userinfo
        /// request</a> from the client application to the userinfo
        /// endpoint.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }


        /// <summary>
        /// Claims of the subject in JSON format. This request
        /// parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The implementation of your service is required to
        /// retrieve claims of the subject (= information about
        /// the end-user) from its database and format them into
        /// JSON.
        /// </para>
        ///
        /// <para>
        /// For example, if <c>"given_name"</c> claim,
        /// <c>"family_name"</c> claim and <c>"email"</c> claim
        /// are requested, the implementation should generate a
        /// JSON object like the following, and then set its string
        /// representation to this <c>Claims</c> property.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "given_name": "Takahiko",
        ///   "family_name": "Kawasaki",
        ///   "email": "takahiko.kawasaki@example.com"
        /// }
        /// </code>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
        /// Standard Claims</a>" of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for further details about the
        /// format.
        /// </para>
        /// </remarks>
        [JsonProperty("claims")]
        public string Claims { get; set; }


        /// <summary>
        /// The value of the <c>"sub"</c> claim. This request
        /// parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this property holds a non-empty value, it is used as
        /// the value of the <c>"sub"</c> claim. Otherwise, the
        /// value of the subject associated with the access token
        /// is used.
        /// </para>
        /// </remarks>
        [JsonProperty("sub")]
        public string Sub { get; set; }
    }
}
