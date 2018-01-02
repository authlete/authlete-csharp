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


// Disable the following warning to the implementation of the
// IAuthleteApi interface.
//
//   "Missing XML comment for publicly visible type or member"
//
#pragma warning disable 1591


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Authlete.Conf;
using Authlete.Dto;
using Authlete.Util;
using Authlete.Web;
using Newtonsoft.Json;


namespace Authlete.Api
{
    /// <summary>
    /// An implementation of the <c>IAuthleteApi</c> interface.
    /// </summary>
    public class AuthleteApi : IAuthleteApi
    {
        const string AUTH_AUTHORIZATION_API_PATH            = "/api/auth/authorization";
        const string AUTH_AUTHORIZATION_FAIL_API_PATH       = "/api/auth/authorization/fail";
        const string AUTH_AUTHORIZATION_ISSUE_API_PATH      = "/api/auth/authorization/issue";
        const string AUTH_TOKEN_API_PATH                    = "/api/auth/token";
        const string AUTH_TOKEN_CREATE_API_PATH             = "/api/auth/token/create";
        const string AUTH_TOKEN_FAIL_API_PATH               = "/api/auth/token/fail";
        const string AUTH_TOKEN_ISSUE_API_PATH              = "/api/auth/token/issue";
        const string AUTH_TOKEN_UPDATE_API_PATH             = "/api/auth/token/update";
        const string AUTH_REVOCATION_API_PATH               = "/api/auth/revocation";
        const string AUTH_USERINFO_API_PATH                 = "/api/auth/userinfo";
        const string AUTH_USERINFO_ISSUE_API_PATH           = "/api/auth/userinfo/issue";
        const string AUTH_INTROSPECTION_API_PATH            = "/api/auth/introspection";
        const string AUTH_INTROSPECTION_STANDARD_API_PATH   = "/api/auth/introspection/standard";
        const string SERVICE_CONFIGURATION_API_PATH         = "/api/service/configuration";
        const string SERVICE_CREATE_API_PATH                = "/api/service/create";
        const string SERVICE_DELETE_API_PATH                = "/api/service/delete/{0}";
        const string SERVICE_GET_API_PATH                   = "/api/service/get/{0}";
        const string SERVICE_GET_LIST_API_PATH              = "/api/service/get/list";
        const string SERVICE_JWKS_GET_API_PATH              = "/api/service/jwks/get";
        const string SERVICE_UPDATE_API_PATH                = "/api/service/update/{0}";
        const string CLIENT_CREATE_API_PATH                 = "/api/client/create";
        const string CLIENT_DELETE_API_PATH                 = "/api/client/delete/{0}";
        const string CLIENT_GET_API_PATH                    = "/api/client/get/{0}";
        const string CLIENT_GET_LIST_API_PATH               = "/api/client/get/list";
        const string CLIENT_SECRET_REFRESH_API_PATH         = "/api/client/secret/refresh/{0}";
        const string CLIENT_SECRET_UPDATE_API_PATH          = "/api/client/secret/update/{0}";
        const string CLIENT_UPDATE_API_PATH                 = "/api/client/update/{0}";
        const string REQUESTABLE_SCOPES_DELETE_API_PATH     = "/api/client/extension/requestable_scopes/delete/{0}";
        const string REQUESTABLE_SCOPES_GET_API_PATH        = "/api/client/extension/requestable_scopes/get/{0}";
        const string REQUESTABLE_SCOPES_UPDATE_API_PATH     = "/api/client/extension/requestable_scopes/update/{0}";
        const string GRANTED_SCOPES_GET_API_PATH            = "/api/client/granted_scopes/get/{0}";
        const string GRANTED_SCOPES_DELETE_API_PATH         = "/api/client/granted_scopes/delete/{0}";
        const string CLIENT_AUTHORIZATION_DELETE_API_PATH   = "/api/client/authorization/delete/{0}";
        const string CLIENT_AUTHORIZATION_GET_LIST_API_PATH = "/api/client/authorization/get/list";
        const string CLIENT_AUTHORIZATION_UPDATE_API_PATH   = "/api/client/authorization/update/{0}";


