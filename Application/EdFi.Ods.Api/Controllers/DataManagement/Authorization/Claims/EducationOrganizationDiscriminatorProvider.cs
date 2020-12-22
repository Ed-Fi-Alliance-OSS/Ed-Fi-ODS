// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using Dapper;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims
{
    public class EducationOrganizationDiscriminatorProvider : IEducationOrganizationDiscriminatorProvider
    {
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        private readonly ConcurrentDictionary<ValueTuple<int, int>, FullName> _discriminatorFullNameByEducationOrganizationId
            = new ConcurrentDictionary<(int, int), FullName>();

        public EducationOrganizationDiscriminatorProvider(
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider)
        {
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        }

        /// <inheritdoc />
        public FullName GetDiscriminator(int educationOrganizationId)
        {
            var edFiOdsInstanceId = _edFiOdsInstanceIdentificationProvider.GetInstanceIdentification();

            var discriminatorFullName = _discriminatorFullNameByEducationOrganizationId.GetOrAdd(
                (edFiOdsInstanceId, educationOrganizationId),
                (tuple) =>
                {
                    var odsInstanceId = tuple.Item1;
                    var edOrgId = tuple.Item2;

                    using var conn = new SqlConnection(_odsDatabaseConnectionStringProvider.GetConnectionString());

                    conn.Open();

                    string discriminatorValue = conn.ExecuteScalar<string>(
                            $"SELECT Discriminator FROM edfi.EducationOrganization WHERE EducationOrganizationId = @EducationOrganizationId",
                            new {EducationOrganizationId = edOrgId})
                        ?? throw new EdFiSecurityException(
                            $"Unable to identify education organization id '{edOrgId}' associated with the API client.");

                    return new FullName(discriminatorValue);
                });

            return discriminatorFullName;
        }
    }
}
