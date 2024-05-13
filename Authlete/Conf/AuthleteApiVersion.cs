/*
 * Copyright (C) 2024 Authlete, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;


namespace Authlete.Conf;


/// <summary>
/// Authlete API version.
/// </summary>
public enum AuthleteApiVersion
{
    V2,
    V3,
}

public static class AuthleteApiVersionExtensions
{
    /// <summary>
    /// Parse the given string as <see cref="AuthleteApiVersion"/>.
    /// 
    /// When the given string is null or does not match any known version,
    /// this method returns null without throwing any exception.
    /// </summary>
    /// <param name="version">A string representing a version, for example, "V2".</param>
    /// <returns>An instance of <see cref="AuthleteApiVersion"/>, or null
    /// if the given string does not match any known version.</returns>
    public static AuthleteApiVersion? Parse(string version)
    {
        if (string.IsNullOrEmpty(version))
        {
            return null;
        }

        if (Enum.TryParse<AuthleteApiVersion>(version, out var parsedVersion))
        {
            return parsedVersion;
        }

        // The given string did not match any known version.
        return null;
    }
}
