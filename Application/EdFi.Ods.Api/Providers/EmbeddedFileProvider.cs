// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Providers
{
    public class EmbeddedFileProvider : IEmbeddedFileProvider
    {
        private readonly IAssembliesProvider _assembliesProvider;

        public EmbeddedFileProvider(IAssembliesProvider assembliesProvider)
        {
            _assembliesProvider = assembliesProvider;
        }

        public Stream Stream(string assemblyName, string fullyQualifiedName)
        {
            var assembly = _assembliesProvider.Get(assemblyName);

            return assembly == null
                ? default
                : assembly.GetManifestResourceStream(fullyQualifiedName);
        }
    }
}
