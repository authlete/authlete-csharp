README (日本語)
===============

概要
--------

[Authlete Web APIs][2] のための C# ライブラリです。

[Authlete][1] は [OAuth 2.0][3] と [OpenID Connect][4] の実装を提供するクラウドサービスです。
Authlete が提供する Web API を使い、DB-less (データベース無し)
の認可サーバーを構築することができます。「DB-less」とは、認可データ (アクセストークン等)、
認可サーバーの設定、クライアントアプリケーションの設定を保存するデータベースを管理する必要が無い、という意味です。
これらのデータはクラウド上にある Authlete サーバーに保存されます。

Authlete のアーキテクチャーの詳細については、
*[New Architecture of OAuth 2.0 and OpenID Connect Implementation][5]*
をお読みください。真のエンジニアであれば、このアーキテクチャーを気に入ってくれるはずです ;-)
なお、日本語版は「[OAuth 2.0 / OIDC 実装の新アーキテクチャー][7]」です。

> The primary advantage of this architecture is in that the
> backend service can focus on implementing OAuth 2.0 and OpenID
> Connect without caring about other components such as identity
> management, user authentication, login session management, API
> management and fraud detection. And, consequently, it leads to
> another major advantage which enables the backend service
> (implementation of OAuth 2.0 and OpenID Connect) to be combined
> with any solution of other components and thus gives flexibility
> to frontend server implementations.
>
> このアーキテクチャーの一番の利点は、アイデンティティー管理やユーザー認証、
> ログインセッション管理、API 管理、不正検出などの機能について気にすることなく、
> バックエンドサービスが OAuth 2.0 と OpenID Connect の実装に集中できることにあります。
> この帰結として、バックエンドサービス (OAuth 2.0 と OpenID Connect の実装)
> をどのような技術部品とも組み合わせることが可能というもう一つの大きな利点が得られ、
> フロントエンドサーバーの実装に柔軟性がもたらされます。


ライセンス
--------

  Apache License, Version 2.0


ソースコード (authlete-csharp)
----------------------------

  <code>https://github.com/authlete/authlete-csharp</code>


API リファレンス (authlete-csharp)
--------------------------------

  <code>https://authlete.github.io/authlete-csharp/</code>


API リファレンス (Authlete)
-------------------------

  <code>https://docs.authlete.com/</code>


NuGet
-----

  [Authlete.Authlete][8]


