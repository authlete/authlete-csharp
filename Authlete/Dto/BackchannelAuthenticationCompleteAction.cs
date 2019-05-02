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
    /// <c>/api/backchannel/authentication/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public enum BackchannelAuthenticationCompleteAction
    {
        /// <summary>
        /// The authorization server implementation must send a
        /// notification to the client's notification endpoint.
        /// This action code is returned when the backchannel token
        /// delivery mode is "ping" or "push".
        /// </summary>
        NOTIFICATION,


        /// <summary>
        /// The authorization server implementation does not have
        /// to take any immediate action for this API response. The
        /// remaining task is just to handle polling requests from
        /// the client to the token endpoint. This action code is
        /// returned when the backchannel token delivery mode is
        /// "poll".
        /// </summary>
        NO_ACTION,


        /// <summary>
        /// An error occurred either because the ticket included in
        /// the API call was invalid or because an error occurred
        /// on Authlete side.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If an error occurred after Authlete succeeded in
        /// retrieving data associated with the ticket from the
        /// database and if the backchannel token delivery mode is
        /// "ping" or "push", <c>NOTIFICATION</c> is used as the
        /// value of <c>action</c> instead of <c>SERVER_ERROR</c>.
        /// </para>
        /// </remarks>
        SERVER_ERROR,
    }
}
