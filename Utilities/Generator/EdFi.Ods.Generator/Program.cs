using System;
using System.Collections.Generic;
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
using Weikio.PluginFramework.Abstractions;
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

        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

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
                CancellationTokenSource.Cancel();
                e.Cancel = true;
            };
            
            var stopwatch = new Stopwatch();
            
            try
            {
                stopwatch.Start();

                _logger.Info("Starting generation.");

                var cancellationToken = CancellationTokenSource.Token;

                await container.Resolve<IRenderingManager>()
                    .RenderAllAsync(cancellationToken)
                    .ConfigureAwait(false);

                stopwatch.Stop();

                _logger.Info($"Completed generation in {stopwatch.Elapsed.ToString()}.");

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
            containerBuilder.RegisterInstance(options).AsImplementedInterfaces();
            containerBuilder.RegisterModule(new GeneratorModule());

            // Add the Configuration to the container
            var configuration = ConfigurationHelper.BuildConfiguration();
            containerBuilder.RegisterInstance(configuration);
            
            // Handle plugins with paths through Options / command-line parameter
            var pluginCatalogs = GetPluginCatalogs(options.Plugins).ToArray();
            var compositePluginCatalog = new CompositePluginCatalog(pluginCatalogs);
            compositePluginCatalog.Initialize();

            var plugins = compositePluginCatalog.GetPlugins();

            var pluginTypes = new HashSet<Type>();
            
            foreach (var plugin in plugins)
            {
                if (pluginTypes.Add(plugin.Type))
                {
                    var pluginInstance = (IRenderingPlugin) Activator.CreateInstance(plugin.Type);
                    pluginInstance?.Initialize(containerBuilder);

                    containerBuilder.RegisterInstance(plugin);
                }
            }

            return containerBuilder.Build();
        }

        private static IEnumerable<IPluginCatalog> GetPluginCatalogs(IEnumerable<string> pluginsArgument)
        {
            // Start with the current assembly's built-in plugins
            var builtinAssemblyPluginCatalog = new AssemblyPluginCatalog(Assembly.GetExecutingAssembly(),type => type.Implements<IRenderingPlugin>());
            yield return builtinAssemblyPluginCatalog;
            
            // Get the base path for any relative paths supplied
            string relativePathBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string pluginArgument in pluginsArgument)
            {
                string testPath = !Path.IsPathFullyQualified(pluginArgument) && !Path.IsPathRooted(pluginArgument) && relativePathBase != null
                    ? Path.Combine(relativePathBase, pluginArgument)
                    : pluginArgument;

                if (File.Exists(testPath))
                {
                    yield return new AssemblyPluginCatalog(testPath, type => type.Implements<IRenderingPlugin>());
                }
                else if (Directory.Exists(testPath))
                {
                    yield return new FolderPluginCatalog(testPath, type => type.Implements<IRenderingPlugin>(),
                        new FolderPluginCatalogOptions { IncludeSubfolders = false });

                    string binSubfolder = Path.Combine(testPath, "bin");

                    if (Directory.Exists(binSubfolder))
                    {
                        yield return new FolderPluginCatalog(binSubfolder, type => type.Implements<IRenderingPlugin>(),
                            new FolderPluginCatalogOptions { IncludeSubfolders = true });
                    }
                }
                else
                {
                    throw new ArgumentException(
                        $"Plugin '{pluginArgument}' could not be resolved as a relative or full path to an assembly or plugins folder.");
                }
            }
        }
    }
}
