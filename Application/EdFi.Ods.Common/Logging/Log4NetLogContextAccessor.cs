// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using log4net;

namespace EdFi.Ods.Common.Logging;

/// <summary>
/// Get and sets name/value pairs in the log4net context using the <see cref="LogicalThreadContext.Properties" /> collection.
/// </summary>
public class Log4NetLogContextAccessor : ILogContextAccessor
{
    /// <inheritdoc cref="ILogContextAccessor.GetValue" />
    public object GetValue(string name)
    {
        return LogicalThreadContext.Properties[name];
    }

    /// <inheritdoc cref="ILogContextAccessor.SetValue" />
    public void SetValue(string name, object value)
    {
        LogicalThreadContext.Properties[name] = value;
    }
}
