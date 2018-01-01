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
    /// Extended information about a client application.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// There are some attributes that belong to a client
    /// application but should not be changed by the developer of
    /// the client application. This class holds such attributes.
    /// </para>
    ///
    /// <para>
    /// For example, an authorization server may narrow the range
    /// of scopes (permissions) that a particular client
    /// application can request. In this case, it is meaningless if
    /// the developer of the client application can freely decide
    /// the set of requestable scopes. It is not the developer of
    /// the client application but the administrator of the
    /// authorization server that should be allowed to define the
    /// set of scopes that the client application can request.
    /// </para>
    /// </remarks>
    public class ClientExtension
    {
        /// <summary>
        /// The flag which indicates whether <i>"Requestable Scopes
        /// per Client"</i> feature is enabled or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this property returns <c>true</c>, a special set of
        /// scopes (permissions) is defined on the server side (the
        /// <c>RequestableScopes</c> represents the special set)
        /// and scopes which the client application can request are
        /// limited to the scopes listed in the set. In other words,
        /// the application cannot request scopes that are not
        /// included in the special set. To be specific, the client
        /// application cannot list other scopes in the <c>scope</c>
        /// request parameter when it makes an authorization
        /// request. To be exact, other scopes can be listed but
        /// will be ignored by the authorization server.
        /// </para>
        ///
        /// <para>
        /// On the other hand, if this property returns <c>false</c>,
        /// the valid set of scopes (permissions) that the client
        /// application can request is equal to the whole scope set
        /// defined by the authorization server.
        /// </para>
        /// </remarks>
        [JsonProperty("requestableScopesEnabled")]
        public bool IsRequestableScopesEnabled { get; set; }


        /// <summary>
        /// The set of scopes that the client application can
        /// request when <i>"Requestable Scopes per Client"</i>
        /// feature is enabled (= when the
        /// <c>IsRequestableScopesEnabled</c> property returns
        /// <c>true</c>.
        /// </summary>
        [JsonProperty("requestableScopes")]
        public string[] RequestableScopes { get; set; }
    }
}
