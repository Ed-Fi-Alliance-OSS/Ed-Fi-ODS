// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
using log4net;

namespace EdFi.Ods.Common.Metadata.StreamProviders.Common;

/// <summary>
/// Provides a base class for metadata stream providers that returns streams for all the embedded resources in Assemblies in the AppDomain
/// matching the supplied name suffix. 
/// </summary>
public class AppDomainEmbeddedResourceStreamsProviderBase
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(AppDomainEmbeddedResourceStreamsProviderBase));

    protected IEnumerable<MetadataStream> GetStreams(
        string nameSuffix,
        Func<Assembly, bool> shouldProcessAssembly)
    {
        // Get assemblies that match the supplied predicate
        return AppDomain.CurrentDomain.GetAssemblies()
            .Where(shouldProcessAssembly)
            .SelectMany(a => GetEmbeddedResourceStreams(a, nameSuffix))
            .Select(x => new MetadataStream(x.name, x.source, x.stream));
    }
        
    private IEnumerable<(string name, string source, Stream stream)> GetEmbeddedResourceStreams(Assembly assembly, string nameSuffix)
    {
        // Check if there is a matching resource in the assembly
        string[] manifestResourceNames = assembly.GetManifestResourceNames();

        if (!manifestResourceNames.Any(x => x.EndsWith(nameSuffix)))
        {
            _logger.Warn($"A matching assembly '{assembly.FullName}' contained no embedded resources with a name ending with a '{nameSuffix}' suffix.");

            yield break;
        }

        // Get the full resource name
        var resourceNamesToLoad = manifestResourceNames
            .Where(n => n.EndsWith(nameSuffix));

        foreach (string resourceName in resourceNamesToLoad)
        {
            // Get the stream to the resource
            var stream = assembly.GetManifestResourceStream(resourceName);

            if (stream == null)
            {
                continue;
            }

            yield return (resourceName, assembly.Location, stream);
        }
    }
}
