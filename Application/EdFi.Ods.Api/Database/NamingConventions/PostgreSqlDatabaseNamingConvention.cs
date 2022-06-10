// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.NamingConventions;

namespace EdFi.Ods.Api.Database.NamingConventions
{
    public class PostgreSqlDatabaseNamingConvention : DatabaseNamingConventionBase
    {
        protected override int MaximumNameLength => 63;

        protected override bool LowerCaseNames => true;

        public override string DefaultDateConstraintValue() => "now()";

        public override string DefaultGuidConstraintValue() => "uuid_generate_v4()";

        public override string DatabaseEngineCode => "PgSql";
    }
}