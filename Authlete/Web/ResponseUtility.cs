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


using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace Authlete.Web
{
    /// <summary>
    /// Utility to generate <c>HttpResponseMessage</c> instances.
    /// </summary>
    public static class ResponseUtility
    {
        // Separator between the scheme part and the parameter part
        // of WWW-Authenticate header values.
        static readonly char[] CHALLENGE_SEPARATORS = { ' ', '\t' };


        /// <summary>
        /// Create a response of <c>"200 OK"</c> with a content in
        /// <c>"application/json;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage OkJson(string content)
        {
            // 200 OK, application/json;charset=UTF-8
            return BuildResponseJson(HttpStatusCode.OK, content);
        }


        /// <summary>
        /// Create a response of <c>"200 OK"</c> with a content in
        /// <c>"application/javascript;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// JavaScript
        /// </param>
        public static HttpResponseMessage OkJavaScript(string content)
        {
            // 200 OK, application/javascript;charset=UTF-8
            return BuildResponseJavaScript(HttpStatusCode.OK, content);
        }


        /// <summary>
        /// Create a response of <c>"200 OK"</c> with a content in
        /// <c>"application/jwt"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage OkJwt(string content)
        {
            // 200 OK, application/jwt
            return BuildResponseJwt(HttpStatusCode.OK, content);
        }


        /// <summary>
        /// Create a response of <c>"200 OK"</c> with a content in
        /// <c>"text/html;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in HTML format.
        /// </param>
        public static HttpResponseMessage OkHtml(string content)
        {
            // 200 OK, text/html;charset=UTF-8
            return BuildResponseHtml(HttpStatusCode.OK, content);
        }


        /// <summary>
        /// Create a response of <c>"204 No Content"</c>.
        /// </summary>
        public static HttpResponseMessage NoContent()
        {
            // 204 No Content
            return BuildResponseBase(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Create a response of <c>"302 Found"</c> with a
        /// <c>Location</c> header.
        /// </summary>
        ///
        /// <param name="location">
        /// A value of <c>Location</c> header.
        /// </param>
        public static HttpResponseMessage Location(Uri location)
        {
            // 302 Found
            HttpResponseMessage response =
                BuildResponseBase(HttpStatusCode.Found);

            // Location: {location}
            response.Headers.Location = location;

            return response;
        }


        /// <summary>
        /// Create a response of <c>"302 Found"</c> with a
        /// <c>Location</c> header.
        /// </summary>
        ///
        /// <param name="location">
        /// A value of <c>Location</c> header.
        /// </param>
        public static HttpResponseMessage Location(string location)
        {
            return Location(new Uri(location));
        }


        /// <summary>
        /// Create a response of <c>"400 Bad Request"</c> with a
        /// content in <c>"application/json;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage BadRequest(string content)
        {
            // 400 Bad Request, application/json;charset=UTF-8
            return BuildResponseJson(HttpStatusCode.BadRequest, content);
        }


        /// <summary>
        /// Create a response of <c>"401 Unauthorized"</c> with a
        /// <c>WWW-Authenticate</c> header.
        /// </summary>
        ///
        /// <param name="challenge">
        /// A value of <c>WWW-Authenticate</c> header.
        /// </param>
        ///
        /// <param name="content">
        /// Response body in JSON format, or <c>null</c>.
        /// </param>
        public static HttpResponseMessage Unauthorized(
            AuthenticationHeaderValue challenge, string content)
        {
            // 401 Unauthorized with a WWW-Authenticate header.
            HttpResponseMessage response =
                WwwAuthenticate(HttpStatusCode.Unauthorized, challenge);

            if (content != null)
            {
                response.Content = new StringContent(
                    content, new UTF8Encoding(), "application/json");
            }

            return response;
        }


        /// <summary>
        /// Create a response of <c>"401 Unauthorized"</c> with a
        /// <c>WWW-Authenticate</c> header.
        /// </summary>
        ///
        /// <param name="challenge">
        /// A value of <c>WWW-Authenticate</c> header.
        /// </param>
        public static HttpResponseMessage Unauthorized(string challenge)
        {
            return WwwAuthenticate(HttpStatusCode.Unauthorized, challenge);
        }


        /// <summary>
        /// Create a response of <c>"403 Forbidden"</c> with a
        /// content in <c>"application/json;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage Forbidden(string content)
        {
            // 403 Forbidden, application/json
            return BuildResponseJson(HttpStatusCode.Forbidden, content);
        }


        /// <summary>
        /// Create a response of <c>"404 Not Found"</c> with a
        /// content in <c>"application/json;charset=UTF-8"</c> format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage NotFound(string content)
        {
            // 404 Not Found, application/json
            return BuildResponseJson(HttpStatusCode.NotFound, content);
        }


        /// <summary>
        /// Create a response of <c>"500 Internal Server Error"</c>
        /// with a content in <c>"application/json;charset=UTF-8"</c>
        /// format.
        /// </summary>
        ///
        /// <param name="content">
        /// Response body in JSON format.
        /// </param>
        public static HttpResponseMessage InternalServerError(string content)
        {
            // 500 Internal Server Error, application/json
            return BuildResponseJson(HttpStatusCode.InternalServerError, content);
        }


        /// <summary>
        /// Create a response with a <c>WWW-Authenticate</c> header.
        /// </summary>
        ///
        /// <param name="statusCode">
        /// HTTP status code of the response.
        /// </param>
        ///
        /// <param name="challenge">
        /// The value of the <c>WWW-Authenticate</c> header.
        /// </param>
        public static HttpResponseMessage WwwAuthenticate(
            HttpStatusCode statusCode, AuthenticationHeaderValue challenge)
        {
            HttpResponseMessage response = BuildResponseBase(statusCode);

            if (challenge != null)
            {
                // WWW-Authenticate: {challenge}
                response.Headers.WwwAuthenticate.Add(challenge);
            }

            return response;
        }


        /// <summary>
        /// Create a response with a <c>WWW-Authenticate</c> header.
        /// </summary>
        ///
        /// <param name="statusCode">
        /// An HTTP status code.
        /// </param>
        ///
        /// <param name="challenge">
        /// A value of the <c>WWW-Authenticate</c> header.
        /// </param>
        public static HttpResponseMessage WwwAuthenticate(
            HttpStatusCode statusCode, string challenge)
        {
            // Value of WWW-Authenticate header.
            AuthenticationHeaderValue value = BuildWwwAuthenticateValue(challenge);

            return WwwAuthenticate(statusCode, value);
        }


        /// <summary>
        /// Build a <c>AuthenticationHeaderValue</c> instance from
        /// a string whose format is "{scheme} {parameter}".
        /// </summary>
        static AuthenticationHeaderValue BuildWwwAuthenticateValue(string challenge)
        {
            // Split the challenge into the scheme part and
            // the parameter part.
            string[] substrings = challenge.Split(
                CHALLENGE_SEPARATORS, 2,
                StringSplitOptions.RemoveEmptyEntries);

            switch (substrings.Length)
            {
                case 2:
                    // Scheme and parameter.
                    return new AuthenticationHeaderValue(substrings[0], substrings[1]);

                case 1:
                    // Hmm. Scheme only.
                    return new AuthenticationHeaderValue(substrings[0]);

                default:
                    // Hmm. The given challenge is wrong.
                    return null;
            }
        }


        /// <summary>
        /// Build a response which has the specified HTTP status
        /// code, "<c>Cache-Control: no-store</c>" header and
        /// "<c>Pragma: no-cache</c>" header.
        /// </summary>
        static HttpResponseMessage BuildResponseBase(HttpStatusCode statusCode)
        {
            // Create a response with an HTTP status code.
            var response = new HttpResponseMessage(statusCode);

            // Cache-Control: no-store
            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                NoStore = true
            };

            // Pragma: no-cache
            response.Headers.Pragma.Add(new NameValueHeaderValue("no-cache"));

            return response;
        }


        /// <summary>
        /// Build a response whose body is a JSON.
        /// </summary>
        static HttpResponseMessage BuildResponseJson(
            HttpStatusCode statusCode, string content)
        {
            HttpResponseMessage response = BuildResponseBase(statusCode);

            // Content-Type: application/json;charset=UTF-8
            response.Content = new StringContent(
                content, new UTF8Encoding(), "application/json");

            return response;
        }


        /// <summary>
        /// Build a response whose body is JavaScript.
        /// </summary>
        static HttpResponseMessage BuildResponseJavaScript(
            HttpStatusCode statusCode, string content)
        {
            HttpResponseMessage response = BuildResponseBase(statusCode);

            // Content-Type: application/javascript;charset=UTF-8
            response.Content = new StringContent(
                content, new UTF8Encoding(), "application/javascript");

            return response;
        }


        /// <summary>
        /// Build a response whose body is a JWT.
        /// </summary>
        static HttpResponseMessage BuildResponseJwt(
            HttpStatusCode statusCode, string content)
        {
            HttpResponseMessage response = BuildResponseBase(statusCode);

            // Content-Type: application/jwt
            response.Content = new StringContent(
                content, null, "application/jwt");

            return response;
        }


        /// <summary>
        /// Build a response whose body is an HTML.
        /// </summary>
        static HttpResponseMessage BuildResponseHtml(
            HttpStatusCode statusCode, string content)
        {
            HttpResponseMessage response = BuildResponseBase(statusCode);

            // Content-Type: text/html;charset=UTF-8
            response.Content = new StringContent(
                content, new UTF8Encoding(), "text/html");

            return response;
        }
    }
}
