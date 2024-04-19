// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Exceptions;
using log4net;
using NHibernate;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class StaleObjectStateExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(StaleObjectStateExceptionTranslator));

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            if (ex is StaleObjectStateException)
            {
                // This is probably a timing issue and is not expected under normal operations, so we'll log it.
                _logger.Error(ex);
                
                problemDetails = new NaturalKeyConflictException(
                    "scenario55.");

                return true;
            }

            problemDetails = null;
            return false;
        }
    }
}
