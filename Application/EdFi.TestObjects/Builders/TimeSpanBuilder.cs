// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;

namespace EdFi.TestObjects.Builders
{
    public class TimeSpanBuilder : NullableValueBuilderBase<TimeSpan>
    {
        private DateTime fromDate = DateTime.Today.AddYears(-10);
        private int offsetMinutes = 1;

        protected override TimeSpan GetNextValue()
        {
            const int minutesPerDay = 24 * 60;

            var toDate = fromDate.AddMinutes(offsetMinutes);
            offsetMinutes = (offsetMinutes + 1) % minutesPerDay;
            return toDate - fromDate;
        }

        public override void Reset()
        {
            fromDate = DateTime.Today.AddYears(-10);
        }
    }
}
