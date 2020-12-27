// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Database;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Controllers.DataManagement;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Api.Controllers.DataManagement.Validation;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json")]
    [Route("{schema}/{resourceCollection}")]
    public class DataManagementResourceController : ControllerBase
    {
        private readonly IDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly IRequestResourceResolver _requestResourceResolver;
        private readonly IResourceDataProvider _resourceDataProvider;
        private readonly IPhysicalNamesProvider _physicalNamesProvider;
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IResourceClaimUriProvider _resourceClaimUriProvider;
        private readonly IEntityPropertyValidator[] _propertyValidators;

        private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementResourceController));
        private Dictionary<FullName, IEntityRecordValidator[]> _validatorsByEntity;

        public DataManagementResourceController(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IRequestResourceResolver requestResourceResolver,
            IResourceDataProvider resourceDataProvider,
            IPhysicalNamesProvider physicalNamesProvider,
            // GET Authorization-related
            IAuthorizationContextProvider authorizationContextProvider,
            IResourceClaimUriProvider resourceClaimUriProvider,
            // Validation related
            IEntityPropertyValidator[] propertyValidators,
            IEntityRecordValidator[] entityRecordValidators)
        {
            _connectionStringProvider = odsDatabaseConnectionStringProvider;
            _requestResourceResolver = requestResourceResolver;
            _resourceDataProvider = resourceDataProvider;
            _physicalNamesProvider = physicalNamesProvider;
            _authorizationContextProvider = authorizationContextProvider;
            _resourceClaimUriProvider = resourceClaimUriProvider;
            _propertyValidators = propertyValidators;

            _validatorsByEntity = entityRecordValidators.GroupBy(x => x.SupportedEntityName)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }
        
        // Collection operations
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var (resource, error) = _requestResourceResolver.GetResourceForRequest(Request);

            if (error != null)
            {
                return StatusCode(error.Code, new { error.Message });
            }

            // TODO: API Simplification - This *may* be better refactored out into a separate component, or possibly passed along as a parameter rather than using context here 
            SetAuthorizationContext(resource, ReadUri);

            var resourceData = await _resourceDataProvider.GetResourceData(resource, Request.Query);

            return new ContentResult
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = resourceData.ToJson(),
            };
        }

        // TODO: API Simplification - Consider introducing the following class and passing it down through the call chain in favor of the context pattern.
        // public class DataManagementRequestContext
        // {
        //     public Resource Resource { get; }
        //
        //     public string HttpMethod { get; set; }
        //
        //     public IQueryCollection Query { get; }
        //     
        //     public JObject Data { get; }
        // }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] JObject jsonData)
        {
            var (resource, error) = _requestResourceResolver.GetResourceForRequest(Request);

            if (resource == null)
            {
                return StatusCode(error.Code, new { error.Message });
            }

            // TODO: API Simplification - This *may* be better refactored out into a separate component, or possibly passed along the call chain as a DataManagementRequestContext parameter rather than using context here 
            SetAuthorizationContext(resource, UpdateUri);

            // Get the primary key of the resource
            var primaryKeyValues = resource.AllIdentifyingProperties
                .ToDictionary(
                    rp => rp.PropertyName, 
                    rp => (object) jsonData[rp.JsonPropertyName]?.Value<JValue>().Value);
            
            // Get the ODS data for the entire resource
            var resourceData = await _resourceDataProvider.GetResourceData(resource, Request.Query, primaryKeyValues);

            // TODO: API Simplification - Obtain database-specific connection
            await using var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
            await connection.OpenAsync();
            using IDbTransaction transaction = await connection.BeginTransactionAsync();

            IList<string> validationFailures = null;
            
            if (resourceData == null)
            {
                // Create
                // throw new NotImplementedException("Resource creation not yet implemented.");
                
                // If resource is derived, create/update the base entity first.
                if (resource.IsDerived)
                {
                    validationFailures = await ProcessResource(null, connection, transaction, resource, resource.Entity.BaseEntity, null, new JArray(jsonData));
                }

                // Update the table for the resource root
                if (validationFailures?.Any() != true)
                {
                    await ProcessResource(null, connection, transaction, resource, resource.Entity, null, new JArray(jsonData));
                }
            }
            else
            {
                // Update
                
                // Group the existing data by resource class name
                var dataByResourceClassName = resourceData.Results
                    .ToDictionary(
                        x => x.ResourceClass.FullName,
                        x => x.Results.Cast<IDictionary<string,object>>().ToArray());

                // If resource is derived, create/update the base entity first.
                if (resource.IsDerived)
                {
                    validationFailures = await ProcessResource(null, connection, transaction, resource, resource.Entity.BaseEntity, dataByResourceClassName, new JArray(jsonData));
                }

                // Update the table for the resource root
                if (validationFailures?.Any() != true)
                {
                    validationFailures = await ProcessResource(null, connection, transaction, resource, resource.Entity, dataByResourceClassName, new JArray(jsonData));
                }
            }

            if (validationFailures.Any())
            {
                transaction.Rollback();
                return BadRequest(new {Message = $"Validation failed: {string.Join("\n", validationFailures)}"});
            }
            
            transaction.Commit();
            return Ok();
        }

        private async Task<IList<string>> ProcessResource(
            IDictionary<string, object> parentPrimaryKeyValues,
            SqlConnection connection,
            IDbTransaction transaction,
            ResourceClassBase resourceClass,
            Entity entity,
            IDictionary<FullName, IDictionary<string, object>[]> dataByResourceClassName,
            JArray jsonObjects)
        {
            // EXECUTION LOGIC
            var pairs = MatchRecordsToJsonObjects();

            // EXECUTION LOGIC
            // string jsonPathBase = resourceClass.JsonPath + ".";

            // Process inserts and updates
            foreach (var pair in pairs)
            {
                IDictionary<string, object> primaryKeyValues = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                var record = pair.Record;
                var jsonObject = pair.JsonObject;

                List<string> validationFailures;
                
                if (record == null)
                {
                    record = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                    validationFailures = await ProcessInsert(
                        connection,
                        transaction,
                        resourceClass,
                        entity,
                        jsonObject,
                        parentPrimaryKeyValues,
                        primaryKeyValues,
                        record);
                }
                else
                {
                    validationFailures = await ProcessUpdate(
                        connection,
                        transaction,
                        resourceClass,
                        entity,
                        record,
                        pair,
                        primaryKeyValues);
                }

                if (validationFailures.Any())
                {
                     return validationFailures;
                }
                
                // Process children
                foreach (var collection in resourceClass.Collections.Where(c => c.ItemType.Name == "StaffElectronicMail"))
                {
                    // TODO: API Simplification - Handle validations
                    var collectionValidationFailures = await ProcessResource(
                        primaryKeyValues,
                        connection,
                        transaction,
                        collection.ItemType,
                        collection.ItemType.Entity,
                        dataByResourceClassName,
                        pair.JsonObject[collection.JsonPropertyName] as JArray);

                    if (collectionValidationFailures.Any())
                    {
                        return collectionValidationFailures;
                    }
                }
            }

            return new List<string>();

            List<DataPair> MatchRecordsToJsonObjects()
            {
                // EXECUTION LOGIC
                var resourceRecords = parentPrimaryKeyValues == null
                    ? dataByResourceClassName?[resourceClass.FullName] ?? Enumerable.Empty<IDictionary<string, object>>()

                    // Filter available records by parent context
                    : dataByResourceClassName[resourceClass.FullName]
                        .Where(r => parentPrimaryKeyValues.All(x => r[x.Key].Equals(x.Value)));

                var pairs = jsonObjects.GroupJoin(
                        resourceRecords,
                        o => resourceClass.AllIdentifyingProperties.Select(rp => o[rp.JsonPropertyName]?.ToValueAsObject()),
                        d => resourceClass.AllIdentifyingProperties.Select(
                            rp =>
                            {
                                object result;

                                if (rp.IsLookup)
                                {
                                    string @namespace = $"{rp.PropertyName}_Namespace";
                                    string codeValue = $"{rp.PropertyName}_CodeValue";

                                    result = $"{d[@namespace]}#{d[codeValue]}";
                                }
                                else
                                {
                                    result = d[rp.EntityProperty.PropertyName];
                                }

                                return result;
                            }),
                        (o, d) => new DataPair
                        {
                            JsonObject = (JObject) o,
                            Record = d.SingleOrDefault()
                        },
                        new IdentifyingPropertyEnumerableComparer())
                    .ToList();

                return pairs;
            }
        }

        private async Task<List<string>> ProcessUpdate(
            SqlConnection connection,
            IDbTransaction transaction,
            ResourceClassBase resourceClass,
            Entity entity,
            IDictionary<string, object> record,
            DataPair pair,
            IDictionary<string, object> primaryKeyValues)
        {
            // EXECUTION LOGIC
            string jsonPathBase = resourceClass.JsonPath + ".";

            // Update the record with the JObject
            var sqlSetBuilder = new StringBuilder();
            var sqlFromBuilder = new StringBuilder();
            var sqlWhereBuilder = new StringBuilder();

            var descriptorWhereBuilder = new StringBuilder();

            var parameters = new Dictionary<string, object>();

            // Build the WHERE clause for the UPDATE
            foreach (var identifyingProperty in resourceClass.AllIdentifyingProperties)
            {
                string parameterName = _physicalNamesProvider.Identifier(identifyingProperty.EntityProperty.PropertyName);
                string columnName = _physicalNamesProvider.Column(identifyingProperty.EntityProperty);

                // SQL LOGIC
                // parameterSources.Add(new ParameterSource(parameterName, columnName));
                sqlWhereBuilder.Append($" AND {columnName} = @{parameterName}");

                // EXECUTION LOGIC
                parameters.Add(parameterName, record[columnName]);

                // TODO: API Simplification - Need to handle primary key updates in secondary follow-up transaction
            }

            // Descriptor index used for simple descriptor table aliasing
            int descriptorIndex = 1;

            var attemptedDescriptors = new List<ValueTuple<string, string, string>>();

            var coercionMessages = new List<string>();
            var validationMessages = new List<string>();

            // Process non-identifying properties
            foreach (var resourceProperty in resourceClass.NonIdentifyingProperties.Where(p => !p.IsResourceIdentifier())
                .Where(p => p.EntityProperty.Entity == entity))
            {
                var entityProperty = resourceProperty.EntityProperty;

                string relativeJsonPath = resourceProperty.JsonPath.TrimPrefix(jsonPathBase);

                // EXECUTION LOGIC
                var proposedValueAsObject =
                    pair.JsonObject.SelectToken(relativeJsonPath)
                        ?.Value<JValue>()
                        ?.Value; // [property.JsonPropertyName]?.Value<object>();

                // EXECUTION LOGIC
                var coercedValue = CoerceProposedValue(resourceProperty, proposedValueAsObject, coercionMessages);
                ValidateProperty(entityProperty, coercedValue, resourceProperty.JsonPropertyName, validationMessages);

                // EXECUTION LOGIC
                // If there are any errors, don't do additional work related to the query.
                if (coercionMessages.Any() || validationMessages.Any())
                {
                    continue;
                }

                // Handle descriptor updates
                if (entityProperty.IsLookup)
                {
                    // EXECUTION LOGIC
                    var proposedDescriptorValue = coercedValue as string;

                    // EXECUTION LOGIC
                    if (proposedDescriptorValue == null)
                    {
                        // TODO: API Simplification - May want to consider using a parameter here rather than literal SQL --> parameters.Add(entityPropertyName, proposedValue);
                        string columnName = _physicalNamesProvider.Column(entityProperty);
                        string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);

                        parameters.Add(parameterName, null);
                        sqlSetBuilder.Append($", {columnName} = @{parameterName}");

                        record[columnName] = null;
                    }
                    else
                    {
                        sqlFromBuilder.Append($", {EdFiConventions.PhysicalSchemaName}.Descriptor d{descriptorIndex}");

                        // EXECUTION LOGIC
                        int delimiterPos = proposedDescriptorValue?.IndexOf('#') ?? -1;

                        // EXECUTION LOGIC
                        if (delimiterPos < 0 || delimiterPos == proposedDescriptorValue.Length)
                        {
                            throw new Exception("Format of descriptor value is incorrect.");
                        }

                        // EXECUTION LOGIC
                        var descriptorNamespace = proposedDescriptorValue.Substring(0, delimiterPos);
                        var descriptorCodeValue = proposedDescriptorValue.Substring(delimiterPos + 1);

                        // TODO: API Simplification - This implementation is SQL Server specific (needs a seam)
                        sqlSetBuilder.Append(
                            $", {_physicalNamesProvider.Column(entityProperty)} = COALESCE(d{descriptorIndex}.DescriptorId, 0)");

                        sqlWhereBuilder.Append(
                            $" AND (d{descriptorIndex}.Namespace = @d{descriptorIndex}Namespace AND d{descriptorIndex}.CodeValue = @d{descriptorIndex}CodeValue)");

                        // EXECUTION LOGIC
                        parameters.Add($"d{descriptorIndex}Namespace", descriptorNamespace);
                        parameters.Add($"d{descriptorIndex}CodeValue", descriptorCodeValue);

                        // Set the record value
                        string namespaceIdentifier = $"{resourceProperty.PropertyName}_Namespace";
                        string codeValueIdentifier = $"{resourceProperty.PropertyName}_CodeValue";
                        record[namespaceIdentifier] = descriptorNamespace;
                        record[codeValueIdentifier] = descriptorCodeValue;

                        // TODO: API Simplification - Remove the descriptor id from the record (for validation)?

                        // parameterSources.Add(new ParameterSource($"d{descriptorIndex}Namespace", ));

                        descriptorWhereBuilder.Append(
                            $" OR (Namespace = @d{descriptorIndex}Namespace AND CodeValue = @d{descriptorIndex}CodeValue)");

                        attemptedDescriptors.Add((resourceProperty.LookupTypeName, descriptorNamespace, descriptorCodeValue));

                        descriptorIndex++;
                    }
                }
                else // TODO: API Simplification - Consider "dirty" checking and only updating modified columns --> if (!proposedValue.Equals(existingValue))
                {
                    string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);
                    string columnName = _physicalNamesProvider.Column(entityProperty);

                    parameters.Add(parameterName, coercedValue);
                    sqlSetBuilder.Append($", {columnName} = @{parameterName}");

                    record[columnName] = coercedValue;
                }
            } // Non-identifying properties

            // TODO: API Simplification - Perform custom record validation
            ValidateRecord(entity, record, validationMessages);

            // If there are any errors, don't do additional work related to the query.
            if (coercionMessages.Any() || validationMessages.Any())
            {
                // TODO: API Simplification - Report this in the method response as validation errors matching existing behavior
                return coercionMessages.Concat(validationMessages).ToList();
            }

            string from = sqlFromBuilder.Length > 0
                ? $"FROM {resourceClass.FullName.Schema}.{resourceClass.FullName.Name}{sqlFromBuilder}"
                : null;

            string descriptorDiagnostics = descriptorWhereBuilder.Length > 0
                ? $@" IF @@rowcount = 0
                    SELECT   DescriptorId, Namespace, CodeValue
                    FROM     edfi.Descriptor 
                    WHERE {descriptorWhereBuilder.ToString(3, descriptorWhereBuilder.Length - 3)}"
                : null;

            string sql = $@"
    UPDATE {_physicalNamesProvider.FullName(entity)}
    SET {sqlSetBuilder.ToString(2, sqlSetBuilder.Length - 2)}
    {@from}
    WHERE {sqlWhereBuilder.ToString(4, sqlWhereBuilder.Length - 4)}
    {descriptorDiagnostics}";

            if (descriptorDiagnostics?.Length > 0)
            {
                await ProcessDescriptorResolution(connection, transaction, sql, parameters, attemptedDescriptors);
            }
            else
            {
                await connection.ExecuteAsync(sql, parameters, transaction);
            }

            var pkValues = entity.Identifier.Properties.ToDictionary(
                p => _physicalNamesProvider.Column(p),
                p => record[_physicalNamesProvider.Column(p)],
                StringComparer.OrdinalIgnoreCase);

            // Copy PK values
            foreach (var pkValue in pkValues)
            {
                primaryKeyValues.Add(pkValue.Key, pkValue.Value);
            }
            
            // No validation errors
            return new List<string>();
        }

        private void ValidateRecord(Entity entity, IDictionary<string,object> record, List<string> validationMessages)
        {
            if (!_validatorsByEntity.TryGetValue(entity.FullName, out var validators))
            {
                return;
            }

            foreach (var validator in validators)
            {
                validator.Validate(entity, record, validationMessages);
            }
        }

        private async Task<List<string>> ProcessInsert(
            SqlConnection connection,
            IDbTransaction transaction,
            ResourceClassBase resourceClass,
            Entity entity,
            JObject jsonObject,
            IDictionary<string, object> parentPrimaryKeyValues,
            IDictionary<string, object> primaryKeyValues,
            IDictionary<string, object> record)
        {
            string jsonPathBase = resourceClass.JsonPath + ".";

            // Insert a record sourced from the JObject

            // throw new NotImplementedException("Inserts not yet implemented.");
            var sqlSelectBuilder = new StringBuilder();
            var sqlFromBuilder = new StringBuilder();
            var sqlWhereBuilder = new StringBuilder();

            // var descriptorWhereBuilder = new StringBuilder();

            var sqlInsertColumns = new List<string>();
            var sqlValues = new List<string>();

            var parameters = new Dictionary<string, object>();

            // Descriptor index used for simple descriptor table aliasing
            int descriptorIndex = 1;
            int personTypeIndex = 1;

            var coercionMessages = new List<string>();
            var validationMessages = new List<string>();

            foreach (var parentPrimaryKeyValue in parentPrimaryKeyValues)
            {
                sqlInsertColumns.Add(parentPrimaryKeyValue.Key);

                string parameterName = parentPrimaryKeyValue.Key;
                sqlValues.Add($"@{parameterName}");

                parameters.Add(parameterName, parentPrimaryKeyValue.Value);
                record[parentPrimaryKeyValue.Key] = parentPrimaryKeyValue.Value;
            }

            // Build the columns and VALUES clause for the INSERT
            // Process non-identifying properties
            foreach (var resourceProperty in resourceClass.AllProperties.Where(p => !p.IsResourceIdentifier())

                // Only use properties for the entity being created (in the case of a resource for a derived entity)
                .Where(p => p.EntityProperty.Entity == entity))
            {
                // TODO: API Simplification - Need primary key values for passing to child contexts 

                var entityProperty = resourceProperty.EntityProperty;

                string relativeJsonPath = resourceProperty.JsonPath.TrimPrefix(jsonPathBase);

                // EXECUTION LOGIC
                var proposedValueAsObject =
                    jsonObject.SelectToken(relativeJsonPath)?.Value<JValue>()?.Value; // [property.JsonPropertyName]?.Value<object>();

                // EXECUTION LOGIC
                var coercedValue = CoerceProposedValue(resourceProperty, proposedValueAsObject, coercionMessages);

                // TODO: API Simplification - Validate property expansions properly
                ValidateProperty(entityProperty, coercedValue, resourceProperty.JsonPropertyName, validationMessages);

                // EXECUTION LOGIC
                // If there are any errors, don't do additional work related to the query.
                if (coercionMessages.Any() || validationMessages.Any())
                {
                    continue;
                }

                // Handle property expansions
                if (resourceProperty.IsLookup)
                {
                    // Handle descriptors
                    string columnName = _physicalNamesProvider.Column(entityProperty);
                    sqlInsertColumns.Add(columnName);

                    // EXECUTION LOGIC
                    var proposedDescriptorValue = coercedValue as string;

                    // EXECUTION LOGIC
                    if (proposedDescriptorValue == null)
                    {
                        // TODO: API Simplification - May want to consider using a parameter here rather than literal SQL --> parameters.Add(entityPropertyName, proposedValue);
                        string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);

                        parameters.Add(parameterName, null);
                        record[columnName] = null;
                        
                        sqlInsertColumns.Add(columnName);
                        sqlValues.Add($@"{parameterName}");
                    }
                    else
                    {
                        sqlFromBuilder.Append($", {EdFiConventions.PhysicalSchemaName}.Descriptor d{descriptorIndex}");

                        // sqlInsertColumns.Add(columnName);
                        sqlValues.Add($"d{descriptorIndex}.DescriptorId");

                        sqlWhereBuilder.Append(
                            $" AND (d{descriptorIndex}.Namespace = @d{descriptorIndex}Namespace AND d{descriptorIndex}.CodeValue = @d{descriptorIndex}CodeValue)");

                        // EXECUTION LOGIC
                        int delimiterPos = proposedDescriptorValue?.IndexOf('#') ?? -1;

                        // EXECUTION LOGIC
                        if (delimiterPos < 0 || delimiterPos == proposedDescriptorValue.Length)
                        {
                            throw new Exception("Format of descriptor value is incorrect.");
                        }

                        // EXECUTION LOGIC
                        var descriptorNamespace = proposedDescriptorValue.Substring(0, delimiterPos);
                        var descriptorCodeValue = proposedDescriptorValue.Substring(delimiterPos + 1);

                        // EXECUTION LOGIC
                        parameters.Add($"d{descriptorIndex}Namespace", descriptorNamespace);
                        parameters.Add($"d{descriptorIndex}CodeValue", descriptorCodeValue);

                        // Set the record value
                        string namespaceIdentifier = $"{resourceProperty.PropertyName}_Namespace";
                        string codeValueIdentifier = $"{resourceProperty.PropertyName}_CodeValue";
                        record[namespaceIdentifier] = descriptorNamespace;
                        record[codeValueIdentifier] = descriptorCodeValue;
                        
                        // attemptedDescriptors.Add((resourceProperty.LookupTypeName, descriptorNamespace, descriptorCodeValue));
                        descriptorIndex++;
                    }
                }

                // TODO: API Simplification - Provide a semantic model extension method for determining this easily -- and better
                else if (resourceProperty.PropertyName.EndsWith("UniqueId")
                    && resourceProperty.EntityProperty.PropertyName.EndsWith("USI"))
                {
                    string columnName = _physicalNamesProvider.Column(entityProperty);
                    sqlInsertColumns.Add(columnName);

                    // EXECUTION LOGIC
                    var proposedUniqueIdValue = coercedValue as string;

                    var definingUsiProperty = resourceProperty.EntityProperty.DefiningProperty;
                    var definingUniqueIdProperty = definingUsiProperty.CorrespondingUniqueIdProperty();

                    string tableFullName = _physicalNamesProvider.FullName(definingUsiProperty.Entity);

                    string definingUsiColumn = _physicalNamesProvider.Column(definingUsiProperty);
                    sqlSelectBuilder.Append($"p{personTypeIndex}.{definingUsiColumn}");
                    sqlFromBuilder.Append($", {tableFullName} AS p{personTypeIndex}");

                    string uniqueIdColumnName = _physicalNamesProvider.Column(definingUniqueIdProperty);
                    string uniqueIdParameterName = _physicalNamesProvider.Identifier(resourceProperty.PropertyName);

                    sqlWhereBuilder.Append($" AND p{personTypeIndex}.{uniqueIdColumnName} = @{uniqueIdParameterName}");

                    // EXECUTION LOGIC
                    parameters.Add(uniqueIdParameterName, proposedUniqueIdValue);

                    // Set the record value
                    record[columnName] = proposedUniqueIdValue;
                    
                    personTypeIndex++;
                }
                else
                {
                    string columnName = _physicalNamesProvider.Column(entityProperty);
                    string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);

                    sqlInsertColumns.Add(columnName);
                    sqlValues.Add($"@{parameterName}");

                    parameters.Add(parameterName, coercedValue);

                    // Set the record value
                    record[columnName] = coercedValue;

                    // string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);
                    //
                    // parameters.Add(parameterName, proposedValueAsObject);
                    // sqlColumns.Add(columnName);
                    // sqlValues.Add(parameterName);
                }

                // TODO: API Simplification - May need to deal with property "un" expansions here.
                // parameters.Add(parameterName, jsonData[resourceProperty]?.ToValueAsObject());
            }

            // Invoke custom record-level validations
            ValidateRecord(entity, record, validationMessages);
            
            // If there are any errors, don't do additional work related to the query.
            if (coercionMessages.Any() || validationMessages.Any())
            {
                // TODO: API Simplification - Report this in the method response as validation errors matching existing behavior
                return coercionMessages.Concat(validationMessages).ToList();
            }

            string sql = $"INSERT INTO {_physicalNamesProvider.FullName(entity)} ({string.Join(", ", sqlInsertColumns)})";

            if (sqlWhereBuilder.Length > 0)
            {
                string sqlFrom = sqlFromBuilder.ToString(2, sqlFromBuilder.Length - 2);
                string sqlWhere = sqlWhereBuilder.ToString(4, sqlWhereBuilder.Length - 4);

                sql += $"SELECT {string.Join(", ", sqlValues)} FROM {sqlFrom} WHERE {sqlWhere}";
            }
            else
            {
                sql += $"VALUES ({string.Join(", ", sqlValues)})";
            }

            if (entity.HasServerAssignedIdentity())
            {
                string identityColumnName = _physicalNamesProvider.Column(entity.Identifier.Properties.Single());
                sql += $"SELECT SCOPE_IDENTITY() AS {identityColumnName}";
            }

            // TODO: API Simplification - Need to do some property expansion error reporting
            // For example:
            // (SELECT StaffUSI FROM edfi.Staff WHERE StaffUniqueId = '207283'), 
            // (SELECT DescriptorId as ElectronicMailTypeDescriptorId FROM edfi.Descriptor WHERE Namespace = 'uri://ed-fi.org/ElectronicMailTypeDescriptor' AND CodeValue = 'Worky'),

            // IDictionary<string, object> primaryKeyValues = null;
            
            if (entity.HasServerAssignedIdentity()) // TODO: API Simplification --> entity.Properties.Any(p => p.IsLookup))
            {
                using (var multipleResults = await connection.QueryMultipleAsync(sql, parameters, transaction))
                {
                    int i = 0;

                    while (!multipleResults.IsConsumed)
                    {
                        var result = await multipleResults.ReadAsync();

                        // SurrogateId will be first result set returned, if present
                        if (i == 0 && entity.HasServerAssignedIdentity())
                        {
                            var newIdentity = ((List<object>) result).Cast<IDictionary<string, object>>().Single();
                            primaryKeyValues = newIdentity;
                        }
                        else
                        {
                            // TODO: API Simplification - Deal with diagnosing missing descriptor references and throwing validation 
                        }

                        // results.Add(new ResourceClassQueryResults(resourceClassQueries[i++].ResourceClass, (List<object>) result));
                        i++;
                    }
                }
            }
            else
            {
                // TODO: API Simplification - Need to establish primary key values for current entity
                // Should be parent primary keys + locally established primary key values
                // --> if (parentPrimaryKeyValues != null) --> primaryKeyValues = new Dictionary<string, object>(parentPrimaryKeyValues, StringComparer.OrdinalIgnoreCase);
                // --> Add locally defined column names and values from parameter values extraction (TODO)
                primaryKeyValues = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                await connection.ExecuteAsync(sql, parameters, transaction);
            }

            return new List<string>();
        }

        private class DataPair
        {
            public IDictionary<string, object> Record { get; set; }
            public JObject JsonObject { get; set; }
        }

        private static async Task ProcessDescriptorResolution(
            SqlConnection connection,
            IDbTransaction transaction,
            string sql,
            Dictionary<string, object> parameters,
            List<(string, string, string)> attemptedDescriptors)
        {
            using (var multipleResults = await connection.QueryMultipleAsync(sql, parameters, transaction))
            {
                // Skip the first result
                var readerField = typeof(SqlMapper.GridReader).GetField("reader", BindingFlags.Instance | BindingFlags.NonPublic);
                var reader = (IDataReader) readerField.GetValue(multipleResults);

                if (reader.FieldCount > 0)
                {
                    while (!multipleResults.IsConsumed)
                    {
                        var result = await multipleResults.ReadAsync();

                        var invalidAttemptedDescriptors = attemptedDescriptors.Where(
                                attemptedDescriptor => !result.Any(
                                    locatedDescriptor => attemptedDescriptor.Item2 == locatedDescriptor.Namespace
                                        && attemptedDescriptor.Item3 == locatedDescriptor.CodeValue))
                            .ToArray();

                        if (invalidAttemptedDescriptors.Any())
                        {
                            string propertyName = invalidAttemptedDescriptors.First().Item1;
                            string @namespace = invalidAttemptedDescriptors.First().Item2;
                            string codeValue = invalidAttemptedDescriptors.First().Item3;

                            throw new BadRequestException(
                                $"Unable to resolve value '{@namespace}#{codeValue}' to an existing '{propertyName}' resource.");
                        }
                    }
                }
            }
        }

        private object CoerceProposedValue(ResourceProperty resourceProperty, object proposedValueAsObject, IList<string> coercionFailureMessages)
        {
            // No coercion performed on null values  
            if (proposedValueAsObject == null)
            {
                return null;
            }
            
            // Ensure proposed value is not the default value
            switch (resourceProperty.PropertyType.DbType)
            {
                case DbType.Boolean:
                    return Convert.ToBoolean(proposedValueAsObject);
                
                case DbType.Currency:
                case DbType.Decimal:
                    // TODO: API Simplification - Convert class may be too quietly forgiving of bad data.
                    return Convert.ToDecimal(proposedValueAsObject);
                    
                case DbType.Double:
                    return Convert.ToDouble(proposedValueAsObject);
                
                case DbType.Single:
                    return Convert.ToSingle(proposedValueAsObject);

                case DbType.Int16:
                    return Convert.ToInt16(proposedValueAsObject);

                case DbType.Int32:
                    return Convert.ToInt32(proposedValueAsObject);
                
                case DbType.Int64:
                    return Convert.ToInt64(proposedValueAsObject);

                case DbType.AnsiString:
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                    return Convert.ToString(proposedValueAsObject);

                case DbType.Guid:
                    if (!Guid.TryParse(Convert.ToString(proposedValueAsObject), out var guidValue))
                    {
                        coercionFailureMessages.Add($"Unable to convert value for property '{resourceProperty.JsonPropertyName}' to a {nameof(Guid)}.");
                        return null;
                    }

                    return guidValue;

                case DbType.Byte:
                    return Convert.ToByte(proposedValueAsObject);
                
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                    // TODO: API Simplification - Needs more attention for proper ISO date/time formats here
                    if (!DateTime.TryParse(Convert.ToString(proposedValueAsObject), out var dateTimeValue))
                    {
                        coercionFailureMessages.Add($"Unable to convert value for property '{resourceProperty.JsonPropertyName}' to a {nameof(DateTime)}.");
                        return null;
                    }

                    return dateTimeValue;
            }
            
            throw new NotImplementedException($"Coercion of property with {nameof(DbType)}.{resourceProperty.PropertyType.DbType.ToString()} has not yet been implemented.");
        }

        private void ValidateProperty(
            EntityProperty entityProperty,
            object proposedValueAsObject,
            string jsonPropertyName,
            List<string> validationMessages)
        {
            foreach (var validator in _propertyValidators)
            {
                validator.Validate(entityProperty, proposedValueAsObject, jsonPropertyName, validationMessages);
            }
        }
        
        // Item-level operations
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }
        
        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Put(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete(/*[FromUri]*/ Guid id)
        {
            return Ok(new {hello = "world"});
        }
        
        // TODO: API Simplification - These constants needs to be defined and used only closer to the database operations (where Create vs Update can be determined after initial GetByKey (POST) or GetById (PUT))
        private const string CreateUri = "http://ed-fi.org/odsapi/actions/create"; 
        private const string ReadUri = "http://ed-fi.org/odsapi/actions/read"; 
        private const string UpdateUri = "http://ed-fi.org/odsapi/actions/update"; 
        private const string DeleteUri = "http://ed-fi.org/odsapi/actions/delete"; 
            
        private void SetAuthorizationContext(Resource resource, string actionUri)
        {
            _authorizationContextProvider.SetResourceUris(
                _resourceClaimUriProvider.GetResourceClaimUris(resource));

            _authorizationContextProvider.SetAction(actionUri);
        }
        
        private class IdentifyingPropertyEnumerableComparer : IEqualityComparer<IEnumerable<object>>
        {
            public bool Equals(IEnumerable<object> xValues, IEnumerable<object> yValues)
            {
                if (xValues == null || yValues == null)
                {
                    return false;
                }
                
                using var xEnumerator = xValues.GetEnumerator();
                using var yEnumerator = yValues.GetEnumerator();

                while (xEnumerator.MoveNext() && yEnumerator.MoveNext())
                {
                    var x = xEnumerator.Current;
                    var y = xEnumerator.Current;
                
                    if (ReferenceEquals(x, y))
                    {
                        return true;
                    }

                    if (ReferenceEquals(x, null))
                    {
                        return false;
                    }

                    if (ReferenceEquals(y, null))
                    {
                        return false;
                    }

                    if (x.GetType() != y.GetType())
                    {
                        return false;
                    }

                    if (!x.Equals(y))
                    {
                        return false;
                    }
                }

                return true;
            }

            public int GetHashCode(IEnumerable<object> obj)
            {
                var hashCode = new HashCode();

                foreach (object value in obj)
                {
                    hashCode.Add(value);
                }

                return hashCode.ToHashCode();
            }
        }
    }

    public static class JTokenExtensions
    {
        public static object ToValueAsObject(this JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Boolean:
                    return token.Value<bool>();
                
                case JTokenType.Date:
                    return token.Value<DateTime>();
                
                case JTokenType.Float:
                    return token.Value<Decimal>();
                    
                case JTokenType.Guid:
                    return token.Value<Guid>();

                case JTokenType.Integer:
                    return token.Value<int>();
                    
                case JTokenType.Null:
                    return null;
                
                case JTokenType.String:
                    return token.Value<string>();

                case JTokenType.Uri:
                    return new Uri(token.Value<string>());

                case JTokenType.TimeSpan:
                    return TimeSpan.Parse(token.Value<string>());
                
                default:
                    throw new NotSupportedException($"Conversion of value in token of type '{token.Type.ToString()}' is not supported.");
            }
        }
    }
}
