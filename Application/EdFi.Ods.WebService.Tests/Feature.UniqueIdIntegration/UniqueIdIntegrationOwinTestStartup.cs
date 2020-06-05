// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Web.Http;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Database;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Security.Profiles;
using EdFi.Ods.WebService.Tests.Owin;

namespace EdFi.Ods.WebService.Tests.Feature.UniqueIdIntegration
{
    internal class UniqueIdIntegrationOwinTestStartup : OwinTestBase.OwinStartup
    {
        internal UniqueIdIntegrationOwinTestStartup(
            string databaseName,
            List<int> educationOrganizationIds,
            List<string> vendorNamespacePrefixes = null,
            Func<IOAuthTokenValidator> createOAuthTokenValidator = null,
            Func<ISecurityRepository> securityRepository = null,
            bool useUniqueIdIntegration = false,
            Func<IAdminProfileNamesPublisher> adminProfileNamesPublisher = null,
            bool useSchoolYear = false)
            : base(
                databaseName, educationOrganizationIds, vendorNamespacePrefixes,
                createOAuthTokenValidator, securityRepository, useUniqueIdIntegration, adminProfileNamesPublisher,
                useSchoolYear) { }

        protected override void InstallSecurityComponents(IWindsorContainer container)
        {
            // No security
        }

        protected override void RegisterFilters(HttpConfiguration config)
        {
            // Register only the core filters, not the authorization filters
            RegisterCoreFilters(config);
        }
    }
}
