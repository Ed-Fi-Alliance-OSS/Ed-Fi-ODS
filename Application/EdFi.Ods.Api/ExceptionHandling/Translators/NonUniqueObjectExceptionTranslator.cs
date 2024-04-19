// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Exceptions;
using log4net;
using NHibernate;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class NonUniqueObjectExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private const string ExpectedExceptionPattern =
            @"^a different object with the same identifier value was already associated with the session: (?<subject>\w*): (?<subjectId>\d*), (?<entitySimple>\w*): (?<property>\w*): (?<entityPropertyId>\d*), of entity: (?<entityFullName>\w*)";

        private readonly ILog _logger = LogManager.GetLogger(typeof(NonUniqueObjectExceptionTranslator));

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            if (ex is NonUniqueObjectException)
            {
                var match = Regex.Match(ex.Message, ExpectedExceptionPattern);

                if (match.Success)
                {
                    try
                    {
                        _logger.Error(
                            string.Format(
                                "A duplicate {0} conflict occurred when attempting to create a new {1} resource with {2} of {3}.",
                                match.Groups["subject"].Value,
                                match.Groups["entitySimple"].Value,
                                match.Groups["property"].Value,
                                match.Groups["entityPropertyId"].Value));

                        problemDetails = new NonUniqueConflictException("scenario57.", 
                            new[] { $"Two {match.Groups["subject"]} entities with the same identifier were associated with the session. See log for additional details." });

                        return true;
                    }
                    catch
                    {
                        problemDetails = null;
                        return false;
                    }
                }
            }

            problemDetails = null;
            return false;
        }
    }
}
