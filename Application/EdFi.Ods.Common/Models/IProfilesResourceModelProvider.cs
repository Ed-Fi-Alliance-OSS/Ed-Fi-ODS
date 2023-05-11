// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models
{
    /// <summary>
    /// Defines a method for obtaining a Profile-based version of the <see cref="ResourceModel"/>.
    /// </summary>
    /// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-profile-metadata".</remarks>
    [Intercept("cache-profile-metadata")]
    public interface IProfileResourceModelProvider
    {
        /// <summary>
        /// Get a Profile-based version of the <see cref="ResourceModel"/> for the Profile specified by name.
        /// </summary>
        /// <param name="profileName">The name of the profile for which a model should be created.</param>
        /// <returns>The <see cref="ProfileResourceModel"/> for the specified profile.</returns>
        ProfileResourceModel GetProfileResourceModel(string profileName);
    }
}
