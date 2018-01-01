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
    /// A property associated with an access token and/or an
    /// authorization code. Some Authlete APIs accept a
    /// <c>"properties"</c> request parameter. The value of the
    /// parameter is an array of <c>Property</c>.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// The default constructor. This is an alias of
        /// <c>Property(null, null, false)</c>.
        /// </summary>
        public Property()
            : this(null, null, false)
        {
        }


        /// <summary>
        /// Constructor with a pair of key and value. This is an
        /// alias of <c>Property(key, value, false)</c>.
        /// </summary>
        ///
        /// <param name="key">
        /// The name of this property.
        /// </param>
        ///
        /// <param name="value">
        /// The value of this property.
        /// </param>
        public Property(string key, string value)
            : this(key, value, false)
        {
        }


        /// <summary>
        /// Constructor with a pair of key and value, and a flag to
        /// mark this property as hidden or not.
        /// </summary>
        ///
        /// <param name="key">
        /// The name of this property.
        /// </param>
        ///
        /// <param name="value">
        /// The value of this property.
        /// </param>
        ///
        /// <param name="hidden">
        /// <c>true</c> to mark this property as hidden. Read the
        /// description about <c>IsHidden</c> for details.
        /// </param>
        public Property(string key, string value, bool hidden)
        {
            Key      = key;
            Value    = value;
            IsHidden = hidden;
        }


        /// <summary>
        /// The name of this property.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }


        /// <summary>
        /// The value of this property.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }


        /// <summary>
        /// The flag which indicates whether this property is
        /// hidden from the client application or not.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If a property is not hidden, information about the
        /// property will be sent back to the client application
        /// with an access token. For example, if you set the
        /// <c>"properties"</c> request prameter as follows when
        /// you call Authlete's <c>/api/auth/token</c> API,
        /// </para>
        ///
        /// <code>
        /// "properties": [
        ///   {
        ///     "key":    "example_parameter",
        ///     "value":  "example_value",
        ///     "hidden": false
        ///   }
        /// ]
        /// </code>
        ///
        /// <para>
        /// The value of the <c>"responseContent"</c> response
        /// parameter in the response from the API will contain
        /// the pair of <c>"example_parameter"</c> and
        /// <c>"example_value"</c> like below.
        /// </para>
        ///
        /// <code>
        /// "responseContent":
        ///   "{\"access_token\":\"(abbrev)\",\"example_parameter\":\"example_value\",...}"
        /// </code>
        ///
        /// <para>
        /// and this will result in that the client application
        /// will receive a JSON which contains the pair like the
        /// following.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "access_token": "(abbrev)",
        ///   "example_parameter": "example_value",
        ///   ...
        /// }
        /// </code>
        ///
        /// <para>
        /// On the other hand, if you mark a property as
        /// <i>hidden</i> like below,
        /// </para>
        ///
        /// <code>
        /// "properties": [
        ///   {
        ///     "key":    "hidden_parameter",
        ///     "value":  "hidden_value",
        ///     "hidden": true
        ///   }
        /// ]
        /// </code>
        ///
        /// <para>
        /// the client application will never see the property in
        /// any response from your authorization server. However,
        /// of course, the property is still associated with the
        /// access token and it can be confirmed by calling
        /// Authlete's <c>/api/auth/introspection</c> API (which is
        /// an API to get information about an access token). A
        /// response from the API contains all properties
        /// associated with the given access token regardless of
        /// whether they are hidden or visible. The following is
        /// an example response from Authlete's
        /// <c>/api/auth/introspection</c> API.
        /// </para>
        ///
        /// <code>
        /// {
        ///   "type":"introspectionResponse",
        ///   "resultCode":"A056001",
        ///   "resultMessage":"[A056001] The access token is valid.",
        ///   "action":"OK",
        ///   "clientId":5008706718,
        ///   "existent":true,
        ///   "expiresAt":1463310477000,
        ///   "properties":[
        ///     {
        ///       "hidden":false,
        ///       "key":"example_parameter",
        ///       "value":"example_value"
        ///     },
        ///     {
        ///       "hidden":true,
        ///       "key":"hidden_parameter",
        ///       "value":"hidden_value"
        ///     }
        ///   ],
        ///   "refreshable":true,
        ///   "responseContent":"Bearer error=\"invalid_request\"",
        ///   "subject":"user123",
        ///   "sufficient":true,
        ///   "usable":true
        /// }
        /// </code>
        /// </remarks>
        [JsonProperty("hidden")]
        public bool IsHidden { get; set; }
    }
}
