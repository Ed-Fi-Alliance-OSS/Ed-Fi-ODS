// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.ProblemDetails;
using log4net;

namespace EdFi.Ods.Api.ExceptionHandling;

public class EdFiProblemDetailsProvider : IEdFiProblemDetailsProvider
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiProblemDetailsProvider));

    private readonly ILogContextAccessor _logContextAccessor;
    private readonly IEnumerable<IProblemDetailsExceptionTranslator> _translators;

    public EdFiProblemDetailsProvider(IEnumerable<IProblemDetailsExceptionTranslator> translators, ILogContextAccessor logContextAccessor)
    {
        _translators = translators;
        _logContextAccessor = logContextAccessor;
    }

    /// <inheritdoc cref="IEdFiProblemDetailsProvider.GetProblemDetails" />
    public IEdFiProblemDetails GetProblemDetails(Exception exception)
    {
        string correlationId = _logContextAccessor.GetCorrelationId();

        // Handle Problem Details exceptions directly
        if (exception is EdFiProblemDetailsExceptionBase problemDetailsException)
        {
            // Set the correlationId and return as serializable
            problemDetailsException.CorrelationId = correlationId;
            return problemDetailsException.AsSerializableModel(); 
        }

        // Try to translate the exception explicitly
        foreach (var translator in _translators)
        {
            if (translator.TryTranslate(exception, out IEdFiProblemDetails problemDetails))
            {
                // Set the correlationId and return as serializable
                problemDetails.CorrelationId = correlationId;
                return problemDetails.AsSerializableModel();
            }
        }

        // This is an unhandled exception
        _logger.Error(exception);

        // Just return all the messages in the exception stack as an Internal Server Error, with correlationId set
        return new InternalServerErrorException("scenario42.") { CorrelationId = correlationId }
            .AsSerializableModel();
    }
}
