// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Common;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using log4net;
using Quartz;

namespace EdFi.Ods.Api.Jobs
{
    public class DeleteExpiredTokensJob : TenantSpecificJobBase
    {
        private readonly IExpiredAccessTokenDeleter _expiredAccessTokenDeleter;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeleteExpiredTokensJob));

        public DeleteExpiredTokensJob(
            IExpiredAccessTokenDeleter expiredAccessTokenDeleter,
            IApiJobScheduler apiJobScheduler,
            ITenantConfigurationProvider tenantConfigurationProvider,
            IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
            : base(apiJobScheduler, tenantConfigurationProvider, tenantConfigurationContextProvider)
        {
            _expiredAccessTokenDeleter = Preconditions.ThrowIfNull(expiredAccessTokenDeleter, nameof(expiredAccessTokenDeleter));
        }

        protected override async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.Debug("Removing expired client access tokens...");

                await _expiredAccessTokenDeleter.DeleteExpiredTokensAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
