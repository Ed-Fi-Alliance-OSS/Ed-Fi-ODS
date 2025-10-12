// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Features.OwnershipBasedAuthorization.SqlServer;
using log4net;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Features.OwnershipBasedAuthorization.NHibernate
{
    public class OwnershipBasedAuthorizationNHibernateConfigurationActivity : INHibernateBeforeBindMappingActivity
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(OwnershipBasedAuthorizationNHibernateConfigurationActivity));

        public void Execute(object sender, BindMappingEventArgs e)
        {
            if (IsViewMappingEvent(e))
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

                // Maps the CreatedByOwnershipTokenID column dynamically
                // Requires there be a property on the base entity already
                // nHibernate wraps property getter exception in PropertyAccessException if any
                // underlying mapped properties are set to access "none", due to an invoke exception being triggered.
                // generated = "always" to avoid nHibernate trying to set values for it
                // <property name="CreatedByOwnershipTokenID" column="ChangeVersion" type="long" not-null="true" generated="always" />
                var createdByOwnershipTokenIdProperty = new HbmProperty
                {
                    name = OwnershipBasedAuthorizationDatabaseConstants.CreatedByOwnershipTokenIdColumnName,
                    column = OwnershipBasedAuthorizationDatabaseConstants.CreatedByOwnershipTokenIdColumnName,
                    type = new HbmType {name = "short"},
                    notnull = false,
                    insert = true,
                    insertSpecified = true,
                    update = false,
                    updateSpecified = true,
                    generated = HbmPropertyGeneration.Never
                };

                classMapping.Items = classMapping.Items.Concat(createdByOwnershipTokenIdProperty).ToArray();
            }
        }

        private static bool IsViewMappingEvent(BindMappingEventArgs e)
        {
            return e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.QueryModels.Views)
                && e.Mapping.assembly.Equals(Namespaces.Standard.BaseNamespace);
        }
    }
}
