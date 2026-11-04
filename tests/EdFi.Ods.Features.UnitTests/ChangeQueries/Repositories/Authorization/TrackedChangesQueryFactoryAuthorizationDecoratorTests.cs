// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Domain.DomainModelEnhancers;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.ChangeQueries.Repositories.Authorization;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using SecurityAction = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Features.UnitTests.ChangeQueries.Repositories.Authorization;

[TestFixture]
public class TrackedChangesQueryFactoryAuthorizationDecoratorTests
{
    private const string ReadChangesActionUri = "uri://ed-fi.org/api/actions/readChanges";
    private const string EdOrgToEdOrgFilterName = "ClaimEducationOrganizationIdsToEducationOrganizationId";
    private const string EdOrgToStudentFilterName = "ClaimEducationOrganizationIdsToStudentUSI";
    private const string ResponsibilityFilterName = "ClaimEducationOrganizationIdsToStudentUSIThroughResponsibility";
    private const string MandatoryFilterName = "MandatoryTestFilter";
    private const string TrackedChangesTable = "tracked_changes_edfi.StudentSpecialEducationProgramEligibilityAssociation";
    private const string BaselinePredicate = "c.NewStudentUSI IS NULL";

    private static readonly object[] _claimEducationOrganizationIds = [255901L];

    private static IEnumerable<TestCaseData> Dialects()
    {
        yield return new TestCaseData(new SqlServerDialect()).SetArgDisplayNames("SqlServer");
        yield return new TestCaseData(new PostgreSqlDialect()).SetArgDisplayNames("PostgreSql");
    }

    [TestCaseSource(nameof(Dialects))]
    public void Deletes_with_a_multi_filter_strategy_and_another_strategy_should_require_every_filter_of_a_strategy(Dialect dialect)
    {
        // Arrange
        var plan = CreatePlan(EdOrgAndStudentOrResponsibilityStrategies());

        // Act
        string whereClause = GetWhereClause(BuildDeletesQuery(dialect, plan));

        // Assert
        whereClause.ShouldBe($"{BaselinePredicate} AND (({In(dialect, "rba0", 0)} AND {In(dialect, "rba1", 1)}) OR ({In(dialect, "rba2", 2)}))");
    }

    [TestCaseSource(nameof(Dialects))]
    public void Key_changes_with_a_multi_filter_strategy_and_another_strategy_should_require_every_filter_of_a_strategy(Dialect dialect)
    {
        // Arrange
        var plan = CreatePlan(EdOrgAndStudentOrResponsibilityStrategies());

        // Act
        string whereClause = GetWhereClause(BuildKeyChangesQuery(dialect, plan));

        // Assert
        whereClause.ShouldBe($"{BaselinePredicate} AND (({In(dialect, "rba0", 0)} AND {In(dialect, "rba1", 1)}) OR ({In(dialect, "rba2", 2)}))");
    }

    [TestCaseSource(nameof(Dialects))]
    public void Multiple_strategies_should_use_left_joins_for_every_authorization_view(Dialect dialect)
    {
        // Arrange
        var plan = CreatePlan(EdOrgAndStudentOrResponsibilityStrategies());

        // Act
        string sql = Normalize(BuildDeletesQuery(dialect, plan).BuildTemplate().RawSql);

        // Assert
        sql.ShouldContain("LEFT JOIN auth.EducationOrganizationIdToEducationOrganizationId AS rba0 ON c.OldProgramEducationOrganizationId = rba0.TargetEducationOrganizationId");
        sql.ShouldContain("LEFT JOIN auth.EducationOrganizationIdToStudentUSI AS rba1 ON c.OldStudentUSI = rba1.StudentUSI");
        sql.ShouldContain("LEFT JOIN auth.EducationOrganizationIdToStudentUSIThroughResponsibility AS rba2 ON c.OldStudentUSI = rba2.StudentUSI");
    }

    [TestCaseSource(nameof(Dialects))]
    public void A_mandatory_strategy_should_stay_outside_the_alternative_strategies(Dialect dialect)
    {
        // Arrange
        var plan = CreatePlan(
            [AndStrategy(FilterContext(MandatoryFilterName, "Namespace")), .. EdOrgAndStudentOrResponsibilityStrategies()]);

        // Act
        string whereClause = GetWhereClause(BuildDeletesQuery(dialect, plan));

        // Assert: the mandatory filter takes view alias index 0 but names its own parameter, so the alternative
        // strategies use the aliases rba1 to rba3 and the generated parameters @p0 to @p2
        whereClause.ShouldBe(
            $"{BaselinePredicate} AND c.OldNamespace = @mandatory AND (({In(dialect, "rba1", 0)} AND {In(dialect, "rba2", 1)}) OR ({In(dialect, "rba3", 2)}))");
    }

