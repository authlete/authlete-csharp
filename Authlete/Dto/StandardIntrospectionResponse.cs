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


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's
    /// <c>/api/auth/introspection/standard</c> API. Note that the
    /// API and <c>/api/auth/introspection</c> API are different.
    /// The <c>/api/auth/introspection/standard</c> API exists to
    /// help your authorization server provide its own introspection
    /// API which complies with
    /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>
    /// (OAuth 2.0 Token Introspection).
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/introspection/standard</c> API
    /// returns JSON which can be mapped to this class. The
    /// implementation of the introspection endpoint of your
    /// authorization server should retrieve the value of the
    /// <c>"action"</c> parameter (which can be obtained via the
    /// <c>Action</c> property of this class) from the response and
    /// take the following steps according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>StandardIntrospectionAction.INTERNAL_SERVER_ERROR</c>,
    /// it means that the request from your system to Authlete
    /// (<c>StandardIntrospectionRequest</c>) was wrong or that an
    /// error occurred in Authlete. In either case, from a
    /// viewpoint of the client application, it is an error on the
    /// server side. Therefore, the introspection endpoint of your
    /// authorization server should generate a response to the
    /// client application with the HTTP status of <c>"500 Internal
    /// Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a JSON string which describes the error, so it can be used
    /// as the entity body of the response if you want. Note that,
    /// however,
    /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>
    /// does not mention anything about the format of the response
    /// body of error responses.
    /// </para>
    ///
    /// <para>
    /// The following illustrates an example response which the
    /// introspection endpoint of your authorization server
    /// generates and returns to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>StandardIntrospectionAction.BAD_REQUEST</c>, it means
    /// that the request from the client application is invalid.
    /// This happens when the request from the client did not
    /// include the <c>"token"</c> request parameter. The HTTP
    /// status of the response returned to the client application
    /// should be <c>"400 Bad Request"</c>. See
    /// <a href="https://tools.ietf.org/html/rfc7662#section-2.1">2.1.
    /// Introspection Request</a> of
    /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>
    /// for details about requirements for introspection requests.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a JSON string which describes the error, so it can be used
    /// as the entity body of the response if you want. Note that,
    /// however,
    /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>
    /// does not mention anything about the format of the response
    /// body of error responses.
    /// </para>
    ///
    /// <para>
    /// The following illustrates an example response which the
    /// introspection endpoint of your authorization server
    /// generates and returns to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>StandardIntrospectionAction.BAD_REQUEST</c>, it means
    /// that the request from the client application is valid. The
    /// HTTP status of the response returned to the client
    /// application must be <c>"200 OK"</c> and its content type
    /// must be <c>"application/json"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the <c>ResponseContent</c> property returns
    /// a JSON string which complies with the introspection
    /// response defined in
    /// <a href="https://tools.ietf.org/html/rfc7662#section-2.2">2.2.
    /// Introspection Response</a> of
    /// <a href="https://tools.ietf.org/html/rfc7662">RFC 7662</a>.
    /// The following illustrates the response which the
    /// introspection endpoint of your authorization server should
    /// generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: application/json
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// Note that RFC 7662 says <i>"To prevent token scanning
    /// attacks, the endpoint MUST also require some form of
    /// authorization to access this endpoint"</i>. This means that
    /// you have to protect your introspection endpoint in some way
    /// or other. Authlete does not care about how your
    /// introspection endpoint is protected. In most cases, as
    /// mentioned in RFC 7662, <c>"401 Unauthorized"</c> is a
    /// proper response when an introspection request does not
    /// satisfy authorization requirements imposed by your
    /// introspection endpoint.
    /// </para>
    /// </remarks>
    public class StandardIntrospectionResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the introspection endpoint of
        /// your authorization server should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StandardIntrospectionAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }
    }
}
