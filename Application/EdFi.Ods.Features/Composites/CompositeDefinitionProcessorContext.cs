// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.Composites
{
    public class CompositeDefinitionProcessorContext
    {
        protected CompositeDefinitionProcessorContext() { }

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

        public virtual XElement CompositeDefinitionElement { get; }

        public virtual IResourceModel ResourceModel { get; }

        public virtual XElement CurrentElement { get; }

        public virtual ResourceClassBase CurrentResourceClass { get; }

        public virtual ResourceMemberBase CurrentResourceMember { get; set; }

        public virtual AssociationView JoinAssociation { get; }

        public virtual string EntityMemberName { get; }

        public virtual string MemberDisplayName { get; }

        public virtual int ChildIndex { get; }

        public virtual bool IsBaseResource() => CurrentElement.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.BaseResource);

        public virtual bool IsReferenceResource()
            => CurrentElement.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.ReferencedResource);

        public virtual bool IsEmbeddedObject()
            => CurrentElement.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.ReferencedResource);

        public virtual bool IsAbstract() => CurrentResourceClass.IsAbstract();

        public virtual bool ShouldFlatten() => AttributeValueAsBool(CompositeDefinitionHelper.Flatten);

        public virtual bool ShouldIncludeResourceSubtype() => AttributeValueAsBool(CompositeDefinitionHelper.IncludeResourceSubtype);

        public virtual string AttributeValue(string attributeName) => CurrentElement.AttributeValue(attributeName);

        public virtual IEnumerable<XElement> PropertyElements() => CurrentElement.Elements(CompositeDefinitionHelper.Property);

        public virtual List<EntityProperty> NonIncomingIdentifyingProperties()
        {
            var joinProperties = JoinAssociation == null
                ? Array.Empty<EntityProperty>()
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
