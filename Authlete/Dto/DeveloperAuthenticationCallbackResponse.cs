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
    /// Developer authentication response from a service
    /// implementation to Authlete.
    /// </summary>
    public class DeveloperAuthenticationCallbackResponse
    {
        /// <summary>
        /// The result of developer authentication. When the pair
        /// of <c>"id"</c> and <c>"password"</c> contained in the
        /// developer authentication request are valid, <c>true</c>
        /// should be set to this property. Otherwise, if developer
        /// authentication failed, <c>false</c> should be set.
        /// </summary>
        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the authenticated
        /// developer.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of the <c>"subject"</c> does not always have
        /// to be equal to the value of the <c>"id"</c> in the
        /// authentication request. For example, <c>"id"</c> may be
        /// an email address but a service implementation may have
        /// generated and assigned a unique identifier such as
        /// <c>60504791</c> to the end-user who can be identified
        /// by the email address. In such a case, <c>60504791</c>
        /// should be set as <c>subject</c>.
        /// </para>
        ///
        /// <para>
        /// This property does not have to be set when the
        /// <c>Authenticated</c> property is <c>false</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The display name of the authenticated developer.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property does not have to be set when the
        /// <c>Authenticated</c> property is <c>false</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
