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


namespace Authlete.Conf
{
    /// <summary>
    /// A simple implementation of the <c>IAuthleteConfiguration</c>
    /// interface.
    /// </summary>
    public class AuthleteSimpleConfiguration : IAuthleteConfiguration
    {
        /// <inheritdoc/>
        public string BaseUrl { get; set; }


        /// <inheritdoc/>
        public string ServiceOwnerApiKey { get; set; }


        /// <inheritdoc/>
        public string ServiceOwnerApiSecret { get; set; }


        /// <inheritdoc/>
        public string ServiceOwnerAccessToken { get; set; }


        /// <inheritdoc/>
        public string ServiceApiKey { get; set; }


        /// <inheritdoc/>
        public string ServiceApiSecret { get; set; }


        /// <inheritdoc/>
        public string ServiceAccessToken { get; set; }

        
        /// <inheritdoc/>
        public string ApiVersion { get; set; }
        
        
        /// <inheritdoc/>
        public string DpopKey { get; set; }
        
        
        /// <inheritdoc/>
        public string ClientCertificate { get; set; }
    }
}
