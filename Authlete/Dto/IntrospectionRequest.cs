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
    /// Request to Authlete's <c>/api/auth/introspection</c> API.
    /// The API returns information about an access token.
    /// </summary>
    public class IntrospectionRequest
    {
        /// <summary>
        /// An access token.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }


        /// <summary>
        /// Scopes which are required to access the protected
        /// resource endpoint of the resource server. If the array
        /// contains one or more scopes which are not covered by
        /// the access token, Authlete's
        /// <c>/api/auth/introspection</c> API returns
        /// <c>IntrospectionAction.FORBIDDEN</c> as the
        /// <c>"action"</c> and sets <c>"insufficient_scope"</c>
        /// as the error code. If this property holds <c>null</c>,
        /// Authlete's <c>/api/auth/introspection</c> API does not
        /// check scopes of the access token.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of an end-user which
        /// is required to access the protected resource endpoint
        /// of the resource server. If the specified subject is
        /// different from the one associated with the access token,
        /// Authlete's <c>/api/auth/introspection</c> API returns
        /// <c>IntrospectionAction.FORBIDDEN</c> as the
        /// <c>"action"</c> and sets <c>"invalid_request"</c> as
        /// the error code.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}