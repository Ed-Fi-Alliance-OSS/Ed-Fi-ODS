// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using log4net;

namespace EdFi.Ods.Api.NetCore.Helpers
{
    public static class TypeHelper
    {
        private static ILog _logger = LogManager.GetLogger(typeof(TypeHelper));

        public static IEnumerable<Type> GetTypesWithModules()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(
                    a => a.GetTypes()
                        .Any(
                            t => t.GetInterfaces()
                                .Contains(typeof(IModule))))
                .ToList();

            _logger.Debug("Assemblies with modules:");
            assemblies.ForEach(a => _logger.Debug($"{a.GetName().Name}"));

            return assemblies
                .SelectMany(
                    a => a.GetTypes()
                        .Where(
                            t => t.GetInterfaces()
                                .Contains(typeof(IModule)) && !t.IsAbstract));
        }
    }
}
