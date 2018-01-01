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
    /// Request to Authlete's
    /// <c>/api/client/authorization/get/list</c> API.
    /// The API returns a list of client applications to which an
    /// end-user has given authorization.
    /// </summary>
    public class ClientAuthorizationGetListRequest
    {
        /// <summary>
        /// The default value of the <c>"developer"</c> request
        /// parameter (= <c>null</c>).
        /// </summary>
        public const string DEFAULT_DEVELOPER = null;


        /// <summary>
        /// The default value of the <c>"start"</c> request
        /// parameter (= <c>0</c>).
        /// </summary>
        public const int DEFAULT_START = 0;


        /// <summary>
        /// The default value of the <c>"end"</c> request
        /// parameter (= <c>5</c>).
        /// </summary>
        public const int DEFAULT_END = 5;


        /// <summary>
        /// The default constructor with the default values.
        /// Because the <c>"subject"</c> request parameter is
        /// mandatory for <c>/api/client/authorization/get/list</c>
        /// API, a value has to be set to the <c>Subject</c> property
        /// after creating a <c>ClientAuthorizationGetListRequest</c>
        /// instance by this constructor.
        /// </summary>
        public ClientAuthorizationGetListRequest()
            : this(null, DEFAULT_DEVELOPER, DEFAULT_START, DEFAULT_END)
        {
        }


        /// <summary>
        /// A constructor with a value for the <c>"subject"</c>
        /// request parameter.
        /// </summary>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of an end-user.
        /// </param>
        public ClientAuthorizationGetListRequest(string subject)
            : this(subject, DEFAULT_DEVELOPER, DEFAULT_START, DEFAULT_END)
        {
        }


        /// <summary>
        /// A constructor with values for the <c>"subject"</c> and
        /// <c>"developer"</c> request parameters.
        /// </summary>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <param name="developer">
        /// The unique identifier of a developer.
        /// </param>
        public ClientAuthorizationGetListRequest(
            string subject, string developer)
            : this(subject, developer, DEFAULT_START, DEFAULT_END)
        {
        }


        /// <summary>
        /// A constructor with values for the <c>"subject"</c>,
        /// <c>"start"</c> and <c>"end"</c> request parameters.
        /// </summary>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <param name="start">
        /// A start index of search results (inclusive).
        /// </param>
        ///
        /// <param name="end">
        /// An end index of search results (exclusive).
        /// </param>
        public ClientAuthorizationGetListRequest(
            string subject, int start, int end)
            : this(subject, DEFAULT_DEVELOPER, start, end)
        {
        }


        /// <summary>
        /// A custructor with values for all the request parameters.
        /// </summary>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <param name="developer">
        /// The unique identifier of a developer.
        /// </param>
        ///
        /// <param name="start">
        /// A start index of search results (inclusive).
        /// </param>
        ///
        /// <param name="end">
        /// An end index of search results (exclusive).
        /// </param>
        public ClientAuthorizationGetListRequest(
            string subject, string developer, int start, int end)
        {
            Subject   = subject;
            Developer = developer;
            Start     = start;
            End       = end;
        }


        /// <summary>
        /// The subject (= unique identifier) of an end-user.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The unique identifier of a developer. If a non-null
        /// value is given, client applications which do not belong
        /// to the developer won't be included in the response
        /// from <c>/api/client/authorization/get/list</c> API.
        /// </summary>
        [JsonProperty("developer")]
        public string Developer { get; set; }


        /// <summary>
        /// A start index of search results (inclusive).
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }


        /// <summary>
        /// An end index of search results (exclusive).
        /// </summary>
        [JsonProperty("end")]
        public int End { get; set; }
    }
}
