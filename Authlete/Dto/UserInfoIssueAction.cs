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
    /// <c>/api/auth/userinfo/issue</c> API.
    /// </summary>
    public enum UserInfoIssueAction
    {
        /// <summary>
        /// The request from your system was wrong or an error
        /// occurred in Authlete. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return <c>"500
        /// Internal Server Error"</c> to the client application.
        /// </summary>
        INTERNAL_SERVER_ERROR,


        /// <summary>
        /// The request does not contain an access token. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return <c>"400 Bad
        /// Request"</c> to the client application.
        /// </summary>
        BAD_REQUEST,


        /// <summary>
        /// The access token does not exist or has expired. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return <c>"401
        /// Unauthorized"</c> to the client application.
        /// </summary>
        UNAUTHORIZED,


        /// <summary>
        /// The access token does not cover the required scopes.
        /// To be concrete, the access token does not have the
        /// <c>"openid"</c> scope. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return <c>"403
        /// Forbidden"</c> to the client application.
        /// </summary>
        FORBIDDEN,


        /// <summary>
        /// The access token was valid and a userinfo response was
        /// generated successfully in JSON format. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return
        /// <c>"200 OK"</c> to the client application with the
        /// content type <c>"application/json;charset=UTF-8"</c>.
        /// </summary>
        JSON,


        /// <summary>
        /// The access token was valid and a userinfo response was
        /// generated successfully in JWT format. The
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#UserInfo">userinfo
        /// endpoint</a> implementation should return
        /// <c>"200 OK"</c> to the client application with the
        /// content type <c>"application/jwt"</c>.
        /// </summary>
        JWT,
    }
}
