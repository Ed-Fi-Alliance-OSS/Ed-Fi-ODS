// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Logging;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.Common;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class GeneratorProvider : IGeneratorProvider
    {
        private readonly Lazy<IDictionary<string, IGenerator>> _templateModelByName;

        public GeneratorProvider(IGenerator[] generators)
        {
            Preconditions.ThrowIfNull(generators, nameof(generators));

            _templateModelByName = new Lazy<IDictionary<string, IGenerator>>(
                () =>
                {
                    Logger.Debug("Creating lookup dictionary for templates models.");

                    return generators.ToDictionary(k => k.GetType().Name, v => v, StringComparer.InvariantCultureIgnoreCase);
                });
        }

        public ILogger Logger { get; set; } = NullLogger.Instance;

        public IGenerator GetGeneratorByDriverName(string driverName)
        {
            Preconditions.ThrowIfNull(driverName, nameof(driverName));
            Preconditions.ThrowIfWhitespace(driverName, nameof(driverName));

            Logger.Debug($"Resolving IGenerator for {driverName}");

            if (_templateModelByName.Value.TryGetValue(driverName, out IGenerator generator))
            {
                return generator;
            }

            Logger.Warn($"Unable to find a generator for {driverName}.");
            return null;
        }
    }
}
