// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class EmbeddedObject : ResourceMemberBase
    {
        private readonly FullName? _parentFullName;

        internal EmbeddedObject(ResourceClassBase resourceClass, AssociationView association, FilterContext childFilterContext)
            : base(resourceClass, association.Name)
        {
            Association = association;
            ObjectType = new ResourceChildItem(this, resourceClass.ResourceModel, association.OtherEntity, childFilterContext, resourceClass);

            _parentFullName = Association.ThisEntity.FullName;
        }

        public EmbeddedObject(ResourceClassBase resourceClass, ResourceChildItem objectType, string displayName)
            : base(resourceClass, displayName, displayName.ToCamelCase())
        {
            ObjectType = objectType;
        }

        public AssociationView Association { get; }

        public ResourceChildItem ObjectType { get; }

        public override FullName ParentFullName
        {
            get
            {
                if (_parentFullName != null)
                {
                    return _parentFullName.Value;
                }

                return ObjectType.Parent.FullName;
            }
        }

        /// <summary>
        /// Indicates whether the embedded object is based on an <see cref="EmbeddedObject"/> inherited from a base entity type.
        /// </summary>
        public bool IsInherited
        {
            get => Association != null &&
                   Parent.Entity?.InheritedNavigableOneToOnes.Contains(Association, ModelComparers.AssociationView) == true;
        }
    }
}
