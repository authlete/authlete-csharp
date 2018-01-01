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
    /// <c>/api/auth/token</c> API.
    /// </summary>
    public enum TokenAction
    {
        /// <summary>
        /// Authentication of the client application failed. The
        /// token endpoint implementation should return either
        /// <c>"400 Bad Request"</c> or <c>"401 Unauthorized"</c>
        /// to the client application.
        /// </summary>
        INVALID_CLIENT,


        /// <summary>
        /// The request from your system to Authlete was wrong or
        /// an error occurred in Authlete. The token endpoint
        /// implementation should return <c>"500 Internal Server
        /// Error"</c> to the client application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The token request from the client application was wrong.
        /// The token endpoint implementation should return
        /// <c>"400 Bad Request"</c> to the client appication.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The token request from the client application was valid
        /// and the grant type is <c>"password"</c>. The token
        /// endpoint implementation should validate the credentials
        /// of the resource owner and call Authlete's
        /// <c>/api/auth/token/issue</c> API or
        /// <c>/api/auth/token/fail</c> API according to the result
        /// of the validation.
        /// </summary>
        PASSWORD,


        /// <summary>
        /// The token request from the client was valid. The token
        /// endpoint implementation should return <c>"200 OK"</c>
        /// to the client application with an access token.
        /// </summary>
        OK,
    }
}
