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


namespace Authlete.Dto
{
    /// <summary>
    /// The value of <c>action</c> in responses from Authlete's
    /// <c>/api/auth/introspection</c> API.
    /// </summary>
    public enum IntrospectionAction
    {
        /// <summary>
        /// The request from the resource server was wrong or an
        /// error occurred in Authlete. The resource server should
        /// return <c>"500 Internal Server Error"</c> to the client
        /// application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The request does not contain an access token. The
        /// resource server should return <c>"400 Bad Request"</c>
        /// to the client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The access token does not exist or has expired. The
        /// resource server should return <c>"401 Unauthorized"</c>
        /// to the client application.
        /// </summary>
        UNAUTHORIZED,


        /// <summary>
        /// The access token does not cover the required scopes.
        /// The resource server should return <c>"403 Forbidden"</c>
        /// to the client application.
        /// </summary>
        FORBIDDEN,


        /// <summary>
        /// The access token is valid. The resource server should
        /// return the protected resource to the client application.
        /// </summary>
        OK,
    }
}
