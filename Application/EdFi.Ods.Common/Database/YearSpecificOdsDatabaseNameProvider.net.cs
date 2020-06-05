#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Database
{
    [Obsolete("This class will soon be deprecated. Use YearSpecificDatabaseNameReplacementTokenProvider instead.", false)]
    public class YearSpecificOdsDatabaseNameProvider : IDatabaseNameProvider
    {
        private readonly ISchoolYearContextProvider schoolYearContextProvider;

        public YearSpecificOdsDatabaseNameProvider(ISchoolYearContextProvider schoolYearContextProvider)
        {
            this.schoolYearContextProvider = schoolYearContextProvider;
        }

        public string GetDatabaseName()
        {
            //Convention: "Ods_" + school year.
            int schoolYear = schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 0)
            {
                throw new InvalidOperationException(
                    "The year-specific ODS database name cannot be derived because the school year was not set in the current context.");
            }

            return $"Ods_{schoolYear}";
        }
    }
}
#endif