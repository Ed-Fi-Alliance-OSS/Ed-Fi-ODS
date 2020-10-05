// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
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
        private static ILog _logger = LogManager.GetLogger(typeof(TypeHelper));

        public static IEnumerable<Type> GetTypesWithModules()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetTypes().Any(t => t.GetInterfaces().Contains(typeof(IModule))))
                .ToList();

            _logger.Debug("Assemblies with modules:");
            assemblies.ForEach(a => _logger.Debug($"{a.GetName().Name}"));

            // force all test modules last
            var overridingModules = assemblies
                .Where(a => a.GetName().Name.Contains("Tests"))
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IModule)) && !t.IsAbstract))
                .ToList();

            var allModules = assemblies
                .Where(x => !x.GetName().Name.Contains("Tests"))
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IModule)) && !t.IsAbstract))
                .Concat(overridingModules)
                .ToList();

            // force modules that begin with "Override" to be installed last.
            var overrideModules = allModules.Where(t => t.Name.StartsWithIgnoreCase("Override")).ToList();

            return allModules.Where(t => !t.Name.StartsWithIgnoreCase("Override"))
                .Concat(overrideModules);
        }
    }
}
#endif