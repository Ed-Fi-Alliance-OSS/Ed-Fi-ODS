// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class UnsupportedMediaTypeException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "unsupported-media-type";
    private const string TitleText = "Unsupported Media Type";

    private const int StatusValue = StatusCodes.Status415UnsupportedMediaType;

    public const string DefaultDetail = "The request construction was invalid.";
    public const string MissingContetTypeErrorText = $"The 'Content-Type' header is missing.";
    public const string InvalidContetTypeErrorText = $"The value specified in the 'Content-Type' header is not supported by this host.";

    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityAuthorizationException"/> class using
    /// the supplied detail, and error.
    /// </summary>
    public UnsupportedMediaTypeException(string detail, string error)
    : base(detail, error)
    {
        if (error != null)
        {
            this.SetErrors(error);
        }
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
