// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;

namespace EdFi.Ods.Common.Extensions;

public static class LogContextAccessorExtensions
{
    /// <summary>
    /// Gets the CorrelationId using the supplied <see cref="ILogContextAccessor" />.
    /// </summary>
    /// <param name="logContextAccessor"></param>
    /// <returns>The previously set correlation id.</returns>
    public static string GetCorrelationId(this ILogContextAccessor logContextAccessor)
    {
        return (string)logContextAccessor.GetValue(CorrelationConstants.LogContextKey);
    }

    /// <summary>
    /// Sets the CorrelationId using the supplied <see cref="ILogContextAccessor" />.
    /// </summary>
    /// <param name="logContextAccessor"></param>
    /// <param name="correlationId">The correlation to save to the logger's context.</param>
    public static void SetCorrelationId(this ILogContextAccessor logContextAccessor, string correlationId)
    {
        logContextAccessor.SetValue(CorrelationConstants.LogContextKey, correlationId);
    }
}