サンプル
--------

  * [csharp-oauth-server][9] - 認可サーバー
  * [csharp-resource-server][10] - リソースサーバー
  * [C# による OAuth 2.0 と OpenID Connect の実装 (Authlete)][11] - 上記二つのサーバーに関する記事


説明
----

#### IAuthleteApi の取得方法

[Authlete Web API][2] とやりとりするメソッドは全て `IAuthleteApi`
インターフェースに集められています。
現在のところ、このインターフェースを実装するクラスは `AuthleteApi` クラスのみです。

`AuthleteApi` クラスのコンストラクターは `IAuthleteConfiguration`
インターフェースの実装を要求します。 `IAuthleteConfiguration`
インタフェースの実装が用意できれば、次のようにして `AuthleteApi`
のインスタンスを作成することができます。

```csharp
// Authlete Web API にアクセスするための設定を用意する。
IAuthleteConfiguration conf = ...;

// IAuthleteApi を実装するインスタンスを生成する。
IAuthleteApi api = new AuthleteApi(conf);
```

`IAuthleteConfiguration` は、Authlete サーバーの URL やサービスの
API クレデンシャルズなどの、Authlete Web API
にアクセスするのに必要な設定値を保持するインターフェースです。
具体的には、このインターフェースには次のようなプロパティー群があります。

| プロパティー            | 説明                                  |
|:------------------------|:--------------------------------------|
| `BaseUrl`               | Authlete サーバーの URL               |
| `ServiceApiKey`         | サービスの API キー                   |
| `ServiceApiSecret`      | サービスの API シークレット           |
| `ServiceOwnerApiKey`    | あなたのアカウントの API キー         |
| `ServiceOwnerApiSecret` | あなたのアカウントの API シークレット |

authlete-csharp には `IAuthleteConfiguration` インターフェースの実装が三つ含まれています。

| クラス                            | 説明                           |
|:----------------------------------|:-------------------------------|
| `AuthleteEnvConfiguration`        | 環境変数による設定             |
| `AuthletePropertiesConfiguration` | プロパティーファイルによる設定 |
| `AuthleteSimpleConfiguration`     | C# プロパティーによる設定      |


#### AuthletePropertiesConfiguration

`IAuthleteConfiguration` インターフェースの三つの実装のうち、ここでは
`AuthletePropertiesConfiguration` クラスについて説明します。

`AuthletePropertiesConfiguration` クラスは、Authlete Web API
へのアクセスに必要な設定をプロパティーファイルでおこなう仕組みを提供します。
ここでいうプロパティーファイルとは、Java の世界で用いられる設定ファイルの一種です。
ファイルフォーマットの仕様は `java.util.Properties.load(java.io.Reader)`
の [JavaDoc][6] に記述されています。 authlete-csharp
には、プロパティーファイルフォーマットを解釈する実装 (`Authlete.Util.Properties`)
が含まれています。

`AuthletePropertiesConfiguration` には三つのコンストラクターがあります。
下記はそれらの使用例です。

```csharp
// (1) 引数無しのコンストラクター。 "authlete.properties" という
//     名前のファイルを読もうとする。 AUTHLETE_CONFIGURATION_FILE
//     という環境変数を用いて他のファイル名を指定することもできる。
IAuthleteConfiguration conf =
    new AuthletePropertiesConfiguration();

// (2) 設定ファイル名を引数にとるコンストラクター。
IAuthleteConfiguration conf =
    new AuthletePropertiesConfiguration("authlete.properties");

// (3) TextReader を引数にとるコンストラクター。
using (TextReader reader = File.OpenText("authlete.properties"))
{
    IAuthleteConfiguration conf =
        new AuthletePropertiesConfiguration(reader);
}
```

`AuthletePropertiesConfiguration` クラスは、与えられた設定ファイル内に次の項目があることを期待しています。

| プロパティーキー           | 説明                                  |
|:---------------------------|:--------------------------------------|
| `base_url`                 | Authlete サーバーの URL               |
| `service.api_key`          | サービスの API キー                   |
| `service.api_secret`       | サービスの API シークレット           |
| `service_owner.api_key`    | あなたのアカウントの API キー         |
| `service_owner.api_secret` | あなたのアカウントの API シークレット |

下記は設定ファイルの例です。

```
base_url                 = https://api.authlete.com
service_owner.api_key    = 1532787510
service_owner.api_secret = 9Y0ZARGatedJRhsYLNfiK_aKQIBCug2O3JQU6srZrpk
service.api_key          = 9463955934
service.api_secret       = AAw0rner_wjRCpk-y1A6J9s20Bvez3GxEBoL9jOJVR0
```


#### IAuthleteApi の設定

`IAuthleteApi` の `Settings` プロパティーは `ISettings` インターフェースの実装を返します。
これを介して `IAuthleteApi` インターフェースの実装の動作を調整することができます。

```csharp
// IAuthleteApi インターフェースの実装を取得する。
IAuthleteApi api = ...;

// 実装の設定を保持するインスタンスを取得する。
ISettings settings = api.Setting;

// ネットワークタイムアウトをセットする。
//
// 現在の実装では Timeout プロパティーにセットされた値は
// HttpClient.Timeout に渡される。
//
settings.Timeout = TimeSpan.FromSeconds(5);
```


#### IAuthleteApi メソッドのカテゴリー

`IAuthleteApi` インターフェースのメソッド群は幾つかのカテゴリーに分けることができます。

  1. 認可エンドポイント実装のためのメソッド群

    - `Authorization(AuthorizationRequest request)`
    - `AuthorizationFail(AuthorizationFailRequest request)`
    - `AuthorizationIssue(AuthorizationIssueRequest request)`

  2. トークンエンドポイント実装のためのメソッド群

    - `Token(TokenRequest request)`
    - `TokenFail(TokenFailRequest request)`
    - `TokenIssue(TokenIssueRequest request)`

  3. サービス管理のためのメソッド群

    - `CreateService(Service service)`
    - `DeleteService(long serviceApiKey)`
    - `GetService(long serviceApiKey)`
    - `GetServiceList()`
    - `GetServiceList(int start, int end)`
    - `UpdateService(Service service)`

  4. クライアントアプリケーション管理のためのメソッド群

    - `CreateClient(Client client)`
    - `DeleteClient(long clientId)`
    - `GetClient(long clientId)`
    - `GetClientList()`
    - `GetClientList(int start, int end)`
    - `UpdateClient(Client client)`
    - `RefreshClientSecret(long clientId)`
    - `RefreshClientSecret(string clientIdentifier)`
    - `UpdateClientSecret(long clientId, string clientSecret)`
    - `UpdateClientSecret(string clientIdentifier, string clientSecret)`

  5. アクセストークンの情報取得のためのメソッド群

    - `Introspection(IntrospectionRequest request)`
    - `StandardIntrospection(StandardIntrospectionRequest request)`

  6. アクセストークン取り消しエンドポイント実装のためのメソッド群

    - `Revocation(RevocationRequest request)`

  7. ユーザー情報エンドポイント実装のためのメソッド群

    - `Userinfo(UserInfoRequest request)`
    - `UserinfoIssue(UserInfoIssueRequest request)`

  8. JWK セットエンドポイント実装のためのメソッド群

    - `GetServiceJwks()`
    - `GetServiceJwks(bool pretty, bool includePrivateKeys)`

  9. OpenID Connect Discovery のためのメソッド群

    - `GetServiceConfiguration()`
    - `GetServiceConfiguration(bool pretty)`

  10. トークン操作のためのメソッド群

    - `TokenCreate(TokenCreateRequest request)`
    - `TokenUpdate(TokenUpdateRequest request)`

  11. 付与されたスコープの記録に関するメソッド群

    - `GetGrantedScopes(long clientId, string subject)`
    - `DeleteGrantedScopes(long clientId, string subject)`

  12. ユーザー・クライアント単位の認可管理に関するメソッド群

    - `DeleteClientAuthorization(long clientId, string subject)`
    - `GetClientAuthorizationList(ClientAuthorizationGetListRequest request)`
    - `UpdateClientAuthorization(long clientId, ClientAuthorizationUpdateRequest request)`

*例*

次のコードは既存のサービスのリストを取得する例です。
各サービスは一つの認可サーバーに対応します。

```csharp
// Authlete API にアクセスするための設定を用意する。ここでは
// IAuthleteConfiguration インターフェースの実装の一つとして
// AuthleteSimpleConfiguration を用いている。前述のとおり、
// AuthletePropertiesConfiguration など、他の実装もある。
IAuthleteConfiguration conf = new AuthleteSimpleConfiguration
{
    BaseUrl               = "https://api.authlete.com",
    ServiceOwnerApiKey    = "1532787510",
    ServiceOwnerApiSecret = "9Y0ZARGatedJRhsYLNfiK_aKQIBCug2O3JQU6srZrpk",
    ServiceApiKey         = "9463955934",
    ServiceApiSecret      = "AAw0rner_wjRCpk-y1A6J9s20Bvez3GxEBoL9jOJVR0"
};

// IAuthleteApi インターフェースの実装を取得する。
// 現在のところ IAuthleteApi インターフェースを
// 実装しているのは AuthleteApi クラスのみ。
IAuthleteApi api = new AuthleteApi(conf);

// サービスのリストを取得する。
ServiceListResponse response = await api.GetServiceList();
```


#### ハンドラー

`IAuthleteApi` インターフェースのメソッド群だけを用いて認可サーバーや
OpenID プロバイダーを開発することも可能ですが、`Authlete.Handler`
名前空間にあるユーティリティークラス群を用いることで、作業はもっと簡単になります。

ハンドラーの使用例の使用例は [csharp-oauth-server][9] と
[cshar-resource-server][10] にあります。
これらは認可サーバーとリソースサーバーのサンプル実装です。
『[C# による OAuth 2.0 と OpenID Connect の実装 (Authlete)][11]』
はこれらの二つのサンプルサーバーに関する記事です。


テスト手順
----------

    $ cd Authlete.Tests
    $ dotnet test


リリース手順
------------

#### 1. ドキュメント更新

`CHANGES.md` と `CHANGES.ja.md` を更新する。 必要があれば `README.md` と
`README.ja.md` も更新する。

#### 2. バージョン更新

Visual Studio で `Authlete` プロジェクトの「オプション」メニューを開く。
「プロジェクト オプション - Authlete」というタイトルのウィンドウで、
「NuGet パッケージ」→「メタデータ」→「全般」タブ、と進む。
「バージョン:」欄の値を更新する。

もしくは、`Authlete/Authlete.csproj` ファイル内の `<PackageVersion>`
の値を直接更新する。

#### 3. バージョン確定

    $ git add Authlete/Authlete.csproj
    $ git commit -m 'Updated PackageVersion to X.Y.Z.'
    $ git push

#### 4. パッケージ生成

    $ dotnet pack

  `bin/Debug` ディレクトリに `.nupkg` ファイルが生成される。

#### 5. パッケージ公開

    $ nuget push bin/Debug/Authlete.Authlete.X.Y.Z.nupkg $KEY \
        -Source https://api.nuget.org/v3/index.json

  コマンドライン上の `$KEY` の値は nuget.org から発行された API キー。
  詳細は『[Publishing packages][12]』を参照のこと。

　公開されたパッケージは https://www.nuget.org/packages/Authlete.Authlete
  にリストされるが、何分か時間がかかる。

#### 6. API リファレンス更新

    $ cd ..
    $ rm -rf html
    $ doxygen

#### 7. API リファレンス公開

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


コンタクト
----------

| 目的 | メールアドレス       |
|:-----|:---------------------|
| 一般 | info@authlete.com    |
| 営業 | sales@authlete.com   |
| 広報 | pr@authlete.com      |
| 技術 | support@authlete.com |


[1]: https://www.authlete.com/
[2]: https://docs.authlete.com/
[3]: https://tools.ietf.org/html/rfc6749
[4]: https://openid.net/connect/
[5]: https://medium.com/@darutk/new-architecture-of-oauth-2-0-and-openid-connect-implementation-18f408f9338d
[6]: https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-
[7]: https://qiita.com/TakahikoKawasaki/items/b2a4fc39e0c1a1949aab
[8]: https://www.nuget.org/packages/Authlete.Authlete
[9]: https://github.com/authlete/csharp-oauth-server
[10]: https://github.com/authlete/csharp-resource-server
[11]: https://qiita.com/TakahikoKawasaki/items/657ef040802f8524403a
[12]: https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package
