// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
        
        public DataManagementResourceController(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IRequestResourceResolver requestResourceResolver,
            IResourceDataProvider resourceDataProvider,
            IPhysicalNamesProvider physicalNamesProvider,
            // GET Authorization-related
            IAuthorizationContextProvider authorizationContextProvider,
            IResourceClaimUriProvider resourceClaimUriProvider,
            // Validation related
            IEntityPropertyValidator[] propertyValidators)
        {
            _connectionStringProvider = odsDatabaseConnectionStringProvider;
            _requestResourceResolver = requestResourceResolver;
            _resourceDataProvider = resourceDataProvider;
            _physicalNamesProvider = physicalNamesProvider;
            _authorizationContextProvider = authorizationContextProvider;
            _resourceClaimUriProvider = resourceClaimUriProvider;
            _propertyValidators = propertyValidators;
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

            // TODO: Simple API - This *may* be better refactored out into a separate component, or possibly passed along as a parameter rather than using context here 
            SetAuthorizationContext(resource, ReadUri);

            var resourceData = await _resourceDataProvider.GetResourceData(resource, Request.Query);

            return new ContentResult
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = resourceData.ToJson(),
            };
        }

        // TODO: Simple API - Consider introducing the following class and passing it down through the call chain in favor of the context pattern.
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

            // TODO: Simple API - This *may* be better refactored out into a separate component, or possibly passed along the call chain as a DataManagementRequestContext parameter rather than using context here 
            SetAuthorizationContext(resource, UpdateUri);

            // Get the primary key of the resource
            var primaryKeyValues = resource.AllIdentifyingProperties
                .ToDictionary(
                    rp => rp.PropertyName, 
                    rp => (object) jsonData[rp.JsonPropertyName]?.Value<JValue>().Value);
            
            // Get the ODS data for the entire resource
            var resourceData = await _resourceDataProvider.GetResourceData(resource, Request.Query, primaryKeyValues);

            // Group the data by resource class name
            var dataByResourceName = resourceData.Results
                .ToDictionary(
                x => x.ResourceClass.FullName,
                x => (List<object>) x.Results);

            // Process root resource class
            var resourceRootData = dataByResourceName[resource.FullName];
            
            // Process identifying properties
            IDictionary<string,object> resourceRootRecord = (IDictionary<string,object>) resourceRootData[0];

            // If resource is derived, create/update the base entity first.
            if (resource.IsDerived)
            {
                await Update(resource, resource.Entity.BaseEntity, jsonData);
            }

            // Update the table for the resource root
            await Update(resource, resource.Entity, jsonData);

            async Task Update(ResourceClassBase resourceClass, Entity entity, JObject jsonData)
            {
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
                    
                    parameters.Add(parameterName, resourceRootRecord[columnName]);
                    sqlWhereBuilder.Append($"AND {columnName} = @{parameterName}");
                }

                string jsonPathBase = resourceClass.JsonPath + ".";

                // Descriptor index used for simple descriptor table aliasing
                int descriptorIndex = 1;
                
                var attemptedDescriptors = new List<ValueTuple<string, string, string>>();
                
                var coercionMessages = new List<string>();
                var validationMessages = new List<string>();

                // Process non-identifying properties
                foreach (var resourceProperty in resourceClass.NonIdentifyingProperties
                        .Where(p => !p.IsResourceIdentifier())
                        .Where(p => p.EntityProperty.Entity == entity))
                {
                    var entityProperty = resourceProperty.EntityProperty;

                    string relativeJsonPath = resourceProperty.JsonPath.TrimPrefix(jsonPathBase);
                    
                    var proposedValueAsObject = jsonData.SelectToken(relativeJsonPath)?.Value<JValue>()?.Value; // [property.JsonPropertyName]?.Value<object>();

                    var coercedValue = CoerceProposedValue(resourceProperty, proposedValueAsObject, coercionMessages); 
                    ValidateProperty(entityProperty, coercedValue, resourceProperty.JsonPropertyName, validationMessages);

                    // If there are any errors, don't do additional work related to the query.
                    if (coercionMessages.Any() || validationMessages.Any())
                        continue;
                    
                    // Handle descriptor updates
                    if (entityProperty.IsLookup)
                    {
                        var proposedDescriptorValue = proposedValueAsObject as string;

                        if (proposedDescriptorValue == null)
                        {
                            // TODO: Simple API - May want to consider using a parameter here rather than literal SQL --> parameters.Add(entityPropertyName, proposedValue);
                            sqlSetBuilder.Append($", {_physicalNamesProvider.Column(entityProperty)} = NULL");
                        }
                        else
                        {
                            sqlFromBuilder.Append($", {EdFiConventions.PhysicalSchemaName}.Descriptor d{descriptorIndex}");
                            
                            int delimiterPos = proposedDescriptorValue?.IndexOf('#') ?? -1;

                            if (delimiterPos < 0 || delimiterPos == proposedDescriptorValue.Length)
                            {
                                throw new Exception("Format of descriptor value is incorrect.");
                            }
                            
                            var descriptorNamespace = proposedDescriptorValue.Substring(0, delimiterPos);
                            var descriptorCodeValue = proposedDescriptorValue.Substring(delimiterPos + 1);

                            // TODO: Simple API - This implementation is SQL Server specific (needs a seam)
                            sqlSetBuilder.Append($", {_physicalNamesProvider.Column(entityProperty)} = COALESCE(d{descriptorIndex}.DescriptorId, 0)");

                            sqlWhereBuilder.Append(
                                $" AND (d{descriptorIndex}.Namespace = @d{descriptorIndex}Namespace AND d{descriptorIndex}.CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            parameters.Add($"d{descriptorIndex}Namespace", descriptorNamespace);
                            parameters.Add($"d{descriptorIndex}CodeValue", descriptorCodeValue);

                            descriptorWhereBuilder.Append(
                                $" OR (Namespace = @d{descriptorIndex}Namespace AND CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            attemptedDescriptors.Add((resourceProperty.LookupTypeName, descriptorNamespace, descriptorCodeValue));

                            descriptorIndex++;
                        }
                    }
                    else // TODO: Simple API - Consider "dirty" checking and only updating modified columns --> if (!proposedValue.Equals(existingValue))
                    {
                        string parameterName = _physicalNamesProvider.Identifier(entityProperty.PropertyName);
                        
                        parameters.Add(parameterName, proposedValueAsObject);
                        sqlSetBuilder.Append($", {_physicalNamesProvider.Column(entityProperty)} = @{parameterName}");
                    }
                }

                // If there are any errors, don't do additional work related to the query.
                if (coercionMessages.Any() || validationMessages.Any())
                {
                    string validationMessage =
                        $"Validation failed:\n{string.Join("\\n", coercionMessages.Concat(validationMessages))}";
                        
                    // TODO: Simple API - Report this in the response.
                    throw new Exception(validationMessage);
                }
                
                // TODO: Simple API - Obtain database-specific connection
                using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
                {
                    await conn.OpenAsync();

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
    {from}
    WHERE {sqlWhereBuilder.ToString(4, sqlWhereBuilder.Length - 4)}
    {descriptorDiagnostics}";

                    if (descriptorDiagnostics?.Length > 0)
                    {
                        using (var multipleResults = await conn.QueryMultipleAsync(sql, parameters))
                        {
                            // Skip the first result
                            var readerField = typeof(SqlMapper.GridReader).GetField("reader", BindingFlags.Instance | BindingFlags.NonPublic);
                            var reader = (IDataReader) readerField.GetValue(multipleResults);

                            if (reader.FieldCount > 0)
                            {
                                while (!multipleResults.IsConsumed)
                                {
                                    var result = await multipleResults.ReadAsync();

                                    var invalidAttemptedDescriptors = attemptedDescriptors
                                        .Where(
                                            attemptedDescriptor => !result.Any(
                                                locatedDescriptor => attemptedDescriptor.Item2 == locatedDescriptor.Namespace
                                                    && attemptedDescriptor.Item3 == locatedDescriptor.CodeValue))
                                        .ToArray();
                                
                                    if (invalidAttemptedDescriptors.Any())
                                    {
                                        string propertyName = invalidAttemptedDescriptors.First().Item1;
                                        string @namespace = invalidAttemptedDescriptors.First().Item2;
                                        string codeValue = invalidAttemptedDescriptors.First().Item3;
                                    
                                        throw new BadRequestException($"Unable to resolve value '{@namespace}#{codeValue}' to an existing '{propertyName}' resource.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        await conn.ExecuteAsync(sql, parameters);
                    }
                }
            }

            return Ok();
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
                    // TODO: Simple API - Convert class may be too quietly forgiving of bad data.
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
                    // TODO: Simple API - Needs more attention for proper ISO date/time formats here
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
        
        // TODO: Simple API - These constants needs to be defined and used only closer to the database operations (where Create vs Update can be determined after initial GetByKey (POST) or GetById (PUT))
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
    }
}
