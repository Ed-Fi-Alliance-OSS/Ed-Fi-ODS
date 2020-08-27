// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Models.Resource
{
    public class ProfileResourceMembersFilterProvider : IResourceMembersFilterProvider
    {
        private static readonly string[] ProfileDefinitionMemberElementNames =
        {
            "Property", "Collection", "Object"
        };

        public IMemberFilter GetMemberFilter(ResourceClassBase resourceClass, XElement definition)
        {
            string memberSelectionMode = definition.AttributeValue("memberSelection");

            // TODO: Embedded rule - Profiles always include PK properties
            var identifyingPropertyNames = resourceClass.IdentifyingProperties.Select(p => p.PropertyName);

            var identifyingReferences = resourceClass.References.Where(r => r.Association.IsIdentifying)
                                                     .Select(r => r.PropertyName);

            var baseMemberNames =
                definition
                   .Elements()
                   .Where(e => ProfileDefinitionMemberElementNames.Contains(e.Name.ToString()))
                   .Select(e => e.AttributeValue("name"))
                   .Where(n => !string.IsNullOrEmpty(n));

            var extensionNames =
                definition
                   .Elements("Extension")
                   .Select(e => e.AttributeValue("name"))
                   .Where(n => !string.IsNullOrEmpty(n) && resourceClass.ResourceModel.SchemaNameMapProvider != null)
                   .Select(
                        x => resourceClass.ResourceModel.SchemaNameMapProvider.GetSchemaMapByLogicalName(x)
                                          .ProperCaseName)
                   .ToArray();

            var extensionMembers =
                definition
                   .Descendants("Property")
                   .Select(e => e.AttributeValue("name"))
                   .Where(n => !string.IsNullOrEmpty(n))
                   .ToArray();

            IMemberFilter memberFilter;

            switch (memberSelectionMode)
            {
                case "IncludeAll":
                    memberFilter = new IncludeAllMemberFilter();
                    break;

                case "IncludeOnly":

                    var includedMemberNames = identifyingPropertyNames.Concat(identifyingReferences)
                                                                      .Concat(baseMemberNames)
                                                                      .ToArray();

                    // Expand filter to include UniqueId versions on names alongside USI names
                    var includedUsiExpansionNames = includedMemberNames
                                                   .Where(n => n.EndsWith("USI"))
                                                   .Select(n => n.Replace("USI", "UniqueId"));

                    memberFilter = new IncludeOnlyMemberFilter(
                        includedMemberNames.Concat(includedUsiExpansionNames)
                                           .Concat(extensionMembers)
                                           .ToArray(),
                        extensionNames);

                    break;

                case "ExcludeOnly":

                    var excludedMemberNames =
                        baseMemberNames
                           .ToArray();

                    var excludedUsiExpansionNames = excludedMemberNames
                                                   .Where(n => n.EndsWith("USI"))
                                                   .Select(n => n.Replace("USI", "UniqueId"));

                    memberFilter = new ExcludeOnlyMemberFilter(
                        excludedMemberNames
                           .Concat(excludedUsiExpansionNames)
                           .Except(identifyingPropertyNames) // Don't let identifying properties be excluded.
                           .Except(identifyingReferences) // Don't let identifying references be excluded.
                           .Concat(extensionMembers)
                           .ToArray(),
                        extensionNames);

                    break;

                default:

                    throw new NotImplementedException(
                        string.Format("Member selection mode '{0}' is not supported.", memberSelectionMode));
            }

            return memberFilter;
        }
    }
}
