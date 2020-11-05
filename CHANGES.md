CHANGES
=======

- `BackchannelAuthenticationCompleteRequest` class
    * Added `IdtHeaderParams` property.

- `Client` class
    * Added `IsRequestObjectRequired` property.

- `Service` class
    * Added `IsRequestObjectRequired` property.
    * Added `IsTraditionalRequestObjectProcessingApplied` property.
    * Added `IsClaimShortcutRestrictive` property.
    * Added `IsScopeRequired` property.

- New types
    * `DeviceAuthorizationAction` enum
    * `DeviceAuthorizationRequest` class
    * `DeviceAuthorizationResponse` class
    * `DeviceCompleteAction` enum
    * `DeviceCompleteRequest` class
    * `DeviceCompleteResponse` class
    * `DeviceCompleteResult` enum
    * `DeviceVerificationAction` enum
    * `DeviceVerificationRequest` class
    * `DeviceVerificationResponse` class
    * `PushedAuthReqAction` enum
    * `PushedAuthReqRequest` class
    * `PushedAuthReqResponse` class


1.4.0 (2020-07-23)
------------------

- `AuthorizationFailReason` enum
    * Added `INVALID_TARGET`.

- `AuthorizationIssueRequest` class
    * Added `IdtHeaderParams` property.

- `AuthorizationResponse` class
    * Added `Purpose` property.
    * Added `Resources` property.

- `BackchannelAuthenticationCompleteResponse` class
    * Added `Resources` property.

- `BackchannelAuthenticationFailReason` enum
    * Added `INVALID_TARGET`.

- `BackchannelAuthenticationResponse` class
    * Added `RequestContext` property.
    * Added `Resources` property.

- `Client` class
    * Added `AuthorizationDataTypes` property.
    * Added `DerivedSectorIdentifier` property.
    * Added `IsDynamicallyRegistered` property.
    * Added `IsParRequired` property.
    * Added `RegistrationAccessTokenHash` property.

- `ClientExtension` class
    * Added `AccessTokenDuration` property.
    * Added `RefreshTokenDuration` property.

- `GrantType` enum
    * Added `DEVICE_CODE`.

- `IntrospectionRequest` class
    * Added `Dpop` property.
    * Added `Htm` property.
    * Added `Htu` property.

- `IntrospectionResponse` class
    * Added `Resources` property.
    * Added `AccessTokenResources` property.

- `Service` class
    * Added `DeviceAuthorizationEndpoint` property.
    * Added `DeviceFlowCodeDuration` property.
    * Added `DeviceFlowPollingInterval` property.
    * Added `DeviceVerificationUri` property.
    * Added `DeviceVerificationUriComplete` property.
    * Added `EndSessionEndpoint` property.
    * Added `IsBackchannelBindingMessageRequiredInFapi` property.
    * Added `IsDynamicRegistrationSupported` property.
    * Added `IsMissingClientIdAllowed` property.
    * Added `IsParRequired` property.
    * Added `IsRefreshTokenDurationKept` property.
    * Added `MtlsEndpointAliases` property.
    * Added `PushedAuthReqDuration` property.
    * Added `PushedAuthReqEndpoint` property.
    * Added `RegistrationManagementEndpoint` property.
    * Added `SupportedAuthorizationDataTypes` property.
    * Added `SupportedEvidence` property.
    * Added `SupportedIdentityDocuments` property.
    * Added `SupportedTrustFrameworks` property.
    * Added `SupportedVerificationMethods` property.
    * Added `SupportedVerifiedClaims` property.
    * Added `UserCodeCharset` property.
    * Added `UserCodeLength` property.

- `TokenCreateRequest` class
    * Added `CertificateThumbprint` property.
    * Added `DpopKeyThumbprint` property.

- `TokenFailReason` enum
    * Added `INVALID_TARGET`.

- `TokenIssueResponse` class
    * Added `AccessTokenResources` property.

- `TokenRequest` class
    * Added `Dpop` property.
    * Added `Htm` property.
    * Added `Htu` property.

- `TokenResponse` class
    * Added `Resources` property.
    * Added `AccessTokenResources` property.

- `TokenUpdateRequest` class
    * Added `CertificateThumbprint` property.
    * Added `DpopKeyThumbprint` property.

- `UserInfoRequest` class
    * Added `Dpop` property.
    * Added `Htm` property.
    * Added `Htu` property.

- New types
    * `NamedUri` class
    * `UserCodeCharset` enum


1.3.0 (2019-05-03)
------------------

