// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.SqlClient;
using EdFi.Ods.Api.Infrastructure.Pipelines.Put;
using Npgsql;

namespace EdFi.Ods.Api.Extensions
{
    public static class PutResultExtensions
    {
        /// <summary>
        /// Indicates whether the result of the PutPipeline should be handled by the retry policy in the controller.
        /// </summary>
        /// <param name="result">The result of the pipeline execution call.</param>
        /// <returns><b>true</b> if the result should be handled by the retry policy in the controller; otherwise <b>false</b>.</returns>
        public static bool ShouldRetry(this PutResult result)
        {
            // Exit quickly if no exception is present (no retries necessary)
            if (result.Exception == null)
            {
                return false;
            }
            
            // SQL Server deadlock detection
            if ((result.Exception.InnerException as SqlException)?.Message?.Contains("deadlocked") == true)
            {
                return true;
            }

            // PostgreSQL deadlock detection
            if ((result.Exception.InnerException as PostgresException)?.Message?.Contains("deadlock") == true)
            {
                return true;
            }

            return false;
        }
    }
}
