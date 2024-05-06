// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class UnresolvedReferenceException : ConflictException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "unresolved-reference";
    private const string TitleText = "Unresolved Reference";

    private const string DefaultDetail = "A referenced item does not exist.";
    private const string DefaultDetailFormat = "The referenced '{0}' item does not exist.";

    public UnresolvedReferenceException()
        : base(DefaultDetail) { }

    public UnresolvedReferenceException(string resourceName)
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
