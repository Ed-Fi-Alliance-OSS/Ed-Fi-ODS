// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Defines possible values describing how a filter is combined with other filters.
    /// </summary>
    public enum FilterOperator
    {
        Or = 1,
        And = 2,
    }
}
