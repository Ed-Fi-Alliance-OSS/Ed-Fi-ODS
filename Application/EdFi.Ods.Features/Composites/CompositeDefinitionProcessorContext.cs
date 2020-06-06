// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.Composites
{
    public class CompositeDefinitionProcessorContext
    {
        public CompositeDefinitionProcessorContext(
            XElement compositeDefinitionElement,
            IResourceModel resourceModel,
            XElement currentElement,
            ResourceClassBase currentResourceClass,
            AssociationView joinAssociation,
            string entityMemberName,
            string memberDisplayName,
            int childIndex,
            ResourceMemberBase resourceMember)
        {
            ChildIndex = childIndex;
            CurrentResourceMember = resourceMember;
            CompositeDefinitionElement = compositeDefinitionElement;
            ResourceModel = resourceModel;
            CurrentElement = currentElement;
            CurrentResourceClass = currentResourceClass;
            JoinAssociation = joinAssociation;
            EntityMemberName = entityMemberName;
            MemberDisplayName = memberDisplayName;
        }

        public XElement CompositeDefinitionElement { get; }

        public IResourceModel ResourceModel { get; }

        public XElement CurrentElement { get; }

        public ResourceClassBase CurrentResourceClass { get; }

        public ResourceMemberBase CurrentResourceMember { get; set; }

        public AssociationView JoinAssociation { get; }

        public string EntityMemberName { get; }

        public string MemberDisplayName { get; }

        public int ChildIndex { get; }

        public bool IsBaseResource() => CurrentElement.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.BaseResource);

        public bool IsReferenceResource() => CurrentElement.Name.ToString().EqualsIgnoreCase( CompositeDefinitionHelper.ReferencedResource);

        public bool IsEmbeddedObject() => CurrentElement.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.ReferencedResource);

        public bool IsAbstract() => CurrentResourceClass.IsAbstract();

        public bool ShouldFlatten() => AttributeValueAsBool(CompositeDefinitionHelper.Flatten);

        public bool ShouldIncludeResourceSubtype() => AttributeValueAsBool(CompositeDefinitionHelper.IncludeResourceSubtype);

        public bool ShouldUseHierarchy() => AttributeValueAsBool(CompositeDefinitionHelper.UseHierarchy);

        public bool ShouldUseReferenceHierarchy() => AttributeValueAsBool(CompositeDefinitionHelper.UseReferencedHierarchy);

        public string AttributeValue(string attributeName) => CurrentElement.AttributeValue(attributeName);

        public IEnumerable<XElement> PropertyElements() => CurrentElement.Elements(CompositeDefinitionHelper.Property);

        public List<EntityProperty> NonIncomingIdentifyingProperties()
        {
            var joinProperties = JoinAssociation == null
                ? new EntityProperty[0]
                : JoinAssociation.OtherProperties;

            return CurrentResourceClass.Entity.Identifier.Properties
                                       .Except(joinProperties, new EntityPropertyEqualityComparer())
                                       .ToList();
        }

        private bool AttributeValueAsBool(string attributeName)
        {
            bool.TryParse(AttributeValue(attributeName), out bool result);
            return result;
        }
    }
}
