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
    /// Response from Authlete's <c>/api/auth/token/update</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/token/update</c> API returns JSON
    /// which can be mapped to this class. The first step that a
    /// caller should take is to retrieve the value of the
    /// <c>"action"</c> response parameter (which can be obtained
    /// via the <c>Action</c> property) from the response.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenUpdateAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that an error occurred on Authlete side.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenUpdateAction.BAD_REQUEST</c>, it means that the
    /// request from the caller was wrong. For example, this
    /// happens when the <c>"accessToken"</c> request parameter is
    /// missing.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenUpdateAction.FORBIDDEN</c>, it means that the
    /// request from the caller was not allowed. For example, this
    /// happens when the access token identified by the
    /// <c>accessToken</c> request parameter does not belong to the
    /// service identified by the API key used for the API call.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenUpdateAction.NOT_FOUND</c>, it means that the
    /// specified access token does not exist.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenUpdateAction.OK</c>, it means that the access token
    /// was updated successfully.
    /// </para>
    /// </remarks>
    public class TokenUpdateResponse : ApiResponse
    {
        /// <summary>
        /// The code which indicates how the response should be
        /// interpreted.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenUpdateAction Action { get; set; }


        /// <summary>
        /// The access token which was specified by the
        /// <c>"accessToken"</c> request parameter of the API call.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The date at which the access token will expire. The
        /// value is expressed in milliseconds since the Unix epoch
        /// (1970-Jan-1).
        /// </summary>
        [JsonProperty("accessTokenExpiresAt")]
        public long AccessTokenExpiresAt { get; set; }


        /// <summary>
        /// The scopes associated with the access token.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The properties associated with the access token.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
