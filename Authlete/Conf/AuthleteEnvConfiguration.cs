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


// Disable the following warning to the implementation of the
// IAuthleteConfiguration interface.
//
//   "Missing XML comment for publicly visible type or member"
//
#pragma warning disable 1591


namespace Authlete.Conf
{
    /// <summary>
    /// An implementation of the <c>IAutheteConfiguration</c>
    /// interface that utilizes environment variables.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// This class refers to the following environment variables.
    /// </para>
    ///
    /// <list type="bullet">
    ///   <item>
    ///     <term><c>AUTHLETE_BASE_URL</c></term>
    ///     <description>The base URL of an Authlete server.</description>
    ///   </item>
    ///   <item>
    ///     <term><c>AUTHLETE_SERVICEOWNER_APIKEY</c></term>
    ///     <description>The API key of a service owner.</description>
    ///   </item>
    ///   <item>
    ///     <term><c>AUTHLETE_SERVICEOWNER_APISECRET</c></term>
    ///     <description>The API secret of a service owner.</description>
    ///   </item>
    ///   <item>
    ///     <term><c>AUTHLETE_SERVICE_APIKEY</c></term>
    ///     <description>The API key of a service.</description>
    ///   </item>
    ///   <item>
    ///     <term><c>AUTHLETE_SERVICE_APISECRET</c></term>
    ///     <description>The API secret of a service.</description>
    ///   </item>
    /// </list>
    /// </remarks>
    public class AuthleteEnvConfiguration : IAuthleteConfiguration
    {
        const string ENV_BASE_URL                 = "AUTHLETE_BASE_URL";
        const string ENV_SERVICE_OWNER_API_KEY    = "AUTHLETE_SERVICEOWNER_APIKEY";
        const string ENV_SERVICE_OWNER_API_SECRET = "AUTHLETE_SERVICEOWNER_APISECRET";
        const string ENV_SERVICE_API_KEY          = "AUTHLETE_SERVICE_APIKEY";
        const string ENV_SERVICE_API_SECRET       = "AUTHLETE_SERVICE_APISECRET";


        public string BaseUrl
        {
            get
            {
                return GetEnv(ENV_BASE_URL);
            }
        }


        public string ServiceOwnerApiKey
        {
            get
            {
                return GetEnv(ENV_SERVICE_OWNER_API_KEY);
            }
        }


        public string ServiceOwnerApiSecret
        {
            get
            {
                return GetEnv(ENV_SERVICE_OWNER_API_SECRET);
            }
        }


        public string ServiceApiKey
        {
            get
            {
                return GetEnv(ENV_SERVICE_API_KEY);
            }
        }


        public string ServiceApiSecret
        {
            get
            {
                return GetEnv(ENV_SERVICE_API_SECRET);
            }
        }


        /// <summary>
        /// Get the value of the environment variable identified
        /// by the name.
        /// </summary>
        string GetEnv(string name)
        {
            return System.Environment.GetEnvironmentVariable(name);
        }
    }
}
