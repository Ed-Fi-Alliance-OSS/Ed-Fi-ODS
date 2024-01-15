// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.ProblemDetails;

namespace EdFi.Ods.Api.ExceptionHandling;

/// <summary>
/// Defines a method for translating internal Exceptions to public-facing error messages.
/// </summary>
public interface IProblemDetailsExceptionTranslator
{
    /// <summary>
    /// Translates the specified <see cref="System.Exception"/> to an error message in an <see cref="EdFiProblemDetails" /> instance.
    /// </summary>
    /// <param name="ex">The <see cref="System.Exception"/> to be translated.</param>
    /// <param name="problemDetails">The response model containing the Ed-Fi problem details.</param>
    /// <returns><b>true</b> if the exception was handled; otherwise <b>false</b>.</returns>
    bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails);
}
