// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class DependentResourceItemExistsException : ConflictException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "dependent-item-exists";
    private const string TitleText = "Dependent Resource Item Exists";
    
    private const string DefaultDetail = "The requested action cannot be performed because this resource item is referenced by another resource item.";
    private const string DefaultDetailFormat = "The requested action cannot be performed because this resource item is referenced by an existing '{0}' resource item.";

    public DependentResourceItemExistsException()
        : base(DefaultDetail) { }

    public DependentResourceItemExistsException(string resourceName)
        : base(string.Format(DefaultDetailFormat, resourceName)) { }

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
