// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Cfg;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class DatabaseConnectionNHibernateConfigurationActivity : INHibernateConfigurationActivity
    {
        public void Execute(NHibernate.Cfg.Configuration configuration)
        {
            configuration.DataBaseIntegration(
                c =>
                {
                    // these fields need to have a value or nhibernate throws an exception. we default them to empty because
                    // we have a connection string provider
                    c.ConnectionString = string.Empty;
                    c.ConnectionStringName = string.Empty;

                    // this enables the connection to be dynamic based on routes
                    c.ConnectionProvider<NHibernateOdsConnectionProvider>();
                });
        }
    }
}
