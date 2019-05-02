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


using System.Net.Http;
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Dto;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for requests to an introspection endpoint
    /// (<a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>).
    /// </summary>
    public class IntrospectionRequestHandler : BaseRequestHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// </param>
        public IntrospectionRequestHandler(IAuthleteApi api)
            : base(api)
        {
        }


        /// <summary>
        /// Handle an introspection request. This method calls
        /// Authlete's <c>/api/auth/introspection/standard</c> API.
        /// </summary>
        ///
        /// <returns>
        /// An HTTP response that should be returned from the
        /// introspection endpoint implementation to the client
        /// application.
        /// </returns>
        ///
        /// <param name="parameters">
        /// Request parameters of an introspection request.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"></exception>
        public async Task<HttpResponseMessage> Handle(string parameters)
        {
            // Call Authlete's /api/auth/introspection/standard API.
            StandardIntrospectionResponse response =
                await CallStandardIntrospectionApi(parameters);

            // 'action' in the response denotes the next action which
            // the implementation of introspection endpoint should take.
            StandardIntrospectionAction action = response.Action;

            // The content of the response to the client application.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case StandardIntrospectionAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case StandardIntrospectionAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case StandardIntrospectionAction.OK:
                    // 200 OK
                    return ResponseUtility.OkJson(content);

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/introspection/standard");
            }
        }


        async Task<StandardIntrospectionResponse>
        CallStandardIntrospectionApi(string parameters)
        {
            if (parameters == null)
            {
                // Authlete returns different error codes for null
                // and an empty string. 'null' is regarded as a
                // caller's error. An empty string is regarded as
                // a client application's error.
                parameters = "";
            }

            // Create a request for Authlete's
            // /api/auth/introspection/standard API.
            var request = new StandardIntrospectionRequest
            {
                Parameters = parameters
            };

            // Call Authlete's /api/auth/introspection/standard API.
            return await Api.StandardIntrospection(request);
        }
    }
}
