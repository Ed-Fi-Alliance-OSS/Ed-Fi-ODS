//SPDX - License - Identifier: Apache - 2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using FluentValidation.Results;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    public interface IProfileDefinitionsProvider
    {
        IDictionary<string, XElement> GetProfileDefinitions();
        ConcurrentDictionary<(string name, string source), ValidationResult> ValidationResultsByMetadataStream { get; }
    }
}
