変更点
======

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
