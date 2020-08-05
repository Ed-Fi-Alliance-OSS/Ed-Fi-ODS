// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common.Database
{
    public class YearSpecificDatabaseNameReplacementTokenProvider : IDatabaseNameReplacementTokenProvider
    {
        private readonly ISchoolYearContextProvider schoolYearContextProvider;

        public YearSpecificDatabaseNameReplacementTokenProvider(ISchoolYearContextProvider schoolYearContextProvider)
        {
            this.schoolYearContextProvider = schoolYearContextProvider;
        }

        public string GetReplacementToken()
        {
            //Convention: "Ods_" + school year.
            int schoolYear = schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 0)
            {
                throw new InvalidOperationException(
                    "The year-specific ODS database name replacement token cannot be derived because the school year was not set in the current context.");
            }

            return string.Format("Ods_{0}", schoolYear);
        }
    }
}
