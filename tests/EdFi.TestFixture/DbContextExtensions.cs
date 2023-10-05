// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EdFi.TestFixture
{
    public static class DbContextExtensions
    {
        public static void SaveChangesForTest(this DbContext context)
        {
            CatchAndWriteDbValidationExceptions(() => context.SaveChanges());
        }

        public static void CatchAndWriteDbValidationExceptions(Action action)
        {
            try
            {
                action();
            }
            catch (ValidationException exception)
            {
                var errorTexts = exception.ValidationResult.ErrorMessage;
                
                Console.WriteLine(errorTexts);

                throw;
            }
        }
    }
}
