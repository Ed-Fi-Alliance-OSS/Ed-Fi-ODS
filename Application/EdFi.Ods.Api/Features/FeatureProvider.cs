// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.Api.Features
{
    public class FeatureProvider : IFeatureProvider
    {
        private readonly IReadOnlyList<IFeature> _features;

        public FeatureProvider(IFeature[] features)
        {
            _features = Preconditions.ThrowIfNull(features, nameof(features));
        }

        // Note: we will always have at least one feature
        public IFeature[] EnabledFeatures() => _features.Where(x => x.IsEnabled()).ToArray();

        public bool IsEnabled<T>()
            where T : IFeature
            => _features.OfType<T>().SingleOrDefault()?.IsEnabled() == true;
    }
}
