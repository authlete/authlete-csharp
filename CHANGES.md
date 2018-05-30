CHANGES
=======

1.1.0 (2018-05-30)
------------------

- `AuthorizationRequestHandlerSpiAdapter` class
    * Implemented `IAuthorizationRequestHandlerSpi` interface.

- `Client` class
    * Added `SelfSignedCertificateKeyId` property.
    * Renamed `IsMutualTlsSenderConstrainedAccessTokens` property to
      `IsTlsClientCertificateBoundAccessTokens`.

- `IntrospectionResponse` class
    * Added `Properties` property.
    * Added `ClientIdAlias` property.
    * Added `IsClientIdAliasUsed` property.

- `Service` class
    * Added `IsMutualTlsValidatePkiCertChain` property.
    * Added `TrustedRootCertificates` property.
    * Renamed `IsMutualTlsSenderConstrainedAccessTokens` property to
      `IsTlsClientCertificateBoundAccessTokens`.

- `TokenRequest` class
    * Added `ClientCertificatePath` property.


1.0.9 (2018-03-15)
------------------

- `Client` class
    * Added `IsMutualTlsSenderConstrainedAccessTokens` property.

- `IntrospectionRequest` class
    * Added `ClientCertificate` property.

- `IntrospectionResponse` class
    * Added `CertificateThumbprint` property.

- `Service` class
    * Added `IsMutualTlsSenderConstrainedAccessTokens` property.
    * Added `SupportedRevocationAuthMethods` property.
    * Added `SupportedRevocationAuthSigningAlgorithms` property.
    * Added `IntrospectionEndpoint` property.
    * Added `SupportedIntrospectionAuthMethods` property.
    * Added `SupportedIntrospectionAuthSigningAlgorithms` property.


1.0.8 (2018-03-11)
------------------

- `Scope` class
    * Added `Attributes` property.

- `Service` class
    * Added `SupportedServiceProfiles` property.

- `TokenRequest` class
    * Added `ClientCertificate` property.

- New types
    * `Pair` class
    * `ServiceProfie` enum


1.0.7 (2018-01-08)
------------------

- Added `AccessTokenValidator` class.


1.0.6 (2018-01-08)
------------------

- Renamed `Existent` property in `IntrospectionResponse` to `IsExistent`.
- Renamed `Usable` property in `IntrospectionResponse` to `IsUsable`.
- Renamed `Sufficient` property in `IntrospectionResponse` to `IsSufficient`.
- Renamed `Refreshable` property in `IntrospectionResponse` to `IsRefreshable`.
- Added `IsActive` property to `IntrospectionResponse` as an alias of `IsUsable`.


1.0.5 (2018-01-07)
------------------

- Removed `PrepareUserClaims` method from `IUserInfoRequestHandlerSpi`.


1.0.4 (2018-01-06)
------------------

- Fixed the attribute of `AuthorizationResponse.Prompts`.


1.0.3 (2018-01-04)
------------------

- Added `TokenRequestHandler.Handle(string, string)` method.
- Added `TokenRequestHandler.Handle(string, BasicCredentials)` method.
- Added `RevocationRequestHandler.Handle(string, string)` method.
- Added `RevocationRequestHandler.Handle(string, BasicCredentials)` method.


1.0.2 (2018-01-02)
------------------

- Fixed a bug in `AuthleteApi` where objects which
  should not be processed by the JSON processor
  were passed to the JSON processor.


1.0.1 (2018-01-02)
------------------

- Fixed a bug in `BasicCredentials.Parse(string)`.
- Fixed a bug in `AuthleteApi` where Authorization header was badly formatted.
- Added `BasicCredentials.FormattedParameter` property.


1.0.0 (2018-01-01)
------------------

- First release.
