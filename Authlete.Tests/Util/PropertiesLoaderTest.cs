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
using System.IO;
using Xunit;
using Authlete.Util;


namespace Authlete.Tests.Util
{
    /// <summary>
    /// Tests for <c>Authlete.Util.PropertiesLoader</c>.
    /// </summary>
    public class PropertiesLoaderTest
    {
        // A dictionary which holds just one pair ("key"="value").
        static readonly IDictionary<string, string> ONE_ENTRY =
            new Dictionary<string, string> { { "key", "value" } };


        static IDictionary<string, string> Load(string content)
        {
            using (TextReader reader = new StringReader(content))
            {
                return PropertiesLoader.Load(reader);
            }
        }


        /// <summary>
        /// Test whether comment lines that start with '#' are ignored.
        /// </summary>
        [Fact]
        public void Test001()
        {
            var actual = Load(
                "# Comment\n" +
                " \t\f# Comment\n" +
                "key=value");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether comment lines that start with '!' are ignored.
        /// </summary>
        [Fact]
        public void Test002()
        {
            var actual = Load(
                "! Comment\n" +
                " \t\f! Comment\n" +
                "key=value");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether empty lines are ignored.
        /// </summary>
        [Fact]
        public void Test003()
        {
            var actual = Load(
                "\n" +
                " \t\f\n" +
                "key=value");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether a backslash at the end of a comment line
        /// does not concatenate the next line.
        /// </summary>
        [Fact]
        public void Test004()
        {
            var actual = Load(
                "# Comment \\\n" +
                "key=value");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether white spaces around a key are ignored.
        /// </summary>
        [Fact]
        public void Test005()
        {
            var actual = Load(" \t\fkey \t\f=value");
            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether ':' works as a separator, too.
        /// </summary>
        [Fact]
        public void Test006()
        {
            var actual = Load("key:value");
            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether a separator ('=' and ':') can be omitted.
        /// </summary>
        [Fact]
        public void Test007()
        {
            var actual = Load("key value");
            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether white spaces before a value are ignored.
        /// </summary>
        [Fact]
        public void Test008()
        {
            var actual = Load("key= \t\fvalue");
            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether a backslash at the end of a line concatenate
        /// the next line.
        /// </summary>
        [Fact]
        public void Test009()
        {
            var actual = Load(
                "key\\\n" +
                "=\\\n" +
                "value");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether leading white spaces on continuation lines
        /// are discarded.
        /// </summary>
        [Fact]
        public void Test010()
        {
            var actual = Load(
                "ke\\\n" +
                "  \t\fy=valu\\\n" +
                "  \t\fe");

            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether ':' and '=' can be used in a key if they
        /// are escaped by a backslash as they are explicitly
        /// mentioned in the JavaDoc of java.util.Properties.
        /// </summary>
        [Fact]
        public void Test011()
        {
            var expected = new Dictionary<string, string> {
                { ":=", "value" }
            };

            var actual = Load("\\:\\= = value");

            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Test whether even line terminator characters ('\r' and
        /// '\n') can be used in a key by writing "\r" and "\n".
        /// </summary>
        [Fact]
        public void Test012()
        {
            var expected = new Dictionary<string, string> {
                { "ke\r\ny", "value" }
            };

            var actual = Load("ke\\r\\ny = value");

            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Test whether '\uxxxx' sequences are interpreted.
        /// </summary>
        [Fact]
        public void Test013()
        {
            var key     = "\\u006B\\u0065\\u0079";
            var value   = "\\u0076\\u0061\\u006c\\u0075\\u0065";
            var content = $"{key}={value}";

            var actual = Load(content);
            Assert.Equal(ONE_ENTRY, actual);
        }


        /// <summary>
        /// Test whether multiple key-value pairs are loaded.
        /// </summary>
        [Fact]
        public void Test014()
        {
            var expected = new Dictionary<string, string> {
                { "key1", "value1" },
                { "key2", "value2" },
                { "key3", "value3" },
                { "key4", "value4" },
                { "key5", "value5" },
            };

            var actual = Load(
                "# Properties\n" +
                "\n" +
                "key1=value1\n" +
                " \n" +
                " key2 = value2\n" +
                "\r\n" +
                "key3\\\n" +
                " =value3\n" +
                "\r" +
                "key4:value4\n" +
                "\n" +
                "key\\u0035=value\\u0035\n" +
                "\n");

            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Test whether multiple backslashes at the end of lines
        /// are processed correctly.
        /// </summary>
        [Fact]
        public void Test015()
        {
            var expected = new Dictionary<string, string> {
                { "key1", "value1\\" },     // value1\
                { "key2", "value2\\\\" },   // value2\\
                { "key3", "value3\\\\\\" }, // value3\\\
                { "key4", "value4" },
            };

            var actual = Load(
                "key1 = value1\\\\\n" +
                "key2 = value2\\\\\\\\\n" +
                "key3 = value3\\\\\\\n" +
                "  \\\\\\\n" +
                "  \\\\\n" +
                "key4 = value4");

            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Test whether an invalid '\uxxxx' sequence raises an
        /// ArgumentException.
        /// </summary>
        [Fact]
        public void Test016()
        {
            Action action = () => Load("key=\\uX");
            Assert.Throws<ArgumentException>(action);
        }
    }
}
