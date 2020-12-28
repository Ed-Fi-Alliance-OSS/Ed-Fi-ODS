// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Container.Modules
{
    public class ExtensionsModule : ConditionalModule
    {
        public ExtensionsModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ExtensionsModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.Extensions);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            var installedExtensionAssemblies =
                AssemblyLoadContext.Default.Assemblies
                .Where(
                    a => a.IsExtensionAssembly()
                         && !ApiSettings.ExcludedExtensions.Contains(
                             ExtensionsConventions.GetProperCaseNameFromAssemblyName(a.GetName().Name), StringComparer.InvariantCultureIgnoreCase))
                .Distinct(new AssemblyComparer())
                .ToList();

            installedExtensionAssemblies.ForEach(
                assembly =>
                {
                    var assemblyName = assembly.GetName().Name;

                    builder.RegisterType<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                        .WithParameter("sourceAssembly", assembly)
                        .As<IDomainModelDefinitionsProvider>()
                        .SingleInstance();
                });
        }
    }

    internal class AssemblyComparer : IEqualityComparer<Assembly>
    {
        public bool Equals(Assembly x, Assembly y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x is null || ReferenceEquals(y, null))
                return false;

            return x.FullName == y.FullName;
        }

        public int GetHashCode(Assembly assembly)
        {
            if (ReferenceEquals(assembly, null)) return 0;

            var fullNameHashCode = assembly.FullName == null
                ? 0
                : assembly.FullName.GetHashCode();
            return fullNameHashCode ^ 32;
        }
    }
}
