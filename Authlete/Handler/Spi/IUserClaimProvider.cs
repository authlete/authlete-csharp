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


namespace Authlete.Handler.Spi
{
    /// <summary>
    /// Interface to get a claim value by specifying a user's
    /// subject and a claim name.
    /// </summary>
    public interface IUserClaimProvider
    {
        /// <summary>
        /// Get the value of a claim of the user. This method may
        /// be called multiple times.
        /// </summary>
        ///
        /// <returns>
        /// The value of the claim. <c>null</c> if the value is not
        /// available. In most cases, a string should be returned.
        /// When <c>claimName</c> is <c>"address"</c>, an instance
        /// of <c>Address</c> class should be returned.
        /// </returns>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of a user.
        /// </param>
        ///
        /// <param name="claimName">
        /// A claim name such as <c>"name"</c> and
        /// <c>"family_name"</c>. Standard claim names are listed
        /// in
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims">5.1.
        /// Standard Claims</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a>. Constant values that represent
        /// the standard claims are listed in
        /// <c>Authlete.Types.StandardClaims</c> class. Note that
        /// the value of this argument (<c>claimName</c>) does NOT
        /// contain a language tag.
        /// </param>
        ///
        /// <param name="languageTag">
        /// A language tag such as <c>"en"</c> and <c>"ja"</c>.
        /// Implementations of this method should take this into
        /// consideration if possible. See
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html#ClaimsLanguagesAndScripts">5.2.
        /// Claims Languages and Scripts</a> of
        /// <a href="https://openid.net/specs/openid-connect-core-1_0.html">OpenID
        /// Connect Core 1.0</a> for details.
        /// </param>
        object GetUserClaimValue(
            string subject, string claimName, string languageTag);
    }
}
