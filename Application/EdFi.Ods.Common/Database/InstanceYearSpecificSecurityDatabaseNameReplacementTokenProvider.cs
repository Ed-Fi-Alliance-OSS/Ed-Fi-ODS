// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Database
{
    public class InstanceYearSpecificSecurityDatabaseNameReplacementTokenProvider : ISecurityDatabaseNameReplacementTokenProvider
    {
        private readonly IInstanceIdContextProvider instanceIdContextProvider;

        public InstanceYearSpecificSecurityDatabaseNameReplacementTokenProvider(IInstanceIdContextProvider instanceIdContextProvider)
        {
            this.instanceIdContextProvider = instanceIdContextProvider;
        }

        public string GetReplacementToken()
        {
            //Convention: "Security" + instance id.

            string instanceId = instanceIdContextProvider.GetInstanceId();

            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException(
                    "The instance-year-specific Security database name replacement token cannot be derived because the instance id was not set in the current context.");
            }

            return $"Security_{instanceId}";
        }
    }
}
