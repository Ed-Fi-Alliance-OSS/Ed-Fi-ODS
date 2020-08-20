// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.ApiClient
{
    public static class Utilities
    {
        public static string ConvertJsonToQueryString(string json)
        {
            var obj = JObject.Parse(json).First.First;

            return string.Join(
                "&",
                obj.Children<JProperty>().Select(jp => jp.Name + "=" + Uri.EscapeDataString(jp.Value.ToString()))
            );
        }
    }
}
