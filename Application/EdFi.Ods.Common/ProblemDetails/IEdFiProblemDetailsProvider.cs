// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Common.ProblemDetails;

public interface IEdFiProblemDetailsProvider
{
    /// <summary>
    /// Gets a serializable Problem Details model for the supplied exception, which is intended to be used as the
    /// response body indicating an error to the client using the Problem Details RFC format.
    /// </summary>
    /// <param name="exception">The exception for which to obtain the problem details.</param>
    /// <returns>A serializable problem details model.</returns>
    IEdFiProblemDetails GetProblemDetails(Exception exception);
}
