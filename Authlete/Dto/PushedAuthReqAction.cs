//
// Copyright (C) 2020 Authlete, Inc.
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
    /// <c>/api/pushed_auth_req</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public enum PushedAuthReqAction
    {
        /// <summary>
        /// The pushed authorization request has been registered
        /// successfully. The endpoint should return <c>201 Created</c>
        /// to the client application.
        /// </summary>
        CREATED,


        /// <summary>
        /// The request is invalid. The pushed authorization request
        /// endpoint should return <c>400 Bad Request</c> to the
        /// client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The client authentication at the pushed authorization
        /// request endpoint failed. The endpoint should return
        /// <c>401 Unauthorized</c> to the client application.
        /// </summary>
        UNAUTHORIZED,


        /// <summary>
        /// The client application is not allowed to use the pushed
        /// authorization request endpoint. The endpoint should
        /// return <c>403 Forbidden</c> to the client application.
        /// </summary>
        FORBIDDEN,


        /// <summary>
        /// The size of the pushed authorization request is too
        /// large. The endpoint should return <c>413 Payload Too Large</c>
        /// to the client application.
        /// </summary>
        PAYLOAD_TOO_LARGE,


        /// <summary>
        /// The API call was wrong or an error occurred on Authlete
        /// side. The pushed authorization request endpoint should
        /// return <c>500 Internal Server Error</c> to the client
        /// application. However, it is up to the authorization
        /// server's policy whether to return <c>500</c> actually.
        /// </summary>
        INTERNAL_SERVER_ERROR,
    }
}
