// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;

namespace EdFi.TestObjects.Builders
{
    public class DateTimeBuilder : NullableValueBuilderBase<DateTime>
    {
        private DateTime nextDate;

        public DateTimeBuilder()
        {
            Reset();
        }

        protected override DateTime GetNextValue()
        {
            var value = nextDate;
            nextDate = nextDate.AddDays(1);
            return value;
        }

        public override void Reset()
        {
            // Initializes a date based on today, but with "Local" date Kind.
            var nextDateLocal = DateTime.Today.AddYears(-10);

            // Initialize the "next" date value using a date Kind of "Unspecified"
            nextDate = new DateTime(nextDateLocal.Year, nextDateLocal.Month, nextDateLocal.Day);
        }
    }
}