- `AuthorizationIssueResponse` class
    * Added `AccessToken` property.
    * Added `AccessTokenDuration` property.
    * Added `AccessTokenExpiresAt` property.
    * Added `AuthorizationCode` property.
    * Added `IdToken` property.
    * Added `JwtAccessToken` property.

- `Client` class
    * Added `BcDeliveryMode` property.
    * Added `BcNotificationEndpoint` property.
    * Added `BcRequestSignAlg` property.
    * Added `IsBcUserCodeRequired` property.
    * Added `TlsClientAuthSanDns` property.
    * Added `TlsClientAuthSanEmail` property.
    * Added `TlsClientAuthSanIp` property.
    * Added `TlsClientAuthSanUri` property.

- `GrantType` enum
    * Added `CIBA`.

- `IAuthleteApi` interface
    * Added `BackchannelAuthentication(BackchannelAuthenticationRequest)` method.
    * Added `BackchannelAuthenticationComplete(BackchannelAuthenticationCompleteRequest)` method.
    * Added `BackchannelAuthenticationFail(BackchannelAuthenticationFailRequest)` method.
    * Added `BackchannelAuthenticationIssue(BackchannelAuthenticationIssueRequest)` method.

- `IAuthleteConfiguration` interface
    * Added `ServiceAccessToken` property.
    * Added `ServiceOwnerAccessToken` property.

- `Service` class
    * Added `AccessTokenSignAlg` property.
    * Added `AccessTokenSignatureKeyId` property.
    * Added `AllowableClockSkew` property.
    * Added `BackchannelAuthenticationEndpoint` property.
    * Added `BackchannelAuthReqIdDuration` property.
    * Added `BackchannelPollingInterval` property.
    * Added `IsBackchannelUserCodeParameterSupported` property.
    * Added `SupportedBackchannelTokenDeliveryModes` property.

- `TokenCreateRequest` class
    * Added `IsAccessTokenPersistent` property.

- `TokenIssueResponse` class
    * Added `JwtAccessToken` property.

- `TokenResponse` class
    * Added `JwtAccessToken` property.

- `TokenUpdateRequest` class
    * Added `AccessTokenHash` property.
    * Added `IsAccessTokenExpiresAtUpdatedOnScopeUpdate` property.
    * Added `IsAccessTokenPersistent` property.
    * Added `IsAccessTokenValueUpdated` property.

- `TokenUpdateResponse` class
    * Added `TokenType` property.

- `UserInfoRequest` class
    * Added `ClientCertificate` property.

- New types
    * `BackchannelAuthenticationAction` enum
    * `BackchannelAuthenticationRequest` class
    * `BackchannelAuthenticationResponse` class
    * `BackchannelAuthenticationCompleteAction` enum
    * `BackchannelAuthenticationCompleteRequest` class
    * `BackchannelAuthenticationCompleteResponse` class
    * `BackchannelAuthenticationCompleteResult` enum
    * `BackchannelAuthenticationFailAction` enum
    * `BackchannelAuthenticationFailReason` enum
    * `BackchannelAuthenticationFailRequest` class
    * `BackchannelAuthenticationFailResponse` class
    * `BackchannelAuthenticationIssueAction` class
    * `BackchannelAuthenticationIssueRequest` class
    * `BackchannelAuthenticationIssueResponse` class
    * `DeliveryMode` enum
    * `UserIdentificationHintType` enum


1.2.0 (2018-09-28)
------------------

- `AuthorizationResponse` class
    * Added `RequestObjectPayload` property.
    * Added `IdTokenClaims` property.
    * Added `UserInfoClaims` property.

- `Client` class
    * Added `SoftwareId` property.
    * Added `SoftwareVersion` property.
    * Added `AuthorizationSignAlg` property.
    * Added `AuthorizationEncryptionAlg` property.
    * Added `AuthorizationEncryptionEnc` property.

- `Service` class
    * Added `AuthorizationResponseDuration` property.
    * Added `IsClientIdAliasEnabled` property.
    * Added `IsErrorDescriptionOmitted` property.
    * Added `IsErrorUriOmitted` property.
    * Added `IsRefreshTokenKept` property.
    * Added `AuthorizationSignatureKeyId` property.
    * Added `IdTokenSignatureKeyId` property.
    * Added `UserInfoSignatureKeyId` property.
    * Removed `SupportedIntrospectionAuthSigningAlgorithms` property.
    * Removed `SupportedRevocationAuthSigningAlgorithms` property.

- `ServiceProfile` enum
    * Added `OPEN_BANKING`.


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
