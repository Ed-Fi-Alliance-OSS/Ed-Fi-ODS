// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Admin.DataAccess.Contexts
{
    public abstract class UsersContext : DbContext, IUsersContext
    {
        public const string ConnectionStringName = "EdFi_Admin";

#if NETFRAMEWORK
        protected UsersContext()
            : base(ConnectionStringName)
        {
            Database.SetInitializer(new ValidateDatabase<UsersContext>());
        }
#endif

#if NETSTANDARD
        protected UsersContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<UsersContext>(null);
        }
#endif
        public const string UserTableName = "Users";

        public static string UserNameColumn
        {
            get { return UserMemberName(x => x.Email); }
        }

        public static string UserIdColumn
        {
            get { return UserMemberName(x => x.UserId); }
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<ApiClient> Clients { get; set; }

        public IDbSet<ClientAccessToken> ClientAccessTokens { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Application> Applications { get; set; }

        public IDbSet<Profile> Profiles { get; set; }

        public IDbSet<OdsInstance> OdsInstances { get; set; }

        public IDbSet<OdsInstanceComponent> OdsInstanceComponents { get; set; }

        //TODO:  This should really be removed from being directly on the context.  Application should own
        //TODO:  these instances, and deleting an application should delete the associated LEA's
        public IDbSet<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        public IDbSet<VendorNamespacePrefix> VendorNamespacePrefixes { get; set; }

        public IDbSet<OwnershipToken> OwnershipToken { get; set; }

        public IDbSet<WebPagesUsersInRoles> UsersInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ApplyProviderSpecificMappings(modelBuilder);
        }

        /// <remarks>
        /// Sub-classes should override this to provide database system-specific column and/or
        /// table mappings: for example, if a linking table column in Postgres needs to map to a 
        /// name other than the default provided by Entity Framework.
        /// </remarks>
        protected virtual void ApplyProviderSpecificMappings(DbModelBuilder modelBuilder) { }

        /// <inheritdoc />
        public Task<int> ExecuteSqlCommandAsync(string sqlStatement, params object[] parameters)
        {
            return Database.ExecuteSqlCommandAsync(sqlStatement.ToLowerInvariant(), parameters);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<TReturn>> ExecuteQueryAsync<TReturn>(string sqlStatement, params object[] parameters)
        {
            return await Database
                .SqlQuery<TReturn>(sqlStatement.ToLowerInvariant(), parameters)
                .ToListAsync();
        }

        private static string UserMemberName(Expression<Func<User, object>> emailExpression)
        {
            return emailExpression.MemberName();
        }
    }
}
