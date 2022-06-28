// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Common.Database.NamingConventions;

namespace EdFi.Ods.Generator.Common.Database.Engines.SqlServer
{
    public class SqlServerDatabaseNamingConvention : DatabaseNamingConventionBase
    {
        protected override int MaximumNameLength => 128;

        protected override bool LowerCaseNames => false;

        public override string DefaultDateConstraintValue() => "GETUTCDATE()";

        public override string DefaultGuidConstraintValue() => "NEWID()";
        
        public override string TriggerName(Entity entity, TriggerType triggerType)
        {
            return IdentifierName(entity.Name, prefix: $"{entity.Schema}_", suffix: $"_TR_{triggerType}");
        }

        public override string DatabaseEngineCode => "MsSql";
    }
}
