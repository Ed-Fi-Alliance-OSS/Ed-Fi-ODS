// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.OpenApi;

namespace EdFi.Ods.Api.Models
{
    public class OpenApiContent
    {
        private readonly Dictionary<OpenApiSpecVersion, Lazy<string>> _metadataBySpecVersion;

        public OpenApiContent(string section, string name, Lazy<string> metadata, Lazy<string> metadataV3, string basePath,
            string relativeSectionPath = null)
        {
            _metadataBySpecVersion = new Dictionary<OpenApiSpecVersion, Lazy<string>>()
            {
                { OpenApiSpecVersion.OpenApi2_0, metadata },
                { OpenApiSpecVersion.OpenApi3_0, metadataV3 }
            };
            
            Section = section;
            Name = name;
            BasePath = basePath;
            RelativeSectionPath = relativeSectionPath ?? name;
        }

        public string Name { get; }

        public string Metadata(OpenApiSpecVersion version)
        {
            return _metadataBySpecVersion[version].Value;
        }

        public string Section { get; }

        public string RelativeSectionPath { get; }

        public string BasePath { get; }
    }
}
