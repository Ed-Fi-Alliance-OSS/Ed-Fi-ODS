
namespace EdFi.Ods.Api.IntegrationTests
{
    public class EdFiTuple
    {
        public int Source { get; }

        public int Target { get; }

        private EdFiTuple(int source, int target)
        {
            Source = source;
            Target = target;
        }

        public static EdFiTuple Create(int source, int target)
        {
            return new EdFiTuple(source, target);
        }
    }
}
