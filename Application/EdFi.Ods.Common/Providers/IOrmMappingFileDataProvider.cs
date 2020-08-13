// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Dtos;

namespace EdFi.Ods.Common.Providers
{
    public interface IOrmMappingFileDataProvider
    {
        /// <summary>
        /// Returns the mapping file data with full names to the orm mapping files and the assembly
        /// </summary>
        /// <returns></returns>
        OrmMappingFileData OrmMappingFileData();
    }
}
