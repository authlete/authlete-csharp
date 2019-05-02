//
// Copyright (C) 2018-2019 Authlete, Inc.
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
    /// Request to Authlete's <c>/api/auth/token/update</c> API.
    /// </summary>
    public class TokenUpdateRequest
    {
        /// <summary>
        /// An access token to be updated.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// A new date at which the acces token will expire. The
        /// value needs to be expressed in milliseconds since the
        /// Unix epoch (1970-Jan-1). If <c>0</c> or a negative
        /// value is given, the expiration date of the access token
        /// is not changed.
        /// </summary>
        [JsonProperty("accessTokenExpiresAt")]
        public long AccessTokenExpiresAt { get; set; }


        /// <summary>
        /// A new set of scopes assigned to the access token. If
        /// <c>null</c> is given, the scope set associated with
        /// the access token is not changed.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }


        /// <summary>
        /// A new set of properties assigned to the access token.
        /// If <c>null</c> is given, the property set associated
        /// with the access token is not changed.
        /// </summary>
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }


        /// <summary>
        /// The flag which indicates whether
        /// <c>/api/auth/token/update</c> API attempts to update
        /// the expiration date of the access token when the scopes
        /// linked to the access token are changed by this request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This request parameter is optional and its default
        /// value is <c>false</c>. If this request parameter is set
        /// to <c>true</c> and all of the following conditions are
        /// satisfied, the API performs an update on the expiration
        /// date of the access token even if the
        /// <c>accessTokenExpiresAt</c> request parameter is not
        /// explicitly specified in the request.
        /// </para>
        ///
        /// <list type="number">
        /// <item>
        /// <description>
        /// The <c>accessTokenExpiresAt</c> request parameter is
        /// not included in the request or its value is <c>0</c>
        /// (or negative).
        /// </description>
        /// </item>
        ///
        /// <item>
        /// <description>
        /// The scopes linked to the access token are changed by
        /// the <c>scopes</c> request parameter in the request.
        /// </description>
        /// </item>
        ///
        /// <item>
        /// <description>
        /// Any of the new scopes to be linked to the access token
        /// has one or more attributes specifying access token
        /// duration.
        /// </description>
        /// </item>
        /// </list>
        ///
        /// <para>
        /// When multiple access token duration values are found in
        /// the attributes of the specified scopes, the smallest
        /// value among them is used.
        /// </para>
        ///
        /// <para>
        /// For more details, see the following examples.
        /// </para>
        ///
        /// <hr/>
        ///
        /// <para><b>Example 1.</b></para>
        ///
        /// <para>
        /// Let's say we send the following request to
        /// <c>/api/auth/token/update</c> API.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "accessToken" : "JDGiiM9PuWT63FIwGjG9eYlGi-aZMq6CQ2IB475JUxs",
        ///   "scopes" : ["read_profile"]
        /// }
        /// </code>
        ///
        /// <para>
        /// and <c>"read_profile"</c> has the following attributes.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "key" : "access_token.duration",
        ///   "value" : "10000"
        /// }
        /// </code>
        ///
        /// <para>
        /// In this case, the API evaluates <c>"10000"</c> as a new
        /// value of the duration of the access token (in seconds)
        /// and updates the expiration date of the access token
        /// using the duration.
        /// </para>
        ///
        /// <hr/>
        ///
        /// <para><b>Example 2.</b></para>
        ///
        /// <para>
        /// Let's say we send the following request to
        /// <c>/api/auth/token/update</c> API.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "accessToken" : "JDGiiM9PuWT63FIwGjG9eYlGi-aZMq6CQ2IB475JUxs",
        ///   "scopes" : ["read_profile", "write_profile"]
        /// }
        /// </code>
        ///
        /// <para>
        /// and <c>"read_profile"</c> has the following attributes.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "key" : "access_token.duration",
        ///   "value" : "10000"
        /// }
        /// </code>
        ///
        /// <para>
        /// and <c>"write_profile"</c> has the following attributes.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "key" : "access_token.duration",
        ///   "value" : "5000"
        /// }
        /// </code>
        ///
        /// <para>
        /// In this case, the API evaluates <c>"10000"</c> and
        /// <c>"5000"</c> as candidate values for new duration of
        /// the access token (in seconds) and chooses the smallest
        /// value of them (i.e. "5000" is adopted) and updates the
        /// expiration date of the access token using the duration.
        /// </para>
        ///
        /// <hr/>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenExpiresAtUpdatedOnScopeUpdate")]
        public bool IsAccessTokenExpiresAtUpdatedOnScopeUpdate { get; set; }


        /// <summary>
        /// The flag which indicates whether the access token
        /// expires or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// By default, all access tokens expire after a period of
        /// time determined by their service. If this request
        /// parameter is <c>true</c> then the access token will not
        /// automatically expire and must be revoked or deleted
        /// manually at the service.
        /// </para>
        ///
        /// <para>
        /// If this request parameter is <c>true</c>, the
        /// <c>accessTokenExpiresAt</c> request parameter is
        /// ignored. If this request parameter is <c>false</c>,
        /// the <c>accessTokenExpiresAt</c> request parameter is
        /// processed normally.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenPersistent")]
        public bool IsAccessTokenPersistent { get; set; }


        /// <summary>
        /// The hash of the access token value.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Used when the hash of the token is known (perhaps from
        /// lookup) but the value of the token itself is not. The
        /// value of the <c>accessToken</c> parameter takes
        /// precedence.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenHash")]
        public string AccessTokenHash { get; set; }


        /// <summary>
        /// The flag which indicates whether to update the value of
        /// the access token in the data store.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If this parameter is set to <c>true</c>, then a new
        /// access token value is generated by the server and
        /// returned in the response. If <c>false</c> (the default
        /// value), the current value of the access token is not
        /// changed.
        /// </para>
        ///
        /// <para>
        /// Since version 1.3.0.
        /// </para>
        /// </remarks>
        [JsonProperty("accessTokenValueUpdated")]
        public bool IsAccessTokenValueUpdated { get; set; }
    }
}
