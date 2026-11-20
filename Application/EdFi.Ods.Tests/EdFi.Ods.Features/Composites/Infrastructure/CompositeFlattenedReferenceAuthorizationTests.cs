// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;
using FakeItEasy;
using NHibernate;
using NHibernate.Transform;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Composites.Infrastructure;

/// <summary>
/// Processes a composite definition with flattened references through the <see cref="CompositeDefinitionProcessor{TBuilderContext,TBuildResult}" />,
/// the <see cref="HqlBuilderAuthorizationDecorator" /> and the <see cref="HqlBuilder" />, and then shapes the rows returned for the
/// generated queries with the <see cref="CompositeResourceResponseProvider" />, to show that the authorization flags projected by the
/// builder are the ones the response provider uses, for both the root query and child queries (ODS-6895).
/// </summary>
[TestFixture]
public class CompositeFlattenedReferenceAuthorizationTests
{
    private const string OwnershipFilterName = "OwnershipFilter";

    private const string CompositeDefinition = """
        <Composite name="Section">
          <BaseResource name="Section">
            <Property name="SectionIdentifier" />
            <ReferencedResource name="CourseOfferingReference" flatten="true">
              <Property name="Id" displayName="courseOfferingId" />
              <Property name="LocalCourseCode" />
              <Property name="LocalCourseTitle" />
            </ReferencedResource>
            <Collection name="SectionClassPeriods" displayName="classPeriods">
              <ReferencedResource name="ClassPeriodReference" flatten="true">
                <Property name="Id" displayName="classPeriodId" />
                <Property name="ClassPeriodName" />
                <Property name="ClassPeriodTitle" />
              </ReferencedResource>
            </Collection>
          </BaseResource>
        </Composite>
        """;

    // The key columns the rows of the child query are matched to the rows of the root query with
    private const string SectionIdentifierKey = "PK1a_SectionIdentifier";
    private const string LocalCourseCodeKey = "PK1a_LocalCourseCode";

    private readonly List<string> _hqlQueries = new();
    private CompositeQuery _compositeQuery;
    private IList<IDictionary> _items;

    private static readonly Guid CourseOfferingId = Guid.NewGuid();
    private static readonly Guid ClassPeriodId = Guid.NewGuid();

    [OneTimeSetUp]
    public void ProcessCompositeDefinitionAndResults()
    {
        var resourceModel = CreateResourceModel();

        // Rows are returned for the HQL the builder generated, with the values of its authorization flag column
        var rootRows = new List<object>();
        var childRows = new List<object>();

        var session = A.Fake<ISession>();
        var rootQuery = A.Fake<IQuery>();
        var childQuery = A.Fake<IQuery>();
        var childFutureResults = A.Fake<IFutureEnumerable<object>>();

        A.CallTo(() => session.CreateQuery(A<string>._))
            .ReturnsLazily(
                (string hql) =>
                {
                    _hqlQueries.Add(hql);

                    string flagAlias = GetFlagAlias(hql);

                    // The root query is built first
                    if (_hqlQueries.Count == 1)
                    {
                        rootRows.Add(SectionRow("authorized", flagAlias, flagValue: 1));
                        rootRows.Add(SectionRow("denied", flagAlias, flagValue: 0));

                        return rootQuery;
                    }

                    childRows.Add(ClassPeriodRow("authorized", "First period", flagAlias, flagValue: 1));
                    childRows.Add(ClassPeriodRow("authorized", "Second period", flagAlias, flagValue: 0));

                    return childQuery;
                });

        A.CallTo(() => rootQuery.SetResultTransformer(A<IResultTransformer>._)).Returns(rootQuery);
        A.CallTo(() => rootQuery.List<object>()).Returns(rootRows);

        A.CallTo(() => childQuery.SetResultTransformer(A<IResultTransformer>._)).Returns(childQuery);
        A.CallTo(() => childQuery.Future<object>()).Returns(childFutureResults);
        // CompositeQuery enumerates the results as an IEnumerable<object>
        A.CallTo(() => ((IEnumerable<object>) childFutureResults).GetEnumerator()).ReturnsLazily(() => childRows.GetEnumerator());

        var sessionFactory = A.Fake<ISessionFactory>();
        A.CallTo(() => sessionFactory.GetCurrentSession()).Returns(session);

        var hqlBuilder = new HqlBuilder(
            sessionFactory,
            A.Fake<IDescriptorResolver>(),
            A.Fake<IResourceJoinPathExpressionProcessor>(),
            A.Fake<IParameterListSetter>(),
            A.Fake<IPersonEntitySpecification>(),
            A.Fake<IPersonUsiResolver>());

        var decorator = new HqlBuilderAuthorizationDecorator(
            hqlBuilder,
            CreateAuthorizationPlanFactory(),
            CreateFilterDefinitionProvider(),
            A.Fake<IAuthorizationContextProvider>());

        var processor = new CompositeDefinitionProcessor<HqlBuilderContext, CompositeQuery>(decorator);

        _compositeQuery = processor.Process(XElement.Parse(CompositeDefinition), resourceModel, CreateBuilderContext());

        var responseProvider = new CompositeResourceResponseProvider(
            sessionFactory,
            processor,
            A.Fake<IResourceModelProvider>(),
            A.Fake<IFieldsExpressionParser>(),
            A.Fake<IProfileResourceModelProvider>(),
            A.Fake<IApiClientContextProvider>(),
            A.Fake<IPersonEntitySpecification>(),
            A.Fake<IPersonUniqueIdResolver>());

        _items = (IList<IDictionary>) responseProvider.ProcessResults(
            _compositeQuery,
            null,
            Newtonsoft.Json.NullValueHandling.Ignore,
            new UniqueIdLookupsByUsiContext());
    }

