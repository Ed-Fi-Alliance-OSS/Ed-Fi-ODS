// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Utils;

// This class will be obsolete with .NET 8 and should be replaced.
public class TimeProvider
{
    protected TimeProvider(){}

    public virtual DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;

    public static TimeProvider System { get; } = new();
}
