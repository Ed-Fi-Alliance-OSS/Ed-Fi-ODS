// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.NamingConventions;

namespace EdFi.Ods.Api.Database.NamingConventions
{
    public class SqlServerDatabaseNamingConvention : DatabaseNamingConventionBase
    {
        protected override int MaximumNameLength => 128;

        protected override bool LowerCaseNames => false;

        public override string DefaultDateConstraintValue() => "GETUTCDATE()";

        public override string DefaultGuidConstraintValue() => "NEWID()";
        
        public override string DatabaseEngineCode => "MsSql";
    }
}
