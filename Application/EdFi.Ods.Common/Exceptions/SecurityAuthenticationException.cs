// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class SecurityAuthenticationException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "security:authentication";
    private const string TitleText = "Authentication Failed";
    private const int StatusValue = StatusCodes.Status401Unauthorized;

    public const string DefaultDetail = "Access could not be authorized.";

    /// <summary>
    /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityAuthenticationException"/> class using
    /// the supplied detail, and error (which is made available in the <see cref="IEdFiProblemDetails.Errors" /> collection
    /// as well as used for the exception's <see cref="Exception.Message" /> property to be used for exception logging).
    /// </summary>
    /// <param name="detail"></param>
    /// <param name="error"></param>
    public SecurityAuthenticationException(string detail, string error)
        : base(detail, error)
    {
        if (error != null)
        {
            this.SetErrors(error);
        }
    }

    /// <summary>
    /// Initializes a new instance of the ProblemDetails-based <see cref="SecurityAuthenticationException"/> class using
    /// the supplied detail, and error and inner exception.
    /// </summary>
    /// <param name="detail"></param>
    /// <param name="error"></param>
    /// <param name="innerException"></param>
    public SecurityAuthenticationException(string detail, string error, Exception innerException)
        : base(detail, error, innerException)
    {
        this.SetErrors(error);
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
