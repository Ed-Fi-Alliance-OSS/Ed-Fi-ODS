// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Admin.DataAccess;
using EdFi.Ods.Sandbox.Provisioners;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox._Stubs
{
    public class TestSandboxProvisioner : ISandboxProvisioner
    {
        private readonly List<Sandbox> _sandboxes = new List<Sandbox>();

        public Sandbox[] AddedSandboxes
        {
            get { return _sandboxes.ToArray(); }
        }

        public void AddSandbox(string sandboxKey, SandboxType sandboxType)
        {
            _sandboxes.Add(
                new Sandbox
                {
                    Key = sandboxKey, SandboxType = sandboxType
                });
        }

        public void DeleteSandboxes(params string[] deletedClientKeys)
        {
            throw new NotImplementedException();
        }

        public SandboxStatus GetSandboxStatus(string clientKey)
        {
            throw new NotImplementedException();
        }

        public void ResetDemoSandbox()
        {
            throw new NotImplementedException();
        }

        public string[] GetSandboxDatabases()
        {
            throw new NotImplementedException();
        }

        public class Sandbox
        {
            public string Key { get; set; }

            public SandboxType SandboxType { get; set; }
        }
    }
}
