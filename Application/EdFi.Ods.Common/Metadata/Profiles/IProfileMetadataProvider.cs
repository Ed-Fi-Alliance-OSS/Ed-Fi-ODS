// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Xml.Linq;
using Autofac.Extras.DynamicProxy;
using FluentValidation.Results;

namespace EdFi.Ods.Common.Metadata.Profiles;

[Intercept("cache-profile-metadata")]
public interface IProfileMetadataProvider
{
    /// <summary>
    /// Collection of valid profile definitions, organized by name.
    /// </summary>
    IReadOnlyDictionary<string, XElement> ProfileDefinitionsByName { get; }

    /// <summary>
    /// Gets the validation results for all profile metadata that has been loaded (or attempted to be loaded).
    /// </summary>
    /// <returns></returns>
    MetadataValidationResult[] GetValidationResults();
}

public class MetadataValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataValidationResult"/> class using the supplied name, source and validation result.
    /// </summary>
    /// <param name="name">The name of the stream (e.g. a file name or short description).</param>
    /// <param name="source">A description of the source of the stream (e.g. an assembly filename, a physical file path, a database name, etc.).</param>
    /// <param name="validationResult">The validation result.</param>
    public MetadataValidationResult(string name, string source, ValidationResult validationResult)
    {
        Name = name;
        Source = source;
        ValidationResult = validationResult;
    }
    
    /// <summary>
    /// Gets the name of the stream (e.g. a file name or short description).
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Gets a description of the source of the stream (e.g. an assembly filename, a physical file path, a database name, etc.).
    /// </summary>
    public string Source { get; }

    public ValidationResult ValidationResult { get; }
}