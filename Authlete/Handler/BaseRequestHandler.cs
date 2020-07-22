//
// Copyright (C) 2018-2020 Authlete, Inc.
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
using Authlete.Api;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// The base class for request handlers.
    /// </summary>
    public class BaseRequestHandler
    {
        /// <summary>
        /// Constructor with an implementation of the
        /// <c>IAuthleteApi</c> interface. The given value can be
        /// referred to as the value of the <c>Api</c> property
        /// later.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public BaseRequestHandler(IAuthleteApi api)
        {
            Api = api;
        }


        /// <summary>
        /// The implementation of the <c>IAuthleteApi</c> interface.
        /// It is the value given to the constructor.
        /// </summary>
        ///
        /// <value>
        /// The implementation of the <c>IAuthleteApi</c> interface.
        /// </value>
        public IAuthleteApi Api { get; }


        /// <summary>
        /// A utility method to generate an <c>HttpResponseMessage</c>
        /// instance with "500 Internal Server Error" and an error
        /// message in JSON. This method is expected to be used
        /// when the value of the <c>"action"</c> parameter in a
        /// response from an Authlete API holds an unexpected value.
        /// </summary>
        ///
        /// <returns>
        /// An <c>HttpResponseMessage</c> which represents a server
        /// error.
        /// </returns>
        ///
        /// <param name="apiPath">
        /// The path of an Authlete API.
        /// </param>
        protected HttpResponseMessage UnknownAction(string apiPath)
        {
            string content = $"{{\"error\":\"server_error\",\"error_description\":\"Authlete's '{apiPath}' API returned an unknown action.\"}}";

            return ResponseUtility.InternalServerError(content);
        }
    }
}
