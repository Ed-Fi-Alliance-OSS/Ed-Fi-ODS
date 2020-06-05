// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Utils;

namespace EdFi.Ods.Sandbox.Provisioners
{
    /// <summary>
    /// Test Sandbox Provisioner doesn't actually create sandboxes.
    /// </summary>
    public class StubSandboxProvisioner : ISandboxProvisioner
    {
        private static readonly List<string> SandboxKeys = new List<string>();

        public void AddSandbox(string sandboxKey, SandboxType sandboxType)
        {
            if (SandboxKeys.Contains(sandboxKey))
            {
                throw new Exception("At least one sandbox already exists");
            }

            SandboxKeys.Add(sandboxKey);
        }

        public void DeleteSandboxes(params string[] deletedClientKeys)
        {
            if (!deletedClientKeys.ToList()
                                  .TrueForAll(x => SandboxKeys.Contains(x)))
            {
                throw new Exception("At least one of the sandboxes does not exist");
            }

            SandboxKeys.RemoveAll(deletedClientKeys.Contains);
        }

        public SandboxStatus GetSandboxStatus(string clientKey)
        {
            return SandboxKeys.Contains(clientKey)
                ? new SandboxStatus
                  {
                      Code = 0, Description = ApiClientStatus.Online
                  }
                : SandboxStatus.ErrorStatus();
        }

        public void ResetDemoSandbox()
        {
            // Nothing to do 
        }

        public string[] GetSandboxDatabases()
        {
            return SandboxKeys.Select(DatabaseNameBuilder.SandboxNameForKey)
                              .ToArray();
        }

        public string GetConnectionString(string clientKey)
        {
            throw new Exception("Cannot get a connection to a stubbed sandbox.");
        }
    }
}
