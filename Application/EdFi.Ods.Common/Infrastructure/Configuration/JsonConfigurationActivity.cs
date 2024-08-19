// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using log4net;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Common.Infrastructure.Configuration;

public class JsonNHibernateConfigurationActivity : INHibernateBeforeBindMappingActivity
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(JsonNHibernateConfigurationActivity));

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

                // Maps the CreatedByOwnershipTokenID column dynamically
                // Requires there be a property on the base entity already
                // nHibernate wraps property getter exception in PropertyAccessException if any
                // underlying mapped properties are set to access "none", due to an invoke exception being triggered.
                // generated = "always" to avoid nHibernate trying to set values for it
                // <property name="CreatedByOwnershipTokenID" column="ChangeVersion" type="long" not-null="true" generated="always" />
                var jsonProperty = new HbmProperty
                {
                    name = "Json",
                    column = "Json",
                    type = new HbmType { name = "BinaryBlob" },
                    length = "8000",
                    notnull = false,
                    generated = HbmPropertyGeneration.Never
                };

                classMapping.Items = classMapping.Items.Concat(jsonProperty).ToArray();
            }
        }

        private static bool IsEdFiQueryMappingEvent(BindMappingEventArgs e)
        {
            return (e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.QueryModels.BaseNamespace) ||
                    e.Mapping.@namespace.Equals(Namespaces.Entities.NHibernate.QueryModels.Views))
                   && e.Mapping.assembly.Equals(Namespaces.Standard.BaseNamespace);
        }
    }