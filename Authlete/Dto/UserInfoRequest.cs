//
// Copyright (C) 2018-2020 Authlete, Inc.
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
    /// Request to Authlete's <c>/api/auth/userinfo</c> API.
    /// </summary>
    public class UserInfoRequest
    {
        /// <summary>
        /// The access token that the
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation received from the client
        /// application.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }


        /// <summary>
        /// The client certificate used in the TLS connection
        /// established between the client application and the
        /// userinfo endpoint in PEM format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of this request parameter is referred to when
        /// the access token given to the userinfo endpoint was
        /// bound to a client certificate when it was issued. See
        /// <a href="https://datatracker.ietf.org/doc/draft-ietf-oauth-mtls/?include_text=1">OAuth
        /// 2.0 Mutual TLS Client Authentication and
        /// Certificate-Bound Access Tokens</a> for details about
        /// the specification of certificate-bound access tokens.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("clientCertificate")]
        public string ClientCertificate { get; set; }


        /// <summary>
        /// The <c>DPoP</c> header presented by the client during the request
        /// to the userinfo endpoint. The header contains a signed JWT which
        /// includes the public key that is paired with the private key used to
        /// sign the JWT.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See "OAuth 2.0 Demonstration of Proof-of-Possession at the
        /// Application Layer (DPoP)" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("dpop")]
        public string Dpop { get; set; }


        /// <summary>
        /// The HTTP method of the userinfo request. This property is used to
        /// validate the <c>DPoP</c> header.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// In normal cases, the value is either <c>GET</c> or <c>POST</c>.
        /// </para>
        ///
        /// <para>
        /// See "OAuth 2.0 Demonstration of Proof-of-Possession at the
        /// Application Layer (DPoP)" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("htm")]
        public string Htm { get; set; }


        /// <summary>
        /// The URL of the userinfo endpoint. This property is used to validate
        /// the <c>DPoP</c> header.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this parameter is omitted, the <c>userInfoEndpoint</c> property
        /// of the <c>Service</c> is used as the default value.
        /// </para>
        ///
        /// <para>
        /// See "OAuth 2.0 Demonstration of Proof-of-Possession at the
        /// Application Layer (DPoP)" for details.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("htu")]
        public string Htu { get; set; }
    }
}
