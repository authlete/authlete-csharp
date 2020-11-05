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


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/pushed_auth_req</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/pushed_auth_req</c> API returns JSON
    /// which can be mapped to this class. The authorization server
    /// implementation should retrieve the value of the
    /// <c>"action"</c> from the response and take the following
    /// steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.CREATED</c>, it means that the
    /// authorization request has been registered successfully.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>201 Created</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which can be used as the entity body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 201 Created
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.BAD_REQUEST</c>, it means that the
    /// request was wrong.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>400 Bad Request</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.UNAUTHORIZED</c>, it means that
    /// client authentication of the request failed.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>401 Unauthorized</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 401 Unauthorized
    /// WWW-Authenticate: (challenge)
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.FORBIDDEN</c>, it means that the
    /// client application is not allowed to use the pushed
    /// authorization request endpoint.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>403 Forbidden</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 403 Forbidden
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.PAYLOAD_TOO_LARGE</c>, it means
    /// that the size of the pushed authorization request is too
    /// large.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with
    /// <c>401 Payload Too Large</c> and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 413 Payload Too Large
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>PushedAuthReqAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the API call from the authorization server
    /// implementation was wrong or that an error occurred in
    /// Authlete.
    /// </para>
    ///
    /// <para>
    /// In either case, from a viewpoint of the client application,
    /// it is an error on the server side. Therefore, the
    /// authorization server implementation should generate a
    /// response to the client application with
    /// <c>500 Internal Server Error</c> and
    /// <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// The <c>ResponseContent</c> property holds a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response.
    /// </para>
    ///
    /// <para>
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// Since version 1.5.0.
    /// </para>
    /// </remarks>
    public class RevocationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the revocation endpoint should
        /// take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PushedAuthReqAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The request URI created to represent the pushed
        /// authorization request. When the client application
        /// sends an authorization request later, the value
        /// held by this property can be used as the value of
        /// the <c>request_uri</c> parameter.
        /// </summary>
        [JsonProperty("requestUri")]
        public Uri RequestUri { get; set; }
    }
}