    [Test]
    public void Should_project_an_authorization_flag_for_each_flattened_reference()
    {
        AssertHelper.All(
            () => _hqlQueries.Count.ShouldBe(2),
            () => _hqlQueries.ShouldAllBe(hql => hql.Contains("then 1 else 0 end as __Auth_")));
    }

    [Test]
    public void Should_subject_the_non_identifying_fields_of_the_flattened_reference_to_its_flag()
    {
        string flagAlias = GetFlagAlias(_hqlQueries[0]);

        var flagsByField = _compositeQuery.AuthorizationFlagAliasesByFieldAlias;

        AssertHelper.All(
            () => flagsByField["localCourseTitle"].ShouldBe([flagAlias]),
            // The reference's id is not an identifying property, so it's subject to the flag
            () => flagsByField["courseOfferingId"].ShouldBe([flagAlias]),
            // The reference's identifying properties are the containing row's foreign key values
            () => flagsByField.ContainsKey("localCourseCode").ShouldBeFalse(),
            // The containing resource's fields are authorized with the containing resource
            () => flagsByField.ContainsKey("sectionIdentifier").ShouldBeFalse(),
            () => flagsByField.Count.ShouldBe(2));
    }

    [Test]
    public void Should_subject_the_non_identifying_fields_of_a_flattened_reference_in_a_collection_to_its_flag()
    {
        string flagAlias = GetFlagAlias(_hqlQueries[1]);

        var flagsByField = _compositeQuery.ChildQueries.Single().AuthorizationFlagAliasesByFieldAlias;

        AssertHelper.All(
            () => flagsByField["classPeriodTitle"].ShouldBe([flagAlias]),
            () => flagsByField["classPeriodId"].ShouldBe([flagAlias]),
            () => flagsByField.ContainsKey("classPeriodName").ShouldBeFalse(),
            () => flagsByField.Count.ShouldBe(2));
    }

    [Test]
    public void Should_return_all_the_values_of_an_authorized_reference()
    {
        var item = GetSection("authorized");

        AssertHelper.All(
            () => item["localCourseCode"].ShouldBe("ALG-1"),
            () => item["localCourseTitle"].ShouldBe("Algebra I"),
            () => item["courseOfferingId"].ShouldBe(CourseOfferingId.ToString("N")));
    }

    [Test]
    public void Should_return_only_the_key_values_of_an_unauthorized_reference()
    {
        var item = GetSection("denied");

        AssertHelper.All(
            () => item["localCourseCode"].ShouldBe("ALG-1"),
            () => item.Contains("localCourseTitle").ShouldBeFalse(),
            () => item.Contains("courseOfferingId").ShouldBeFalse(),
            () => item.Keys.Cast<string>().ShouldAllBe(k => !k.StartsWith("__")));
    }

