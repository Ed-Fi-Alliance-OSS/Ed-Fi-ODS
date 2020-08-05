// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Represents an abstraction of Ed-Fi descriptors to allow for decoupling of logic from the generated descriptor interfaces contained in version-specific assemblies.
    /// </summary>
    public interface IEdFiDescriptor
    {
        int DescriptorId { get; set; }

        string CodeValue { get; set; }

        string Namespace { get; set; }
    }
}
