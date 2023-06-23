// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Api.Security.Conventions;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Conventions
{
    [TestFixture]
    public class EdFiSecurityConventionsTests
    {
        public class When_parsing_schema_name_from_a_namespace_for_a_standard_resource : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Standard resource
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.School.EdFi";

                _actualSchemaName = EdFiSecurityConventions.ParseResourceSchemaProperCaseName(@namespace);
            }

            [Assert]
            public void Should_parse_the_supplied_schema()
            {
                _actualSchemaName.ShouldBe("EdFi");
            }
        }

        public class When_parsing_schema_name_from_a_namespace_for_an_extension_resource : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Extension resource
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.Applicant.GrandBend";

                _actualSchemaName = EdFiSecurityConventions.ParseResourceSchemaProperCaseName(@namespace);
            }

            [Assert]
            public void Should_parse_the_supplied_schema()
            {
                _actualSchemaName.ShouldBe("GrandBend");
            }
        }

        public class When_parsing_schema_name_from_a_namespace_for_a_resource_extension_class : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Resource extension -- Not authorizable
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.Parent.EdFi.Extensions.Sample"; // ParentAddressExtension

                _actualSchemaName = EdFiSecurityConventions.ParseResourceSchemaProperCaseName(@namespace);
            }

            [Assert]
            public void Should_throw_an_ArgumentException_indicating_that_resource_extensions_are_not_authorizable()
            {
                ActualException.ShouldBeOfType<ArgumentException>();
                ActualException.Message.ShouldBe("Resource extensions are not authorizable so schema name extraction from the class namespace is not supported.");
            }
        }
    }
}