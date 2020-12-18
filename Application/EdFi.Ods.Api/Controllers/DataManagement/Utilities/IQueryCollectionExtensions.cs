// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Utilities
{
    public static class IQueryCollectionExtensions
    {
        public static bool TryGetQueryParameter<T>(this IQueryCollection queryCollection, string parameterName, out T value)
        {
            if (queryCollection.ContainsKey(parameterName))
            {
                value = (T) Convert.ChangeType(queryCollection[parameterName].First(), typeof(T));

                if (value == null)
                {
                    return false;
                }

                return true;
            }

            value = default(T);
            return false;
        }
    }
}
