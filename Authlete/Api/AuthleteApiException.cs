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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Authlete.Api
{
    /// <summary>
    /// Exception that <c>IAuthleteApi</c> methods may throw.
    /// </summary>
    public class AuthleteApiException : Exception
    {
        /// <summary>
        /// Constructor without information about an HTTP response.
        /// </summary>
        ///
        /// <param name="message">
        /// An error message.
        /// </param>
        ///
        /// <param name="cause">
        /// The cause of this exception.
        /// </param>
        ///
        /// <param name="request">
        /// The request to the API that triggered this exception.
        /// </param>
        public AuthleteApiException(
            string message, Exception cause,
            HttpRequestMessage request)
            : base(message, cause)
        {
            Request = request;
        }


        /// <summary>
        /// Constructor with some data of an HTTP response.
        /// </summary>
        ///
        /// <param name="message">
        /// An error message.
        /// </param>
        ///
        /// <param name="cause">
        /// The cause of this exception.
        /// </param>
        ///
        /// <param name="request">
        /// The request to the API that triggered this exception.
        /// </param>
        ///
        /// <param name="statusCode">
        /// The HTTP status code of the response from the API.
        /// </param>
        ///
        /// <param name="reasonPhrase">
        /// The reason phrase of the response from the API.
        /// </param>
        ///
        /// <param name="headers">
        /// The HTTP headers of the response from the API.
        /// </param>
        public AuthleteApiException(
            string message, Exception cause,
            HttpRequestMessage request, HttpStatusCode statusCode,
            string reasonPhrase, HttpResponseHeaders headers)
            : base(message, cause)
        {
            Request         = request;
            StatusCode      = statusCode;
            ReasonPhrase    = reasonPhrase;
            ResponseHeaders = headers;
        }


        /// <summary>
        /// Constructor with some data of an HTTP response.
        /// </summary>
        ///
        /// <param name="message">
        /// An error message.
        /// </param>
        ///
        /// <param name="request">
        /// The request to the API that triggered this exception.
        /// </param>
        ///
        /// <param name="statusCode">
        /// The HTTP status code of the response from the API.
        /// </param>
        ///
        /// <param name="reasonPhrase">
        /// The reason phrase of the response from the API.
        /// </param>
        ///
        /// <param name="headers">
        /// The HTTP headers of the response from the API.
        /// </param>
        ///
        /// <param name="body">
        /// The entity body of the response from the API.
        /// </param>
        public AuthleteApiException(
            string message,
            HttpRequestMessage request, HttpStatusCode statusCode,
            string reasonPhrase, HttpResponseHeaders headers,
            string body)
            : base(message)
        {
            Request         = request;
            StatusCode      = statusCode;
            ReasonPhrase    = reasonPhrase;
            ResponseHeaders = headers;
            ResponseBody    = body;
        }


        /// <summary>
        /// The HTTP request to the Authlete API.
        /// </summary>
        public HttpRequestMessage Request { get; }


        /// <summary>
        /// The HTTP status code of the response from the Authlete
        /// API. This property will return <c>null</c> if an error
        /// occurred before the response was properly processed.
        /// </summary>
        public HttpStatusCode StatusCode { get; }


        /// <summary>
        /// The reason phrase of the response from the Authlete API.
        /// This property will return <c>null</c> if an error
        /// occurred before the response was properly processed.
        /// </summary>
        public string ReasonPhrase { get; }


        /// <summary>
        /// The HTTP headers of the response from the Authlete API.
        /// This property will return <c>null</c> if an error
        /// occurred before the response was properly processed.
        /// </summary>
        public HttpResponseHeaders ResponseHeaders { get; }


        /// <summary>
        /// The content of the response from the Authlete API.
        /// This property will return <c>null</c> if the response
        /// did not have any content or if an error occurred before
        /// the response was properly processed.
        /// </summary>
        public string ResponseBody { get; }
    }
}
