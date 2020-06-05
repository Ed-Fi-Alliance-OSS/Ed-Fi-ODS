#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.ChainOfResponsibility
{
    /// <summary>
    /// Implements an <see cref="IInterceptor"/> that automatically handles the
    /// scenario where none of the members of the chain handled a request, eliminating
    /// the need for the "Null" member of the chain to be provided by the developer.
    /// </summary>
    public class ChainOfResponsibilityTerminatorProxyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.DeclaringType != null)
            {
                throw new NotSupportedException(
                    string.Format(
                        "No '{0}' implementation handled the request.",
                        invocation.Method.DeclaringType.Name));
            }

            throw new NotSupportedException("No implementation handled the request.");
        }
    }
}
#endif
