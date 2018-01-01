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
    /// <c>/api/auth/token/create</c> API.
    /// </summary>
    public enum TokenCreateAction
    {
        /// <summary>
        /// An error occurred on Authlete side.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The request from your system was wrong. For example,
        /// this happens when the <c>"grantType"</c> request
        /// parameter is missing.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The request from your system was not allowed. For
        /// example, this happens when the client application
        /// identified by the <c>"clientId"</c> request parameter
        /// does not belong to the service identified by the API
        /// key used for the API call.
        /// </summary>
        FORBIDDEDN,


        /// <summary>
        /// An access token and optionally a refresh token were
        /// issued successfully.
        /// </summary>
        OK,
    }
}
