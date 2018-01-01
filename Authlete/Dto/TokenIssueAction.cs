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
    /// <c>/api/auth/token/issue</c> API.
    /// </summary>
    public enum TokenIssueAction
    {
        /// <summary>
        /// The request from your system was wrong or an error
        /// occurred in Authlete. The token endpoint should return
        /// <c>"500 Internal Server Error"</c> to the client
        /// application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// Authlete's <c>/api/auth/token/issue</c> API successfully
        /// generated an access token. The token endpoint should
        /// return <c>"200 OK"</c> to the client application with
        /// the access token.
        /// </summary>
        OK,
    }
}
