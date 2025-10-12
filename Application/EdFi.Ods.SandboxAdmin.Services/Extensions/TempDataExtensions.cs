// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EdFi.Ods.SandboxAdmin.Services.Extensions
{
    public static class TempDataExtensions
    {
        private const string ErrorKey = "ErrorMessage";

        public static void SetErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[ErrorKey] = message;
        }

        public static bool HasErrorMessage(this ITempDataDictionary tempData)
        {
            var hasKey = tempData.ContainsKey(ErrorKey);

            if (!hasKey)
            {
                return false;
            }

            var value = tempData[ErrorKey];

            if (value == null)
            {
                return false;
            }

            return !string.IsNullOrWhiteSpace(value.ToString());
        }

        public static string GetErrorMessage(this ITempDataDictionary tempData)
        {
            return (string)tempData[ErrorKey];
        }

        public static void SetFlag(this ITempDataDictionary tempData, string key)
        {
            tempData[key] = true;
        }

        public static bool GetFlag(this ITempDataDictionary tempData, string key)
        {
            return tempData.ContainsKey(key);
        }
    }
}