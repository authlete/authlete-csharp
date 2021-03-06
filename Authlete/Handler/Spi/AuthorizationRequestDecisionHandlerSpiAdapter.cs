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


// Disable the following warning to this empty implementation.
//
//   "Missing XML comment for publicly visible type or member"
//
#pragma warning disable 1591


namespace Authlete.Handler.Spi
{
    /// <summary>
    /// An empty implementation of the
    /// <c>IAuthorizationRequestDecisionHandlerSpi</c> interface.
    /// </summary>
    public class AuthorizationRequestDecisionHandlerSpiAdapter
        : AuthorizationRequestHandlerSpiAdapter,
          IAuthorizationRequestDecisionHandlerSpi
    {
        public virtual bool IsClientAuthorized()
        {
            return false;
        }
    }
}
