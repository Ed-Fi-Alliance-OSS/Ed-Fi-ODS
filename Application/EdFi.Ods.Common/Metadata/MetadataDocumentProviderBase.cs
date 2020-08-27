// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using log4net;

namespace EdFi.Ods.Common.Metadata
{
    public abstract class MetadataDocumentProviderBase
    {
        protected readonly ILog _logger;

        protected MetadataDocumentProviderBase()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        protected XDocument GetResourceXDocument(Assembly assembly, string embeddedResourceName)
        {
            // Check if there is a matching resource in the assembly
            if (!assembly.GetManifestResourceNames()
                         .Any(x => x.EndsWith(embeddedResourceName))) // TODO: Embedded convention
            {
                _logger.Warn(
                    string.Format(
                        "An assembly named {0} was found but no '{1}' file was found in it.",
                        assembly.FullName,
                        embeddedResourceName));

                return null;
            }

            // Get the full resource name
            var resourceName = assembly.GetManifestResourceNames()
                                       .First(x => x.EndsWith(embeddedResourceName)); // TODO: Embedded convention

            // Read the XDocument from the resource
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    var metadataXDoc = XDocument.Load(reader);
                    return metadataXDoc;
                }
            }
        }

        protected List<XDocument> GetAllMetadataDocumentsInAppDomain(
            Func<Assembly, bool> shouldProcessAssembly,
            string embeddedResourceName)
        {
            // Get assemblies that match the supplied predicate
            var assemblies = from a in AppDomain.CurrentDomain.GetAssemblies()
                             where shouldProcessAssembly(a)
                             select a;

            return assemblies.Select(a => GetResourceXDocument(a, embeddedResourceName))
                             .ToList();
        }
    }
}
