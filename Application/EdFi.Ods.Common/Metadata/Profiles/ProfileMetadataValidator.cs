// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Utils.Profiles;
using FluentValidation;
using FluentValidation.Results;
using log4net;

namespace EdFi.Ods.Common.Metadata.Profiles;

public class ProfileMetadataValidator : IProfileMetadataValidator
{
    private readonly IResourceModelProvider _resourceModelProvider;

    private const string ValidationSchemaResourceName = @"EdFi.Ods.Common.Metadata.Schemas.Ed-Fi-ODS-API-Profiles.xsd";

    private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataValidator));
    
    public ProfileMetadataValidator(IResourceModelProvider resourceModelProvider)
    {
        _resourceModelProvider = resourceModelProvider;
    }

    public ValidationResult Validate(XDocument profilesDefinition)
    {
        var validationFailures = new List<ValidationFailure>();

        // Perform XML schema validation
        profilesDefinition.Validate(
            GetValidationSchemaSet(),
            (sender, args) =>
            {
                validationFailures.Add(new ValidationFailure(string.Empty, args.Message));
            });

        // Exit immediately if XML schema validation fails
        if (validationFailures.Any())
        {
            return new ValidationResult(validationFailures);
        }

        // Find duplicate profiles names
        var duplicateProfileNames = profilesDefinition.XPathSelectElements("//Profile")
            .Select(e => e.AttributeValue("name"))
            .GroupBy(n => n, n => n)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .OrderBy(n => n)
            .ToArray();

        if (duplicateProfileNames.Any())
        {
            validationFailures.Add(new ValidationFailure(
                string.Empty,
                $"Duplicate profile name(s) encountered: '{string.Join("', '", duplicateProfileNames)}'"));
            
            return new ValidationResult(validationFailures);
        }
        
        // Resource model validation
        var resourceModel = _resourceModelProvider.GetResourceModel();

        validationFailures.AddRange(ValidateModels());
        
        return new ValidationResult(validationFailures);
        
        IEnumerable<ValidationFailure> ValidateModels()
        {
            try
            {
                var profileValidationReporter = new ProfileValidationReporter();
            
                // Readable models
                var readableProfileResourceModels = profilesDefinition.XPathSelectElements("//Profile[Resource/ReadContentType]")
                    .Select(profileDefinition => new ProfileResourceModel(resourceModel, profileDefinition, profileValidationReporter))
                    .ToArray();

                if (readableProfileResourceModels.Any())
                {
                    using var readable = new ProfilesAppliedResourceModel(ContentTypeUsage.Readable, readableProfileResourceModels);

                    // Force full iteration of the read content type
                    var allReadableMembers = readable.GetAllResources()
                        .SelectMany(r => r.AllContainedItemTypesOrSelf)
                        .SelectMany(
                            rcb => rcb.Properties.Cast<ResourceMemberBase>()
                                .Concat(rcb.Collections)
                                .Concat(rcb.Extensions)
                                .Concat(rcb.References)
                                .Concat(rcb.EmbeddedObjects))
                        .ToArray();
                }

                // Writable models
                var writableProfileResourceModels = profilesDefinition.XPathSelectElements("//Profile[Resource/WriteContentType]")
                    .Select(p => new ProfileResourceModel(resourceModel, p, profileValidationReporter))
                    .ToArray();

                if (writableProfileResourceModels.Any())
                {
                    using var writable = new ProfilesAppliedResourceModel(
                        ContentTypeUsage.Writable,
                        writableProfileResourceModels);

                    // Force full iteration of the write content type
                    var allWritableMembers = writable.GetAllResources()
                        .SelectMany(r => r.AllContainedItemTypesOrSelf)
                        .SelectMany(
                            rcb => rcb.Properties.Cast<ResourceMemberBase>()
                                .Concat(rcb.Collections)
                                .Concat(rcb.Extensions)
                                .Concat(rcb.References)
                                .Concat(rcb.EmbeddedObjects))
                        .ToArray();
                }

                if (profileValidationReporter.ValidationFailures.Any())
                {
                    return profileValidationReporter.ValidationFailures
                        .Select(
                            f => new ValidationFailure(
                                string.Join(", ", f.MemberNames),
                                f.Message)
                            {
                                Severity = Enum.Parse<Severity>(f.Severity.ToString()),
                            });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                
                return new[] { new ValidationFailure(string.Empty, $"{ex.Message}") };
            }

            return Array.Empty<ValidationFailure>();
        }
    }

    private XmlSchemaSet GetValidationSchemaSet()
    {
        var currentAssembly = typeof(ProfileMetadataValidator).Assembly;

        using (var streamReader = new StreamReader(currentAssembly.GetManifestResourceStream(ValidationSchemaResourceName)))
        {
            var schemaSet = new XmlSchemaSet();

            schemaSet.Add("", XmlReader.Create(new StringReader(streamReader.ReadToEnd())));

            return schemaSet;
        }
    }
}