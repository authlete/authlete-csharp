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
    /// Developer authentication request from Authlete to a service
    /// implementation.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// When a client application developer needs to be
    /// authenticated at the Client Application Developer Console
    /// (which Authlete provides for client application developers
    /// on behalf of the service), Authlete makes a <i>developer
    /// authentication request</i> to the developer authentication
    /// callback endpoint of the service. This class represents the
    /// format of the request.
    /// </para>
    ///
    /// <para>
    /// The <c>"id"</c> and <c>"password"</c> parameters in this
    /// authentication request are the values that the developer
    /// input to the input fields of the login form of the
    /// Developer Console.
    /// </para>
    /// </remarks>
    public class DeveloperAuthenticationCallbackRequest
    {
        /// <summary>
        /// The API key of the target service.
        /// </summary>
        [JsonProperty("serviceApiKey")]
        public long ServiceApiKey { get; set; }


        /// <summary>
        /// The login ID that the developer input to the login ID
        /// field of the login form of the Developer Console.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }


        /// <summary>
        /// The password that the developer input to the password
        /// field of the login form of the Developer Console.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