    [Test]
    public void Should_return_only_the_key_values_of_an_unauthorized_reference_in_a_collection()
    {
        var classPeriods = ((IEnumerable) GetSection("authorized")["classPeriods"]).Cast<IDictionary>().ToList();

        var authorized = classPeriods.Single(x => (string) x["classPeriodName"] == "First period");
        var denied = classPeriods.Single(x => (string) x["classPeriodName"] == "Second period");

        AssertHelper.All(
            () => classPeriods.Count.ShouldBe(2),
            () => authorized["classPeriodTitle"].ShouldBe("Title of First period"),
            () => authorized["classPeriodId"].ShouldBe(ClassPeriodId.ToString("N")),
            () => denied.Contains("classPeriodTitle").ShouldBeFalse(),
            () => denied.Contains("classPeriodId").ShouldBeFalse(),
            () => denied.Keys.Cast<string>().ShouldAllBe(k => !k.StartsWith("__")));
    }

    private IDictionary GetSection(string sectionIdentifier)
        => _items.Single(x => (string) x["sectionIdentifier"] == sectionIdentifier);

    private static string GetFlagAlias(string hql)
        => Regex.Match(hql, @"end as (?<alias>\w+)").Groups["alias"].Value;

    private static Hashtable SectionRow(string sectionIdentifier, string flagAlias, int flagValue)
        => new()
        {
            { "__BaseEntityId__", Guid.NewGuid() },
            { SectionIdentifierKey, sectionIdentifier },
            { LocalCourseCodeKey, "ALG-1" },
            { "sectionIdentifier", sectionIdentifier },
            { "courseOfferingId", CourseOfferingId },
            { "localCourseCode", "ALG-1" },
            { "localCourseTitle", "Algebra I" },
            { flagAlias, flagValue },
        };

    private static Hashtable ClassPeriodRow(string sectionIdentifier, string classPeriodName, string flagAlias, int flagValue)
        => new()
        {
            { SectionIdentifierKey, sectionIdentifier },
            { LocalCourseCodeKey, "ALG-1" },
            { "PK2a_ClassPeriodName", classPeriodName },
            { "classPeriodId", ClassPeriodId },
            { "classPeriodName", classPeriodName },
            { "classPeriodTitle", $"Title of {classPeriodName}" },
            { flagAlias, flagValue },
        };

