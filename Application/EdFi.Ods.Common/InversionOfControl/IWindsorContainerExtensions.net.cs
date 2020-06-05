#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// Provides extensions methods to assist with Castle Windsor container configuration.
    /// </summary>
    public static class IWindsorContainerExtensions
    {
        /// <summary>
        /// Adds support to the return an array of all components satisfying an interface.
        /// </summary>
        /// <remarks>
        /// Will return an empty array if there are no configured components
        /// </remarks>
        /// <param name="container">The Castle Windows container.</param>
        public static void AddSupportForEmptyCollections(this IWindsorContainer container)
        {
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
        }
    }
}
#endif
