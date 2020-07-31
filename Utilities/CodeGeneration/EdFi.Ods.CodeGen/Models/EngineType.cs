// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.CodeGen.Models
{
    public enum EngineType
    {
        // Having a 0 default value causes problems with CommandLineParser's ability to display help text
        PostgreSQL = 1,
        SQLServer = 2
    }
}
