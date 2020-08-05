// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Context
{
    /// <summary>
    /// Defines a method for transferring required context from <see cref="HttpContext"/> to <see cref="CallContext"/>.
    /// </summary>
    public interface IHttpContextStorageTransfer
    {
        /// <summary>
        /// Transfers required context from <see cref="HttpContext"/> into <see cref="CallContext"/>.
        /// </summary>
        void TransferContext();
    }
}
