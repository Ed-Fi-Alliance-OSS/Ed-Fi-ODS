// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Api.Helpers
{
    public static class TypeHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TypeHelper));

        public static IEnumerable<Type> GetTypesWithModules()
        {
            var allModules = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(
                    a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IModule)) && !t.IsAbstract)
                        .Select(
                            t => new
                            {
                                SourceAssembly = a,
                                Type = t
                            }))
                .ToList();

            _logger.Debug($"Assemblies with modules: {string.Join(", ", allModules.Select(m => m.SourceAssembly.GetName().Name))}");

            // Anything with Override goes to the end of the list, then prioritize Tests modules
            return allModules
                .OrderBy(m => m.Type.Name.StartsWithIgnoreCase("Override"))
                .Select(t => t.Type);
        }
    }
}
