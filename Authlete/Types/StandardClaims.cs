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


namespace Authlete.Types
{
    /// <summary>
    /// Standard claims defined in
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
    /// Standard Claims</a> of
    /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
    /// Connect Core 1.0</a>.
    /// </summary>
    public static class StandardClaims
    {
        /// <summary>
        /// Subject - Identifier for the End-User at the Issuer.
        /// </summary>
        public const string SUB = "sub";


        /// <summary>
        /// End-User's full name in displayable form including all
        /// name parts, possibly including titles and suffixes,
        /// ordered according to the End-User's locale and
        /// preferences.
        /// </summary>
        public const string NAME = "name";


        /// <summary>
        /// Given name(s) or first name(s) of the End-User. Note
        /// that in some cultures, people can have multiple given
        /// names; all can be present, with the names being
        /// separated by space characters.
        /// </summary>
        public const string GIVEN_NAME = "given_name";


        /// <summary>
        /// Surname(s) or last name(s) of the End-User. Note that
        /// in some cultures, people can have multiple family names
        /// or no family name; all can be present, with the names
        /// being separated by space characters.
        /// </summary>
        public const string FAMILY_NAME = "family_name";


        /// <summary>
        /// Middle name(s) of the End-User. Note that in some
        /// cultures, people can have multiple middle names; all
        /// can be present, with the names being separated by
        /// space characters. Also note that in some cultures,
        /// middle names are not used.
        /// </summary>
        public const string MIDDLE_NAME = "middle_name";


        /// <summary>
        /// Casual name of the End-User that may or may not be
        /// the same as the <c>given_name</c>. For instance, a
        /// <c>nickname</c> value of <c>Mike</c> might be returned
        /// alongside a <c>given_name</c> value of <c>Michael</c>.
        /// </summary>
        public const string NICKNAME = "nickname";


        /// <summary>
        /// Shorthand name by which the End-User wishes to be
        /// referred to at the RP, such as <c>janedoe</c> or
        /// <c>j.doe</c>. This value MAY be any valid JSON string
        /// including special characters such as <c>@</c>, <c>/</c>,
        /// or whitespace. The RP MUST NOT rely upon this value
        /// being unique, as discussed in Section 5.7.
        /// </summary>
        public const string PREFERRED_USERNAME = "preferred_username";


        /// <summary>
        /// URL of the End-User's profile page. The contents of
        /// this Web page SHOULD be about the End-User.
        /// </summary>
        public const string PROFILE = "profile";


        /// <summary>
        /// URL of the End-User's profile picture. This URL MUST
        /// refer to an image file (for example, a PNG, JPEG, or
        /// GIF image file), rather than to a Web page containing
        /// an image. Note that this URL SHOULD specifically
        /// reference a profile photo of the End-User suitable for
        /// displaying when describing the End-User, rather than
        /// an arbitrary photo taken by the End-User.
        /// </summary>
        public const string PICTURE = "picture";


        /// <summary>
        /// URL of the End-User's Web page or blog. This Web page
        /// SHOULD contain information published by the End-User
        /// or an organization that the End-User is affiliated with.
        /// </summary>
        public const string WEBSITE = "website";


        /// <summary>
        /// End-User's preferred e-mail address. Its value MUST
        /// conform to the RFC 5322 addr-spec syntax. The RP MUST
        /// NOT rely upon this value being unique, as discussed in
        /// Section 5.7.
        /// </summary>
        public const string EMAIL = "email";


        /// <summary>
        /// True if the End-User's e-mail address has been
        /// verified; otherwise false. When this Claim Value is
        /// <c>true</c>, this means that the OP took affirmative
        /// steps to ensure that this e-mail address was controlled
        /// by the End-User at the time the verification was
        /// performed. The means by which an e-mail address is
        /// verified is context-specific, and dependent upon the
        /// trust framework or contractual agreements within which
        /// the parties are operating.
        /// </summary>
        public const string EMAIL_VERIFIED = "email_verified";


        /// <summary>
        /// End-User's gender. Values defined by this specification
        /// are <c>female</c> and <c>male</c>. Other values MAY be
        /// used when neither of the defined values are applicable.
        /// </summary>
        public const string GENDER = "gender";


        /// <summary>
        /// End-User's birthday, represented as an ISO 8601:2004
        /// <c>YYYY-MM-DD</c> format. The year MAY be <c>0000</c>,
        /// indicating that it is omitted. To represent only the
        /// year, <c>YYYY</c> format is allowed. Note that
        /// depending on the underlying platform's date related
        /// function, providing just year can result in varying
        /// month and day, so the implementers need to take this
        /// factor into account to correctly process the dates.
        /// </summary>
        public const string BIRTHDATE = "birthdate";


        /// <summary>
        /// String from zoneinfo time zone database representing
        /// the End-User's time zone. For example,
        /// <c>Europe/Paris</c> or <c>America/Los_Angeles</c>.
        /// </summary>
        public const string ZONEINFO = "zoneinfo";


        /// <summary>
        /// End-User's locale, represented as a BCP47 [RFC5646]
        /// language tag. This is typically an ISO 639-1 Alpha-2
        /// language code in lowercase and an ISO 3166-1 Alpha-2
        /// country code in uppercase, separated by a dash. For
        /// example, <c>en-US</c> or <c>fr-CA</c>. As a
        /// compatibility note, some implementations have used an
        /// underscore as the separator rather than a dash, for
        /// example, <c>en_US</c>; Relying Parties MAY choose to
        /// accept this locale syntax as well.
        /// </summary>
        public const string LOCALE = "locale";


        /// <summary>
        /// End-User's preferred telephone number. E.164 is
        /// RECOMMENDED as the format of this Claim, for example,
        /// <c>+1 (425) 555-1212</c> or <c>+56 (2) 687 2400</c>.
        /// If the phone number contains an extension, it is
        /// RECOMMENDED that the extension be represented using
        /// the RFC 3966 extension syntax, for example,
        /// <c>+1 (604) 555-1234;ext=5678</c>.
        /// </summary>
        public const string PHONE_NUMBER = "phone_number";


        /// <summary>
        /// True if the End-User's phone number has been verified;
        /// otherwise false. When this Claim Value is <c>true</c>,
        /// this means that the OP took affirmative steps to ensure
        /// that this phone number was controlled by the End-User
        /// at the time the verification was performed. The means
        /// by which a phone number is verified is context-specific,
        /// and dependent upon the trust framework or contractual
        /// agreements within which the parties are operating. When
        /// true, the <c>phone_number</c> Claim MUST be in E.164
        /// format and any extensions MUST be represented in RFC
        /// 3966 format.
        /// </summary>
        public const string PHONE_NUMBER_VERIFIED = "phone_number_verified";


        /// <summary>
        /// End-User's preferred postal address. The value of the
        /// <c>address</c> member is a JSON [RFC4627] structure
        /// containing some or all of the members defined in
        /// Section 5.1.1.
        /// </summary>
        public const string ADDRESS = "address";


        /// <summary>
        /// Time the End-User's information was last updated. Its
        /// value is a JSON number representing the number of
        /// seconds from 1970-01-01T0:0:0Z as measured in UTC
        /// until the date/time.
        /// </summary>
        public const string UPDATED_AT = "updated_at";
    }
}
