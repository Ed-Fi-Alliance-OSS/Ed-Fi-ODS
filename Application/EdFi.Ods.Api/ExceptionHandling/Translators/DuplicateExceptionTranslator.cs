// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Text.RegularExpressions;
using NHibernate;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class DuplicateExceptionTranslator : IExceptionTranslator
    {
        private const string ExpectedExceptionPattern =
            @"^a different object with the same identifier value was already associated with the session: (?<subject>\w*): (?<subjectId>\d*), (?<entitySimple>\w*): (?<property>\w*): (?<entityPropertyId>\d*), of entity: (?<entityFullName>\w*)";

        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            if (ex is NonUniqueObjectException)
            {
                var match = Regex.Match(ex.Message, ExpectedExceptionPattern);

                if (match.Success)
                {
                    try
                    {
                        var error = new RESTError
                        {
                            Code = (int) HttpStatusCode.Conflict,
                            Type = HttpStatusCode.Conflict.ToString(),
                            Message = $"A duplicate {match.Groups["subject"].Value} conflict occurred when attempting to create a new {match.Groups["entitySimple"].Value} resource with {match.Groups["property"].Value} of {match.Groups["entityPropertyId"].Value}."
                        };
                        
                        translationResult = new ExceptionTranslationResult(error, ex);
                    }
                    catch
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
