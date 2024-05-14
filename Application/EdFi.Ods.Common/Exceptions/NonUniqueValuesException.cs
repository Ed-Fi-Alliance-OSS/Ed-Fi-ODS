// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class NonUniqueValuesException : ConflictException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "non-unique-values";
    private const string TitleText = "Non-Unique Values";

    public const string DefaultDetail =
        "A value (or a specific set of values) in the item must be unique, but another item with these values already exists.";
    
    public NonUniqueValuesException(string detail)
        : base(detail) { }

    /// <summary>
    /// Initializes the exception using the supplied detail and errors array (used exclusively for surfacing the NHibernate
    /// NonUniqueObjectException exception as a Problem Details response).
    /// </summary>
    /// <param name="detail"></param>
    /// <param name="errors"></param>
    public NonUniqueValuesException(string detail, string[] errors)
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
