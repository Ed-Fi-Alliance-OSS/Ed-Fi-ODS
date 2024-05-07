// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class CompositeResourceNotReadableException : SecurityAuthorizationException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "composite:not-readable";
    private const string TitleText = "Composite Data Not Readable";

    private const int StatusValue = StatusCodes.Status405MethodNotAllowed; // TODO: ODS-6143 - Remove this line

    private new const string DefaultDetail = "The data cannot be read due to a data policy.";
    private const string ErrorMessageFormat = "The composite's root data '{0}' is not readable because the API client has been assigned a Profile covering that data which only supports writes.";

    public CompositeResourceNotReadableException(string resourceName, Exception inner)
        : base(DefaultDetail, null, inner)
    {
        string error = string.Format(ErrorMessageFormat, resourceName);

        // If the inner exception is a Problem Details-based exception, concatenate the errors.
        if (inner is IEdFiProblemDetails innerProblemDetails)
        {
            this.SetErrors(innerProblemDetails.Errors.Prepend(error).ToArray());
        }
        else
        {
            this.SetErrors(error);
        }
    }

    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    public override int Status { get => StatusValue; }  // TODO: ODS-6143 - Remove this override

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
