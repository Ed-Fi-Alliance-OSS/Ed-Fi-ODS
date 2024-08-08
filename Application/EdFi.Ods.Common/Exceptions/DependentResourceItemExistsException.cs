// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Exceptions;

public class DependentResourceItemExistsException : ConflictException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "dependent-item-exists";
    private const string TitleText = "Dependent Item Exists";
    
    private const string DefaultDetail = "The requested action cannot be performed because this item is referenced by another item.";
    private const string NonRootDetailFormat = "The requested action cannot be performed because this item is referenced by an existing '{0}' item.";
    private const string AbstractRootDetailFormat = "The requested action cannot be performed because this item is referenced by an existing '{0}' item contained within a resource item of one of the following types: {1}.";
    private const string ConcreteRootDetailFormat = "The requested action cannot be performed because this item is referenced by an existing '{0}' item contained within an '{1}' resource item.";

    public DependentResourceItemExistsException()
        : base(DefaultDetail) { }

    public DependentResourceItemExistsException(Entity resourceEntity)
        : base(GetDetail(resourceEntity)) { }

    public static string GetDetail(Entity resourceEntity)
    {
        if (resourceEntity.Parent is null)
        {
            return string.Format(NonRootDetailFormat, resourceEntity.Name);
        }

        if (resourceEntity.Parent.IsAbstract)
        {
            var derivedEntities = resourceEntity.Parent.DerivedEntities.Select(x => x.Name);
            return string.Format(AbstractRootDetailFormat, resourceEntity.Name, string.Join(", ", derivedEntities));

        }
        else
        {
            return string.Format(ConcreteRootDetailFormat, resourceEntity.Name, resourceEntity.Parent.Name);

        }
    }

    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    protected override IEnumerable<string> GetTypeParts()
    {
        foreach (var part in base.GetTypeParts())
        {
            yield return part;
        }

        yield return TypePart;
    }
    // ---------------------------
}
