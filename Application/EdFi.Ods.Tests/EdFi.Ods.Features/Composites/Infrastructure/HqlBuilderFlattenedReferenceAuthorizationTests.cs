// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Text;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;
using FakeItEasy;
using NHibernate;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Composites.Infrastructure;

/// <summary>
/// Tests how the <see cref="HqlBuilder" /> records which projected fields of flattened references are subject to
/// the authorization flags projected for those references (ODS-6895).
/// </summary>
[TestFixture]
public class HqlBuilderFlattenedReferenceAuthorizationTests
{
    private HqlBuilder _hqlBuilder;
    private CompositeDefinitionProcessorContext _processorContext;
    private Resource _courseOffering;

    [SetUp]
    public void SetUp()
    {
        _hqlBuilder = new HqlBuilder(
            A.Fake<ISessionFactory>(),
            A.Fake<IDescriptorResolver>(),
            A.Fake<IResourceJoinPathExpressionProcessor>(),
            A.Fake<IParameterListSetter>(),
            A.Fake<IPersonEntitySpecification>(),
            A.Fake<IPersonUsiResolver>());

        _processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        _courseOffering = CreateCourseOfferingResource();
    }

    [Test]
    public void CreateFlattenedMemberContext_SharesTheContainingQueryState()
    {
        var rootContext = CreateRootBuilderContext();

        var flattenedContext = _hqlBuilder.CreateFlattenedMemberContext(rootContext);

        flattenedContext.IsFlattenedMemberContext.ShouldBeTrue();
        rootContext.IsFlattenedMemberContext.ShouldBeFalse();
        flattenedContext.CurrentQueryFilterParameterValueByName.ShouldBeSameAs(rootContext.CurrentQueryFilterParameterValueByName);
        // The specification parameters, so that authorization parameters don't reuse their names
        flattenedContext.ParameterValueByName.ShouldBeSameAs(rootContext.ParameterValueByName);
        flattenedContext.AuthorizationFlagAliasesByFieldAlias.ShouldBeSameAs(rootContext.AuthorizationFlagAliasesByFieldAlias);
        flattenedContext.Select.ShouldBeSameAs(rootContext.Select);
        flattenedContext.InheritedAuthorizationFlagAliases.ShouldBeEmpty();
        flattenedContext.AuthorizationFlagAlias.ShouldBeNull();
    }

    [Test]
    public void ProjectProperties_ForAuthorizedFlattenedReference_SubjectsOnlyNonIdentifyingFieldsToTheFlag()
    {
        var rootContext = CreateRootBuilderContext();

        var flattenedContext = CreateFlattenedContextWithFlag(rootContext, "comp_ab");

        _hqlBuilder.ProjectProperties(
            [
                Projection("LocalCourseCode"),
                Projection("LocalCourseTitle"),
                // A property that no code refers to by name, to show that nothing is hard-coded
                Projection("SomeNewlyAddedProperty", "renamedProperty")
            ],
            flattenedContext,
            _processorContext);

        var flagsByField = rootContext.AuthorizationFlagAliasesByFieldAlias;

        flagsByField.ContainsKey("localCourseCode").ShouldBeFalse();
        flagsByField["localCourseTitle"].ShouldBe(["__Auth_comp_ab"]);
        flagsByField["renamedProperty"].ShouldBe(["__Auth_comp_ab"]);
        flagsByField.Count.ShouldBe(2);

        // The HQL projection itself is unchanged
        rootContext.Select.ToString().ShouldContain("comp_ab.LocalCourseTitle as localCourseTitle");
        rootContext.Select.ToString().ShouldContain("comp_ab.SomeNewlyAddedProperty as renamedProperty");
    }

    [Test]
    public void ProjectProperties_ForNestedFlattenedReference_SubjectsFieldsToTheContainingReferencesFlags()
    {
        var rootContext = CreateRootBuilderContext();

        var flattenedContext = CreateFlattenedContextWithFlag(rootContext, "comp_ab");
        var nestedContext = CreateFlattenedContextWithFlag(flattenedContext, "comp_ac");

        nestedContext.InheritedAuthorizationFlagAliases.ShouldBe(["__Auth_comp_ab"]);

        _hqlBuilder.ProjectProperties(
            [
                Projection("LocalCourseCode", "nestedCode"),
                Projection("LocalCourseTitle", "nestedTitle")
            ],
            nestedContext,
            _processorContext);

        var flagsByField = rootContext.AuthorizationFlagAliasesByFieldAlias;

        // Identifying values of the nested reference come from the containing reference's row
        flagsByField["nestedCode"].ShouldBe(["__Auth_comp_ab"]);
        flagsByField["nestedTitle"].ShouldBe(["__Auth_comp_ab", "__Auth_comp_ac"]);
    }

    [Test]
    public void ProjectProperties_ForFlattenedMemberWithoutItsOwnFlag_SubjectsAllFieldsToTheContainingReferencesFlags()
    {
        var rootContext = CreateRootBuilderContext();

        var flattenedContext = CreateFlattenedContextWithFlag(rootContext, "comp_ab");

        // e.g. an embedded object or a reference to a resource requiring no authorization filtering
        var nestedContext = _hqlBuilder.CreateFlattenedMemberContext(flattenedContext);
        nestedContext.CurrentAlias = "comp_ac";

        _hqlBuilder.ProjectProperties(
            [
                Projection("LocalCourseCode", "nestedCode"),
                Projection("LocalCourseTitle", "nestedTitle")
            ],
            nestedContext,
            _processorContext);

        var flagsByField = rootContext.AuthorizationFlagAliasesByFieldAlias;

        flagsByField["nestedCode"].ShouldBe(["__Auth_comp_ab"]);
        flagsByField["nestedTitle"].ShouldBe(["__Auth_comp_ab"]);
    }

