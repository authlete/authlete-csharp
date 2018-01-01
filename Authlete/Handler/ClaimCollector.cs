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


using System;
using System.Collections.Generic;
using Authlete.Handler.Spi;


namespace Authlete.Handler
{
    /// <summary>
    /// Collector of claim values.
    /// </summary>
    class ClaimCollector
    {
        // Separator between a claim name and a language tag.
        static readonly char[] CLAIM_SEPARATOR = { '#' };


        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="subject">
        /// The subject (= unique identifier) of a user.
        /// </param>
        ///
        /// <param name="claimNames">
        /// Claim names. <c>null</c> is allowed.
        /// </param>
        ///
        /// <param name="claimLocales">
        /// Claim locales. This should be the value of the
        /// <c>"claims_locales"</c> request parameter. <c>null</c>
        /// is allowed.
        /// </param>
        ///
        /// <param name="claimProvider">
        /// An implementation of the <c>IUserClaimProvider</c>
        /// which provides actual claim values.
        /// </param>
        public ClaimCollector(
            string subject, string[] claimNames,
            string[] claimLocales, IUserClaimProvider claimProvider)
        {
            Subject       = subject;
            ClaimNames    = claimNames;
            ClaimLocales  = NormalizeClaimLocales(claimLocales);
            ClaimProvider = claimProvider;
        }


        string Subject { get; }
        string[] ClaimNames { get; }
        string[] ClaimLocales { get; }
        IUserClaimProvider ClaimProvider { get; }


        /// <summary>
        /// Drop empty and duplicate claim locales from the given
        /// array.
        /// </summary>
        static string[] NormalizeClaimLocales(string[] claimLocales)
        {
            if (claimLocales == null || claimLocales.Length == 0)
            {
                return null;
            }

            // From 5.2. Claims Languages and Scripts in OpenID
            // Connect Core 1.0
            //
            //   However, since BCP47 language tag values are case
            //   insensitive, implementations SHOULD interpret the
            //   language tag values supplied in a case insensitive
            //   manner.
            //
            ISet<string> claimLocaleSet =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Normalized list.
            IList<string> list = new List<string>();

            // Loop to drop empty and duplicate claim locales.
            foreach (string claimLocale in claimLocales)
            {
                // If the claim locale is empty.
                if (string.IsNullOrEmpty(claimLocale))
                {
                    continue;
                }

                // If the claim locale is a duplicate.
                if (claimLocaleSet.Contains(claimLocale))
                {
                    continue;
                }

                claimLocaleSet.Add(claimLocale);
                list.Add(claimLocale);
            }

            int size = list.Count;

            if (size == 0)
            {
                return null;
            }

            if (size == claimLocales.Length)
            {
                // No change.
                return claimLocales;
            }

            // Convert the list to an array.
            var array = new string[size];
            list.CopyTo(array, 0);

            return array;
        }


        /// <summary>
        /// Collect claim values.
        /// </summary>
        public IDictionary<string, object> Collect()
        {
            // If no claim is required.
            if (ClaimNames == null || ClaimNames.Length == 0)
            {
                return null;
            }

            // Claim values.
            IDictionary<string, object> collectedClaims =
                new Dictionary<string, object>();

            // For each required claim.
            foreach (string claimName in ClaimNames)
            {
                // If the claim name is empty.
                if (string.IsNullOrEmpty(claimName))
                {
                    continue;
                }

                // Split the claim name into the name part and
                // the language tag part.
                string[] elements = claimName.Split(CLAIM_SEPARATOR, 2);
                string name = elements[0];
                string tag = (elements.Length == 2) ? elements[1] : null;

                // If the name part is empty.
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                // Get the claim value of the claim.
                object claimValue = GetClaimValue(name, tag);

                // If the claim value was not obtained.
                if (claimValue == null)
                {
                    continue;
                }

                // Just for an edge case where claimName ends
                // with '#'. Note that a value ('name') cannot
                // be assigned to the foreach iteration variable
                // ('claimName') in C#.
                string key = (tag == null) ? name : claimName;

                // Add the pair of the claim name and the claim value.
                collectedClaims.Add(key, claimValue);
            }

            // If no claim value has been obtained.
            if (collectedClaims.Count == 0)
            {
                return null;
            }

            // Collected claim values.
            return collectedClaims;
        }


        object GetClaimValue(
            string claimName, string languageTag)
        {
            // If a languaget tag is explicitly appended.
            if (string.IsNullOrEmpty(languageTag) == false)
            {
                // Get the claim value of the claim with the
                // specific language tag.
                return ClaimProvider.GetUserClaimValue(
                    Subject, claimName, languageTag);
            }

            // If claim locales are not specified by the
            // 'claims_locales' request parameter.
            if (ClaimLocales == null || ClaimLocales.Length == 0)
            {
                // Get the claim value of the claim without any
                // language tag.
                return ClaimProvider.GetUserClaimValue(
                    Subject, claimName, null);
            }

            // For each claim locale. They are ordered by preference.
            foreach (string claimLocale in ClaimLocales)
            {
                // Try to get the claim value with the claim locale.
                object value = ClaimProvider.GetUserClaimValue(
                    Subject, claimName, claimLocale);

                // If the claim value was obtained.
                if (value != null)
                {
                    return value;
                }
            }

            // The last resort. Try to get the claim value without
            // any language tag.
            return ClaimProvider.GetUserClaimValue(
                Subject, claimName, null);
        }
    }
}
