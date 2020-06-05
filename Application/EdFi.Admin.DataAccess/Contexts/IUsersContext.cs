// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Admin.DataAccess.Contexts
{
    public interface IUsersContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<ApiClient> Clients { get; set; }

        IDbSet<ClientAccessToken> ClientAccessTokens { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Application> Applications { get; set; }

        IDbSet<Profile> Profiles { get; set; }

        IDbSet<OdsInstance> OdsInstances { get; set; }

        IDbSet<OdsInstanceComponent> OdsInstanceComponents { get; set; }

        IDbSet<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        IDbSet<VendorNamespacePrefix> VendorNamespacePrefixes { get; set; }

        IDbSet<OwnershipToken> OwnershipToken { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        /// <summary>
        /// Asynchronously executes a raw SQL statement with only a scalar result (e.g. row count).
        /// </summary>
        /// <param name="sqlStatement">Query to execute, optionally containing parameter strings using @ symbol token</param>
        /// <param name="parameters">Optional parameters</param>
        /// <returns>Statement result (row count by default)</returns>
        /// <example>
        /// <para>
        /// No parameters:
        /// </para>
        /// <code>
        /// <![CDATA[
        /// string sqlCommand = "UPDATE dbo.Something SET FieldOne = null";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand);
        /// ]]>
        /// </code>
        /// <para>
        /// Single parameter, @p0. The name does not matter; @p0 is a good standard to follow to indicate to the reader that it is the first parameter.
        /// </para>
        /// <code>
        /// <![CDATA[
        /// int fieldTwoLowerLimit = 30;
        /// string sqlCommand = "UPDATE dbo.Something SET FieldOne = null WHERE FieldTwo > @p0";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand, fieldTwoLowerLimit);
        /// ]]>
        /// </code>
        /// <para>
        /// Two parameters, second one for a CreateDate field that we're not going to return.
        /// </para>
        /// <code>
        /// <![CDATA[
        /// int fieldTwoLowerLimit = 30;
        /// DateTime createDateUpperLimit = DateTime.Parse(2020,1,1);
        /// string sqlCommand = "UPDATE dbo.Something SET FieldOne = null WHERE FieldTwo > @p0 AND CreateDate < '@p1'";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand, fieldTwoLowerLimit, createDateUpperLimit);
        /// ]]>
        /// </code>
        /// </example>
        Task<int> ExecuteSqlCommandAsync(string sqlStatement, params object[] parameters);

        /// <summary>
        /// Asynchronously executes a raw SQL query and maps the results to an object of type <typeparamref name="TReturn"/>.
        /// </summary>
        /// <typeparam name="TReturn">Any class with properties matching the column names in the query</typeparam>
        /// <param name="sqlStatement">Query to execute, optionally containing parameter strings using @ symbol token</param>
        /// <param name="parameters">Optional parameters</param>
        /// <returns>Readonly list of <typeparamref name="TReturn"/></returns>
        /// <example>
        /// <para>
        /// Given this return entity:
        /// </para>
        /// <code>
        /// public class Something { public string FieldOne { get; set; } public int FieldTwo { get; set; } }
        /// </code>
        /// <para>
        /// No parameters:
        /// </para>
        /// <code>
        /// <![CDATA[
        /// string sqlCommand = "SELECT FieldOne, FieldTwo FROM dbo.Something";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand);
        /// ]]>
        /// </code>
        /// <para>
        /// Single parameter, @p0. The name does not matter; @p0 is a good standard to follow to indicate to the reader that it is the first parameter.
        /// </para>
        /// <code>
        /// <![CDATA[
        /// int fieldTwoLowerLimit = 30;
        /// string sqlCommand = "SELECT FieldOne, FieldTwo FROM dbo.Something WHERE FieldTwo > @p0";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand, fieldTwoLowerLimit);
        /// ]]>
        /// </code>
        /// <para>
        /// Two parameters, second one for a CreateDate field that we're not going to return.
        /// </para>
        /// <code>
        /// <![CDATA[
        /// int fieldTwoLowerLimit = 30;
        /// DateTime createDateUpperLimit = DateTime.Parse(2020,1,1);
        /// string sqlCommand = "SELECT FieldOne, FieldTwo FROM dbo.Something WHERE FieldTwo > @p0 AND CreateDate < '@p1'";
        /// IReadOnlyList<Something> result = await _usersContext.ExecuteQueryAsync<Something>(sqlCommand, fieldTwoLowerLimit, createDateUpperLimit);
        /// ]]>
        /// </code>
        /// </example>
        Task<IReadOnlyList<TReturn>> ExecuteQueryAsync<TReturn>(string sqlStatement, params object[] parameters);
    }
}
