﻿//
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
    /// Service Provider Interface for <c>UserInfoRequestHandler</c>.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An implementation of this interface needs to be given to
    /// the constructor of <c>UserInfoRequestHandler</c>.
    /// </para>
    ///
    /// <para>
    /// <c>UserInfoRequestHandlerSpiAdapter</c> is an empty
    /// implementation of this interface.
    /// </para>
    /// </remarks>
    public interface IUserInfoRequestHandlerSpi
        : IUserClaimProvider
    {
        /// <summary>
        /// The value of the <c>"sub"</c> claim that will be
        /// embedded in the response from the userinfo endpoint.
        /// If this property is <c>null</c>, the subject associated
        /// with the access token (which was presented by the
        /// client application at the userinfo endpoint) will be
        /// used as the value of the <c>"sub"</c> claim.
        /// </summary>
        ///
        /// <returns>
        /// The value of the <c>"sub"</c> claim.
        /// </returns>
        string GetSub();
    }
}
