// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Common.Utils
{
    public static class SystemClock
    {
        public static Func<DateTime> Now = () => { throw new Exception(string.Format("{0} has not been initialized.", typeof(SystemClock))); };

        static SystemClock()
        {
            UseUtcNow();
        }

        public static void UseUtcNow()
        {
            Now = () => DateTime.UtcNow;
        }
    }
}
