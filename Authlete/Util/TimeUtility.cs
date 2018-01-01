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


namespace Authlete.Util
{
    /// <summary>
    /// Time utility.
    /// </summary>
    public static class TimeUtility
    {
        /// <summary>
        /// The Unix epoch (1970-Jan-1).
        /// </summary>
        public static readonly DateTime Epoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        /// <summary>
        /// Get the milliseconds since the Unix epoch (1970-Jan-1).
        /// </summary>
        ///
        /// <returns>
        /// The milliseconds since the Unix epoch (1970-Jan-1).
        /// </returns>
        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Epoch).TotalMilliseconds;
        }


        /// <summary>
        /// Get the seconds since the Unix epoch (1970-Jan-1).
        /// </summary>
        ///
        /// <returns>
        /// The seconds since the Unix epoch (1970-Jan-1).
        /// </returns>
        public static long CurrentTimeSeconds()
        {
            return (long)(DateTime.UtcNow - Epoch).TotalSeconds;
        }
    }
}
