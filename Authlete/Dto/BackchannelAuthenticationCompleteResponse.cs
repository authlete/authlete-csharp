//
// Copyright (C) 2019 Authlete, Inc.
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
using System;


namespace Authlete.Dto
{
    /// <summary>
    /// Response from Authlete's
    /// <c>/api/backchannel/authentication/complete</c> API.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Authlete's <c>/api/backchannel/authentication/complete</c>
    /// API returns JSON which can be mapped to this class. The
    /// authorization server implementation should retrieve the
    /// value of the <c>action</c> response parameter (which can be
    /// obtained via the <c>Action</c> property) from the response
    /// and take the following steps according to the value.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationCompleteAction.NOTIFICATION</c>,
    /// it means that the authorization server must send a
    /// notification to the client notification endpoint.
    /// </para>
    ///
    /// <para>
    /// According to the CIBA Core specification, the notification
    /// is an HTTP POST request whose request body is JSON and
    /// whose <c>Authorization</c> header contains the client
    /// notification token, which was included in the backchannel
    /// authentication request as the value of the
    /// <c>client_notification_token</c> request parameter, as a
    /// bearer token.
    /// </para>
    ///
    /// <para>
    /// When the backchannel token delivery mode is "ping", the
    /// request body of the notification is JSON which contains
    /// <c>auth_req_id</c> property only. When the backchannel
    /// token delivery mode is "push", the request body will
    /// additionally contain an access token, an ID token and other
    /// properties. Note that when the backchannel token delivery
    /// mode is "poll", a notification does not have to be sent to
    /// the client notification endpoint.
    /// </para>
    ///
    /// <para>
    /// In error cases, in the "ping" mode, however, the content of
    /// a notification is not different from the content in
    /// successful cases. That is, the notification contains the
    /// <c>auth_req_id</c> property only. The client will know the
    /// error when it accesses the token endpoint. On the other
    /// hand, in the "push" mode, in error cases, the content of a
    /// notification will include the <c>error</c> property instead
    /// of an access token and an ID token. The client will know
    /// the error by detecting that <c>error</c> is included in the
    /// notification.
    /// </para>
    ///
    /// <para>
    /// In any case, <c>ResponseContent</c> holds JSON which can be
    /// used as the request body of the notification.
    /// </para>
    ///
    /// <para>
    /// The client notification endpoint that the notification
    /// should be sent to is held by the
    /// <c>ClientNotificationEndpoint</c> property. Likewise, the
    /// client notification token that the notification should
    /// include as a bearer token is held by the
    /// <c>ClientNotificationToken</c> property. With these
    /// properties, the notification can be built like the
    /// following.
    /// </para>
    ///
    /// <code>
    /// POST (The path part of ClientNotificationEndpoint) HTTP/1.1
    /// Host: (The host part of ClientNotificationEndpoint)
    /// Authorization: Bearer (ClientNotificationToken)
    /// Content-Type: application/json
    ///
    /// (ResponseContent)
    /// </code>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationCompleteAction.NO_ACTION</c>,
    /// it means that the authorization server does not have to
    /// take any immediate action.
    /// </para>
    ///
    /// <para>
    /// The <c>Action</c> property holds <c>NO_ACTION</c> only when
    /// the backchannel token delivery mode is "poll". In this case,
    /// the client will receive the final result at the token
    /// endpoint.
    /// </para>
    ///
    /// <br/><hr/>
    ///
    /// <para>
    /// When the value of the <c>Action</c> property is
    /// <c>BackchannelAuthenticationCompleteAction.SERVER_ERROR</c>,
    /// it means either (1) that the request from the authorization
    /// server to Authlete was wrong, or (2) that an error occurred
    /// on Authlete side.
    /// </para>
    ///
    /// <para>
    /// When the backchannel token delivery mode is "ping" or "push",
    /// <c>SERVER_ERROR</c> is used only when an error is detected
    /// before the record of the ticket (which is included in the
    /// API call to <c>/api/backchannel/authentication/complete</c>)
    /// is retrieved from the database successfully. If an error is
    /// detected <i>after</i> the record of the ticket is retrieved
    /// from the database, <c>NOTIFICATION</c> is used instead of
    /// <c>SERVER_ERROR</c>.
    /// </para>
    ///
    /// <para>
    /// When the backchannel token delivery mode is "poll",
    /// <c>SERVER_ERROR</c> is used regardless of whether it is
    /// before or after the record of the ticket is retrieved from
    /// the database.
    /// </para>
    ///
    /// <para>
    /// Since version 1.3.0.
    /// </para>
    /// </remarks>
    public class BackchannelAuthenticationCompleteResponse : ApiResponse
    {
        /// <summary>
        /// The next action that the authorization server
        /// implementation should take.
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BackchannelAuthenticationCompleteAction Action { get; set; }


