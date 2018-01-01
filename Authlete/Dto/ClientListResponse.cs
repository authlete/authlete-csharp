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
    /// Response from Authlete's <c>/api/client/get/list</c> API.
    /// </summary>
    public class ClientListResponse
    {
        /// <summary>
        /// The start index (inclusive) for the result set of the
        /// query. It is the value contained in the original
        /// request (= the value of the <c>"start"</c> request
        /// parameter), or the default value (<c>0</c>) if the
        /// original request did not contain the parameter.
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }


        /// <summary>
        /// The end index (exclusive) for the result set of the
        /// query. It is the value contained in the original
        /// request (= the value of the <c>"end"</c> request
        /// parameter), or the defaul value defined in Authlete
        /// server if the original request did not contain the
        /// parameter.
        /// </summary>
        [JsonProperty("end")]
        public int End { get; set; }


        /// <summary>
        /// The unique identifier of the developer. It is the value
        /// contained in the original request (= the value of the
        /// <c>"developer"</c> request parameter), or <c>null</c>.
        /// In the case of <c>null</c>, it means that all the
        /// clients that belong to the service are targeted.
        /// </summary>
        [JsonProperty("developer")]
        public string Developer { get; set; }


        /// <summary>
        /// The total count of client applications of either the
        /// entire service (in the case of <c>developer=null</c>)
        /// or the developer.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value of this property is not the size of the array
        /// returned from the <c>Clients</c> property. Instead, it
        /// is the total count of the client applications (of
        /// either the entire service or the developer) which exist
        /// in Authlete's database.
        /// </para>
        /// </remarks>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }


        /// <summary>
        /// The list of client applications that match the query
        /// conditions.
        /// </summary>
        [JsonProperty("clients")]
        public Client[] Clients { get; set; }
    }
}
