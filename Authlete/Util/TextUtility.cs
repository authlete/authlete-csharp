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


using System.Net;
using Newtonsoft.Json;


namespace Authlete.Util
{
    /// <summary>
    /// Text utility.
    /// </summary>
    public static class TextUtility
    {
        /// <summary>
        /// Convert a plain text into a Base64-encoded string.
        /// </summary>
        ///
        /// <returns>
        /// A Base64-encoded string.
        /// </returns>
        ///
        /// <param name="plainText">
        /// A plain text. If <c>null</c> is given, <c>null</c> is
        /// returned.
        /// </param>
        public static string Base64Encode(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            // Convert the plain text into a byte array.
            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            // Convert the byte array into a Base64-encoded string.
            return System.Convert.ToBase64String(plainBytes);
        }


        /// <summary>
        /// Convert a Base64-encoded string into a plain text.
        /// </summary>
        ///
        /// <returns>
        /// A plain text.
        /// </returns>
        ///
        /// <param name="base64String">
        /// A Base64-encoded string. If <c>null</c> is given,
        /// <c>null</c> is returned.
        /// </param>
        public static string Base64Decode(string base64String)
        {
            if (base64String == null)
            {
                return null;
            }

            // Decode the Base64-encoded string.
            byte[] plainBytes = System.Convert.FromBase64String(base64String);

            // Convert the byte array into a plain text, assuming
            // that the byte array represents a valid UTF-8 string.
            return System.Text.Encoding.UTF8.GetString(plainBytes);
        }


        /// <summary>
        /// Convert a plain text into a URL-encoded string.
        /// </summary>
        ///
        /// <returns>
        /// A URL-encoded string.
        /// </returns>
        ///
        /// <param name="plainText">
        /// A plain text. If <c>null</c> is given, <c>null</c> is
        /// returned.
        /// </param>
        public static string UrlEncode(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            // Convert the plain text into a URL-encoded string.
            return WebUtility.UrlEncode(plainText);
        }


        /// <summary>
        /// Convert a URL-encoded string into a plain text.
        /// </summary>
        ///
        /// <returns>
        /// A plain text.
        /// </returns>
        ///
        /// <param name="encodedString">
        /// A URL-encoded string. If <c>null</c> is given,
        /// <c>null</c> is returned.
        /// </param>
        public static string UrlDecode(string encodedString)
        {
            if (encodedString == null)
            {
                return null;
            }

            // Convert the URL-encoded string into a plain text,
            // assuming the given string is a valid URL-encoded
            // string.
            return WebUtility.UrlDecode(encodedString);
        }


        /// <summary>
        /// Convert a character which represents a hex digit
        /// (<c>0-9</c>, <c>A-F</c>, <c>a-f</c>) to an integer
        /// (from 0 to 15). If the given character is not a hex
        /// digit, <c>null</c> is returned.
        /// </summary>
        ///
        /// <param name="c">
        /// A hex digit (<c>0-9</c>, <c>A-F</c>, <c>a-f</c>).
        /// </param>
        public static int? HexToInt(char c)
        {
            // 0-9
            if ('0' <= c && c <= '9')
            {
                return (c - '0');
            }

            // A-F
            if ('A' <= c && c <= 'F')
            {
                return (c - 'A' + 10);
            }

            // a-f
            if ('a' <= c && c <= 'f')
            {
                return (c - 'a' + 10);
            }

            // Invalid character.
            return null;
        }


        /// <summary>
        /// Convert a JSON string into an object.
        /// </summary>
        ///
        /// <returns>
        /// An object.
        /// </returns>
        ///
        /// <param name="json">
        /// A JSON string. If <c>null</c> is given, the default
        /// value of the type is returned.
        /// </param>
        ///
        /// <typeparam name="T">
        /// The type of the output object.
        /// </typeparam>
        public static T FromJson<T>(string json)
        {
            if (json == null)
            {
                return default(T);
            }

            // Convert the JSON string into an object.
            return JsonConvert.DeserializeObject<T>(json);
        }


        /// <summary>
        /// Convert an object into a JSON string.
        /// </summary>
        ///
        /// <returns>
        /// A JSON string.
        /// </returns>
        ///
        /// <param name="obj">
        /// An object. If <c>null</c> is given, <c>null</c> is
        /// returned.
        /// </param>
        public static string ToJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            // Convert the object into a JSON string.
            return JsonConvert.SerializeObject(obj);
        }


        /// <summary>
        /// Compare two strings with the
        /// <c>OrdinalIgnoreCase</c> rule and returns <c>true</c>
        /// if they are equal.
        /// </summary>
        public static bool EqualsIgnoreCase(string s1, string s2)
        {
            return string.Equals(
                s1, s2, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
