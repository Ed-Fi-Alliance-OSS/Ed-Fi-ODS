// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Context
{
    public class SchoolYearContextProvider : ISchoolYearContextProvider, IHttpContextStorageTransferKeys
    {
        private const string SchoolYearContextKey = "SchoolYearContextProvider.SchoolYear";

        private readonly IContextStorage contextStorage;

        public SchoolYearContextProvider(IContextStorage contextStorage)
        {
            this.contextStorage = contextStorage;
        }

        /// <summary>
        /// Declare the <see cref="IContextStorage"/> keys that are read and written by the component
        /// and should be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/> for background Tasks.
        /// </summary>
        /// <returns>A list of keys to be transferred from <see cref="HttpContext"/> to <see cref="CallContext"/>.</returns>
        IReadOnlyList<string> IHttpContextStorageTransferKeys.GetKeys()
        {
            return new[]
                   {
                       SchoolYearContextKey
                   };
        }

        public int GetSchoolYear()
        {
            return contextStorage.GetValue<int>(SchoolYearContextKey);
        }

        public void SetSchoolYear(int schoolYear)
        {
            contextStorage.SetValue(SchoolYearContextKey, schoolYear);
        }
    }
}
