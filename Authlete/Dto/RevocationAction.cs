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
    /// <c>/api/auth/revocation</c> API.
    /// </summary>
    public enum RevocationAction
    {
        /// <summary>
        /// Authentication of the client application failed. The
        /// authorization server implementation should return
        /// either <c>"400 Bad Request"</c> or
        /// <c>"401 Unauthorized"</c> to the client application.
        /// </summary>
        INVALID_CLIENT,


        /// <summary>
        /// The request from the authorization server implementation
        /// was wrong or an error occurred in Authlete. The
        /// authorization server implementation should return
        /// <c>"500 Internal Server Error"</c> to the client
        /// application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The request from the client application was wrong. The
        /// authorization server implementation should return
        /// <c>"400 Bad Request"</c> to the client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The request from the client application was valid. The
        /// authorization server implementation should return
        /// <c>"200 OK"</c> to the client application.
        /// </summary>
        OK,
    }
}
