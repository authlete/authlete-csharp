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


namespace Authlete.Types
{
    /// <summary>
    /// Backchannel token delivery mode defined in the specification
    /// of CIBA (Client Initiated Backchannel Authentication).
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum DeliveryMode
    {
        /// <summary>
        /// Poll mode, a backchannel token delivery mode where a
        /// client polls the token endpoint until it gets tokens.
        /// </summary>
        POLL = 1,


        /// <summary>
        /// Ping mode, a backchannel token delivery mode where a
        /// client is notified via its client notification endpoint
        /// and then gets tokens from the token endpoint.
        /// </summary>
        PING,


        /// <summary>
        /// Push mode, a backchannel token delivery mode where a
        /// client receives tokens at its client notification
        /// endpoint.
        /// </summary>
        PUSH,
    }
}
