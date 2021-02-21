// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.LoadTools.ApiClient
{
    public class RemoteFileDownloadResult
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public string FullName { get; set; }
    }
}
