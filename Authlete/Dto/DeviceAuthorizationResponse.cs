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
    /// Response from Authlete's <c>/api/device/authorization</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/device/authorization</c> API returns
    /// JSON which can be mapped to this class. The authorization
    /// server implementation should retrieve the value of the
    /// <c>action</c> response parameter (which can be obtained via
    /// the <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>DeviceAuthorizationAction.OK</c>, it means that the device
    /// authorization request from the client application is valid.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>200 OK</c> and
    /// <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which can be used as the entity body of the response. The
    /// following illustrates the response which the authorization
    /// server implementation should generate and return to the
    /// client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
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
    /// <c>DeviceAuthorizationAction.BAD_REQUEST</c>, it means that
    /// the device authorization request from the client application
    /// was wrong.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>400 Bad Request</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should generate
    /// and return to the client application.
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
    /// <c>DeviceAuthorizationAction.UNAUTHORIZED</c>, it means that
    /// client authentication of the device authorization request
    /// failed.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>401 Unauthorized</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
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
    /// <c>DeviceAuthorizationAction.INTERNAL_SERVER_ERROR</c>,
    /// it means that the API call from the authorization server
    /// implementation was wrong or that an error occurred in
    /// Authlete.
    /// </para>
    ///
    /// <para>
    /// In either case, from a viewpoint of the client application,
    /// it is an error on the server side. Therefore, the
    /// authorization server implementation should generate a
    /// response to the client application with
    /// <c>500 Internal Server Error</c> and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
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
    public class DeviceAuthorizationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceAuthorizationAction Action { get; set; }


        /// <summary>
        /// The response content which can be used to generate a
        /// response to the client application.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The client ID of the client application.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The client ID alias of the client application.
        /// </summary>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was used in the device authorization request.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The name of the client application.
        /// </summary>
        [JsonProperty("clientName")]
        public string ClientName { get; set; }


        /// <summary>
        /// The scopes requested by the device authorization
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Basically, this property holds the value of the <c>scope</c>
        /// request parameter in the device authorization request.
        /// However, because unregistered scopes are dropped on
        /// Authlete side, if the <c>scope</c> request parameter
        /// contains unknown scopes, the list held by this property
        /// becomes different from the value of the <c>scope</c>
        /// request parameter.
        /// </para>
        ///
        /// <para>
        /// Note that <c>Description</c> property and
        /// <c>Descriptions</c> property of each element (<c>Scope</c>
        /// instance) in the array held by this property always
        /// null even if descriptions of the scopes are registered.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public Scope[] Scopes { get; set; }


        /// <summary>
        /// The names of the claims which were requested indirectly
        /// via some special scopes. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">5.4.
        /// Requesting Claims using Scope Values</a> in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </summary>
        [JsonProperty("claimNames")]
        public string[] ClaimNames { get; set; }


        /// <summary>
        /// The list of ACRs (Authentication Context Class
        /// References) requested by the device authorization
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Basically, this property holds the value of the
        /// <c>acr_values</c> request parameter in the device
        /// authorization request. However, because unsupported
        /// ACR values are dropped on Authlete side, if the
        /// <c>acr_values</c> request parameter contains
        /// unrecognized ACR values, the list this property holds
        /// becomes different from the value of the <c>acr_values</c>
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("acrs")]
        public string[] Acrs { get; set; }


        /// <summary>
        /// The device verification code. This corresponds to
        /// the <c>device_code</c> property in the response to
        /// the client application.
        /// </summary>
        [JsonProperty("deviceCode")]
        public string DeviceCode { get; set; }


        /// <summary>
        /// The end-user verification code. This corresponds to
        /// the <c>user_code</c> property in the response to
        /// the client application.
        /// </summary>
        [JsonProperty("userCode")]
        public string UserCode { get; set; }


        /// <summary>
        /// The end-user verification URI. This corresponds to
        /// the <c>verification_uri</c> property in the response
        /// to the client application.
        /// </summary>
        [JsonProperty("verificationUri")]
        public Uri VerificationUri { get; set; }


        /// <summary>
        /// The end-user verification URI that includes the
        /// end-user verification code. This corresponds to the
        /// <c>verification_uri_complete</c> property in the
        /// response to the client application.
        /// </summary>
        [JsonProperty("verificationUriComplete")]
        public Uri VerificationUriComplete { get; set; }


        /// <summary>
        /// The duration of the issued device verification code
        /// and end-user verification code in seconds. This
        /// corresponds to the <c>expires_in</c> property in the
        /// response to the client application.
        /// </summary>
        [JsonProperty("expiresIn")]
        public int ExpiresIn { get; set; }


        /// <summary>
        /// The minimum amount of time in seconds that the client
        /// must wait for between polling requests to the token
        /// endpoint. This corresponds to the <c>interval</c>
        /// property in the response to the client application.
        /// </summary>
        [JsonProperty("interval")]
        public int Interval { get; set; }


        /// <summary>
        /// The resources specified by the <c>resource</c> request
        /// parameters. See
        /// <a href="https://www.rfc-editor.org/rfc/rfc8707.html">RFC 8707</a>
        /// (Resource Indicators for OAuth 2.0) for details.
        /// </summary>
        [JsonProperty("resources")]
        public string[] Resources { get; set; }


        /// <summary>
        /// The warnings raised during processing the device
        /// authorization request.
        /// </summary>
        [JsonProperty("warnings")]
        public string[] Warnings { get; set; }
    }
}
