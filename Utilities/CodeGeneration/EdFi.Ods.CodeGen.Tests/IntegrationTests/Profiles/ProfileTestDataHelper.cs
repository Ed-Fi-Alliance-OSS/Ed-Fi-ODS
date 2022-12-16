// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Xml.Linq;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Profiles
{
    public static class ProfileTestDataHelper
    {
        public static XDocument LoadProfileDocument(string profileDefinitionName)
        {
            using var stream = typeof(ProfileTestDataHelper).Assembly.GetManifestResourceStream(
                typeof(ProfileTestDataHelper),
                $"TestProfiles.{profileDefinitionName}");

            return XDocument.Load(stream);
        }
    }
}
