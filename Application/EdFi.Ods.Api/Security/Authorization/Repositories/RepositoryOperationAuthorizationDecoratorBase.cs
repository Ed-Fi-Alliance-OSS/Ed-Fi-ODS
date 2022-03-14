// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Security.DataAccess.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract base class for authorization decorators to use for invoking 
    /// authorization.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entity/request.</typeparam>
    public abstract class RepositoryOperationAuthorizationDecoratorBase<TEntity>
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
        private readonly IExplicitObjectValidator[] _explicitObjectValidators;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
        private readonly ISessionFactory _sessionFactory;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

        private readonly Lazy<Dictionary<string, Actions>> _bitValuesByAction;

        [Flags]
        private enum Actions
        {
            Create = 0x1,
            Read = 0x2,
            Update = 0x4,
            Delete = 0x8,
        }
        
        protected RepositoryOperationAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IExplicitObjectValidator[] explicitObjectValidators,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            ISecurityRepository securityRepository,
            ISessionFactory sessionFactory,
            IApiKeyContextProvider apiKeyContextProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _authorizationFilteringProvider = authorizationFilteringProvider;
            _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
            _explicitObjectValidators = explicitObjectValidators;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _sessionFactory = sessionFactory;
            _apiKeyContextProvider = apiKeyContextProvider;

            // Lazy initialization
            _bitValuesByAction = new Lazy<Dictionary<string, Actions>>(
                () => new Dictionary<string, Actions>
                {
                    { securityRepository.GetActionByName("Create").ActionUri, Actions.Create },
                    { securityRepository.GetActionByName("Read").ActionUri, Actions.Read },
                    { securityRepository.GetActionByName("Update").ActionUri, Actions.Update },
                    { securityRepository.GetActionByName("Delete").ActionUri, Actions.Delete }
                });
        }

        /// <summary>
        /// Invokes authorization of the request using the resource/action currently in context.
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var action = _authorizationContextProvider.GetAction();

            await AuthorizeSingleItemAsync(entity, action, cancellationToken);
        }

        
        // /// <summary>
        // /// Authorizes a single-item request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
        // /// </summary>
        // /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        // Task AuthorizeSingleItemAsync(EdFiAuthorizationContext authorizationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Invokes authorization of the request using the resource currently in context but wit 
        /// an override action (e.g. for converting the "Upsert" action to either "Create" or "Update").
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="actionUri">The action being performed with the request/entity.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, string actionUri, CancellationToken cancellationToken)
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();

            // Build the AuthorizationContext
            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current, // TODO: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
                _authorizationContextProvider.GetResourceUris(),
                actionUri,
                entity);

            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext);

            PerformAuthorizationValidation(authorizationContext, authorizationBasisMetadata);

            // Get the authorization filtering information
            var authorizationFiltering =
                _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);

            // throw new NotImplementedException(
            //     "Multiple authorization strategy support for single-item authorization is a work in progress.");
            
            // Authorize the call
            //await _authorizationProvider.AuthorizeSingleItemAsync(authorizationContext, cancellationToken);
            
            var andStrategies = authorizationFiltering
                .Where(asf => asf.Operator == FilterOperator.And)
                .ToArray();

            // var andResults = andStrategies.SelectMany(
            //         s => s.Filters.Select(
            //             f => new
            //             {
            //                 FilterDefinition = _authorizationFilterDefinitionProvider.GetFilterDefinition(f.FilterName),
            //                 FilterContext = f
            //             }))
            //     .Select(x => new 
            //     { 
            //         Result = x.FilterDefinition.AuthorizeInstance(authorizationContext, x.FilterContext),
            //         FilterDefinition = x.FilterDefinition
            //     })
            //     .ToArray();

            var andResults = andStrategies.Select(
                    s => new
                    {
                        AuthorizationStrategyName = s.AuthorizationStrategyName,
                        Filters = s.Filters
                            .Select(
                                f => new
                                {
                                    FilterDefinition = _authorizationFilterDefinitionProvider.GetFilterDefinition(f.FilterName),
                                    FilterContext = f
                                })
                            .Select(
                                x => new
                                {
                                    Result = new ResolvableInstanceAuthorizationResult(x.FilterDefinition.AuthorizeInstance(authorizationContext, x.FilterContext)), // as IInstanceAuthorizationResult,
                                    FilterDefinition = x.FilterDefinition,
                                })
                            .ToArray()
                    })
                .ToArray();
            
            // Throw exception for the first failure now, if any were encountered
            andResults
                .SelectMany(x => x.Filters.Select(y => y.Result.Exception))
                .Where(ex => ex != null)
                .ForEach(ex => throw ex);

            // For remaining pending authorizations requiring database access, get the existence checks SQL fragments  
            var pendingAndExistenceCheckSqlFragments = andResults.Select(
                    x => new
                    {
                        AuthorizationStrategyName = x.AuthorizationStrategyName,
                        PendingExistenceChecks = x.Filters
                            .Where(y => !y.Result.AuthorizationPerformed)
                            .Select(y => new
                            {
                                FilterDefinition = y.FilterDefinition as ViewBasedAuthorizationFilterDefinition,
                                Result = y.Result as ResolvableInstanceAuthorizationResult,
                            })
                            // .Select(y => y.FilterDefinition)
                            // .Cast<ViewBasedAuthorizationFilterDefinition>()
                            // .Select(
                            //     y => new
                            //     {
                            //         FilterName = y.FilterName,
                            //         SubjectEndpointName = y.SubjectEndpointName,
                            //         ItemExistenceSql = y.ItemExistenceSql
                            //     })
                    });

            var orStrategies = authorizationFiltering
                .Where(f => f.Operator == FilterOperator.Or).ToArray();
                
            var orResults = orStrategies
                .Select(s => 
                        new
                        {
                            AuthorizationStrategyName = s.AuthorizationStrategyName,
                            Filters = s.Filters
                                .Select(f => new
                                {
                                    FilterDefinition = _authorizationFilterDefinitionProvider.GetFilterDefinition(f.FilterName),
                                    FilterContext = f
                                })
                                .Select(x => new
                                { 
                                    Result = new ResolvableInstanceAuthorizationResult(x.FilterDefinition.AuthorizeInstance(authorizationContext, x.FilterContext)) as IInstanceAuthorizationResult,
                                    FilterDefinition = x.FilterDefinition
                                })
                                .ToArray()
                        }
                    )
                .ToArray();

            bool orConditionAlreadySatisfied = orResults.Any(r => 
                r.Filters.All(f => f.Result == InstanceAuthorizationResult.Success));

            if (orConditionAlreadySatisfied)
            {
                // Check pending ANDs
                if (pendingAndExistenceCheckSqlFragments.Any())
                {
                    // Execute SQL to determine AND results
                    throw new NotImplementedException("Or conditions satisfied, but AND SQL existence checks not yet supported");
                }
            }
            else
            {
                // We'll need to go to the database to check for relationship existence 
                var pendingOrExistenceCheckSqlFragments = orResults
                    // Don't check any OR strategy that already has a failure
                    .Where(x => x.Filters.All(f => f.Result.Exception == null))
                    .Select(
                        x => new
                        {
                            AuthorizationStrategyName = x.AuthorizationStrategyName,
                            PendingExistenceChecks = x.Filters //.Select(x => x.Filters)
                                .Where(y => !y.Result.AuthorizationPerformed)
                                .Select(y => new
                                {
                                    FilterDefinition = y.FilterDefinition as ViewBasedAuthorizationFilterDefinition,
                                    Result = y.Result as ResolvableInstanceAuthorizationResult,
                                })
                                // .Select(y => y.FilterDefinition)
                                // .Cast<ViewBasedAuthorizationFilterDefinition>()
                                // .Select(
                                //     y => new
                                //     {
                                //         FilterName = y.FilterName, 
                                //         SubjectEndpointName = y.SubjectEndpointName,
                                //         ItemExistenceSql = y.ItemExistenceSql,
                                //     })
                                
                        });

                var existenceCheckSqlFragments = 
                    pendingAndExistenceCheckSqlFragments.Concat(pendingOrExistenceCheckSqlFragments);

                // Build the existence check SQL
                StringBuilder sql = new();

                // TODO: GKM - BEGIN SQL Server specific code
                // sql.AppendLine("DECLARE @claimEdOrgIds as dbo.IntTable");
                // sql.Append("INSERT INTO @claimEdOrgIds VALUES ");
                //
                // var claimEdOrgIds= _apiKeyContextProvider.GetApiKeyContext().EducationOrganizationIds;
                //
                // claimEdOrgIds.ForEach(id =>
                // {
                //     sql.Append('(');
                //     sql.Append(id);
                //     sql.Append(')');
                // });
                // TODO: GKM - END SQL Server specific code
                
                sql.Append("SELECT ");

                List<CompositeResolvableInstanceAuthorizationResult> resolvableResults = new();
                
                existenceCheckSqlFragments.ForEach(
                    (x, i) =>
                    {
                        if (i > 0)
                        {
                            sql.Append(", ");
                        }

                        sql.Append("CASE WHEN ");

                        var compositeResolvableResult = new CompositeResolvableInstanceAuthorizationResult();
                        resolvableResults.Add(compositeResolvableResult);
                        
                        x.PendingExistenceChecks.ForEach(
                            (y, j) =>
                            {
                                if (j > 0)
                                {
                                    sql.Append(" AND ");
                                }

                                sql.Append("EXISTS (");
                                sql.Append(y.FilterDefinition.ItemExistenceSql);
                                sql.Append(')');
                                
                                // sql.Append(") THEN 1 ELSE 0 END AS IsAuthorized_");
                                // sql.Append(i);
                                // sql.Append("_");
                                // sql.Append(j);
                                
                                compositeResolvableResult.AddAuthorizationResult(y.Result);
                                // resolvableResults.Add(y.Result);
                            });
                        
                        sql.Append(" THEN 1 ELSE 0 END AS IsAuthorized_");
                        sql.Append(i);
                    });

                // ColumnNames in results -> {AuthorizationStrategyName}_{FilterName}_{SubjectEndpointName}

                // Execute the query
                using var sessionScope = new SessionScope(_sessionFactory);

                using var cmd = sessionScope.Session.Connection.CreateCommand();

                // Assign the command text
                cmd.CommandText = sql.ToString();

                // Assign all parameters
                cmd.Parameters.AddRange(
                authorizationFiltering.SelectMany(
                    x => x.Filters.Select(
                        f =>
                        {
                            var parameter = cmd.CreateParameter();
                            parameter.ParameterName = f.SubjectEndpointName;
                            parameter.Value = f.SubjectEndpointValue;

                            return parameter;
                        }))
                    .GroupBy(x => x.ParameterName)
                    .Select(x => x.First())
                    .ToArray());

                // Assign EdOrgId claims
                var claimEdOrgIds= _apiKeyContextProvider.GetApiKeyContext().EducationOrganizationIds;

                if (cmd is SqlCommand)
                {
                    var sqlParameter = cmd.CreateParameter() as SqlParameter;

                    DataTable dt = new();
                    dt.Columns.Add("Id", typeof(int));

                    foreach (int claimEdOrgId in claimEdOrgIds)
                    {
                        dt.Rows.Add(claimEdOrgId);
                    }

                    sqlParameter!.ParameterName = "ClaimEducationOrganizationIds";
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "dbo.IntTable";
                    sqlParameter.Value = dt;

                    cmd.Parameters.Add(sqlParameter);
                }
                else
                {
                    throw new NotImplementedException("PostgreSQL support not yet implemented.");
                }
                
                // Process the pending AND SQL checks, ensure that they are all 1, or throw an exception
                using var result = await cmd.ExecuteReaderAsync(cancellationToken);

                await result.ReadAsync(cancellationToken);

                for (int i = 0; i < result.FieldCount; i++)
                {
                    if (result.GetInt32(i) == 0)
                    {
                        resolvableResults[i].ResolveWithFailure(new EdFiSecurityException("No established relationships."));
                    }
                    else
                    {
                        resolvableResults[i].ResolveSuccessful();
                    }
                }
                
                // Process the pending OR checks, ensure that at least one of them has all 1s, or throw an exception
                bool orConditionSatisfied = orResults.Any(r => 
                    r.Filters.All(f => f.Result.AuthorizationPerformed && f.Result.Exception == null));

                if (!orConditionSatisfied)
                {
                    throw new EdFiSecurityException("Need better exception here.");
                }
            }
            
            // We're authorized
            
            /*
                DECLARE @claimEdOrgIds as dbo.IntTable, 
                    @subjectStudentUSI INT = 954,
                    @subjectEdOrgId INT = 255901044

                INSERT INTO @claimEdOrgIds VALUES (255901044);

                SELECT 
                    CASE
                        WHEN 
                            EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToEducationOrganizationId authvw INNER JOIN @claimEdOrgIds c ON authvw.SourceEducationOrganizationId = c.Id AND authvw.TargetEducationOrganizationId = @subjectEdOrgId)
                            AND EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStudentUSI authvw INNER JOIN @claimEdOrgIds c ON authvw.SourceEducationOrganizationId = c.Id AND authvw.StudentUSI = @subjectStudentUSI)
                        THEN 1
                        ELSE 0
                    END AS IsAuthorized_RelationshipsWithEdOrgsAndPeople,
                    CASE
                        WHEN 
                            EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToEducationOrganizationId authvw INNER JOIN @claimEdOrgIds c ON authvw.SourceEducationOrganizationId = c.Id AND authvw.TargetEducationOrganizationId = @subjectEdOrgId)
                            AND EXISTS (SELECT 1 FROM auth.EducationOrganizationIdToStudentUSIThroughResponsibility authvw INNER JOIN @claimEdOrgIds c ON authvw.SourceEducationOrganizationId = c.Id AND authvw.StudentUSI = @subjectStudentUSI)
                        THEN 1
                        ELSE 0
                    END AS IsAuthorized_RelationshipsWithStudentsOnlyThroughResponsibilty
             */
            
            // foreach (var filtering in andStrategies)
            // {
            //     foreach (AuthorizationFilterDetails filterDetails in filtering.Filters)
            //     {
            //         filterDetails.
            //     }
            // }
            
            bool IsCreateUpdateOrDelete(EdFiAuthorizationContext authorizationContext)
            {
                return (_bitValuesByAction.Value[authorizationContext.Action.Single().Value] 
                    & (Actions.Create | Actions.Update | Actions.Delete)) != 0;
            }

            void PerformAuthorizationValidation(
                EdFiAuthorizationContext edFiAuthorizationContext,
                AuthorizationBasisMetadata authorizationBasisMetadata1)
            {
                // If there are explicit object validators, and we're modifying data
                if (_explicitObjectValidators.Any() && IsCreateUpdateOrDelete(edFiAuthorizationContext))
                {
                    // Validate the object using explicit validation
                    var validationResults = _explicitObjectValidators.ValidateObject(
                        edFiAuthorizationContext.Data,
                        authorizationBasisMetadata1.ValidationRuleSetName);

                    if (!validationResults.IsValid())
                    {
                        throw new ValidationException(
                            string.Format(
                                "Validation of '{0}' failed.\n{1}",
                                edFiAuthorizationContext.Data.GetType().Name,
                                string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))));
                    }
                }
            }
        }

        protected IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering<TEntity>()
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();
        
            // Build the AuthorizationContext
            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current,
                _authorizationContextProvider.GetResourceUris(),
                _authorizationContextProvider.GetAction(),
                typeof(TEntity));
        
            // Get authorization filters
            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext);

            return _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);
        }

        // protected void AuthorizeResourceActionOnly(TEntity entity, string actionUri)
        // {
        //     // Make sure Authorization context is present before proceeding
        //     _authorizationContextProvider.VerifyAuthorizationContextExists();
        //
        //     // Build the AuthorizationContext
        //     EdFiAuthorizationContext authorizationContext = new EdFiAuthorizationContext(
        //         ClaimsPrincipal.Current,
        //         _authorizationContextProvider.GetResourceUris(),
        //         actionUri,
        //         entity);
        //
        //     // Authorize the call
        //     _authorizationProvider.AuthorizeResourceActionOnly(authorizationContext);
        // }
    }
}
