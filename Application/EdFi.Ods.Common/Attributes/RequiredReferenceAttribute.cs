// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Attributes;

public class RequiredReferenceAttribute : ValidationAttribute
{
    private readonly bool _isIdentifying;
    private readonly string _resourceSchema;
    private readonly string _resourceName;

    public RequiredReferenceAttribute(bool isIdentifying)
    {
        _isIdentifying = isIdentifying;
    }

    public RequiredReferenceAttribute(string resourceSchema, string resourceName)
    {
        _resourceSchema = resourceSchema;
        _resourceName = resourceName;
    }

    private ConcurrentDictionary<string, string> _itemTypeNameByRequestTypeName = new();

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Identifying references are forcibly included in Profiles, so we only need to check for Profile in force for non-identifying references.
        if (!_isIdentifying)
        {
            string profileName = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get()?.ProfileName;

            // Is there a Profile applied to this request?
            if (profileName != null)
            {
                // Determine if this reference has been excluded
                if (GeneratedArtifactStaticDependencies.ProfileResourceModelProvider.GetProfileResourceModel(profileName)
                    .ResourceByName.TryGetValue(new FullName(_resourceSchema, _resourceName), out var profileContentTypes))
                {
                    // Maintain a dictionary of item type names rather than creating new strings that need to be GC'd for every reference check
                    string itemTypeName = _itemTypeNameByRequestTypeName.GetOrAdd(
                        validationContext.ObjectType.Name,
                        requestTypeName => requestTypeName.TrimSuffix("Post").TrimSuffix("Put"));

                    if (!profileContentTypes.Writable.ContainedItemTypeByName.TryGetValue(itemTypeName, out var resourceClass))
                    {
                        return ValidationResult.Success;
                    }

                    if (!resourceClass.ReferenceByName.TryGetValue(validationContext.MemberName, out var ignored))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
        }

        // Perform required check
        if (value != null)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"{validationContext.MemberName} is required.", new[] { validationContext.MemberName });
    }
}