        /// <summary>
        /// Constructor with configuration.
        /// </summary>
        ///
        /// <param name="configuration">
        /// Configuration to access an Authlete API server.
        /// </param>
        public AuthleteApi(IAuthleteConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            ServiceOwnerCredentials = CreateServiceOwnerCredentials(configuration);
            ServiceCredentials      = CreateServiceCredentials(configuration);
            BaseUri                 = CreateBaseUri(configuration);
            ApiClient               = CreateHttpClient();
            Settings                = new SettingsImpl(this);
        }


        /// <summary>
        /// Service owner credentials.
        /// </summary>
        BasicCredentials ServiceOwnerCredentials { get; }


        /// <summary>
        /// Service credentials.
        /// </summary>
        BasicCredentials ServiceCredentials { get; }


        /// <summary>
        /// The base URI of Authlete APIs.
        /// </summary>
        Uri BaseUri { get; }


        /// <summary>
        /// HttpClient instance used in this implementation.
        /// </summary>
        HttpClient ApiClient { get; }


        /// <summary>
        /// Create a BasicCredentials for Basic Authentication
        /// using the API key and API secret of the service owner.
        /// </summary>
        static BasicCredentials CreateServiceOwnerCredentials(
            IAuthleteConfiguration configuration)
        {
            // API key and API secret of a service owner.
            string key    = configuration.ServiceOwnerApiKey;
            string secret = configuration.ServiceOwnerApiSecret;

            return new BasicCredentials(key, secret);
        }


        /// <summary>
        /// Create a BasicCredentials for Basic Authentication
        /// using the API key and API secret of the service.
        /// </summary>
        static BasicCredentials CreateServiceCredentials(
            IAuthleteConfiguration configuration)
        {
            // API key and API secret of a service.
            string key    = configuration.ServiceApiKey;
            string secret = configuration.ServiceApiSecret;

            return new BasicCredentials(key, secret);
        }


        static Uri CreateBaseUri(
            IAuthleteConfiguration configuration)
        {
            // The base URL in the configuration.
            string url = configuration.BaseUrl;

            // If the base URL is not available.
            if (url == null)
            {
                throw new ArgumentException(
                    "The configuration does not have information about the base URL.");
            }

            Uri uri;

            try
            {
                // Try to parse the string as a Uri.
                uri = new Uri(url);
            }
            catch (UriFormatException e)
            {
                // The string is not a valid Uri.
                throw new ArgumentException(
                    "The base URL in the configuration is malformed.", e);
            }

            // If the URI is not an absolute one.
            if (uri.IsAbsoluteUri == false)
            {
                throw new ArgumentException(
                    "The base URL in the configuration must be an absolute URL.");
            }

            var builder = new UriBuilder(uri)
            {
                // Clear some parts, if any.
                Path     = null,
                Query    = null,
                Fragment = null,
                UserName = null,
                Password = null
            };

            return builder.Uri;
        }


        /// <summary>
        /// Create an <c>HttpClient</c> instance to access Authlete
        /// APIs.
        /// </summary>
        HttpClient CreateHttpClient()
        {
            var client = new HttpClient();

            // Accept: application/json
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }


        async Task<TResponse> CallApi<TResponse>(
            HttpMethod method, BasicCredentials credentials,
            string path, IDictionary<string, string> queryParams,
            object requestBody)
        {
            // Build an HTTP request to call the API.
            HttpRequestMessage request = BuildRequest(
                method, credentials, path, queryParams, requestBody);

            // Send the request to the API.
            HttpResponseMessage response = await SendRequest(request);

            // Read the content of the response.
            string content = await ReadContent(request, response);

            // If the HTTP status code of the response indicates
            // that the API call has failed.
            if (response.IsSuccessStatusCode == false)
            {
                // Create an AuthleteApiException and throw it.
                throw CreateExceptionOfApiFailure(request, response, content);
            }

