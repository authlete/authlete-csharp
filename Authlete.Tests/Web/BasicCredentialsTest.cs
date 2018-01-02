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


using System.Net.Http.Headers;
using Xunit;
using Authlete.Web;


namespace Authlete.Tests.Web
{
    /// <summary>
    /// Tests for <c>Authlete.Web.BasicCredentials</c>.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Since version 1.0.1
    /// </para>
    /// </remarks>
    public class BasicCredentialsTest
    {
        static readonly string USER_ID      = "user";
        static readonly string PASSWORD     = "password";
        static readonly string BASE64       = "dXNlcjpwYXNzd29yZA==";
        static readonly string BASIC_BASE64 = $"Basic {BASE64}";


        [Fact]
        public void Test001()
        {
            string actual =
                new BasicCredentials(USER_ID, PASSWORD)
                    .Formatted;

            Assert.Equal(BASIC_BASE64, actual);
        }


        [Fact]
        public void Test002()
        {
            string actual =
                new BasicCredentials(USER_ID, PASSWORD)
                    .FormattedParameter;

            Assert.Equal(BASE64, actual);
        }


        [Fact]
        public void Test003()
        {
            var credentials = BasicCredentials.Parse(BASIC_BASE64);
            string actual   = credentials.Formatted;

            Assert.Equal(BASIC_BASE64, actual);
        }


        [Fact]
        public void Test004()
        {
            var headerValue = new AuthenticationHeaderValue("Basic", BASE64);
            var credentials = BasicCredentials.Parse(headerValue);
            string actual   = credentials.Formatted;

            Assert.Equal(BASIC_BASE64, actual);
        }


        [Fact]
        public void Test005()
        {
            string input    = $"Dummy {BASE64}";
            var credentials = BasicCredentials.Parse(input);

            Assert.Equal(null, credentials.UserId);
            Assert.Equal(null, credentials.Password);
        }


        [Fact]
        public void Test006()
        {
            var headerValue = new AuthenticationHeaderValue("Dummy", BASE64);
            var credentials = BasicCredentials.Parse(headerValue);

            Assert.Equal(null, credentials.UserId);
            Assert.Equal(null, credentials.Password);
        }
    }
}
