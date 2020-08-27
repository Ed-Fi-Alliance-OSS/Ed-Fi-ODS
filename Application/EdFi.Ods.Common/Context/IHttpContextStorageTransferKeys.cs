// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Context
{
    /// <summary>
    /// Defines a method for declaring what <see cref="IContextStorage"/> keys are read and or written by a component.
    /// </summary>
    /// <remarks>This interface was introduced to transfer required context from <see cref="HttpContext"/> 
    /// to <see cref="CallContext"/> for background Tasks in an ASP.NET application.</remarks>
    public interface IHttpContextStorageTransferKeys
    {
        /// <summary>
        /// Declaring what <see cref="IContextStorage"/> keys are read and or written by the component.
        /// </summary>
        /// <returns>A list of keys.</returns>
        IReadOnlyList<string> GetKeys();
    }
}
