// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;

namespace EdFi.Ods.CodeGen.Conventions
{
    public static class StandardConventions
    {
        /// <summary>
        /// Path to the standard schema directory
        /// </summary>
        public static readonly string Schemas = Path.Combine("Application", "EdFi.Ods.Standard", "Artifacts", "Schemas");

        /// <summary>
        /// Path to the standard metadata directory
        /// </summary>
        public static readonly string Metadata = Path.Combine("Application", "EdFi.Ods.Standard", "Artifacts", "Metadata");
    }
}
