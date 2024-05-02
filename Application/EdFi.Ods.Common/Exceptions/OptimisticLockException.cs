// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class OptimisticLockException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "optimistic-lock-failed";
    private const string TitleText = "Optimistic Lock Failed";

    private const int StatusValue = StatusCodes.Status412PreconditionFailed;

    private const string DetailText = "The resource item has been modified by another user.";
    private const string ErrorText = "The resource item's etag value does not match what was specified in the 'If-Match' request header indicating that it has been modified by another client since it was last retrieved.";

    /// <summary>
    /// Initializes a new instance of the <see cref="OptimisticLockException"/> class using the default text and error messages
    /// indicating an optimistic locking evaluation detected changes from another API client.
    /// </summary>
    public OptimisticLockException()
        : base(DetailText, [ErrorText]) { }

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
