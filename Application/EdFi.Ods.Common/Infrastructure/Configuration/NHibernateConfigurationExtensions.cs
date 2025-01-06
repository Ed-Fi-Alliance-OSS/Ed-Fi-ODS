// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Infrastructure.Interceptors;
using EdFi.Ods.Common.Infrastructure.Listeners;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.FeatureManagement;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public static class NHibernateConfigurationExtensions
    {
        public static void SetInterceptorAndEventListeners(
            this NHibernate.Cfg.Configuration configuration,
            Func<IEntityAuthorizer> entityAuthorizerResolver,
            IAuthorizationContextProvider authorizationContextProvider,
            IFeatureManager featureManager)
        {
            configuration.Interceptor = new EdFiOdsInterceptor();
            configuration.SetListener(ListenerType.PreInsert, new EdFiOdsPreInsertListener(featureManager));
            configuration.SetListener(ListenerType.PostInsert, new EdFiOdsPostInsertListener());
            configuration.SetListener(ListenerType.PreUpdate, new EdFiOdsPreUpdateListener(featureManager));

            configuration.SetListener(
                ListenerType.PostUpdate,
                new EdFiOdsPostUpdateEventListener(entityAuthorizerResolver, authorizationContextProvider, featureManager));
        }
    }
}
