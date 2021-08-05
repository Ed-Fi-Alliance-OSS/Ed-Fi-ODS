using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        private readonly IDictionary<string, string> _optionsPropertyByName;

        public RenderingManager(
            IList<Plugin> renderingPlugins, 
            ITemplatesProvider templatesProvider, 
            IRenderingsManifestProvider renderingsManifestProvider,
            IList<ITemplateModelProvider> templateModelProviders,
            IGeneratorOptions generatorOptions,
            IList<IRenderingPropertiesEnhancer> renderingPropertiesEnhancers)
        {
            _renderingPlugins = renderingPlugins;
            _templatesProvider = templatesProvider;
            _renderingsManifestProvider = renderingsManifestProvider;
            _templateModelProviders = templateModelProviders;

            _outputPath = generatorOptions.OutputPath;

            _optionsPropertyByName = generatorOptions.PropertyByName;
            
            foreach (var enhancer in renderingPropertiesEnhancers)
            {
                enhancer.EnhanceProperties(_optionsPropertyByName);
            }
            
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

                if (!renderings.Any())
                {
                    continue;
                }
                
                _logger.Debug($"Global rendering context: {string.Join(", ", _optionsPropertyByName.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                
                var matchingRenderings = renderings.Where(r => r.Conditions.All(
                    c =>
                    {
                        if (!_optionsPropertyByName.TryGetValue(c.Key, out string optionValue))
                        {
                            _logger.Debug($"Condition for '{c.Key}' of '{c.Value}' on template '{r.Template}' was not satisfied by the global rendering context.");
                            return false;
                        }

                        return Regex.IsMatch(optionValue, c.Value, RegexOptions.IgnoreCase);
                    })).ToArray();

                if (!matchingRenderings.Any())
                {
                    _logger.Warn($"No renderings matched the supplied context.");
                    continue;
                }
                 
                _logger.Info($"The following templates will be rendered from assembly '{renderingPlugin.Assembly.FullName}':{Environment.NewLine}    {string.Join($"{Environment.NewLine}    ", matchingRenderings.Select(r => RenderingHelper.ApplyPropertiesToParameterMarkers(_optionsPropertyByName, r.Template)))}");
                
                foreach (var rendering in matchingRenderings)
                {
                    string templateName = RenderingHelper.ApplyPropertiesToParameterMarkers(
                        _optionsPropertyByName,
                        rendering.Template);
                    
                    if (!templateContentByName.TryGetValue(templateName, out string templateContent))
                    {
                        _logger.Error($"Unable to find template '{templateName}' in plugin assembly '{pluginAssembly.FullName}'.");
                        renderingSuccessful = false;
                        continue;
                    }

                    // Get the model provider, prioritizing the plugin assembly first
                    var templateModelProvider = _templateModelProviders.Where(p => p.GetType().Assembly == pluginAssembly)
                        .Where(p => IsTemplateModelProviderForProviderName(p, rendering.ModelProvider))
                        .Concat(_templateModelProviders.Where(p => IsTemplateModelProviderForProviderName(p, rendering.ModelProvider)))
                        .FirstOrDefault();

                    if (templateModelProvider == null)
                    {
                        _logger.Error($@"Unable to find model provider '{rendering.ModelProvider}' for template '{templateName}' in plugin assembly '{pluginAssembly.FullName}'.");
                        renderingSuccessful = false;
                        continue;
                    }
                    
                    // Get the template model
                    var templateModel = templateModelProvider.GetTemplateModel(_optionsPropertyByName);
                    
                    // Determine output filename
                    string outputFileName = Path.IsPathRooted(rendering.OutputPath)
                        ? rendering.OutputPath
                        : Path.Combine(_outputPath, rendering.OutputPath);

                    outputFileName = RenderingHelper.ApplyPropertiesToParameterMarkers(_optionsPropertyByName, outputFileName);
                    
                    // Render the template
                    _logger.Info($"Rendering content for template '{templateName}'...");

                    // Process all the templates for parameter markers and pass to the rendering process as the partials 
                    var partials = templateContentByName
                        .Select(kvp => new KeyValuePair<string, string>(RenderingHelper.ApplyPropertiesToParameterMarkers(_optionsPropertyByName, kvp.Key), kvp.Value))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, StringComparer.OrdinalIgnoreCase);
                    
                    string renderedContent = await RenderAsync(templateContent, templateModel, partials);

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

            bool IsTemplateModelProviderForProviderName(ITemplateModelProvider p, string renderingModelProvider)
            {
                var result = p.GetType().Name.Equals(renderingModelProvider, StringComparison.OrdinalIgnoreCase)
                    || p.GetType().Name.Equals(renderingModelProvider + "TemplateModelProvider", StringComparison.OrdinalIgnoreCase);
                
                _logger.Debug($"Evaluated template model provider '{p.GetType().Name}' against model provider name '{renderingModelProvider}': {result}");

                return result;
            }
        }

        private async Task<string> RenderAsync(string templateContent, object templateModel, IDictionary<string, string> partials)
        {
            string renderedContent = await _stubbleRender
                .Value
                .RenderAsync(templateContent, templateModel, partials, _renderSettings)
                .ConfigureAwait(false);

            return renderedContent;
        }
    }
}