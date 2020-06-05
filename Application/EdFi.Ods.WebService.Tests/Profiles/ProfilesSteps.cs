// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Models.Resources.Actual.EdFi;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ProgramAggregate.EdFi;
using EdFi.Ods.Standard;
using EdFi.Ods.WebService.Tests.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using TechTalk.SpecFlow;
using SchoolEntity = EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi.School;
using LocalEducationAgencyEntity = EdFi.Ods.Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency;
using StudentEntity = EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi.Student;
using AssessmentEntity = EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi.Assessment;
using AssessmentContentStandardEntity = EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi.AssessmentContentStandard;
using SchoolResource_Full = EdFi.Ods.Api.Common.Models.Resources.School.EdFi.School;
using LocalEducationAgencyResource_Full = EdFi.Ods.Api.Common.Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency;
using StudentResource_Full = EdFi.Ods.Api.Common.Models.Resources.Student.EdFi.Student;
using AssessmentResource_Full = EdFi.Ods.Api.Common.Models.Resources.Assessment.EdFi.Assessment;
using MetadataProfiles = EdFi.Ods.Common.Metadata.Schemas.Profiles;
using Property = EdFi.Ods.Common.Metadata.Schemas.PropertyDefinition;
using AcademicWeekEntity = EdFi.Ods.Entities.NHibernate.AcademicWeekAggregate.EdFi.AcademicWeek;
using AcademicWeekResource_Full = EdFi.Ods.Api.Common.Models.Resources.AcademicWeek.EdFi.AcademicWeek;
using StudentSpecialEducationProgramAssociationEntity =
    EdFi.Ods.Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation;
