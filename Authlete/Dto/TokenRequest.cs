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


namespace Authlete.Dto
{
    /// <summary>
    /// Request to Authlete's <c>/api/auth/token</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An entity body of a token request may contain the client ID
    /// (<c>client_id</c>) and the client secret (<c>client_secret</c>)
    /// along with other request parameters as described in
    /// <a href="http://tools.ietf.org/html/rfc6749#section-2.3.1">2.3.1.
    /// Client Password</a> of
    /// <a href="http://tools.ietf.org/html/rfc6749">RFC 6749</a>.
    /// If client credentials are contained both in the
    /// <c>Authorization</c> header and in the entity body, they
    /// must be identical. If they do not match, Authlete's
    /// <c>/api/auth/token</c> API reports an error. It is not an
    /// error of your authorization server implementation but an
    /// error of the client application.
    /// </para>
    /// </remarks>
    public class TokenRequest
    {
        /// <summary>
        /// Token request parameters which the token endpoint
        /// implementation of your authorization server received
        /// from a client application. The value of this request
        /// parameter is the entire entity body (which is formatted
        /// in <c>application/x-www-form-urlencoded</c>) of the
        /// request from the client application. This request
        /// parameter is mandatory.
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }


        /// <summary>
        /// The client ID extracted from the <c>Authorization</c>
        /// header of the token request from the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the token endpoint of the authorization server
        /// supports Basic Authentication as a means of
        /// <a href="http://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client ID in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set as the value of this
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }


        /// <summary>
        /// The client secret extracted from the <c>Authorization</c>
        /// header of the token request from the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the token endpoint of the authorization server
        /// supports Basic Authentication as a means of
        /// <a href="http://tools.ietf.org/html/rfc6749#section-2.3">client
        /// authentication</a>, and if the request from the client
        /// application contained its client secret in the
        /// <c>Authorization</c> header, the value should be
        /// extracted from there and set as the value of this
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }


        /// <summary>
        /// Extra properties to be associated with an access token
        /// which may be issued as a result of the token request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the value of the <c>"grant_type"</c> parameter
        /// contained in the token request from the client
        /// application is <c>"authorization_code"</c>, properties
        /// set by this request parameter will be added as the
        /// extra properties of a newly created access token. The
        /// extra properties specified when the authorization code
        /// was issued (using
        /// <c>AuthorizationIssueRequest.Properties</c>) will also
        /// be used, but their values will be overwritten if the
        /// extra properties set by this request parameter have the
        /// same keys. In other words, extra properties contained
        /// in this request will be merged into existing extra
        /// properties which are associated with the authorization
        /// code.
        /// </para>
        ///
        /// <para>
        /// Otherwise, if the value of the <c>"grant_type"</c>
        /// parameter contained in the token request from the
        /// client application is <c>"refresh_token"</c>, properties
        /// set by this request parameter will be added to the
        /// existing extra properties of the corresponding access
        /// token. Extra properties having the same keys will be
        /// overwritten in the same manner as the case of
        /// <c>grant_type=authorization_code</c>.
        /// </para>
        ///
        /// <para>
        /// Otherwise, if the value of the <c>"grant_type"</c>
        /// parameter contained in the token request from the
        /// client application is <c>"client_credentials"</c>,
        /// properties set by this request parameter will be used
        /// simply as extra properties of a newly created access
        /// token. Because
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.4">Client
        /// Credentials flow</a> does not have a preceding
        /// authorization request, merging extra properties will
        /// not be performed. This is different from the cases of
        /// <c>grant_type=authorization_code</c> and
        /// <c>grant_type=refresh_token</c>.
        /// </para>
        ///
        /// <para>
        /// In other cases (<c>grant_type=password</c>), properties
        /// set by this request parameter will not be used. When
        /// you want to associate extra properties with an access
        /// token which is issued by
        /// <a href="https://tools.ietf.org/html/rfc6749#section-4.3">Resource
        /// Owner Password Credentials flow</a>, use
        /// <c>TokenIssueRequest.Properties</c> instead.
        /// </para>
        ///
        /// <para>
        /// Keys of extra properties will be used as labels of
        /// top-level entries in a JSON response containing an
        /// access token which is returned from an authorization
        /// server. An example is <c>example_parameter</c>, which
        /// you can find in
        /// <a href="https://tools.ietf.org/html/rfc6749#section-5.1">5.1.
        /// Successful Response</a> of
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>.
        /// The following code snippet is an example to set one
        /// extra property having <c>"example_parameter"</c> as its
        /// key and <c>"example_value"</c> as its value.
        /// </para>
        ///
        /// <code>
        /// request.Properties = new Property[] {
        ///     new Property("example_parameter", "example_value")
        /// };
        /// </code>
        ///
        /// <para>
        /// Keys listed below should not be used and they would be
        /// ignored on Authlete side even if they were used. It's
        /// because they are reserved in
        /// <a href="https://tools.ietf.org/html/rfc6749">RFC 6749</a>
        /// and
        /// <a href="http://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// OpenID Connect Core 1.0</a>.
        /// </para>
        ///
        /// <list type="bullet">
        ///   <item><description><c>token_type</c></description></item>
        ///   <item><description><c>expires_in</c></description></item>
        ///   <item><description><c>refresh_token</c></description></item>
        ///   <item><description><c>scope</c></description></item>
        ///   <item><description><c>error</c></description></item>
        ///   <item><description><c>error_description</c></description></item>
        ///   <item><description><c>error_uri</c></description></item>
        ///   <item><description><c>id_token</c></description></item>
        /// </list>
        ///
        /// <para>
        /// Note that there is an upper limit on the total size of
        /// extra properties. On the server side, the properties
        /// will be (1) converted to a multidimensional string
        /// array, (2) converted to JSON, (3) encrypted by
        /// AES/CBC/PKCS5Padding, (4) encoded by base64url, and
        /// then stored into the database. The length of the
        /// resultant string must not exceed 65,535 in bytes. This
        /// is the upper limit, but we think it is big enough.
        /// </para>
        /// </remarks>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }
}
