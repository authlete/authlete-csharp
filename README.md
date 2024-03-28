README
======

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

  <code>https://docs.authlete.com/</code>


NuGet
-----

  [Authlete.Authlete][8]


Samples
-------

  * [csharp-oauth-server][9] - Authorization server
  * [csharp-resource-server][10] - Resource server
  * [OAuth 2.0 and OpenID Connect implementation in C# (Authlete)][11] - Article about the two servers above


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
// In the current implementation, the value set to the Timeout
// property is passed to HttpClient.Timeout.
//
settings.Timeout = TimeSpan.FromSeconds(5);
```


#### IAuthleteApi Method Categories

Methods in the `IAuthleteApi` interface can be divided into some
categories.

  1. Methods for Authorization Endpoint Implementation

    - `Authorization(AuthorizationRequest request)`
    - `AuthorizationFail(AuthorizationFailRequest request)`
    - `AuthorizationIssue(AuthorizationIssueRequest request)`

  2. Methods for Token Endpoint Implementation

    - `Token(TokenRequest request)`
    - `TokenFail(TokenFailRequest request)`
    - `TokenIssue(TokenIssueRequest request)`

  3. Methods for Service Management

    - `CreateService(Service service)`
    - `DeleteService(long serviceApiKey)`
    - `GetService(long serviceApiKey)`
    - `GetServiceList()`
    - `GetServiceList(int start, int end)`
    - `UpdateService(Service service)`

  4. Methods for Client Application Management

    - `CreateClient(Client client)`
    - `DeleteClient(long clientId)`
    - `GetClient(long clientId)`
    - `GetClientList()`
    - `GetClientList(string developer)`
    - `GetClientList(int start, int end)`
    - `GetClientList(string developer, int start, int end)`
    - `UpdateClient(Client client)`
    - `RefreshClientSecret(long clientId)`
    - `RefreshClientSecret(string clientIdentifier)`
    - `UpdateClientSecret(long clientId, string clientSecret)`
    - `UpdateClientSecret(string clientIdentifier, string clientSecret)`

  5. Methods for Access Token Introspection

    - `Introspection(IntrospectionRequest request)`
    - `StandardIntrospection(StandardIntrospectionRequest request)`

  6. Methods for Revocation Endpoint Implementation

    - `Revocation(RevocationRequest request)`

  7. Methods for User Info Endpoint Implementation

    - `Userinfo(UserInfoRequest request)`
    - `UserinfoIssue(UserInfoIssueRequest request)`

  8. Methods for JWK Set Endpoint Implementation

    - `GetServiceJwks()`
    - `GetServiceJwks(bool pretty, bool includePrivateKeys)`

  9. Methods for OpenID Connect Discovery

    - `GetServiceConfiguration()`
    - `GetServiceConfiguration(bool pretty)`

  10. Methods for Token Operations

    - `TokenCreate(TokenCreateRequest request)`
    - `TokenDelete(string token)`
    - `TokenUpdate(TokenUpdateRequest request)`

  11. Methods for Records of Granted Scopes

    - `GetGrantedScopes(long clientId, string subject)`
    - `DeleteGrantedScopes(long clientId, string subject)`

  12. Methods for Authorization Management on a User-Client Combination Basis

    - `DeleteClientAuthorization(long clientId, string subject)`
    - `GetClientAuthorizationList(ClientAuthorizationGetListRequest request)`
    - `UpdateClientAuthorization(long clientId, ClientAuthorizationUpdateRequest request)`

  13. Methods for CIBA (Client Initiated Backchannel Authentication)

    - `BackchannelAuthentication(BackchannelAuthenticationRequest request)`
    - `BackchannelAuthenticationIssue(BackchannelAuthenticationIssueRequest request)`
    - `BackchannelAuthenticationFail(BackchannelAuthenticationFailRequest request)`
    - `BackchannelAuthenticationComplete(BackchannelAuthenticationCompleteRequest request)`

  14. Methods for Device Flow

    - `DeviceAuthorization(DeviceAuthorizationRequest request)`
    - `DeviceComplete(DeviceCompleteRequest request)`
    - `DeviceVerification(DeviceVerificationRequest request)`

  15. Methods for Pushed Authorization Requests

    - `PushAuthorizationRequest(PushedAuthReqRequest request)`

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

You can find the usage of the handlers in [csharp-oauth-server][9]
and [csharp-resource-server][10]. They are sample implementations
of an authorization server and a resource server.
[OAuth 2.0 and OpenID Connect implementation in C# (Authlete)][11]
is an article about the two sample servers.


How To Test
-----------

    $ cd Authlete.Tests
    $ dotnet test

Docker Support
-----------
#### Building the Docker Image with Detailed Output

This project supports building and running inside a Docker container. The instructions below guide you through the process of building the Docker image, running the container, and retrieving test results with detailed build output.

#### Building the Docker Image

To build the Docker image with detailed build output, use the following command:

```bash
docker build -t authlete-test --progress=plain --no-cache --target build .
```

This command performs the following actions:
- `-t authlete-test` tags the built Docker image as `authlete-test`.
- `--progress=plain` displays the build output in plain text, providing detailed information during the build process.
- `--no-cache` ensures that Docker does not use any cached layers from previous builds, forcing all steps to be re-executed.
- `--target build` specifies that the Docker build process should stop after completing the `build` stage. This is particularly useful if you want to run tests without deploying the final application as part of the build process.

#### Retrieving Test Results

The Dockerfile is configured to generate test results in TRX format during the build process. To extract these test results from the Docker image to your host system, follow these steps:

1. **Create a Temporary Container from the Image**:
   Create a container named `temp-container` from your `authlete-test` image without starting it:

   ```bash
   docker create --name temp-container authlete-test
   ```

2. **Copy Test Results to Host**:
   Copy the test results from the `temp-container` to a directory on your host machine:

   ```bash
   docker cp temp-container:/test-results ./test-results
   ```

   This copies the test results stored at `/test-results` inside the container to a `./test-results` directory on your host.

3. **Cleanup**:
   Remove the temporary container:

   ```bash
   docker rm temp-container
   ```

Now, you'll find the `.trx` test result files in the `./test-results` directory on your host machine, ready for review.

How To Release
--------------

#### 1. Update Documents

Update `CHANGES.md` and `CHANGES.ja.md`. Update `README.md` and
`README.ja.md`, too, if necessary.

#### 2. Update Version

In Visual Studio, open "Options" menu of the `Authlete` project.
In the window titled "Project Options - Authlete", go to
"NuGet Package" -> "Metadata" -> "General" tab. Update the value
in the "Version:" field.

Or, edit the value of `<PackageVersion>` in `Authlete/Authlete.csproj`
file directly.

#### 3. Commit Version

    $ git add Authlete/Authlete.csproj
    $ git commit -m 'Updated PackageVersion to X.Y.Z.'
    $ git push

#### 4. Generate Package

    $ dotnet pack

  A `.nupkg` file will be created under `bin/Debug` directory.

#### 5. Publish Package

    $ nuget push bin/Debug/Authlete.Authlete.X.Y.Z.nupkg $KEY \
        -Source https://api.nuget.org/v3/index.json

  The value of `$KEY` on the command line is an API key issued by
  nuget.org. See [Publishing packages][12] for details.

  The published package will appear at https://www.nuget.org/packages/Authlete.Authlete,
  but it will take some minutes.

#### 6. Update API Reference

    $ cd ..
    $ rm -rf html
    $ doxygen

#### 7. Publish API Reference

    $ mkdir -p ../docs
    $ cd ../docs
    $ git clone https://github.com/authlete/authlete-csharp
    $ cd authlete-csharp
    $ git checkout gh-pages
    $ rm -rf *
    $ cp -r ../../authlete-csharp/html/* .
    $ git add .
    $ git commit -m 'Updated for version X.Y.Z'
    $ git push origin gh-pages



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
[3]: https://tools.ietf.org/html/rfc6749
[4]: https://openid.net/connect/
[5]: https://medium.com/@darutk/new-architecture-of-oauth-2-0-and-openid-connect-implementation-18f408f9338d
[6]: https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-
[8]: https://www.nuget.org/packages/Authlete.Authlete
[9]: https://github.com/authlete/csharp-oauth-server
[10]: https://github.com/authlete/csharp-resource-server
[11]: https://medium.com/@darutk/oauth-2-0-and-openid-connect-implementation-in-c-authlete-8a8f9efc9361
[12]: https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package
