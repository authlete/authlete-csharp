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


using System.Collections.Generic;
using System.IO;
using Authlete.Util;


namespace Authlete.Conf
{
    /// <summary>
    /// An implementation of the <c>IAuthleteConfiguration</c>
    /// interface that refers to a <c>properties</c> file whose
    /// content complies with the format defined in the
    /// <a href="https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-">JavaDoc</a>
    /// of <c>java.util.Properties.load(java.io.Reader)</c>.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// This is a utility class to load a configuration file that
    /// includes properties related to Authlete. Below is the list
    /// of configuration properties.
    /// </para>
    ///
    /// <list type="bullet">
    /// <item>
    /// <term><c>base_url</c></term>
    /// <description>
    /// The base URL of an Authlete server. The default value is
    /// <c>https://api.authlete.com</c>.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service_owner.api_key</c></term>
    /// <description>
    /// The API key of a service owner.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service_owner.api_secret</c></term>
    /// <description>
    /// The API secret of a service owner.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service_owner.access_token</c></term>
    /// <description>
    /// The access token for service owner APIs.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service.api_key</c></term>
    /// <description>
    /// The API key of a service.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service.api_secret</c></term>
    /// <description>
    /// The API secret of a service.
    /// </description>
    /// </item>
    ///
    /// <item>
    /// <term><c>service.access_token</c></term>
    /// <description>
    /// The access token for service APIs.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public class AuthletePropertiesConfiguration : IAuthleteConfiguration
    {
        /// <summary>
        /// The default value of the name of the configuration file
        /// (<c>"authlete.properties"</c>).
        /// </summary>
        public const string DEFAULT_FILE = "authlete.properties";

        /// <summary>
        /// The name of the environment variable to specify the
        /// configuration file.
        /// </summary>
        public const string ENV_CONFIG_FILE = "AUTHLETE_CONFIGURATION_FILE";

        const string KEY_BASE_URL                   = "base_url";
        const string KEY_SERVICE_OWNER_API_KEY      = "service_owner.api_key";
        const string KEY_SERVICE_OWNER_API_SECRET   = "service_owner.api_secret";
        const string KEY_SERVICE_OWNER_ACCESS_TOKEN = "service_owner.access_token";
        const string KEY_SERVICE_API_KEY            = "service.api_key";
        const string KEY_SERVICE_API_SECRET         = "service.api_secret";
        const string KEY_SERVICE_ACCESS_TOKEN       = "service.access_token";
        const string KEY_DPOP_KEY                   = "service.dpop_key";
        const string KEY_CLIENT_CERTIFICATE         = "service.client_certificate";
        const string KEY_API_VERSION                = "api_version";
        const string BASE_URL_DEFAULT               = "https://api.authlete.com";
        


        /// <summary>
        /// The default constructor. This constructor tries to read
        /// a configuration file. If the environment variable,
        /// <c>AUTHLETE_CONFIGURATION_FILE</c>, is defined and
        /// holds a non-null value, the value is used as the name
        /// of the configuration file. Otherwise (= if the
        /// environment variable is not defined or its value is
        /// empty), this constructor tries to read a file named
        /// <c>"authlete.properties"</c>.
        /// </summary>
        public AuthletePropertiesConfiguration()
            : this(GetConfigFileName())
        {
        }


        /// <summary>
        /// Constructor with the name of a configuration file.
        /// </summary>
        ///
        /// <param name="file">
        /// The name of a configuration file.
        /// </param>
        public AuthletePropertiesConfiguration(string file)
        {
            using (TextReader reader = File.OpenText(file))
            {
                Load(reader);
            }
        }


        /// <summary>
        /// Constructor with the stream of a configuration file.
        /// </summary>
        ///
        /// <param name="reader">
        /// The stream of a configuration file.
        /// </param>
        public AuthletePropertiesConfiguration(TextReader reader)
        {
            Load(reader);
        }


        /// <summary>
        /// Get the name of a configuration file.
        /// </summary>
        static string GetConfigFileName()
        {
            // Get the file name specified by the environment variable.
            string file =
                System.Environment.GetEnvironmentVariable(ENV_CONFIG_FILE);

            // If the environment variable holds a non-null value.
            if (string.IsNullOrEmpty(file) == false)
            {
                // Use the value as a file name.
                return file;
            }

            // Use the default file.
            return DEFAULT_FILE;
        }


        /// <summary>
        /// Parse the content of the reader and set up parameters
        /// to access Authlete APIs.
        /// </summary>
        void Load(TextReader reader)
        {
            // Parse the content of the reader.
            IDictionary<string, string> props =
                PropertiesLoader.Load(reader);

            // Set up parameters to access Authlete APIs.
            BaseUrl                 = props[KEY_BASE_URL];
            ServiceOwnerApiKey      = props[KEY_SERVICE_OWNER_API_KEY];
            ServiceOwnerApiSecret   = props[KEY_SERVICE_OWNER_API_SECRET];
            ServiceOwnerAccessToken = props[KEY_SERVICE_OWNER_ACCESS_TOKEN];
            ServiceApiKey           = props[KEY_SERVICE_API_KEY];
            ServiceApiSecret        = props[KEY_SERVICE_API_SECRET];
            ServiceAccessToken      = props[KEY_SERVICE_ACCESS_TOKEN];
            DpopKey                 = props[KEY_DPOP_KEY];
            ApiVersion              = props[KEY_API_VERSION];
            ClientCertificate       = props[KEY_CLIENT_CERTIFICATE];
        }


        /// <inheritdoc/>
        public string BaseUrl { get; private set; }


        /// <inheritdoc/>
        public string ServiceOwnerApiKey { get; private set; }


        /// <inheritdoc/>
        public string ServiceOwnerApiSecret { get; private set; }


        /// <inheritdoc/>
        public string ServiceOwnerAccessToken { get; private set; }


        /// <inheritdoc/>
        public string ServiceApiKey { get; private set; }


        /// <inheritdoc/>
        public string ServiceApiSecret { get; private set; }


        /// <inheritdoc/>
        public string ServiceAccessToken { get; private set; }

        
        /// <inheritdoc/>
        public string ApiVersion { get; private set; }
        
        
        /// <inheritdoc/>
        public string DpopKey { get; private set; }
        
        
        /// <inheritdoc/>
        public string ClientCertificate { get; private set; }
    }
}
