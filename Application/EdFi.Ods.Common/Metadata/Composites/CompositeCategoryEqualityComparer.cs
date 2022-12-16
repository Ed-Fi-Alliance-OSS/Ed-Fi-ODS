// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Extensions;

namespace EdFi.Ods.Common.Metadata.Composites;

public class CompositeCategoryEqualityComparer : IEqualityComparer<CompositeCategory>
{
    public bool Equals(CompositeCategory x, CompositeCategory y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (ReferenceEquals(x, null))
        {
            return false;
        }

        if (ReferenceEquals(y, null))
        {
            return false;
        }

        if (x.GetType() != y.GetType())
        {
            return false;
        }

        return x.Name.EqualsIgnoreCase(y.Name) && x.OrganizationCode.EqualsIgnoreCase(y.OrganizationCode);
    }

    public int GetHashCode(CompositeCategory obj)
    {
        return HashCode.Combine(obj.OrganizationCode, obj.Name);
    }
}