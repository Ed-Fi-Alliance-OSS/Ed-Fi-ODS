using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Generator.Templating;
using log4net;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;
using Weikio.PluginFramework.Abstractions;

namespace EdFi.Ods.Generator.Rendering
{
    public class RenderingManager : IRenderingManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RenderingManager));
        
        private readonly IList<Plugin> _renderingPlugins;
        private readonly ITemplatesProvider _templatesProvider;
        private readonly IRenderingsManifestProvider _renderingsManifestProvider;
        private readonly IList<ITemplateModelProvider> _templateModelProviders;
        private readonly string _outputPath;

        private readonly Lazy<StubbleVisitorRenderer> _stubbleRender;
        private readonly RenderSettings _renderSettings;
        private IDictionary<string, string> _optionsPropertyByName;
        private readonly string _databaseEngine;

        public RenderingManager(
            IList<Plugin> renderingPlugins, 
            ITemplatesProvider templatesProvider, 
            IRenderingsManifestProvider renderingsManifestProvider,
            IList<ITemplateModelProvider> templateModelProviders,
            Options options)
        {
            _renderingPlugins = renderingPlugins;
            _templatesProvider = templatesProvider;
            _renderingsManifestProvider = renderingsManifestProvider;
            _templateModelProviders = templateModelProviders;

            _outputPath = options.OutputPath;
            _databaseEngine = options.DatabaseEngine;
            
            _optionsPropertyByName = options.PropertyByName;
            
            _stubbleRender = new Lazy<StubbleVisitorRenderer>(
                () => new StubbleBuilder()
                    .Configure(
                        settings =>
                        {
                            settings.SetMaxRecursionDepth(512);
                            settings.SetIgnoreCaseOnKeyLookup(true);
                        }
                    )
                    .Build());

            _renderSettings = new RenderSettings {SkipHtmlEncoding = true};
        }

        public async Task<bool> RenderAllAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken == null)
            {
                throw new ArgumentNullException(nameof(cancellationToken));
            }

            bool renderingSuccessful = true;
            
            _logger.Debug("Generation starting.");

            foreach (var renderingPlugin in _renderingPlugins)
            {
                // Get the template contents for the plugin, by name
                var pluginAssembly = renderingPlugin.Type.Assembly;
                var templateContentByName = _templatesProvider.GetTemplates(pluginAssembly);

                var renderings =  await _renderingsManifestProvider.GetRenderingsAsync(pluginAssembly);

                foreach (var rendering in renderings)
                {
                    var skipRendering = rendering.Properties.TryGetValue("DatabaseEngine", out string renderingDatabaseEngine)
                        && !renderingDatabaseEngine.Equals(_databaseEngine, StringComparison.OrdinalIgnoreCase);

                    // Use this for a more generic mechanism for matching supplied context properties to rendering properties
                    // var skipRendering = rendering.Properties
                        //.Join(_optionsPropertyByName, 
                        //     x => x.Key, 
                        //     x => x.Key, 
                        //     (x, y) => string.Compare(x.Value, y.Value, StringComparison.OrdinalIgnoreCase) == 0)
                        // .Any(x => x == false);

                    if (skipRendering)
                    {
                        continue;
                    }
                    
                    if (!templateContentByName.TryGetValue(rendering.Template, out string templateContent))
                    {
                        _logger.Error($"Unable to find template '{rendering.Template}' in plugin assembly '{pluginAssembly.FullName}'.");
                        renderingSuccessful = false;
                        continue;
                    }

                    // Get the model provider
                    var templateModelProvider = _templateModelProviders.Where(p => p.GetType().Assembly == pluginAssembly)
                        .Where(p => p.GetType().Name.Equals(rendering.ModelProvider, StringComparison.OrdinalIgnoreCase))
                        .Concat(
                            _templateModelProviders.Where(
                                p => p.GetType().Name.Equals(rendering.ModelProvider, StringComparison.OrdinalIgnoreCase)))
                        .FirstOrDefault();

                    if (templateModelProvider == null)
                    {
                        _logger.Error($@"Unable to find model provider '{rendering.ModelProvider}' for template '{rendering.Template}' in plugin assembly '{pluginAssembly.FullName}'.");
                        renderingSuccessful = false;
                        continue;
                    }
                    
                    // Get the template model
                    var templateModel = templateModelProvider.GetTemplateModel(_optionsPropertyByName);
                    
                    // Determine output filename
                    string outputFileName = Path.IsPathRooted(rendering.OutputPath)
                        ? rendering.OutputPath
                        : Path.Combine(_outputPath, rendering.OutputPath);

                    // Apply properties to parameter markers
                    foreach (var kvp in _optionsPropertyByName)
                    {
                        string propertyMarker = $"{{{{{kvp.Key}}}}}";

                        if (outputFileName.Contains(propertyMarker))
                        {
                            outputFileName = outputFileName.Replace(propertyMarker, kvp.Value);
                        }
                    }
                    
                    // Render the template
                    _logger.Info($"Rendering content for template '{rendering.Template}'...");
                    string renderedContent = await RenderAsync(templateContent, templateModel, templateContentByName);

                    string outputFolder = Path.GetDirectoryName(outputFileName);

                    if (!Directory.Exists(outputFolder))
                    {
                        _logger.Info($"Creating destination folder '{outputFolder}'...");
                        Directory.CreateDirectory(outputFolder);
                    }

                    _logger.Info($"Writing '{outputFileName}'...");
                    await using var streamWriter = new StreamWriter(outputFileName);
                    await streamWriter.WriteAsync(renderedContent).ConfigureAwait(false);
                }
            }
            
            _logger.Debug($"Generation complete.");

            return renderingSuccessful;
        }

        private async Task<string> RenderAsync(string templateContent, object templateModel, IDictionary<string, string> templateContentByName)
        {
            string renderedContent = await _stubbleRender
                .Value
                .RenderAsync(templateContent, templateModel, templateContentByName, _renderSettings)
                .ConfigureAwait(false);

            return renderedContent;
        }
    }
}