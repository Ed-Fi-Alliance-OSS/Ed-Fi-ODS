#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Handlers;

namespace EdFi.Ods.Security.Container.Installers
{
    /// <summary>
    /// Provides a generic type selection strategy for Castle during component resolution
    /// that supports an extensibility point in the <see cref="SecurityComponentsInstaller"/>
    /// for changing the relationship-based authorization context data to a different, but
    /// derived type (to support additional education organization types).
    /// </summary>
    public class RelationshipBasedAuthorizationGenericStrategy : IGenericImplementationMatchingStrategy
    {
        private readonly Type _contextDataType;

        public RelationshipBasedAuthorizationGenericStrategy(Type contextDataType)
        {
            _contextDataType = contextDataType;
        }

        public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
        {
            return new[]
                   {
                       _contextDataType
                   };
        }
    }
}
#endif