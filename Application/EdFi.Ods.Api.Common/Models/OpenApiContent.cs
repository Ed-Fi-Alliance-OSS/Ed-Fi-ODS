// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Models
{
    public class OpenApiContent
    {
        private readonly Lazy<string> _metadata;

        public OpenApiContent(string section, string name, Lazy<string> metadata, string basePath,
            string relativeSectionPath = null)
        {
            _metadata = metadata;
            Section = section;
            Name = name;
            BasePath = basePath;
            RelativeSectionPath = relativeSectionPath ?? name;
        }

        public string Name { get; }

        public string Metadata
        {
            get => _metadata.Value;
        }

        public string Section { get; }

        public string RelativeSectionPath { get; }

        public string BasePath { get; }
    }
}
