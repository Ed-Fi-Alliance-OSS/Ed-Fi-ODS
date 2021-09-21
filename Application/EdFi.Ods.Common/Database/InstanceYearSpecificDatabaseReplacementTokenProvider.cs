// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Database
{
    public class InstanceYearSpecificDatabaseReplacementTokenProvider : IDatabaseReplacementTokenProvider
    {
        private readonly IInstanceIdContextProvider instanceIdContextProvider;
        private readonly ISchoolYearContextProvider schoolYearContextProvider;

        public InstanceYearSpecificDatabaseReplacementTokenProvider(ISchoolYearContextProvider schoolYearContextProvider, IInstanceIdContextProvider instanceIdContextProvider)
        {
            this.instanceIdContextProvider = instanceIdContextProvider;
            this.schoolYearContextProvider = schoolYearContextProvider;
        }

        public string GetDatabaseNameReplacementToken()
        {
            //Convention: "Ods_" + instance id + "_"+ school year.

            string instanceId = instanceIdContextProvider.GetInstanceId();

            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException(
                    "The instance-year-specific ODS database name replacement token cannot be derived because the instance id was not set in the current context.");
            }

            int schoolYear = schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 0)
            {
                throw new InvalidOperationException(
                    "The instance-year-specific ODS database name replacement token cannot be derived because the school year was not set in the current context.");
            }

            return string.Format("Ods_{0}_{1}", instanceId, schoolYear);
        }

        public string GetServerNameReplacementToken() => GetDatabaseNameReplacementToken();
    }
}
