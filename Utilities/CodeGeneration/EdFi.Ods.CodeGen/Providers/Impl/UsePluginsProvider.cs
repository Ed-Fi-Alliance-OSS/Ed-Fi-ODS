
namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class UsePluginsProvider : IUsePluginsProvider
    {
        public readonly bool _usePlugins;

        public UsePluginsProvider(bool usePlugins)
        {
            _usePlugins = usePlugins;
        }

        public bool UsePlugins()
        {
           return _usePlugins;
        }
    }
}
