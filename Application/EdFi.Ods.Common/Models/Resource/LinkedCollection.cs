// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class LinkedCollection : ResourceMemberBase
    {
        public LinkedCollection(Resource resource, AssociationView association)
            : base(resource, association.Name)
        {
            Association = association;
        }

        /// <summary>
        /// Gets the <see cref="Resource"/> that represents the items of the linked collection.
        /// </summary>
        public Resource Resource
        {
            get => ResourceClass.ResourceModel.GetResourceByFullName(Association.OtherEntity.FullName);
        }

        /// <summary>
        /// Gets the <see cref="AssociationView"/> that represents the relationship from the current resource to the linked collection.
        /// </summary>
        public AssociationView Association { get; }

        public string Name
        {
            get { return Association.Name; }
        }

        public override FullName ParentFullName
        {
            get { return Resource.Entity.FullName; }
        }
        
        public override string JsonPath
        {
            get => $"{Parent.JsonPath}.{JsonPropertyName}[*]";
        }
    }
}
