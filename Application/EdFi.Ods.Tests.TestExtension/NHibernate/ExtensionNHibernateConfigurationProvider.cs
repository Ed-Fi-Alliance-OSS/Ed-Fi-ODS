// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Configuration;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Tests.TestExtension.NHibernate
{
    public class ExtensionNHibernateConfigurationProvider : IExtensionNHibernateConfigurationProvider
    {
        public OrmMappingFileData OrmMappingFileData
        {
            get => new OrmMappingFileData
            {
                Assembly = GetType().Assembly,
                MappingFileFullNames = new[]
                    {
                        Path.Combine(
                            "NHibernate", "Mappings", DatabaseEngine.SqlServer.ScriptsFolderName,
                            OrmMappingFileConventions.EntityOrmMappings + ".hbm.xml")
                    }
            };
        }

        //Returns a dictionary with entity name as the key and the associated extension hbm bag
        //Although LeaveEventExtension only applies to LeaveEvent, there can exist a situation in which an extension is applied
        //to a list of entities resulting in multiple dictionary entries, one for each entity being extended.
        public IDictionary<string, HbmBag> EntityExtensionHbmBagByEntityName
        {
            get
            {
                return new Dictionary<string, HbmBag>
                       {
                           {
                               "StaffLeave", new HbmBag
                                             {
                                                 name = "TestExtension", cascade = "all-delete-orphan", inverse = true,
                                                 lazy = HbmCollectionLazy.False, key = new HbmKey
                                                                                       {
                                                                                           column = new[]
                                                                                                    {
                                                                                                        new HbmColumn
                                                                                                        {
                                                                                                            name = "EventDate"
                                                                                                        },
                                                                                                        new HbmColumn
                                                                                                        {
                                                                                                            name = "StaffLeaveEventCategoryTypeId"
                                                                                                        },
                                                                                                        new HbmColumn
                                                                                                        {
                                                                                                            name = "StaffUSI"
                                                                                                        }
                                                                                                    }
                                                                                       },
                                                 Item = new HbmOneToMany
                                                        {
                                                            @class =
                                                                "EdFi.Ods.Tests.TestExtension.Models.Entities.TestExtension.StaffLeave, EdFi.Ods.Tests.TestExtension"
                                                        }
                                             }
                           }
                       };
            }
        }

        public IDictionary<string, HbmBag[]> AggregateExtensionHbmBagsByEntityName
        {
            get
            {
                return new Dictionary<string, HbmBag[]>
                       {
                           {
                               "StaffLeave", new[]
                                             {
                                                 new HbmBag
                                                 {
                                                     name = "TestExtension", cascade = "all-delete-orphan", inverse = true,
                                                     lazy = HbmCollectionLazy.False, key = new HbmKey
                                                                                           {
                                                                                               column = new[]
                                                                                                        {
                                                                                                            new HbmColumn
                                                                                                            {
                                                                                                                name = "StaffUSI"
                                                                                                            }
                                                                                                        }
                                                                                           },
                                                     Item = new HbmOneToMany
                                                            {
                                                                @class =
                                                                    "EdFi.Ods.Tests.TestExtension.Models.Entities.TestExtension.StaffLeaveReason, EdFi.Ods.Tests.TestExtension"
                                                            }
                                                 }
                                             }
                           }
                       };
            }
        }

        public IDictionary<string, HbmJoinedSubclass[]> NonDiscriminatorBasedHbmJoinedSubclassesByEntityName => new Dictionary<string, HbmJoinedSubclass[]>();

        public IDictionary<string, HbmSubclass[]> DiscriminatorBasedHbmSubclassesByEntityName => new Dictionary<string, HbmSubclass[]>();
    }
}
