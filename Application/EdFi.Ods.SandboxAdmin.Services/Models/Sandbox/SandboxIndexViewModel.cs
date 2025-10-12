// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.SandboxAdmin.Services.Models.Sandbox
{
    public class SandboxViewModel
    {
        public string User { get; set; }

        public string ApplicationName { get; set; }

        public string Client { get; set; }

        public string Sandbox { get; set; }
    }

    public class SandboxIndexViewModel
    {
        public string[] AllSandboxes { get; set; }

        public SandboxViewModel[] OwnedSandboxes { get; set; }

        public SandboxViewModel[] MissingSandboxes { get; set; }

        public string[] OrphanSandboxes { get; set; }

        public bool HasSandboxes
        {
            get { return AllSandboxes.Length > 0; }
        }

        public bool HasOrphans
        {
            get { return OrphanSandboxes.Length > 0; }
        }

        public bool HasOwnedSandboxes
        {
            get { return OwnedSandboxes.Length > 0; }
        }

        public bool HasMissing
        {
            get { return MissingSandboxes.Length > 0; }
        }
    }
}