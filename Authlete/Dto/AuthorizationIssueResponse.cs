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
    /// Response from Authlete's <c>/api/auth/authorization/issue</c>
    /// API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/auth/authorization/issue</c> API returns
    /// JSON which can be mapped to this class. The authorization
    /// server implementation should retrieve the value of the
    /// <c>action</c> response parameter (which can be obtained via
    /// the <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationIssueAction.INTERNAL_SERVER_ERROR</c>,
    /// it means that the request from the authorization server
    /// implementation was wrong or that an error ocurred in
    /// Authlete. In either case, from a viewpoint of the client
    /// application, it is an error on the server side. Therefore,
    /// the authorization server implementation should generate a
    /// response to the client application with the HTTP status of
    /// <c>"500 Internal Server Error"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the
    /// response which the authorization server implementation
    /// should generate and return to the client application.
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
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationIssueAction.BAD_REQUEST</c>, it means that
    /// the ticket is no longer valid (deleted or expired) and that
    /// the reason of the invalidity was probably due to the
    /// end-user's too-delayed response to the authorization UI.
    /// </para>
    ///
    /// <para>
    /// The HTTP status of the response returned to the client
    /// application should be <c>"400 Bad Request"</c> and the
    /// content type should be <c>"application/json"</c> although
    /// OAuth 2.0 specification does not mention the format of the
    /// error response for this case.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the
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
    /// (The value returned from ResponseContent)
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationIssueAction.LOCATION</c>, it means that the
    /// response to the client application should be
    /// <c>"302 Found"</c> with a <c>"Location"</c> header.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a redirect URI
    /// which contains (1) an authorization code, an ID token and/or
    /// an access token (on success) or (2) an error code (on failure),
    /// so it can be used as the value of <c>"Location"</c> header.
    /// The following illustrates the response which the
    /// authorization server implementation should generate and
    /// return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 302 Found
    /// Location: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationIssueAction.FORM</c>, it means that the
    /// response to the client application should be <c>"200 OK"</c>
    /// with an HTML which triggers redirection by JavaScript. This
    /// happens when the authorization request from the client
    /// application contains <c>response_mode=form_post</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns an HTML which
    /// satisfies the requirements of <c>response_mode=form_post</c>,
    /// so it can be used as the entity body of the response. The
    /// following illustrates the response which the authorization
    /// server implementation should generate and return to the
    /// client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: text/html;charset=UTF-8
    /// Cache-Control: no-store
    /// Pragma: no-store
    ///
    /// (The value returned from ResponseContent)
    /// </code>
    /// </remarks>
    public class AuthorizationIssueResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthorizationIssueAction Action { get; set; }


        /// <summary>
        /// The response content which can be used to generate a
        /// response to the client application. The format of the
        /// value varies depending on the value of the
        /// <c>Action</c> property.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }
    }
}
