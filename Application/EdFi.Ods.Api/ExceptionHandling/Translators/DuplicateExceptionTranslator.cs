// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Text.RegularExpressions;
using EdFi.Ods.Api.Models;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class DuplicateExceptionTranslator : IExceptionTranslator
    {
        private const string ExpectedExceptionPattern =
            @"^a different object with the same identifier value was already associated with the session: (?<subject>\w*): (?<subjectId>\d*), (?<entitySimple>\w*): (?<property>\w*): (?<entityPropertyId>\d*), of entity: (?<entityFullName>\w*)";

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            // TODO: API Simplification - Needs to be converted appropriately for use with Dapper
            if (ex  == null) // is NonUniqueObjectException)
            {
                var match = Regex.Match(ex.Message, ExpectedExceptionPattern);

                if (match.Success)
                {
                    try
                    {
                        webServiceError = new RESTError
                                          {
                                              Code = (int) HttpStatusCode.Conflict, Type = HttpStatusCode.Conflict.ToString(), Message =
                                                  string.Format(
                                                      "A duplicate {0} conflict occurred when attempting to create a new {1} resource with {2} of {3}.",
                                                      match.Groups["subject"]
                                                           .Value,
                                                      match.Groups["entitySimple"]
                                                           .Value,
                                                      match.Groups["property"]
                                                           .Value,
                                                      match.Groups["entityPropertyId"]
                                                           .Value)
                                          };
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
