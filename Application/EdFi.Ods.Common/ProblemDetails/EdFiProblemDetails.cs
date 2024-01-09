// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Common.ProblemDetails;

/// <summary>
/// Provides a serializable representation of the problem details model
/// that is independent of the custom exception-based type hierarchy. 
/// </summary>
public class EdFiProblemDetails : IEdFiProblemDetails
{
    /// <inheritdoc cref="IEdFiProblemDetails.Detail" />
    public string Detail { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.Type" />
    public string Type { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.Title" />
    public string Title { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.Status" />
    public int Status { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.CorrelationId" />
    public string CorrelationId { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.ValidationErrors" /> 
    public Dictionary<string, string[]> ValidationErrors { get; set; }

    /// <inheritdoc cref="IEdFiProblemDetails.Errors" />
    public string[] Errors { get; set; }
}
