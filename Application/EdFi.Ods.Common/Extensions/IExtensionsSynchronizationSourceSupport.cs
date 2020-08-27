// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Extensions
{
    /// <summary>
    /// Defines the operations for supporting the movement and synchronization of
    /// extension data to persistence.
    /// </summary>
    public interface IExtensionsSynchronizationSourceSupport
    {
        /// <summary>
        /// Indicates whether the named extension is supported by the source object (typically it is supported unless constrained in a resource class by an API Profile).
        /// </summary>
        /// <param name="name">The name of the extension.</param>
        /// <returns><b>true</b> if the extension is supported as a source for synchronization; otherwise <b>false</b>.</returns>
        bool IsExtensionSupported(string name);

        /// <summary>
        /// If functionally implemented by the target object, records whether the specified extension
        /// is supported for synchronization during the current movement of data towards persistence.
        /// </summary>
        /// <param name="name">The name of the extension.</param>
        /// <param name="isSupported">Indicator as to whether the extension is supported as a source for synchronization.</param>
        void SetExtensionSupported(string name, bool isSupported);

        /// <summary>
        /// Indicates whether the named extension has data available in the current movement towards persistence.
        /// </summary>
        /// <param name="name">The name of the extension.</param>
        /// <returns><b>true</b> if extension data was present on the source; otherwise <b>false</b>.</returns>
        bool IsExtensionAvailable(string name);

        /// <summary>
        /// If functionally implemented by the target object, records whether the source object has data available
        /// for synchronization for the specified extension.
        /// </summary>
        /// <param name="name">The name of the extension.</param>
        /// <param name="isAvailable">Indicator as to whether the source object has extension data available for synchronization.</param>
        void SetExtensionAvailable(string name, bool isAvailable);
    }
}
