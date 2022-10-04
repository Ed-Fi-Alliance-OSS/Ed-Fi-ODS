// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models;

/// <summary>
/// Defines a method for supporting the mapping/synchronizing of Ed-Fi resource/entity classes.
/// </summary>
public interface IMappingContract
{
    /// <summary>
    /// Indicates whether the specified member is supported in the mapping contract.
    /// </summary>
    /// <param name="memberName">The name of member to be mapped/synchronized.</param>
    /// <returns><b>true</b> if the member is supported; otherwise <b>false</b>.</returns>
    bool IsMemberSupported(string memberName);
}
