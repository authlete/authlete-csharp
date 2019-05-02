//
// Copyright (C) 2018-2019 Authlete, Inc.
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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace Authlete.Util
{
    /// <summary>
    /// Loader for <c>properties</c> files. See the
    /// <a href="https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-">description</a>
    /// of <c>java.util.Properties.load(java.io.Reader)</c> about
    /// the format of <c>properties</c> files.
    /// </summary>
    ///
    /// <example>
    /// <code>
    /// using (TextReader reader = File.OpenText("test.properties"))
    /// {
    ///     IDictionary&lt;string, string&gt; properties =
    ///         PropertiesLoader.Load(reader);
    /// }
    /// </code>
    /// </example>
    public static class PropertiesLoader
    {
        static readonly Regex IGNORABLE_LINE_PATTERN;
        static readonly Regex CONTINUING_LINE_PATTERN;


        static PropertiesLoader()
        {
            // Regular expression for ignorable lines
            // (blank lines and comment lines).
            IGNORABLE_LINE_PATTERN = new Regex(
                "^[ \t\f]*([#!].*)?$", RegexOptions.Compiled);

            // Regular expression for line whose line terminator
            // is escaped by a backslash.
            //
            //   From java.util.Properties.load(java.io.Reader)
            //
            //     ... Note that it is not sufficient to only
            //     examine the charater preceding a line terminator
            //     sequence to decide if the line terminator is
            //     escaped; there must be an odd number of
            //     contiguous backslashes for the line terminator
            //     to be escaped. Since the input is processed from
            //     left to right, a non-zero even number of 2n
            //     contiguous backslashes before a line terminator
            //     (or elsewhere) encodes n backslashes after
            //     escape processing.
            //
            CONTINUING_LINE_PATTERN = new Regex(
                @"(^|.*[^\\])(\\\\)*\\$", RegexOptions.Compiled);
        }


        /// <summary>
        /// Extract key-value pairs from a reader whose content
        /// complies with the specification of the <c>properties</c>
        /// file. See the
        /// <a href="https://docs.oracle.com/javase/9/docs/api/java/util/Properties.html#load-java.io.Reader-">description</a>
        /// of <c>java.util.Properties.load(java.io.Reader)</c>
        /// about the format of <c>properties</c> files.
        /// </summary>
        ///
        /// <returns>
        /// Key-value pairs extracted from the reader.
        /// </returns>
        ///
        /// <param name="reader">
        /// A reader whose content complies with the specification
        /// of the <c>properties</c> file.
        /// </param>
        ///
        /// <exception cref="ArgumentException">
        /// A malformed '@\uxxxx' sequence was found.
        /// </exception>
        public static IDictionary<string, string> Load(TextReader reader)
        {
            var properties = new Dictionary<string, string>();

            while (true)
            {
                // Read an effective line.
                string line = ReadEffectiveLine(reader);

                if (line == null)
                {
                    // No more effective line.
                    break;
                }

                // Split the line into a key and a value.
                KeyValuePair<string, string>? pair = ParseLine(line);

                // If the line could not be parsed correctly.
                if (pair == null)
                {
                    continue;
                }

                // Succeeded in extracting a key-value pair.
                properties.Add(pair.Value.Key, pair.Value.Value);
            }

            return properties;
        }


        static string ReadEffectiveLine(TextReader reader)
        {
            // Skip blank lines and comment lines.
            string line = SkipIgnorableLines(reader);

            if (line == null)
            {
                // No more line.
                return null;
            }

            // Remove leading white spaces if any.
            line = RemoveLeadingWhiteSpaces(line);

            // If the line terminator is not escaped by '\'.
            if (CONTINUING_LINE_PATTERN.IsMatch(line) == false)
            {
                // No need to concatenate the next line.
                return line;
            }

            var builder = new StringBuilder();

            // Remove the backslash at the end and append the
            // resultant string.
            builder.Append(RemoveLastChar(line));

            while (true)
            {
                line = reader.ReadLine();

                // If the end of the stream was reached.
                if (line == null)
                {
                    break;
                }

                // Ignore leading white spaces as the spec requires.
                line = RemoveLeadingWhiteSpaces(line);

                // If the line terminator is not escaped by '\'.
                if (CONTINUING_LINE_PATTERN.IsMatch(line) == false)
                {
                    // Append the line as is.
                    builder.Append(line);

                    // And this is the end of the logical line.
                    break;
                }

                // Remove the backslash at the end and append the
                // resultant string.
                builder.Append(RemoveLastChar(line));
            }

            return builder.ToString();
        }


        static string SkipIgnorableLines(TextReader reader)
        {
            while (true)
            {
                // Read one line.
                string line = reader.ReadLine();

                // If the end of the stream was reached.
                if (line == null)
                {
                    // No more line.
                    return null;
                }

                // If the line is ignorable.
                if (IGNORABLE_LINE_PATTERN.IsMatch(line))
                {
                    // Skip the line.
                    continue;
                }

                // Found a non-ignorable line.
                return line;
            }
        }


        static string RemoveLeadingWhiteSpaces(string str)
        {
            return str.TrimStart(' ', '\t', '\f');
        }


        static string RemoveLastChar(string str)
        {
            return str.Substring(0, str.Length - 1);
        }


        static bool IsWhiteSpace(char c)
        {
            return (c == ' ' || c == '\t' || c == '\f');
        }


        static bool IsSeparator(char c)
        {
            return (c == '=' || c == ':');
        }


        static KeyValuePair<string, string>? ParseLine(string line)
        {
            // The index which points to the beginning of the value.
            int index = 0;

            // Extract the key. 'index' will be updated and it will
            // point to the beginning of the value.
            string key = ExtractKey(line, ref index);

            // If the key is an empty string.
            if (key.Length == 0)
            {
                // No valid key was found.
                return null;
            }

            // Extract the value.
            string value = ExtractValue(line, index);

            // Extracted a key-value pair from the line.
            return new KeyValuePair<string, string>(key, value);
        }


        static string ExtractKey(string line, ref int index)
        {
            // From java.util.Properties.load(java.io.Reader)
            //
            //   The key contains all of the characters in the
            //   line starting with the first non-white space
            //   character and up to, but not including, the first
            //   unescaped '=', ':', or white space character
            //   other than a line terminator. All of these key
            //   termination characters may be included in the key
            //   by escaping them with a preceding backslash
            //   character; for example,
            //
            //     \:\=
            //
            //   would be the two-character key ":=". Line
            //   terminator characters can be included using \r
            //   and \n escape sequences. Any white space after
            //   the key is skipped; if the first non-white space
            //   character after the key is '=' or ':', then it is
            //   ignored and any white space characters after it
            //   are also skipped. All remaining characters on the
            //   line become part of the associated element string;
            //   if there are no remaining characters, the element
            //   is the empty string "". Once the raw character
            //   sequences constituting the key and element are
            //   identified, escape processing is performed as
            //   described above.

            var builder = new StringBuilder();

            int len = line.Length;

            for (int i = 0; i < len; ++i)
            {
                char c = line[i];

                // If a separator was found.
                if (IsSeparator(c))
                {
                    // The end of the key was reached.
                    // Make 'index' point to the value.
                    OnSeparatorFound(line, ref index, i);
                    break;
                }

                // If a white space was found.
                if (IsWhiteSpace(c))
                {
                    // The end of the key was reached.
                    // Make 'index' point to the value.
                    OnWhiteSpaceFound(line, ref index, i);
                    break;
                }

                // If a backslash was found.
                if (c == '\\')
                {
                    // Interpret the special sequence and
                    // increment 'i' as necessary.
                    OnBackSlashFound(line, ref i, builder);
                }
                else
                {
                    // Append the character as is.
                    builder.Append(c);
                }

                // If the end of the line was reached.
                if (i + 1 == len)
                {
                    // No value.
                    index = len;
                    break;
                }
            }

            // Build the key.
            return builder.ToString();
        }


        static void OnSeparatorFound(
            string line, ref int index, int i)
        {
            // Skip white spaces which may follow the separator.
            // 'index' will point to the beginning of the value.
            index = SkipWhiteSpaces(line, i + 1);
        }


        static void OnWhiteSpaceFound(
            string line, ref int index, int i)
        {
            // Skip white spaces which may follow the key. 'index'
            // will point to (1) the separator or (2) the beginning
            // of the value.
            index = SkipWhiteSpaces(line, i + 1);

            // If 'index' points to the separator.
            if ((index < line.Length) && IsSeparator(line[index]))
            {
                // Skip white spaces which may follow the separator.
                // 'index' will point to the beginning of the value.
                index = SkipWhiteSpaces(line, index + 1);
            }
        }


        static void OnBackSlashFound(
            string line, ref int i, StringBuilder builder)
        {
            // In this context, it is assured that there exists a
            // character after the backslash (= the backslash is
            // not the last character of the string).
            char c = line[++i];

            switch (c)
            {
                default:  builder.Append(c);    return;
                case 'f': builder.Append('\f'); return;
                case 'n': builder.Append('\n'); return;
                case 'r': builder.Append('\r'); return;
                case 't': builder.Append('\t'); return;
                case 'u': break;
            }

            // '\uxxxx' is expected where 'x' is [0-9A-Fa-f].
            // Convert 'xxxx' into an integer.
            int? n = ReadFourDigitHex(line, i + 1);

            if (n == null)
            {
                throw new ArgumentException("Malformed \\uxxxx encoding.");
            }

            builder.Append((char)n);
            i += 4;
        }


        static int SkipWhiteSpaces(string str, int i)
        {
            int len = str.Length;

            for ( ; i < len; ++i)
            {
                if (IsWhiteSpace(str[i]) == false)
                {
                    break;
                }
            }

            return i;
        }


        static int? ReadFourDigitHex(string str, int start)
        {
            if (str.Length <= start + 3)
            {
                return null;
            }

            int? i0 = TextUtility.HexToInt(str[start    ]);
            int? i1 = TextUtility.HexToInt(str[start + 1]);
            int? i2 = TextUtility.HexToInt(str[start + 2]);
            int? i3 = TextUtility.HexToInt(str[start + 3]);

            if (i0 == null || i1 == null || i2 == null || i3 == null)
            {
                return null;
            }

            return ((i0.Value << 12) |
                    (i1.Value <<  8) |
                    (i2.Value <<  4) |
                    (i3.Value      ) );
        }


        static string ExtractValue(string line, int index)
        {
            int len = line.Length;
            var builder = new StringBuilder();

            for (int i = index; i < len; ++i)
            {
                char c = line[i];

                // If the character is not a backslash.
                if (c != '\\')
                {
                    // Append the character as is.
                    builder.Append(c);
                    continue;
                }

                // Interpret the sequence.
                OnBackSlashFound(line, ref i, builder);
            }

            // Build a value.
            return builder.ToString();
        }
    }
}
