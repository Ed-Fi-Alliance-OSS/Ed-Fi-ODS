// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/// <summary>
/// An exception that indicates a problem with the technical construction of the request (e.g. use of an incorrect content type
/// for the resource), or a query string parameter (e.g. an invalid value for the limit or offset parameters).
/// </summary>
/// <remarks>This exception should be used when the target audience is the developer of the code that is calling the API.</remarks>
public class BadRequestParameterException : BadRequestException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "parameter-validation";
    private const string TitleText = "Parameter Validation Failed";

    public BadRequestParameterException(string detail, string[] errors)
        : base(detail, errors) { }

    public BadRequestParameterException(string detail, string[] errors, Exception innerException)
        : base(detail, errors, innerException) { }

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
