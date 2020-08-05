// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.Ods.Common.Serialization;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    internal class ExtensionsConverterWithAssemblyOverride : ExtensionsConverter
    {
        public ExtensionsConverterWithAssemblyOverride(string resourceName, string resourceClassName)
            : base(resourceName, resourceClassName) { }

        protected override string GetExtensionClassAssemblyQualifiedName(string extensionName)
        {
            // Use base implementation to establish conventions
            string assemblyQualifiedName = base.GetExtensionClassAssemblyQualifiedName(extensionName);

            // Split the name into parts (namespace and assembly name)
            var parts = assemblyQualifiedName.Split(',');

            // Redirect the assembly qualified name to the tests assembly, and add a prefix to the namespace (to differentiate from the real type)
            string assemblyName = Assembly.GetExecutingAssembly()
                                          .GetName()
                                          .Name;

            return $"{assemblyName}.{parts[0]}, {assemblyName}";
        }

        protected override string[] GetExtensionSchemas()
        {
            return new[]
                   {
                       "Test1", "TestArbitraryCasing"
                   };
        }
    }
}
