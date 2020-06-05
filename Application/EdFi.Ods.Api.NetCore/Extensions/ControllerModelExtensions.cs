// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.NetCore.Extensions
{
    public static class ControllerModelExtensions
    {
        public static bool IsDataManagementController(this ControllerModel controller)
            => controller.ControllerType.BaseType != null
               && controller.ControllerType.BaseType != typeof(ControllerBase)
               && controller.ControllerType.BaseType.IsGenericType
               && controller.ControllerType.BaseType.Name
                   .StartsWith("DataManagement", StringComparison.InvariantCultureIgnoreCase);
   }
}
