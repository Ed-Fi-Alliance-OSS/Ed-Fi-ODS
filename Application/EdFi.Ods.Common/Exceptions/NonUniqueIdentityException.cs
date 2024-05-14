// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class NonUniqueIdentityException : ConflictException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "non-unique-identity";
    private const string TitleText = "Identifying Values Are Not Unique";

    public const string DefaultDetail = "The identifying value(s) of the item are the same as another item that already exists.";

    public NonUniqueIdentityException(string detail, string[] errors)
        : base(detail)
    {
        this.SetErrors(errors);
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
