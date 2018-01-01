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
    /// Service Provider Interface for
    /// <c>AuthorizationRequestDecisionHandler</c>.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// An implementation of this interface needs to be given to
    /// the constructor of <c>AuthorizationRequestDecisionHandler</c>.
    /// </para>
    ///
    /// <para>
    /// <c>AuthorizationRequestDecisionHandlerSpiAdapter</c> is an
    /// empty implementation of this interface.
    /// </para>
    /// </remarks>
    public interface IAuthorizationRequestDecisionHandlerSpi
        : IAuthorizationRequestHandlerSpi
    {
        /// <summary>
        /// Get the end-user's decision on the authorization
        /// request.
        /// </summary>
        ///
        /// <returns>
        /// <c>true</c> if the end-user has decided to grant
        /// authorization to the client application. Otherwise,
        /// if the end-user has denied the authorization request,
        /// <c>false</c> should be returned.
        /// </returns>
        bool IsClientAuthorized();
    }
}
