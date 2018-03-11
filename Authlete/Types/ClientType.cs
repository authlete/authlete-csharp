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


namespace Authlete.Types
{
    /// <summary>
    /// Client types defined in
    /// <a href="https://tools.ietf.org/html/rfc6749#section-2.1">2.1.
    /// Client Types</a> of
    /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// Clients incapable of maintaining the confidentiality of
        /// their credentials. Typical examples are native
        /// applications on smart phones.
        /// </summary>
        PUBLIC = 1,


        /// <summary>
        /// Clients capable of maintaining the confidentiality of
        /// their credentials.
        /// </summary>
        CONFIDENTIAL,
    }
}
