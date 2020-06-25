// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class ResourceStatistic
    {
        public long Resources { get; set; }
        public double Milliseconds { get; set; }

        public double AvgResourcesPerSec() => Milliseconds != 0 ? Math.Round(Resources / (Milliseconds / 1000), 3) : 0;
    }
}
