// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class Extension : ResourceMemberBase
    {
        private Lazy<ResourceChildItem> _objectType;

        public Extension(ResourceClassBase resourceClass, Func<ResourceChildItem> extensionObjectType, string displayName)
            : base(resourceClass, displayName, displayName.ToCamelCase())
        {
            _objectType = new Lazy<ResourceChildItem>(extensionObjectType);

            if (resourceClass.Entity != null)
            {
                ParentFullName = resourceClass.Entity.FullName;
            }
        }

        internal Extension(
            ResourceClassBase resourceClass,
            AssociationView association,
            FilterContext childFilterContext,
            Func<IEnumerable<AssociationView>> collectionAssociations,
            Func<IEnumerable<AssociationView>> embeddedObjectAssociations)
            : base(resourceClass, association.Name)
        {
            Association = association;

            _objectType = new Lazy<ResourceChildItem>(() => new ResourceChildItem(
                this,
                resourceClass.ResourceModel,
                association.OtherEntity,
                childFilterContext,
                resourceClass,
                collectionAssociations,
                embeddedObjectAssociations));

            ParentFullName = Association.ThisEntity.FullName;
        }

        public AssociationView Association { get; }

        public ResourceChildItem ObjectType
        {
            get => _objectType.Value;
        }

        public override FullName ParentFullName { get; }
    }
}
