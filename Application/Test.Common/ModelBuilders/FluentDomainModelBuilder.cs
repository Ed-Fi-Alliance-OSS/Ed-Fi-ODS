using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;

namespace Test.Common.ModelBuilders;

public class FluentDomainModelBuilder
{
    protected internal List<SchemaDescriptor> Schemas = new();
        
    public FluentDomainModelBuilder WithSchemas(Action<SchemaCollectionDescriptor> d)
    {
        d(new SchemaCollectionDescriptor(this));

        return this;
    }

    public DomainModel Build()
    {
        var allDomainModelDefinitions = Schemas.Select(
            s =>
            {
                var schemaDefinition = new SchemaDefinition(s.LogicalName, s.PhysicalName);

                var aggregateDefinitions = s.AggregateRoots.Select(
                        a => new AggregateDefinition(
                            new FullName(a.Schema, a.Name),
                            a.Entities.Select(e => new FullName(e.Schema, e.Name)).ToArray()))
                    .ToArray();

                var entityDefinitions = s.AggregateRoots.SelectMany(
                        a => a.Entities.Select(
                                e => new EntityDefinition(
                                    e.Schema,
                                    e.Name,
                                    e.Properties.Select(
                                            p => new EntityPropertyDefinition(
                                                p.PropertyName,
                                                p.PropertyType,
                                                isIdentifying: p.IsIdentifying,
                                                isServerAssigned: p.IsServerAssigned))
                                        .ToArray(),

                                    // NOTE: This only supports inferred Primary Keys right now, and also no support for incorporating identifying Foreign Keys
                                    new EntityIdentifierDefinition[]
                                    {
                                        new(
                                            $"PK_{e.Name}",
                                            e.Properties.Where(p => p.IsIdentifying).Select(p => p.PropertyName).ToArray(),
                                            isPrimary: true),
                                    }))
                            .ToArray())
                    .ToArray();

                var domainModelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggregateDefinitions,
                    entityDefinitions,
                    Array.Empty<AssociationDefinition>());

                return domainModelDefinitions;
            });

        var domainModel = new DomainModelBuilder(allDomainModelDefinitions).Build();

        return domainModel;
    }
}