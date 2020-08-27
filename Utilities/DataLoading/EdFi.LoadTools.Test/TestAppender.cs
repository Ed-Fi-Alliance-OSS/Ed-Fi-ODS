// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace EdFi.LoadTools.Test
{
    public class TestAppender : IAppender
    {
        public TestAppender()
        {
            Logs = new List<LoggingEvent>();
        }

        public List<LoggingEvent> Logs { get; }

        void IAppender.DoAppend(LoggingEvent loggingEvent)
        {
            Logs.Add(loggingEvent);
        }

        void IAppender.Close() { }

        string IAppender.Name { get; set; }

        public void AttachToRoot()
        {
            ((Hierarchy) LogManager.GetRepository()).Root.AddAppender(this);
        }

        public void DetachFromRoot()
        {
            ((Hierarchy) LogManager.GetRepository()).Root.RemoveAppender(this);
        }
    }
}
