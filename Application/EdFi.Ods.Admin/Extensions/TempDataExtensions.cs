// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Web.Mvc;

namespace EdFi.Ods.Admin.Extensions
{
    public static class TempDataExtensions
    {
        private const string ErrorKey = "ErrorMessage";

        public static void SetErrorMessage(this TempDataDictionary tempData, string message)
        {
            tempData[ErrorKey] = message;
        }

        public static bool HasErrorMessage(this TempDataDictionary tempData)
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

        public static string GetErrorMessage(this TempDataDictionary tempData)
        {
            return (string) tempData[ErrorKey];
        }

        public static void SetFlag(this TempDataDictionary tempData, string key)
        {
            tempData[key] = true;
        }

        public static bool GetFlag(this TempDataDictionary tempData, string key)
        {
            return tempData.ContainsKey(key);
        }
    }
}
