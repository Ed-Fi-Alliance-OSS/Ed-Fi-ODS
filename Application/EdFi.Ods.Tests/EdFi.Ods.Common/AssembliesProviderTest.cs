// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Composites.Test;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    [TestFixture]
    public class AssembliesProviderTest
    {
        public IAssembliesProvider SystemUnderTest = new AssembliesProvider();

        [Test]
        public void Should_get_assembly_containing_type()
        {
            //DynamicProxyGEnAssembly2 is a temporary assembly built by mocking systems. Excluding assembly for testing. 
            //https://stackoverflow.com/questions/15405040/what-is-the-dynamicproxygenassembly2-assembly
            var assemblies = SystemUnderTest.GetAssembliesContaining<IAssembliesProvider>().Where(a => !a.GetName().Name.Equals("DynamicProxyGenAssembly2"));

            AssertHelper.All(() => assemblies.Count().ShouldBe(1), () =>
                {
                    var assemblyName = assemblies.FirstOrDefault()?.GetName().Name ?? string.Empty;

                    assemblyName.ShouldBe("EdFi.Ods.Common");
                });
        }

        [Test]
        public void Should_not_get_assembly_containing_type_because_type_not_implemented()
        {
            var assemblies = SystemUnderTest.GetAssembliesContaining<Marker_EdFi_Ods_Composites_Test>();

            AssertHelper.All(() => assemblies.Length.ShouldBe(0));
        }
    }
}
