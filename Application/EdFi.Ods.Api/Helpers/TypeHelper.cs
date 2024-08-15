// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using log4net;

namespace EdFi.Ods.Api.Helpers
{
    public static class TypeHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TypeHelper));

        public static IEnumerable<Type> GetModuleTypes()
        {
            var allModules = GetImplementationsOf<IModule>();

            _logger.Debug($"Assemblies with modules: {string.Join(", ", allModules.Select(m => m.assembly.GetName().Name))}");

            // Any modules with names starting with Override and Plugin are sorted to the end of the list
            return allModules
                .OrderBy(m =>
                    // Plugin modules should be invoked last
                    m.type.IsImplementationOf<ICustomModule>() ? 2
                    // ... after modules using "Override" prefix naming convention
                    : m.type.Name.StartsWithIgnoreCase("Override") ? 1
                    // ... after all others
                    : 0)
                .Select(t => t.type);
        }

        public static List<(Assembly assembly, Type type)> GetImplementationsOf<T>()
        {
            var allModules = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(
                    a => a.GetExportedTypes()
                        .Where(t => t.IsImplementationOf<T>())
                        .Select(
                            t => (SourceAssembly: a, Type: t)))
                .ToList();

            return allModules;
        }

        private static Type[] _foundTypes;
        
        public static IEnumerable<Type> GetAssemblyTypes<T>()
        {
            if (_foundTypes != null)
            {
                return _foundTypes;
            }
            
            var allFoundAssemblies = GetImplementationsOf<T>().ToArray();

            _logger.Debug($"Assemblies with type: {string.Join(", ", allFoundAssemblies.Select(m => m.assembly.GetName().Name))}");

            _foundTypes ??= allFoundAssemblies.Select(t => t.type).ToArray();

            return _foundTypes;
        }
    }
}
