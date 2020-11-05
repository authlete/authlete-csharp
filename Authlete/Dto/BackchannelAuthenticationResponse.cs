//
// Copyright (C) 2019-2020 Authlete, Inc.
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
    /// Response from Authlete's <c>/api/backchannel/authentication</c>
    /// API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/backchannel/authentication</c> API returns
    /// JSON which can be mapped to this class. The authorization
    /// server implementation should retrieve the value of the
    /// <c>action</c> response parameter (which can be obtained via
    /// the <c>Action</c> property) from the response and take the
    /// following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationAction.BAD_REQUEST</c>, it means
    /// that the backchannel authentication request from the client
    /// application was wrong.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>400 Bad Request</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
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
    /// <c>BackchannelAuthenticationAction.UNAUTHORIZED</c>, it
    /// means that client authentication of the backchannel
    /// authentication request failed. Note that client
    /// authentication is always required at the backchannel
    /// authentication endpoint. This implies that public clients
    /// are not allowed to use the backchannel authentication
    /// endpoint.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation should generate a
    /// response to the client application with <c>401 Unauthorized</c>
    /// and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 401 Unauthorized
    /// WWW-Authenticate: (challenge)
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
    /// <c>BackchannelAuthenticationAction.INTERNAL_SERVER_ERROR</c>,
    /// it means that the API call from the authorization server
    /// implementation was wrong or that an error occurred in
    /// Authlete.
    /// </para>
    ///
    /// <para>
    /// In either case, from a viewpoint of the client application,
    /// it is an error on the server side. Therefore, the
    /// authorization server implementation should generate a
    /// response to the client application with
    /// <c>500 Internal Server Error</c> and <c>application/json</c>.
    /// </para>
    ///
    /// <para>
    /// In this case, <c>ResponseContent</c> returns a JSON string
    /// which describes the error, so it can be used as the entity
    /// body of the response. The following illustrates the response
    /// which the authorization server implementation should
    /// generate and return to the client application.
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
    /// <c>BackchannelAuthenticationAction.USER_IDENTIFICATION</c>,
    /// it means that the backchannel authentication request from
    /// the client application is valid. The authorization server
    /// implementation has to follow the steps below.
    /// </para>
    ///
    /// <para><b>[END-USER IDENTIFICATION</b></para>
    ///
    /// <para>
    /// The first step is to determine the subject (= unique
    /// identifier) of the end-user from whom the client
    /// application wants to get authorization.
    /// </para>
    ///
    /// <para>
    /// According to the CIBA specification, a backchannel
    /// authentication request contains one (and only one) of the
    /// <c>login_hint_token</c>, <c>id_token_hint</c> and
    /// <c>login_hint</c> request parameters as a hint by which the
    /// authorization server identifies the subject of an end-user.
    /// </para>
    ///
    /// <para>
    /// The authorization server implementation can know which hint
    /// is included in the backchannel authenticaiton request by
    /// checking the value of <c>HintType</c> property. The property
    /// holds a <c>UserIdentificationHintType</c> value that
    /// indicates which hint is included. For example, when the
    /// property holds <c>UserIdentificationHintType.LOGIN_HINT</c>,
    /// it means that the backchannel authentication request
    /// contains the <c>login_hint</c> request parameter as a hint.
    /// </para>
    ///
    /// <para>
    /// The <c>Hint</c> property holds the value of the hint. For
    /// example, when the <c>HintType</c> property holds
    /// <c>UserIdentificationHintType.LOGIN_HINT</c>, <c>Hint</c>
    /// holds the value of the <c>login_hint</c> request parameter.
    /// </para>
    ///
    /// <para>
    /// It is up to the authorization server implementation how to
    /// determine the subject of the end-user from the hint. There
    /// are few things Authlete can help. Only one thing Authlete
    /// can do is to set the value of the <c>sub</c> claim in the
    /// <c>id_token_hint</c> request parameter to the <c>Sub</c>
    /// property when the request parameter is used.
    /// </para>
    ///
    /// <para><b>[END-USER IDENTIFICATION ERROR]</b></para>
    ///
    /// <para>
    /// There are some cases where the authorization server
    /// implementation encounters an error during the user
    /// identification process. In any error case, the authorization
    /// server implementation has to return an HTTP response with
    /// the <c>error</c> response parameter to the client
    /// application. The following is an example of such error
    /// responses.
    /// </para>
    ///
    /// <code>
    /// HTTP/1.1 400 Bad Request
    /// Content-Type:application/json
    /// Cache-Control: no-store
    /// Pragma: no-cache
    ///
    /// {"error":"unknown_user_id"}
    /// </code>
    ///
    /// <para>
    /// Authlete provides <c>/api/backchannel/authenticaiton/fail</c>
    /// API that builds the response body (JSON) of an error
    /// response. However, because it is easy to build an error
    /// response manually, you may choose not to call the API. One
    /// good thing in using the API is that the API call can trigger
    /// deletion of the ticket which has been issued from Authlete's
    /// <c>/api/backchannel/authentication</c> API. If you don't
    /// call <c>/api/backchannel/authenticaiton/fail</c> API, the
    /// ticket will continue to exist in the database until it is
    /// cleaned up by the batch program after the ticket expires.
    /// </para>
    ///
    /// <para>
    /// Possible error cases that the authorization server
    /// implementation itself has to handle are as follows. Other
    /// error cases have already been covered by
    /// <c>/api/backchannel/authentication</c> API.
    /// </para>
    ///
    /// <para>
    /// <c>expired_login_hint_token</c>:<br/>
    /// The authorization server implementation detected that the
    /// hint presented by the <c>login_hint_token</c> request
    /// parameter has expired. Note that the format of
    /// <c>login_hint_token</c> is not described in the CIBA Core
    /// spec at all and so there is no consensus on how to detect
    /// expiration of <c>login_hint_token</c>. Interpretation of
    /// <c>login_hint_token</c> is left to each authorization
    /// server implementation.
    /// </para>
    ///
    /// <para>
    /// <c>unknown_user_id</c>:<br/>
    /// The authorization server implementation could not determine
    /// the subject of the end-user by the presented hint.
    /// </para>
    ///
    /// <para>
    /// <c>unauthorized_client</c>:<br/>
    /// The authorization server implementation has custom rules to
    /// reject backchannel authentication requests from some
    /// particular clients and found that the client which has made
    /// the backchannel authentication request is one of the
    /// particular clients. Note that
    /// <c>/api/backchannel/authentication</c> API does not return
    /// <c>action=USER_IDENTIFICATION</c> in cases where the client
    /// does not exist or client authentication has failed.
    /// Therefore, the authorization server implementation will
    /// never have to user the error code <c>unauthorized_client</c>
    /// unless the server has intentionally implemented custom
    /// rules to reject backchannel authentication requests based
    /// on clients.
    /// </para>
    ///
    /// <para>
    /// <c>missing_user_code</c>:<br/>
    /// The authorization server implementation has custom rules to
    /// require that a backchannel authentication request include
    /// a user code for some particular users and found that the
    /// user identified by the hint is one of the particular users.
    /// Note that <c>/api/backchannel/authentication</c> API does
    /// not return <c>action=USER_IDENTIFICATION</c> when both the
    /// <c>backchannel_user_code_parameter_supported</c> metadata
    /// of the server and the <c>backchannel_user_code_parameter</c>
    /// metadata of the client are <c>true</c> and the backchannel
    /// authentication request does not include the <c>user_code</c>
    /// request parameter. In this case,
    /// <c>/api/backchannel/authentication</c> API returns
    /// <c>action=BAD_REQUEST</c> with JSON containing
    /// <c>"error":"missing_user_code"</c>. Therefore, the
    /// authorization server implementation will never have to use
    /// the error code <c>missing_user_code</c> unless the server
    /// has intentionally implemented custom rules to require a
    /// user code based on users even in the case where the
    /// <c>backchannel_user_code_parameter</c> metadata of the
    /// client which has made the backchannel authentication
    /// request is <c>false</c>.
    /// </para>
    ///
    /// <para>
    /// <c>invalid_user_code</c>:<br/>
    /// The authorization server implementation detected that the
    /// presented user code is invalid. Note that the format of
    /// <c>user_code</c> is not described in the CIBA Core spec at
    /// all and so there is no consensus on how to judge whether a
    /// user code is valid or not. It is up to each authorization
    /// server implementation how to handle user codes.
    /// </para>
    ///
    /// <para>
    /// <c>invalid_binding_message</c>:<br/>
    /// The authorization server implementation detected that the
    /// presented binding message is invalid. Note that the format
    /// of <c>binding_message</c> is not described in the CIBA Core
    /// spec at all and so there is no consensus on how to judge
    /// whether a binding message is valid or not. It is up to each
    /// authorization server implementation how to handle binding
    /// messages.
    /// </para>
    ///
    /// <para>
    /// <c>access_denied</c>:<br/>
    /// The authorization server implementation has custom rules to
    /// reject backchannel authentication requests without asking
    /// the end-user and respond to the client as if the end-user
    /// had rejected the request in some particular cases and found
    /// that the backchannel authentication requests is one of the
    /// particular cases. The authorization server implementation
    /// will never have to use the error code <c>access_denied</c>
    /// at this timing unless the server has intentionally
    /// implemented custom rules to reject backchannel
    /// authentication requests without asking th end-user and
    /// respond to the client as if the end-user had rejected the
    /// request.
    /// </para>
    ///
    /// <para><b>[AUTH_REQ_ID ISSUE]</b></para>
    ///
    /// <para>
    /// If the authorization server implementation has successfully
    /// determined the subject of the end-user, the next action is
    /// to return an HTTP response to the client application which
    /// contains <c>auth_req_id</c>.
    /// </para>
    ///
    /// <para>
    /// Authlete provides <c>/api/backchannel/authentication/issue</c>
    /// API which generates a JSON containing <c>auth_req_id</c>,
    /// so, your next action is (1) call the API, (2) receive the
    /// response from the API, (3) build a response to the client
    /// application using the content of the API response, and (4)
    /// return the response to the client application. See the
    /// description of <c>/api/backchannel/authentication/issue</c>
    /// API for details.
    /// </para>
    ///
    /// <para><b>[END-USER AUTHENTICATION AND AUTHORIZATION]</b></para>
    ///
    /// <para>
    /// After sending a JSON containing <c>auth_req_id</c> back to
    /// the client application, the authorization server
    /// implementation starts to communicate with an authentication
    /// device of the end-user. It is assumed that end-user
    /// authentication is performed on the authentication device
    /// and the end-user confirms the content of the backchannel
    /// authentication request and grants authorization to the
    /// client application if everything is okay. The authorization
    /// server implementation must be able to receive the result of
    /// the end-user authentication and authorization from the
    /// authentication device.
    /// </para>
    ///
    /// <para>
    /// How to communicate with an authentication device and achieve
    /// end-user authentication and authorization is up to each
    /// authorization server implementation, but the following
    /// request parameters of the backchannel authentication request
    /// should be taken into consideration in any implementation.
    /// </para>
    ///
    /// <para>
    /// <c>acr_values</c> (<c>Acrs</c> property):<br/>
    /// A backchannel authentication request may contain an array
    /// of ACRs (Authentication Context Class References) in
    /// preference order. If multiple authentication devices are
    /// registered for the end-user, the authorization server
    /// implementation should take the ACRs into consideration when
    /// selecting the best authentication device.
    /// </para>
    ///
    /// <para>
    /// <c>scope</c> (<c>Scopes</c> property):<br/>
    /// A backchannel authentication request always contains a list
    /// of scopes. At least, <c>openid</c> is included in the list
    /// (otherwise <c>/api/backchannel/authentication</c> API
    /// returns <c>action=BAD_REQUESET</c>). It would be better to
    /// show the requested scopes to the end-user on the
    /// authentication device or somewhere appropriate. If the
    /// <c>scope</c> request parameter contains <c>address</c>,
    /// <c>email</c>, <c>phone</c> and/or <c>profile</c>, they are
    /// interpreted as defined in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">5.4.
    /// Requesting Claims using Scope Values</a> of OpenID Connect
    /// Core 1.0. That is, they are expanded into a list of claim
    /// names. The <c>ClaimNames</c> property holds the expanded
    /// result.
    /// </para>
    ///
    /// <para>
    /// <c>bind_message</c> (<c>BindingMessage</c> property):<br/>
    /// A backchannel authentication request may contain a binding
    /// message. It is a human readable identifier or message
    /// intended to be displayed on both the consumption device
    /// (client application) and the authentication device.
    /// </para>
    ///
    /// <para>
    /// <c>user_code</c> (<c>UserCode</c> property):<br/>
    /// A backchannel authentication request may contain a user code.
    /// It is a secret code, such as password or pin, known only to
    /// the end-user but verifiable by the authorization server.
    /// The user code should be used to authorize sending a request
    /// to the authentication device.
    /// </para>
    ///
    /// <para><b>[END-USER AUTHENTICATION AND AUTHORIZATION COMPLETION]</b></para>
    ///
    /// <para>
    /// After receiving the result of end-user authentication and
    /// authorization, the authorization server implementation must
    /// call Authlete's <c>/api/backchannel/authentication/complete</c>
    /// API to tell Authlete the result and pass necessary data so
    /// that Authlete can generate an ID token, an access token and
    /// optionally a refresh token. See the description of the API
    /// for details.
    /// </para>
    ///
    /// <para><b>[CLIENT NOTIFICATION]</b></para>
    ///
    /// <para>
    /// When the backchannel token delivery mode is either "ping"
    /// or "push", the authorization server implementation must
    /// send a notification to the pre-registered notification
    /// endpoint of the client after the end-user authentication
    /// and authorization. In this case, the <c>Action</c> property
    /// of <c>BackchannelAuthenticationCompleteResponse</c> (a
    /// response from <c>/api/backchannel/authentication/complete</c>
    /// API) holds
    /// <c>BackchannelAuthenticationCompleteAction.NOTIFICATION</c>.
    /// See the description of
    /// <c>/api/backchannel/authentication/complete</c> API for
    /// details.
    /// </para>
    ///
    /// <para><b>[TOKEN REQUEST]</b></para>
    ///
    /// <para>
    /// When the backchannel token delivery mode is either "ping"
    /// or "poll", the client application will make one or more
    /// token requests to the token endpoint to get an ID token, an
    /// access token and optionally a refresh token.
    /// </para>
    ///
    /// <para>
    /// A token request that corresponds to a backchannel
    /// authentication request uses
    /// <c>urn:openid:params:grant-type:ciba</c> as the value of
    /// the <c>grant_type</c> request parameter. Authlete's
    /// <c>/api/auth/token</c> API recognizes the grant type
    /// automatically and behaves properly, so the existing token
    /// endpoint implementation does not have to be changed to
    /// support CIBA.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BackchannelAuthenticationAction Action { get; set; }


        /// <summary>
        /// The response content which can be used to generate a
        /// response to the client application.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When this property holds a non-null value, it is JSON
        /// containing error information. When the <c>Action</c>
        /// property holds <c>USER_IDENTIFICATION</c>, the value of
        /// this property is null.
        /// </para>
        /// </remarks>
        [JsonProperty("responseContent")]
        public string ResponseContent { get; set; }


        /// <summary>
        /// The client ID of the client application.
        /// </summary>
        [JsonProperty("clientId")]
        public long ClientId { get; set; }


        /// <summary>
        /// The client ID alias of the client application.
        /// </summary>
        [JsonProperty("clientIdAlias")]
        public string ClientIdAlias { get; set; }


        /// <summary>
        /// The flag which indicates whether the client ID alias
        /// was used in the backchannel authentication request.
        /// </summary>
        [JsonProperty("clientIdAliasUsed")]
        public bool IsClientIdAliasUsed { get; set; }


        /// <summary>
        /// The name of the client application.
        /// </summary>
        [JsonProperty("clientName")]
        public string ClientName { get; set; }


        /// <summary>
        /// The backchannel token delivery mode of the client
        /// application.
        /// </summary>
        [JsonProperty("deliveryMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryMode DeliveryMode { get; set; }


        /// <summary>
        /// The scopes requested by the backchannel authentication
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Basically, this property holds the value of the <c>scope</c>
        /// request parameter in the backchannel authentication
        /// request. However, because unregistered scopes are
        /// dropped on Authlete side, if the <c>scope</c> request
        /// parameter contains unknown scopes, the list held by
        /// this property becomes different from the value of the
        /// <c>scope</c> request parameter.
        /// </para>
        ///
        /// <para>
        /// Note that <c>Description</c> property and
        /// <c>Descriptions</c> property of each element (<c>Scope</c>
        /// instance) in the array held by this property always
        /// null even if descriptions of the scopes are registered.
        /// </para>
        /// </remarks>
        [JsonProperty("scopes")]
        public Scope[] Scopes { get; set; }


        /// <summary>
        /// The names of the claims which were requested indirectly
        /// via some special scopes. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims">5.4.
        /// Requesting Claims using Scope Values</a> in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </summary>
        [JsonProperty("claimNames")]
        public string[] ClaimNames { get; set; }


        /// <summary>
        /// The client notification token included in the
        /// backchannel authentication request. It is the value of
        /// the <c>client_notification_token</c> request parameter.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the backchannel token delivery mode is "ping" or
        /// "push", the backchannel authentication request must
        /// include a client notification token.
        /// </para>
        /// </remarks>
        [JsonProperty("clientNotificationToken")]
        public string ClientNotificationToken { get; set; }


        /// <summary>
        /// The list of ACRs (Authentication Context Class
        /// References) requested by the backchannel authentication
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Basically, this property holds the value of the
        /// <c>acr_values</c> request parameter in the backchannel
        /// authentication request. However, because unsupported
        /// ACR values are dropped on Authlete side, if the
        /// <c>acr_values</c> request parameter contains
        /// unrecognized ACR values, the list this property holds
        /// becomes different from the value of the <c>acr_values</c>
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("acrs")]
        public string[] Acrs { get; set; }


        /// <summary>
        /// The type of the hint for end-user identification which
        /// was included in the backchannel authentication request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the backchannel authentication request contains
        /// <c>id_token_hint</c>, this property holds
        /// <c>UserIdentificationHintType.ID_TOKEN_HINT</c>.
        /// Likewise, this property holds
        /// <c>UserIdentificationHintType.LOGIN_HINT</c> when the
        /// request contains <c>login_hint</c>, or holds
        /// <c>UserIdentificationHintType.LOGIN_HINT_TOKEN</c> when
        /// the request contains <c>login_hint_token</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("hintType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserIdentificationHintType HintType { get; set; }


        /// <summary>
        /// The value of the hint for end-user identification.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the <c>HintType</c> property holds
        /// <c>UserIdentificationHintType.ID_TOKEN_HINT</c>, this
        /// property holds the value of the <c>id_token_hint</c>
        /// request parameter. Likewise, this property holds the
        /// value of the <c>login_hint</c> request parameter when
        /// the <c>HintType</c> property holds
        /// <c>UserIdentificationHintType.LOGIN_HINT</c>, or holds
        /// the value of the <c>login_hint_token</c> request
        /// parameter when the <c>HintType</c> property holds
        /// <c>UserIdentificationHintType.LOGIN_HINT_TOKEN</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("hint")]
        public string Hint { get; set; }


        /// <summary>
        /// The value of the <c>sub</c> claim contained in the ID
        /// token hint included in the backchannel authentication
        /// request.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property works only when the backchannel
        /// authentication request contains the <c>id_token_hint</c>
        /// request parameter.
        /// </para>
        /// </remarks>
        [JsonProperty("sub")]
        public string Sub { get; set; }


        /// <summary>
        /// The binding message included in the backchannel
        /// authentication request. It is the value of the
        /// <c>binding_message</c> request parameter.
        /// </summary>
        [JsonProperty("bindingMessage")]
        public string BindingMessage { get; set; }


        /// <summary>
        /// The user code included in the backchannel authentication
        /// request. It is the value of the <c>user_code</c> request
        /// parameter.
        /// </summary>
        [JsonProperty("userCode")]
        public string UserCode { get; set; }


        /// <summary>
        /// The flag which indicates whether a user code is required.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property holds <c>true</c> when both the
        /// <c>backchannel_user_code_parameter</c> metadata of the
        /// client (= <c>IsBcUserCodeRequired</c> property of the
        /// <c>Client</c> class) and the
        /// <c>backchannel_user_code_parameter_supported</c>
        /// metadata of the server
        /// (= <c>IsBackchannelUserCodeParameterSupported</c>
        /// property of the <c>Service</c> class) are <c>true</c>.
        /// </para>
        /// </remarks>
        [JsonProperty("userCodeRequired")]
        public bool IsUserCodeRequired { get; set; }


        /// <summary>
        /// The requested expiry for the authentication request ID
        /// (<c>auth_req_id</c>). It is the value of the
        /// <c>requested_expiry</c> request parameter.
        /// </summary>
        [JsonProperty("requestedExpiry")]
        public int RequestedExpiry { get; set; }


        /// <summary>
        /// The request context of the backchannel authentication request. It
        /// is the value of the <c>request_context</c> claim in the signed
        /// authentication request object and its format is JSON.
        /// <c>request_context</c> is a new claim added by the FAPI-CIBA profile.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This property is null if the backchannel authentication request does
        /// not include a <c>request</c> request parameter or the JWT specified
        /// by the request parameter does not include a <c>request_context</c>
        /// claim.
        /// </para>
        ///
        /// <para>
        /// Since version 1.4.0.
        /// </para>
        /// </remarks>
        [JsonProperty("requestContext")]
        public string RequestContext { get; set; }


        /// <summary>
        /// The resources specified by the <c>resource</c> request parameters or
        /// by the <code>resource</code> property in the request object in the
        /// preceding backchannel authentication request. If both are given, the
        /// values in the request object take precedence. See
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
        /// The warnings raised during processing the backchannel
        /// authentication request.
        /// </summary>
        [JsonProperty("warnings")]
        public string[] Warnings { get; set; }


        /// <summary>
        /// The ticket that is necessary for the implementation of
        /// the backchannel authentication endpoint to call
        /// <c>/api/backchannel/authentication/*</c> API.
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }
    }
}
