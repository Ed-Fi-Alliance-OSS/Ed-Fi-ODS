// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common.Models.Resource;
using Resource = EdFi.Ods.Common.Metadata.Schemas.Resource;

namespace EdFi.Ods.CodeGen.Metadata
{
    public class ProfileMetadataValidator : MetadataValidatorBase<Profile>
    {
        public ProfileMetadataValidator(ResourceModel resourceModel, Profile[] profiles, XDocument profileXDocument)
            : base(resourceModel, profiles, profileXDocument) { }

        public override void ValidateMetadata()
        {
            if (ValidationObjectInstances == null || !ValidationObjectInstances.Any())
            {
                return;
            }

            ProfileNamesAreUnique();
            ValidationObjectInstances.ForEach(IsValidProfile);
        }

        public void IsValidProfile(Profile profile)
        {
            foreach (var resource in profile.Resource)
            {
                ValidateObjects(profile, resource);
                ValidateCollections(profile, resource);
                ValidateProperties(profile, resource);
            }
        }

        public void ProfileNamesAreUnique()
        {
            if (ValidationObjectInstances.Select(obj => obj.name)
                    .Distinct()
                    .Count() != ValidationObjectInstances.Count())
            {
                throw new DuplicateProfileException();
            }
        }

        public void ValidateObjects(Profile profile, Resource resource)
        {
            var domainResource = GetDomainResourceFor(resource);

            if (domainResource == null)
            {
                throw new InvalidResourceException(resource, profile);
            }

            foreach (var objectElement in GetValidationElements(profile, resource, "Object"))
            {
                var objectName = GetValidationElementName(objectElement);

                if (!domainResource.EmbeddedObjects.Select(embeddedObj => embeddedObj.ObjectType.Name)
                    .Concat(domainResource.Extensions.Select(e => e.ObjectType.Name))
                    .Contains(objectName))
                {
                    throw new MissingForeignKeyException("Object", objectName, profile, domainResource.Name);
                }
            }
        }

        public void ValidateCollections(Profile profile, Resource resource)
        {
            var domainResource = GetDomainResourceFor(resource);

            if (domainResource == null)
            {
                throw new InvalidResourceException(resource, profile);
            }

            foreach (var collectionElement in GetValidationElements(profile, resource, "Collection"))
            {
                var collectionName = GetValidationElementName(collectionElement);
                var containingTable = GetContainingTable(collectionElement, resource);

                var embeddedObjectCollections = domainResource.EmbeddedObjects.ToDictionary(
                    embeddedObj => embeddedObj.ObjectType.Name,
                    embeddedObj => embeddedObj.ObjectType.Collections.Select(
                        embeddedObjectCollection => embeddedObjectCollection.PropertyName));

                var invalidCollections =
                    containingTable == resource.name && !domainResource.Collections
                        .Select(domainResourceCollection => domainResourceCollection.PropertyName)
                        .Contains(collectionName) ||
                    containingTable != resource.name && embeddedObjectCollections.Any(
                        embeddedObjectCollection => embeddedObjectCollection.Key == containingTable &&
                                                    !embeddedObjectCollection.Value.Contains(collectionName));

                if (invalidCollections)
                {
                    throw new MissingForeignKeyException("Collection", collectionName, profile, domainResource.Name);
                }
            }
        }

        public void ValidateProperties(Profile profile, Resource resource)
        {
            var domainResource = GetDomainResourceFor(resource);

            foreach (var propertyElement in GetValidationElements(profile, resource, "Property"))
            {
                var propertyName = GetValidationElementName(propertyElement);

                if (IsReferenceProperty(propertyName))
                {
                    if (!domainResource.References.Any(
                        reference => reference.PropertyName == propertyName &&
                                     reference.ParentFullName.Name == GetContainingTable(propertyElement, resource)))
                    {
                        throw new IncomingReferenceException(propertyName, profile, domainResource.Name);
                    }

                    return;
                }

                var resourceProperty = domainResource.AllProperties
                    .Concat(domainResource.AllContainedItemTypes.SelectMany(item => item.AllProperties))
                    .Concat(domainResource.Extensions.SelectMany(p => p.ObjectType.AllProperties))
                    .FirstOrDefault(
                        domainResourceProperty => domainResourceProperty.PropertyName ==
                                                  FormatPropertyNameAsResourcePropertyName(propertyName));

                if (resourceProperty == null)
                {
                    throw new MissingPropertyException(propertyName, profile);
                }

                if (resourceProperty.IsDescriptorUsage)
                {
                    var invalidPropertyReference = !resourceProperty.IsIdentifying && resourceProperty.IsDescriptorUsage &&
                                                   resourceProperty.EntityProperty.Entity.IncomingAssociations
                                                       .Concat(resourceProperty.EntityProperty.Entity.OutgoingAssociations)
                                                       .Any(
                                                           association
                                                               => association.ThisProperties.Contains(
                                                                      resourceProperty.EntityProperty) &&
                                                                  !resourceProperty.IsDirectDescriptorUsage);

                    if (invalidPropertyReference)
                    {
                        throw new InvalidPropertyReferenceException(
                            propertyName,
                            profile,
                            domainResource.Name,
                            resourceProperty.ParentFullName.Name);
                    }
                }
            }
        }

