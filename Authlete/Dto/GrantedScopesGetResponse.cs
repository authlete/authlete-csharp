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
    /// Response from Authlete's
    /// <c>/api/client/granted_scopes/get/{clientId}</c> API.
    /// </summary>
    public class GrantedScopesGetResponse : ApiResponse
    {
        /// <summary>
        /// The API key of the service.
        /// </summary>
        [JsonProperty("serviceApiKey")]
        public long ServiceApiKey { get; set; }


        /// <summary>
        /// The client ID.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the end-user who
        /// has granted authorization to the client application.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The scopes granted to the client application by the
        /// last authorization process by the end-user (who is
        /// identified by the subject).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <c>null</c> means that there is no record about granted
        /// scopes. An empty array means that there exists a record
        /// about granted scopes but no scope has been granted to
        /// the client application. If the returned array holds
        /// some elements, they are the scopes granted to the
        /// client application by the last authorization process.
        /// </para>
        /// </remarks>
        [JsonProperty("latestGrantedScopes")]
        public string[] LatestGrantedScopes { get; set; }


        /// <summary>
        /// The scopes granted to the client application by all the
        /// past authorization processes. Note that revoked scopes
        /// are not included.
        /// </summary>
        [JsonProperty("mergedGrantedScopes")]
        public string[] MergedGrantedScopes { get; set; }


        /// <summary>
        /// The timestamp in milliseconds since the Unix epoch
        /// (1970-Jan-1) at which the record was modified.
        /// </summary>
        [JsonProperty("modifiedAt")]
        public long ModifiedAt { get; set; }
    }
}
