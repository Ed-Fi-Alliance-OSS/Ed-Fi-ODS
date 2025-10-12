// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Sandbox;

namespace EdFi.Ods.SandboxAdmin.Services.Models.Client
{
    public class ClientIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ApplicationName { get; set; }

        public string Key { get; set; }

        public string Secret { get; set; }

        public string Status { get; set; }

        public string SandboxTypeName { get; set; }

        public string OperationalContextUri { get; set; }

        public bool IsLoading
        {
            get { return Status != ApiClientStatus.Online; }
        }
    }
}