    [TestCaseSource(nameof(Dialects))]
    public void A_single_multi_filter_strategy_should_use_inner_joins_and_require_every_filter(Dialect dialect)
    {
        // Arrange
        var plan = CreatePlan(
            OrStrategy(
                FilterContext(EdOrgToEdOrgFilterName, "ProgramEducationOrganizationId"),
                FilterContext(EdOrgToStudentFilterName, "StudentUSI")));

        // Act
        string sql = Normalize(BuildDeletesQuery(dialect, plan).BuildTemplate().RawSql);

        // Assert
        sql.ShouldNotContain("LEFT JOIN");
        sql.ShouldContain("INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId AS rba0");
        sql.ShouldContain("INNER JOIN auth.EducationOrganizationIdToStudentUSI AS rba1");
        GetWhereClause(sql).ShouldBe($"{BaselinePredicate} AND (({In(dialect, "rba0", 0)} AND {In(dialect, "rba1", 1)}))");
    }

    private static QueryBuilder BuildDeletesQuery(Dialect dialect, DataManagementAuthorizationPlan plan)
    {
        var next = A.Fake<IDeletedItemsQueryBuilderFactory>();
        A.CallTo(() => next.CreateQueryBuilder(A<Resource>._)).Returns(CreateTrackedChangesQueryBuilder(dialect));

        var decorator = new DeletedItemsQueryBuilderFactoryAuthorizationDecorator(
            next,
            A.Fake<IDomainModelProvider>(),
            A.Fake<IDomainModelEnhancer>(),
            CreatePlanFactory(plan),
            CreateFilterDefinitionProvider(),
            CreateSecurityRepository());

        return decorator.CreateQueryBuilder(CreateResource());
    }

    private static QueryBuilder BuildKeyChangesQuery(Dialect dialect, DataManagementAuthorizationPlan plan)
    {
        var next = A.Fake<IKeyChangesQueryBuilderFactory>();
        A.CallTo(() => next.CreateQueryBuilder(A<Resource>._)).Returns(CreateTrackedChangesQueryBuilder(dialect));

        var decorator = new KeyChangesQueryBuilderFactoryAuthorizationDecorator(
            next,
            A.Fake<IDomainModelProvider>(),
            A.Fake<IDomainModelEnhancer>(),
            CreatePlanFactory(plan),
            CreateFilterDefinitionProvider(),
            CreateSecurityRepository());

        return decorator.CreateQueryBuilder(CreateResource());
    }

    private static QueryBuilder CreateTrackedChangesQueryBuilder(Dialect dialect)
    {
        // The production factories add their own criteria before the authorization filters are applied
        return new QueryBuilder(dialect)
            .From($"{TrackedChangesTable} AS c")
            .Select("c.ChangeVersion")
            .WhereNull("c.NewStudentUSI");
    }

    // (edorg AND student) OR responsibility, as shipped for StudentSpecialEducationProgramEligibilityAssociation
    private static AuthorizationStrategyFiltering[] EdOrgAndStudentOrResponsibilityStrategies()
    {
        return
        [
            OrStrategy(
                FilterContext(EdOrgToEdOrgFilterName, "ProgramEducationOrganizationId"),
                FilterContext(EdOrgToStudentFilterName, "StudentUSI")),
            OrStrategy(FilterContext(ResponsibilityFilterName, "StudentUSI"))
        ];
    }

    private static IDataManagementAuthorizationPlanFactory CreatePlanFactory(DataManagementAuthorizationPlan plan)
    {
        var planFactory = A.Fake<IDataManagementAuthorizationPlanFactory>();
        A.CallTo(() => planFactory.CreateAuthorizationPlan(ReadChangesActionUri)).Returns(plan);

        return planFactory;
    }

    private static ISecurityRepository CreateSecurityRepository()
    {
        var securityRepository = A.Fake<ISecurityRepository>();
        A.CallTo(() => securityRepository.GetActionByName("ReadChanges"))
            .Returns(new SecurityAction { ActionUri = ReadChangesActionUri });

        return securityRepository;
    }

