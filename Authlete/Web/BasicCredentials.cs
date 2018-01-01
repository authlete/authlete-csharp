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


using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using static Authlete.Util.TextUtility;


namespace Authlete.Web
{
    /// <summary>
    /// A class that represents a pair of user ID and password and
    /// provides <c>Formatted</c> property which returns a string
    /// suitable as a value of <c>Authorization</c> header for
    /// Basic Authentication.
    /// </summary>
    public class BasicCredentials
    {
        static readonly Regex CHALLENGE_PATTERN;
        static readonly char[] SEPARATOR = { ':' };


        static BasicCredentials()
        {
            // Create a regular expression for "Basic {value}".
            CHALLENGE_PATTERN = new Regex(
                "^Basic *([^ ]+) *$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled
            );
        }


        /// <summary>
        /// Constructor with a pair of user ID and password.
        /// </summary>
        public BasicCredentials(string userId, string password)
        {
            UserId    = userId;
            Password  = password;
            Formatted = Format(userId, password);
        }


        /// <summary>
        /// The user ID.
        /// </summary>
        public string UserId { get; }


        /// <summary>
        /// The password.
        /// </summary>
        public string Password { get; }


        /// <summary>
        /// A string in <c>"Basic {base64-encoded-string}"</c>
        /// format which is suitable as a value of
        /// <c>Authorization</c> header for Basic Authentication.
        /// </summary>
        public string Formatted { get; }


        /// <summary>
        /// Format the credentials into
        /// "Basic {base64-encoded-string}" which is suitable as a
        /// value of <c>Authorization</c> header for Basic
        /// Authentication.
        /// </summary>
        static string Format(string userId, string password)
        {
            // Build a plain text, "{userId}:{password}".
            string plainText = $"{userId ?? ""}:{password ?? ""}";

            // Encode the plain text by Base64.
            string base64string = Base64Encode(plainText);

            // Build a string suitable for Basic Authentication.
            return $"Basic {base64string}";
        }


        /// <summary>
        /// Create a <c>BasicCredentials</c> instance from the
        /// given <c>AuthenticationHeaderValue</c> instance.
        /// If <c>null</c> is given or if the scheme of the
        /// <c>AuthenticationHeaderValue</c> instance is not
        /// <c>"Basic"</c>, a <c>BasicCredentials</c> instance
        /// whose <c>UserId</c> and <c>Password</c> are both
        /// <c>null</c> is returned.
        /// </summary>
        ///
        /// <returns>
        /// A <c>BasicCredentials</c> instance generated based on
        /// the information of the given
        /// <c>AuthenticationHeaderValue</c> instance.
        /// </returns>
        ///
        /// <param name="value">
        /// A value of <c>Authorization</c> header whose scheme is
        /// <c>"Basic"</c>.
        /// </param>
        public static BasicCredentials Parse(AuthenticationHeaderValue value)
        {
            // If the scheme is not "Basic".
            if (value == null ||
                EqualsIgnoreCase("Basic", value.Scheme) == false)
            {
                return new BasicCredentials(null, null);
            }

            // Build a BasicCredentials instance from the
            // base64 expression of "{UserId}:{Password}".
            return BuildFromParameter(value.Parameter);
        }


        /// <summary>
        /// Create a <c>BasicCredentials</c> instance from the
        /// given string whose format is expected to be
        /// <c>"Basic {base64-encoded-string}"</c>. If the given
        /// string is <c>null</c> or it does not match the pattern,
        /// a <c>BasicCredentials</c> instance whose <c>UserId</c>
        /// and <c>Password</c> are both <c>null</c> is returned.
        /// </summary>
        ///
        /// <returns>
        /// A <c>BasicCredentials</c> instance generated based on
        /// the information of the given string.
        /// </returns>
        ///
        /// <param name="value">
        /// A value of <c>Authorization</c> header whose scheme is
        /// <c>"Basic"</c>.
        /// </param>
        public static BasicCredentials Parse(string value)
        {
            if (value == null)
            {
                // UserId = null, Password = null
                return new BasicCredentials(null, null);
            }

            // Expecting the input matches "Basic {base64string}".
            var matches = CHALLENGE_PATTERN.Matches(value);

            // If not matched.
            if (matches.Count != 1)
            {
                // UserId = null, Password = null
                return new BasicCredentials(null, null);
            }

            // Base64-encoded "UserId:Password".
            string base64String = matches[0].Value;

            // Build a BasicCredentials instance from the
            // base64 expression of "{UserId}:{Password}".
            return BuildFromParameter(base64String);
        }


        /// <summary>
        /// Build a <c>BasicCredentials</c> instance from a
        /// base64 expression of "{UserId}:{Password}".
        /// </summary>
        static BasicCredentials BuildFromParameter(string base64String)
        {
            if (base64String == null)
            {
                // UserId = null, Password = null
                return new BasicCredentials(null, null);
            }

            // Decode the Base64 string.
            string plainText = Base64Decode(base64String);

            // Split "UserId:Password" into "UserId" and "Password".
            string[] substrings = plainText.Split(SEPARATOR, 2);

            string userId   = null;
            string password = null;

            // User ID
            if (1 <= substrings.Length)
            {
                userId = substrings[0];
            }

            // Password
            if (2 <= substrings.Length)
            {
                password = substrings[1];
            }

            return new BasicCredentials(userId, password);
        }
    }
}
