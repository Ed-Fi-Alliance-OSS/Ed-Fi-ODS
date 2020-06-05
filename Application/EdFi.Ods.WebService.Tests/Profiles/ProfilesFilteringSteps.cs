// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Xml.XPath;
using Castle.Windsor;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.WebService.Tests.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using EdFi.TestObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SchoolResource_Full = EdFi.Ods.Api.Common.Models.Resources.School.EdFi.School;
using StudentAssessmentResource_Full = EdFi.Ods.Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessment;
using ScoreResult_Entity = EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessmentStudentObjectiveAssessmentScoreResult;
using PerformanceLevel_Entity =
    EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel;
using ScoreResult_Full = EdFi.Ods.Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessmentStudentObjectiveAssessmentScoreResult;
using PerformanceLevel_Full = EdFi.Ods.Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessmentStudentObjectiveAssessmentPerformanceLevel;
using SchoolEntity = EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi.School;
using StudentAssessment_Entity = EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment;
using SchoolCategory_Entity = EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi.SchoolCategory;
using SchoolGradeLevel_Entity = EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi.SchoolGradeLevel;
using EducationOrganizationAddress_Entity = EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi.EducationOrganizationAddress;
using EducationOrganizationInternationalAddress_Entity =
    EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi.EducationOrganizationInternationalAddress;
