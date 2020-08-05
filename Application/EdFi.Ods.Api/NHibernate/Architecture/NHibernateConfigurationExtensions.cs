// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Cfg;
using NHibernate.Event;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public static class NHibernateConfigurationExtensions
    {
        public static void AddCreateDateHooks(this Configuration configuration)
        {
            configuration.Interceptor = new CreateDateBasedTransientInterceptor();
            configuration.SetListener(ListenerType.PreInsert, new EdFiOdsPreInsertListener());
            configuration.SetListener(ListenerType.PostInsert, new EdFiOdsPostInsertListener());
            configuration.SetListener(ListenerType.PostUpdate, new EdFiOdsPostUpdateEventListener());

            //configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
        }
    }
}
