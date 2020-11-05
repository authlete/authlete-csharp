//
// Copyright (C) 2020 Authlete, Inc.
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
    /// Request to Authlete's <c>/api/pushed_auth_req</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The authorization server can implement a pushed authorization request
    /// endpoint which is defined in "OAuth 2.0 Pushed Authorization Requests"
    /// by using the Authlete API.
    /// </para>
    ///
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public class PushedAuthReqRequest
    {
        /// <summary>
        /// Request parameters that the pushed authorization request endpoint
        /// received from the client application.
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }


        /// <summary>
        /// The client ID extracted from the <c>Authorization</c> header of
        /// the request to the pushed authorization request endpoint.
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }


        /// <summary>
        /// The client secret extracted from the <c>Authorization</c> header of
        /// the request to the pushed authorization request endpoint.
        /// </summary>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }


        /// <summary>
        /// The client certificate used in the TLS connection between the client
        /// application and the pushed authorization request endpoint.
        /// </summary>
        [JsonProperty("clientCertificate")]
        public string ClientCertificate { get; set; }


        /// <summary>
        /// The certificate path presented by the client during client
        /// authentication.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Each element is a string in PEM format.
        /// </para>
        /// </remarks>
        [JsonProperty("clientCertificatePath")]
        public string[] ClientCertificatePath { get; set; }
    }
}
