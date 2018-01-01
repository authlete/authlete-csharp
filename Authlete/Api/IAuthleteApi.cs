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


using Authlete.Dto;
using System.Threading.Tasks;


namespace Authlete.Api
{
    /// <summary>
    /// Authlete API.
    /// </summary>
    public interface IAuthleteApi
    {
        /// <summary>
        /// Call Authlete's <c>/api/auth/authorization</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<AuthorizationResponse>
        Authorization(AuthorizationRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/authorization/fail</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<AuthorizationFailResponse>
        AuthorizationFail(AuthorizationFailRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/authorization/issue</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<AuthorizationIssueResponse>
        AuthorizationIssue(AuthorizationIssueRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/token</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<TokenResponse>
        Token(TokenRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/token/create</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<TokenCreateResponse>
        TokenCreate(TokenCreateRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/token/fail</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<TokenFailResponse>
        TokenFail(TokenFailRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/token/issue</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<TokenIssueResponse>
        TokenIssue(TokenIssueRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/token/update</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<TokenUpdateResponse>
        TokenUpdate(TokenUpdateRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/revocation</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<RevocationResponse>
        Revocation(RevocationRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/userinfo</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<UserInfoResponse>
        UserInfo(UserInfoRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/userinfo/issue</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<UserInfoIssueResponse>
        UserInfoIssue(UserInfoIssueRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/introspection</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<IntrospectionResponse>
        Introspection(IntrospectionRequest request);


        /// <summary>
        /// Call Authlete's <c>/api/auth/introspection/standard</c> API.
        /// </summary>
        ///
        /// <returns>
        /// A response from the API.
        /// </returns>
        ///
        /// <param name="request">
        /// Request parameters passed to the API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<StandardIntrospectionResponse>
        StandardIntrospection(StandardIntrospectionRequest request);


        /// <summary>
        /// Create a service
        /// (= call Authlete's <c>/api/service/create</c> API).
        /// </summary>
        ///
        /// <returns>
        /// Information about the service that was newly created.
        /// </returns>
        ///
        /// <param name="service">
        /// Information about the service you want to create.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<Service>
        CreateService(Service service);


        /// <summary>
        /// Delete a service
        /// (call Authlete's <c>/api/service/delete/{apiKey}</c> API).
        /// </summary>
        ///
        /// <param name="apiKey">
        /// The API key of the service.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<object>
        DeleteService(long apiKey);


        /// <summary>
        /// Get information about a service
        /// (= call Authlete's <c>/api/service/get/{apiKey}</c> API).
        /// </summary>
        ///
        /// <returns>
        /// Information about the service.
        /// </returns>
        ///
        /// <param name="apiKey">
        /// The API key of the service.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<Service>
        GetService(long apiKey);


        /// <summary>
        /// Get a list of services that belong to the service owner
        /// (= call Authlete's <c>/api/service/get/list</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This method uses the default range to limit the result
        /// set of the query. Use <c>GetServiceList(int, int)</c>
        /// to specify the range explicitly.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// A list of services.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ServiceListResponse>
        GetServiceList();


        /// <summary>
        /// Get a list of services that belong to the service owner
        /// (= call Authlete's <c>/api/service/get/list</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The pair of <c>start</c> and <c>end</c> parameters
        /// denotes the range of the result set of the query. For
        /// example, if <c>start</c> is 5 and <c>end</c> is 7, the
        /// pair makes a range from 5 (inclusive) to 7 (exclusive)
        /// and the response will contain (at most) 2 pieces of
        /// service information, i.e., information about the 6th
        /// and the 7th services (the index starts from 0).
        /// </para>
        ///
        /// <para>
        /// If <c>(end - start)</c> is equal to or less than 0,
        /// <c>ServiceListResponse.Services</c> method of the
        /// response returns <c>null</c>. But even in such a case,
        /// <c>ServiceListResponse.TotalCount</c> method returns
        /// the total count. In other words, if you want to get
        /// just the total count, you can write the code as shown
        /// below.
        /// </para>
        ///
        /// <code>
        /// // Call /api/service/get/list API.
        /// ServiceListResponse res =
        ///     await api.GetServiceList(0, 0);
        ///
        /// // Get the number of services.
        /// int totalCount = res.TotalCount;
        /// </code>
        /// </remarks>
        ///
        /// <returns>
        /// A list of services.
        /// </returns>
        ///
        /// <param name="start">
        /// The start index (inclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <param name="end">
        /// The end index (exclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ServiceListResponse>
        GetServiceList(int start, int end);


        /// <summary>
        /// Update a service
        /// (= call Authlete's <c>/api/service/update/{apiKey}</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <c>service.ApiKey</c> must return the correct API key
        /// of the service.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// Information about the updated service.
        /// </returns>
        ///
        /// <param name="service">
        /// Information about a service to update.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<Service>
        UpdateService(Service service);


        /// <summary>
        /// Get the JWK Set of a service
        /// (= call Authlete's <c>/api/service/jwks/get</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This method is an alias of
        /// <c>GetServiceJwks(false, false)</c>.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// JSON representation of the JWK Set of the service.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<string>
        GetServiceJwks();


        /// <summary>
        /// Get the JWK Set of a service
        /// (= call Authlete's <c>/api/service/jwks/get</c> API).
        /// </summary>
        ///
        /// <returns>
        /// JSON representation of the JWK Set of the service.
        /// </returns>
        ///
        /// <param name="pretty">
        /// <c>true</c> to get the JSON in pretty format.
        /// </param>
        ///
        /// <param name="includePrivateKeys">
        /// <c>true</c> to include private keys in the JSON.
        /// <c>false</c> to exclude private keys from the JSON.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<string>
        GetServiceJwks(bool pretty, bool includePrivateKeys);


        /// <summary>
        /// Get the configuration of the service in JSON format
        /// that complies with
        /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a>.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This method is an alias of
        /// <c>GetServiceConfiguration(true)</c>
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The configuration of the service in JSON format.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<string>
        GetServiceConfiguration();


        /// <summary>
        /// Get the configuration of the service in JSON format
        /// that complies with
        /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a> (= call Authlete's
        /// <c>/api/service/configuration</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// The value returned from this method can be used as the
        /// response body from <c>/.well-known/openid-configuration</c>.
        /// See
        /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html#ProviderConfig">4.
        /// Obtaining OpenID Provider Configuration Information</a>
        /// of
        /// <a href="http://openid.net/specs/openid-connect-discovery-1_0.html">OpenID
        /// Connect Discovery 1.0</a> for details.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The configuration of the service in JSON format.
        /// </returns>
        ///
        /// <param name="pretty">
        /// <c>true</c> to get the JSON in pretty format.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<string>
        GetServiceConfiguration(bool pretty);


        /// <summary>
        /// Create a client
        /// (= call Authlete's <c>/api/client/create</c> API).
        /// </summary>
        ///
        /// <returns>
        /// Information about the client that was newly created.
        /// </returns>
        ///
        /// <param name="client">
        /// Information about the client you want to create.
        ///
        /// <exception cref="AuthleteApiException"/>
        /// </param>
        Task<Client>
        CreateClient(Client client);


        /// <summary>
        /// Delete a client
        /// (call Authlete's <c>/api/client/delete/{clientId}</c> API).
        /// </summary>
        ///
        /// <param name="clientId">
        /// The client ID of the client application you want to
        /// delete.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<object>
        DeleteClient(long clientId);


        /// <summary>
        /// Get information about a client
        /// (= call Authlete's <c>/api/client/get/{clientId}</c> API).
        /// </summary>
        ///
        /// <returns>
        /// Information about the client.
        /// </returns>
        ///
        /// <param name="clientId">
        /// The client ID.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<Client>
        GetClient(long clientId);


        /// <summary>
        /// Get a list of clients that belong to the service
        /// (= call Authlete's <c>/api/client/get/list</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// This method uses the default range to limit the result
        /// set of the query. Use <c>GetClientList(int, int)</c> to
        /// specify the range explicitly.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// A list of clients.
        /// </returns>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientListResponse>
        GetClientList();


        /// <summary>
        /// Get a list of clients that belong to the developer
        /// (= call Authlete's <c>/api/client/get/list</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// When <c>developer</c> is <c>null</c>, a list of client
        /// applications that belong to the service is returned.
        /// </para>
        ///
        /// <para>
        /// This method uses the default range to limit the result
        /// set of the query. Use <c>GetClientList(string, int, int)</c>
        /// to specify the range explicitly.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// A list of clients.
        /// </returns>
        ///
        /// <param name="developer">
        /// The developer of the targeted client applications.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientListResponse>
        GetClientList(string developer);


        /// <summary>
        /// Get a list of clients that belong to the service
        /// (= call Authlete's <c>/api/client/get/list</c> API).
        /// </summary>
        ///
        /// <returns>
        /// A list of clients.
        /// </returns>
        ///
        /// <param name="start">
        /// The start index (inclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <param name="end">
        /// The end index (exclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientListResponse>
        GetClientList(int start, int end);


        /// <summary>
        /// Get a list of clients
        /// (= call Authlete's <c>/api/client/get/list</c> API).
        /// </summary>
        ///
        /// <returns>
        /// A list of clients.
        /// </returns>
        ///
        /// <remarks>
        /// <para>
        /// When <c>developer</c> is <c>null</c>, a list of clients
        /// that belong to the service is returned. Otherwise, when
        /// <c>developer</c> is not <c>null</c>, a list of clients
        /// that belong to the developer is returned.
        /// </para>
        ///
        /// <para>
        /// The pair of <c>start</c> and <c>end</c> parameters
        /// denotes the range of the result set of the query. For
        /// example, if <c>start</c> is 5 and <c>end</c> is 7, the
        /// pair makes a range from 5 (inclusive) to 7 (exclusive)
        /// and the response will contain (at most) 2 pieces of
        /// client information, i.e., information about the 6th and
        /// 7th clients (the index starts from 0).
        /// </para>
        ///
        /// <para>
        /// If <c>(end - start)</c> is equal to or less than 0,
        /// <c>ClientListResponse.Clients</c> method of the
        /// response returns <c>null</c>. But even in such a case,
        /// <c>ClientListResponse.TotalCount</c> method returns the
        /// total count. In other words, if you want to get just
        /// the total count, you can write the code as shown below.
        /// </para>
        ///
        /// <code>
        /// // Call /api/client/get/list API.
        /// ClientListResponse res =
        ///     await api.GetClientList(developer, 0, 0);
        ///
        /// // Get the number of client applications.
        /// int totalCount = res.TotalCount;
        /// </code>
        /// </remarks>
        ///
        /// <param name="developer">
        /// The developer of the targeted clients, or <c>null</c>
        /// to get a list of clients of the entire sive.
        /// </param>
        ///
        /// <param name="start">
        /// The start index (inclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <param name="end">
        /// The end index (exclusive) of the result set of the
        /// query. Must not be negative.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientListResponse>
        GetClientList(string developer, int start, int end);


        /// <summary>
        /// Update a client
        /// (= call Authlete's <c>/api/client/update/{clientId}</c> API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// <c>client.ClientId</c> must return the correct client
        /// ID of the client.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// Information about the updated client.
        /// </returns>
        ///
        /// <param name="client">
        /// Information about a client you want to update.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<Client>
        UpdateClient(Client client);


        /// <summary>
        /// Get the set of scopes that an end-user has granted to a
        /// client application (= call Authlete's
        /// <c>/api/client/granted_scopes/get/<i>{clientId}</i></c>
        /// API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// A dedicated Authlete server provides a functionality to
        /// remember the set of scopes that an end-user has granted
        /// to a client application. A remembered set is NOT
        /// removed from the database even after all existing
        /// access tokens associated with the combination of the
        /// client application and the subject have expired. Note
        /// that this functionality is not provided by the shared
        /// Authlete server.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// Scopes granted to the client application by the end-user.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <param name="subject">
        /// Subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<GrantedScopesGetResponse>
        GetGrantedScopes(long clientId, string subject);


        /// <summary>
        /// Delete DB records about the set of scopes that an
        /// end-user has granted to a client application (= call
        /// Authlete's
        /// <c>/api/client/granted_scopes/delete/<i>{clientId}</i></c>
        /// API).
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Even if you delete records about granted scopes by
        /// calling this API, existing access tokens are not
        /// deleted and scopes of existing access tokens are not
        /// changed.
        /// </para>
        ///
        /// <para>
        /// Please call this method if the end-user identified by
        /// the subject is deleted from your system. Otherwise,
        /// garbage data continue to exist in the database.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The result of the API call.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <param name="subject">
        /// Subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ApiResponse>
        DeleteGrantedScopes(long clientId, string subject);


        /// <summary>
        /// Delete all existing access tokens issued to the client
        /// application by the end-user (= call Authlete's
        /// <c>/api/client/authorization/delete/{clientId}</c> API).
        /// </summary>
        ///
        /// <returns>
        /// The result of the API call.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <param name="subject">
        /// Subject (= unique identifier) of an end-user.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ApiResponse>
        DeleteClientAuthorization(long clientId, string subject);


        /// <summary>
        /// Get the list of client applications authorized by the
        /// end-user (= call Authlete's
        /// <c>/api/client/authorization/get/list</c> API).
        /// </summary>
        ///
        /// <returns>
        /// The list of client applications.
        /// </returns>
        ///
        /// <param name="request">
        /// Conditions of the query to Authlete's
        /// <c>/api/client/authorization/get/list</c> API.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<AuthorizedClientListResponse>
        GetClientAuthorizationList(ClientAuthorizationGetListRequest request);


        /// <summary>
        /// Update attributes of all existing access tokens issued
        /// to the client application by the end-user (= call
        /// Authlete's <c>/api/client/authorization/update/{clientId}</c>
        /// API).
        /// </summary>
        ///
        /// <returns>
        /// The result of the API call.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <param name="request">
        /// Request.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ApiResponse>
        UpdateClientAuthorization(long clientId, ClientAuthorizationUpdateRequest request);


        /// <summary>
        /// Refresh the client secret of a client (= call Authlete's
        /// <c>/api/client/secret/refresh/{clientId}</c> API). A
        /// new value of the client secret will be generated by the
        /// Authlete server. If you want to specify a new value,
        /// use <c>UpdateClientSecret</c> method.
        /// </summary>
        ///
        /// <returns>
        /// The client secret.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientSecretRefreshResponse>
        RefreshClientSecret(long clientId);


        /// <summary>
        /// Refresh the client secret of a client (= call Authlete's
        /// <c>/api/client/secret/refresh/{clientId}</c> API). A
        /// new value of the client secret will be generated by the
        /// Authlete server. If you want to specify a new value,
        /// use <c>UpdateClientSecret</c> method.
        /// </summary>
        ///
        /// <returns>
        /// The client secret.
        /// </returns>
        ///
        /// <param name="clientIdentifier">
        /// Client ID.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientSecretRefreshResponse>
        RefreshClientSecret(string clientIdentifier);


        /// <summary>
        /// Update the client secret of a client (= call Authlete's
        /// <c>/api/client/secret/update/{clientId}</c> API). If
        /// you want to have the Authlete server generate a new
        /// value of the client secret, use <c>RefreshClientSecret</c>
        /// method.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Valid characters for a client secret are <c>A-Z</c>,
        /// <c>a-z</c>, <c>0-9</c>, <c>-</c>, and <c>_</c>. The
        /// maximum length of a client secret is 86.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The client secret.
        /// </returns>
        ///
        /// <param name="clientId">
        /// Client ID.
        /// </param>
        ///
        /// <param name="clientSecret">
        /// A new value of client secret.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientSecretUpdateResponse>
        UpdateClientSecret(long clientId, string clientSecret);


        /// <summary>
        /// Update the client secret of a client (= call Authlete's
        /// <c>/api/client/secret/update/{clientId}</c> API). If
        /// you want to have the Authlete server generate a new
        /// value of the client secret, use <c>RefreshClientSecret</c>
        /// method.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// Valid characters for a client secret are <c>A-Z</c>,
        /// <c>a-z</c>, <c>0-9</c>, <c>-</c>, and <c>_</c>. The
        /// maximum length of a client secret is 86.
        /// </para>
        /// </remarks>
        ///
        /// <returns>
        /// The client secret.
        /// </returns>
        ///
        /// <param name="clientIdentifier">
        /// Client ID.
        /// </param>
        ///
        /// <param name="clientSecret">
        /// A new value of client secret.
        /// </param>
        ///
        /// <exception cref="AuthleteApiException"/>
        Task<ClientSecretUpdateResponse>
        UpdateClientSecret(string clientIdentifier, string clientSecret);


        /// <summary>
        /// The reference to the settings of this <c>IAuthleteApi</c>
        /// implementation.
        /// </summary>
        ISettings Settings { get; }
    }
}
