// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using EdFi.Ods.CodeGen.Models.Application;
using EdFi.Ods.CodeGen.Providers;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;

namespace EdFi.Ods.CodeGen.Processing.Impl
{
    public class TemplateWriter : ITemplateWriter
    {
        private readonly Lazy<StubbleVisitorRenderer> _stubbleRender;
        private readonly Lazy<IDictionary<string, string>> _templatesByTemplateName;
        private readonly RenderSettings _renderSettings;

        public TemplateWriter(IMustacheTemplateProvider mustacheTemplateProvider)
        {
            if (mustacheTemplateProvider == null)
            {
                throw new ArgumentNullException(nameof(mustacheTemplateProvider));
            }

            _templatesByTemplateName = new Lazy<IDictionary<string, string>>(mustacheTemplateProvider.GetMustacheTemplates);

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

            _renderSettings = new RenderSettings
                              {
                                  SkipHtmlEncoding = true
                              };
        }

        public ILogger Logger { get; set; } = NullLogger.Instance;

        public async Task WriteAsync(TemplateWriterData codeGenTemplateWriterData, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string template = _templatesByTemplateName.Value[codeGenTemplateWriterData.TemplateSet.Name];

            Logger.Debug($"Rendering {codeGenTemplateWriterData.TemplateSet.Name}.");

            string destinationFolder = Path.GetDirectoryName(codeGenTemplateWriterData.OutputPath);

            if (!Directory.Exists(destinationFolder))
            {
                Logger.Debug($"Creating destination folder {destinationFolder}.");
                Directory.CreateDirectory(destinationFolder);
            }

            string renderedTemplate = _stubbleRender
                                     .Value
                                     .Render(template, codeGenTemplateWriterData.Model, _templatesByTemplateName.Value, _renderSettings);

            using (var streamWriter = new StreamWriter(codeGenTemplateWriterData.OutputPath))
            {
                Logger.Debug($"Writing {codeGenTemplateWriterData.OutputPath}.");
                await streamWriter.WriteAsync(renderedTemplate).ConfigureAwait(false);
            }
        }
    }
}
