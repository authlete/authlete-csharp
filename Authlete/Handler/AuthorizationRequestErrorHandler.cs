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


using System.Net.Http;
using Authlete.Dto;
using Authlete.Web;


namespace Authlete.Handler
{
    /// <summary>
    /// Handler for error cases of authorization requests.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// A response from Authlete's <c>/api/auth/authorization</c>
    /// API contains an <c>"action"</c> response parameter. When
    /// the value of the response parameter is neither
    /// <c>"NO_INTERACTION"</c> nor <c>"INTERACTION"</c>, the
    /// authorization request should be handled as an error case.
    /// This class is a handler for such error cases.
    /// </para>
    /// </remarks>
    public class AuthorizationRequestErrorHandler
        : AuthorizationRequestBaseHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AuthorizationRequestErrorHandler()
            : base(null)
        {
        }


        /// <summary>
        /// Handle an error case of an authorization request.
        /// This method returns <c>null</c> when <c>response.Action</c>
        /// returns <c>AuthorizationAction.INTERACTION</c> or
        /// <c>AuthorizationAction.NO_INTERACTION</c>. In other cases,
        /// an instance of <c>HttpResponseMessage</c> is returned.
        /// </summary>
        ///
        /// <returns>
        /// An error response that should be returned to the client
        /// application from the authorization endpoint. <c>null</c>
        /// is returned when <c>response.Action</c> returns
        /// <c>AuthorizationAction.INTERACTION</c> or
        /// <c>AuthorizationAction.NO_INTERACTION</c>.
        /// </returns>
        ///
        /// <param name="response">
        /// A response from Authlete's <c>/api/auth/authorization</c>
        /// API.
        /// </param>
        public HttpResponseMessage Handle(
            AuthorizationResponse response)
        {
            // 'action' in the response denotes the next action which
            // the implementation of authorization endpoint should take.
            AuthorizationAction action = response.Action;

            // The content of the response to the client application.
            // The format of the content varies depending on the action.
            string content = response.ResponseContent;

            // Dispatch according to the action.
            switch (action)
            {
                case AuthorizationAction.INTERNAL_SERVER_ERROR:
                    // 500 Internal Server Error
                    return ResponseUtility.InternalServerError(content);

                case AuthorizationAction.BAD_REQUEST:
                    // 400 Bad Request
                    return ResponseUtility.BadRequest(content);

                case AuthorizationAction.LOCATION:
                    // 302 Found
                    return ResponseUtility.Location(content);

                case AuthorizationAction.FORM:
                    // 200 OK
                    return ResponseUtility.OkHtml(content);

                case AuthorizationAction.INTERACTION:
                    // This is not an error case. The implementation
                    // of the authorization endpoint should show an
                    // authorization page to the end-user.
                    return null;

                case AuthorizationAction.NO_INTERACTION:
                    // This is not an error case. The implementation
                    // of the authorization endpoint should handle the
                    // authorization request without user interaction.
                    return null;

                default:
                    // 500 Internal Server Error.
                    // This should never happen.
                    return UnknownAction("/api/auth/authorization");
            }
        }
    }
}
