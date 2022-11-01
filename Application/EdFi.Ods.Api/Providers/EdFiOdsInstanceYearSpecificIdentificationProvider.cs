// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Providers;

namespace EdFi.Ods.Api.Providers
{
    public class EdFiOdsInstanceYearSpecificIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
    {
        //private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;

        public EdFiOdsInstanceYearSpecificIdentificationProvider(ISchoolYearContextProvider schoolYearContextProvider, IInstanceIdContextProvider instanceIdContextProvider)
        {
            //_odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _instanceIdContextProvider = instanceIdContextProvider;
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        public ulong GetInstanceIdentification()
        {
            //var connectionString = _odsDatabaseConnectionStringProvider
            //    .GetConnectionString();
            //var hashCode = connectionString.GetHashCode();

            //return hashCode;

            string instanceId = _instanceIdContextProvider.GetInstanceId();

            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException(
                    "The instance-year-specific ODS database name replacement token cannot be derived because the instance id was not set in the current context.");
            }

            int schoolYear = _schoolYearContextProvider.GetSchoolYear();

            if (schoolYear == 0)
            {
                throw new InvalidOperationException(
                    "The instance-year-specific ODS database name replacement token cannot be derived because the school year was not set in the current context.");
            }

            var instanceYearStr = $"Ods_{instanceId}_{schoolYear}";
            var instanceYearDeterministicHashCode = instanceYearStr.GetXxHash3Code();
            return instanceYearDeterministicHashCode;
        }
    }
}
