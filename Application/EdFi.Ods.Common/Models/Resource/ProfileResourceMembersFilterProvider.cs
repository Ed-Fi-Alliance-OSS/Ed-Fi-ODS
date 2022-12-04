// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Validation;

namespace EdFi.Ods.Common.Models.Resource
{
    public class ProfileResourceMembersFilterProvider : IResourceMembersFilterProvider
    {
        private readonly IProfileValidationReporter _profileValidationReporter;
        
        private static readonly string[] _profileDefinitionMemberElementNames =
        {
            "Property",
            "Collection",
            "Object"
        };

        public ProfileResourceMembersFilterProvider(IProfileValidationReporter profileValidationReporter)
        {
            _profileValidationReporter = profileValidationReporter;
        }
        
        public IMemberFilter GetMemberFilter(ResourceClassBase resourceClass, XElement definition)
        {
            string memberSelectionMode = definition.AttributeValue("memberSelection");

            // TODO: Embedded rule - Profiles always include PK properties
            var identifyingPropertyNames = resourceClass.IdentifyingProperties
                .Select(p => p.PropertyName);

            var identifyingReferenceNames = resourceClass.References
                .Where(r => r.Association.IsIdentifying)
                .Select(r => r.PropertyName);

            var definitionMemberNames = definition.Elements()
                .Where(e => _profileDefinitionMemberElementNames.Contains(e.Name.ToString()))
                .Select(e => e.AttributeValue("name"))
                .Where(n => !string.IsNullOrEmpty(n));

            var definitionExtensionNames = definition.Elements("Extension")
                .Select(e => e.AttributeValue("name"))
                .Where(n => !string.IsNullOrEmpty(n) && resourceClass.ResourceModel.SchemaNameMapProvider != null)
                .Select(x => resourceClass.ResourceModel.SchemaNameMapProvider.GetSchemaMapByLogicalName(x).ProperCaseName);

            IMemberFilter memberFilter;

            switch (memberSelectionMode)
            {
                case "IncludeAll":
                    memberFilter = IncludeAllMemberFilter.Instance;
                    break;

                case "IncludeOnly":
                    var invalidInclusions = definitionMemberNames.Where(
                            n => !resourceClass.CollectionByName.ContainsKey(n)
                                && !resourceClass.PropertyByName.ContainsKey(n)
                                && !resourceClass.ReferenceByName.ContainsKey(n)
                                && !resourceClass.EmbeddedObjectByName.ContainsKey(n))
                        .OrderBy(n => n)
                        .ToArray();

                    if (invalidInclusions.Any())
                    {
                        string profileName = GetProfileName();

                        string message =
                            $"The following member(s) defined in profile '{profileName}' could not be included for resource class '{resourceClass.FullName}' {(resourceClass is Resource ? string.Empty : $"in resource '{resourceClass.ResourceRoot.FullName}' ")}because they don't exist: '{string.Join("', '", invalidInclusions)}'. The following members are available: '{GetAllMemberNamesCsv(resourceClass)}'.";

                        _profileValidationReporter.ReportValidationFailure(
                            ProfileValidationSeverity.Error,
                            profileName,
                            resourceClass.ResourceRoot.FullName,
                            resourceClass.FullName,
                            invalidInclusions,
                            message);
                    }

                    var finalInclusions = definitionMemberNames
                        .Except(invalidInclusions)
                        .Concat(identifyingReferenceNames)
                        .Concat(identifyingPropertyNames)
                        .ToArray();
                    
                    memberFilter = new IncludeOnlyMemberFilter(
                        finalInclusions.ToArray(),
                        definitionExtensionNames.ToArray());

                    break;

                case "ExcludeOnly":

                    var invalidIdentifyingExclusions = definitionMemberNames
                        .Intersect(identifyingPropertyNames.Concat(identifyingReferenceNames))
                        .ToArray();

                    if (invalidIdentifyingExclusions.Any())
                    {
                        string profileName = GetProfileName();
                        
                        string message =
                            $"The following member(s) defined in profile '{profileName}' could not be excluded for resource class '{resourceClass.FullName}' {(resourceClass is Resource ? string.Empty : $"in resource '{resourceClass.ResourceRoot.FullName}' ")}because they are identifying: '{string.Join("', '", invalidIdentifyingExclusions)}'. The following members are identifying and cannot be excluded: '{GetAllMemberNamesCsv(identifyingPropertyNames.Concat(identifyingReferenceNames))}'.";
                        
                        _profileValidationReporter.ReportValidationFailure(
                            ProfileValidationSeverity.Warning,
                            profileName,
                            resourceClass.ResourceRoot.FullName,
                            resourceClass.FullName,
                            invalidIdentifyingExclusions,
                            message);
                    }
                    
                    var missingExclusions = definitionMemberNames
                        .Except(invalidIdentifyingExclusions)
                        .Where(
                            n => !resourceClass.CollectionByName.ContainsKey(n)
                                && !resourceClass.PropertyByName.ContainsKey(n)
                                && !resourceClass.ReferenceByName.ContainsKey(n)
                                && !resourceClass.EmbeddedObjectByName.ContainsKey(n))
                        .ToArray();

                    if (missingExclusions.Any())
                    {
                        string profileName = GetProfileName();

                        string message =
                            $"The following member(s) defined in profile '{profileName}' could not be excluded for resource class '{resourceClass.FullName}' {(resourceClass is Resource ? string.Empty : $"in resource '{resourceClass.ResourceRoot.FullName}' ")}because they don't exist: '{string.Join("', '", missingExclusions)}'. The following members are available: '{GetAllMemberNamesCsv(resourceClass)}'.";
                        
                        _profileValidationReporter.ReportValidationFailure(
                            ProfileValidationSeverity.Warning,
                            profileName,
                            resourceClass.ResourceRoot.FullName,
                            resourceClass.FullName,
                            missingExclusions,
                            message);
                    }

                    string[] finalExclusions = definitionMemberNames
                        .Except(invalidIdentifyingExclusions) // Don't let identifying members be excluded.
                        .Except(missingExclusions) // Don't let identifying members be excluded.
                        .ToArray();

                    memberFilter = new ExcludeOnlyMemberFilter(finalExclusions.ToArray(), definitionExtensionNames.ToArray());

                    break;

                default:

                    throw new NotImplementedException(
                        string.Format("Member selection mode '{0}' is not supported.", memberSelectionMode));
            }

            return memberFilter;

            string GetProfileName()
            {
                return definition.XPathSelectElements("ancestor-or-self::Profile").Last().AttributeValue("name");
            }
        }

        private string GetAllMemberNamesCsv(IEnumerable<string> memberNames)
        {
            return string.Join("', '", memberNames.OrderBy(n => n));
        }

        private string GetAllMemberNamesCsv(ResourceClassBase resourceClass)
        {
            return string.Join("', '", 
                resourceClass.Properties.Cast<ResourceMemberBase>()
                    .Concat(resourceClass.References)
                    .Concat(resourceClass.Collections)
                    .Concat(resourceClass.EmbeddedObjects)
                    .Select(m => m.PropertyName)
                    .OrderBy(n => n));
        }
    }
}
