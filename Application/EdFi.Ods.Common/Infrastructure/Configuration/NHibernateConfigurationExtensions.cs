// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Infrastructure.Interceptors;
using EdFi.Ods.Common.Infrastructure.Listeners;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public static class NHibernateConfigurationExtensions
    {
        public static void AddCreateDateHooks(
            this NHibernate.Cfg.Configuration configuration,
            IEnumerable<IEntityValidator> entityValidators)
        {
            configuration.Interceptor = new CreateDateBasedTransientInterceptor();
            configuration.SetListener(ListenerType.PreInsert, new EdFiOdsPreInsertListener());
            configuration.SetListener(ListenerType.PostInsert, new EdFiOdsPostInsertListener());
            configuration.SetListener(ListenerType.PostUpdate, new EdFiOdsPostUpdateEventListener(entityValidators));
        }
    }
}
