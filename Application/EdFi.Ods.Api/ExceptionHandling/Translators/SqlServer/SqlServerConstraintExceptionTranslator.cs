// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Api.ExceptionHandling.Translators.Postgres;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerConstraintExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IDiscriminatorResolver _discriminatorResolver;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        private static readonly IContextStorage _contextStorage = new CallContextStorage();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(SqlServerConstraintExceptionTranslator));

        public SqlServerConstraintExceptionTranslator(
            IDomainModelProvider domainModelProvider,
            IDiscriminatorResolver discriminatorResolver,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _domainModelProvider = domainModelProvider;
            _discriminatorResolver = discriminatorResolver;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        /* Sample errors:

         * Delete fails, single column child reference
         * -------------------------------------------
         * The DELETE statement conflicted with the REFERENCE constraint "FK_CourseTranscript_CourseAttemptResultType_CourseAttemptResultTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.CourseTranscript", column 'CourseAttemptResultTypeId'.
        *  The statement has been terminated.

         * Delete fails, multiple column child reference
         * ---------------------------------------------
         * The DELETE statement conflicted with the REFERENCE constraint "FK_DisciplineAction_DisciplineIncident_SchoolId". The conflict occurred in database "EdFi_Ods", table "edfi.DisciplineAction".
         * The statement has been terminated.
         *
         * Insert fails, single column parent reference
         * --------------------------------------------
         * The INSERT statement conflicted with the FOREIGN KEY constraint "FK_StudentAddress_AddressType_AddressTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.AddressType", column 'AddressTypeId'.
         * The statement has been terminated.

         * Update fails, single column parent reference
         * --------------------------------------------
         * The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Student_LimitedEnglishProficiencyType_LimitedEnglishProficiencyTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.LimitedEnglishProficiencyType", column 'LimitedEnglishProficiencyTypeId'.
         * The statement has been terminated.
         *
         */

        private static readonly Regex _expression = new(
            @"^The (?<StatementType>INSERT|UPDATE|DELETE) statement conflicted with the (?<ConstraintType>FOREIGN KEY|REFERENCE) constraint ""(?<ConstraintName>\w+)"".*?table ""(?<SchemaName>\w+)\.(?<TableName>\w+)""(?:, column '(?<ColumnName>\w+)')?");

        // ^The (?<Statement>INSERT|UPDATE|DELETE) statement conflicted with the (?<ConstraintType>FOREIGN KEY|REFERENCE) constraint "(?<ConstraintName>\w+)".*?table "(?<SchemaName>\w+)\.(?<TableName>\w+)".*?(?: column '(?<ColumnName>\w+)')?
        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                // Is this a constraint violation message from SQL Server?
                var match = _expression.Match(exception.Message);

                if (match.Success)
                {
                    string statementType = match.Groups["StatementType"].Value;
                    string constraintType = match.Groups["ConstraintType"].Value;
                    string schemaName = match.Groups["SchemaName"].Value;
                    string tableName = match.Groups["TableName"].Value;

                    switch (statementType)
                    {
                        case "INSERT":
                        case "UPDATE":

                            if (constraintType == "FOREIGN KEY")
                            {
                                problemDetails = new UnresolvedReferenceException(tableName);
                                return true;
                            }

                            break;

                        case "DELETE":

                            if (constraintType == "REFERENCE")
                            {
                                if (_domainModelProvider.GetDomainModel()
                                    .EntityByFullName.TryGetValue(new FullName(schemaName, tableName), out var entity))
                                {
                                    // Attempt to refine the entity if it's abstract and has a discriminator
                                    entity = RefineEntityUsingDiscriminator(entity, schemaName, tableName);

                                    problemDetails = new DependentResourceItemExistsException(entity);

                                    return true;
                                }
                            }

                            break;
                    }
                }
            }

            problemDetails = null;
            return false;
        }

        private Entity RefineEntityUsingDiscriminator(Entity entity, string schema, string tableName)
        {
            // Only attempt refinement if the entity is abstract and uses a discriminator
            if (!entity.IsAbstract || !entity.HasDiscriminator())
            {
                return entity;
            }

            try
            {
                var resourceContext = _dataManagementResourceContextProvider.Get();
                if (resourceContext?.Resource?.Entity == null)
                {
                    return entity; // No context available
                }

                var parentEntity = resourceContext.Resource.Entity;

                var deleteContext = _contextStorage.GetValue<DeleteContext>(nameof(DeleteContext));
                if (deleteContext == null)
                {
                    return entity; // No delete context available
                }

                // Query for one discriminator
                var discriminators = _discriminatorResolver.GetDistinctDiscriminators(
                    schema,
                    tableName,
                    parentEntity,
                    deleteContext.Id,
                    maxResults: 1);

                // If a discriminator is found, try to find matching derived entity
                if (discriminators.Any())
                {
                    var derivedEntity = entity.DerivedEntities
                        .FirstOrDefault(d => discriminators.Any(x => x.Equals(d.FullName.ToString(), StringComparison.OrdinalIgnoreCase)));

                    if (derivedEntity != null)
                    {
                        return derivedEntity;
                    }
                }

                // If zero discriminators, fall back to the abstract entity
                return entity;
            }
            catch (Exception ex)
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"Failed to refine entity using discriminator for {schema}.{tableName}: {ex.Message}", ex);
                }
                return entity;
            }
        }
    }
}
