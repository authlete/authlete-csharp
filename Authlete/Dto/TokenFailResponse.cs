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
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/auth/token/fail</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/token/fail</c> API returns JSON
    /// which can be mapped to this class. The authorization server
    /// implementation should retrieve the value of the
    /// <c>"action"</c> parameter (which can be obtained via the
    /// <c>Action</c> property of this class) from the response and
    /// the take the following steps according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenFailAction.INTERNAL_SERVER_ERROR</c>, it means that
    /// the request from the authorization server
    /// (<c>AuthorizationFailRequest</c>) was wrong or that an
    /// error occurred in Authlete. In either case, from a
    /// viewpoint of the client application, it is an error on the
    /// server side. Therefore, the authorization server
    /// implementation should generate a response to the client
    /// application with the HTTP status of <c>"500 Internal Server
    /// Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// JSON string which describes the error, so it can be used as
    /// the entity body of the response. The following illustrates
    /// the response which the authorization server implementation
    /// should generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenFailAction.BAD_REQUEST</c>, it means that
    /// Authlete's <c>/api/auth/token/fail</c> API successfully
    /// generated an error response for the client application.
    /// The HTTP status of the response returned to the client
    /// application must be <c>"400 Bad Request"</c> and the
    /// content type must be <c>"application/json"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns a
    /// JSON string which describes the error, so it can be used as
    /// the entity body of the response. The following illustrates
    /// the response which the authorization server implementation
    /// should generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    /// </remarks>
    public class TokenFailResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the token endpoint implementation
        /// should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenFailAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }
    }
}
