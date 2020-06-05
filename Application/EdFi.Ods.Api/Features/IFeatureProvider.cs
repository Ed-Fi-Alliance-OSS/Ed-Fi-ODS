// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.Api.Features
{
    public interface IFeatureProvider
    {
        /// <summary>
        /// Returns the features for the ODS/API
        /// </summary>
        /// <returns>An array of enabled features</returns>
        IFeature[] EnabledFeatures();

        /// <summary>
        /// Validates if a feature is enabled
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsEnabled<T>() where T : IFeature;
    }
}
