// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Security.Conventions;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Conventions
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
        
        public class When_parsing_schema_name_from_a_namespace_for_a_standard_resource_in_a_profile : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Standard resource in a Profile
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable";

                _actualSchemaName = EdFiSecurityConventions.ParseResourceSchemaProperCaseName(@namespace);
            }

            [Assert]
            public void Should_parse_the_supplied_schema()
            {
                _actualSchemaName.ShouldBe("EdFi");
            }
        }
        
        public class When_parsing_schema_name_from_a_namespace_for_an_extension_resource_in_a_profile : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Extension resource in a Profile
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.Applicant.GrandBend.Staff_and_Prospect_MixedInclude_Writable";

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

        public class When_parsing_schema_name_from_a_namespace_for_a_resource_class_with_a_base_class_context : TestFixtureBase
        {
            private string _actualSchemaName;

            protected override void Act()
            {
                // Resource class with base class context -- Not authorizable
                string @namespace = $"{Namespaces.Resources.BaseNamespace}.EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School"; // ParentAddressExtension

                _actualSchemaName = EdFiSecurityConventions.ParseResourceSchemaProperCaseName(@namespace);
            }

            [Assert]
            public void Should_throw_an_ArgumentException_indicating_that_resource_extensions_are_not_authorizable()
            {
                ActualException.ShouldBeOfType<Exception>();
                ActualException.Message.ShouldBe("Resource classes with a base resource context for a Profile are not authorizable so schema name extraction from class namespace is not supported.");
            }
        }
    }
}
