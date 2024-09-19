// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class BadRequestException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "bad-request";
    private const string TitleText = "Bad Request";
    public const string DefaultDetail = "The request construction was invalid.";

    private const int StatusValue = StatusCodes.Status400BadRequest;

    public BadRequestException()
        : base(DefaultDetail, DefaultDetail) { }

    public BadRequestException(string detail)
        : base(detail, detail) { }

    public BadRequestException(string detail, string[] errors)
        : base(detail, detail)
    {
        this.SetErrors(errors);
    }

    public BadRequestException(string detail, string[] errors, Exception innerException)
        : base(detail, detail, innerException)
    {
        this.SetErrors(errors);
    }
    
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
