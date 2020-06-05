// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Security.DataAccess.Contexts
{
    public class SqlServerSecurityContext : SecurityContext
    {
        // The default behavior is appropriate for this sub-class.
#if NETSTANDARD
        public SqlServerSecurityContext(string connectionString) : base(connectionString) { }
#endif
    }
}
