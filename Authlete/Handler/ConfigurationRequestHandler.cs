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


using System.Net.Http;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for requests to a configuration endpoint.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An OpenID Provider that supports
    /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Connect Discovery 1.0</a> provides an endpoint that returns
    /// its configuration information in JSON format. Details about
    /// the format are described in
    /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
    /// OpenID Provider Metadata</a> of
    /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Connect Discovery 1.0</a>.
    /// </para>
    ///
    /// <para>
    /// Note that the URI of an OpenID Provider configuration
    /// endpoint is defined in
    /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html#ProviderConfigurationRequest">4.1.
    /// OpenID Provider Configuration Request</a>. In short, the
    /// URI must be:
    /// </para>
    ///
    /// <code>
    /// {Issuer-Identifier}/.well-known/openid-configuration
    /// </code>
    ///
    /// <para>
    /// <c>{Issuer-Identifier}</c> is a URL to identify an OpenID
    /// Provider. For example, <c>https://example.com</c>. For
    /// details about Issuer Identifier, see the description about
    /// the <c>"issuer"</c> metadata defined in
    /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html#ProviderMetadata">3.
    /// OpenID Provider Metadata</a>
    /// (<a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
    /// Conect Discovery 1.0</a>) and the <c>"iss"</c> claim in
    /// (<a href="http://openid.net/specs/openid-connect-core-1_0.html#IDToken">2.
    /// ID Token</a>
    /// (<a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>).
    /// </para>
    ///
    /// <para>
    /// You can change the Issuer Identifier of your service by
    /// using the management console
    /// (<a href="https://www.authlete.com/documents/so_console">Service
    /// Owner Console</a>). Note that the default value of Issuer
    /// Identifier is not appropriate for production use, so you
    /// should change it.
    /// </para>
    /// </remarks>
    public class ConfigurationRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public ConfigurationRequestHandler(IAuthleteApi api)
            : base(api)
        {
        }


        /// <summary>
        /// Handle a request to a configuration endpoint. This
        /// method is an alias of <c>Handle(true)</c>.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// configuration endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle()
        {
            return await Handle(true);
        }


        /// <summary>
        /// Handle a request to a configuration endpoint. This
        /// method calls Authlete's <c>/api/service/configuration</c>
        /// API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// configuration endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="pretty">
        /// <c>true</c> to format the output JSON in a more
        /// human-readable way.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        public async Task<HttpResponseMessage> Handle(bool pretty)
        {
            // Call Authlete's /api/service/configuration API.
            // The API returns a JSON that complies with OpenID
            // Connect Discovery 1.0.
            string json = await Api.GetServiceConfiguration(pretty);

            // 200 OK, application/json;charset=UTF-8
            return ResponseUtility.OkJson(json);
        }
    }
}
