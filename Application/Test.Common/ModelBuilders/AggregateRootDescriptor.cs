using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace Test.Common.ModelBuilders;

public class AggregateRootDescriptor : EntityDescriptor
{
    protected internal List<EntityDescriptor> Entities = new();

    protected internal AggregateRootDescriptor(string schema, string name)
        : base(schema, name)
    {
        Entities.Add(this);
    }

    public EntityDescriptor WithEntities(Action<EntityCollectionDescriptor> d)
    {
        d(new EntityCollectionDescriptor(this));

        return this;
    }
}