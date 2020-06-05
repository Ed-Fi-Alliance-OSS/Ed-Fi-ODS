#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;

namespace EdFi.Ods.Common.Extensions
{
    public static class WindsorContainerExtensions
    {
        public static ComponentRegistration<TService> IsDecorator<TService>(this ComponentRegistration<TService> registration) where TService : class
            => registration.IsDefault();
    }
}
#endif