// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.Metadata.Profiles
{
    /// <summary>
    /// Defines a method for obtaining tuples of names of associated Profiles and Resources.
    /// </summary>
    /// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-profile-metadata".</remarks>
    [Intercept("cache-profile-metadata")]
    public interface IProfileResourceNamesProvider
    {
        /// <summary>
        /// Gets a list of tuples containing the names of associated Profiles and Resources.
        /// </summary>
        /// <returns>A list of tuples containing associated Profile and Resource names.</returns>
        List<ProfileAndResourceNames> GetProfileResourceNames();
    }

    /// <summary>
    /// Provides a tuple of names of a Profile and a member Resource.
    /// </summary>
    public class ProfileAndResourceNames
    {
        /// <summary>
        /// Gets or sets the name of a Profile.
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the name of a Resource.
        /// </summary>
        public string ResourceName { get; set; }
    }
}
