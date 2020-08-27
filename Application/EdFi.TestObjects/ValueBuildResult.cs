// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.TestObjects
{
    public class ValueBuildResult
    {
        public static readonly ValueBuildResult NotHandled = new ValueBuildResult
                                                             {
                                                                 Handled = false
                                                             };

        public static readonly ValueBuildResult Deferred = new ValueBuildResult
                                                           {
                                                               Handled = true, ShouldSetValue = false, ShouldDefer = true
                                                           };

        public bool Handled { get; private set; }

        public bool ShouldSetValue { get; private set; }

        public object Value { get; private set; }

        public bool ShouldSkip
        {
            get { return Handled && !ShouldSetValue && !ShouldDefer; }
        }

        public string LogicalPath { get; private set; }

        public bool ShouldDefer { get; private set; }

        public static ValueBuildResult WithValue(object value, string logicalPath)
        {
            return new ValueBuildResult
                   {
                       Handled = true, ShouldDefer = false, ShouldSetValue = true, Value = value, LogicalPath = logicalPath
                   };
        }

        public static ValueBuildResult Skip(string logicalPath)
        {
            return new ValueBuildResult
                   {
                       Handled = true, ShouldSetValue = false, ShouldDefer = false, LogicalPath = logicalPath
                   };
        }
    }
}
