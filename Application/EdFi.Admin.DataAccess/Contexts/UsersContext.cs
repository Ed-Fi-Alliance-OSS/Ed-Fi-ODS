// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Extensions;
using EdFi.Admin.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EdFi.Admin.DataAccess.Contexts
{
    public abstract class UsersContext : DbContext, IUsersContext
    {
        protected UsersContext(DbContextOptions options)
            : base(options) { }

        public const string UserTableName = "Users";

        public static string UserNameColumn
        {
            get { return UserMemberName(x => x.Email); }
        }

        public static string UserIdColumn
        {
            get { return UserMemberName(x => x.UserId); }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiClient>()
                .HasMany(t => t.ApplicationEducationOrganizations)
                .WithMany(t => t.Clients)
                .UsingEntity<ApiClientApplicationEducationOrganization>("ApiClientApplicationEducationOrganizations",
                     l =>
                        l.HasOne<ApplicationEducationOrganization>().WithMany().HasForeignKey(
                            "ApplicationEducationOrganizationId"),
                    r =>
                        r.HasOne<ApiClient>().WithMany().HasForeignKey("ApiClientId"));

            modelBuilder.Entity<Application>()
                .HasMany(a => a.Profiles)
                .WithMany(a => a.Applications)
                .UsingEntity("ProfileApplications");
            
            modelBuilder.UseUnderscoredFkColumnNames();
            
            modelBuilder.Model.FindEntityTypes(typeof(ApiClient)).First().
                GetProperty("CreatorOwnershipTokenId").SetColumnName("CreatorOwnershipTokenId_OwnershipTokenId");

        }

        public DbSet<User> Users { get; set; }

        public DbSet<ApiClient> ApiClients { get; set; }

        public DbSet<ClientAccessToken> ClientAccessTokens { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Profile> Profiles { get; set; }
        
        public DbSet<ApiClientOwnershipToken> ApiClientOwnershipTokens { get; set; }

        public DbSet<OdsInstance> OdsInstances { get; set; }

        public DbSet<OdsInstanceContext> OdsInstanceContexts { get; set; }

        public DbSet<OdsInstanceDerivative> OdsInstanceDerivatives { get; set; }

        //TODO:  This should really be removed from being directly on the context.  Application should own
        //TODO:  these instances, and deleting an application should delete the associated LEA's
        public DbSet<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        public DbSet<VendorNamespacePrefix> VendorNamespacePrefixes { get; set; }

        public DbSet<OwnershipToken> OwnershipTokens { get; set; }

        public DbSet<ApiClientOdsInstance> ApiClientOdsInstances { get; set; }

        public DbSet<WebPagesUsersInRoles> UsersInRoles { get; set; }

        /// <inheritdoc />
        public Task<int> ExecuteSqlCommandAsync(string sqlStatement, params object[] parameters)
        {
            return Database.ExecuteSqlInterpolatedAsync(
                FormattableStringFactory.Create(sqlStatement.ToLowerInvariant(), parameters));
        }

        private static string UserMemberName(Expression<Func<User, object>> emailExpression)
        {
            return MemberName(emailExpression);

            string MemberName(LambdaExpression expression)
            {
                var memberExpression = expression.Body as MemberExpression;

                if (memberExpression != null)
                {
                    return memberExpression.Member.Name;
                }

                var methodExpression = expression.Body as MethodCallExpression;

                if (methodExpression != null)
                {
                    return methodExpression.Method.Name;
                }

                var unaryExpression = expression.Body as UnaryExpression;

                if (unaryExpression != null)
                {
                    var unaryMember = unaryExpression.Operand as MemberExpression;

                    if (unaryMember == null)
                    {
                        throw new ArgumentException($"Strange operand in unary expression '{expression}'");
                    }

                    return unaryMember.Member.Name;
                }

                throw new ArgumentException($"Expression '{expression}' of type '{expression.Body.GetType()}' is not handled");
            }
        }
    }
}
