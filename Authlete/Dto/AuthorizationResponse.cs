//
// Copyright (C) 2018-2020 Authlete, Inc.
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


using Authlete.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's <c>/api/auth/authorization</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Note: In the description below, "authorization server" is
    /// always used even where "OpenID provider" should be used.
    /// </para>
    ///
    /// <para>
    /// Authlete's <c>/api/auth/authorization</c> API returns JSON
    /// which can be mapped to this class. The authorization server
    /// implementation should retrieve the value of the <c>action</c>
    /// response parameter (which can be obtained via the
    /// <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationAction.INTERNAL_SERVER_ERROR</c>, it means
    /// that the request from the authorization server implementation
    /// was wrong or that an error occurred in Authlete. In either
    /// case, from a viewpoint of the client application, it is an
    /// error on the server side. Therefore, the authorization
    /// server implementation should generate a response to the
    /// client application with the HTTP status of <c>"500 Internal
    /// Server Error"</c>. Authlete recommends
    /// <c>"application/json"</c> as the content type although OAuth
    /// 2.0 specification does not mention the format of the error
    /// response when the redirect URI is not usable.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the
    /// response which the authorization server implementation
    /// should generate and return to the client application.
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
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationAction.BAD_REQUEST</c>, it means that the
    /// request from the client application was invalid. The HTTP
    /// status of the response returned to the client application
    /// should be <c>"400 Bad Request"</c> and Authlete recommends
    /// <c>"application/json"</c> as the content type although
    /// OAuth 2.0 specification does not mention the format of the
    /// error response when the redirect URI is not usable.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the
    /// response which the authorization server implementation
    /// should generate and return to the client application.
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
    /// <c>AuthorizationAction.LOCATION</c>, it means that the
    /// request from the client application is invalid but the
    /// redirect URI to which the error should be reported has been
    /// determined. The HTTP status of the response returned to the
    /// client application should be <c>"302 Found"</c> and the
    /// <c>"Location"</c> header must have a redirect URI with an
    /// <c>"error"</c> response parameter.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns the redirect
    /// URI which has the <c>"error"</c> response parameter, so it
    /// can be used as the value of <c>"Location"</c> header. The
    /// following illustrates the response which the authorization
    /// server implementation should generate and return to the
    /// client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 302 Found
    /// Location: (The value returned from ResponseContent)
    /// Cache-Control: no-store
    /// Pragma: no-cache
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationAction.FORM</c>, it means that the request
    /// from the client application is invalid but the redirect URI
    /// to which the error should be reported has been determined,
    /// and that the request contains <c>response_mode=form_post</c>
    /// as is defined in
    /// <a href="https://openid.net/specs/oauth-v2-form-post-response-mode-1_0.html">OAuth
    /// 2.0 Form Post Response Mode</a>. The HTTP status of the
    /// response returned to the client application should be
    /// <c>"200 OK"</c> and the content type should be
    /// <c>"text/html;charset=UTF-8"</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns an HTML which
    /// satisfies the requirements of <c>response_mode=form_post</c>,
    /// so it can be used as the entity body of the response. The
    /// following illustrates the response which the authorization
    /// server implementation should generate and return to the
    /// client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 200 OK
    /// Content-Type: text/html;charset=UTF-8
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
    /// <c>AuthorizationAction.NO_INTERACTION</c>, it means that
    /// the request from the client application has no problem and
    /// requires the authorization server to process the request
    /// without displaying any user interface for authentication
    /// and/or consent. This happens when the request contains
    /// <c>prompt=none</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, the authorization server implementation
    /// should follow the steps below.
    /// </para>
    ///
    /// <para><b>[END-USER AUTHENTICATION]</b></para>
    ///
    /// <para>
    /// Check whether an end-user has already logged in. If an
    /// end-user has logged in, go to the next step ([MAX AGE]).
    /// Otherwise, call Authlete's <c>/api/auth/authorization/fail</c>
    /// API with <c>reason=AuthorizationFailAction.NOT_LOGGED_IN</c>
    /// and use the response from the API to generate a response to
    /// the client application.
    /// </para>
    ///
    /// <para><b>[MAX AGE]</b></para>
    ///
    /// <para>
    /// Get the value of the max age from the <c>MaxAge</c> property.
    /// The value represents the maximum authentication age which
    /// has come from the <c>"max_age"</c> request parameter or the
    /// <c>"default_max_age"</c> configuration parameter of the
    /// client application. If the value is <c>0</c>, go to the
    /// next step ([SUBJECT]). Otherwise, follow the sub steps
    /// described below.
    /// </para>
    ///
    /// <para>
    /// (1) Get the time at which the end-user was authenticated.
    /// Note that this value is not managed by Authlete, meaning
    /// that it is expected that the authorization server
    /// implementation manages the value. If the authorization
    /// server implementation does not manage authentication time
    /// of end-users, call Authlete's <c>/api/auth/authorization/fail</c>
    /// API with <c>reason=AuthorizationFailReason.MAX_AGE_NOT_SUPPORTED</c>
    /// and use the response from the API to generate a response to
    /// the client application.
    /// </para>
    ///
    /// <para>
    /// (2) Add the value of the maximum authentication age (which
    /// is represented in seconds to the authentication time.
    /// </para>
    ///
    /// <para>
    /// (3) Check whether the calculated value is equal to or
    /// greater than the current time. If this condition is
    /// satisfied, go to the next step ([SUBJECT]). Otherwise, call
    /// Authlete's <c>/api/auth/authorization/fail</c> API with
    /// <c>reason=AuthorizationFailReason.EXCEEDS_MAX_AGE</c> and
    /// use the response from the API to generate a response to the
    /// client application.
    /// </para>
    ///
    /// <para><b>[SUBJECT]</b></para>
    ///
    /// <para>
    /// Get the value of the requested subject from the <c>Subject</c>
    /// property. The value represents an end-user who the client
    /// application expects to grant authorization. If the value is
    /// <c>null</c>, go to the next step ([ACRs]). Otherwise, follow
    /// the sub steps described below.
    /// </para>
    ///
    /// <para>
    /// (1) Compare the value of the requested subject to the subject
    /// (= unique user ID) of the current end-user.
    /// </para>
    ///
    /// <para>
    /// (2) If they are equal, go to the next step ([ACRs]).
    /// </para>
    ///
    /// <para>
    /// If they are not equal, call Authlete's
    /// <c>/api/auth/authorization/fail</c> API with
    /// <c>reason=AuthorizationFailRequest.DIFFERENT_SUBJECT</c>
    /// and use the response from the API to generate a response to
    /// the client application.
    /// </para>
    ///
    /// <para><b>[ACRs]</b></para>
    ///
    /// <para>
    /// Get the value of ACRs (Authentication Context Class
    /// References) from the <c>Acrs</c> property. The value has
    /// come from (1) the <c>"acr"</c> claim in the <c>"claims"</c>
    /// request parameter, (2) the <c>"acr_values"</c> request
    /// parameter, or (3) the <c>"default_acr_values"</c>
    /// configuration parameter of the client application.
    /// </para>
    ///
    /// <para>
    /// It is ensured that all the ACRs returned by the <c>Acrs</c>
    /// property are supported by the authorization server
    /// implementation. In other words, it is ensured that all the
    /// ACRs are listed in the <c>"acr_values_supported"</c>
    /// configuration parameter of the authorization server.
    /// </para>
    ///
    /// <para>
    /// If the value of ACRs is <c>null</c>, go to the next step
    /// ([SCOPES]). Otherwise, follow the sub steps described
    /// below.
    /// </para>
    ///
    /// <para>
    /// (1) Get the ACR performed for the authentication of the
    /// current end-user. Note that this value is managed not by
    /// Authlete but by the authorization server implementation.
    /// (If the authorization server implementation cannot handle
    /// ACRs, it should not have listed ACRs in the
    /// <c>"acr_values_supported"</c> configuration parameter.)
    /// </para>
    ///
    /// <para>
    /// Compare the ACR value obtained in the above step to each
    /// element in the ACR array obtained from the <c>Acrs</c>
    /// property in the listed order. If the ACR value was found in
    /// the array, go to the next step ([SCOPES]).
    /// </para>
    ///
    /// <para>
    /// If the ACR value was not found in the ACR array (= if the
    /// ACR performed for the authentication of the current end-user
    /// did not match any one of the ACRs requested by the client
    /// application), check whether one of the requested ACRs must
    /// be satisfied or not by referring to the <c>IsAcrEssential</c>
    /// property. If the <c>IsAcrEssential</c> property returns
    /// <c>true</c>, call Authlete's
    /// <c>/api/auth/authorization/fail</c> API with
    /// <c>reason=AuthorizationFailReason.ACR_NOT_SATISFIED</c> and
    /// use the response from the API to generate a response to the
    /// client application. Otherwise, go to the next step
    /// ([SCOPES]).
    /// </para>
    ///
    /// <para><b>[SCOPES]</b></para>
    ///
    /// <para>
    /// Get the scopes from the <c>Scopes</c> property. If the array
    /// contains one or more scopes which have not been granted to
    /// the client application by the end-user in the past, call
    /// Authlete's <c>/api/auth/authorization/fail</c> API with
    /// <c>reason=AuthorizationFailReason.CONSENT_REQUIRED</c> and
    /// use the response from the API to generate a response to the
    /// client application. Otherwise, go to the next step ([ISSUE]).
    /// </para>
    ///
    /// <para>
    /// Note that Authlete provides APIs to manage records of
    /// granted scopes (<c>/api/client/grantedscopes/*</c> APIs),
    /// but the APIs work only in the case the Authlete server you
    /// use is a dedicated Authlete server (contact
    /// <a href="mailto:sales@authlete.com">sales@authlete.com</a>
    /// for details). In other words, the APIs of the shared
    /// Authlete server are disabled intentionally (in order to
    /// prevent garbage data from being accumulated) and they
    /// return <c>"403 Forbidden"</c>.
    /// </para>
    ///
    /// <para><b>[ISSUE]</b></para>
    ///
    /// <para>
    /// If all the above steps succeeded, the last step is to issue
    /// an authorization code, an ID token and/or an access token
    /// (<c>response_type=none</c> is a special case where nothing
    /// is issued). The last step can be performed by calling
    /// Authlete's <c>/api/auth/authorization/issue</c> API. The
    /// API requires the following parameters, which are
    /// represented as properties of the
    /// <c>AuthorizationIssueRequest</c> class. Prepare these
    /// parameters and call the <c>/api/auth/authorization/issue</c>
    /// API.
    /// </para>
    ///
    /// <para>
    /// (1) [ticket] (required). This parameter represents a ticket
    /// which is exchanged with tokens at the
    /// <c>/api/auth/authorization/issue</c> API. Use the value
    /// returned from the <c>Ticket</c> property as it is.
    /// </para>
    ///
    /// <para>
    /// (2) [subject] (required). This parameter represents the
    /// unique identifier of the current end-user. It is often
    /// called "User ID" and it may or may not be visible to the
    /// end-user. In any case, it is a number or a string assigned
    /// to the end-user by your service. Authlete does not care
    /// about the format of the value of the subject, but it must
    /// consist of only ASCII letters and its length must be equal
    /// to or less than 100.
    /// </para>
    ///
    /// <para>
    /// When the <c>Subject</c> property of <c>AuthorizationResponse</c>
    /// returns a non-null value, the value of <c>subject</c>
    /// request parameter to <c>/api/auth/authorization/issue</c>
    /// API is necessarily identical.
    /// </para>
    ///
    /// <para>
    /// The value of this request parameter will be embedded in an
    /// ID token as the value of the <c>"sub"</c> claim. When the
    /// value of the <c>"subject_type"</c> configuration parameter
    /// of the client is <c>SubjectType.PAIRWISE</c>, the value of
    /// the <c>"sub"</c> claim is different from the value
    /// specified here, but <c>PAIRWISE</c> is not supported by
    /// Authlete yet. See
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#SubjectIDTypes">8.
    /// Subject Identifier Types</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for details about subject types.
    /// </para>
    ///
    /// <para>
    /// You can use the <c>"sub"</c> request parameter to adjust
    /// the value of the <c>"sub"</c> claim in an ID token. See the
    /// description of the <c>"sub"</c> request parameter for details.
    /// </para>
    ///
    /// <para>
    /// (3) [authTime] (optional). This parameter represents the
    /// time when the end-user authentication occurred. Its value
    /// is the number of seconds since the Unix epoch (1970-Jan-1).
    /// The value of this parameter will be embedded in an ID token
    /// as the value of the <c>"auth_time"</c> claim.
    /// </para>
    ///
    /// <para>
    /// (4) [acr] (optional). This parameter represents the ACR
    /// (Authentication Context Class Reference) which the
    /// authentication of the end-user satisifes. When the
    /// <c>Acrs</c> property returns a non-empty array and the
    /// <c>IsAcrEssential</c> property returns <c>true</c>, the
    /// value of this parameter must be one of the array elements.
    /// Otherwise, even <c>null</c> is allowed. The value of this
    /// parameter will be embedded in an ID token as the value of
    /// the <c>"acr"</c> claim.
    /// </para>
    ///
    /// <para>
    /// (5) [claims] (optional). This parameter represents claims
    /// of the end-user. "Claims" here are pieces of information
    /// about the end-user such as <c>"name"</c>, <c>"email"</c>
    /// and <c>"birthdate"</c>. The authorization server
    /// implementation is required to gather claims of the end-user,
    /// format the claim values into a JSON and set the JSON string
    /// as the value of this parameter.
    /// </para>
    ///
    /// <para>
    /// The claims which the authorization server implementation is
    /// required to gather can be obtained from the <c>Claims</c>
    /// property.
    /// </para>
    ///
    /// <para>
    /// For example, if the <c>Claims</c> property returns an array
    /// which contains <c>"name"</c>, <c>"email"</c> and
    /// <c>"birthdate"</c>, the value of this parameter should look
    /// like the following.
    /// </para>
    ///
    /// <code>
    /// {
    ///   "name": "John Smith",
    ///   "email": "john@example.com",
    ///   "birthdate": "1974-05-06"
    /// }
    /// </code>
    ///
    /// <para>
    /// The <c>ClaimsLocales</c> property lists the end-user's
    /// preferred languages and scripts for claim values, ordered by
    /// preference. When the <c>ClaimsLocales</c> property returns
    /// a non-empty array, its elements should be taken into
    /// consideration when the authorization server implementation
    /// gathers claim values. Especially, note the excerpt below
    /// from
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsLanguagesAndScripts">5.2.
    /// Claims Languages and Scripts</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </para>
    ///
    /// <para>
    /// <i>"When the OP determines, either through the
    /// <c>claims_locales</c> parameter, or by other means, that
    /// End-User and Client are requesting Claims in only one set
    /// of languages and scripts, it is RECOMMENDED that OPs return
    /// Claims without language tags when they employ this language
    /// and script. It is also RECOMMENDED that Clients be written
    /// in a manner that they can handle and utilize Claims using
    /// language tags."</i>
    /// </para>
    ///
    /// <para>
    /// If the <c>Claims</c> property returns <c>null</c> or an
    /// empty array, the value of this parameter should be
    /// <c>null</c>.
    /// </para>
    ///
    /// <para>
    /// See
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
    /// Standard Claims</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for claim names and their value
    /// formats. Note (1) that the authorization server
    /// implementation may support its special claims
    /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#AdditionalClaims">5.1.2.
    /// Additional Claims</a>) and (2) that claim names may be
    /// followed by a language tag
    /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsLanguagesAndScripts">5.2.
    /// Claims Languages and Scripts</a>). Read the specification of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a> for details.
    /// </para>
    ///
    /// <para>
    /// The claim values in this parameter will be embedded in an
    /// ID token.
    /// </para>
    ///
    /// <para>
    /// <c>IdTokenClaims</c> is available since version 1.2.0. The
    /// property holds the value of the <c>"id_token"</c> property
    /// in the <c>"claims"</c> request parameter or in the
    /// <c>"claims"</c> property in a request object. The value
    /// held by <c>IdTokenClaims</c> should be considered when you
    /// prepare claim values. See the description of the property
    /// for details. Note that, however, old Authlete servers don't
    /// support this response parameter.
    /// </para>
    ///
    /// <para>
    /// (6) [properties] (optional). Extra properties to be
    /// associated with an access token and/or an authorization
    /// code that may be issued from the Authlete API. Note that
    /// the <c>properties</c> request parameter is accepted only
    /// when <c>Content-Type</c> of the request to Authlete's
    /// <c>/api/auth/authorization/issue</c> API is
    /// <c>"application/json"</c>, so don't use
    /// <c>"application/x-www-form-urlencoded"</c> if you want to
    /// use this request parameter.
    /// </para>
    ///
    /// <para>
    /// (7) [scopes] (optional). Scopes to be associated with an
    /// access token and/or an authorization code. If this
    /// parameter is <c>null</c>, the scopes specified in the
    /// original authorization request from the client application
    /// are used. In other cases, the specified scopes by this
    /// parameter will replace the scopes contained in the original
    /// authorization request.
    /// </para>
    ///
    /// <para>
    /// Even scopes that are not included in the original
    /// authorization request can be specified. However, as an
    /// exception, the <c>"openid"</c> scope is ignored on Authlete
    /// server side if it is not included in the original request.
    /// It is because the existence of the <c>"openid"</c> scope
    /// considerably changes the validation steps and because
    /// adding <c>"openid"</c> triggers generation of an ID token
    /// (although the client application has not requested it) and
    /// the behavior is a major violation against the specification.
    /// </para>
    ///
    /// <para>
    /// If you add the <c>"offline_access"</c> scope although it is
    /// not included in the original request, keep in mind that the
    /// specification requires explicit consent from the end-user
    /// for the scope
    /// (<a href="https://openid.net/specs/openid-connect-core-1_0.html#OfflineAccess">11.
    /// Offline Access</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>). When <c>"offline_access"</c> is
    /// included in the original authorization request, the current
    /// implementation of Authlete's <c>/api/auth/authorization</c>
    /// API checks whether the authorization request has come along
    /// with the <c>"prompt"</c> request parameter and its value
    /// includes <c>"consent"</c>. However, note that the
    /// implementation of Authlete's <c>/api/auth/authorization/issue</c>
    /// API does not perform the same validation even if the
    /// <c>"offline_access"</c> scope is added via this <c>scopes</c>
    /// parameter.
    /// </para>
    ///
    /// <para>
    /// (8) [sub] (optional). The value of the <c>"sub"</c> claim
    /// in an ID token which may be issued. If the value of this
    /// request parameter is not empty, it is used as the value of
    /// the <c>"sub"</c> claim. Otherwise, the value of the
    /// <c>"subject"</c> request parameter is used as the value of
    /// the <c>"sub"</c> claim. The main purpose of this parameter
    /// is to hide the actual value of the subject from client
    /// applications.
    /// </para>
    ///
    /// <para>
    /// <c>/api/auth/authorization/issue</c> API returns a response
    /// in JSON format which can be mapped to
    /// <c>AuthorizationIssueResponse</c>. Use the response from
    /// the API to generate a response to the client application.
    /// See the description of <c>AuthorizationIssueResponse</c>
    /// for details.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>AuthorizationAction.INTERACTION</c>, it means that the
    /// request from the client application has no problem and
    /// requires the authorization server to process the request
    /// with user interaction by an HTML form.
    /// </para>
    ///
    /// <para>
    /// The purpose of the UI displayed to the end-user is to ask
    /// the end-user to grant authorization to a client application.
    /// The items described below are some points which the
    /// authorization server implementation should take into
    /// consideration when it builds the UI.
    /// </para>
    ///
    /// <para><b>[DISPLAY MODE]</b></para>
    ///
    /// <para>
    /// <c>AuthorizationResponse</c> contains <c>"display"</c>
    /// parameter. The value can be obtained via the <c>Display</c>
    /// property and it is one of <c>PAGE</c> (default), <c>POPUP</c>
    /// <c>TOUCH</c> and <c>WAP</c>. The meanings of the values are
    /// described in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
    /// Authentication Request</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>. Basically, the authorization server
    /// implementation should display the UI which is suitable for
    /// the display mode, but it is okay for the authorization
    /// server implementation to <i>"attempt to detect the
    /// capabilities of the User Agent and present an appropriate
    /// display."</i>
    /// </para>
    ///
    /// <para>
    /// It is ensured that the value returned from the <c>Display</c>
    /// property is one of the supported display values which are
    /// specified by the <c>"display_values_supported"</c>
    /// configuration parameter of the authorization server.
    /// </para>
    ///
    /// <para><b>[UI LOCALE]</b></para>
    ///
    /// <para>
    /// <c>AuthorizationResponse</c> contains <c>"ui_locales"</c>
    /// parameter. The value can be obtained via the <c>UiLocales</c>
    /// property and it is an array of language tag values (such as
    /// <c>"fr-CA"</c> and <c>"en"</c>) ordered by preference. The
    /// authorization server implementation should display the UI
    /// in one of the languages listed in the <c>"ui_locales"</c>
    /// parameter when possible.
    /// </para>
    ///
    /// <para>
    /// It is ensured that language tags returned from the
    /// <c>UiLocales</c> property are contained in the list of
    /// supported UI locales which are specified by the
    /// <c>"ui_locales_supported"</c> configuration parameter of
    /// the authorization server.
    /// </para>
    ///
    /// <para><b>[CLIENT INFORMATION]</b></para>
    ///
    /// <para>
    /// The authorization server implementation should show the
    /// end-user information about the client application. The
    /// information can be obtained via the <c>Client</c> property.
    /// </para>
    ///
    /// <para><b>[SCOPES]</b></para>
    ///
    /// <para>
    /// A client application requires authorization for specific
    /// permissions. In OAuth 2.0 specification, <i>"scope"</i> is
    /// a technical term which represents a permission. The
    /// <c>Scopes</c> property returns scopes requested by the
    /// client application. The authorization server implementation
    /// should show the end-user the scopes.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation may choose not to
    /// show scopes to which the end-user has given consent in the
    /// past. To put it the other way around, the authorization
    /// server implementation may show only the scopes to which the
    /// end-user has not given consent yet. However, if the value
    /// returned from the <c>Prompts</c> contains
    /// <c>Prompt.CONSENT</c>, the authorization server
    /// implementation has to obtain explicit consent from the
    /// end-user even if the end-user has given consent to all the
    /// requested scopes in the past.
    /// </para>
    ///
    /// <para>
    /// Note that Authlete provides APIs to manage records of
    /// granted scopes (<c>/api/client/granted_scopes/*</c> APIs),
    /// but the APIs work only in the case the Authlete server you
    /// use is a dedicated Authlete server (contact
    /// <a href="mailto:sales@authlete.com">sales@authlete.com</a>
    /// for details). In other words, the APIs of the shared
    /// Authlete server are disabled intentionally (in order to
    /// prevent garbage data from being accumulated) and they
    /// return <c>"403 Forbidden"</c>.
    /// </para>
    ///
    /// <para>
    /// It is ensured that scopes returned from the <c>Scopes</c>
    /// property are contained in the list of supported scopes
    /// parameter of the authorization server.
    /// </para>
    ///
    /// <para><b>[END-USER AUTHENTICATION]</b></para>
    ///
    /// <para>
    /// Necessarily, the end-user must be authenticated (= must
    /// login your service) before granting authorization to the
    /// client application. Simply put, a login form is expected to
    /// be displayed for end-user authentication. The authorization
    /// server implementation must follow the steps described below
    /// to comply with OpenID Connect. (Or just always show a login
    /// form if it's too much of a bother to follow the steps below).
    /// </para>
    ///
    /// <para>
    /// (1) Get the value of the <c>Prompts</c> property. It
    /// corresponds to the value of the <c>"prompt"</c> request
    /// parameter. Details of the request parameter are described
    /// in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
    /// Authentication Request</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </para>
    ///
    /// <para>
    /// If the value returned from the <c>Prompts</c> property
    /// contains <c>Prompt.SELECT_ACCOUNT</c>, display a form to
    /// urge the end-user to select one of his/her accounts for
    /// login. If the <c>Subject</c> property returns a non-null
    /// value, it is the end-user ID that the client application
    /// expects, so the value should be used to determine the value
    /// of the login ID. Note that a subject and a login ID are not
    /// necessarily equal. If the <c>Subject</c> property returns
    /// <c>null</c>, the value returned from the <c>LoginHint</c>
    /// should be referred to as a hint to determine the value of
    /// the login ID. The <c>LoginHint</c> property simply returns
    /// the value of the <c>"login_hint"</c> request parameter.
    /// </para>
    ///
    /// <para>
    /// If the value returned from the <c>Prompts</c> property
    /// contains <c>Prompt.LOGIN</c>, display a form to urge the
    /// end-user to login even if the end-user has already logged
    /// in. If the <c>Subject</c> property returns a non-null value,
    /// it is the end-user ID that the client application expects,
    /// so the value should be used to determine the value of the
    /// login ID. Note that a subject and a login ID are not
    /// necessarily equal. If the <c>Subject</c> property returns
    /// <c>null</c>, the value returned from the <c>LoginHint</c>
    /// should be referred to as a hint to determine the value of
    /// the login ID. The <c>LoginHint</c> property simply returns
    /// the value of the <c>"login_hint"</c> request parameter.
    /// </para>
    ///
    /// <para>
    /// If the value returned from the <c>Prompts</c> property does
    /// not contain <c>Prompt.LOGIN</c>, the authorization server
    /// implementation does not have to authenticate the end-user
    /// if all the conditions described below are satisfied. If any
    /// one of the condisionts is not satisfied, show a login form
    /// to authenticate the end-user.
    /// </para>
    ///
    /// <para>
    /// (a) An end-user has already logged in your service.
    /// </para>
    ///
    /// <para>
    /// (b) The login ID of the current end-user matches the value
    /// returned from the <c>Subject</c> property. This check is
    /// required only when the <c>Subject</c> property returns a
    /// non-null value.
    /// </para>
    ///
    /// <para>
    /// (c) The max age, which is the number of seconds obtained by
    /// the <c>MaxAge</c> property, has not passed since the
    /// current end-user logged in your service. This check is
    /// required only when the <c>MaxAge</c> property returns a
    /// non-zero value.
    /// </para>
    ///
    /// <para>
    /// If the authorization server implementation does not manage
    /// authentication time of end-users (= if the authorization
    /// server implementation cannot know when end-users logged in)
    /// and if the <c>MaxAge</c> property returns a non-zero value,
    /// a login form should be displayed.
    /// </para>
    ///
    /// <para>
    /// (d) The ACR (Authentication Context Class Reference) of the
    /// authentication performed for the current end-user satisfies
    /// one of the ACRs listed in the value of the <c>Acrs</c>
    /// property. This check is required only when the <c>Acrs</c>
    /// property returns a non-empty array.
    /// </para>
    ///
    /// <para>
    /// In every case, the end-user authentication must satisfy one
    /// of the ACRs listed in the value of the <c>Acrs</c> property
    /// when the <c>Acrs</c> property returns a non-empty array and
    /// the <c>IsAcrEssential</c> property returns <c>true</c>.
    /// </para>
    ///
    /// <para><b>[GRANT/DENY BUTTONS]</b></para>
    ///
    /// <para>
    /// The end-user is supposed to choose either (1) to grant
    /// authorization to the client application or (2) to deny the
    /// authorization request. The UI must have UI components to
    /// accept the decision by the end-user. Usually, a button to
    /// grant authorization and a button to deny the request are
    /// provided.
    /// </para>
    ///
    /// <para>
    /// When the subject returned by the <c>Subject</c> property is
    /// not <c>null</c>, the end-user authentication must be
    /// performed for the subject, meaning that the authorization
    /// server implemetation should repeatedly show a login form
    /// until the subject is succesfully authenticated.
    /// </para>
    ///
    /// <para>
    /// The end-user will choose either (1) to grant authorization
    /// to the client application or (2) to deny the authorization
    /// request. When the end-user chose to deny the authorization
    /// request, call Authlete's <c>/api/auth/authorization/fail</c>
    /// API with <c>reason=AuthorizationFailReason.DENIED</c> and
    /// use the response from the API to generate a response to the
    /// client application.
    /// </para>
    ///
    /// <para>
    /// When the end-user chose to grant authorization to the client
    /// application, the authorization server implementation has to
    /// issue an authorization code, an ID token, and/or an access
    /// token to the client application (<c>response_type=none</c>
    /// is a special case where nothing is issued). Issuing the
    /// tokens can be performed by calling Authlete's
    /// <c>/api/auth/authorization/issue</c> API. Read [ISSUE]
    /// written above in the description for the case of
    /// <c>action=AuthorizationResponseAction.NO_INTERACTION</c>.
    /// </para>
    /// </remarks>
    public class AuthorizationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthorizationAction Action { get; set; }


        /// <summary>
        /// The information about the service.
        /// </summary>
        [JsonProperty("service")]
        public Service Service { get; set; }


        /// <summary>
        /// The information about the client application that has
        /// made the authorization request.
        /// </summary>
        [JsonProperty("client")]
        public Client Client { get; set; }


        /// <summary>
        /// The flag which indicates whether the value of the
        /// <c>"client_id"</c> request parameter included in the
        /// authorization request is the client ID alias or the
        /// original numeric client ID.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The display mode which the client application requested
        /// by the <c>"display"</c> request parameter. When the
        /// authorization request does not contain the
        /// <c>"display"</c> request parameter, this property
        /// returns <c>Display.PAGE</c> as the default value.
        /// </summary>
        [JsonProperty("display")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Display Display { get; set; }


        /// <summary>
        /// The maximum authentication age which is the allowable
        /// elapsed time in seconds since the last time the
        /// end-user was actively authenticated by the authorization
        /// server implementation. The value of this property comes
        /// from either (1) the <c>"max_age"</c> request parameter
        /// or (2) the <c>"default_max_age"</c> configuration
        /// parameter of the client application. <c>0</c> may be
        /// returned which means that the max age constraint does
        /// not have to be imposed.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"max_age"</c> request
        /// parameter.
        /// </para>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> for the
        /// <c>"default_max_age"</c> configuration parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("maxAge")]
        public int MaxAge { get; set; }


        /// <summary>
        /// The scopes which the client application requested by
        /// the <c>"scope"</c> request parameter. When the
        /// authorization request did not contain the <c>"scope"</c>
        /// request parameter, this property returns a list of
        /// scopes which are marked as default. <c>null</c> may be
        /// returned if the authorization request did not contain
        /// valid scopes and none of registered scopes is marked as
        /// default.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// You may want to enable end-users to select/deselect
        /// scopes in the authorization page. In other words, you
        /// may want to use a different set of scopes than the set
        /// specified by the original authorization request.
        /// You can replace scopes when you call Authlete's
        /// <c>/api/authorization/issue</c> API. See the
        /// description of <c>AuthorizationIssueRequest.Scopes</c>
        /// for details.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public Scope[] Scopes { get; set; }


        /// <summary>
        /// The list of preferred languages and scripts for the
        /// user interface. The value of this property comes from
        /// the <c>"ui_locales"</c> request parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"ui_locales"</c>
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("uiLocales")]
        public string[] UiLocales { get; set; }


        /// <summary>
        /// The list of preferred languages and scripts for claim
        /// values contained in an ID token. The value of this
        /// property comes from the <c>"claims_locales"</c> request
        /// parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"claims_locales"</c>
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("claimsLocales")]
        public string[] ClaimsLocales { get; set; }


        /// <summary>
        /// The list of claims that the client application requested
        /// to be embedded in an ID token. The value of this property
        /// comes from the <c>"scope"</c> and/or <c>"claims"</c>
        /// request parameters of the original authorization request.
        /// </summary>
        [JsonProperty("claims")]
        public string[] Claims { get; set; }


        /// <summary>
        /// The flag which indicates whether the end-user
        /// authentication must satisfy one of the requested ACRs.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property returns <c>true</c> only when the
        /// authorization request from the client application
        /// contains the <c>"claims"</c> request parameter and it
        /// contains an entry for the <c>"acr"</c> claim with
        /// <c>"essential":true</c>. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#IndividualClaimsRequests">5.5.1.
        /// Individual Claims Requests</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </para>
        /// </remarks>
        [JsonProperty("acrEssential")]
        public bool IsAcrEssential { get; set; }


        /// <summary>
        /// The list of ACRs (Authentication Context Class
        /// References) requested by the client application. The
        /// value of this property comes from (1) the <c>"acr"</c>
        /// claim in the <c>"claims"</c> request parameter, (2)
        /// the <c>"acr_values"</c> request parameter, or (3) the
        /// <c>"default_acr_values"</c> configuration parameter of
        /// the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsParameter">5.5.
        /// Requesting Claims using the "claims" Request Parameter</a>
        /// of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"claims"</c> request
        /// parameter.
        /// </para>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"acr_values"</c>
        /// request parameter.
        /// </para>
        ///
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html#ClientMetadata">2.
        /// Client Metadata</a> of
        /// <a href="https://openid.net/specs/openid-connect-registration-1_0.html">OpenID
        /// Connect Dynamic Client Registration 1.0</a> for the
        /// <c>"default_acr_values"</c> configuration parameter of
        /// the client application.
        /// </para>
        /// </remarks>
        [JsonProperty("acrs")]
        public string[] Acrs { get; set; }


        /// <summary>
        /// The subject (= unique identifier) of the end-user that
        /// the client application requested. The value of this
        /// property comes from the <c>"sub"</c> claim in the
        /// <c>"claims"</c> request parameter. This property may
        /// return <c>null</c> (probably in most cases).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsParameter">5.5.
        /// Requesting Claims using the "claims" Request Parameter</a>
        /// of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"claims"</c> request
        /// parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// Login hint specified by the <c>"login_hint"</c> request
        /// parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"login_hint"</c> request
        /// parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("loginHint")]
        public string LoginHint { get; set; }


        /// <summary>
        /// The list of prompts contained in the authorization
        /// request (= the value of the <c>"prompt"</c> request
        /// parameter).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#AuthRequest">3.1.2.1.
        /// Authentication Request</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for the <c>"prompt"</c> request
        /// parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("prompts", ItemConverterType = typeof(StringEnumConverter))]
        public Prompt[] Prompts { get; set; }


        /// <summary>
        /// The payload part of the request object in JSON format.
        /// This property holds <c>null</c> if the authorization
        /// request does not include a request object.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("requestObjectPayload")]
        public string RequestObjectPayload { get; set; }


        /// <summary>
        /// The value of the <c>id_token</c> property in the
        /// <c>claims</c> request parameter or in the <c>claims</c>
        /// property in a request object.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A client application may request certain claims be
        /// embedded in an ID token or in a response from the
        /// UserInfo endpoint. There are several ways. Including
        /// the <c>claims</c> request parameter and including the
        /// <c>claims</c> property in a request object are such
        /// examples. In both the cases, the value of the
        /// <c>claims</c> parameter/property is JSON. Its format is
        /// described in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsParameter">5.5.
        /// Requesting Claims using the "claims" Request Parameter</a>
        /// of <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// The following is an excerpt from the specification. You
        /// can find <c>userinfo</c> and <c>id_token</c> are
        /// top-level properties.
        /// </para>
        ///
        /// <code>
        /// {
        ///  "userinfo":
        ///   {
        ///    "given_name": {"essential": true},
        ///    "nickname": null,
        ///    "email": {"essential": true},
        ///    "email_verified": {"essential": true},
        ///    "picture": null,
        ///    "http://example.info/claims/groups": null
        ///   },
        ///  "id_token":
        ///   {
        ///    "auth_time": {"essential": true},
        ///    "acr": {"values": ["urn:mace:incommon:iap:silver"]
        ///   }
        /// }
        /// </code>
        ///
        /// <para>
        /// This property (<c>IdTokenClaims</c>) holds the value of
        /// the <c>id_token</c> property in JSON format. For
        /// example, if the JSON above is included in an
        /// authorization request, this property holds JSON
        /// equivalent to the following.
        /// </para>
        ///
        /// <code>
        /// {
        ///  "auth_time": {"essential": true},
        ///  "acr": {"values": ["urn:mace:incommon:iap:silver"]
        /// }
        /// </code>
        ///
        /// <para>
        /// Note that if a request object is given and it contains
        /// the <c>claims</c> property and if the <c>claims</c>
        /// request parameter is also given, this property holds
        /// the value of the former.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("idTokenClaims")]
        public string IdTokenClaims { get; set; }


        /// <summary>
        /// The value of the <c>userinfo</c> property in the
        /// <c>claims</c> request parameter or in the <c>claims</c>
        /// property in a request object.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A client application may request certain claims be
        /// embedded in an ID token or in a response from the
        /// UserInfo endpoint. There are several ways. Including
        /// the <c>claims</c> request parameter and including the
        /// <c>claims</c> property in a request object are such
        /// examples. In both the cases, the value of the
        /// <c>claims</c> parameter/property is JSON. Its format is
        /// described in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsParameter">5.5.
        /// Requesting Claims using the "claims" Request Parameter</a>
        /// of <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// The following is an excerpt from the specification. You
        /// can find <c>userinfo</c> and <c>id_token</c> are
        /// top-level properties.
        /// </para>
        ///
        /// <code>
        /// {
        ///  "userinfo":
        ///   {
        ///    "given_name": {"essential": true},
        ///    "nickname": null,
        ///    "email": {"essential": true},
        ///    "email_verified": {"essential": true},
        ///    "picture": null,
        ///    "http://example.info/claims/groups": null
        ///   },
        ///  "id_token":
        ///   {
        ///    "auth_time": {"essential": true},
        ///    "acr": {"values": ["urn:mace:incommon:iap:silver"]
        ///   }
        /// }
        /// </code>
        ///
        /// <para>
        /// This property (<c>UserInfoClaims</c>) holds the value
        /// of the <c>userinfo</c> property in JSON format. For
        /// example, if the JSON above is included in an
        /// authorization request, this property holds JSON
        /// equivalent to the following.
        /// </para>
        ///
        /// <code>
        /// {
        ///  "given_name": {"essential": true},
        ///  "nickname": null,
        ///  "email": {"essential": true},
        ///  "email_verified": {"essential": true},
        ///  "picture": null,
        ///  "http://example.info/claims/groups": null
        /// }
        /// </code>
        ///
        /// <para>
        /// Note that if a request object is given and it contains
        /// the <c>claims</c> property and if the <c>claims</c>
        /// request parameter is also given, this property holds
        /// the value of the former.
        /// </para>
        ///
        /// <para>
        /// Since version 1.2.0.
        /// </para>
        /// </remarks>
        [JsonProperty("userInfoClaims")]
        public string UserInfoClaims { get; set; }


        /// <summary>
        /// The resources specified by the <c>resource</c> request parameters or
        /// by the <code>resource</code> property in the request object. If both
        /// are given, the values in the request object take precedence. See
        /// <a href="https://www.rfc-editor.org/rfc/rfc8707.html">RFC 8707</a>
        /// (Resource Indicators for OAuth 2.0) for details.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("resources")]
        public string[] Resources { get; set; }


        /// <summary>
        /// The value of the <c>purpose</c> request parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The <code>purpose</code> request parameter is defined in
        /// <a href="https://openid.net/specs/openid-connect-4-identity-assurance-1_0.html">OpenID
        /// Connect for Identity Assurance 1.0</a>.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }


        /// <summary>
        /// The response content which can be used to generate a
        /// response to the client application. The format of the
        /// value varies depending on the value of the <c>Action</c>
        /// property.
        /// </summary>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The ticket issued from Authlete's
        /// <c>/api/auth/authorization</c> API to the authorization
        /// server implementation. This ticket is necessary to call
        /// the <c>/api/auth/authorization/issue</c> API or the
        /// <c>/api/auth/authorization/fail</c> API.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
    }
}
