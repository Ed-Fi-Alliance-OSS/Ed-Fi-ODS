// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess;

namespace EdFi.Ods.Sandbox.Provisioners
{
    public class SandboxStatus
    {
        public byte Code { get; set; }

        public string Description { get; set; }

        public static SandboxStatus ErrorStatus()
        {
            return new SandboxStatus
                   {
                       Code = byte.MaxValue, Description = "ERROR"
                   };
        }
    }

    public interface ISandboxProvisioner
    {
        void AddSandbox(string sandboxKey, SandboxType sandboxType);

        void DeleteSandboxes(params string[] deletedClientKeys);

        SandboxStatus GetSandboxStatus(string clientKey);

        void ResetDemoSandbox();

        string[] GetSandboxDatabases();
    }
}