    private static HqlBuilderContext CreateBuilderContext()
        => new(
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder(),
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
            null,
            1,
            new Dictionary<string, CompositeSpecificationParameter>(StringComparer.InvariantCultureIgnoreCase),
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase),
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase),
            new AliasGenerator(CompositeDefinitionHelper.AliasPrefix));

    private static IDataManagementAuthorizationPlanFactory CreateAuthorizationPlanFactory()
    {
        var authorizationPlanFactory = A.Fake<IDataManagementAuthorizationPlanFactory>();

        // The containing resource is authorized with no filtering
        A.CallTo(() => authorizationPlanFactory.CreateAuthorizationPlan(A<Resource>._, RequestActions.ReadActionUri))
            .Returns(new DataManagementAuthorizationPlan { Filtering = Array.Empty<AuthorizationStrategyFiltering>() });

        // The referenced resources are authorized with ownership-based filtering
        A.CallTo(
                () => authorizationPlanFactory.CreateAuthorizationPlan(
                    A<Resource>.That.Matches(r => r.Name == "CourseOffering" || r.Name == "ClassPeriod"),
                    RequestActions.ReadActionUri))
            .Returns(
                new DataManagementAuthorizationPlan
                {
                    Filtering =
                    [
                        new AuthorizationStrategyFiltering
                        {
                            Operator = FilterOperator.Or,
                            Filters =
                            [
                                new AuthorizationFilterContext
                                {
                                    FilterName = OwnershipFilterName,
                                    ClaimParameterName = "CreatedByOwnershipTokenId",
                                    ClaimEndpointValues = [(short) 1],
                                }
                            ]
                        }
                    ]
                });

        return authorizationPlanFactory;
    }

    private static IAuthorizationFilterDefinitionProvider CreateFilterDefinitionProvider()
    {
        var filterDefinitionProvider = A.Fake<IAuthorizationFilterDefinitionProvider>();

        var ownershipDefinition = new AuthorizationFilterDefinition(
            OwnershipFilterName,
            "({currentAlias}.CreatedByOwnershipTokenId IS NOT NULL AND {currentAlias}.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
            null, null, null);

        A.CallTo(() => filterDefinitionProvider.TryGetAuthorizationFilterDefinition(OwnershipFilterName, out ownershipDefinition))
            .Returns(true)
            .AssignsOutAndRefParameters(ownershipDefinition);

        return filterDefinitionProvider;
    }

    private static IResourceModel CreateResourceModel()
    {
        var domainModelBuilder = new DomainModelBuilder();

        var schema = EdFiConventions.PhysicalSchemaName;

        domainModelBuilder.AddSchema(new SchemaDefinition(EdFiConventions.LogicalName, schema));

        // Like the Ed-Fi model, "Id" is not part of the primary key, but has an alternate key of its own
        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "CourseOffering",
                [
                    new EntityPropertyDefinition("LocalCourseCode", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("LocalCourseTitle", new PropertyType(DbType.String)),
                    new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid)),
                ],
                [
                    new EntityIdentifierDefinition("CourseOffering_PK", ["LocalCourseCode"], isPrimary: true),
                    new EntityIdentifierDefinition("CourseOffering_UI_Id", ["Id"]),
                ]));

        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "ClassPeriod",
                [
                    new EntityPropertyDefinition("ClassPeriodName", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("ClassPeriodTitle", new PropertyType(DbType.String)),
                    new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid)),
                ],
                [
                    new EntityIdentifierDefinition("ClassPeriod_PK", ["ClassPeriodName"], isPrimary: true),
                    new EntityIdentifierDefinition("ClassPeriod_UI_Id", ["Id"]),
                ]));

        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "Section",
                [
                    new EntityPropertyDefinition("SectionIdentifier", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("LocalCourseCode", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("Id", new PropertyType(DbType.Guid)),
                ],
                [
                    new EntityIdentifierDefinition("Section_PK", ["SectionIdentifier", "LocalCourseCode"], isPrimary: true),
                    new EntityIdentifierDefinition("Section_UI_Id", ["Id"]),
                ]));

        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "SectionClassPeriod",
                [
                    new EntityPropertyDefinition("SectionIdentifier", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("LocalCourseCode", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("ClassPeriodName", new PropertyType(DbType.String), isIdentifying: true),
                ],
                [
                    new EntityIdentifierDefinition(
                        "SectionClassPeriod_PK",
                        ["SectionIdentifier", "LocalCourseCode", "ClassPeriodName"],
                        isPrimary: true),
                ]));

        domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName(schema, "CourseOffering"), Array.Empty<FullName>()));
        domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName(schema, "ClassPeriod"), Array.Empty<FullName>()));

        domainModelBuilder.AddAggregate(
            new AggregateDefinition(new FullName(schema, "Section"), [new FullName(schema, "SectionClassPeriod")]));

        domainModelBuilder.AddAssociation(
            new AssociationDefinition(
                new FullName(schema, "FK_Section_CourseOffering"),
                Cardinality.OneToZeroOrMore,
                new FullName(schema, "CourseOffering"),
                [StringKey("LocalCourseCode")],
                new FullName(schema, "Section"),
                [StringKey("LocalCourseCode")],
                isIdentifying: true,
                isRequired: true));

        domainModelBuilder.AddAssociation(
            new AssociationDefinition(
                new FullName(schema, "FK_SectionClassPeriod_Section"),
                Cardinality.OneToZeroOrMore,
                new FullName(schema, "Section"),
                [StringKey("SectionIdentifier"), StringKey("LocalCourseCode")],
                new FullName(schema, "SectionClassPeriod"),
                [StringKey("SectionIdentifier"), StringKey("LocalCourseCode")],
                isIdentifying: true,
                isRequired: true));

        domainModelBuilder.AddAssociation(
            new AssociationDefinition(
                new FullName(schema, "FK_SectionClassPeriod_ClassPeriod"),
                Cardinality.OneToZeroOrMore,
                new FullName(schema, "ClassPeriod"),
                [StringKey("ClassPeriodName")],
                new FullName(schema, "SectionClassPeriod"),
                [StringKey("ClassPeriodName")],
                isIdentifying: true,
                isRequired: true));

        return new ResourceModel(domainModelBuilder.Build());

        static EntityPropertyDefinition StringKey(string propertyName)
            => new(propertyName, new PropertyType(DbType.String), isIdentifying: true);
    }
}
