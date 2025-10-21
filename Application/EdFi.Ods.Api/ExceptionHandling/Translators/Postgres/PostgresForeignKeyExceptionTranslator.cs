// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresForeignKeyExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IDiscriminatorResolver _discriminatorResolver;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        private static readonly IContextStorage _contextStorage = new CallContextStorage();

        public PostgresForeignKeyExceptionTranslator(
            IDomainModelProvider domainModelProvider,
            IDiscriminatorResolver discriminatorResolver,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _domainModelProvider = domainModelProvider;
            _discriminatorResolver = discriminatorResolver;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exceptionToEvaluate = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exceptionToEvaluate is PostgresException postgresException)
            {
                if (postgresException.SqlState == PostgresSqlStates.ForeignKeyViolation)
                {
                    // Try to get the entity affected
                    if (_domainModelProvider.GetDomainModel()
                        .EntityByFullName.TryGetValue(new FullName(postgresException.SchemaName, postgresException.TableName), out var entity))
                    {
                        // For "insert or update" violations, extract table name from the constraint name
                        //     EXAMPLE: insert or update on table "school" violates foreign key constraint "fk_6cd2e3_localeducationagency"
                        if (postgresException.MessageText.Contains("insert or update"))
                        {
                            // Iterate the incoming associations looking for the offending constraint
                            var association = entity?.IncomingAssociations.SingleOrDefault(
                                a =>
                                    a.Association.ConstraintByDatabaseEngine[DatabaseEngine.Postgres.Value]
                                    .EqualsIgnoreCase(postgresException.ConstraintName));

                            if (association != null)
                            {
                                problemDetails = new UnresolvedReferenceException(association.OtherEntity.Name);

                                return true;
                            }
                        }
                        else if (postgresException.MessageText.Contains("update or delete"))
                        {
                            // NOTE: FK violations won't happen in the ODS for "update" because where key updates are allowed, cascade updates are applied.
                            // So this scenario will only happen with deletes where there are child aggregate/resources that must be removed first.

                            // Attempt discriminator-based refinement for abstract entities
                            entity = RefineEntityUsingDiscriminator(entity, postgresException.SchemaName, postgresException.TableName);

                            problemDetails = new DependentResourceItemExistsException(entity);

                            return true;
                        }
                    }

                    // Unable to determine details, probably due to long table name munging for Postgres identities
                    problemDetails = postgresException.MessageText.Contains("update or delete")
                        ? new DependentResourceItemExistsException()
                        : new UnresolvedReferenceException();

                    return true;
                }
            }

            problemDetails = null;
            return false;
        }

        private Entity RefineEntityUsingDiscriminator(Entity entity, string schema, string tableName)
        {
            // Only attempt refinement if entity is abstract and has discriminator
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
                var discriminators = _discriminatorResolver.GetDistinctDiscriminatorsAsync(
                    schema,
                    tableName,
                    parentEntity,
                    deleteContext.Id,
                    maxResults: 1).Result;

                // If a discriminator is found, try to find matching derived entity
                if (discriminators.Any())
                {
                    var derivedEntity = entity.DerivedEntities
                            .FirstOrDefault(d => discriminators[0].Contains(d.Name, StringComparison.OrdinalIgnoreCase));

                    if (derivedEntity != null)
                    {
                        return derivedEntity;
                    }
                }

                // If zero discriminators, fall back to the abstract entity
                return entity;
            }
            catch
            {
                // If any error occurs during discriminator resolution, return the original entity
                return entity;
            }
        }
    }
}
