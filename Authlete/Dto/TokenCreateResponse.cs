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


using Authlete.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/auth/token/create</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/token/create</c> API returns JSON
    /// which can be mapped to this class. The first step that a
    /// caller should take is to retrieve the value of the
    /// <c>"action"</c> response parameter (which can be obtained
    /// via the <c>Action</c> property of this class) from the
    /// response.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenCreateAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that an error occurred on Authlete side.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenCreateAction.BAD_REQUEST</c>, it means that the
    /// request from the caller was wrong. For example, this
    /// happens when the <c>"grantType"</c> request parameter is
    /// missing.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenCreateAction.FORBIDDEN</c>, it means that the
    /// request from the caller is not allowed. For example, this
    /// happens when the client application identified by the
    /// <c>"clientId"</c> request parameter does not belong to the
    /// service identified by the API key used for the API call.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>TokenCreateAction.OK</c>, it means that everything was
    /// processed successfully and an access token and optionally
    /// a refresh token were issued. So, in short, when the value
    /// of the <c>Action</c> property is <c>TokenCreateAction.OK</c>,
    /// you can retrieve the values of a new access token and an
    /// optional refresh token from the <c>AccessToken</c> property
    /// and the <c>RefreshToken</c> property.
    /// </para>
    /// </remarks>
    public class TokenCreateResponse : ApiResponse
    {
        /// <summary>
        /// The code which indicates how the response from
        /// Authlete's <c>/api/auth/token/create</c> API should be
        /// interpreted.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenCreateAction Action { get; set; }


        /// <summary>
        /// The grant type emulated for the newly issued access
        /// token.
        /// </summary>
        [JsonProperty("grantType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GrantType GrantType { get; set; }


        /// <summary>
        /// The client ID associated with the newly issued access
        /// token.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the user
        /// associated with the newly issued access token. This
        /// property is <c>null</c> when the grant type is
        /// <c>GrantType.CLIENT_CREDENTIALS</c>.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The scopes associated with the newly issued access
        /// token.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The value of the newly issued access token.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The token type of the newly issued access token.
        /// For example, <c>"Bearer"</c>.
        /// </summary>
        [JsonProperty("tokenType")]
        public string TokenType { get; set; }


        /// <summary>
        /// The duration of the newly issued access token in
        /// seconds.
        /// </summary>
        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }


        /// <summary>
        /// The date at which the newly issued access token will
        /// expire. The value is expressed in milliseconds since
        /// the Unix epoch (1970-Jan-1).
        /// </summary>
        [JsonProperty("expiresAt")]
        public long ExpiresAt { get; set; }


        /// <summary>
        /// The value of the newly issued refresh token. This
        /// property is <c>null</c> when the grant type is either
        /// <c>GrantType.IMPLICIT</c> or
        /// <c>GrantType.CLIENT_CREDENTIALS</c>.
        /// </summary>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The properties associated with the newly issued access
        /// token.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
