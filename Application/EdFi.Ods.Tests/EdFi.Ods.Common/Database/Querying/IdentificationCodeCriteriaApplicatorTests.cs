// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Tests.EdFi.Ods.Common.Database.Querying;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Common.Providers.Queries.Criteria.Tests
{
    [TestFixture]
    public class IdentificationCodeAggregateQueryCriteriaApplicatorTests
    {
        private IResourceModel _resourceModel;
        private IDescriptorResolver _fakeDescriptorResolver;
        private IResourceModelProvider _resourceModelProvider;
        private IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;

        private Dictionary<(string descriptorName, string descriptorUri), int>
            _courseIdentificationSystemDescriptorIdMappings =
                new()
                {
                    {
                        ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#SEA"), 1
                    },
                    { ("CourseIdentificationSystemDescriptor", "uri://ed-fi.org/CourseIdentificationSystemDescriptor#Other"), 2 }
                };

        [SetUp]
        public void SetUp()
        {
            _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;
            _resourceModel = _resourceModelProvider.GetResourceModel();
            _fakeDescriptorResolver = A.Fake<IDescriptorResolver>();

            A.CallTo(
                () => _fakeDescriptorResolver.GetDescriptorId(A<string>._, A<string>._)).ReturnsLazily(
                (string descriptorName, string descriptorUri)
                    => _courseIdentificationSystemDescriptorIdMappings.GetValueOrDefault((descriptorName, descriptorUri)));
        }
        
                [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceDoesNotIdentificationCodeAndNoAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.calendar");

            List<ResourceProperty> identificationCodeProperties = null;

            var additionalParameters = new Dictionary<string, string>();

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }
        
        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceDoesNotIdentificationCodeAndAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.calendar");

            List<ResourceProperty> identificationCodeProperties = null;

            var additionalParameters =
                new Dictionary<string, string>() { { "IdentificationCode", "SomeIdentificationCodeValue" } };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        public void
            ApplyAdditionalParameters_NoCriteriaApplied_WhenResourceHasIdentificationCodeAndNoAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            // Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

            List<ResourceProperty> identificationCodeProperties = null;

            var additionalParameters = new Dictionary<string, string>();

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                    resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(false);

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

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

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS idct 
                                        ON r.CourseCode = idct.CourseCode 
                                               AND r.EducationOrganizationId = idct.EducationOrganizationId 
                                    WHERE idct.IdentificationCode = @p0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<string>("@p0").ShouldBe(identificationCodeParameterValue)
            );
        }

        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingDescriptorTypeAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

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

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS idct 
                                        ON r.CourseCode = idct.CourseCode 
                                               AND r.EducationOrganizationId = idct.EducationOrganizationId 
                                    WHERE idct.CourseIdentificationSystemDescriptorId = @p0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<int>("@p0").ShouldBe(
                    _courseIdentificationSystemDescriptorIdMappings[
                        (descriptorParameterDescriptorName, descriptorParameterDescriptorUri)])
            );
        }
        
         [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMatchingNonExistentDescriptorAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

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
                        resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(
                    resourceWithIdentificationCodeProperty.CollectionByName["CourseIdentificationCodes"].ItemType.Properties
                        .Where(
                            property => property.PropertyName.Equals("IdentificationCode") ||
                                        !property.EntityProperty.IsPredefinedProperty()).ToList());

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM 
                                    INNER JOIN edfi.CourseIdentificationCode AS idct 
                                        ON r.CourseCode = idct.CourseCode 
                                               AND r.EducationOrganizationId = idct.EducationOrganizationId 
                                    WHERE 1 = 0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.Count().ShouldBe(0)
            );
        }

        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenResourceHasIdentificationCodeAndMultipleAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.course");

            List<ResourceProperty> identificationCodeProperties = null;

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

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(
                    resourceWithIdentificationCodeProperty.CollectionByName["CourseIdentificationCodes"].ItemType.Properties
                        .Where(
                            property => property.PropertyName.Equals("IdentificationCode") ||
                                        !property.EntityProperty.IsPredefinedProperty()).ToList());

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM 
                            INNER JOIN edfi.CourseIdentificationCode AS idct 
                                ON r.CourseCode = idct.CourseCode 
                                       AND r.EducationOrganizationId = idct.EducationOrganizationId 
                            WHERE idct.CourseIdentificationSystemDescriptorId = @p0 
                              AND idct.IdentificationCode = @p1".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.ParameterNames.ShouldContain("p1"),
                () => actualParameters.Get<int>("@p0").ShouldBe(
                    _courseIdentificationSystemDescriptorIdMappings[
                        (descriptorParameterDescriptorName, descriptorParameterDescriptorUri)]),
                () => actualParameters.Get<string>("@p1").ShouldBe(identificationCodeParameterValue)
            );
        }

        [TestCase(DatabaseEngine.SqlServer)]
        [TestCase(DatabaseEngine.PostgreSql)]
        [Test]
        public void
            ApplyAdditionalParameters_CorrectCriteriaApplied_WhenDerivedResourceHasIdentificationCodeAndMatchingAdditionalParametersSupplied(
            DatabaseEngine databaseEngine)
        {
            //Arrange
            var q = new QueryBuilder(GetDialectFor(databaseEngine));

            var resourceWithIdentificationCodeProperty = _resourceModel.GetResourceByFullName("edfi.school");

            List<ResourceProperty> identificationCodeProperties = null;
            string identificationCodeParameterValue = "1000001";

            var additionalParameters =
                new Dictionary<string, string>() { { "IdentificationCode", identificationCodeParameterValue } };

            IResourceIdentificationCodePropertiesProvider fakeResourceIdentificationCodePropertiesProvider =
                A.Fake<IResourceIdentificationCodePropertiesProvider>();

            A.CallTo(
                    () => fakeResourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                        resourceWithIdentificationCodeProperty, out identificationCodeProperties)).Returns(true)
                .AssignsOutAndRefParameters(
                    resourceWithIdentificationCodeProperty.CollectionByName["EducationOrganizationIdentificationCodes"].ItemType
                        .Properties
                        .Where(
                            property => property.PropertyName.Equals("IdentificationCode") ||
                                        !property.EntityProperty.IsPredefinedProperty()).ToList());

            var identificationCodeAggregateQueryCriteriaApplicator = new IdentificationCodeAggregateQueryCriteriaApplicator(
                _fakeDescriptorResolver, _resourceModelProvider, fakeResourceIdentificationCodePropertiesProvider,
                EdFi.Common.Configuration.DatabaseEngine.TryParseEngine(databaseEngine.ToString()));

            // Act
            identificationCodeAggregateQueryCriteriaApplicator.ApplyAdditionalParameters(
                q, resourceWithIdentificationCodeProperty.Entity, A.Fake<AggregateRootWithCompositeKey>(), additionalParameters);

            var template = q.BuildTemplate();
            var actualParameters = template.Parameters as DynamicParameters;

            // Assert
            actualParameters.ShouldSatisfyAllConditions(
                () => template.RawSql.NormalizeSql()
                    .ShouldBe(
                        @"SELECT FROM 
                                    INNER JOIN edfi.EducationOrganizationIdentificationCode AS idct 
                                        ON b.EducationOrganizationId = idct.EducationOrganizationId 
                                    WHERE idct.IdentificationCode = @p0".NormalizeSql()),
                () => actualParameters.ShouldNotBeNull(),
                () => actualParameters.ParameterNames.ShouldContain("p0"),
                () => actualParameters.Get<string>("@p0").ShouldBe(identificationCodeParameterValue)
            );
        }

        public enum DatabaseEngine
        {
            SqlServer,
            PostgreSql,
        }

        private static Dialect GetDialectFor(DatabaseEngine databaseEngine)
        {
            switch (databaseEngine)
            {
                case DatabaseEngine.SqlServer:
                    return new SqlServerDialect();
                case DatabaseEngine.PostgreSql:
                    return new PostgreSqlDialect();
                default:
                    throw new NotSupportedException($"Unsupported database engine '{databaseEngine.ToString()}'.");
            }
        }
    }
}
