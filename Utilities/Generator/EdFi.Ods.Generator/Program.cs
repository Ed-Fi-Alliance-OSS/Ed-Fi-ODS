using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CommandLine;
using EdFi.Ods.Generator.Helpers;
using EdFi.Ods.Generator.Modules;
using EdFi.Ods.Generator.Rendering;
using log4net;
using log4net.Config;
using Weikio.PluginFramework.Catalogs;

namespace EdFi.Ods.Generator
{
    public static class ReturnCodes
    {
        public const int Success = 0;
        public const int Failure = 1;
    }

    internal class Program
    {
        private static ILog _logger;

        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private static async Task<int> Main(string[] args)
        {
            ConfigureLogging();
            _logger = LogManager.GetLogger(typeof(Program));

            int result = 0;
            
            Options options = null;

            new Parser(
                    config =>
                    {
                        config.CaseInsensitiveEnumValues = true;
                        config.CaseSensitive = false;
                    }).ParseArguments<Options>(args)
                .WithParsed(opts => options = opts)
                .WithNotParsed(
                    errs =>
                    {
                        Console.WriteLine("Invalid options were entered.");
                        Console.WriteLine(errs.ToString());
                        result = -1;
                    });

            if (result != ReturnCodes.Success)
            {
                return result;
            }
            
            var container = InitializeContainer(options);
            
            Console.CancelKeyPress += (o, e) =>
            {
                _logger.Warn("Ctrl-C Pressed. Stopping all threads.");
                _cancellationTokenSource.Cancel();
                e.Cancel = true;
            };
            
            var stopwatch = new Stopwatch();
            
            try
            {
                stopwatch.Start();

                _logger.Info("Starting generation.");

                var cancellationToken = _cancellationTokenSource.Token;

                await container.Resolve<IRenderingManager>()
                    .RenderAllAsync(cancellationToken)
                    .ConfigureAwait(false);

                stopwatch.Stop();

                _logger.Info($"Complete generation in {stopwatch.Elapsed.ToString()}.");

                return ReturnCodes.Success;
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());

                return ReturnCodes.Failure;
            }
            finally
            {
                container?.Dispose();
            }
        }

        private static void ConfigureLogging()
        {
            var assembly = typeof(Program).GetTypeInfo().Assembly;

            string configPath = Path.Combine(Path.GetDirectoryName(assembly.Location), "log4net.config");

            XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
        }

        private static IContainer InitializeContainer(Options options)
        {
            // Register components with Autofac
            var containerBuilder = new ContainerBuilder();
            // containerBuilder.Populate(services);
            containerBuilder.RegisterInstance(options);
            containerBuilder.RegisterModule(new GeneratorModule());

            // Add the Configuration to the container
            var configuration = ConfigurationHelper.BuildConfiguration();
            containerBuilder.RegisterInstance(configuration);
            
            // TODO: Handle plugins with paths through Options / command-line parameter
            string ndeAssemblyFileName =
                @"C:\Projects\EdFi\w\Ed-Fi-ODS\Utilities\Generator\Nde.Adviser.Lds.SqlGeneration\bin\Debug\netcoreapp3.1\Nde.Adviser.Lds.SqlGeneration.dll";

            var ndeAssemblyPluginCatalog = new AssemblyPluginCatalog(ndeAssemblyFileName, type => type.Implements<IRenderingPlugin>());
            var assemblyPluginCatalog = new AssemblyPluginCatalog(Assembly.GetExecutingAssembly(),type => type.Implements<IRenderingPlugin>());

            var compositePluginCatalog = new CompositePluginCatalog(ndeAssemblyPluginCatalog, assemblyPluginCatalog);
            compositePluginCatalog.Initialize();

            var plugins = compositePluginCatalog.GetPlugins();

            foreach (var plugin in plugins)
            {
                var pluginInstance = (IRenderingPlugin) Activator.CreateInstance(plugin.Type);
                pluginInstance?.Initialize(containerBuilder);

                containerBuilder.RegisterInstance(plugin);
            }

            #region Plugins exploration (commented out)

            // string pluginPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //
            // var folderPlugin = new FolderPluginCatalog(
            //     pluginPath,
            //     type =>
            //     {
            //         type.Implements<IRenderingPlugin>();
            //     });
            //
            // services.AddPluginFramework<IRenderingPlugin>(pluginPath);
            
            // services.AddPluginFramework()
            //     .AddPluginCatalog(compositePluginCatalog);

            #endregion

            return containerBuilder.Build();
        }
    }
}
