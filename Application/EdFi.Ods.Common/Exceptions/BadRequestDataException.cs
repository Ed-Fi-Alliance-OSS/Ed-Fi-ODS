// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/// <summary>
/// An exception that indicates a problem with one or more values of domain data provided with a request (e.g. a value
/// provided in the JSON body of the request that fails data validation, an invalid domain value provided for a query string
/// parameter used for filtering resources in a GET request).
/// </summary>
/// <remarks>This exception should be used when the target audience is the end user of the client system (i.e. someone who can
/// make necessary corrections to the domain data).</remarks>
public class BadRequestDataException : BadRequestException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "data-validation-failed";
    private const string TitleText = "Data Validation Failed";

    // NOTE: For future consideration
    // private const int StatusValue = StatusCodes.Status422UnprocessableEntity;

    public BadRequestDataException(string detail)
        : base(detail) { }

    public BadRequestDataException(string detail, Dictionary<string, string[]> validationErrors)
        : base(detail)
    {
        ((IEdFiProblemDetails)this).ValidationErrors = validationErrors;
    }

    public BadRequestDataException(string detail, string[] errors)
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
