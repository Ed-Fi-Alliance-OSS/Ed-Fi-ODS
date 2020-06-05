#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using Castle.MicroKernel;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// Provides an <see cref="ArrayResolver"/> implementation that allow arrays of specific item types 
    /// to be resolved as empty for dependencies.
    /// </summary>
    public class SelectivelyEmptyArrayResolver : ArrayResolver
    {
        private readonly Type[] allowableEmptyArrayTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectivelyEmptyArrayResolver"/> class using the
        /// specified kernel and array item types.
        /// </summary>
        /// <param name="kernel">The container's kernel.</param>
        /// <param name="allowableEmptyArrayTypes">An array of item types that can be resolved in an array as empty.</param>
        public SelectivelyEmptyArrayResolver(IKernel kernel, params Type[] allowableEmptyArrayTypes)
            : base(kernel, false)
        {
            this.allowableEmptyArrayTypes = allowableEmptyArrayTypes ?? new Type[0];
        }

        protected override bool CanSatisfy(Type itemType)
        {
            if (allowableEmptyArrayTypes.Contains(itemType))
            {
                return true;
            }

            return kernel.HasComponent(itemType);
        }
    }
}
#endif