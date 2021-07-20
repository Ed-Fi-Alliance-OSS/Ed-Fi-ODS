using System.Reflection;
using Autofac;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Generator.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Database.Transformers;
using EdFi.Ods.Generator.Rendering;
using EdFi.Ods.Generator.Templating;

namespace EdFi.Ods.ChangeQueries.SqlGeneration
{
    public class ChangeQueriesPlugin : IRenderingPlugin
    {
        public void Initialize(ContainerBuilder containerBuilder)
        {
            // Register domain model transformers
            containerBuilder
                .RegisterType<IdAlternateIdentifierStripper>()
                .As<IDomainModelDefinitionsTransformer>();
            
            // Register template model providers
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<ITemplateModelProvider>()
                .AsImplementedInterfaces();
            
            // Register enhancers for Database artifacts generation
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<ITableEnhancer>()
                .AsImplementedInterfaces();
            
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IColumnEnhancer>()
                .AsImplementedInterfaces();
        }
    }
}