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
    /// Request to Authlete's <c>/api/auth/authorization</c> API.
    /// An authorization endpoint implementation is supposed to
    /// pass all the request parameters it received from a client
    /// application to the API.
    /// </summary>
    public class AuthorizationRequest
    {
        /// <summary>
        /// Request parameters that the implementation of your
        /// authorization endpoint received from a client
        /// application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of this <c>Parameters</c> property should be
        /// either (1) the entire query string when the HTTP method
        /// of the authorization request from the client application
        /// was <c>GET</c> or (2) the entire entity body (which is
        /// formatted in <c>application/x-www-form-urlencoded</c>)
        /// when the HTTP method of the authorization request from
        /// the client application was <c>POST</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }
    }
}
