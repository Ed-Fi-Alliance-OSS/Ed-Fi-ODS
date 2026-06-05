// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Metadata.Custom;

public class DomainModelCustomMetadata
{
    public List<DateRangeValidation> DateRangeValidations { get; set; }
}

public class DateRangeValidation
{
    public string Schema { get; set; }

    public string EntityName { get; set; }

    public string PropertyName { get; set; }

    public DateTime MinValue { get; set; }

    public DateTime MaxValue { get; set; }
}
