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
    /// <c>/api/auth/token/update</c> API.
    /// </summary>
    public enum TokenUpdateAction
    {
        /// <summary>
        /// An error occurred on Authlete side.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The request from the caller was wrong. For example,
        /// this happens when the <c>"accessToken"</c> request
        /// parameter was missing.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The request from the caller was not allowed. For
        /// example, this happens when the access token identified
        /// by the <c>"accessToken"</c> request parameter does not
        /// belong to the service identified by the API key used
        /// for the API call.
        /// </summary>
        FORBIDDEN,


        /// <summary>
        /// The specified access token does not exist.
        /// </summary>
        NOT_FOUND,


        /// <summary>
        /// The access token was updated successfully.
        /// </summary>
        OK,
    }
}
