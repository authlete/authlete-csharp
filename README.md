Authlete Library for C#
=======================

Overview
--------

This is a C# library for [Authlete Web APIs][2].

[Authlete][1] is a cloud service that provides an implementation
of [OAuth 2.0][3] & [OpenID Connect][4]. By using the Web APIs
provided by Authlete, you can develop a _DB-less_ authorization
server and/or OpenID provider. "DB-less" here means that you
don't have to manage a database server that stores authorization
data (e.g. access tokens), settings of authorization servers and
settings of client applications. These data are stored in the
Authlete server on cloud.

Please read
*[New Architecture of OAuth 2.0 and OpenID Connect Implementation][5]*
for details about the architecture of Authlete. True engineers
will love the architecture ;-)

> The primary advantage of this architecture is in that the
> backend service can focus on implementing OAuth 2.0 and OpenID
> Connect without caring about other components such as identity
> management, user authentication, login session management, API
> management and fraud detection. And, consequently, it leads to
> another major advantage which enables the backend service
> (implementation of OAuth 2.0 and OpenID Connect) to be combined
> with any solution of other components and thus gives flexibility
> to frontend server implementations.


License
-------

  Apache License, Version 2.0


Source Code (authlete-csharp)
-----------------------------

  <code>https://github.com/authlete/authlete-csharp</code>


API Reference (authlete-csharp)
-------------------------------

  <code>https://authlete.github.io/authlete-csharp/</code>


API Reference (Authlete)
------------------------

  <c>https://docs.authlete.com/</code>


NuGet
-----

  [Authlete.Authlete][8]


Description
-----------

#### How To Get IAuthleteApi

All the methods to communicate with [Authlete Web APIs][2] are
gathered in `IAuthleteApi` interface. Currently, `AuthleteApi`
class is the only class that implements the interface.

The constructor of `AuthleteApi` class requires an implementation
of `IAuthleteConfiguration` interface. Once you prepare an
implementation of `IAuthleteConfiguration` interface, you can
create an `AuthleteApi` instance as follows.

```csharp
// Prepare configuration to access Authlete Web APIs.
IAuthleteConfiguration conf = ...;

// Create an instance that implements IAuthleteApi.
IAuthleteApi api = new AuthleteApi(conf);
```

`IAuthleteConfiguration` is an interface that holds configuration
values to access Authlete Web APIs such as the URL of an Authlete
server and API credentials of a service. To be concrete, the
interface has the following properties.

| Property                | Description                |
|:------------------------|:---------------------------|
| `BaseUrl`               | URL of an Authlete server  |
| `ServiceApiKey`         | API key of a service       |
| `ServiceApiSecret`      | API secret of a service    |
| `ServiceOwnerApiKey`    | API key of your account    |
| `ServiceOwnerApiSecret` | API secret of your account |

authlete-csharp includes three implementations of
`IAuthleteConfiguration` interface as listed below.

| Class                             | Description                            |
|:----------------------------------|:---------------------------------------|
| `AuthleteEnvConfiguration`        | Configuration by environment variables |
| `AuthletePropertiesConfiguration` | Configuration by a properties file     |
| `AuthleteSimpleConfiguration`     | Configuration by C# properties         |


#### AuthletePropertiesConfiguration

Among the three implementations of `IAuthleteConfiguration`
interface, this section explains `AuthletePropertiesConfiguration`
class.

`AuthletePropertiesConfiguration` class provides a mechanism to use
a properties file to set configuration values to access Authlete Web
APIs. *Properties file* here is a kind of configuration files used
in Java world. The specification of the file format is described in
the [JavaDoc][6] of `java.util.Properties.load(java.io.Reader)`.
authlete-csharp includes an implementation that can interpret the
format (`Authlete.Util.PropertiesLoader`).

`AuthletePropertiesConfiguration` class has three constructors.
The following examples show the usage of the constructors.

```csharp
// (1) Constructor with no argument. This tries to read a file
//     named "authlete.properties". The environment variable,
//     AUTHLETE_CONFIGURATION_FILE, can be used to specify
//     another different file name.
IAuthleteConfiguration conf =
    new AuthletePropertiesConfiguration();

// (2) Constructor with the name of a configuration file.
IAuthleteConfiguration conf =
    new AuthletePropertiesConfiguration("authlete.properties");

// (3) Constructor with a TextReader.
using (TextReader reader = File.OpenText("authlete.properties"))
{
    IAuthleteConfiguration conf =
        new AuthletePropertiesConfiguration(reader);
}
```

`AuthletePropertiesConfiguration` class expects entries in the
table below to be found in the given configuration file.

| Property Key               | Description                |
|:---------------------------|:---------------------------|
| `base_url`                 | URL of an Authlete server  |
| `service.api_key`          | API key of a service       |
| `service.api_secret`       | API secret of a service    |
| `service_owner.api_key`    | API key of your account    |
| `service_owner.api_secret` | API secret of your account |

Below is an example of a configuration file.

```
base_url                 = https://api.authlete.com
service_owner.api_key    = 1532787510
service_owner.api_secret = 9Y0ZARGatedJRhsYLNfiK_aKQIBCug2O3JQU6srZrpk
service.api_key          = 9463955934
service.api_secret       = AAw0rner_wjRCpk-y1A6J9s20Bvez3GxEBoL9jOJVR0
```