            // If the response does not have a response body.
            if (content == null)
            {
                // Basically, null is returned.
                return default(TResponse);
            }

            // Some API calls use 'string' or 'object' as TResponse.
            if (typeof(TResponse) == typeof(string) ||
                typeof(TResponse) == typeof(object))
            {
                // The content should not be processed by the JSON
                // processor, so return it without conversion.
                return (TResponse)(object)content;
            }

            // Convert the content of the response to an object.
            return TextUtility.FromJson<TResponse>(content);
        }


        HttpRequestMessage BuildRequest(
            HttpMethod method, BasicCredentials credentials,
            string path, IDictionary<string, string> queryParams,
            object requestBody)
        {
            var request = new HttpRequestMessage();

            // Set the HTTP method.
            request.Method = method;

            // Set the URL of the Authlete API with query parameters.
            request.RequestUri = BuildRequestUri(path, queryParams);

            // HTTP headers of the request.
            var headers = request.Headers;

            // Set 'Authorization' header to access the Authlete API.
            headers.Authorization =
                new AuthenticationHeaderValue(
                           "Basic", credentials.FormattedParameter);

            // If a request body is given.
            if (requestBody != null)
            {
                // Set the request body.
                request.Content = BuildContent(requestBody);
            }

            return request;
        }


        Uri BuildRequestUri(
            string path, IDictionary<string, string> queryParams)
        {
            var builder = new UriBuilder(BaseUri);

            // Path part.
            builder.Path = path;

            // If query parameters are given.
            if (queryParams != null)
            {
                // Query part.
                builder.Query = BuildQuery(queryParams);
            }

            return builder.Uri;
        }


        string BuildQuery(IDictionary<string, string> queryParams)
        {
            var list = new List<string>();

            // For each query parameter.
            foreach (var pair in queryParams)
            {
                // The key of the query parameter.
                string key = ToQueryParamKey(pair.Key);

                if (key == null)
                {
                    // Ignore the invalid key.
                    continue;
                }

                // The value of the query parameter.
                string value = ToQueryParamValue(pair.Value);

                // Build "key=value" and add it to the list.
                list.Add($"{key}={value}");
            }

            if (list.Count == 0)
            {
                return null;
            }

            // Build "key0=value0&key1=value1&...".
            return String.Join("&", list);
        }


        string ToQueryParamKey(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                // Convert the invalid key to null.
                return null;
            }

            return TextUtility.UrlEncode(str);
        }


        string ToQueryParamValue(string str)
        {
            if (str == null)
            {
                // Convert the null to an empty string.
                return string.Empty;
            }

            return TextUtility.UrlEncode(str);
        }


        HttpContent BuildContent(object requestBody)
        {
            // Convert the given object into a JSON string.
            string json = TextUtility.ToJson(requestBody);

            // Content-Type: application/json; charset=UTF-8
            return new StringContent(
                json, new UTF8Encoding(), "application/json");
        }


