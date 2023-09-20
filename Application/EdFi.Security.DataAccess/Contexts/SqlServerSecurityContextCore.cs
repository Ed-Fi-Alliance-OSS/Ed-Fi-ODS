// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Contexts
{
    public class SqlServerSecurityContextCore : SecurityContextCore
    {
        // The default behavior is appropriate for this sub-class.
        public SqlServerSecurityContextCore(DbContextOptions options) : base(options) { }
    }
}
