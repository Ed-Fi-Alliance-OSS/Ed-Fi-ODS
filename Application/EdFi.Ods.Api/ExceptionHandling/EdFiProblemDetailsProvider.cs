// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
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
        // Try to translate the exception explicitly
        foreach (var translator in _translators)
        {
            if (translator.TryTranslate(exception, out IEdFiProblemDetails problemDetails))
            {
                // Assign the correlation error (if it exists)
                problemDetails.CorrelationId = (string)_logContextAccessor.GetValue(CorrelationConstants.LogContextKey);

                return problemDetails.AsSerializableModel();
            }
        }

        _logger.Error(exception);

        // Default exception message is to just return all the messages in the exception stack as an Internal Server Error
        var response = new InternalServerErrorException
        {
            CorrelationId = (string)_logContextAccessor.GetValue(CorrelationConstants.LogContextKey)
        };

        return response.AsSerializableModel();
    }
}
