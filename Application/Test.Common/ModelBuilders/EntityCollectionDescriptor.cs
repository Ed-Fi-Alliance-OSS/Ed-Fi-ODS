namespace Test.Common.ModelBuilders;

public class EntityCollectionDescriptor
{
    private readonly AggregateRootDescriptor _aggregateRootDescriptor;

    public EntityCollectionDescriptor(AggregateRootDescriptor aggregateRootDescriptor)
    {
        _aggregateRootDescriptor = aggregateRootDescriptor;
    }

    public EntityDescriptor Entity(string name)
    {
        return Entity(_aggregateRootDescriptor.Schema, name);
    }

    public EntityDescriptor Entity(string schema, string name)
    {
        var entity = new EntityDescriptor(schema, name);
        _aggregateRootDescriptor.Entities.Add(entity);

        return entity;
    }
}
