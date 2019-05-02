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
    /// <c>/api/backchannel/authentication/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// After the implementation of the backchannel authentication
    /// endpoint returns JSON containing an <c>auth_req_id</c> to
    /// the client, the authorization server starts a background
    /// process that communicates with the authentication device of
    /// the end-user. On the authentication device, end-user
    /// authentication is performed and the end-user is asked
    /// whether they give authorization to the client or not. The
    /// authorization server will receive the result of end-user
    /// authentication and authorization from the authentication
    /// device.
    /// </para>
    ///
    /// <para>
    /// After the authorization server receives the result from the
    /// authentication device, or even in the case where the server
    /// gave up receiving a response from the authentication device
    /// for some reasons, the server should call the
    /// <c>/api/backchannel/authentication/complete</c> API to tell
    /// Authlete the result.
    /// </para>
    ///
    /// <para>
    /// When the end-user was authenticated and authorization was
    /// granted to the client by the end-user, the authorization
    /// server should call the API with
    /// <c>result=BackchannelAuthenticationCompleteResult.AUTHORIZED</c>.
    /// In this successful case, the <c>subject</c> request
    /// parameter is mandatory. If the token delivery mode is "push",
    /// the API will generate an access token, an ID token and
    /// optionally a refresh token. On the other hand, if the token
    /// delivery mode is "poll" or "ping", the API will just update
    /// the database record so that <c>/api/auth/token</c> API can
    /// generate tokens later.
    /// </para>
    ///
    /// <para>
    /// When the authorization server received the decision of the
    /// end-user from the authentication device and it indicates
    /// that the end-user has rejected to give authorization to the
    /// client, the authorization server should call the API with
    /// <c>result=BackchannelAuthenticationCompleteResult.ACCESS_DENIED</c>.
    /// In this case, if the token delivery mode is "push", the API
    /// will generate an error response that contains the <c>error</c>
    /// response parameter and optionally the <c>error_description</c>
    /// and <c>error_uri</c> response parameters (if the
    /// <c>errorDescription</c> and <c>errorUri</c> request
    /// parameters have been given). On the other hand, if the
    /// token delivery mode is "poll" or "ping", the API will just
    /// update the database record so that <c>/api/auth/token</c>
    /// API can generate an error response later. In any token
    /// delivery mode, the value of the <c>error</c> parameter will
    /// become <c>access_denied</c>.
    /// </para>
    ///
    /// <para>
    /// When the authorization server could not get the result of
    /// end-user authentication and authorization from the
    /// authentication device for some reasons, the authorization
    /// server should call the API with
    /// <c>result=BackchannelAuthenticationCompleteResult.TRANSACTION_FAILED</c>.
    /// In this error case, the API will behave in the same way as
    /// in the case of <c>ACCESS_DENIED</c>. The only difference
    /// is that <c>transaction_failed</c> is used as the value of
    /// the <c>error</c> parameter.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationCompleteRequest
    {
        /// <summary>
        /// The ticket which is necessary to call Authlete's
        /// <c>/api/backchannel/authentication/complete</c> API.
        /// This request parameter is mandatory.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The ticket previously issued by Authlete's
        /// <c>/api/backchannel/authentication</c> API.
        /// </para>
        /// </remarks>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }


        /// <summary>
        /// The result of end-user authentication and authorization.
        /// This request parameter is mandatory.
        /// </summary>
        [JsonProperty("result")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BackchannelAuthenticationCompleteResult Result { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the end-user who
        /// has granted authorization to the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property is used as the value of the subject
        /// associated with the access token and as the value of
        /// the <c>"sub"</c> claim in the ID token.
        /// </para>
        ///
        /// <para>
        /// Note that, if the <c>Sub</c> property returns a
        /// non-empty value, it is used as the value of the
        /// <c>"sub"</c> claim in the ID token. However, even in
        /// the case, the value of the subject associated with the
        /// access token is still the value of this <c>Subject</c>
        /// property.
        /// </para>
        /// </remarks>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// The value of the <c>"sub"</c> claim used in the ID
        /// token. If this property returns <c>null</c> or its
        /// value is empty, the value of the <c>Subject</c>
        /// property is used as the value of the <c>"sub"</c> claim.
        /// The main purpose of this <c>Sub</c> property is to hide
        /// the actual value of the subject from client applications.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Note that the value of the <c>Subject</c> property is
        /// used as the value of the subject associated with the
        /// access token regardless of whether this <c>Sub</c>
        /// property holds a non-empty value or not. In other words,
        /// this <c>Sub</c> property affects only the <c>"sub"</c>
        /// claim in the ID token.
        /// </para>
        /// </remarks>
        [JsonProperty("sub")]
        public string Sub { get; set; }


        /// <summary>
        /// The time at which the end-user was authenticated. When
        /// this request parameter holds a positive number, the
        /// <c>"auth_time"</c> claim will be embedded in the ID
        /// token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value should be the number of seconds since the
        /// Unix epoch (1970-01-01).
        /// </para>
        /// </remarks>
        [JsonProperty("authTime")]
        public long AuthTime { get; set; }


        /// <summary>
        /// The reference of the authentication context class which
        /// the end-user authentication satisfied. When this
        /// request parameter holds a non-null value, the <c>"acr"</c>
        /// claim will be embedded in the ID token.
        /// </summary>
        [JsonProperty("acr")]
        public string Acr { get; set; }


        /// <summary>
        /// Additional claims which will be embedded in the ID
        /// token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The authorization server implementation is required to
        /// retrieve values of requested claims of the end-user
        /// from its database and format them in JSON format.
        /// </para>
        ///
        /// <para>
        /// For example, if <c>"given_name"</c> claim,
        /// <c>"family_name"</c> claim and <c>"email"</c> claim are
        /// requested, the authorization server implementation
        /// should generate a JSON object like the following and
        /// set its string representation to this <c>Claims</c>
        /// property.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "given_name": "Takahiko",
        ///   "family_name": "Kawasaki",
        ///   "email": "takahiko.kawasaki@example.com"
        /// }
        /// </code>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
        /// Standard Claims</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details about the format.
        /// </para>
        /// </remarks>
        [JsonProperty("claims")]
        public string Claims { get; set; }


        /// <summary>
        /// Extra properties that you want to associate with the
        /// access token. This request parameter is optional.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Keys of extra properties will be used as labels of
        /// top-level entries in a JSON response returned from the
        /// authorization server. An example is
        /// <c>example_parameter</c>, which you can find in
        /// <a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> in RFC 6749. The following code
        /// snippet is an example to set one extra property having
        /// <c>example_parameter</c> as its key and
        /// <c>example_value</c> as its value.
        /// </para>
        ///
        /// <code>
        /// request.Properties = new Property[] {
        ///     new Property("example_parameter", "example_value")
        /// };
        /// </code>
        ///
        /// <para>
        /// Note that there is an upper limit on the total size of
        /// extra properties. On Authlete side, the properties will
        /// be (1) converted to a multidimensional string array, (2)
        /// converted to JSON, (3) encrypted by AES/CBC/PKCS5Padding,
        /// (4) encoded by base64url, and then stored into the
        /// database. The length of the resultant string must not
        /// exceed 65,535 in bytes. This is the upper limit, but we
        /// think it is big enough.
        /// </para>
        /// </remarks>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// Scopes that should be associated with the access token.
        /// If <c>null</c> (the default value) is set, the scopes
        /// specified in the original backchannel authentication
        /// request are used. In other cases, the scopes set to
        /// this property will replace the original scopes
        /// contained in the original request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Even scopes that are not included in the original
        /// request can be included.
        /// </para>
        ///
        /// <para>
        /// Note that because the CIBA specification requires
        /// <c>openid</c> as a mandatory scope, <c>openid</c>
        /// should be always included.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// The description of the error. This corresponds to the
        /// <c>error_description</c> property in the response to
        /// the client.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this optional request parameter is given, its value
        /// is used as the value of the <c>error_description</c>
        /// property, but it is used only when the result is not
        /// <c>BackchannelAuthenticationCompleteResult.AUTHORIZED</c>.
        /// </para>
        ///
        /// <para>
        /// To comply with the specification strictly, the
        /// description must not include characters outside the set
        /// %x20-21 / %x23-5B / %x5D-7E.
        /// </para>
        /// </remarks>
        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }


        /// <summary>
        /// The URI of a document which describes the error in
        /// detail. This corresponds to the <c>error_uri</c>
        /// property in the response to the client.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this optional request parameter is given, its value
        /// is used as the value of the <c>error_uri</c> property,
        /// but it is used only when the result is not
        /// <c>BackchannelAuthenticationCompleteResult.AUTHORIZED</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("errorUri")]
        public Uri ErrorUri { get; set; }
    }
}
