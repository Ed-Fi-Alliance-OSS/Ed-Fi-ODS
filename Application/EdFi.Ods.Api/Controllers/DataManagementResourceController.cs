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
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
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
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IResourceClaimUriProvider _resourceClaimUriProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(DataManagementResourceController));
        
        public DataManagementResourceController(
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IRequestResourceResolver requestResourceResolver,
            IResourceDataProvider resourceDataProvider,
            // Authorization-related
            IAuthorizationContextProvider authorizationContextProvider,
            IResourceClaimUriProvider resourceClaimUriProvider)
        {
            _connectionStringProvider = odsDatabaseConnectionStringProvider;
            _requestResourceResolver = requestResourceResolver;
            _resourceDataProvider = resourceDataProvider;
            _authorizationContextProvider = authorizationContextProvider;
            _resourceClaimUriProvider = resourceClaimUriProvider;
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

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] JObject jsonData)
        {
            var (resource, error) = _requestResourceResolver.GetResourceForRequest(Request);

            if (resource == null)
            {
                return StatusCode(error.Code, new { error.Message });
            }

            // Get the primary key of the resource
            var primaryKeyValues = resource.AllIdentifyingProperties
                .ToDictionary(
                    rp => rp.PropertyName, 
                    rp => (object) jsonData[rp.JsonPropertyName].Value<JValue>().Value);
            
            var resourceData = await _resourceDataProvider.GetResourceData(resource, Request.Query, primaryKeyValues);

            var dataByFullName = resourceData.Results.ToDictionary(
                x => x.ResourceClass.FullName,
                x => (List<object>) x.Results);

            // Process root resource class
            var odsData = dataByFullName[resource.FullName];
            
            // Process identifying properties
            IDictionary<string,object> odsRow = (IDictionary<string,object>) odsData[0];

            if (resource.IsDerived)
            {
                await Update(resource, resource.Entity.BaseEntity, jsonData);
            }

            await Update(resource, resource.Entity, jsonData);

            async Task Update(ResourceClassBase resourceClass, Entity entity, JObject sourceData)
            {
                var sqlSetBuilder = new StringBuilder();
                var sqlFromBuilder = new StringBuilder();
                var sqlWhereBuilder = new StringBuilder();
                
                var descriptorWhereBuilder = new StringBuilder();
                
                var parameters = new Dictionary<string, object>();

                foreach (var identifyingProperty in resourceClass.AllIdentifyingProperties)
                {
                    string entityPropertyName = identifyingProperty.EntityProperty.PropertyName;
                    parameters.Add(entityPropertyName, odsRow[entityPropertyName]);
                    sqlWhereBuilder.Append($"AND {entityPropertyName} = @{entityPropertyName}");
                }

                string jsonPathBase = resourceClass.JsonPath + ".";

                int descriptorIndex = 1;
                var attemptedDescriptors = new List<ValueTuple<string, string, string>>();
                
                // Process non-identifying properties
                foreach (var property in resourceClass.NonIdentifyingProperties
                        .Where(p => p.PropertyName != "Id")
                        .Where(p => p.EntityProperty.Entity == entity))
                {
                    string entityPropertyName = property.EntityProperty.PropertyName;

                    string relativeJsonPath = property.JsonPath.TrimPrefix(jsonPathBase);
                    
                    // var existingValue = odsRow[entityPropertyName];
                    var proposedValue = jsonData.SelectToken(relativeJsonPath)?.Value<JValue>()?.Value; // [property.JsonPropertyName]?.Value<object>();

                    // var proposedValue = Convert.ChangeType(proposedValueAsObject, TypeCode.Int32); // property.PropertyType.GetTypeCode())

                    if (property.EntityProperty.IsLookup)
                    {
                        if (proposedValue == null)
                        {
                            //parameters.Add(entityPropertyName, proposedValue);
                            sqlSetBuilder.Append($", {entityPropertyName} = NULL");
                        }
                        else
                        {
                            sqlFromBuilder.Append($", edfi.Descriptor d{descriptorIndex}");
                            
                            var descriptorParts = (proposedValue as string)?.Split('#');

                            sqlSetBuilder.Append($", {entityPropertyName} = COALESCE(d{descriptorIndex}.DescriptorId, 0)");

                            sqlWhereBuilder.Append(
                                $" AND (d{descriptorIndex}.Namespace = @d{descriptorIndex}Namespace AND d{descriptorIndex}.CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            parameters.Add($"d{descriptorIndex}Namespace", descriptorParts[0]);
                            parameters.Add($"d{descriptorIndex}CodeValue", descriptorParts[1]);

                            descriptorWhereBuilder.Append(
                                $" OR (Namespace = @d{descriptorIndex}Namespace AND CodeValue = @d{descriptorIndex}CodeValue)");
                            
                            attemptedDescriptors.Add((property.LookupTypeName, descriptorParts[0], descriptorParts[1]));

                            descriptorIndex++;
                        }
                    }
                    else // if (!proposedValue.Equals(existingValue))
                    {
                        parameters.Add(entityPropertyName, proposedValue);
                        sqlSetBuilder.Append($", {entityPropertyName} = @{entityPropertyName}");
                    }
                }

                using (var conn = new SqlConnection(_connectionStringProvider.GetConnectionString()))
                {
                    await conn.OpenAsync();

                    string from = sqlFromBuilder.Length > 0
                        ? $"FROM {resourceClass.FullName.Schema}.{resourceClass.FullName.Name}{sqlFromBuilder.ToString()}"
                        : null;

                    string descriptorDiagnostics = descriptorWhereBuilder.Length > 0
                        ? $@" IF @@rowcount = 0
                    SELECT   DescriptorId, Namespace, CodeValue
                    FROM     edfi.Descriptor 
                    WHERE {descriptorWhereBuilder.ToString(3, descriptorWhereBuilder.Length - 3)}"
                        : null;
                    
                    string sql = $@"
    UPDATE {entity.FullName.Schema}.{entity.FullName.Name}
    SET {sqlSetBuilder.ToString(2, sqlSetBuilder.Length - 2)}
    {@from}
    WHERE {sqlWhereBuilder.ToString(4, sqlWhereBuilder.Length - 4)}
    {descriptorDiagnostics}";

                    if (descriptorDiagnostics.Length > 0)
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
        
        // TODO: Simple API - This needs to be somewhere else (where Create vs Update can be determined after initial GetByKey (POST) or GetById (PUT))
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
