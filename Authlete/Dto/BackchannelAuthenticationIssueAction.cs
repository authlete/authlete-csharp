//
// Copyright (C) 2019 Authlete, Inc.
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
    /// <c>/api/backchannel/authentication/issue</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationIssueAction
    {
        /// <summary>
        /// The implementation of the backchannel authentication
        /// endpoint should return a <c>200 OK</c> response to the
        /// client application.
        /// </summary>
        OK,


        /// <summary>
        /// The implementation of the backchannel authentication
        /// endpoint should return a <c>500 Internal Server Error</c>
        /// response to the client application. However, in most
        /// cases, commercial implementations prefer to use other
        /// HTTP status code than <c>5xx</c>.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The ticket included in the API call is invalid. It does
        /// not exist or has expired.
        /// </summary>
        INVALID_TICKET,
    }
}
