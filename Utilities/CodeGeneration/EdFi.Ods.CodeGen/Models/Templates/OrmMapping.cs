// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.CodeGen.Models.Templates
{
    public class OrmMapping
    {
        public string Assembly { get; set; }

        public string Namespace { get; set; }

        public List<OrmAggregate> Aggregates { get; set; }
    }

    public class OrmAggregate
    {
        public List<OrmClass> Classes { get; set; }
    }

    public class OrmClass
    {
        public string ClassName { get; set; }

        public string ReferenceClassName { get; set; }

        public string TableName { get; set; }

        public string SchemaName { get; set; }

        public bool IsAggregateRoot { get; set; }

        public bool IsAbstract { get; set; }

        public OrmProperty Id { get; set; }

        public OrmCompositeIdentity CompositeId { get; set; }

        public List<NHibernatePropertyDefinition> Properties { get; set; }

        public bool HasOneToOneChildMappings { get; set; }

        public List<OrmOneToOne> OneToOneChildMappings { get; set; }

        public bool HasBackReferences { get; set; }

        public List<OrmBackReference> BackReferences { get; set; }

        public List<OrmCollection> Collections { get; set; }

        public bool IsConcreteEntityBaseMapping { get; set; }

        public bool HasDiscriminator { get; set; }

        public bool IsReferenceable { get; set; }

        public bool HasDerivedEntities { get; set; }

        public bool HasDiscriminatorWhereClause { get; set; }

        public List<OrmDerivedEntity> DerivedEntities { get; set; }

        public bool IsQueryModelContext { get; set; }

        public List<OrmAggregateReference> AggregateReferences { get; set; }
    }

    public class NHibernatePropertyDefinition
    {
        public string PropertyName { get; set; }

        public string ColumnName { get; set; }

        public string NHibernateTypeName { get; set; }

        public string MaxLength { get; set; }

        public string MinLength { get; set; }

        public bool IsNullable { get; set; }

        public bool IsReadOnly { get; set; }
    }

    public class OrmProperty
    {
        public string PropertyName { get; set; }

        public string ColumnName { get; set; }

        public string NHibernateTypeName { get; set; }

        public string MaxLength { get; set; }

        public string MinLength { get; set; }

        public string GeneratorClass { get; set; }

        public bool IsNullable { get; set; }

        public List<OrmProperty> Properties { get; set; }

        public bool HasOneToOneChildMappings { get; set; }

        public List<OrmOneToOne> OneToOneChildMappings { get; set; }

        public List<OrmBag> BackReferences { get; set; }

        public bool IsReadOnly { get; set; }
    }

    public class OrmCompositeIdentity
    {
        public List<OrmProperty> KeyProperties { get; set; }

        public OrmManyToOne KeyManyToOne { get; set; }
    }

    public class OrmManyToOne
    {
        public string Name { get; set; }

        public bool HasClassName { get; set; }

        public string ClassName { get; set; }

        public List<OrmColumn> OrderedParentColumns { get; set; }
    }

    public class OrmColumn
    {
        public string Name { get; set; }
    }

    public class OrmOneToOne
    {
        public string Name { get; set; }

        public string Access { get; set; }

        public bool IsQueryModelMapping { get; set; }

        public string ClassName { get; set; }

        public List<OrmColumn> Columns { get; set; }
    }

    public class OrmBag
    {
        public string BagName { get; set; }

        public string ParentClassName { get; set; }

        public List<OrmColumn> Columns { get; set; }
    }

    public class OrmCollection
    {
        public string BagName { get; set; }

        public bool IsEmbeddedCollection { get; set; }

        public List<OrmColumn> Columns { get; set; }

        public string ClassName { get; set; }
    }

    public class OrmDerivedEntity
    {
        public bool IsJoinedSubclass { get; set; }

        public string ClassName { get; set; }

        public string ReferenceClassName { get; set; }

        public string TableName { get; set; }

        public string SchemaName { get; set; }

        public string DiscriminatorValue { get; set; }

        public string BaseTableName { get; set; }

        public string BaseTableSchemaName { get; set; }

        public List<OrmColumn> KeyColumns { get; set; }

        public List<OrmProperty> KeyProperties { get; set; }

        public List<NHibernatePropertyDefinition> Properties { get; set; }

        public List<OrmAggregateReference> AggregateReferences { get; set; }

        public bool HasBackReferences { get; set; }

        public List<OrmBackReference> BackReferences { get; set; }

        public List<OrmCollection> Collections { get; set; }
    }

    public class OrmAggregateReference
    {
        public string BagName { get; set; }

        public string AggregateReferenceClassName { get; set; }

        public List<OrmColumn> Columns { get; set; }
    }

    public class OrmBackReference
    {
        public string BagName { get; set; }

        public string ParentClassName { get; set; }

        public List<OrmColumn> Columns { get; set; }
    }
}
