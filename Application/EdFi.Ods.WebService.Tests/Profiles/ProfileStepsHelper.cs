// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Helpers;
using Castle.Windsor;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramAggregate.EdFi;
using EdFi.Ods.Standard;
using EdFi.Ods.WebService.Tests.Extensions;
using KellermanSoftware.CompareNetObjects;
using log4net;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class ProfileStepsHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod()
                      .DeclaringType);
        private readonly FeatureContext _currentFeatureContext;
        private readonly ScenarioContext _currentScenarioContext;

        public ProfileStepsHelper(FeatureContext currentFeatureContext, ScenarioContext currentScenarioContext)
        {
            _currentFeatureContext = currentFeatureContext;
            _currentScenarioContext = currentScenarioContext;
        }

        public HttpContent GetPostContent<TEntity, TResource>(string contentType)
            where TEntity : IHasIdentifier, IDateVersionedEntity, new()
            where TResource : new()
        {
            // Get the "GetById" repository operation
            var getEntityById = _currentFeatureContext.Container()
                                                      .Resolve<IGetEntityById<TEntity>>();

            // Retrieve an "existing" entity
            var entityForUpdate = getEntityById.GetByIdAsync(Guid.NewGuid(), CancellationToken.None).GetResultSafely();

            // Map the "updated" entity to a full School resource
            var mapperMethod = GetMapperMethod<TEntity>();
            dynamic fullResourceForUpdate = new TResource();

            mapperMethod.Invoke(
                null,
                new object[]
                {
                    entityForUpdate, fullResourceForUpdate, null
                });

            //empty the id for the Post operation
            fullResourceForUpdate.Id = Guid.Empty;

            //build post content
            return new StringContent(JsonConvert.SerializeObject(fullResourceForUpdate), Encoding.UTF8, contentType);
        }

        public MethodInfo GetMapperMethod<TEntity>()
        {
            string entityName = typeof(TEntity).Name;

            string mapperTypeName = string.Format(
                "{0}.{1}Mapper",
                EdFiConventions.BuildNamespace(Namespaces.Entities.Common.BaseNamespace, EdFiConventions.ProperCaseName),
                entityName);

            // TODO: Embedded convention - Mapper type namespace
            var mapperType = Type.GetType(
                mapperTypeName + ", " + typeof(Marker_EdFi_Ods_Standard).Assembly.GetName()
                                                                        .Name);

            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var mapperMethod = mapperType.GetMethod("MapTo", bindingFlags);

            if (mapperMethod == null)
            {
                mapperMethod = mapperType.GetMethod("MapDerivedTo", bindingFlags);

                if (mapperMethod == null)
                {
                    throw new Exception($"Unable to find MapTo or MapDerivedTo method on type '{mapperType.FullName}'.");
                }
            }

            return mapperMethod;
        }

        /// <summary>
        /// Gets a list of all the paths of public properties in the entire object graph for the specified entity type, filtered to remove paths that
        /// are not relevant for entity comparison.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to be inspected.</typeparam>
        /// <returns></returns>
        public List<string> GetEntityPropertyPaths<TEntity>()
            where TEntity : IHasIdentifier, IDateVersionedEntity
        {
            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var getEntityById = container.Resolve<IGetEntityById<TEntity>>();

            // Create two completely different entities (to enable us to use the 
            // DataComparer to create a list of all the properties for us)
            var entity1 = getEntityById.GetByIdAsync(Guid.NewGuid(), CancellationToken.None).GetResultSafely();
            var entity2 = getEntityById.GetByIdAsync(Guid.NewGuid(), CancellationToken.None).GetResultSafely();

            var entityPropertyPaths = new List<string>();

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                     ShowBreadcrumb = true, MaxDifferences = int.MaxValue, DifferenceCallback = d =>
                    {
                        if (d.IsRelevantForEntityComparison())
                        {
                            entityPropertyPaths.Add(
                                RemoveArrayIndexers(d.PropertyName));
                        }
                    }
                });

            comparer.Compare(entity1, entity2);

            return entityPropertyPaths.Select(p => p.TrimStart('.'))
                                      .OrderBy(x => x)
                                      .ToList();
        }

        public string RemoveArrayIndexers(string propertyPath)
        {
            // Strip child collection indexers (e.g. "[5]") from the breadcrumb
            return Regex.Replace(propertyPath, @"(\[[0-9]+\])", string.Empty);
        }

        public IEnumerable<string> WriteContentTypeProperties(Resource resource)
        {
            return (resource.WriteContentType.Collection ?? new ClassDefinition[0])
                  .Select(x => x.name)
                  .Concat(
                       (resource.WriteContentType.Property ?? new PropertyDefinition[0])
                      .Select(x => x.name));
        }

        public ContentMetaData GetResourceMemberData(Resource resource, ContentTypeUsage contentTypeUsage)
        {
            var contentMetaData = new ContentMetaData();

            switch (contentTypeUsage)
            {
                case ContentTypeUsage.Readable:

                    if (resource.ReadContentType.Property != null)
                    {
                        contentMetaData.MemberCount += resource.ReadContentType.Property.Count();

                        contentMetaData.Members.AddRange(
                            resource.ReadContentType.Property.Select(property => property.name));
                    }

                    if (resource.ReadContentType.Object != null)
                    {
                        UpdateContentMetaData(resource.ReadContentType.Object, contentMetaData);
                    }

                    if (resource.ReadContentType.Collection != null)
                    {
                        UpdateContentMetaData(resource.ReadContentType.Collection, contentMetaData);
                    }

                    break;
                case ContentTypeUsage.Writable:

                    if (resource.WriteContentType.Property != null)
                    {
                        contentMetaData.MemberCount += resource.WriteContentType.Property.Count();

                        contentMetaData.Members.AddRange(
                            resource.WriteContentType.Property.Select(property => property.name));
                    }

                    if (resource.WriteContentType.Object != null)
                    {
                        UpdateContentMetaData(resource.WriteContentType.Object, contentMetaData);
                    }

                    if (resource.WriteContentType.Collection != null)
                    {
                        UpdateContentMetaData(resource.WriteContentType.Collection, contentMetaData);
                    }

                    break;
            }

            return contentMetaData;
        }

        private static void UpdateContentMetaData(ClassDefinition[] collections, ContentMetaData contentMetaData)
        {
            if (collections == null)
            {
                return;
            }

            foreach (ClassDefinition collection in collections)
            {
                contentMetaData.MemberCount++;
                contentMetaData.Members.Add(collection.name);

                if (collection.Property != null)
                {
                    contentMetaData.MemberCount += collection.Property.Count();
                    contentMetaData.Members.AddRange(collection.Property.Select(property => property.name));
                }

                if (collection.Collection != null && collection.Collection.Any())
                {
                    UpdateContentMetaData(collection.Collection, contentMetaData);
                }
            }
        }

        public List<string> ParseNamesFromCsvText(string csvText)
        {
            return
                csvText.Split(
                            new[]
                            {
                                ','
                            },
                            StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => x.Trim())
                       .ToList();
        }

        public bool IsETag(string propertyName)
        {
            return propertyName.EqualsIgnoreCase("ETag")
                   || propertyName.EqualsIgnoreCase("_etag");
        }

        public bool IsExtension(string propertyName)
        {
            return propertyName.EqualsIgnoreCase("Extension")
                   || propertyName.EqualsIgnoreCase("_ext");
        }

        public List<string> GetPropertyNames(dynamic data)
        {
            if (data == null)
            {
                return new List<string>();
            }

            var propertyNames = ((Dictionary<string, object>.KeyCollection) data.GetDynamicMemberNames())

                                // Don't ever include boilerplate properties in the count
                               .Where(p => !IsETag(p) && !IsExtension(p) && !p.EndsWithIgnoreCase("CreatedByOwnershipTokenId"))
                               .OrderBy(x => x)
                               .ToList();

            return propertyNames;
        }

        public dynamic GetDataFromResponse()
        {
            // Check for, and use the data already in the scenario context
            if (ScenarioContext.Current.ContainsKey(ScenarioContextKeys.Data))
            {
                return ScenarioContext.Current.Get<dynamic>(ScenarioContextKeys.Data);
            }

            string content = GetContentFromResponse();
            dynamic data = Json.Decode(content);

            // Save it to the context
            ScenarioContext.Current.Set<dynamic>(data, ScenarioContextKeys.Data);

            // Log debug details containing the properties found on the data object
            if (_logger.IsDebugEnabled)
            {
                var propertyNames = GetPropertyNames(data);
                _logger.DebugFormat("Properties found on resource: {0}", string.Join(", ", propertyNames));
            }

            return data;
        }

        public string GetContentFromResponse()
        {
            // Deserialize the dynamic data object from the JSON response content
            var httpContent = ScenarioContext.Current.Get<HttpResponseMessage>()
                                             .Content;

            string content = httpContent.ReadAsStringAsync()
                                        .Sync();

            return content;
        }

        public ContentType GetReadContentType(string resourceTypeName)
        {
            var profile = ScenarioContext.Current.Get<Profile>();

            var contentType = profile.Resource.Single(x => x.name == resourceTypeName)
                                     .ReadContentType;

            return contentType;
        }

        // Note: The School doesn't have any references that are composite keys. If this method is repurposed
        // for such a scenario, an array of strings would be more appropriate as the conversion from a resource's
        // reference to an entity's corresponding properties would not be 1->1.
        public string ConvertResourcePropertyNameToEntityPropertyName(string resourcePropertyName)
        {
            // Convert resource types and descriptors names to entity names
            if (resourcePropertyName.EndsWith("Descriptor"))
            {
                return resourcePropertyName + "Id";
            }

            // Handle School references explicitly (pragmatic decision) rather than do the work of reflecting to gather up the properties
            switch (resourcePropertyName)
            {
                case "CharterApprovalSchoolYearTypeReference":
                    return "CharterApprovalSchoolYear";

                case "LocalEducationAgencyReference":
                    return "LocalEducationAgencyId";
            }

            return resourcePropertyName;
        }

        public string TrimIdFromDescriptorsAndTypes(string propertyName)
        {
            return propertyName.EndsWith("TypeId") || propertyName.EndsWith("DescriptorId")
                ? propertyName.TrimSuffix("Id")
                : propertyName;
        }

        public void GetPersistedAndOriginalContentStandards(
            string embeddedObjectPropertyName,
            out AssessmentContentStandard persistedContentStandard,
            out AssessmentContentStandard originalContentStandard)
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var embeddedObjectProperty = persistedEntity.GetType()
                                                        .GetProperty(embeddedObjectPropertyName);

            persistedContentStandard = (AssessmentContentStandard) embeddedObjectProperty.GetValue(persistedEntity);
            originalContentStandard = (AssessmentContentStandard) embeddedObjectProperty.GetValue(originalEntity);
        }

        public IEnumerable<Difference> CompareContentStandards(
            AssessmentContentStandard persistedContentStandard,
            AssessmentContentStandard originalContentStandard)
        {
            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            // Get the differences on the content standard only, exclude the parent
            comparer.Config.MembersToIgnore.Add("Assessment");

            return comparer.Compare(persistedContentStandard, originalContentStandard)
                           .RelevantEntityDifferences();
        }
    }

    public class ContentMetaData
    {
        public int MemberCount;
        public List<string> Members = new List<string>();
    }
}
