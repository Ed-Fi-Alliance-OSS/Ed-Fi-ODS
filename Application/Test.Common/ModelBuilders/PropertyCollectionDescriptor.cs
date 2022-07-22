namespace Test.Common.ModelBuilders;

public class PropertyCollectionDescriptor
{
    private readonly EntityDescriptor _entityDescriptor;

    public PropertyCollectionDescriptor(EntityDescriptor entityDescriptor)
    {
        _entityDescriptor = entityDescriptor;
    }

    public PropertyDescriptor Property(string name)
    {
        var property = new PropertyDescriptor(this, name);
        _entityDescriptor.Properties.Add(property);

        return property;
    }
}