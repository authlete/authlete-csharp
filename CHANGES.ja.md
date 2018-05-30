CHANGES (日本語)
================

1.1.0 (2018 年 05 月 30 日)
---------------------------

- `AuthorizationRequestHandlerSpiAdapter` クラス
    * `IAuthorizationRequestHandlerSpi` インターフェースを実装。

- `Client` クラス
    * `SelfSignedCertificateKeyId` プロパティーを追加。
    * `IsMutualTlsSenderConstrainedAccessTokens` プロパティーを
      `IsTlsClientCertificateBoundAccessTokens` へと名称変更。

- `IntrospectionResponse` クラス
    * `Properties` プロパティーを追加。
    * `ClientIdAlias` プロパティーを追加。
    * `IsClientIdAliasUsed` プロパティーを追加。

- `Service` クラス
    * `IsMutualTlsValidatePkiCertChain` プロパティーを追加。
    * `TrustedRootCertificates` プロパティーを追加。
    * `IsMutualTlsSenderConstrainedAccessTokens` プロパティーを
      `IsTlsClientCertificateBoundAccessTokens` へと名称変更。

- `TokenRequest` クラス
    * `ClientCertificatePath` プロパティーを追加。


1.0.9 (2018 年 03 月 15 日)
---------------------------

- `Client` クラス
    * `IsMutualTlsSenderConstrainedAccessTokens` プロパティーを追加。

- `IntrospectionRequest` クラス
    * `ClientCertificate` プロパティーを追加。

- `IntrospectionResponse` クラス
    * `CertificateThumbprint` プロパティーを追加。

- `Service` クラス
    * `IsMutualTlsSenderConstrainedAccessTokens` プロパティーを追加。
    * `SupportedRevocationAuthMethods` プロパティーを追加。
    * `SupportedRevocationAuthSigningAlgorithms` プロパティーを追加。
    * `IntrospectionEndpoint` プロパティーを追加。
    * `SupportedIntrospectionAuthMethods` プロパティーを追加。
    * `SupportedIntrospectionAuthSigningAlgorithms` プロパティーを追加。


1.0.8 (2018 年 03 月 11 日)
---------------------------

- `Scope` クラス
    * `Attributes` プロパティーを追加。

- `Service` クラス
    * `SupportedServiceProfiles` プロパティーを追加。

- `TokenRequest` クラス
    * `ClientCertificate` プロパティーを追加。

- 新しい型
    * `Pair` クラス
    * `ServiceProfie` 列挙型


1.0.7 (2018 年 01 月 08 日)
---------------------------

- `AccessTokenValidator` クラスを追加。


1.0.6 (2018 年 01 月 08 日)
---------------------------

- `IntrospectionResponse` の `Existent` プロパティーを `IsExistent` へとリネーム。
- `IntrospectionResponse` の `Usable` プロパティーを `IsUsable` へとリネーム。
- `IntrospectionResponse` の `Sufficient` プロパティーを `IsSufficient` へとリネーム。
- `IntrospectionResponse` の `Refreshable` プロパティーを `IsRefreshable` へとリネーム。
- `IntrospectinoResponse` に `IsUsable` の別名として `IsActive` プロパティーを追加。


1.0.5 (2018 年 01 月 07 日)
---------------------------

- `IUserInfoRequestHandlerSpi` から `PrepareUserClaims` メソッドを削除。


1.0.4 (2018 年 01 月 06 日)
---------------------------

- `AuthorizationResponse.Prompts` の属性を修正。


1.0.3 (2018 年 01 月 04 日)
---------------------------

- `TokenRequestHandler.Handle(string, string)` メソッドを追加。
- `TokenRequestHandler.Handle(string, BasicCredentials)` メソッドを追加。
- `RevocationRequestHandler.Handle(string, string)` メソッドを追加。
- `RevocationRequestHandler.Handle(string, BasicCredentials)` メソッドを追加。


1.0.2 (2018 年 01 月 02 日)
---------------------------

- JSON プロセッサーで処理すべきではないオブジェクトが
  JSON プロセッサーに渡されていたという `AuthleteApi`
  内の不具合を修正。


1.0.1 (2018 年 01 月 02 日)
---------------------------

- `BasicCredentials.Parse(string)` の不具合を修正。
- `AuthleteApi` 内の Authorization ヘッダー生成不具合を修正。
- `BasicCredentials.FormattedParameter` プロパティーを追加。


1.0.0 (2018 年 01 月 01 日)
---------------------------

- 最初のリリース
