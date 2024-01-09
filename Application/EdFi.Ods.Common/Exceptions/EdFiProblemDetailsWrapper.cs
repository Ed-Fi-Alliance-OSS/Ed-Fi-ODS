// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/// <summary>
/// A struct used to wrap an existing <see cref="IEdFiProblemDetails" /> implementation (either the
/// EdFiProblemDetails response model or an exception class derived from <see cref="EdFiProblemDetailsExceptionBase" />).
/// </summary>
public readonly struct EdFiProblemDetailsWrapper : IEdFiProblemDetails
{
    private readonly IEdFiProblemDetails _wrapped;

    public EdFiProblemDetailsWrapper(IEdFiProblemDetails wrapped)
    {
        _wrapped = wrapped;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Detail" />
    public string Detail
    {
        get => _wrapped.Detail;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Type" />
    public string Type
    {
        get => _wrapped.Type;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Title" />
    public string Title
    {
        get => _wrapped.Title;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Status" />
    public int Status
    {
        get => _wrapped.Status;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.CorrelationId" />
    public string CorrelationId
    {
        get => _wrapped.CorrelationId;
        set => _wrapped.CorrelationId = value;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.ValidationErrors" /> 
    public Dictionary<string, string[]> ValidationErrors
    {
        get => _wrapped.ValidationErrors;
        set => _wrapped.ValidationErrors = value;
    }

    /// <inheritdoc cref="IEdFiProblemDetails.Errors" />
    public string[] Errors
    {
        get => _wrapped.Errors;
        set => _wrapped.Errors = value;
    }
}
