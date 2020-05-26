// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Providers;

namespace EdFi.Ods.CodeGen.Console
{
    public class ApplicationRunner : IApplicationRunner
    {
        private readonly IAssemblyDataProvider _assemblyDataProvider;
        private readonly ITemplateProcessor _templateProcessor;

        public ApplicationRunner(ITemplateProcessor templateProcessor, IAssemblyDataProvider assemblyDataProvider)
        {
            _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
            _assemblyDataProvider = assemblyDataProvider ?? throw new ArgumentNullException(nameof(assemblyDataProvider));
        }

        private ILogger Logger { get; } = NullLogger.Instance;

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken == null)
            {
                throw new ArgumentNullException(nameof(cancellationToken));
            }

            Logger.Debug("Processing beginning.");
            
            foreach (var assemblyData in _assemblyDataProvider.Get())
            {
                await _templateProcessor.ProcessAsync(assemblyData, cancellationToken)
                                        .ConfigureAwait(false);
            }
            
            Logger.Debug($"Processing complete.");
        }
    }
}
