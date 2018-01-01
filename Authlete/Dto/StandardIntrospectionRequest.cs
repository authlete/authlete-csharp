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
    /// Request to Authlete's
    /// <c>/api/auth/introspection/standard</c> API.
    /// </summary>
    public class StandardIntrospectionRequest
    {
        /// <summary>
        /// Request parameters which comply with the introspection
        /// request defined in
        /// <a href="https://tools.ietf.org/html/rfc7662#section-2.1">2.1.
        /// Introspection Request</a> of
        /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The following is an example value for this
        /// <c>Parameters</c> property.
        /// </para>
        ///
        /// <code>
        /// token=pNj1h24a4geA_YHilxrshkRkxJDsyXBZWKp3hZ5ND7A&amp;token_type_hint=access_token
        /// </code>
        ///
        /// <para>
        /// The implementation of the introspection endpoint of
        /// your authorization server will receive an HTTP POST
        /// request with parameters in the
        /// <c>application/x-www-form-urlencoded</c> format. It is
        /// the entity body of the request that Authlete's
        /// <c>/api/auth/introspection/standard</c> API expects as
        /// the value of the <c>"parameters"</c> request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }
    }
}
