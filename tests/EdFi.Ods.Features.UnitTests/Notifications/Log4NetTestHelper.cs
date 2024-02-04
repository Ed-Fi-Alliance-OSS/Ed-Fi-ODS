// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Utils.Extensions;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace EdFi.Ods.Features.UnitTests.Notifications;

public class Log4NetTestHelper
{
    public static MemoryAppender SetupMemoryAppender()
    {
        var memoryAppender = new MemoryAppender();
        memoryAppender.ActivateOptions();

        var hierarchy = (Hierarchy) LogManager.GetRepository();
        hierarchy.Root.AddAppender(memoryAppender);
        
        hierarchy.Configured = true;

        BasicConfigurator.Configure();

        return memoryAppender;
    }

    public static void ClearMemoryAppender()
    {
        var hierarchy = (Hierarchy) LogManager.GetRepository();

        foreach (var logger in hierarchy.GetCurrentLoggers())
        {
            if (logger is Logger hierarchyLogger)
            {
                var appenders = hierarchyLogger.Appenders.OfType<MemoryAppender>().ToList();

                foreach (var appender in appenders)
                {
                    hierarchyLogger.RemoveAppender(appender);
                    appender.Clear();
                }
            }
        }
    }
}
