//
// Copyright (C) 2018-2019 Authlete, Inc.
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


using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for requests to an endpoint that exposes JSON Web
    /// Key Set document
    /// (<a href="https://tools.ietf.org/html/rfc7517">RFC 7517</a>).
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An OpenID Provider (OP) is required to expose its JSON Web
    /// Key Set document (JWK Set) so that client applications can
    /// (1) verify signatures by the OP and (2) encrypt their
    /// requests to the OP. The URI of a JWK Set endpoint can be
    /// found as the value of the <c>"jwks_uri"</c> metadata which
    /// is defined in
    /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">OpenID
    /// Provider Metadata</a>, if the OP supports
    /// <a href="https://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Connect Discovery 1.0</a>.
    /// </para>
    /// </remarks>
    public class JwksRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public JwksRequestHandler(IAuthleteApi api)
            : base(api)
        {
        }


        /// <summary>
        /// Handle a request to a JWK Set document endpoint.
        /// This method is an alias of <c>Handle(true)</c>.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the JWK
        /// Set document endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"></exception>
        public async Task<HttpResponseMessage> Handle()
        {
            return await Handle(true);
        }


        /// <summary>
        /// Handle a request to a JWK Set document endpoint. This
        /// method calls Authlete's <c>/api/service/jwks/get</c>
        /// API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the JWK
        /// Set document endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="pretty">
        /// <c>true</c> to format the JWK Set document in a more
        /// human-readable way.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"></exception>
        public async Task<HttpResponseMessage> Handle(bool pretty)
        {
            AuthleteApiException cause;

            try
            {
                // Call Authlete's /api/service/jwks/get API. The
                // API returns the JWK Set (RFC 7517) of the service.
                // The second argument given to GetServiceJwks() is
                // false not to include private keys.
                string jwks = await Api.GetServiceJwks(pretty, false);

                // If no JWK Set for the service is registered.
                if (string.IsNullOrEmpty(jwks))
                {
                    // 204 No Content.
                    return ResponseUtility.NoContent();
                }

                // 200 OK, application/json;charset=UTF-8
                return ResponseUtility.OkJson(jwks);
            }
            catch (AuthleteApiException e)
            {
                cause = e;
            }

            // If the HTTP status code of the response from the
            // Authlete API is not "302 Found".
            if (cause.StatusCode != HttpStatusCode.Found)
            {
                // Something wrong happened.
                throw cause;
            }

            // The value of the Location header of the response
            // from the Authlete API.
            Uri location = cause.ResponseHeaders.Location;

            // 302 Found with a Location header.
            return ResponseUtility.Location(location);
        }
    }
}
