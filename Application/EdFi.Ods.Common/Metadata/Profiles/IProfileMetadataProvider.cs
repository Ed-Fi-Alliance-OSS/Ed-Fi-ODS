// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;
using FluentValidation.Results;

namespace EdFi.Ods.Common.Metadata.Profiles;

public interface IProfileMetadataProvider
{
    /// <summary>
    /// Indicates whether the specified Profile definition exists.
    /// </summary>
    bool ContainsProfileDefinition(string profileName);

    /// <summary>
    /// Gets the specified Profile definition by name.
    /// </summary>
    XElement GetProfileDefinition(string profileName);

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