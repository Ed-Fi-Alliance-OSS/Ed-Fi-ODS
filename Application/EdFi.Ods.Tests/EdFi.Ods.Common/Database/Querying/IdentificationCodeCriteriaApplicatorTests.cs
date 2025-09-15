// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Providers.Queries.Criteria;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database.Querying
{
    [TestFixture]
    public class IdentificationCodeAggregateRootQueryCriteriaApplicatorTests
    {
        private IResourceModel _resourceModel;
        private IResourceModelProvider _resourceModelProvider;
        private readonly string identificationCodeTableAlias =
            IdentificationCodeAggregateRootQueryCriteriaApplicator.IdentificationCodeEntityTableAlias();

        [SetUp]
        public void SetUp()
        {
            _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;
            _resourceModel = _resourceModelProvider.GetResourceModel();
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceDoesNotIdentificationCodeAndNoAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.calendar");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int> ();
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            List<ResourceProperty> identificationCodeProperties = null;

            var additionalParameters = new Dictionary<string, string>();

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceDoesNotIdentificationCodeAndAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.calendar");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int> ();
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            List<ResourceProperty> identificationCodeProperties = null;

            var additionalParameters =
                new Dictionary<string, string>() { { "IdentificationCode", "SomeIdentificationCodeValue" } };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceHasIdentificationCodeAndNoAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int>
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    }
                };
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));
            
            List<ResourceProperty> identificationCodeProperties;

            var additionalParameters = new Dictionary<string, string>();

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int>
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    }
                };
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            List<ResourceProperty> identificationCodeProperties = null;

            string identificationCodeParameterValue = "ALG-1";

            var additionalParameters =
                new Dictionary<string, string>() { { "IdentificationCode", identificationCodeParameterValue } };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(
                    resourceWithIdentificationCodeProperty.CollectionByName["CourseIdentificationCodes"].ItemType.Properties
                        .Where(
                            property => property.PropertyName.Equals("IdentificationCode") ||
                                        !property.EntityProperty.IsPredefinedProperty()).ToList());

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS {identificationCodeTableAlias} 
                                        ON r.CourseCode = {identificationCodeTableAlias}.CourseCode 
                                               AND r.EducationOrganizationId = {identificationCodeTableAlias}.EducationOrganizationId 
                                    WHERE {identificationCodeTableAlias}.IdentificationCode = @p0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<string>("@p0").ShouldBe(identificationCodeParameterValue)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingDescriptorTypeAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int>
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    }
                };
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            List<ResourceProperty> identificationCodeProperties = null;

            var descriptorParameterDescriptorName = "CourseIdentificationSystemDescriptor";
            var descriptorParameterDescriptorUri = "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA";

            var additionalParameters = new Dictionary<string, string>()
            {
                { descriptorParameterDescriptorName, descriptorParameterDescriptorUri }
            };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(
                    resourceWithIdentificationCodeProperty.CollectionByName["CourseIdentificationCodes"].ItemType.Properties
                        .Where(
                            property => property.PropertyName.Equals("IdentificationCode") ||
                                        !property.EntityProperty.IsPredefinedProperty()).ToList());

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS {identificationCodeTableAlias} 
                                        ON r.CourseCode = {identificationCodeTableAlias}.CourseCode 
                                               AND r.EducationOrganizationId = {identificationCodeTableAlias}.EducationOrganizationId 
                                    WHERE {identificationCodeTableAlias}.CourseIdentificationSystemDescriptorId = @p0"
                            .NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<int>("@p0").ShouldBe(
                    descriptorIdMappings[
                        (descriptorParameterDescriptorName, descriptorParameterDescriptorUri)])
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingNonExistentDescriptorAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeCollection = _resourceModel.GetResourceByFullName("edfi.course");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int>
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    }
                };
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            var identificationCodePropertiesForResource =
                IdentificationCodePropertiesForResourceWithAnIdentificationCodeCollection(
                    resourceWithIdentificationCodeCollection);

            List<ResourceProperty> identificationCodeProperties = null;

            var descriptorParameterDescriptorName = "CourseIdentificationSystemDescriptor";
            var descriptorParameterDescriptorUri = "uri://ed-fi.org/CourseIdentificationSystemDescriptor#NonExistentCode";

            var additionalParameters = new Dictionary<string, string>()
            {
                { descriptorParameterDescriptorName, descriptorParameterDescriptorUri }
            };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeCollection, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(identificationCodePropertiesForResource);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeCollection.Entity, A.Fake<AggregateRootWithCompositeKey>(),
                additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS {identificationCodeTableAlias} 
                                        ON r.CourseCode = {identificationCodeTableAlias}.CourseCode 
                                               AND r.EducationOrganizationId = {identificationCodeTableAlias}.EducationOrganizationId 
                                    WHERE 1 = 0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMultipleAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeCollection = _resourceModel.GetResourceByFullName("edfi.course");
            
            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int>
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    }
                };
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));

            var identificationCodePropertiesForResource =
                IdentificationCodePropertiesForResourceWithAnIdentificationCodeCollection(
                    resourceWithIdentificationCodeCollection);

            var descriptorParameterDescriptorName = "CourseIdentificationSystemDescriptor";
            var descriptorParameterDescriptorUri = "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA";

            var identificationCodeParameterValue = "ALG-2";

            var additionalParameters = new Dictionary<string, string>()
            {
                { descriptorParameterDescriptorName, descriptorParameterDescriptorUri },
                { "IdentificationCode", identificationCodeParameterValue }
            };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            List<ResourceProperty> identificationCodeProperties;

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeCollection, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(identificationCodePropertiesForResource);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeCollection.Entity, A.Fake<AggregateRootWithCompositeKey>(),
                additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM 
                            INNER JOIN edfi.CourseIdentificationCode AS {identificationCodeTableAlias} 
                                ON r.CourseCode = {identificationCodeTableAlias}.CourseCode 
                                       AND r.EducationOrganizationId = {identificationCodeTableAlias}.EducationOrganizationId 
                            WHERE {identificationCodeTableAlias}.CourseIdentificationSystemDescriptorId = @p0 
                              AND {identificationCodeTableAlias}.IdentificationCode = @p1".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.ParameterNames.ShouldContain("p1"),
                () => actualParameters.Get<int>("@p0").ShouldBe(
                    descriptorIdMappings[
                        (descriptorParameterDescriptorName, descriptorParameterDescriptorUri)]),
                () => actualParameters.Get<string>("@p1").ShouldBe(identificationCodeParameterValue)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer)]
        [TestCase(DatabaseEngineEnum.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenDerivedResourceHasIdentificationCodeAndMatchingAdditionalParametersSupplied(
            DatabaseEngineEnum databaseEngineEnum)
        {
            //Arrange
            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();
            var standardVersion = domainModel.Schemas[0].Version;

            var parts = standardVersion.Split('.');
            var majorVersion = int.Parse(parts[0]);

            if (majorVersion >= 6)
            {
                Assert.Ignore($"Skipped: Test not applicable for ODS version {standardVersion}");
            }

            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeCollection = _resourceModel.GetResourceByFullName("edfi.school");

            var fakeDescriptorResolver = A.Fake<IDescriptorResolver>();
            var descriptorIdMappings =
                new Dictionary<(string descriptorName, string descriptorUri), int> ();
            A.CallTo(
                () => fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => descriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));
            
            var identificationCodePropertiesForResource =
                IdentificationCodePropertiesForResourceWithAnIdentificationCodeCollection(
                    resourceWithIdentificationCodeCollection);

            List<ResourceProperty> identificationCodeProperties;
            string identificationCodeParameterValue = "1000001";

            var additionalParameters =
                new Dictionary<string, string>() { { "IdentificationCode", identificationCodeParameterValue } };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeCollection, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(identificationCodePropertiesForResource);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeCollection.Entity, A.Fake<AggregateRootWithCompositeKey>(),
                additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        $@"SELECT FROM 
                                    INNER JOIN edfi.EducationOrganizationIdentificationCode AS {identificationCodeTableAlias} 
                                        ON b.EducationOrganizationId = {identificationCodeTableAlias}.EducationOrganizationId 
                                    WHERE {identificationCodeTableAlias}.IdentificationCode = @p0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<string>("@p0").ShouldBe(identificationCodeParameterValue)
            );
        }

        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.course")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.course")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.school")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.school")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.educationorganization")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.educationorganization")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.staff")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.staff")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.coursetranscript")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.coursetranscript")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.studenteducationorganizationassociation")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.studenteducationorganizationassociation")]
        [TestCase(DatabaseEngineEnum.SqlServer, "edfi.learningstandard")]
        [TestCase(DatabaseEngineEnum.PostgreSql, "edfi.learningstandard")]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndAllIdentificationCodeParametersAreSupplied(
            DatabaseEngineEnum databaseEngineEnum, string resourceWithIdentificationCodeCollectionName)
        {
            //Arrange
            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();
            var standardVersion = domainModel.Schemas[0].Version;

            var parts = standardVersion.Split('.');
            var majorVersion = int.Parse(parts[0]);

            if (majorVersion >= 6)
            {
                Assert.Ignore($"Skipped: Test not applicable for ODS version {standardVersion}");
            }

            var q = new QueryBuilder(GetDialectFor(databaseEngineEnum));

            var resourceWithIdentificationCodeCollection =
                _resourceModel.GetResourceByFullName(resourceWithIdentificationCodeCollectionName);

            var identificationCodePropertiesForResource =
                IdentificationCodePropertiesForResourceWithAnIdentificationCodeCollection(
                    resourceWithIdentificationCodeCollection);

            var additionalParameters = new Dictionary<string, string>();

            Dictionary<(string descriptorName, string descriptorUri), int>
                courseIdentificationSystemDescriptorToDescriptorIdMappings = new();

            int descriptorId = 1;

            foreach (var property in identificationCodePropertiesForResource)
            {
                if (property.IsDescriptorUsage)
                {
                    courseIdentificationSystemDescriptorToDescriptorIdMappings.Add(
                        (property.DescriptorName, $"uri://ed-fi.org/{property.DescriptorName}#ValidDescriptorCode"),
                        descriptorId++);

                    additionalParameters.Add(
                        property.DescriptorName, $"uri://ed-fi.org/{property.DescriptorName}#ValidDescriptorCode");
                }
                else
                {
                    switch (property.PropertyType.DbType)
                    {
                        case DbType.Int32:
                            additionalParameters.Add(property.PropertyName, "1234");
                            break;
                        case DbType.String:
                            additionalParameters.Add(property.PropertyName, "AdditionalParameterStringValue");
                            break;
                        default:
                            throw new Exception("Expected DbType.Int32 or DbType.String but got " + property.PropertyType.DbType);
                    }
                }
            }

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            List<ResourceProperty> identificationCodeProperties;

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeCollection, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(identificationCodePropertiesForResource);

            var descriptorResolver = A.Fake<IDescriptorResolver>();

            A.CallTo(
                () => descriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => courseIdentificationSystemDescriptorToDescriptorIdMappings.GetValueOrDefault(
                        (descriptorName, descriptorUri)));

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateRootQueryCriteriaApplicator(
                descriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                global::EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngineEnum.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeCollection.Entity, A.Fake<AggregateRootWithCompositeKey>(),
                additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert

            var identificationCodesEntity = identificationCodePropertiesForResource.First().EntityProperty.Entity;
            var rawSql = template.RawSql.NormalizeSql();

            // Assert that the generated SQL contains an INNER JOIN with the correct IdentificationCode table
            rawSql.ShouldContain(
                $"INNER JOIN {identificationCodesEntity.Schema}.{identificationCodesEntity.TableName(GetDatabaseEngineFor(databaseEngineEnum))} as {identificationCodeTableAlias} ON");

            // Check the generated join criteria for the INNER JOIN of with the IdentificationCodes table

            // Get the equality criteria for the INNER JOIN from the SQL
            var joinEqualityCriteriaInSql = rawSql.Split("ON")[1].Split("WHERE")[0].Split("AND").Select(s => s.Trim()).ToList();

            // Get a list of the inherited identifying properties of the IdentificationCode entity 
            var joinProperties = identificationCodesEntity.Properties
                .Where(p => p.IsIdentifying && p.IsFromParent).ToList();

            // Calculate the equality criteria expected to be present in the join condition based on the IdentificationCode table's columns
            var identificationCodesTableJoinColumns = joinProperties.Select(
                p => p.ColumnName(GetDatabaseEngineFor(databaseEngineEnum), p.PropertyName)).ToList();

            var expectedJoinEqualityCriteria = identificationCodesTableJoinColumns.Select(
                c => $"{resourceWithIdentificationCodeCollection.Entity.RootTableAlias()}.{c} = {identificationCodeTableAlias}.{c}");

            // Assert that the equality criteria in the join condition are unique
            joinEqualityCriteriaInSql.ShouldBeUnique();

            // Assert that the equality criteria in the join condition in the SQL exactly match the expected set
            joinEqualityCriteriaInSql.Except(expectedJoinEqualityCriteria).ShouldBeEmpty();

            // Check the equality criteria in the generated WHERE clause     

            // Get the individual equality criteria from the where clause (excluding the parameter numbers)
            var equalityCriteriaInWhereClause = rawSql.Split("WHERE")[1].Split("AND").Where(s => s.Contains('='))
                .Select(s => s.Substring(0, s.IndexOf("@p", StringComparison.Ordinal) + 2).Trim()).ToList();

            // Calculate the expected to be in the where clause based on the queryable properties of the IdentificationCode 
            var expectedEqualityCriteriaInWhereClause = identificationCodePropertiesForResource.Select(
                    p => $"{identificationCodeTableAlias}.{p.EntityProperty.ColumnName(GetDatabaseEngineFor(databaseEngineEnum), p.PropertyName)} = @p")
                .ToList();

            // Assert that the equality criteria in the where clause are unique
            equalityCriteriaInWhereClause.ShouldBeUnique();

            // Assert that the equality criteria present in the sql where clause exactly match the expected set
            equalityCriteriaInWhereClause.Except(expectedEqualityCriteriaInWhereClause).ShouldBeEmpty();

            // Assert that the query parameters object should be non-null and have an item count equal to the number of queryable IdentificationCode properties
            actualParameters.ShouldNotBeNull();
            actualParameters.ParameterNames.Count().ShouldBe(identificationCodePropertiesForResource.Count);
        }

        public enum DatabaseEngineEnum
        {
            SqlServer,
            PostgreSql,
        }

        private static Dialect GetDialectFor(DatabaseEngineEnum databaseEngineEnum)
        {
            switch (databaseEngineEnum)
            {
                case DatabaseEngineEnum.SqlServer:
                    return new SqlServerDialect();
                case DatabaseEngineEnum.PostgreSql:
                    return new PostgreSqlDialect();
                default:
                    throw new NotSupportedException($"Unsupported database engine '{databaseEngineEnum.ToString()}'.");
            }
        }

        private static DatabaseEngine GetDatabaseEngineFor(DatabaseEngineEnum databaseEngineEnum)
        {
            switch (databaseEngineEnum)
            {
                case DatabaseEngineEnum.SqlServer:
                    return DatabaseEngine.SqlServer;
                case DatabaseEngineEnum.PostgreSql:
                    return DatabaseEngine.Postgres;
                default:
                    throw new NotSupportedException($"Unsupported database engine '{databaseEngineEnum.ToString()}'.");
            }
        }

        private static List<ResourceProperty> IdentificationCodePropertiesForResourceWithAnIdentificationCodeCollection(
            Resource resourceWithIdentificationCodeCollection)
        {
            return resourceWithIdentificationCodeCollection.Collections
                .First(c => c.PropertyName.EndsWith("IdentificationCodes")).ItemType.Properties
                .Where(
                    property => property.PropertyName.Equals("IdentificationCode") ||
                                !property.EntityProperty.IsPredefinedProperty()).ToList();
        }
    }
}