        private string CreateMemberXPath(string profileName, string resourceName, string memberType)
            => string.Format(
                "//Profile[@name='{0}']//Resource[@name='{1}']/{2}//{4}|//Profile[@name='{0}']//Resource[@name='{1}']/{3}//{4}",
                profileName,
                resourceName,
                "ReadContentType",
                "WriteContentType",
                memberType);

        private List<XElement> GetXElementsFromXPath(string xPath)
            => DocumentToValidate.XPathSelectElements(xPath)
                .ToList();

        private string GetValidationElementName(XElement validationElement) => validationElement.AttributeValue("name");

        private string GetContainingTable(XElement validationElement, Resource resource)
            => validationElement.Parent.AttributeValue("name") ?? resource.name;

        private IEnumerable<XElement> GetValidationElements(Profile profile, Resource resource, string memberType)
            => GetXElementsFromXPath(CreateMemberXPath(profile.name, resource.name, memberType));

        private bool IsReferenceProperty(string propertyName) => propertyName.EndsWith("Reference");

        private string FormatPropertyNameAsResourcePropertyName(string propertyName)
            => propertyName.EndsWith("TypeId")
                ? propertyName.TrimSuffix("Id")
                : propertyName;

        private Common.Models.Resource.Resource GetDomainResourceFor(Resource resource)
        {
            string schemaProperCaseNameOrDefault =
                ExtensionsConventions.GetProperCaseNameForLogicalName(resource.logicalSchema ?? EdFiConventions.ProperCaseName);

            bool IsSchemaMatch(ResourceClassBase r) => r.SchemaProperCaseName.EqualsIgnoreCase(schemaProperCaseNameOrDefault);
            bool IsNameMatch(ResourceClassBase r) => r.Name.EqualsIgnoreCase(resource.name);
            bool IsFullNameMatch(ResourceClassBase r) => IsSchemaMatch(r) && IsNameMatch(r);

            return ResourceModel.GetAllResources()
                .FirstOrDefault(IsFullNameMatch);
        }
    }

    public class DuplicateProfileException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage = @"There are duplicate profiles detected in Profiles.xml";

        public DuplicateProfileException()
            : base(ExceptionMessage) { }
    }

    public class InvalidResourceException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage = "Parent entity {0}.{1} in profile {2} does not match any valid entities";

        public InvalidResourceException(Resource resource, Profile profile)
            : base(string.Format(ExceptionMessage, resource.logicalSchema, resource.name, profile.name), profile) { }
    }

    public class MissingForeignKeyException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage =
            "'{0}' property '{1}' contained in Profile '{2}' did not have a corresponding foreign key on table '{3}'.";

        public MissingForeignKeyException(string objectType, string objectName, Profile profile, string domainResourceName)
            : base(string.Format(ExceptionMessage, objectType, objectName, profile.name, domainResourceName), profile) { }
    }

    public class IncomingReferenceException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage =
            "The Reference property '{0}' contained in Profile '{1}' did not match an incoming foreign key relationship on table '{2}'.";

        public IncomingReferenceException(string objectName, Profile profile, string domainResourceName)
            : base(string.Format(ExceptionMessage, objectName, profile.name, domainResourceName), profile) { }
    }

    public class MissingPropertyException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage =
            "The listed property '{0}' contained in Profile '{1}' does not match any known properties.";

        public MissingPropertyException(string propertyName, Profile profile)
            : base(string.Format(ExceptionMessage, propertyName, profile.name), profile) { }
    }

    public class InvalidPropertyReferenceException : MetadataValidationException<Profile>
    {
        private const string ExceptionMessage =
            @"The property '{0}' contained in Profile '{1}' cannot be included in the Profile definition because it is part of an incoming FK reference from '{2}' to '{3}'. Reference property instead.";

        public InvalidPropertyReferenceException(
            string propertyName,
            Profile profile,
            string domainResourceName,
            string propertyParentName)
            : base(
                string.Format(ExceptionMessage, propertyName, profile.name, domainResourceName, propertyParentName),
                profile) { }
    }
}
