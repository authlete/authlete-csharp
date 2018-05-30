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
using System.Threading.Tasks;
using Authlete.Api;
using Authlete.Dto;


namespace Authlete.Web
{
    /// <summary>
    /// Access token validator.
    /// </summary>
    ///
    /// <example>
    /// <code>
    /// // An implementation of IAuthleteApi interface.
    /// IAuthleteApi api = ...;
    ///
    /// // Create an access token validator.
    /// var validator = new AccessTokenValidator(api);
    ///
    /// // Extract an access token from the request.
    /// string accessToken = ...;
    ///
    /// // Validate the access token. Note that Validate() method
    /// // can take optional parameters, 'requiredScopes' and
    /// // 'requiredSubject' in addition to 'accessToken'.
    /// bool valid = await validator.Validate(accessToken);
    ///
    /// // If the access token is not valid.
    /// if (valid == false)  // 'if (validator.IsValid)' works, too.
    /// {
    ///     // If the call to /api/auth/introspection API made by
    ///     // the implementation of Validate() method succeeded,
    ///     // the 'IntrospectionResult' property holds the
    ///     // response from the API.
    ///     IntrospectionResponse info = validator.IntrospectionResult;
    ///
    ///     // When Validate() method returns false, the
    ///     // 'ErrorResponse' property holds an error response
    ///     // that complies with RFC 6750.
    ///     HttpResponseMessage response = validator.ErrorResponse;
    ///
    ///     // Return the error response to the client application.
    ///     return response;
    /// }
    ///
    /// // The access token is valid. The 'IntrospectionResult'
    /// // property holds the response from /api/auth/introspection.
    /// IntrospectionResponse info = validator.IntrospectionResult;
    /// </code>
    /// </example>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.0.7.
    /// </para>
    /// </remarks>
    public class AccessTokenValidator
    {
        readonly IAuthleteApi _api;


        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="api">
        /// An implementation of the <c>IAuthleteApi</c> interface.
        /// This is required because <c>Validate()</c> method
        /// internally calls Authlete's <c>/api/auth/introspection</c>
        /// API.
        /// </param>
        public AccessTokenValidator(IAuthleteApi api)
        {
            _api = api;
        }


        /// <summary>
        /// The flag whether the access token given to
        /// <c>Validate()</c> is valid or not. After a call of
        /// <c>Validate()</c> method, this property holds the same
        /// value returned from <c>Validate()</c>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// On entry of <c>Validate()</c> method, this property is
        /// reset to <c>false</c>.
        /// </para>
        /// </remarks>
        public Boolean IsValid { get; private set; }


        /// <summary>
        /// A response from Authlete's <c>/api/auth/introspection</c>
        /// API. <c>Validate()</c> method internally calls
        /// <c>/api/auth/introspection</c> API and sets the response
        /// to this property. Note that this property remains
        /// <c>null</c> if the API call threw an exception, and in
        /// that error case, the <c>IntrospectionError</c> property
        /// is set.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// On entry of <c>Validate()</c> method, this property is
        /// reset to <c>null</c>.
        /// </para>
        /// </remarks>
        public IntrospectionResponse IntrospectionResult { get; private set; }


        /// <summary>
        /// <c>Validate()</c> method internally calls Authlete's
        /// <c>/api/auth/introspection</c> API. If the API call
        /// threw an exception, the exception would be set to this
        /// property. Note that this property remains <c>null</c>
        /// if the API call succeeded, and in that successful case,
        /// the <c>IntrospectionResult</c> property is set.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// On entry of <c>Validate()</c> method, this property is
        /// reset to <c>null</c>.
        /// </para>
        /// </remarks>
        public Exception IntrospectionError { get; private set; }


        /// <summary>
        /// An error response that the API caller (here assuming
        /// that the API caller is an implementation of a protected
        /// resource endpoint) should return to the client
        /// application. This property is internally set by
        /// <c>Validate()</c> method when <c>Validate()</c> returns
        /// <c>false</c>. The error response complies with
        /// <a href="https://tools.ietf.org/html/rfc6750">RFC 6750</a>
        /// (The OAuth 2.0 Authorization Framework: Bearer Token
        /// Usage).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// On entry of <c>Validate()</c> method, this property is
        /// reset to <c>null</c>.
        /// </para>
        /// </remarks>
        public HttpResponseMessage ErrorResponse { get; private set; }


