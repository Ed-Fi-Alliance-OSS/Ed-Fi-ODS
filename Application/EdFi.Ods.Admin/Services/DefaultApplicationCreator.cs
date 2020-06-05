// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Admin.DataAccess;

namespace EdFi.Ods.Admin.Services
{
    public class DefaultApplicationCreator : IDefaultApplicationCreator
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IDatabaseTemplateLeaQuery _leaQuery;
        private readonly IUsersContextFactory _usersContextFactory;

        public DefaultApplicationCreator(
            IUsersContextFactory usersContextFactory,
            IDatabaseTemplateLeaQuery leaQuery,
            IConfigValueProvider configValueProvider)
        {
            _usersContextFactory = Preconditions.ThrowIfNull(usersContextFactory, nameof(usersContextFactory));
            _leaQuery = Preconditions.ThrowIfNull(leaQuery, nameof(leaQuery));
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
        }

        /// <summary>
        /// Look for an existing default application for this particular sandbox type.  Also, make sure that all
        /// Local Education Agency associations are updated.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="sandboxType"></param>
        /// <returns></returns>
        public Application FindOrCreateUpdatedDefaultSandboxApplication(int vendorId, SandboxType sandboxType)
        {
            using (var context = _usersContextFactory.CreateContext())
            {
                var vendor = context.Vendors
                                    .Where(x => x.VendorId == vendorId)
                                    .Include(x => x.Applications.Select(a => a.ApplicationEducationOrganizations))
                                    .Single();

                var leaIds = _leaQuery.GetLocalEducationAgencyIds(sandboxType);
                var defaultAppName = _configValueProvider.GetValue("DefaultApplicationName");
                var applicationName = defaultAppName + " " + sandboxType;
                var application = GetApplication(context, vendor, applicationName);

                foreach (var leaId in leaIds)
                {
                    if (application.ApplicationEducationOrganizations.Any(x => x.EducationOrganizationId == leaId))
                    {
                        continue;
                    }

                    application.CreateEducationOrganizationAssociation(leaId);
                }

                context.SaveChanges();
                return application;
            }
        }

        public void AddLeaIdsToApplication(IList<int> localEducationAgencyIds, int applicationId)
        {
            using (var context = _usersContextFactory.CreateContext())
            {
                var application = context.Applications.SingleOrDefault(a => a.ApplicationId == applicationId);

                if (application != null)
                {
                    foreach (var leaId in localEducationAgencyIds)
                    {
                        if (!application.ApplicationEducationOrganizations.Any(x => x.EducationOrganizationId == leaId))
                        {
                            application.CreateEducationOrganizationAssociation(leaId); 
                        }
                    }

                    context.SaveChanges();
                }
            }
        }

        private Application GetApplication(IUsersContext context, Vendor vendor, string applicationName)
        {
            if (vendor.Applications.Any(x => x.ApplicationName == applicationName))
            {
                return vendor.Applications.Single(x => x.ApplicationName == applicationName);
            }

            var defaultClaimSetName = _configValueProvider.GetValue("DefaultClaimSetName");
            var newApplication = vendor.CreateApplication(applicationName, defaultClaimSetName);

            newApplication.OperationalContextUri = _configValueProvider.GetValue("DefaultOperationalContextUri");
            context.Applications.Add(newApplication);
            return newApplication;
        }
    }
}
