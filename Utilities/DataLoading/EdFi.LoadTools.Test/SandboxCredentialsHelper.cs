// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Xml;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    public static class SandboxCredentialsHelper
    {
        private const string CredentialsFile = @"..\..\..\..\..\..\..\Ed-Fi-ODS-Implementation\Application\EdFi.Ods.SandboxAdmin.Web\AdminCredential.config";

        public static SandboxCredential GetMinimalSandboxCredential()
        {
            return SandboxCredential.Create(GetCredentialFile(), "Minimal Demonstration Sandbox");
        }

        public static SandboxCredential GetPopulatedSandboxCredential()
        {
            return SandboxCredential.Create(GetCredentialFile(), "Populated Demonstration Sandbox");
        }

        private static XmlDocument GetCredentialFile()
        {
            if (!File.Exists(CredentialsFile))
            {
                Assert.Fail("The sandbox credentials file does not exist.");
            }

            var sandboxCredentials = new XmlDocument();
            sandboxCredentials.Load(CredentialsFile);
            return sandboxCredentials;
        }
    }

    public class SandboxCredential
    {
        public string Key { get; set; }

        public string Secret { get; set; }

        public static SandboxCredential Create(XmlDocument document, string sandboxName)
        {
            var sandbox = document.SelectSingleNode($"/initialization/users/add/sandboxes/sandbox[@name='{sandboxName}']");

            if (sandbox == null)
            {
                Assert.Fail($"unable to find sandbox {sandboxName}");
            }

            return new SandboxCredential
                   {
                       Key = sandbox.Attributes["key"].Value, Secret = sandbox.Attributes["secret"].Value
                   };
        }
    }
}
