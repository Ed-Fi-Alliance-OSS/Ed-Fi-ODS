// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using log4net.Appender;

namespace EdFi.Ods.Tests._Extensions;

public static class MemoryAppenderExtensions
{
    // Useful for interactive debugging while writing tests that verify correct logging entries
    public static void ToConsole(this MemoryAppender memoryAppender)
    {
        memoryAppender.GetEvents()
            .Select(
                e => new
                {
                    e.Level,
                    e.RenderedMessage
                })
            .ForEach(x => Console.WriteLine($"{x.Level}: {x.RenderedMessage}"));
    }
}
