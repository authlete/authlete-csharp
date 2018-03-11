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
    /// Authentication response from a service implementation to
    /// Authlete.
    /// </summary>
    public class AuthenticationCallbackResponse
    {
        /// <summary>
        /// The authentication result. <c>true</c> if the end-user
        /// was authenticated successfully. Otherwise, <c>false</c>.
        /// </summary>
        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the authenticated
        /// end-user.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the end-user was authenticated successfully, the
        /// subject (= unique identifier) of the end-user should be
        /// set to this property.
        /// </para>
        ///
        /// <para>
        /// The value of the <c>"subject"</c> does not always have
        /// to be equal to the value of the <c>"id"</c> in the
        /// authentication request. For example, <c>"id"</c> may be
        /// an email address but a service implementation may have
        /// generated and assigned a unique identifier such as
        /// <c>60504791</c> to the end-user who can be identified
        /// by the email address. In such a case, <c>60504791</c>
        /// should be set as this <c>Subject</c> property.
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
        /// Claims of the authenticated end-user in JSON format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// For example, to embed <c>"given_name"</c> claim,
        /// <c>"family_name"</c> claim and <c>"email"</c> claim,
        /// the string should be formatted like the following.
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
        /// Standard Claims</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">OpenID
        /// Connect Core 1.0</a> for further details about the
        /// format.
        /// </para>
        ///
        /// <para>
        /// This property does not have to be set (1) when the
        /// end-user was not authenticated, (2) when the
        /// authentication request does not contain any claims, or
        /// (3) when the service implementation cannot or does not
        /// want to provide data for any of the requested claims.
        /// </para>
        /// </remarks>
        [JsonProperty("claims")]
        public string Claims { get; set; }
    }
}
