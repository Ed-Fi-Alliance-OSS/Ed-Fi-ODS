// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Domain
{
    public enum AssociationViewType
    {
        OneToMany,
        ManyToOne,
        OneToOneOutgoing,
        OneToOneIncoming,
        ToDerived,
        FromBase,
        ToExtension,
        FromCore
    }

    public static class AssociationViewTypeExtensions
    {
        public static bool IsIncoming(this AssociationViewType associationViewType)
        {
            return (associationViewType == AssociationViewType.FromBase
                || associationViewType == AssociationViewType.FromCore
                || associationViewType == AssociationViewType.OneToOneIncoming
                || associationViewType == AssociationViewType.ManyToOne);
        }
        
        public static bool IsOutgoing(this AssociationViewType associationViewType)
        {
            return (associationViewType == AssociationViewType.ToDerived
                || associationViewType == AssociationViewType.ToExtension
                || associationViewType == AssociationViewType.OneToMany
                || associationViewType == AssociationViewType.OneToOneOutgoing);
        }
    }
}