    [Test]
    public void ProjectProperties_WithoutAuthorizationFlags_RecordsNothing()
    {
        var rootContext = CreateRootBuilderContext();

        _hqlBuilder.ProjectProperties(
            [Projection("LocalCourseCode"), Projection("LocalCourseTitle")],
            rootContext,
            _processorContext);

        var flattenedContext = _hqlBuilder.CreateFlattenedMemberContext(rootContext);
        flattenedContext.CurrentAlias = "comp_ab";

        _hqlBuilder.ProjectProperties(
            [Projection("LocalCourseTitle", "flattenedTitle")],
            flattenedContext,
            _processorContext);

        rootContext.AuthorizationFlagAliasesByFieldAlias.ShouldBeEmpty();
    }

    [Test]
    public void ChildContexts_CarryTheAuthorizationFilteringOfContainingFlattenedReferences()
    {
        var rootContext = CreateRootBuilderContext();

        var containingReferenceAuthorizations = new[]
        {
            new ContainingReferenceAuthorizationFiltering(Array.Empty<AuthorizationStrategyFiltering>(), "comp_ab")
        };

        rootContext.ContainingReferenceAuthorizations = containingReferenceAuthorizations;

        // Simulate HqlBuilder.ApplyFlattenedMember joining to the referenced resource
        rootContext.CurrentAlias = "comp_ab";

        // A flattened reference's children are processed with this context
        var flattenedReferenceChildContext = _hqlBuilder.CreateFlattenedReferenceChildContext(rootContext);

        flattenedReferenceChildContext.IsFlattenedReferenceChildContext.ShouldBeTrue();

        // The authorization decorator relies on the referenced resource's alias being the parent alias of this context
        flattenedReferenceChildContext.ParentAlias.ShouldBe("comp_ab");
        flattenedReferenceChildContext.ContainingReferenceAuthorizations.ShouldBeSameAs(containingReferenceAuthorizations);

        // e.g. a collection of the flattened reference
        var childContext = _hqlBuilder.CreateChildContext(flattenedReferenceChildContext, _processorContext);

        childContext.IsFlattenedReferenceChildContext.ShouldBeFalse();
        childContext.ContainingReferenceAuthorizations.ShouldBeSameAs(containingReferenceAuthorizations);

        // e.g. a collection within that collection
        _hqlBuilder.SnapshotParentingContext(childContext);
        var parentingContext = _hqlBuilder.CreateParentingContext(childContext);

        parentingContext.ContainingReferenceAuthorizations.ShouldBeSameAs(containingReferenceAuthorizations);
    }

    private HqlBuilderContext CreateFlattenedContextWithFlag(HqlBuilderContext containingContext, string alias)
    {
        var flattenedContext = _hqlBuilder.CreateFlattenedMemberContext(containingContext);

        // Simulate the effects of HqlBuilder.ApplyFlattenedMember and the HqlBuilderAuthorizationDecorator
        flattenedContext.CurrentAlias = alias;
        flattenedContext.AuthorizationFlagAlias = $"__Auth_{alias}";

        return flattenedContext;
    }

    private CompositePropertyProjection Projection(string propertyName, string displayName = null)
        => new(_courseOffering.PropertyByName[propertyName], displayName);

    private static HqlBuilderContext CreateRootBuilderContext()
    {
        var rootContext = new HqlBuilderContext(
            new StringBuilder("comp_aa.Id As __BaseEntityId__"),
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder(),
            new System.Collections.Generic.Dictionary<string, object>(),
            null,
            1,
            null,
            null,
            null,
            new AliasGenerator("comp_"))
        {
            CurrentAlias = "comp_aa",
            PropertyProjections = new System.Collections.Generic.List<CompositePropertyProjection>()
        };

        return rootContext;
    }

    private static Resource CreateCourseOfferingResource()
    {
        var domainModelBuilder = new DomainModelBuilder();

        var schema = EdFiConventions.PhysicalSchemaName;
        var entityName = new FullName(schema, "CourseOffering");

        domainModelBuilder.AddSchema(new SchemaDefinition(EdFiConventions.LogicalName, schema));

        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "CourseOffering",
                [
                    new EntityPropertyDefinition("LocalCourseCode", new PropertyType(DbType.String), isIdentifying: true),
                    new EntityPropertyDefinition("LocalCourseTitle", new PropertyType(DbType.String)),
                    new EntityPropertyDefinition("SomeNewlyAddedProperty", new PropertyType(DbType.Int32))
                ],
                [new EntityIdentifierDefinition("PK", ["LocalCourseCode"], isPrimary: true)]));

        domainModelBuilder.AddAggregate(new AggregateDefinition(entityName, Array.Empty<FullName>()));

        var domainModel = domainModelBuilder.Build();

        return new ResourceModel(domainModel).GetResourceByFullName(entityName);
    }
}