        /// <summary>
        /// The content of the notification.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When the <c>Action</c> property holds
        /// <c>BackchannelAuthenticationCompleteAction.NOTIFICATION</c>,
        /// this property holds JSON which should be used as the
        /// request body of the notification.
        /// </para>
        ///
        /// <para>
        /// In successful cases, when the backchannel token
        /// delivery mode is "ping", the JSON contains
        /// <c>auth_req_id</c>. On the other hand, when the
        /// backchannel token delivery mode is "push", the JSON
        /// contains an access token, an ID token, and optionally
        /// a refresh token (and some other properties).
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
        /// The backchannel token delivery mode.
        /// </summary>
        [JsonProperty("deliveryMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryMode DeliveryMode { get; set; }


        /// <summary>
        /// The client notification endpoint to which a
        /// notification needs to be sent.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This corresponds to the <c>client_notification_endpoint</c>
        /// metadata of the client application.
        /// </para>
        /// </remarks>
        [JsonProperty("clientNotificationEndpoint")]
        public Uri ClientNotificationEndpoint { get; set; }


        /// <summary>
        /// The client notification token which needs to be
        /// embedded as a <c>Bearer</c> token in the
        /// <c>Authorization</c> header in the notification.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This is the value of the <c>client_notification_token</c>
        /// request parameter included in the backchannel
        /// authentication request.
        /// </para>
        /// </remarks>
        [JsonProperty("clientNotificationToken")]
        public string ClientNotificationToken { get; set; }


        /// <summary>
        /// The value of the <c>auth_req_id</c> which is
        /// associated with the ticket.
        /// </summary>
        [JsonProperty("authReqId")]
        public string AuthReqId { get; set; }


        /// <summary>
        /// The newly issued access token. This property holds a
        /// non-null value only when the backchannel token delivery
        /// mode is "push" and an access token has been issued
        /// successfully.
        /// </summary>
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        /// <summary>
        /// The newly issued refresh token. This property holds a
        /// non-null value only when the backchannel token delivery
        /// mode is "push" and a refresh token has been issued
        /// successfully.
        /// </summary>
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }


        /// <summary>
        /// The newly issued ID token. This property holds a
        /// non-null value only when the backchannel token delivery
        /// mode is "push" and an ID token has been issued
        /// successfully.
        /// </summary>
        [JsonProperty("idToken")]
        public string IdToken { get; set; }


        /// <summary>
        /// The duration of the access token in seconds. If an
        /// access token has not been issued, this property holds 0.
        /// </summary>
        [JsonProperty("accessTokenDuration")]
        public long AccessTokenDuration { get; set; }


        /// <summary>
        /// The duration of the refresh token in seconds. If a
        /// refresh token has not been issued, this property holds
        /// 0.
        /// </summary>
        [JsonProperty("refreshTokenDuration")]
        public long RefreshTokenDuration { get; set; }


        /// <summary>
        /// The duration of the ID token in seconds. If an ID token
        /// has not been issued, this property holds 0.
        /// </summary>
        [JsonProperty("idTokenDuration")]
        public long IdTokenDuration { get; set; }


        /// <summary>
        /// The newly issued access token in JWT format.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// If the authorization server is configured to issue
        /// JWT-based access tokens (= if <c>AccessTokenSignAlg</c>
        /// of <c>Service</c> is a non-null value), a JWT-based
        /// access token is issued along with the original
        /// random-string one.
        /// </para>
        ///
        /// <para>
        /// Regarding the detailed format of the JWT-based access
        /// token, see the description of the <c>Service</c> class.
        /// </para>
        /// </remarks>
        [JsonProperty("jwtAccessToken")]
        public string JwtAccessToken { get; set; }
    }
}
