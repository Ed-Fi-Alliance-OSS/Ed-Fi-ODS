// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class TooManyTokensException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "security:authentication:too-many-tokens";
    private const string TitleText = "Too Many Tokens";

    private const int StatusValue = StatusCodes.Status429TooManyRequests;

    private const string DetailText = "The caller has authenticated too many times in too short of a time period.";
    private const string ErrorText = "Too many access tokens have been requested (limit is {0}). Access tokens should be reused until they expire.";

    /// <summary>
    /// Initializes a new instance of the <see cref="TooManyTokensException"/> class using the default text and error messages
    /// indicating that the maximum token limit has been reached by the API client.
    /// </summary>
    public TooManyTokensException(int tokenPerClientLimit)
        : base(DetailText, [string.Format(ErrorText, tokenPerClientLimit.ToString())]) { }

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
