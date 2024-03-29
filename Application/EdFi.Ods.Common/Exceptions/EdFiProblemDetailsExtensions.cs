// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Exceptions;

public static class EdFiProblemDetailsExtensions
{
    /// <summary>
    /// Sets the <see cref="IEdFiProblemDetails.Errors" /> array on the IEdFiProblemDetails if there are at least one
    /// error supplied; otherwise sets it to <b>null</b>.
    /// </summary>
    /// <param name="problemDetails">The problem details to be initialized.</param>
    /// <param name="errors">The error, or error messages to set.</param>
    public static void SetErrors(this IEdFiProblemDetails problemDetails, params string[] errors)
    {
        if (errors.Length > 0)
        {
            problemDetails.Errors = errors;
        }
        else
        {
            problemDetails = null;
        }
    }
}
