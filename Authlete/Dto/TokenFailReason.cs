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
    /// The value of <c>reason</c> in requests to Authlete's
    /// <c>/api/auth/token/fail</c> API.
    /// </summary>
    public enum TokenFailReason
    {
        /// <summary>
        /// Unknown reason. Using this reason will result in
        /// <c>error=server_error</c>.
        /// </summary>
        UNKNOWN,


        /// <summary>
        /// The resource owner's credentials (<c>username</c> and
        /// <c>password</c> contained in the token request whose
        /// flow is
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials</a>) are invalid. Using this
        /// reason will result in <c>error=invalid_request</c>.
        /// </summary>
        INVALID_RESOURCE_OWNER_CREDENTIALS,
    }
}