    private static IAuthorizationFilterDefinitionProvider CreateFilterDefinitionProvider()
    {
        var educationOrganizationIdNamesProvider = A.Fake<IEducationOrganizationIdNamesProvider>();
        A.CallTo(() => educationOrganizationIdNamesProvider.GetAllNames()).Returns(["EducationOrganizationId"]);

        var personTypesProvider = A.Fake<IPersonTypesProvider>();
        A.CallTo(() => personTypesProvider.PersonTypes).Returns(["Student"]);

        var relationshipsFactory = new RelationshipsAuthorizationStrategyFilterDefinitionsFactory(
            educationOrganizationIdNamesProvider,
            A.Fake<IApiClientContextProvider>(),
            A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>(),
            personTypesProvider,
            A.Fake<IMultiValueRestrictions>());

        var responsibilityFactory = new RelationshipsWithStudentsOnlyThroughResponsibilityAuthorizationStrategyFilterDefinitionsFactory(
            educationOrganizationIdNamesProvider,
            A.Fake<IApiClientContextProvider>(),
            A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>(),
            personTypesProvider,
            A.Fake<IMultiValueRestrictions>());

        var mandatoryFilterDefinition = new AuthorizationFilterDefinition(
            MandatoryFilterName,
            null,
            null,
            (_, _, _, _, queryBuilder, _) => queryBuilder.Where("c.OldNamespace", "=", "uri://ed-fi.org", "@mandatory"),
            null);

        var filterDefinitionsByName = relationshipsFactory.CreatePredefinedAuthorizationFilterDefinitions()
            .Concat(responsibilityFactory.CreatePredefinedAuthorizationFilterDefinitions())
            .Append(mandatoryFilterDefinition)
            .ToDictionary(d => d.FilterName);

        return new DictionaryAuthorizationFilterDefinitionProvider(filterDefinitionsByName);
    }

    private static DataManagementAuthorizationPlan CreatePlan(params AuthorizationStrategyFiltering[] filtering)
    {
        return new DataManagementAuthorizationPlan { Filtering = filtering };
    }

    private static AuthorizationStrategyFiltering OrStrategy(params AuthorizationFilterContext[] filters)
    {
        return new AuthorizationStrategyFiltering { Operator = FilterOperator.Or, Filters = filters };
    }

    private static AuthorizationStrategyFiltering AndStrategy(params AuthorizationFilterContext[] filters)
    {
        return new AuthorizationStrategyFiltering { Operator = FilterOperator.And, Filters = filters };
    }

    private static AuthorizationFilterContext FilterContext(string filterName, string subjectEndpointName)
    {
        return new AuthorizationFilterContext
        {
            FilterName = filterName,
            SubjectEndpointName = subjectEndpointName,
            ClaimEndpointValues = _claimEducationOrganizationIds,
        };
    }

    private static Resource CreateResource()
    {
        var domainModelBuilder = new DomainModelBuilder();

        var schema = EdFiConventions.PhysicalSchemaName;
        var entityName = new FullName(schema, "StudentSpecialEducationProgramEligibilityAssociation");

        domainModelBuilder.AddAggregate(new AggregateDefinition(entityName, []));
        domainModelBuilder.AddEntity(new EntityDefinition(schema, entityName.Name, [], []));
        domainModelBuilder.AddSchema(new SchemaDefinition(EdFiConventions.LogicalName, schema));

        var domainModel = domainModelBuilder.Build();
        var entity = domainModel.EntityByFullName[entityName];

        // Normally applied by the NHibernate domain model enhancer
        (entity as dynamic).NHibernateEntityType = typeof(object);

        return (Resource)Activator.CreateInstance(
            typeof(Resource),
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            [new ResourceModel(domainModel), entity],
            CultureInfo.CurrentCulture)!;
    }

    private static string In(Dialect dialect, string alias, int parameterIndex)
    {
        var (sql, _, _) = dialect.GetInClause(
            $"{alias}.SourceEducationOrganizationId",
            $"@p{parameterIndex}",
            _claimEducationOrganizationIds);

        return Normalize(sql);
    }

    private static string GetWhereClause(QueryBuilder queryBuilder)
    {
        return GetWhereClause(Normalize(queryBuilder.BuildTemplate().RawSql));
    }

    private static string GetWhereClause(string sql)
    {
        int whereIndex = sql.IndexOf(" WHERE ", StringComparison.Ordinal);
        whereIndex.ShouldBeGreaterThan(-1, $"No WHERE clause found in: {sql}");

        return sql[(whereIndex + " WHERE ".Length)..];
    }

    private static string Normalize(string sql)
    {
        string singleSpaced = Regex.Replace(sql, @"\s+", " ").Trim();

        // Remove the spaces the SQL builder places just inside parentheses
        return Regex.Replace(Regex.Replace(singleSpaced, @"\(\s+", "("), @"\s+\)", ")");
    }

    private sealed class DictionaryAuthorizationFilterDefinitionProvider(
        IDictionary<string, AuthorizationFilterDefinition> filterDefinitionsByName)
        : IAuthorizationFilterDefinitionProvider
    {
        public AuthorizationFilterDefinition GetAuthorizationFilterDefinition(string filterName)
        {
            return filterDefinitionsByName[filterName];
        }

        public bool TryGetAuthorizationFilterDefinition(string filterName, out AuthorizationFilterDefinition authorizationFilterDefinition)
        {
            return filterDefinitionsByName.TryGetValue(filterName, out authorizationFilterDefinition!);
        }
    }
}
