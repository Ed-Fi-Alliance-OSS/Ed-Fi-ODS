// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Utils;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EdFi.Ods.Admin.Contexts
{
    public class IdentityContext : IdentityDbContext
    {
        public const string ConnectionStringName = "EdFi_Admin";

#if NETFRAMEWORK
        protected IdentityContext()
            : base(ConnectionStringName) { }
#endif

#if NETSTANDARD
        protected IdentityContext(string connectionString)
            : base(connectionString) { }
#endif


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyProviderSpecificMappings(modelBuilder);
        }

        /// <remarks>
        /// Sub-classes should override this to provide database system-specific column and/or
        /// table mappings: for example, if a linking table column in Postgres needs to map to a 
        /// name other than the default provided by Entity Framework.
        /// </remarks>
        protected virtual void ApplyProviderSpecificMappings(DbModelBuilder modelBuilder) { }
    }
}

