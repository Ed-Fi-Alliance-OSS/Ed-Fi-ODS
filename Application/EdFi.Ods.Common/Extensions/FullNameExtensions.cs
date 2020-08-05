// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Extensions
{
    public static class FullNameExtensions
    {
        private static readonly FullName _edfiSchoolYearTypeFullName 
            = new FullName(EdFiConventions.PhysicalSchemaName, "SchoolYearType");

        /// <summary>
        /// Indicates whether the supplied <see cref="EdFi.Ods.Common.Models.Domain.FullName" /> refers to the standard
        /// Ed-Fi SchoolYearType entity.
        /// </summary>
        /// <param name="entityFullName">The <see cref="EdFi.Ods.Common.Models.Domain.FullName" /> of the <see cref="EdFi.Ods.Common.Models.Domain.Entity" />.</param>
        /// <returns><b>true</b> if the full name represents the Ed-Fi Standard SchoolYearType entity; otherwise <b>false</b>.</returns>
        public static bool IsEdFiSchoolYearType(this FullName entityFullName) 
            => entityFullName == _edfiSchoolYearTypeFullName;
    }
}
