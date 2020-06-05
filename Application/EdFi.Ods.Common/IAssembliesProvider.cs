// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.Ods.Common.Extensibility;

namespace EdFi.Ods.Common
{
    public interface IAssembliesProvider
    {
        Assembly[] GetAssemblies();

        Assembly Get(string assemblyName);

        /// <summary>
        /// Defines a method that searches the provided folder for, and loads assemblies that include
        /// a type (generally a marker interface) that implements the <see cref="IPluginMarker" /> interface.
        /// </summary>
        /// <param name="pluginFolder">The full path of the folder to scan for plug-ins.</param>
        void LoadPluginAssemblies(string pluginFolder);

        Assembly[] GetAssembliesContaining<T>();
    }
}
