// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Cfg;

namespace EdFi.Ods.Api.Common.Infrastructure.Configuration
{
    /// <summary>
    /// Defines a method for manipulating the NHibernate <see cref="Configuration"/> object at runtime before NHibernate configuration is finalized.
    /// </summary>
    public interface INHibernateConfigurationActivity
    {
        /// <summary>
        /// Executes the configuration activity.
        /// </summary>
        /// <param name="configuration">The NHibernate <see cref="Configuration"/> instance to be manipulated.</param>
        void Execute(NHibernate.Cfg.Configuration configuration);
    }
}
