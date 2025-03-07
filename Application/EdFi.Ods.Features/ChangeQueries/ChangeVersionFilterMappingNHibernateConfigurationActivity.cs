﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Configuration;
using log4net;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Features.ChangeQueries
{
    public class ChangeQueryMappingNHibernateConfigurationActivity : INHibernateBeforeBindMappingActivity
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ChangeQueryMappingNHibernateConfigurationActivity));

        public void Execute(object sender, BindMappingEventArgs e)
        {
            if (IsEdFiQueryMappingEvent(e))
            {
                return;
            }

            foreach (var classMapping in e.Mapping.Items.OfType<HbmClass>())
            {
                // Entities mapped with <version> are aggregate roots.
                if (classMapping.Version == null)
                {
                    continue;
                }

                // Maps the ChangeVersion column dynamically
                // Requires there be a property on the base entity already
                // NHibernate wraps property getter exception in PropertyAccessException if any
                // underlying mapped properties are set to access "none", due to an invoke exception being triggered.
                // insert = false to never include it in an INSERT statement
                // update = false to never include it in an UPDATE statement
                // <property name="ChangeVersion" column="ChangeVersion" type="long" not-null="true" generated="never" insert="false" update="false" />
                var changeVersionProperty = new HbmProperty
                {
                    name = ChangeQueriesDatabaseConstants.ChangeVersionColumnName,
                    column = ChangeQueriesDatabaseConstants.ChangeVersionColumnName,
                    type = new HbmType
                           {
                               name = "long"
                           },
                    notnull = true,
                    generated = HbmPropertyGeneration.Never,
                    insert = false,
                    insertSpecified = true,
                    update = false,
                    updateSpecified = true,
                };
                classMapping.Items = classMapping.Items.Concat(changeVersionProperty).ToArray();
            }
        }

        private static bool IsEdFiQueryMappingEvent(BindMappingEventArgs e)
        {
            return (e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.QueryModels.BaseNamespace) ||
                    e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.QueryModels.Views))
                   && e.Mapping.assembly.Equals(Namespaces.Standard.BaseNamespace);
        }
    }
}
