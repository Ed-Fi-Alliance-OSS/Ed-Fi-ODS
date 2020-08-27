// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// Provides methods for obtaining services in a decoupled fashion.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Locates and returns the service implementing the specified type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> of the service.</param>
        /// <returns>The service implementation.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Locates and returns the service implementing the type specified by the generic parameter.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the service.</typeparam>
        /// <returns>The service implementation.</returns>
        T Resolve<T>();

        /// <summary>
        /// Locates and returns the named service implementing the type specified by the generic parameter.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the service.</typeparam>
        /// <returns>The named service implementation.</returns>
        T Resolve<T>(string key);

        /// <summary>
        /// Locates and returns all services implementing the type specified.
        /// </summary>
        /// <returns>All implementations of the service.</returns>
        Array ResolveAll(Type type);

        /// <summary>
        /// Releases the component from the container, preventing possible memory leaks.
        /// </summary>
        /// <param name="instance">The instance of the component to release, for garbage collection.</param>
        void Release(object instance);
    }
}
