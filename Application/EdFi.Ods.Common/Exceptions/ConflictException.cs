// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class ConflictException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "conflict";
    private const string TitleText = "Resource Data Conflict";
    private const int StatusValue = StatusCodes.Status409Conflict;

    private const string DefaultDetail = "The requested change would result in data that conflicts with the existing data.";

    public ConflictException()
        : base(DefaultDetail, DefaultDetail) { }

    public ConflictException(string detail)
        : base(detail, detail) { }

    public ConflictException(string detail, string[] errors)
        : base(detail, detail)
    {
        this.SetErrors(errors);
    }

    public ConflictException(string detail, Exception inner)
        : base(detail, detail, inner) { }

    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    public override int Status { get => StatusValue; }
    
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
