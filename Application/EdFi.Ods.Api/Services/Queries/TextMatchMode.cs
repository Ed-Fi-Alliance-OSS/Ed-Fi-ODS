// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Services.Queries
{
    public enum TextMatchMode
    {
        Anywhere,
        Start,
        End,
        Exact
    }

    // TODO: Support date/numeric ranges
    //public class DateRangeCriteria : QueryCriteriaBase
    //{
    //    public bool MinInclusive { get; set; }
    //    public bool MaxInclusive { get; set; }

    //    public DateTime MinValue { get; set; }
    //    public DateTime MaxValue { get; set; }
    //}

    //public class NumericRangeCriteria : QueryCriteriaBase
    //{
    //    public bool MinInclusive { get; set; }
    //    public bool MaxInclusive { get; set; }

    //    public decimal MinValue { get; set; }
    //    public decimal MaxValue { get; set; }
    //}
}