        /// <summary>
        /// Validate an access token.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// On entry, as the first step, the implementation of this
        /// method resets the following properties to <c>false</c>
        /// or <c>null</c>.
        /// </para>
        ///
        /// <list type="bullet">
        /// <item><description><c>IsValid</c></description></item>
        /// <item><description><c>IntrospectionResult</c></description></item>
        /// <item><description><c>IntrospectionError</c></description></item>
        /// <item><description><c>ErrorResponse</c></description></item>
        /// </list>
        ///
        /// <para>
        /// Then, this method internally calls Authlete's
        /// <c>/api/auth/introspection</c> API to get information
        /// about the access token.
        /// </para>
        ///
        /// <para>
        /// If the API call failed, the exception thrown by the API
        /// call is set to the <c>IntrospectionError</c> property
        /// and an error response (<c>500 Internal Server Error)</c>
        /// that should be returned to the client application is set
        /// to the <c>ErrorResponse</c> property. Then, this method
        /// sets <c>false</c> to the <c>IsValid</c> property and
        /// returns <c>false</c>.
        /// </para>
        ///
        /// <para>
        /// If the API call succeeded, the response from the API is
        /// set to the <c>IntrospectionResult</c> property. Then,
        /// the implementation of this method checks the value of
        /// the <c>"action"</c> parameter in the response from the
        /// API.
        /// </para>
        ///
        /// <para>
        /// If the value of the <c>"action"</c> parameter is
        /// <c>"OK"</c>, this method sets <c>true</c> to the
        /// <c>IsValid</c> property and returns <c>true</c>.
        /// </para>
        ///
        /// <para>
        /// If the value of the <c>"action"</c> parameter is not
        /// <c>"OK"</c>, this method builds an error response that
        /// should be returned to the client application and sets
        /// it to the <c>ErrorResponse</c> property. Then, this
        /// method sets <c>false</c> to the <c>IsValid</c> property
        /// and returns <c>false</c>.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// If the given access token exists and has not expired,
        /// and optionally if the access token covers all the
        /// required scopes (in case <c>requiredScopes</c> was
        /// given) and the access token is associated with the
        /// required subject (in case <c>requiredSubject</c> was
        /// given), this method returns <c>true</c>. In other cases,
        /// this method returns <c>false</c>.
        /// </returns>
        ///
        /// <param name="accessToken">
        /// An access token to be validated.
        /// </param>
        ///
        /// <param name="requiredScopes">
        /// Scopes that the access token should have. If a non-null
        /// value is given to this parameter, the implementation of
        /// Authlete's <c>/api/auth/introspection</c> API checks
        /// whether the access token covers all the required scopes.
        /// On the other hand, if <c>null</c> is given to this
        /// parameter, Authlete does not conduct the validation.
        /// </param>
        ///
        /// <param name="requiredSubject">
        /// Subject (= unique identifier of an end-user) that the
        /// access token should be associated with. If a non-null
        /// value is given to this parameter, the implementation of
        /// Authlete's <c>/api/auth/introspection</c> API checks
        /// whether the access token is associated with the
        /// required subject. On the other hand, if <c>null</c> is
        /// given to this parameter, Authlete does not conduct the
        /// validation.
        /// </param>
        public async Task<bool> Validate(
            string accessToken, string[] requiredScopes = null,
            string requiredSubject = null)
        {
            // Clear properties that may have been set by the
            // previous Validate() call.
            IsValid             = false;
            IntrospectionResult = null;
            IntrospectionError  = null;
            ErrorResponse       = null;

            try
            {
                // Call Authlete's /api/auth/introspection API.
                // The response from the API is set to the
                // 'IntrospectionResult' property.
                IntrospectionResult =
                    await CallIntrospectionApi(
                        accessToken, requiredScopes, requiredSubject);
            }
            catch (Exception cause)
            {
                // The API call failed.
                IntrospectionError = cause;
                ErrorResponse      = BuildErrorResponse(cause);
                return (IsValid = false);
            }

            // The 'action' parameter in the response from
            // /api/auth/introspection denotes the next action
            // the API caller should take.
            switch (IntrospectionResult.Action)
            {
                case IntrospectionAction.OK:
                    // The access token is valid.
                    return (IsValid = true);

                default:
                    // The access token is not valid, or an
                    // unexpected error occurred. An error response
                    // that the protected resource endpoint should
                    // return to the client application is set to
                    // the 'ErrorResponse' property.
                    ErrorResponse = BuildErrorResponse(IntrospectionResult);
                    return (IsValid = false);
            }
        }


        /// <summary>
        /// Call Authlete's <c>/api/auth/introspection</c> API.
        /// </summary>
        async Task<IntrospectionResponse> CallIntrospectionApi(
            string accessToken, string[] requiredScopes,
            string requiredSubject)
        {
            // Prepare a request to /api/auth/introspection API.
            var request = new IntrospectionRequest
            {
                Token   = accessToken,
                Scopes  = requiredScopes,
                Subject = requiredSubject
            };

            // Call /api/auth/introspection API.
            return await _api.Introspection(request);
        }


        /// <summary>
        /// Build an error response that should be returned to the
        /// client application.
        /// </summary>
        static HttpResponseMessage BuildErrorResponse(
            IntrospectionResponse response)
        {
            HttpStatusCode statusCode;

            // The 'action' parameter in the response from
            // Authlete's /api/auth/introspection API denotes the
            // next action that the API caller should take.
            switch (response.Action)
            {
                case IntrospectionAction.INTERNAL_SERVER_ERROR:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;

                case IntrospectionAction.BAD_REQUEST:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case IntrospectionAction.UNAUTHORIZED:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                case IntrospectionAction.FORBIDDEN:
                    statusCode = HttpStatusCode.Forbidden;
                    break;

                default:
                    // This should not happen. In this case, this
                    // method should not be called.
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            // In error cases, the 'responseContent' parameter in
            // the response from Authlete's /api/auth/introspection
            // API contains a value for the WWW-Authenticate header.
            string challenge = response.ResponseContent;

            // Build a response that complies with RFC 6750.
            return ResponseUtility
                .WwwAuthenticate(statusCode, challenge);
        }


        /// <summary>
        /// Build an error response (500 Internal Server Error)
        /// that should be returned to the client application.
        /// </summary>
        static HttpResponseMessage BuildErrorResponse(Exception e)
        {
            string challenge =
                "Bearer error=\"server_error\"," +
                "error_description=\"Introspection API call failed.\"";

            // Build a response that complies with RFC 6750.
            return ResponseUtility
                .WwwAuthenticate(
                    HttpStatusCode.InternalServerError, challenge);
        }
    }
}
