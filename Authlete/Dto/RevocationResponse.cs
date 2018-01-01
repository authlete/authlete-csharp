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
    /// Response from Authlete's <c>/api/auth/revocation</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/revocation</c> API returns JSON
    /// which can be mapped to this class. The authorization server
    /// implementation should retrieve the value of the
    /// <c>"action"</c> from the response and take the following
    /// steps according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>RevocationAction.INVALID_CLIENT</c>, it means that
    /// authentication of the client failed. In this case, the HTTP
    /// status of the response to the client application should be
    /// either <c>"400 Bad Request"</c> or <c>"401 Unauthorized"</c>.
    /// The description about <c>"invalid_client"</c> shown below
    /// is an excerpt from RFC 6749.
    /// </para>
    ///
    /// <para>
    /// <i><c>invalid_client</c>: Client authentication failed
    /// (e.g., unknown client, no client authentication included,
    /// or unsupported authentication method). The authorization
    /// server MAY return an HTTP 401 (Unauthorized) status code
    /// to indicate which HTTP authentication schemes are
    /// supported. If the client attempted to authenticate via the
    /// "Authorization" request header field, the authorization
    /// server MUST respond with an HTTP 401 (Unauthorized) status
    /// code and include the
    /// <a href="http://tools.ietf.org/html/rfc2616#section-14.47">"WWW-Authenticate"</a>
    /// response header field matching the authentication scheme
    /// used by the client.</i>
    /// </para>
    ///
    /// <para>
    /// In either case, the JSON string returned from the
    /// <c>ResponseContent</c> property can be used as the entity
    /// body of the response to the client application.
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
    /// (The value returned from <c>ResponseContent</c>)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>RevocationAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the request from the authorization server
    /// implementation (<c>RevocationRequest</c>) was wrong or that
    /// an error occurred in Authlete.
    /// </para>
    ///
    /// <para>
    /// In either case, from a viewpoint of the client application,
    /// it is an error on the server side. Therefore, the
    /// authorization server implementation should generate a
    /// response to the client application with the HTTP status of
    /// <c>"500 Internal Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the
    /// response which the authorization server should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 500 Internal Server Error
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from <c>ResponseContent</c>)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>RevocationAction.BAD_REQUEST</c>, it means that the
    /// request from the client application is invalid.
    /// </para>
    ///
    /// <para>
    /// The HTTP status of the response returned to the client
    /// application must be <c>"400 Bad Request"</c> and the
    /// content type must be <c>"application/json"</c>.
    /// <a href="https://tools.ietf.org/html/rfc7009#section-2.2.1">2.2.1.
    /// Error Response</a> of
    /// <a href="https://tools.ietf.org/html/rfc7009">RFC 7009</a>
    /// states <i>"The error presentation conforms to the
    /// definition in
    /// <a href="http://tools.ietf.org/html/rfc6749#section-5.2">Section
    /// 5.2</a> of
    /// [<a href="http://tools.ietf.org/html/rfc6749">RFC 6749</a>]."</i>
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustartes the
    /// response which the authorization server implementation
    /// should generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type: application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from <c>ResponseContent</c>)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>RevocationAction.OK</c>, it means that the request from
    /// the client application is valid and the presented token has
    /// been revoked successfully or that the client submitted an
    /// invalid token. Note that invalid tokens do not cause an
    /// error. See
    /// <a href="https://tools.ietf.org/html/rfc7009#section-2.2">2.2.
    /// Revocation Response</a> for details.
    /// </para>
    ///
    /// <para>
    /// The HTTP status of the response returned to the client
    /// application must be <c>"200 OK"</c>.
    /// </para>
    ///
    /// <para>
    /// If the original request from the client application
    /// contains the <c>"callback"</c> request parameter and its
    /// value is not empty, the content type should be
    /// <c>"application/javascript"</c> and the content should be a
    /// JavaScript snippet for JSONP.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JavaScript
    /// snippet if the original request from the client application
    /// contains the <c>"callback"</c> request parameter and its
    /// value is not empty. Otherwise, <c>ResponseContent</c>
    /// returns <c>null</c>. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: application/javascript
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// (The value returned from <c>ResponseContent</c>)
    /// </code>
    /// </remarks>
    public class RevocationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the revocation endpoint should
        /// take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RevocationAction Action { get; set; }


        /// <summary>
        /// The response content which can be used as the entity
        /// body of the response returned from the revocation
        /// endpoint to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }
    }
}
