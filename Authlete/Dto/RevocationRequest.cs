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
    /// Request to Authlete's <c>/api/auth/revocation</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The entity body of a revocation request may contain a pair
    /// of client ID and client secret (<c>client_id</c> and
    /// <c>client_secret</c>) along with other request parameters
    /// as described in
    /// <a href="https://tools.ietf.org/html/rfc6749#section-2.3.1">2.3.1.
    /// Client Password</a> of
    /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
    /// If the client credentials are contained in both the
    /// <c>Authorization</c> header and the entity body, they must
    /// be identical. Otherwise, Authlete's <c>/api/auth/revocation</c>
    /// API generates an error (it's not a service error but a
    /// client error).
    /// </para>
    ///
    /// <para>
    /// When the presented token is an access token, Authlete
    /// revokes the access token and its associated refresh token,
    /// too. Likewise, if the presented token is a refresh token,
    /// Authlete revokes the refresh token and its associated
    /// access token. Note that, however, other access tokens and
    /// refresh tokens are not revoked even though their associated
    /// client application, subject and grant type are equal to
    /// those of the token to be revoked.
    /// </para>
    /// </remarks>
    public class RevocationRequest
    {
        /// <summary>
        /// Request parameters that the revocation endpoint
        /// (<a href="https://tools.ietf.org/html/rfc7009">RFC
        /// 7009</a>) of the authorization server received from a
        /// client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of the <c>"parameters"</c> request parameter
        /// is the entire entity body (which is formatted in
        /// <c>application/x-www-form-urlencoded</c>) of the
        /// request from the client application.
        /// </para>
        /// </remarks>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }


        /// <summary>
        /// The client ID extracted from the <c>Authorization</c>
        /// header of the revocation request from the client
        /// application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the revocation endpoint of the authorization server
        /// supports Basic Authentication as a means of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client ID in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set to this property.
        /// </para>
        /// </remarks>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }


        /// <summary>
        /// The client secret extracted from the <c>Authorization</c>
        /// header of the revocation request from the client
        /// application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the revocation endpoint of the authorization server
        /// supports Basic Authentication as a means of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client secret in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set to this property.
        /// </para>
        /// </remarks>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }
    }
}
