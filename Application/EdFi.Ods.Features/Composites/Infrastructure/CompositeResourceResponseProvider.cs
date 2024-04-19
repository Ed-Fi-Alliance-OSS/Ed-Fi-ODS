// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Utils.Profiles;
using log4net;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Features.Composites.Infrastructure
{
    public class CompositeResourceResponseProvider : ICompositeResourceResponseProvider
    {
        private readonly ICompositeDefinitionProcessor<HqlBuilderContext, CompositeQuery> _compositeDefinitionProcessor;
        private readonly IFieldsExpressionParser _fieldsExpressionParser;

        private readonly ILog _logger = LogManager.GetLogger(typeof(CompositeResourceResponseProvider));

        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly IPersonUniqueIdResolver _uniqueIdResolver;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly ISessionFactory _sessionFactory;

        public CompositeResourceResponseProvider(
            ISessionFactory sessionFactory,
            ICompositeDefinitionProcessor<HqlBuilderContext, CompositeQuery> compositeDefinitionProcessor,
            IResourceModelProvider resourceModelProvider,
            IFieldsExpressionParser fieldsExpressionParser,
            IProfileResourceModelProvider profileResourceModelProvider,
            IApiClientContextProvider apiClientContextProvider,
            IPersonEntitySpecification personEntitySpecification,
            IPersonUniqueIdResolver uniqueIdResolver)
        {
            _sessionFactory = sessionFactory;
            _compositeDefinitionProcessor = compositeDefinitionProcessor;
            _resourceModelProvider = resourceModelProvider;
            _fieldsExpressionParser = fieldsExpressionParser;
            _profileResourceModelProvider = profileResourceModelProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _personEntitySpecification = personEntitySpecification;
            _uniqueIdResolver = uniqueIdResolver;
        }

        public object Get(
            XElement compositeDefinition,
            IDictionary<string, CompositeSpecificationParameter> parameters,
            IDictionary<string, object> queryStringParameters,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            var resourceModel = GetResourceModel();

            bool closeSession = false;

            CompositeQuery query = null;

            object result = null;

            try
            {
                if (!CurrentSessionContext.HasBind(_sessionFactory))
                {
                    CurrentSessionContext.Bind(_sessionFactory.OpenSession());
                    closeSession = true;
                }

                var fieldSelections = GetFieldSelections(queryStringParameters);

                if (TryBuildCompositeQuery(
                    compositeDefinition,
                    resourceModel,
                    parameters,
                    queryStringParameters,
                    out query))
                {
                    // Initialize the local context variable
                    var uniqueIdLookupsByUsiContext = new UniqueIdLookupsByUsiContext();

                    // Scan for USI values needing resolution
                    CaptureUsiValuesForUniqueIdResolution(query, uniqueIdLookupsByUsiContext);

                    // Resolve all the UniqueIds
                    uniqueIdLookupsByUsiContext.ResolveAllUniqueIds(_uniqueIdResolver)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();

                    // Process the results
                    result = ProcessResults(query, fieldSelections, nullValueHandling, uniqueIdLookupsByUsiContext);

                    // Handle Single item requests
                    if (query.IsSingleItemResult && result == null)
                    {
                        throw new NotFoundException("scenario68.");
                    }
                }
                else
                {
                    // Return an appropriate response for an empty result
                    if (IsSingleItemRequest(compositeDefinition, resourceModel, queryStringParameters))
                    {
                        throw new NotFoundException("scenario69.");
                    }

                    result = new List<IDictionary>();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
            finally
            {
                if (closeSession)
                {
                    _sessionFactory.GetCurrentSession()
                                   .Close();
                }
            }

            return result;
        }

        private bool IsSingleItemRequest(
            XElement compositeDefinition,
            IResourceModel resourceModel,
            IDictionary<string, object> queryStringParameters)
        {
            var currentElt = compositeDefinition.Element("BaseResource");

            if (currentElt == null)
            {
                throw new Exception("Unable to find the main 'Resource' element of the composite definition.");
            }

            string logicalSchema = currentElt.Attributes()
                                             .SingleOrDefault(x => x.Name.ToString().EqualsIgnoreCase(CompositeDefinitionHelper.LogicalSchema))
                                            ?.Value ?? EdFiConventions.LogicalName;

            var physicalName = resourceModel.GetPhysicalNameForLogicalName(logicalSchema);

            var currentModel = resourceModel.GetResourceByFullName(new FullName(physicalName, currentElt.AttributeValue(CompositeDefinitionHelper.Name)));

            return currentModel.IsSingleItemRequest(queryStringParameters.ToList());
        }

        private IResourceModel GetResourceModel()
        {
            // Determine caller's assigned profiles
            var assignedProfileNames = _apiClientContextProvider.GetApiClientContext().Profiles;

            if (assignedProfileNames.Any())
            {
                // Get all the Profile-specific versions of the Resource Model (which also separates models for read/write content types)
                var profileResourceModels = assignedProfileNames
                    .Select(_profileResourceModelProvider.GetProfileResourceModel)
                    .ToArray();

                // Get to an IResourceModel that applies all currently assigned filters
                return new ProfilesAppliedResourceModel(
                    ContentTypeUsage.Readable,
                    profileResourceModels);
            }

            return _resourceModelProvider.GetResourceModel();
        }

        private bool TryBuildCompositeQuery(
            XElement compositeDefinition,
            IResourceModel resourceModel,
            IDictionary<string, CompositeSpecificationParameter> filterCriteria,
            IDictionary<string, object> queryStringParameters,
            out CompositeQuery compositeQuery)
        {
            compositeQuery = null;

            var aliasGenerator = new AliasGenerator(CompositeDefinitionHelper.AliasPrefix);

            var builderContext = new HqlBuilderContext(
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new StringBuilder(),
                new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
                null,
                1,
                filterCriteria,
                queryStringParameters,
                new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase),
                aliasGenerator);

            compositeQuery = _compositeDefinitionProcessor.Process(compositeDefinition, resourceModel, builderContext);

            return compositeQuery != null;
        }

        private IReadOnlyList<SelectedResourceMember> GetFieldSelections(IDictionary<string, object> queryStringParameters)
        {
            if (queryStringParameters.TryGetValue(CompositeDefinitionHelper.Fields, out object fieldsObject))
            {
                var fieldsExpression = fieldsObject.ToString();
                queryStringParameters.Remove(CompositeDefinitionHelper.Fields);

                return _fieldsExpressionParser.ParseFields(fieldsExpression);
            }

            return null;
        }

        public object ProcessResults(CompositeQuery query, IReadOnlyList<SelectedResourceMember> fieldSelections, NullValueHandling nullValueHandling, UniqueIdLookupsByUsiContext uniqueIdLookupsByUsiContext)
        {
            return ProcessResults(query, null, null, fieldSelections, nullValueHandling, uniqueIdLookupsByUsiContext)
               .ApplyCardinality(query.IsSingleItemResult);
        }

        private void CaptureUsiValuesForUniqueIdResolution(
            CompositeQuery query,
            UniqueIdLookupsByUsiContext uniqueIdLookupsByUsiContext)
        {
            try
            {
                var currentEnumerator = query.GetEnumerator(null);

                (string usiKey, string personType)[] usiKeys = null;

                do
                {
                    // Nothing to enumerate?
                    if (currentEnumerator == null || currentEnumerator.IsComplete)
                    {
                        return;
                    }

                    // Get current row
                    var currentRow = (Hashtable)currentEnumerator.Current;

                    if (currentRow == null)
                    {
                        break;
                    }

                    // Find USI columns for current level's records, if not already
                    usiKeys ??= GetUsiKeys().ToArray();

                    // Add UniqueId lookups for each of the USIs found
                    foreach (var usiKey in usiKeys)
                    {
                        if (currentRow[usiKey.usiKey] is int usi)
                        {
                            uniqueIdLookupsByUsiContext.AddLookup(usiKey.personType, usi);
                        }
                    }

                    // Recursively process child query results
                    foreach (var childQuery in query.ChildQueries)
                    {
                        CaptureUsiValuesForUniqueIdResolution(childQuery, uniqueIdLookupsByUsiContext);
                    }

                    IEnumerable<(string usiKey, string personType)> GetUsiKeys()
                    {
                        var keys = query.DataFields
                            .Where(k => UniqueIdConventions.IsUSI(k));

                        foreach (string key in keys)
                        {
                            if (_personEntitySpecification.TryGetUSIPersonType(
                                    key,
                                    out string personType))
                            {
                                yield return (key, personType);
                            }
                        }
                    }
                }
                while (currentEnumerator.MoveNext());
            }
            finally
            {
                query.ResetEnumerator();
            }
        }

        public IList<IDictionary> ProcessResults(
            CompositeQuery query,
            Hashtable parentRow,
            string[] parentKeys,
            IReadOnlyList<SelectedResourceMember> fieldSelections,
            NullValueHandling nullValueHandling,
            UniqueIdLookupsByUsiContext uniqueIdLookupsByUsiContext)
        {
            var results = new List<IDictionary>();

            var currentEnumerator = query.GetEnumerator(parentRow);

            do
            {
                // Nothing to enumerate?
                if (currentEnumerator == null || currentEnumerator.IsComplete)
                {
                    return results;
                }

                // Get current row
                var currentRow = (Hashtable)currentEnumerator.Current;

                if (currentRow == null)
                {
                    break;
                }

                // If the child is outside the context of the parent, quit processing
                if (parentRow != null && !IsChildRow(parentKeys, parentRow, currentRow))
                {
                    break;
                }

                // Convert the row to serializable form
                var resultItem = GetItem(currentRow, query.DataFields, query.OrderedFieldNamesWithTypes, fieldSelections, nullValueHandling, uniqueIdLookupsByUsiContext);

                // Process the children
                foreach (var childQuery in query.ChildQueries)
                {
                    SelectedResourceMember selectedMember = null;

                    string childCollectionName = childQuery.DisplayName;

                    // Check to see if this collection should be included
                    if (fieldSelections != null && fieldSelections.Count > 0)
                    {
                        selectedMember = fieldSelections.FirstOrDefault(x => x.Equals(childCollectionName) || x.Equals("*"));

                        if (selectedMember == null)
                        {
                            continue;
                        }
                    }

                    resultItem[childCollectionName] =
                        ProcessResults(
                                childQuery,
                                currentRow,
                                query.KeyFields,
                                selectedMember == null
                                    ? null
                                    : selectedMember.Children,
                                nullValueHandling,
                                uniqueIdLookupsByUsiContext)
                           .ApplyCardinality(childQuery.IsSingleItemResult);
                }

                results.Add(resultItem);
            }
            while (currentEnumerator.MoveNext());

            return results;
        }

        private IDictionary GetItem(
            Hashtable sourceRow,
            string[] keys,
            IDictionary<string, PropertyType> orderedFieldNamesWithTypes,
            IReadOnlyList<SelectedResourceMember> fieldSelections,
            NullValueHandling nullValueHandling,
            UniqueIdLookupsByUsiContext uniqueIdLookupsByUsiContext)
        {
            var item = new OrderedDictionary();

            if (!keys.Any())
            {
                return item;
            }

            var descriptorNamespaceByKey = keys
                                          .Where(x => x.EndsWith(CompositeDefinitionHelper.NamespaceMarker))
                                          .ToDictionary(
                                               x => x.Substring(0, x.IndexOf(CompositeDefinitionHelper.Marker)),
                                               x => sourceRow[x]);

            HashSet<string> selectedKeys = null;

            if (fieldSelections != null && fieldSelections.Count > 0)
            {
                selectedKeys = new HashSet<string>(fieldSelections.Select(x => x.MemberName));

                if (selectedKeys.Contains("*"))
                {
                    selectedKeys = null;
                }
            }

            var keysToProcess = keys.Where(x => !x.StartsWith(CompositeDefinitionHelper.Marker)
                                                && !x.EndsWith(CompositeDefinitionHelper.NamespaceMarker));

            // Retain order of properties
            // since pass through items are not in the resource and/or domain model, we need to add them as part of the return fields.
            // order fields are exclusively from the model, so we need to add the pass through items to end.
            var keyValuePairs = orderedFieldNamesWithTypes.Keys
                               .Concat(keys.Where(x => x.EndsWith(CompositeDefinitionHelper.PassThroughMarker))
                                           .Select(x => x.TrimSuffix(CompositeDefinitionHelper.PassThroughMarker)))
                               .Join(
                                    EnumerateKeyValuePairs(sourceRow, nullValueHandling, keysToProcess, descriptorNamespaceByKey, selectedKeys, uniqueIdLookupsByUsiContext, orderedFieldNamesWithTypes),
                                    x => x,
                                    x => x.Key,
                                    (prop, kvp) => kvp,
                                    StringComparer.InvariantCultureIgnoreCase);

            // Set the values to the ordered dictionary
            foreach (var kvp in keyValuePairs)
            {
                item[kvp.Key] = kvp.Value;
            }

            return item;
        }

        private IEnumerable<KeyValuePair<string, object>> EnumerateKeyValuePairs(
            Hashtable sourceRow,
            NullValueHandling nullValueHandling,
            IEnumerable<string> keysToProcess,
            Dictionary<string, object> descriptorNamespaceByKey,
            HashSet<string> selectedKeys,
            UniqueIdLookupsByUsiContext uniqueIdLookupsByUsiContext,
            IDictionary<string, PropertyType> orderedFieldNamesWithTypes)
        {
            foreach (string key in keysToProcess)
            {
                string renamedKey = null;

                // Handle Pass through values
                if (key.EndsWith(CompositeDefinitionHelper.PassThroughMarker))
                {
                    renamedKey = key.TrimSuffix(CompositeDefinitionHelper.PassThroughMarker);
                    yield return new KeyValuePair<string, object>(renamedKey ?? key, sourceRow[key]);
                }
                else
                {
                    // Remove null values, if appropriate
                    object value;

                    if (sourceRow[key] == null)
                    {
                        if (nullValueHandling == NullValueHandling.Include)
                        {
                            value = sourceRow[key];
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (descriptorNamespaceByKey.TryGetValue(key, out object namespaceForDescriptor))
                        {
                            value =
                                DescriptorHelper.GetUri(
                                    namespaceForDescriptor.ToString(),
                                    sourceRow[key]
                                       .ToString());
                        }
                        else
                        {
                            // See if we need to convert an USI to a UniqueId
                            if (UniqueIdConventions.IsUSI(key)
                                && _personEntitySpecification.TryGetUSIPersonTypeAndRoleName(key, out string personType, out string roleName))
                            {
                                // Resolve the UniqueId from the USI
                                if (!uniqueIdLookupsByUsiContext.UniqueIdByUsiByPersonType.TryGetValue(personType, out var map)
                                        || !map.TryGetValue((int)sourceRow[key], out string uniqueId))
                                {
                                    // This should never happen
                                    throw new Exception($"Unable to resolve {personType}USI '{(int)sourceRow[key]}' to a UniqueId value.");
                                }

                                string uniqueIdKey = (roleName + personType + CompositeDefinitionHelper.UniqueId).ToCamelCase();

                                renamedKey = uniqueIdKey;
                                value = uniqueId;
                            }
                            else if (orderedFieldNamesWithTypes.ContainsKey(key) &&
                                     new[] { DbType.Date, DbType.Guid }.Contains(orderedFieldNamesWithTypes[key].DbType))
                            {
                                value = orderedFieldNamesWithTypes[key].DbType switch
                                {
                                    DbType.Guid => ((Guid)sourceRow[key]).ToString("N"),
                                    DbType.Date => ((DateTime)sourceRow[key]).ToString("yyyy-MM-dd"),
                                    _ => sourceRow[key]
                                };
                            }
                            else
                            {
                                value = sourceRow[key];
                            }
                        }
                    }

                    // Don't add unselected properties
                    if (selectedKeys == null || selectedKeys.Contains(renamedKey ?? key))
                    {
                        yield return new KeyValuePair<string, object>(renamedKey ?? key, value);
                    }
                }
            }
        }

        private bool IsChildRow(string[] parentKeys, Hashtable parentRow, Hashtable currentRow)
        {
            // Match values based on name.
            return parentKeys.All(k => Equals(parentRow[k], currentRow[k]));
        }
    }
}