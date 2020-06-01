// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityOrmMappingsForQueries : EntityOrmMappings
    {
        public EntityOrmMappingsForQueries(IViewsProvider viewsProvider, IDatabaseTypeTranslator databaseTypeTranslator)
            : base(viewsProvider, databaseTypeTranslator) { }

        protected override void Configure()
        {
            GenerateQueryModel = true;
            base.Configure();
        }
    }
}