using SchoolCategory_Full = EdFi.Ods.Api.Common.Models.Resources.School.EdFi.SchoolCategory;
using SchoolGradeLevel_Full = EdFi.Ods.Api.Common.Models.Resources.School.EdFi.SchoolGradeLevel;
using EducationOrganizationAddress_Full = EdFi.Ods.Api.Common.Models.Resources.EducationOrganization.EdFi.EducationOrganizationAddress;
using EducationOrganizationInternationalAddress_Full =
    EdFi.Ods.Api.Common.Models.Resources.EducationOrganization.EdFi.EducationOrganizationInternationalAddress;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    [Binding]
    public class ProfilesFilteringSteps
    {
        private readonly ProfileStepsHelper _profileStepsHelper;

        public ProfilesFilteringSteps()
        {
            _profileStepsHelper = new ProfileStepsHelper(FeatureContext.Current, ScenarioContext.Current);
        }

        [When(
            @"a PUT request with a collection containing only (.*) (included|excluded) (Type|Descriptor) values is submitted to (.*) with a request body content type of (?:the appropriate value for the profile in use|""(.*)"")")]
        public void
            WhenAPUTRequestWithACollectionContainingOnlyConformingIncludedOrExcludedTypeValuesIsSubmittedToSchoolsWithARequestBodyContentTypeOfTheAppropriateValueForTheProfileInUse(
            ConformanceType conformanceType,
            IncludedOrExcluded includedOrExcluded,
            string typeOrDescriptor,
            string resourceCollectionName,
            string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = ProfilesContentTypeHelper.CreateContentType(
                    resourceCollectionName,
                    ScenarioContext.Current.Get<string>(ScenarioContextKeys.ProfileName),
                    ContentTypeUsage.Writable);
            }

            var httpClient = FeatureContext.Current.Get<HttpClient>();

            httpClient.DefaultRequestHeaders.Clear();
            var container = FeatureContext.Current.Get<IWindsorContainer>();

            HttpContent putRequestContent = null;
            Guid id = Guid.NewGuid();

            switch (resourceCollectionName)
            {
                case "schools":
                    putRequestContent = GetSchoolPutRequestContent(id, contentType, conformanceType, includedOrExcluded, container, httpClient);
                    break;

                case "studentAssessments":

                    putRequestContent = GetStudentAssessmentPutRequestContent(
                        id,
                        contentType,
                        conformanceType,
                        includedOrExcluded,
                        container,
                        httpClient);

                    break;

                default:
                    throw new NotSupportedException();
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                Guid.NewGuid()
                    .ToString());

            // Post resource, using the Profile's content type
            var putResponseMessage = httpClient.PutAsync(OwinUriHelper.BuildOdsUri(resourceCollectionName + "/" + id), putRequestContent)
                                               .Sync();

            ScenarioContext.Current.Set(putResponseMessage);
        }

        private static HttpContent GetSchoolPutRequestContent(
            Guid id,
            string contentType,
            ConformanceType conformanceType,
            IncludedOrExcluded includedOrExcluded,
            IWindsorContainer container,
            HttpClient httpClient)
        {
            // Get the "GetById" repository operation
            var getSchoolEntityById = container.Resolve<IGetEntityById<SchoolEntity>>();

            // Retrieve an "existing" entity
            var schoolEntityForUpdate = getSchoolEntityById.GetByIdAsync(id, CancellationToken.None).GetResultSafely();

            // Map the "updated" entity to a full School resource
            var fullSchoolResourceForUpdate = new SchoolResource_Full();
            schoolEntityForUpdate.MapTo(fullSchoolResourceForUpdate, null);

            //empty the id for the Post operation
            fullSchoolResourceForUpdate.Id = Guid.Empty;

            var profileElt = ScenarioContext.Current.Get<XElement>("ProfileXElement");
            string resourceName = "School";
            bool inclusiveFilter = includedOrExcluded == IncludedOrExcluded.Included;

            // Assumption: For simplicity (until otherwise required) we're only supporting these descriptors
            Func<string, bool> filterPropertyNamePredicate = x =>
                                                                 x.EqualsIgnoreCase("AddressTypeDescriptor")
                                                                 || x.EqualsIgnoreCase("CountryDescriptor")
                                                                 || x.EqualsIgnoreCase("SchoolCategoryDescriptor")
                                                                 || x.EqualsIgnoreCase("GradeLevelDescriptor");

            var filteredCollectionElts =
                GetFilteredCollectionElts(
                        profileElt,
                        resourceName,
                        false,
                        filterPropertyNamePredicate,
                        inclusiveFilter)
                   .ToList();

            if (!filteredCollectionElts.Any())
            {
                throw new InvalidOperationException(
                    "Assumptions have been made for simplicity of the tests.  No collection filtered on 'AddressTypeDescriptor' or 'CountryDescriptor' or 'SchoolCategoryDescriptor' or 'GradeLevelDescriptor' was found.");
            }

            bool conforming = conformanceType == ConformanceType.Conforming;
            bool valuesAreIncluded = includedOrExcluded == IncludedOrExcluded.Included;

            bool nonConforming = conformanceType == ConformanceType.NonConforming;
            bool valuesAreExcluded = includedOrExcluded == IncludedOrExcluded.Excluded;

            foreach (var filteredCollectionElt in filteredCollectionElts)
            {
                var filterElt = filteredCollectionElt.Element("Filter");

                string filterPropertyName = filterElt.Attribute("propertyName")
                                                     .Value;

                // Get the filter's values
                var filterValues = filterElt
                                  .Elements("Value")
                                  .Select(x => x.Value)
                                  .ToList();

                var testObjectFactory = container.Resolve<ITestObjectFactory>();

                // Defensive programming
                if (!(conforming || nonConforming) || !(valuesAreIncluded || valuesAreExcluded))
                {
                    throw new NotSupportedException(
                        "Both members of conforming/non-conforming or included/excluded have been set to false, indicating a change of mutual exclusivity expectations.");
                }

                if (valuesAreIncluded && conforming || valuesAreExcluded && nonConforming)
                {
                    if (filterPropertyName == "AddressTypeDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.EducationOrganizationAddresses.Clear();
                        schoolEntityForUpdate.EducationOrganizationAddresses.Clear();

                        // Add only conforming/included (or non-conforming excluded) items to the resource
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<EducationOrganizationAddress_Full>();
                                    item.AddressTypeDescriptor = fv;
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.EducationOrganizationAddresses.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolEntity>()
                                                                    .EducationOrganizationAddresses.First();

                                        item.AddressTypeDescriptor = fv + "1111";
                                        item.EducationOrganization = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.EducationOrganizationAddresses.Add(a));
                        }
                    }
                    else if (filterPropertyName == "CountryDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.EducationOrganizationInternationalAddresses.Clear();
                        schoolEntityForUpdate.EducationOrganizationInternationalAddresses.Clear();

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item =
                                        testObjectFactory.Create<EducationOrganizationInternationalAddress_Full>();

                                    item.CountryDescriptor = fv;
                                    return item;
                                })
                           .ForEach(
                                a => fullSchoolResourceForUpdate.EducationOrganizationInternationalAddresses.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item =
                                            testObjectFactory.Create<EducationOrganizationInternationalAddress_Entity>
                                                ();

                                        item.CountryDescriptor = fv + "1111";
                                        item.EducationOrganization = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(
                                    a => schoolEntityForUpdate.EducationOrganizationInternationalAddresses.Add(a));
                        }
                    }
                    else if (filterPropertyName == "SchoolCategoryDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.SchoolCategories.Clear();
                        schoolEntityForUpdate.SchoolCategories.Clear();

                        // Add only conforming/included (or non-conforming excluded) item to the resource
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<SchoolCategory_Full>();
                                    item.SchoolCategoryDescriptor = fv;
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.SchoolCategories.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolCategory_Entity>();
                                        item.SchoolCategoryDescriptor = fv + "1111";
                                        item.School = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.SchoolCategories.Add(a));
                        }
                    }
                    else if (filterPropertyName == "GradeLevelDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.SchoolGradeLevels.Clear();
                        schoolEntityForUpdate.SchoolGradeLevels.Clear();

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<SchoolGradeLevel_Full>();
                                    item.GradeLevelDescriptor = fv;
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.SchoolGradeLevels.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolGradeLevel_Entity>();
                                        item.GradeLevelDescriptor = fv + "1111";
                                        item.School = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.SchoolGradeLevels.Add(a));
                        }
                    }
                }
                else if (valuesAreExcluded && conforming || valuesAreIncluded && nonConforming)
                {
                    if (filterPropertyName == "AddressTypeDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.EducationOrganizationAddresses.Clear();
                        schoolEntityForUpdate.EducationOrganizationAddresses.Clear();

                        // Add only non-conforming (not included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<EducationOrganizationAddress_Full>();
                                    item.AddressTypeDescriptor = fv + "9999";
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.EducationOrganizationAddresses.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolEntity>()
                                                                    .EducationOrganizationAddresses.First();

                                        item.AddressTypeDescriptor = fv;
                                        item.EducationOrganization = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.EducationOrganizationAddresses.Add(a));
                        }
                    }
                    else if (filterPropertyName == "CountryDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.EducationOrganizationInternationalAddresses.Clear();
                        schoolEntityForUpdate.EducationOrganizationInternationalAddresses.Clear();

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                v =>
                                {
                                    var item =
                                        testObjectFactory.Create<EducationOrganizationInternationalAddress_Full>();

                                    item.CountryDescriptor = v + "9999";
                                    return item;
                                })
                           .ForEach(
                                a => fullSchoolResourceForUpdate.EducationOrganizationInternationalAddresses.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item =
                                            testObjectFactory.Create<EducationOrganizationInternationalAddress_Entity>
                                                ();

                                        item.CountryDescriptor = fv;
                                        item.EducationOrganization = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(
                                    a => schoolEntityForUpdate.EducationOrganizationInternationalAddresses.Add(a));
                        }
                    }
                    else if (filterPropertyName == "SchoolCategoryDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.SchoolCategories.Clear();
                        schoolEntityForUpdate.SchoolCategories.Clear();

                        // Add only non-conforming (not included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<SchoolCategory_Full>();
                                    item.SchoolCategoryDescriptor = fv + "9999";
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.SchoolCategories.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolCategory_Entity>();
                                        item.SchoolCategoryDescriptor = fv;
                                        item.School = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.SchoolCategories.Add(a));
                        }
                    }
                    else if (filterPropertyName == "GradeLevelDescriptor")
                    {
                        // Remove all items
                        fullSchoolResourceForUpdate.SchoolGradeLevels.Clear();
                        schoolEntityForUpdate.SchoolGradeLevels.Clear();

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                v =>
                                {
                                    var item = testObjectFactory.Create<SchoolGradeLevel_Full>();
                                    item.GradeLevelDescriptor = v + "9999";
                                    return item;
                                })
                           .ForEach(a => fullSchoolResourceForUpdate.SchoolGradeLevels.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<SchoolGradeLevel_Entity>();
                                        item.GradeLevelDescriptor = fv;
                                        item.School = schoolEntityForUpdate;
                                        return item;
                                    })
                               .ForEach(a => schoolEntityForUpdate.SchoolGradeLevels.Add(a));
                        }
                    }
                }
            }

            if (conforming)
            {
                // Make a copy of the entity for subsequent comparison
                var originalSchoolEntity = new SchoolEntity();
                schoolEntityForUpdate.MapTo(originalSchoolEntity, null);

                // Save into the ScenarioContext the targeted entity and the prepared school resource for 
                // subsequent inspection to ensure values are synched to entity correctly, and existing 
                // values disallowed by the filter are intact on the entity.
                ScenarioContext.Current.Set(
                    ((FakeRepository<SchoolEntity>) getSchoolEntityById).EntitiesById[id],
                    "currentSchoolEntity");

                ScenarioContext.Current.Set(originalSchoolEntity, "originalSchoolEntity");
                ScenarioContext.Current.Set(fullSchoolResourceForUpdate, "schoolResourceForUpdate");
            }

            // Modify the client to specify that we're sending a profile-specific resource
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), contentType);

            //build content
            HttpContent putRequestContent = new StringContent(
                JsonConvert.SerializeObject(fullSchoolResourceForUpdate),
                Encoding.UTF8,
                contentType);

            return putRequestContent;
        }

        private static HttpContent GetStudentAssessmentPutRequestContent(
            Guid id,
            string contentType,
            ConformanceType conformanceType,
            IncludedOrExcluded includedOrExcluded,
            IWindsorContainer container,
            HttpClient httpClient)
        {
            // Get the "GetById" repository operation
            var getStudentAssessmentEntityById = container.Resolve<IGetEntityById<StudentAssessment_Entity>>();

            // Retrieve an "existing" entity
            var studentAssessmentForUpdate = getStudentAssessmentEntityById.GetByIdAsync(id, CancellationToken.None)
                .GetResultSafely();

            // Map the "updated" entity to a full School resource
            var fullStudentAssessmentResourceForUpdate = new StudentAssessmentResource_Full();
            studentAssessmentForUpdate.MapTo(fullStudentAssessmentResourceForUpdate, null);

            //empty the id for the Post operation
            fullStudentAssessmentResourceForUpdate.Id = Guid.Empty;

            var profileElt = ScenarioContext.Current.Get<XElement>("ProfileXElement");
            string resourceName = "StudentAssessment";
            bool inclusiveFilter = includedOrExcluded == IncludedOrExcluded.Included;

            // Assumption: For simplicity (until otherwise required) we're only supporting specific properties
            Func<string, bool> filterPropertyNamePredicate = x =>
                                                                 x.EqualsIgnoreCase("AssessmentReportingMethodDescriptor")
                                                                 || x.EqualsIgnoreCase("PerformanceLevelDescriptor");

            var filteredCollectionElts =
                GetFilteredCollectionElts(
                        profileElt,
                        resourceName,
                        false,
                        filterPropertyNamePredicate,
                        inclusiveFilter)
                   .ToList();

            if (!filteredCollectionElts.Any())
            {
                throw new InvalidOperationException(
                    "Assumptions have been made for simplicity of the tests.  No collection filtered on 'AssessmentReportingMethodType' or 'PerformanceLevelDescriptor' was found.");
            }

            bool conforming = conformanceType == ConformanceType.Conforming;
            bool valuesAreIncluded = includedOrExcluded == IncludedOrExcluded.Included;

            bool nonConforming = conformanceType == ConformanceType.NonConforming;
            bool valuesAreExcluded = includedOrExcluded == IncludedOrExcluded.Excluded;

            foreach (var filteredCollectionElt in filteredCollectionElts)
            {
                var filterElt = filteredCollectionElt.Element("Filter");

                string filterPropertyName = filterElt.Attribute("propertyName")
                                                     .Value;

                // Get the filter's values
                var filterValues = filterElt
                                  .Elements("Value")
                                  .Select(x => x.Value)
                                  .ToList();

                var testObjectFactory = container.Resolve<ITestObjectFactory>();

                // Defensive programming
                if (!(conforming || nonConforming) || !(valuesAreIncluded || valuesAreExcluded))
                {
                    throw new NotSupportedException(
                        "Both members of conforming/non-conforming or included/excluded have been set to false, indicating a change of mutual exclusivity expectations.");
                }

                if (valuesAreIncluded && conforming || valuesAreExcluded && nonConforming)
                {
                    if (filterPropertyName == "AssessmentReportingMethodDescriptor")
                    {
                        // Remove all items
                        fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentScoreResults.Clear());

                        studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentScoreResults.Clear());

                        // Add only conforming/included (or non-conforming excluded) items to the resource
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<ScoreResult_Full>();
                                    item.AssessmentReportingMethodDescriptor = fv;
                                    return item;
                                })
                           .ForEach(
                                a => fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                           .StudentAssessmentStudentObjectiveAssessmentScoreResults.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<ScoreResult_Entity>();
                                        item.AssessmentReportingMethodDescriptor = fv + "1111";

                                        item.StudentAssessmentStudentObjectiveAssessment =
                                            studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First();

                                        return item;
                                    })
                               .ForEach(
                                    a => studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                   .StudentAssessmentStudentObjectiveAssessmentScoreResults.Add(a));
                        }
                    }
                    else if (filterPropertyName == "PerformanceLevelDescriptor")
                    {
                        // Remove all items
                        fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Clear());

                        studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Clear());

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item =
                                        testObjectFactory.Create<PerformanceLevel_Full>();

                                    item.PerformanceLevelDescriptor = fv;
                                    return item;
                                })
                           .ForEach(
                                a => fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                           .StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item =
                                            testObjectFactory.Create<PerformanceLevel_Entity>
                                                ();

                                        item.PerformanceLevelDescriptor = fv + "1111";

                                        item.StudentAssessmentStudentObjectiveAssessment =
                                            studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First();

                                        return item;
                                    })
                               .ForEach(
                                    a => studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                   .StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Add(a));
                        }
                    }
                }
                else if (valuesAreExcluded && conforming || valuesAreIncluded && nonConforming)
                {
                    if (filterPropertyName == "AssessmentReportingMethodDescriptor")
                    {
                        // Remove all items
                        fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentScoreResults.Clear());

                        studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentScoreResults.Clear());

                        // Add only non-conforming (not included) items
                        filterValues
                           .Select(
                                fv =>
                                {
                                    var item = testObjectFactory.Create<ScoreResult_Full>();
                                    item.AssessmentReportingMethodDescriptor = fv + "9999";
                                    return item;
                                })
                           .ForEach(
                                a => fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                           .StudentAssessmentStudentObjectiveAssessmentScoreResults.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item = testObjectFactory.Create<ScoreResult_Entity>();
                                        item.AssessmentReportingMethodDescriptor = fv;

                                        item.StudentAssessmentStudentObjectiveAssessment =
                                            studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First();

                                        return item;
                                    })
                               .ForEach(
                                    a => studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                   .StudentAssessmentStudentObjectiveAssessmentScoreResults.Add(a));
                        }
                    }
                    else if (filterPropertyName == "PerformanceLevelDescriptor")
                    {
                        // Remove all items
                        fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Clear());

                        studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.ForEach(
                            x => x.StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Clear());

                        // Add only conforming (included) items
                        filterValues
                           .Select(
                                v =>
                                {
                                    var item =
                                        testObjectFactory.Create<PerformanceLevel_Full>();

                                    item.PerformanceLevelDescriptor = v + "9999";
                                    return item;
                                })
                           .ForEach(
                                a => fullStudentAssessmentResourceForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                           .StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Add(a));

                        // Add some values to entity that are disallowed by the filter to ensure they are ignored (rather than processed and deleted) during persistence
                        if (conforming)
                        {
                            filterValues
                               .Select(
                                    fv =>
                                    {
                                        var item =
                                            testObjectFactory.Create<PerformanceLevel_Entity>
                                                ();

                                        item.PerformanceLevelDescriptor = fv;

                                        item.StudentAssessmentStudentObjectiveAssessment =
                                            studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First();

                                        return item;
                                    })
                               .ForEach(
                                    a => studentAssessmentForUpdate.StudentAssessmentStudentObjectiveAssessments.First()
                                                                   .StudentAssessmentStudentObjectiveAssessmentPerformanceLevels.Add(a));
                        }
                    }
                }
            }

            if (conforming)
            {
                // Make a copy of the entity for subsequent comparison
                var originalStudentAssessmentEntity = new StudentAssessment_Entity();
                studentAssessmentForUpdate.MapTo(originalStudentAssessmentEntity, null);

                // Save into the ScenarioContext the targeted entity and the prepared school resource for 
                // subsequent inspection to ensure values are synched to entity correctly, and existing 
                // values disallowed by the filter are intact on the entity.
                ScenarioContext.Current.Set(
                    ((FakeRepository<StudentAssessment_Entity>) getStudentAssessmentEntityById).EntitiesById[id],
                    "currentStudentAssessmentEntity");

                ScenarioContext.Current.Set(originalStudentAssessmentEntity, "originalStudentAssessmentEntity");
                ScenarioContext.Current.Set(fullStudentAssessmentResourceForUpdate, "studentAssessmentResourceForUpdate");
            }

            // Modify the client to specify that we're sending a profile-specific resource
            httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), contentType);

            //build content
            HttpContent putRequestContent = new StringContent(
                JsonConvert.SerializeObject(fullStudentAssessmentResourceForUpdate),
                Encoding.UTF8,
                contentType);

            return putRequestContent;
        }

      
        private static IList<XElement> GetFilteredCollectionElts(
            XElement profileElt,
            string resourceName,
            bool isReadContentType,
            Func<string, bool> filterPropertyNamePredicate,
            bool inclusiveFilters)
        {
            // Get the filtered collections
            var filteredCollectionElts = profileElt.XPathSelectElements(
                                                        string.Format(
                                                            "Resource[@name='{0}']/{1}ContentType//Collection[Filter[@filterMode='{2}Only']]",
                                                            resourceName,
                                                            isReadContentType
                                                                ? "Read"
                                                                : "Write",
                                                            inclusiveFilters
                                                                ? "Include"
                                                                : "Exclude"))

                                                    // Don't process filters against properties we're not interested in right now.
                                                   .Where(
                                                        e => filterPropertyNamePredicate(
                                                            e.Element("Filter")
                                                             .Attribute("propertyName")
                                                             .Value))
                                                   .ToList();

            return filteredCollectionElts;
        }

       

        [StepArgumentTransformation(@"(conforming|non-conforming)")]
        public ConformanceType ConformanceTypeTransform(string conformanceTypeText)
        {
            string valueText = conformanceTypeText.Replace("-", string.Empty);

            return (ConformanceType) Enum.Parse(typeof(ConformanceType), valueText, ignoreCase: true);
        }
    }

    public enum IncludedOrExcluded
    {
        Included = 1,
        Excluded
    }

    public enum ConformanceType
    {
        Conforming = 1,
        NonConforming
    }
}