        async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request)
        {
            Exception cause;

            try
            {
                // Send the request to the API.
                return await ApiClient.SendAsync(request);
            }
            catch (Exception e)
            {
                // Failed to send the request to the API.
                cause = e;
            }

            // The path of the Authlete API.
            string path = request.RequestUri.AbsolutePath;

            // The error message of a new exception.
            string message = $"API call to '{path}' failed: {cause.Message}";

            // Throw an AuthleteApiException.
            throw new AuthleteApiException(message, cause, request);
        }


        async Task<string> ReadContent(
            HttpRequestMessage request, HttpResponseMessage response)
        {
            Exception cause;

            try
            {
                // Read the content of the response from the API.
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                // Failed to read the content of the response.
                cause = e;
            }

            // The path of the Authlete API.
            string path = request.RequestUri.AbsolutePath;

            // The error message of a new exception.
            string message = $"Failed to read the content of the response from the '{path}' API: {cause.Message}";

            // Throw an AuthleteApiException.
            throw new AuthleteApiException(
                message, cause, request, response.StatusCode,
                response.ReasonPhrase, response.Headers);
        }


        AuthleteApiException CreateExceptionOfApiFailure(
            HttpRequestMessage request, HttpResponseMessage response,
            string content)
        {
            // The path of the Authlete API.
            string path = request.RequestUri.AbsolutePath;

            // The HTTP status code and the reason phrase of the response.
            HttpStatusCode code = response.StatusCode;
            int codeValue       = (int)code;
            string codeName     = code.ToString();
            string reason       = response.ReasonPhrase;

            // The error message of a new exception.
            string message = $"The '{path}' API returned: {codeValue} {codeName} {reason}";

            // Build an AuthleteApiException.
            return new AuthleteApiException(
                message, request, code, reason, response.Headers, content);
        }


        /// <summary>
        /// Call an API with HTTP GET method.
        /// </summary>
        async Task<TResponse> CallGetApi<TResponse>(
            BasicCredentials credentials, string path,
            IDictionary<string, string> queryParams)
        {
            return await CallApi<TResponse>(
                HttpMethod.Get, credentials, path, queryParams, null);
        }


        /// <summary>
        /// Call an API with HTTP GET method and service owner
        /// credentials.
        /// </summary>
        async Task<TResponse> CallServiceOwnerGetApi<TResponse>(
            string path, IDictionary<string, string> queryParams)
        {
            return await CallGetApi<TResponse>(
                ServiceOwnerCredentials, path, queryParams);
        }


        /// <summary>
        /// Call an API with HTTP GET method and service owner
        /// credentials without query parameters.
        /// </summary>
        async Task<TResponse> CallServiceOwnerGetApi<TResponse>(string path)
        {
            return await CallGetApi<TResponse>(
                ServiceOwnerCredentials, path, null);
        }


        /// <summary>
        /// Call an API with HTTP GET method and service credentials.
        /// </summary>
        async Task<TResponse> CallServiceGetApi<TResponse>(
            string path, IDictionary<string, string> queryParams)
        {
            return await CallGetApi<TResponse>(
                ServiceCredentials, path, queryParams);
        }


        /// <summary>
        /// Call an API with HTTP GET method and service credentials
        /// without query parameters.
        /// </summary>
        async Task<TResponse> CallServiceGetApi<TResponse>(string path)
        {
            return await CallGetApi<TResponse>(
                ServiceCredentials, path, null);
        }


        /// <summary>
        /// Call an API with HTTP POST method.
        /// </summary>
        async Task<TResponse> CallPostApi<TResponse>(
            BasicCredentials credentials, string path,
            IDictionary<string, string> queryParams,
            object requestBody)
        {
            return await CallApi<TResponse>(
                HttpMethod.Post, credentials, path,
                queryParams, requestBody);
        }


        /// <summary>
        /// Call an API with HTTP POST method and service owner
        /// credentials.
        /// </summary>
        async Task<TResponse> CallServiceOwnerPostApi<TResponse>(
            string path, IDictionary<string, string> queryParams,
            object requestBody)
        {
            return await CallPostApi<TResponse>(
                ServiceOwnerCredentials, path, queryParams, requestBody);
        }


        /// <summary>
        /// Call an API with HTTP POST method and service owner
        /// credentials without query parameters.
        /// </summary>
        async Task<TResponse> CallServiceOwnerPostApi<TResponse>(
            string path, object requestBody)
        {
            return await CallServiceOwnerPostApi<TResponse>(
                path, null, requestBody);
        }


        /// <summary>
        /// Call an API with HTTP POST method and service credentials.
        /// </summary>
        async Task<TResponse> CallServicePostApi<TResponse>(
            string path, IDictionary<string, string> queryParams,
            object requestBody)
        {
            return await CallPostApi<TResponse>(
                ServiceCredentials, path, queryParams, requestBody);
        }


        /// <summary>
        /// Call an API with HTTP POST method and service credentials
        /// without query parameters.
        /// </summary>
        async Task<TResponse> CallServicePostApi<TResponse>(
            string path, object requestBody)
        {
            return await CallServicePostApi<TResponse>(path, null, requestBody);
        }


        /// <summary>
        /// Call an API with HTTP DELETE method.
        /// </summary>
        async Task<object> CallDeleteApi(
            BasicCredentials credentials, string path,
            IDictionary<string, string> queryParams)
        {
            return await CallApi<object>(
                HttpMethod.Delete, credentials, path, queryParams, null);
        }


        /// <summary>
        /// Call an API with HTTP DELETE method and service owner
        /// credentials.
        /// </summary>
        async Task<object> CallServiceOwnerDeleteApi(
            string path, IDictionary<string, string> queryParams)
        {
            return await CallDeleteApi(
                ServiceOwnerCredentials, path, queryParams);
        }


        /// <summary>
        /// Call an API with HTTP DELETE method and service owner
        /// credentials without query parameters.
        /// </summary>
        async Task<object> CallServiceOwnerDeleteApi(string path)
        {
            return await CallServiceOwnerDeleteApi(path, null);
        }


        /// <summary>
        /// Call an API with HTTP DELETE method and service
        /// credentials.
        /// </summary>
        async Task<object> CallServiceDeleteApi(
            string path, IDictionary<string, string> queryParams)
        {
            return await CallDeleteApi(
                ServiceCredentials, path, queryParams);
        }


        /// <summary>
        /// Call an API with HTTP DELETE method and service
        /// credentials without query parameters.
        /// </summary>
        async Task<object>CallServiceDeleteApi(string path)
        {
            return await CallServiceDeleteApi(path, null);
        }


        public async Task<AuthorizationResponse>
        Authorization(AuthorizationRequest request)
        {
            return await CallServicePostApi<AuthorizationResponse>(
                AUTH_AUTHORIZATION_API_PATH, request);
        }


        public async Task<AuthorizationFailResponse>
        AuthorizationFail(AuthorizationFailRequest request)
        {
            return await CallServicePostApi<AuthorizationFailResponse>(
                AUTH_AUTHORIZATION_FAIL_API_PATH, request);
        }


        public async Task<AuthorizationIssueResponse>
        AuthorizationIssue(AuthorizationIssueRequest request)
        {
            return await CallServicePostApi<AuthorizationIssueResponse>(
                AUTH_AUTHORIZATION_ISSUE_API_PATH, request);
        }


        public async Task<TokenResponse>
        Token(TokenRequest request)
        {
            return await CallServicePostApi<TokenResponse>(
                AUTH_TOKEN_API_PATH, request);
        }


        public async Task<TokenCreateResponse>
        TokenCreate(TokenCreateRequest request)
        {
            return await CallServicePostApi<TokenCreateResponse>(
                AUTH_TOKEN_CREATE_API_PATH, request);
        }


        public async Task<TokenFailResponse>
        TokenFail(TokenFailRequest request)
        {
            return await CallServicePostApi<TokenFailResponse>(
                AUTH_TOKEN_FAIL_API_PATH, request);
        }


        public async Task<TokenIssueResponse>
        TokenIssue(TokenIssueRequest request)
        {
            return await CallServicePostApi<TokenIssueResponse>(
                AUTH_TOKEN_ISSUE_API_PATH, request);
        }


        public async Task<TokenUpdateResponse>
        TokenUpdate(TokenUpdateRequest request)
        {
            return await CallServicePostApi<TokenUpdateResponse>(
                AUTH_TOKEN_UPDATE_API_PATH, request);
        }


        public async Task<RevocationResponse>
        Revocation(RevocationRequest request)
        {
            return await CallServicePostApi<RevocationResponse>(
                AUTH_REVOCATION_API_PATH, request);
        }


        public async Task<UserInfoResponse>
        UserInfo(UserInfoRequest request)
        {
            return await CallServicePostApi<UserInfoResponse>(
                AUTH_USERINFO_API_PATH, request);
        }


        public async Task<UserInfoIssueResponse>
        UserInfoIssue(UserInfoIssueRequest request)
        {
            return await CallServicePostApi<UserInfoIssueResponse>(
                AUTH_USERINFO_ISSUE_API_PATH, request);
        }


        public async Task<IntrospectionResponse>
        Introspection(IntrospectionRequest request)
        {
            return await CallServicePostApi<IntrospectionResponse>(
                AUTH_INTROSPECTION_API_PATH, request);
        }


        public async Task<StandardIntrospectionResponse>
        StandardIntrospection(StandardIntrospectionRequest request)
        {
            return await CallServicePostApi<StandardIntrospectionResponse>(
                AUTH_INTROSPECTION_STANDARD_API_PATH, request);
        }


        public async Task<Service>
        CreateService(Service service)
        {
            return await CallServiceOwnerPostApi<Service>(
                SERVICE_CREATE_API_PATH, service);
        }


        public async Task<object>
        DeleteService(long apiKey)
        {
            return await CallServiceOwnerDeleteApi(
                String.Format(SERVICE_DELETE_API_PATH, apiKey));
        }


        public async Task<Service>
        GetService(long apiKey)
        {
            return await CallServiceOwnerGetApi<Service>(
                String.Format(SERVICE_GET_API_PATH, apiKey));
        }


        public async Task<ServiceListResponse>
        GetServiceList()
        {
            return await CallServiceOwnerGetApi<ServiceListResponse>(
                SERVICE_GET_LIST_API_PATH);
        }


        public async Task<ServiceListResponse>
        GetServiceList(int start, int end)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "start", start.ToString() },
                { "end",   end.ToString() }
            };

            return await CallServiceOwnerGetApi<ServiceListResponse>(
                SERVICE_GET_LIST_API_PATH, queryParams);
        }


        public async Task<Service>
        UpdateService(Service service)
        {
            return await CallServiceOwnerPostApi<Service>(
                String.Format(SERVICE_UPDATE_API_PATH, service.ApiKey),
                service);
        }


        public async Task<string>
        GetServiceJwks()
        {
            return await CallServiceGetApi<string>(
                SERVICE_JWKS_GET_API_PATH);
        }


        public async Task<string>
        GetServiceJwks(bool pretty, bool includePrivateKeys)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "pretty",             pretty.ToString() },
                { "includePrivateKeys", includePrivateKeys.ToString() }
            };

            return await CallServiceGetApi<string>(
                SERVICE_JWKS_GET_API_PATH, queryParams);
        }


        public async Task<string>
        GetServiceConfiguration()
        {
            return await CallServiceGetApi<string>(
                SERVICE_CONFIGURATION_API_PATH);
        }


        public async Task<string>
        GetServiceConfiguration(bool pretty)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "pretty", pretty.ToString() }
            };

            return await CallServiceGetApi<string>(
                SERVICE_CONFIGURATION_API_PATH, queryParams);
        }


        public async Task<Client>
        CreateClient(Client client)
        {
            return await CallServicePostApi<Client>(
                CLIENT_CREATE_API_PATH, client);
        }


        public async Task<object>
        DeleteClient(long clientId)
        {
            return await CallServiceDeleteApi(
                String.Format(CLIENT_DELETE_API_PATH, clientId));
        }


        public async Task<Client>
        GetClient(long clientId)
        {
            return await CallServiceGetApi<Client>(
                String.Format(CLIENT_GET_API_PATH, clientId));
        }


        public async Task<ClientListResponse>
        GetClientList()
        {
            return await CallServiceGetApi<ClientListResponse>(
                CLIENT_GET_LIST_API_PATH);
        }


        public async Task<ClientListResponse>
        GetClientList(string developer)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "developer", developer }
            };

            return await CallServiceGetApi<ClientListResponse>(
                CLIENT_GET_LIST_API_PATH, queryParams);
        }


        public async Task<ClientListResponse>
        GetClientList(int start, int end)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "start", start.ToString() },
                { "end",   end.ToString() }
            };

            return await CallServiceGetApi<ClientListResponse>(
                CLIENT_GET_LIST_API_PATH, queryParams);
        }


        public async Task<ClientListResponse>
        GetClientList(string developer, int start, int end)
        {
            // Query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "developer", developer },
                { "start",     start.ToString() },
                { "end",       end.ToString() }
            };

            return await CallServiceGetApi<ClientListResponse>(
                CLIENT_GET_LIST_API_PATH, queryParams);
        }


        public async Task<Client>
        UpdateClient(Client client)
        {
            return await CallServicePostApi<Client>(
                String.Format(CLIENT_UPDATE_API_PATH, client.ClientId),
                client);
        }


        class GrantedScopesRequest
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }
        }


        public async Task<GrantedScopesGetResponse>
        GetGrantedScopes(long clientId, string subject)
        {
            // Prepare a request body.
            var request = new GrantedScopesRequest
            {
                Subject = subject
            };

            // Call the API.
            return await CallServicePostApi<GrantedScopesGetResponse>(
                String.Format(GRANTED_SCOPES_GET_API_PATH, clientId),
                request);
        }


        public async Task<ApiResponse>
        DeleteGrantedScopes(long clientId, string subject)
        {
            // Prepare a request body.
            var request = new GrantedScopesRequest
            {
                Subject = subject
            };

            // Call the API.
            return await CallServicePostApi<ApiResponse>(
                String.Format(GRANTED_SCOPES_DELETE_API_PATH, clientId),
                request);
        }


        public async Task<ApiResponse>
        DeleteClientAuthorization(long clientId, string subject)
        {
            // Prepare a request body.
            var request = new ClientAuthorizationDeleteRequest
            {
                Subject = subject
            };

            // Call the API.
            return await CallServicePostApi<ApiResponse>(
                String.Format(CLIENT_AUTHORIZATION_DELETE_API_PATH, clientId),
                request);
        }


        public async Task<AuthorizedClientListResponse>
        GetClientAuthorizationList(ClientAuthorizationGetListRequest request)
        {
            return await CallServicePostApi<AuthorizedClientListResponse>(
                CLIENT_AUTHORIZATION_GET_LIST_API_PATH, request);
        }


        public async Task<ApiResponse>
        UpdateClientAuthorization(long clientId, ClientAuthorizationUpdateRequest request)
        {
            return await CallServicePostApi<ApiResponse>(
                String.Format(CLIENT_AUTHORIZATION_UPDATE_API_PATH, clientId),
                request);
        }


        public async Task<ClientSecretRefreshResponse>
        RefreshClientSecret(long clientId)
        {
            return await RefreshClientSecret(clientId.ToString());
        }


        public async Task<ClientSecretRefreshResponse>
        RefreshClientSecret(string clientIdentifier)
        {
            return await CallServiceGetApi<ClientSecretRefreshResponse>(
                String.Format(CLIENT_SECRET_REFRESH_API_PATH, clientIdentifier));
        }


        public async Task<ClientSecretUpdateResponse>
        UpdateClientSecret(long clientId, string clientSecret)
        {
            return await UpdateClientSecret(clientId.ToString(), clientSecret);
        }


        public async Task<ClientSecretUpdateResponse>
        UpdateClientSecret(string clientIdentifier, string clientSecret)
        {
            // Prepare a request body.
            var request = new ClientSecretUpdateRequest
            {
                ClientSecret = clientSecret
            };

            // Call the API.
            return await CallServicePostApi<ClientSecretUpdateResponse>(
                String.Format(CLIENT_SECRET_UPDATE_API_PATH, clientIdentifier),
                request);
        }


        class SettingsImpl : ISettings
        {
            readonly AuthleteApi api;
            TimeSpan timeout;


            public SettingsImpl(AuthleteApi api)
            {
                this.api = api;
            }


            public TimeSpan Timeout
            {
                get {
                    return timeout;
                }

                set {
                    timeout = value;
                    api.ApiClient.Timeout = value;
                }
            }
        }


        public ISettings Settings { get; }
    }
}
