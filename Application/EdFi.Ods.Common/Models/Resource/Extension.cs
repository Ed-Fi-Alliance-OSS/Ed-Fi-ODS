// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class Extension : ResourceMemberBase
    {
        public Extension(ResourceClassBase resourceClass, ResourceChildItem extensionObjectType, string displayName)
            : base(resourceClass, displayName, displayName.ToCamelCase())
        {
            ObjectType = extensionObjectType;

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

            ObjectType = new ResourceChildItem(
                resourceClass.ResourceModel,
                association.OtherEntity,
                childFilterContext,
                resourceClass,
                collectionAssociations,
                embeddedObjectAssociations);

            ParentFullName = Association.ThisEntity.FullName;
        }

        public AssociationView Association { get; }

        public ResourceChildItem ObjectType { get; }

        public override FullName ParentFullName { get; }
    }
}
