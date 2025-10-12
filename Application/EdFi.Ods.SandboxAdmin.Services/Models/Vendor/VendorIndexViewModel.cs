// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.SandboxAdmin.Services.Models.Vendor
{
    public class VendorIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NamespacePrefix { get; set; }

        public string ContactName { get; set; }

        public string ContactEmailAddress { get; set; }

        public bool IsDefaultVendor { get; set; }

    }
}