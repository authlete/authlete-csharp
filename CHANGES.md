CHANGES
=======

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