using StudentSpecialEducationProgramAssociation_Full =
    EdFi.Ods.Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    [Binding]
    public sealed class ProfilesSteps
    {
        private readonly FeatureContext _currentFeatureContext;
        private readonly ScenarioContext _currentScenarioContext;
        private ProfileStepsHelper _profileStepsHelper;

        public ProfilesSteps()
        {
            // Entry Point, need to set the contexts
            _currentScenarioContext = ScenarioContext.Current;
            _currentFeatureContext = FeatureContext.Current;
            _profileStepsHelper = new ProfileStepsHelper(_currentFeatureContext, _currentScenarioContext);
        }

        [Given(@"the caller is using the ""(.*)"" profile")]
        public void GivenTheCallerIsUsingTheProfile(string profileName)
        {
            // Find the profile, by name
            var profiles = FeatureContext.Current.Get<MetadataProfiles>();
            var profile = profiles.Profile.SingleOrDefault(x => x.name == profileName);

            // Save the profile name and deserialized model for use in the scenario
            _currentScenarioContext.Set(profileName, ScenarioContextKeys.ProfileName);
            _currentScenarioContext.Set(profile);

            var xdoc = FeatureContext.Current.Get<XDocument>("ProfilesXDocument");

            var profileElt = xdoc.Descendants("Profile")
                                 .SingleOrDefault(
                                      e => e.Attribute("name")
                                            .Value == profileName);

            _currentScenarioContext.Set(profileElt, "ProfileXElement");
        }

        [Given(@"the caller is assigned the ""(.*)"" profile")]
        public void GivenTheCallerIsAssignedTheProfile(string profileName)
        {
            List<string> assignedProfiles;

            // Create (or add to) a list of assigned profiles
            if (_currentScenarioContext.TryGetValue(ScenarioContextKeys.AssignedProfiles, out assignedProfiles))
            {
                assignedProfiles.Add(profileName);
            }
            else
            {
                assignedProfiles = new List<string>
                                   {
                                       profileName
                                   };
            }

            // Make the list available to the scenario
            _currentScenarioContext.Set(assignedProfiles, ScenarioContextKeys.AssignedProfiles);
        }

        [When(
            @"a GET \(by id\) request is submitted to (.*) with an accept header content type of (?:the appropriate value for the profile in use|""(.*)"")")]
        public void WhenARequestIsSubmitted(string resourceCollectionName, string contentType)
        {
            // If no explicit content type was provided, build it automatically based on the profile and resource
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = ProfilesContentTypeHelper.CreateContentType(
                    resourceCollectionName,
                    _currentScenarioContext.ProfileName(),
                    ContentTypeUsage.Readable);
            }

            // Execute the GET request against the API
            var httpClient = _currentFeatureContext.HttpClient(contentType);

            var uri = OwinUriHelper.BuildOdsUri(
                resourceCollectionName + "/" + Guid.NewGuid()
                                                   .ToString("n"));

            var getResponseMessage = httpClient.GetAsync(uri)
                                               .Sync();

            string resourceModelName = CompositeTermInflector.MakeSingular(resourceCollectionName)
                                                             .ToMixedCase();

            // Save the response, and the resource collection name for the scenario
            _currentScenarioContext.Set(getResponseMessage);
            _currentScenarioContext.Set(resourceCollectionName, ScenarioContextKeys.ResourceCollectionName);
            _currentScenarioContext.Set(resourceModelName, ScenarioContextKeys.ResourceModelName);
        }

      
        // TODO: JSM - these test may go away in swagger 3.0. If they do we can delete this code, otherwise it will need to be addressed at that time.
        [When(
            @"a GET \(by id\) request is submitted using (.*) to (.*) with an accept header content type of (?:the appropriate value for the profile in use|""(.*)"")")]
        public void WhenAGetByIdRequestIsSubmittedUsingTheSDKWithAnAcceptHeaderContentTypeOfTheAppropriateValueForTheProfileInUse(
            string sdkUsage,
            string resourceCollectionName,
            string contentType)
        {
            if (sdkUsage != "raw JSON")
            {
                throw new NotSupportedException("Unsupported API usage type");
            }

            WhenARequestIsSubmittedWithRawJson(resourceCollectionName, contentType);

            string resourceModelName = CompositeTermInflector.MakeSingular(resourceCollectionName)
                                                             .ToMixedCase();

            _currentScenarioContext.Set(resourceCollectionName, ScenarioContextKeys.ResourceCollectionName);
            _currentScenarioContext.Set(resourceModelName, ScenarioContextKeys.ResourceModelName);
        }

        private void WhenARequestIsSubmittedWithRawJson(string resourceCollectionName, string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = ProfilesContentTypeHelper.CreateContentType(
                    resourceCollectionName,
                    _currentScenarioContext.ProfileName(),
                    ContentTypeUsage.Readable);
            }

            var httpClient = _currentFeatureContext.HttpClient(contentType);

            var uri = OwinUriHelper.BuildOdsUri(
                resourceCollectionName + "/" + Guid.NewGuid()
                                                   .ToString("n"));

            var getResponseMessage = httpClient.GetAsync(uri)
                                               .Sync();

            _currentScenarioContext.Set(getResponseMessage);
        }

        private void CopyContextualSignatureProperties(object sourceEntity, object targetEntity)
        {
            var contextualDomainSignatureProperties = sourceEntity.GetType()
                                                                  .GetProperties()
                                                                  .Where(
                                                                       p =>
                                                                           p.GetCustomAttribute<DomainSignatureAttribute>() != null
                                                                           && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
                                                                  .ToList();

            // Copy signature properties from source to target
            foreach (var property in contextualDomainSignatureProperties)
            {
                property.SetValue(targetEntity, property.GetValue(sourceEntity));
            }

            // Get all the child collections to process
            var childCollectionProperties = sourceEntity.GetType()
                                                        .GetProperties()
                                                        .Where(p => p.PropertyType.Name.StartsWith("ICollection"))
                                                        .ToList();

            foreach (var property in childCollectionProperties)
            {
                dynamic sourceList = property.GetValue(sourceEntity);
                dynamic targetList = property.GetValue(targetEntity);

                if (sourceList.Count != targetList.Count)
                {
                    Assert.Fail("While copying contextual keys to child collections, the number of items in the lists did not match.");
                }

                for (int i = 0; i < sourceList.Count; i++)
                {
                    CopyContextualSignatureProperties(Enumerable.ToList(sourceList)[i], Enumerable.ToList(targetList)[i]);
                }
            }
        }

        [When(
            @"a PUT request with a completely updated resource( with preserved child collections)? is submitted using (.*) to (.*) with a request body content type of (?:the appropriate value for the profile in use|""(.*)"")")]
        public void
            WhenAPUTRequestWithACompletelyUpdatedResourceIsSubmittedUsingTheSDKToSchoolsWithARequestBodyContentTypeOfTheAppropriateValueForTheProfileInUse(
            string withPreservedChildCollections,
            string sdkUsage,
            string resourceCollectionName,
            string contentType)
        {
            if (sdkUsage != "raw JSON")
            {
                throw new NotSupportedException("Unsupported API usage type");
            }

            _currentScenarioContext.Set(resourceCollectionName, ScenarioContextKeys.ResourceCollectionName);

            bool preserveChildCollections = !string.IsNullOrWhiteSpace(withPreservedChildCollections);

            if (string.IsNullOrEmpty(contentType))
            {
                contentType = ProfilesContentTypeHelper.CreateContentType(
                    resourceCollectionName,
                    _currentScenarioContext.ProfileName(),
                    ContentTypeUsage.Writable);
            }

            switch (resourceCollectionName)
            {
                case "schools":

                    PutResourceItem<SchoolEntity, SchoolResource_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                case "localEducationAgencies":

                    PutResourceItem<LocalEducationAgencyEntity, LocalEducationAgencyResource_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                case "students":

                    PutResourceItem<StudentEntity, StudentResource_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                case "academicWeeks":

                    PutResourceItem<AcademicWeekEntity, AcademicWeekResource_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                case "assessments":

                    PutResourceItem<AssessmentEntity, AssessmentResource_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                case "studentSpecialEducationProgramAssociations":

                    PutResourceItem<StudentSpecialEducationProgramAssociationEntity, StudentSpecialEducationProgramAssociation_Full>(
                        resourceCollectionName,
                        contentType,
                        preserveChildCollections);

                    break;

                default:
                    Assert.Fail("No PUT support has been added for resource '{0}'.", resourceCollectionName);
                    break;
            }
        }

        private void PutResourceItem<TEntity, TResource>(
            string resourceCollectionName,
            string contentType,
            bool preserveChildCollections)
            where TEntity : IHasIdentifier, IDateVersionedEntity, new()
            where TResource : new()
        {
            // Get the "GetById" repository operation
            var container = FeatureContext.Current.Get<IWindsorContainer>();
            var getEntityById = container.Resolve<IGetEntityById<TEntity>>();

            // Retrieve an "existing" entity
            Guid id = Guid.NewGuid();
            var entity = getEntityById.GetByIdAsync(id, CancellationToken.None).GetResultSafely();

            string entityName = typeof(TEntity).Name;

            // TODO: Embedded convention - Creating the Mapper type name for an entity
            // Find the mapper method
            var mapperMethod = _profileStepsHelper.GetMapperMethod<TEntity>();

            // Make a copy of the entity for subsequent comparison
            var originalEntity = new TEntity();

            mapperMethod.Invoke(
                null,
                new object[]
                {
                    entity, originalEntity, null
                });

            var comparer = new CompareLogic();

            var compareResult = comparer.Compare(entity, originalEntity);

            var relevantDifferences = compareResult
                .RelevantEntityDifferences()
                .ToList();

            if (!compareResult.AreEqual && relevantDifferences.Any())
            {
                Assert.Fail("These entities should be identical at this point. " + string.Join(Environment.NewLine, relevantDifferences.Select(d => d.ToString())));
            }

            // Create a second entity with all different values
            var entityForUpdate = getEntityById.GetByIdAsync(Guid.NewGuid(), CancellationToken.None).GetResultSafely();

            // Assign the "updated" entity the original entity's identifier and primary key
            entityForUpdate.Id = id;

            // Copy the child collection contextual primary keys to the "updated" version so that 
            // they are seen as the same entities (rather than deletions and additions)
            if (preserveChildCollections)
            {
                CopyContextualSignatureProperties(entity, entityForUpdate);
            }

            // Map the "updated" entity to a full School resource
            var fullResourceForUpdate = new TResource();

            mapperMethod.Invoke(
                null,
                new object[]
                {
                    entityForUpdate, fullResourceForUpdate, null
                });

            var putResponseMessage = new HttpResponseMessage();

            var httpClient = _currentFeatureContext.HttpClient(contentType);

            // Put the "updated" full school resource, using the Profile's content type
            putResponseMessage = httpClient.PutAsync(
                                                OwinUriHelper.BuildOdsUri(
                                                    resourceCollectionName + "/" + id.ToString("n")),
                                                new StringContent(
                                                    JsonConvert.SerializeObject(fullResourceForUpdate),
                                                    Encoding.UTF8,
                                                    contentType))
                                           .Sync();

            _currentScenarioContext.Set(putResponseMessage);

            // Obtain the entity that was "upserted" directly from the fake repository
            var updateEntity = container.Resolve<IUpsertEntity<TEntity>>();
            var repository = (FakeRepository<TEntity>) updateEntity;

            // Save values into the scenario context
            _currentScenarioContext.Set(repository.EntitiesById[id], ScenarioContextKeys.PersistedEntity);
            _currentScenarioContext.Set(originalEntity, ScenarioContextKeys.OriginalEntity);
            _currentScenarioContext.Set(fullResourceForUpdate, ScenarioContextKeys.ResourceForUpdate);
            _currentScenarioContext.Set(entityName, ScenarioContextKeys.ResourceType);
        }

        [Then(
            @"the number of properties on the response model should reflect the number of included properties plus the Id and primary key properties")]
        public void ThenTheResponseModelShouldOnlyContainTheIncludedElements()
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();
            var propertyNames = _profileStepsHelper.GetPropertyNames(data);

            var readContentType = _profileStepsHelper.GetReadContentType("School");

            propertyNames.Count.Equals(
                2 + (readContentType.Collection ?? new ClassDefinition[0]).Length +
                (readContentType.Property ?? new Property[0]).Length);
        }

        [Then(@"the response model should contain the id and the primary key properties of \[(.*)\]")]
        public void ThenTheResponseModelShouldContainTheIdAndPrimaryKey(string primaryKeyProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualPropertyNames = (List<string>) _profileStepsHelper.GetPropertyNames(data);

            // Id
            Assert.That(actualPropertyNames, Has.Member("id"));

            // Primary key fields
            var primaryKeyPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(primaryKeyProperties);

            foreach (string propertyName in primaryKeyPropertyNames)
            {
                Assert.That(actualPropertyNames, Has.Member(propertyName));
            }

            _currentScenarioContext.Set(primaryKeyPropertyNames.Count, ScenarioContextKeys.ContextualPrimaryKeyPropertyCount);
        }

        [Then(@"the response model should contain the explicitly included properties of \[(.*)\]")]
        public void ThenTheResponseModelShouldContainTheIncludedProperties(string includedProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(data);

            var includedPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(includedProperties);

            // Included concrete elements
            foreach (string propertyName in includedPropertyNames)
            {
                Assert.That(actualPropertyNames, Has.Member(propertyName));
            }

            _currentScenarioContext.Set(includedPropertyNames.Count, ScenarioContextKeys.IncludedPropertyCount);
        }

        [Then(@"the response model should contain the explicitly included regular reference properties")]
        public void ThenTheResponseModelShouldContainTheExplicitlyIncludedRegularReferenceProperties()
        {
            //<Property name="LocalEducationAgencyReference" />                   <!-- Regular reference -->
            //<Property name="CharterApprovalSchoolYearTypeReference" />          <!-- Role-named reference -->

            dynamic data = _profileStepsHelper.GetDataFromResponse();
            var propertyNames = _profileStepsHelper.GetPropertyNames(data);

            // Included reference elements
            Assert.That(propertyNames, Contains.Item("LocalEducationAgencyReference".ToCamelCase()));
        }

        [Then(@"the response model should contain the explicitly included role-named reference properties")]
        public void ThenTheResponseModelShouldContainTheExplicitlyIncludedRoleNamedReferenceProperties()
        {
            //<Property name="LocalEducationAgencyReference" />                   <!-- Regular reference -->
            //<Property name="CharterApprovalSchoolYearTypeReference" />          <!-- Role-named reference -->

            dynamic data = _profileStepsHelper.GetDataFromResponse();
            var propertyNames = _profileStepsHelper.GetPropertyNames(data);

            // Included role-named reference elements
            Assert.That(propertyNames, Contains.Item("CharterApprovalSchoolYearTypeReference".ToCamelCase()));
        }

        [Then(@"the response model should not contain the explicitly excluded reference properties")]
        public void ThenTheResponseModelShouldNotContainTheExplicitlyExcludedReferenceProperties()
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();
            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(data);

            var resource = _currentScenarioContext.Resource("School");

            if (resource.ReadContentType.memberSelection != MemberSelectionMode.ExcludeOnly)
            {
                Assert.Fail(
                    "The step definition can only be used ReadContentTypes with a memberSelectionMode of 'ExcludeOnly'.");
            }

            var excludedMembers =
                (resource.ReadContentType.Collection ?? new ClassDefinition[0]).Select(x => x.name)
                                                                               .Concat(
                                                                                    (resource.ReadContentType.Property ?? new Property[0]).Select(
                                                                                        x => x.name))
                                                                               .Select(_profileStepsHelper.TrimIdFromDescriptorsAndTypes);

            foreach (var excludedMember in excludedMembers)
            {
                Assert.That(actualPropertyNames, Has.No.Member(excludedMember));
            }
        }

        [Then(@"the persisted entity model should have unmodified primary key values")]
        public void ThenThePersistedEntityModelShouldHaveAnUnmodifiedPrimaryKeyValue()
        {
            dynamic persistedEntity = _currentScenarioContext.PersistedEntity<dynamic>();
            dynamic originalEntity = _currentScenarioContext.OriginalEntity<dynamic>();

            switch (_currentScenarioContext.EntityTypeName())
            {
                case "School":
                    persistedEntity.SchoolId.Equals(originalEntity.SchoolId);
                    break;
                case "StudentSpecialEducationProgramAssociation":
                    persistedEntity.BeginDate.Equals(originalEntity.BeginDate);
                    break;
            }
        }

        [Then(@"the persisted entity model should not have new values assigned to the explicitly excluded references' properties")]
        public void ThenThePersistedEntityModelShouldNotHaveTheNewValuesAssignedToTheExplicitlyExcludedReferencesProperties()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var resource = _currentScenarioContext.Resource();

            if (resource.ReadContentType.memberSelection != MemberSelectionMode.ExcludeOnly)
            {
                Assert.Fail(
                    "The step definition can only be used for ReadContentTypes with a memberSelectionMode of 'ExcludeOnly'.");
            }

            var excludedReferenceProperties =
                (resource.ReadContentType.Collection ?? new ClassDefinition[0]).Select(x => x.name)
                                                                               .Concat(
                                                                                    (resource.ReadContentType.Property ?? new Property[0]).Select(
                                                                                        x => x.name))
                                                                               .Where(x => x.EndsWith("Reference"))
                                                                               .Select(
                                                                                    _profileStepsHelper
                                                                                       .ConvertResourcePropertyNameToEntityPropertyName)
                                                                               .ToList();

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            var compareResult = comparer.Compare(originalEntity, persistedEntity);

            // Verify that none of the excluded references are in the change list
            var changedValuePropertyNames = compareResult.RelevantEntityDifferences()
                                                         .Select(
                                                              x => x.PropertyName.TrimStart('.')
                                                                    .Split('[')[0])
                                                         .Distinct()
                                                         .ToList();

            foreach (var excludedReferenceProperty in excludedReferenceProperties)
            {
                Assert.That(changedValuePropertyNames, Has.No.Member(excludedReferenceProperty));
            }
        }

        [Then(@"the only values changed should be the explicitly included values")]
        public void ThenTheOnlyValuesChangedShouldBeTheExplicitlyIncludedValues()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var resource = _currentScenarioContext.Resource();

            if (resource.WriteContentType.memberSelection != MemberSelectionMode.IncludeOnly)
            {
                Assert.Fail(
                    "The step definition can only be used for WriteContentTypes with a memberSelectionMode of 'IncludeOnly'.");
            }

            var includedProperties = _profileStepsHelper.WriteContentTypeProperties(resource)
                                                        .Select(_profileStepsHelper.TrimIdFromDescriptorsAndTypes);

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            var compareResult = comparer.Compare(originalEntity, persistedEntity);

            // Verify that all the differences are covered by the expected list
            var changedValuesPropertyNames = compareResult.RelevantEntityDifferences().Select(x => x.PropertyName)
                                                          .ToList();

            var changedValuesNotFound = changedValuesPropertyNames.Where(
                dp => !includedProperties.Any(ip => dp.TrimStart('.').StartsWith(ip)));

            if (changedValuesNotFound.Any())
            {
                string notFoundText = String.Join(", ", changedValuesNotFound);
                Assert.Fail($"The following values were changed values were not found in the included set: {notFoundText}");
            }
        }

        [Then(@"the only values changed should be the explicitly included regular and role-named references' properties")]
        public void ThenTheOnlyValuesChangedShouldBeTheExplicitlyIncludedRegularAndRoleNamedReferencesProperties()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var resource = _currentScenarioContext.Resource();

            var includedProperties =
                (resource.WriteContentType.Collection ?? new ClassDefinition[0]).Select(x => x.name)
                                                                                .Concat(
                                                                                     (resource.WriteContentType.Property ?? new Property[0]).Select(
                                                                                         x => x.name))
                                                                                .Select(_profileStepsHelper.TrimIdFromDescriptorsAndTypes);

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            var compareResult = comparer.Compare(originalEntity, persistedEntity);

            // This "map" is defined based on hard-coded knowledge of the profiles being used for testing
            // The effort to obtaining the physical database information here outweighs the benefit
            var explicitlyMappedIncludes =
                includedProperties.Select(
                    p =>
                    {
                        // Map the known LEA reference to the corresponding property name
                        if (p.EqualsIgnoreCase("LocalEducationAgencyReference"))
                        {
                            return "LocalEducationAgencyId";
                        }

                        // Map the known role-named reference to the corresponding property name
                        if (p.EqualsIgnoreCase("CharterApprovalSchoolYearTypeReference"))
                        {
                            return "CharterApprovalSchoolYear";
                        }

                        // This really shouldn't be used by this step and the profile defined, but map others literally
                        return p;
                    });

            // Verify that all the differences are covered by the expected list
            var differingEntityPropertyNames = compareResult.RelevantEntityDifferences().Select(x => x.PropertyName)
                                                            .ToList();

            differingEntityPropertyNames.All(dp => explicitlyMappedIncludes.Any(ip => dp.TrimStart('.').StartsWith(ip)))
                                        .ShouldBeTrue(DisplayLists(differingEntityPropertyNames, explicitlyMappedIncludes));
        }

        [Then(@"the response should indicate success")]
        public void ThenTheResponseShouldIndicateSuccess()
        {
            var response = ScenarioContext.Current.Get<HttpResponseMessage>();

            Assert.That(
                response.StatusCode,
                Is.EqualTo(HttpStatusCode.OK)
                  .Or.EqualTo(HttpStatusCode.NoContent)
                  .Or.EqualTo(HttpStatusCode.Created),
                response.Content.ReadAsStringAsync()
                        .GetResultSafely());
        }

        [Then(@"the response should indicate an internal server error")]
        public void ThenTheResponseShouldIndicateAnInternalServerError()
        {
            var response = ScenarioContext.Current.Get<HttpResponseMessage>();

            Assert.That(
                response.StatusCode,
                Is.EqualTo(HttpStatusCode.InternalServerError),
                response.Content.ReadAsStringAsync()
                        .GetResultSafely());
        }

     

        [Then(@"the response model should not contain the explicitly excluded properties of \[(.*)\]")]
        public void ThenTheResponseModelShouldNotContainTheExplicitlyExcludedProperties(string excludedProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(data);

            var excludedPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(excludedProperties);

            excludedPropertyNames.ForEach(p => Assert.That(actualPropertyNames, Has.No.Member(p)));

            _currentScenarioContext.Set(excludedPropertyNames.Count, ScenarioContextKeys.ExcludedPropertyCount);
        }

        [Then(
            @"the number of properties on the response model should reflect the number of properties \(including the Id and primary key properties\) less the excluded ones")]
        public void
            ThenTheNumberOfPropertiesOnTheResponseModelShouldReflectTheNumberOfPropertiesIncludingTheIdAndPrimaryKeyPropertiesLessTheExcludedOnes()
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var resourcesInProfile = _currentScenarioContext.Profile()
                                                            .Resource;

            var profileExcludedMembers =
                resourcesInProfile.SelectMany(
                    r => _profileStepsHelper.GetResourceMemberData(r, ContentTypeUsage.Readable).Members)
                    .ToList();

            int profileExcludedMemberCount =
                resourcesInProfile.Sum(
                    r => _profileStepsHelper.GetResourceMemberData(r, ContentTypeUsage.Readable)
                                            .MemberCount);

            Assert.That(profileExcludedMembers.Count(), Is.EqualTo(profileExcludedMemberCount), DisplayList("Profile Excluded Members", profileExcludedMembers));

            var fullResourceJsonPropertyNames = typeof(SchoolResource_Full).GetProperties()
                .Where(p => p.IsRelevantForEntityComparison())
                .Select(p => p.GetCustomAttributes<DataMemberAttribute>().FirstOrDefault()?.Name)
                .ToList();

            int fullResourcePropertyCount = fullResourceJsonPropertyNames.Count();
            Assert.That(fullResourceJsonPropertyNames.Count(), Is.EqualTo(fullResourcePropertyCount), DisplayList("Full Resource Properties", fullResourceJsonPropertyNames));

            var actualJsonPropertyNames = ((List<string>) _profileStepsHelper.GetPropertyNames(data))
                .Where(n => n.IsRelevantForEntityComparison())
                .ToList();

            int actualIncludedPropertyCount = actualJsonPropertyNames.Count;

            var actualExcludedMembers = fullResourceJsonPropertyNames.Except(actualJsonPropertyNames).ToList();
            int actualExcludedMemberCount = fullResourcePropertyCount - actualIncludedPropertyCount;
            Assert.That(actualExcludedMemberCount, Is.EqualTo(actualExcludedMembers.Count()), DisplayList("Actual Excluded Members", actualExcludedMembers));

            Assert.That(actualExcludedMemberCount, Is.EqualTo(profileExcludedMemberCount), 
                DisplayLists(actualExcludedMembers, profileExcludedMembers));
        }

        [Then(@"the persisted entity model should not have the new values assigned to the explicitly excluded properties")]
        public void ThenThePersistedEntityModelShouldNotHaveTheNewValuesAssignedToTheExplicitlyExcludedProperties()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var resource = _currentScenarioContext.Resource();

            var excludedEntityPropertyNames = _profileStepsHelper.WriteContentTypeProperties(resource)
                                                                 .Select(_profileStepsHelper.ConvertResourcePropertyNameToEntityPropertyName);

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            var compareResult = comparer.Compare(originalEntity, persistedEntity);

            var changedPropertyNames =
                compareResult.RelevantEntityDifferences()
                             .Select(diff => diff.PropertyName.TrimStart('.'))
                             .ToList();

            Assert.That(
                excludedEntityPropertyNames.Intersect(changedPropertyNames)
                                           .Any(),
                Is.False);
        }

        [Then(@"the only values not changed should be the explicitly excluded values, the id, and the primary key values")]
        public void ThenTheOnlyValuesNotChangedShouldBeTheExplicitlyExcludedValuesTheIdAndThePrimaryKeyValues()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var resource = _currentScenarioContext.Resource();

            var excludedPropertyNames =

                // Get resource's child member names
                (resource.WriteContentType.Collection ?? new ClassDefinition[0]).Select(x => x.name)
                                                                                .Concat(
                                                                                     (resource.WriteContentType.Property ?? new Property[0]).Select(
                                                                                         x => x.name))

                                                                                 // Convert the member names from resource to entity property names
                                                                                .Select(
                                                                                     _profileStepsHelper
                                                                                        .ConvertResourcePropertyNameToEntityPropertyName)
                                                                                .ToList();

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    MaxDifferences = 100
                });

            var compareResult = comparer.Compare(originalEntity, persistedEntity);

            var differingPropertyNames = compareResult
                                        .RelevantEntityDifferences()

                                         // Normalize Types/Descriptor properties to the form using the Id suffix
                                        .Select(
                                             diff => _profileStepsHelper.ConvertResourcePropertyNameToEntityPropertyName(
                                                 diff.PropertyName.TrimStart('.')
                                                     .Split('[', '.')[0]))

                                         // Eliminate duplicates caused by Id suffix normalization on entities
                                        .Distinct();

            Type entityType = null;

            var keyProperties = new string[]
                                { };

            switch (_currentScenarioContext.EntityTypeName())
            {
                case "School":
                    entityType = typeof(SchoolEntity);

                    keyProperties = new[]
                                    {
                                        "SchoolId",
                                        "EducationOrganizationId"
                                    };

                    break;
                case "StudentSpecialEducationProgramAssociation":
                    entityType = typeof(StudentSpecialEducationProgramAssociationEntity);

                    keyProperties = new[]
                                    {
                                        "BeginDate",
                                        "EducationOrganizationId",
                                        "ProgramEducationOrganizationId",
                                        "ProgramName",
                                        "ProgramTypeDescriptorId",
                                        "StudentUSI",
                                        "StudentUniqueId",
                                    };

                    break;
            }

            var allEntityProperties = entityType?
                                     .GetProperties()

                                     .Where(property => property.IsRelevantForEntityComparison())

                                     // Eliminate boolean properties (because they can't be guaranteed to be different with such a limited domain of values)
                                     .Where(property => property.PropertyType != typeof(bool?))

                                      // Normalize Types/Descriptor properties to the form using the Id suffix
                                     .Select(property => _profileStepsHelper.ConvertResourcePropertyNameToEntityPropertyName(property.Name))

                                      // Eliminate duplicates caused by Id suffix normalization on entities
                                     .Distinct();

            // the only values not changed ... 
            var actualUnchangedPropertyNames =
                allEntityProperties?
                   .Except(differingPropertyNames)
                   .OrderBy(x => x)
                   .ToList();

            // ... should be the explicitly excluded values, the id, and the primary key
            var expectedUnchangedPropertyNames =
                excludedPropertyNames
                   .Concat(keyProperties)
                   .OrderBy(x => x)
                   .ToList();

            Assert.That(actualUnchangedPropertyNames, Is.EqualTo(expectedUnchangedPropertyNames), 
                DisplayLists(actualUnchangedPropertyNames, expectedUnchangedPropertyNames));
        }

        [Then(@"the response model should contain all of the resource model's properties")]
        public void ThenTheResponseModelShouldContainAllOfTheResourceModelsProperties()
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualResponsePropertyNames = (List<string>) _profileStepsHelper.GetPropertyNames(data);

            Type currentResourceType = null;

            switch (_currentScenarioContext.ResourceModelName())
            {
                case "School":
                    currentResourceType = typeof(SchoolResource_Full);
                    break;
                case "StudentSpecialEducationProgramAssociation":
                    currentResourceType = typeof(StudentSpecialEducationProgramAssociation_Full);
                    break;
            }

            var fullResourcePropertyNames = currentResourceType?.GetProperties()

                                                                 // TODO: JSM - If testing with extensions a new step should be added with explicit support.
                                                                .Where(
                                                                     p => p.GetCustomAttribute<DataMemberAttribute>() != null
                                                                          && p.Name != "ETag" && !_profileStepsHelper.IsExtension(p.Name))
                                                                .Select(
                                                                     p => p.GetCustomAttribute<DataMemberAttribute>()
                                                                           .Name);

            // Compare the sorted lists for any differences
            Assert.That(actualResponsePropertyNames, Is.EquivalentTo(fullResourcePropertyNames));
        }

        [Then(@"every non-primary key value on the entity should be changed")]
        public void ThenEveryNon_PrimaryKeyValueOnTheEntityShouldBeChanged()
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var changedPropertyPaths = new List<string>();

            var comparer = new CompareLogic(
                new ComparisonConfig
                {
                    ShowBreadcrumb = true,
                    MaxDifferences = int.MaxValue,
                    DifferenceCallback = d =>
                    {
                        if (d.IsRelevantForEntityComparison())
                        {
                            string normalizedPropertyPath =
                                _profileStepsHelper.RemoveArrayIndexers(
                                    d.PropertyName.TrimStart('.'));

                            changedPropertyPaths.Add(normalizedPropertyPath);
                        }
                    }
                });

            comparer.Compare(originalEntity, persistedEntity);

            List<string> entityPropertyPaths = null;
            string[] identifierProperties = null;

            switch (_currentScenarioContext.EntityTypeName())
            {
                case "School":
                    entityPropertyPaths = _profileStepsHelper.GetEntityPropertyPaths<SchoolEntity>();

                    identifierProperties = new[]
                                           {
                                               "SchoolId",
                                               "EducationOrganizationId",
                                           };

                    break;
                case "StudentSpecialEducationProgramAssociation":
                    entityPropertyPaths = _profileStepsHelper.GetEntityPropertyPaths<StudentSpecialEducationProgramAssociationEntity>();

                    identifierProperties = new[]
                                           {
                                               "BeginDate",
                                               "EducationOrganizationId",
                                               "ProgramEducationOrganizationId",
                                               "ProgramName",
                                               "ProgramTypeDescriptor",
                                               "ProgramTypeDescriptorId",
                                               "StudentUniqueId",
                                               "StudentUSI"
                                           };

                    break;
            }

            var actualUnchangedProperties = entityPropertyPaths?.Except(changedPropertyPaths)
                                                                .ToList();

            Assert.That(actualUnchangedProperties, Is.EquivalentTo(identifierProperties), DisplayLists(actualUnchangedProperties, identifierProperties));
        }

        [Then(@"the response model's (?:base class )?(.*) collection items should contain the contextual primary key properties of \[(.*)\]")]
        public void ThenTheResponseModelSBaseClassCollectionAItemsShouldContainTheContextualPrimaryKeyProperties(
            string collectionPropertyName,
            string contextualPrimaryKeyProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var collection = data[collectionPropertyName];

            if (collection == null)
            {
                Assert.Fail(
                    "Collection property '{0}' not found.\r\nModel Data: \r\n{1}",
                    collectionPropertyName,
                    _profileStepsHelper.GetContentFromResponse());
            }

            dynamic firstChildItem = collection[0];

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(firstChildItem);

            var contextualPrimaryKeyPropertyNames = contextualPrimaryKeyProperties
                                                   .Split(',')
                                                   .Select(x => x.Trim())
                                                   .ToList();

            foreach (string propertyName in contextualPrimaryKeyPropertyNames)
            {
                Assert.That(actualPropertyNames, Has.Member(propertyName));
            }

            _currentScenarioContext.Set(contextualPrimaryKeyPropertyNames.Count, ScenarioContextKeys.ContextualPrimaryKeyPropertyCount);
        }

        [Then(@"the response model's (?:base class )?(.*) collection items should not contain the explicitly excluded properties of \[(.*)\]")]
        public void ThenTheResponseModelsBaseClassCollectionAItemsShouldNotContainTheExplicitlyExcludedProperties(
            string collectionPropertyName,
            string excludedProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var baseClassChildCollection = data[collectionPropertyName];

            if (baseClassChildCollection == null)
            {
                Assert.Fail(
                    "Base class child collection property '{0}' not found.\r\nModel Data: \r\n{1}",
                    collectionPropertyName,
                    _profileStepsHelper.GetContentFromResponse());
            }

            var firstItem = baseClassChildCollection[0];

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(firstItem);

            var excludedPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(excludedProperties);

            foreach (string propertyName in excludedPropertyNames)
            {
                Assert.That(actualPropertyNames, Has.No.Member(propertyName));
            }

            _currentScenarioContext.Set(excludedPropertyNames.Count, ScenarioContextKeys.ExcludedPropertyCount);
        }

        [Then(@"the response model's (?:base class )?(.*) collection items should contain the explicitly included properties of \[(.*)\]")]
        public void ThenTheResponseModelsBaseClassCollectionAItemsShouldContainTheExplicitlyIncludedProperties(
            string collectionPropertyName,
            string includedProperties)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var collection = data[collectionPropertyName];

            if (collection == null)
            {
                Assert.Fail(
                    "Collection property '{0}' not found.\r\nModel Data: \r\n{1}",
                    collectionPropertyName,
                    _profileStepsHelper.GetContentFromResponse());
            }

            dynamic firstItem = collection[0];

            var itemPropertyNames = _profileStepsHelper.GetPropertyNames(firstItem);

            var includedPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(includedProperties);

            foreach (string propertyName in includedPropertyNames)
            {
                Assert.That(itemPropertyNames, Has.Member(propertyName));
            }

            _currentScenarioContext.Set(includedPropertyNames.Count, ScenarioContextKeys.IncludedPropertyCount);
        }

        [Then(
            @"the number of properties on the response model's base class (.*) collection items should reflect the number of included properties plus the contextual primary key properties")]
        public void
            ThenTheNumberOfPropertiesOnTheResponseModelsBaseCollectionAShouldReflectTheNumberOfIncludedPropertiesPlusTheContextualPrimaryKeyProperties(
            string collectionPropertyName)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var baseClassChildCollection = data[collectionPropertyName];

            if (baseClassChildCollection == null)
            {
                Assert.Fail(
                    "Base class child collection property '{0}' not found.\r\nModel Data: \r\n{1}",
                    collectionPropertyName,
                    _profileStepsHelper.GetContentFromResponse());
            }

            var firstItem = baseClassChildCollection[0];
            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(firstItem);

            AssertPropertyCountReflectIncludedPropertiesPlusContextualPrimaryKeys(actualPropertyNames, false);
        }

        [Then(@"the number of properties on the response model should reflect the number of included properties plus the primary key properties")]
        public void The_number_of_properties_on_the_response_model_should_reflect_the_number_of_included_properties_plus_the_primary_key_properties()
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(data);

            AssertPropertyCountReflectIncludedPropertiesPlusContextualPrimaryKeys(actualPropertyNames, true);
        }

        public void AssertPropertyCountReflectIncludedPropertiesPlusContextualPrimaryKeys(List<string> actualPropertyNames, bool isResourceLevel)
        {
            int contextualPrimaryKeyCount = _currentScenarioContext.Get<int>(ScenarioContextKeys.ContextualPrimaryKeyPropertyCount);
            int includedPropertyCount = _currentScenarioContext.Get<int>(ScenarioContextKeys.IncludedPropertyCount);

            int expectedCount =
                (isResourceLevel
                    ? 1
                    : 0)
                + includedPropertyCount
                + contextualPrimaryKeyCount;

            Assert.That(actualPropertyNames, Has.Count.EqualTo(expectedCount));
        }

        [Then(
            @"the only values changed on the entity model's (?:base class )?(.*) collection items should be the explicitly included properties of (.*)")]
        public void ThenTheOnlyValuesChangedOnTheEntityModelsBaseClassCollectionItemsShouldBeTheExplicitlyIncludedValues(
            string collectionPropertyName,
            string includedProperties)
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var collectionProperty = persistedEntity.GetType()
                                                    .GetProperty(collectionPropertyName);

            var currentCollection = collectionProperty.GetValue(persistedEntity);
            var originalCollection = collectionProperty.GetValue(originalEntity);

            var comparer =
                new CompareLogic(
                    new ComparisonConfig
                    {
                        MaxDifferences = 100,

                        //Don't look at the base class property, only look at the collection differences.
                        MembersToIgnore = new List<string>
                                          {
                                              originalEntity.GetType()
                                                            .Name,
                                              "CreatedByOwnershipTokenId"
                                          }
                    });

            var compareResult = comparer.Compare(currentCollection, originalCollection);

            var set = new HashSet<string>();

            var modifiedPropertyNames =
                compareResult.RelevantEntityDifferences()
                             .Select(
                                  d => d.PropertyName.Split('.')
                                        .Last())
                             .Where(s => set.Add(s))
                             .ToList();

            var includedPropertyNames = _profileStepsHelper.ParseNamesFromCsvText(includedProperties);

            Assert.That(modifiedPropertyNames, Is.EquivalentTo(includedPropertyNames));
        }

        [Then(
            @"the number of properties on the response model's (?:base class )?(.*) collection items should reflect the number of properties on the full (.*) resource model( less the explicitly excluded ones)?")]
        public void
            ThenTheNumberOfPropertiesOnTheResponseModelsBaseClassCollectionAItemsShouldReflectTheNumberOfPropertiesOnTheModelLessTheExplicitlyExcludedOnes(
            string collectionPropertyName,
            string resourceModelName,
            string lessTheExplicitlyExcludedOnes)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var baseClassChildCollection = data[collectionPropertyName];

            if (baseClassChildCollection == null)
            {
                Assert.Fail(
                    "Base class child collection property '{0}' not found.\r\nModel Data: \r\n{1}",
                    collectionPropertyName,
                    _profileStepsHelper.GetContentFromResponse());
            }

            var firstItem = baseClassChildCollection[0];
            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(firstItem);

            // Use the verification of the method below
            AssertPropertyCountReflectFullModelPropertiesLessExcluded(
                resourceModelName,
                lessTheExplicitlyExcludedOnes,
                actualPropertyNames);
        }

        [Then(
            @"the number of properties on the response model should reflect the number of properties on the full (.*) resource model( less the explicitly excluded ones)?")]
        public void ThenTheNumberOfPropertiesOnTheResponseModelShouldReflectTheNumberOfPropertiesOnTheModelLessTheExplicitlyExcludedOnes(
            string resourceModelName,
            string lessTheExplicitlyExcludedOnes)
        {
            dynamic data = _profileStepsHelper.GetDataFromResponse();

            var actualPropertyNames = _profileStepsHelper.GetPropertyNames(data);

            AssertPropertyCountReflectFullModelPropertiesLessExcluded(
                resourceModelName,
                lessTheExplicitlyExcludedOnes,
                actualPropertyNames);
        }

        public void AssertPropertyCountReflectFullModelPropertiesLessExcluded(
            string resourceModelName,
            string lessTheExplicitlyExcludedOnes,
            List<string> actualPropertyNames)
        {
            var fullResourceModelType =
                (from t in typeof(Marker_EdFi_Ods_Standard).Assembly.GetTypes()

                 // TODO: Embedded convention - base namespace for resources
                 where t.FullName.StartsWith(Namespaces.Resources.BaseNamespace + ".")
                       && t.Name == resourceModelName
                 select t)
               .Single();

            // Count the serializable properties on the full resource model
            int fullResourceModelPropertyCount = fullResourceModelType
                                                .GetProperties()

                                                 // TODO: JSM - If testing with extensions a new step should be added with explicit support.
                                                .Count(
                                                     p => !_profileStepsHelper.IsETag(p.Name) && !_profileStepsHelper.IsExtension(p.Name)
                                                                                              && p.GetCustomAttribute<DataMemberAttribute>() != null);

            bool subtractExcludedProperties = !string.IsNullOrWhiteSpace(lessTheExplicitlyExcludedOnes);

            int excludedPropertyCount = subtractExcludedProperties
                ? _currentScenarioContext.Get<int>(ScenarioContextKeys.ExcludedPropertyCount)
                : 0;

            Assert.That(actualPropertyNames, Has.Count.EqualTo(fullResourceModelPropertyCount - excludedPropertyCount));
        }

        [Then(
            @"the only values not changed on the entity model's (?:base class )?(.*) collection items should be the contextual primary key values of \[(.*?)\](?:, and the explicitly excluded properties of \[(.*)\])?")]
        public void
            ThenTheOnlyValuesNotChangedOnTheEntityModelSBaseClassCollectionItemsShouldBeTheExplicitlyExcludedValuesAndTheContextualPrimaryKeyValues(
            string collectionPropertyName,
            string contextualPrimaryKeyProperties,
            string excludedProperties)
        {
            var persistedEntity = _currentScenarioContext.PersistedEntity<object>();
            var originalEntity = _currentScenarioContext.OriginalEntity<object>();

            var collectionProperty = persistedEntity.GetType()
                                                    .GetProperty(collectionPropertyName);

            var currentCollection = collectionProperty.GetValue(persistedEntity);
            var originalCollection = collectionProperty.GetValue(originalEntity);

            var comparer =
                new CompareLogic(
                    new ComparisonConfig
                    {
                        MaxDifferences = 100,

                        //Don't look at the base class property, only look at the collection differences.
                        MembersToIgnore = new List<string>
                                          {
                                              originalEntity.GetType()
                                                            .Name
                                          }
                    });

            var compareResult = comparer.Compare(currentCollection, originalCollection);

            var modifiedPropertyNames = compareResult.RelevantEntityDifferences()
                                                     .Select(
                                                          x => x.PropertyName.Split('.')
                                                                .Last())
                                                     .Distinct()
                                                     .ToList();

            string entityModelName = CompositeTermInflector.MakeSingular(collectionPropertyName);

            var entityModelType =
                (from t in typeof(Marker_EdFi_Ods_Standard).Assembly.GetTypes()

                 // TODO: Embedded convention - finding entity models by name
                 where t.Name == entityModelName
                       && t.FullName.Contains(".Entities.")
                 select t)
               .Single();

            var allEntityProperties = entityModelType
                                     .GetProperties()
                                     .Where(
                                          p =>
                                              p.Name != "CreateDate" // Boilerplate property for identifying transient entities
                                              && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
                                     .Select(p => p.Name);

            var unmodifiedPropertyNames =
                allEntityProperties
                   .Except(modifiedPropertyNames)
                   .ToList();

            string[] expectedUnmodified =

                // Contextal primary key value
                _profileStepsHelper.ParseNamesFromCsvText(contextualPrimaryKeyProperties)

                                    // Explicitly excluded
                                   .Concat(_profileStepsHelper.ParseNamesFromCsvText(excludedProperties))
                                   .ToArray();

            Assert.That(unmodifiedPropertyNames, Is.EquivalentTo(expectedUnmodified), DisplayLists(unmodifiedPropertyNames, expectedUnmodified));
        }
    
       

        private string DisplayList(string label, IEnumerable<string> items)
        {
            return $@"{label}:
-------------
  {string.Join(Environment.NewLine + "  ", items)}
";
        }

        private string DisplayLists(IEnumerable<string> actualItems, IEnumerable<string> expectedItems)
        {
            return $@"Actual Items:
-------------
  {string.Join(Environment.NewLine + "  ", actualItems)}

ExpectedItems:
--------------
  {string.Join(Environment.NewLine + "  ", expectedItems)}
";
        }


    }
}
