//
// Copyright (C) 2024 Authlete, Inc.
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


namespace Authlete.Conf
{
    /// <summary>
    /// Configuration to access Authlete APIs.
    /// </summary>
    public interface IAuthleteConfiguration
    {
        /// <summary>
        /// The base URL of an Authlete server.
        /// </summary>
        string BaseUrl { get; }


        /// <summary>
        /// The API key of a service owner.
        /// </summary>
        string ServiceOwnerApiKey { get; }


        /// <summary>
        /// The API secret of a service owner.
        /// </summary>
        string ServiceOwnerApiSecret { get; }


        /// <summary>
        /// The access token for service owner APIs.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        string ServiceOwnerAccessToken { get; }


        /// <summary>
        /// The API key of a service.
        /// </summary>
        string ServiceApiKey { get; }


        /// <summary>
        /// Gets the service API secret.
        /// </summary>
        string ServiceApiSecret { get; }


        /// <summary>
        /// The access token for service APIs.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        string ServiceAccessToken { get; }
        
        
        /// <summary>
        /// Get the Authlete API version.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.7.0.
        /// </para>
        /// </remarks>
        string ApiVersion { get; }
        
        
        /// <summary>
        /// Get the public/private key pair used for DPoP signatures in JWK format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.7.0.
        /// </para>
        /// </remarks>
        string DpopKey { get; }
        
        
        /// <summary>
        /// Get the certificate used for MTLS bound access tokens in PEM format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.7.0.
        /// </para>
        /// </remarks>
        string ClientCertificate { get; }
    }
}
