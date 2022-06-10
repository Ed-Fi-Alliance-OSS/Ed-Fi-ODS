namespace EdFi.Ods.Common.Models.Dynamic
{
    public static class DynamicModelExtensions
    {
        public static void CopyDynamicPropertiesFrom(this IDynamicModel target, IDynamicModel source)
        {
            foreach (var kvp in source.DynamicProperties)
            {
                target.DynamicProperties[kvp.Key] = kvp.Value;
            }
        }
    }
}