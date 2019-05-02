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


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's
    /// <c>/api/backchannel/authentication/fail</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// The API prepares JSON that contains an <c>error</c>.
    /// The JSON should be used as the response body of the
    /// response which is returned to the client application from
    /// the backchannel authentication endpoint.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationFailRequest
    {
        /// <summary>
        /// The ticket which should be deleted on the API call.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This request parameter is not mandatory but optional.
        /// If this request parameter is given and the ticket
        /// belongs to the service, the specified ticket is deleted
        /// from the database. Giving this parameter is recommended
        /// to clean up the storage area for the service.
        /// </para>
        /// </remarks>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The reason of the failure of the backchannel
        /// authentication request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This request parameter is not mandatory but optional.
        /// However, giving this parameter is recommended. If
        /// omitted,
        /// <c>BackchannelAuthenticationFailReason.SERVER_ERROR</c>
        /// is used as a reason.
        /// </para>
        /// </remarks>
        [JsonProperty("reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BackchannelAuthenticationFailReason Reason { get; set; }


        /// <summary>
        /// The description of the error. If this optional
        /// parameter is given, its value is used as the value of
        /// the <c>error_description</c> property in the response
        /// to the client application.
        /// </summary>
        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }


        /// <summary>
        /// The URI of a document which describes the error in
        /// detail. If this optional request parameter is given,
        /// its value is used as the value of the <c>error_uri</c>
        /// property in the response to the client application.
        /// </summary>
        [JsonProperty("errorUri")]
        public Uri ErrorUri { get; set; }
    }
}