#### IAuthleteApi Settings

`Settings` property of `IAuthleteApi` returns an instance of
`ISettings` interface whereby you can adjust the behaviors of the
implementation of `IAuthleteApi` interface.

```csharp
// Get an implementation of IAuthleteApi interface.
IAuthleteApi api = ...;

// Get the instance which holds settings of the implementation.
ISettings settings = api.Setting;

// Set a network timeout.
//
// In the current implementation, the value set to the `Timeout`
// property is passed to `HttpClient.Timeout`.
//
settings.Timeout = TimeSpan.FromSeconds(5);
```


#### IAuthleteApi Method Categories

Methods in the `IAuthleteApi` interface can be divided into some
categories.

  1. Methods for Authorization Endpoint Implementation

    - `Authorization(AuthorizationRequest)`
    - `AuthorizationFail(AuthorizationFailRequest)`
    - `AuthorizationIssue(AuthorizationIssueRequest)`

  2. Methods for Token Endpoint Implementation

    - `Token(TokenRequest)`
    - `TokenFail(TokenFailRequest)`
    - `TokenIssue(TokenIssueRequest)`

  3. Methods for Service Management

    - `CreateService(Service)`
    - `DeleteService(long serviceApiKey)`
    - `GetService(long serviceApiKey)`
    - `GetServiceList()`
    - `GetServiceList(int start, int end)`
    - `UpdateService(Service)`

  4. Methods for Client Application Management

    - `CreateClient(Client)`
    - `DeleteClient(long clientId)`
    - `GetClient(long clientId)`
    - `GetClientList()`
    - `GetClientList(int start, int end)`
    - `UpdateClient(Client)`
    - `RefreshClientSecret(long)`
    - `RefreshClientSecret(String)`
    - `UpdateClientSecret(long, string)`
    - `UpdateClientSecret(String, string)`

  5. Methods for Access Token Introspection

    - `Introspection(IntrospectionRequest)`
    - `StandardIntrospection(StandardIntrospectionRequest)`

  6. Methods for Revocation Endpoint Implementation

    - `Revocation(RevocationRequest)`

  7. Methods for User Info Endpoint Implementation

    - `Userinfo(UserInfoRequest)`
    - `UserinfoIssue(UserInfoIssueRequest)`

  8. Methods for JWK Set Endpoint Implementation

    - `GetServiceJwks()`
    - `GetServiceJwks(bool pretty, bool includePrivateKeys)`

  9. Methods for OpenID Connect Discovery

    - `GetServiceConfiguration()`
    - `GetServiceConfiguration(bool pretty)`

  10. Methods for Token Operations

    - `TokenCreate(TokenCreateRequest)`
    - `TokenUpdate(TokenUpdateRequest)`

  11. Methods for Records of Granted Scopes

    - `GetGrantedScopes(long clientId, string subject)`
    - `DeleteGrantedScopes(long clientId, string subject)`

  12. Methods for Authorization Management on a User-Client Combination Basis

    - `DeleteClientAuthorization(long clientId)`
    - `GetClientAuthorizationList(ClientAuthorizationGetListRequest request)`
    - `UpdateClientAuthorization(long clientId, ClientAuthorizationUpdateRequest request)`

*Example*

The following code snippet is an example to get the list of your
services. Each service corresponds to an authorization server.

```csharp
// Prepare configuration to access Authlete APIs.
// AuthleteSimpleConfiguration is used here as one
// implementation of IAuthleteConfiguration interface.
// As described above, there are other implementations
// such as AuthletePropertiesConfiguraiton.
IAuthleteConfiguration conf = new AuthleteSimpleConfiguration
{
    BaseUrl               = "https://api.authlete.com",
    ServiceOwnerApiKey    = "1532787510",
    ServiceOwnerApiSecret = "9Y0ZARGatedJRhsYLNfiK_aKQIBCug2O3JQU6srZrpk",
    ServiceApiKey         = "9463955934",
    ServiceApiSecret      = "AAw0rner_wjRCpk-y1A6J9s20Bvez3GxEBoL9jOJVR0"
};

// Get an implementation of IAuthleteApi interface.
// Currently, AuthleteApi is the only class that
// implements the IAuthleteApi interface.
IAuthleteApi api = new AuthleteApi(conf);

// Get the list of services.
ServiceListResponse response = await api.GetServiceList();
```


#### Handlers

It is possible to develop an authorization server and/or OpenID
provider only with the methods of `IAuthleteApi` interface, but
the task will become much easier if you use utility classes in
`Authlete.Handler` namespace.

TODO: Write documentation about the handlers here.


TODO
----

- Write documentation about the handlers.


Contact
-------

| Purpose   | Email Address        |
|:----------|:---------------------|
| General   | info@authlete.com    |
| Sales     | sales@authlete.com   |
| PR        | pr@authlete.com      |
| Technical | support@authlete.com |


[1]: https://www.authlete.com/
[2]: https://docs.authlete.com/
[3]: http://tools.ietf.org/html/rfc6749
[4]: http://openid.net/connect/
[5]: https://medium.com/@darutk/new-architecture-of-oauth-2-0-and-openid-connect-implementation-18f408f9338d
[6]: https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-
[8]: https://www.nuget.org/packages/Authlete.Authlete
