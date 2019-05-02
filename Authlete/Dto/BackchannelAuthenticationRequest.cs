//
// Copyright (C) 2019 Authlete, Inc.
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
    /// Request to Authlete's <c>/api/backchannel/authentication</c>
    /// API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// When the implementation of the backchannel authentication
    /// endpoint of the authorization server receives a backchannel
    /// authentication request from a client application, the first
    /// step is to call Authlete's <c>/api/backchannel/authentication</c>
    /// API. The API will parse the backchannel authentication
    /// request on behalf of the implementation of the backchannel
    /// authentication endpoint.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationRequest
    {
        /// <summary>
        /// Backchannel authentication request parameters which the
        /// backchannel authentication endpoint of the authorization
        /// server implementation received from a client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of this property should be the entire request
        /// body (which is formatted in
        /// <c>application/x-www-form-urlencoded</c>) of the request
        /// from the client application.
        /// </para>
        /// </remarks>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }


        /// <summary>
        /// The client ID extracted from the <c>Authorization</c>
        /// header of a backchannel authentication request from a
        /// client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the backchannel authentication endpoint of the
        /// authorization server supports Basic Authentication as a
        /// means of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client ID in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set as the value of this
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }


        /// <summary>
        /// The client secret extracted from the <c>Authorization</c>
        /// header of the backchannel authentication request from
        /// the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the backchannel authentication endpoint of the
        /// authorization server supports Basic Authentication as a
        /// means of
        /// <a href="https://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client secret in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set as the value of this
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }


        /// <summary>
        /// The client certificate used in the TLS connection
        /// between the client application and the backchannel
        /// authentication endpoint of the authorization server.
        /// </summary>
        [JsonProperty("clientCertificate")]
        public string ClientCertificate { get; set; }


        /// <summary>
        /// The certificate path presented by the client during
        /// client authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Each element in the array is a certificate in PEM format.
        /// </para>
        /// </remarks>
        [JsonProperty("clientCertificatePath")]
        public string[] ClientCertificatePath { get; set; }
    }
}
