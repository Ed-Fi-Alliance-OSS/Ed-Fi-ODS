// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Extensions;
using EdFi.TestFixture;
using Test.Common;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Specifications
{
    public class FullNameExtensionTests : TestFixtureBase
    {
        private bool _actualResultForEdFiStandardName;
        private bool _actualResultForMisnamedResource;
        private bool _actualResultForNonEdFiSchema;

        protected override void Act()
        {
            _actualResultForEdFiStandardName = (new FullName(EdFiConventions.PhysicalSchemaName, "SchoolYearType"))
                .IsEdFiSchoolYearType();

            _actualResultForMisnamedResource = (new FullName(EdFiConventions.PhysicalSchemaName, "NotSchoolYearType"))
                .IsEdFiSchoolYearType();

            _actualResultForNonEdFiSchema = (new FullName("notEdFi", "SchoolYearType"))
                .IsEdFiSchoolYearType();
        }

        [Assert]
        public void Should_indicate_the_SchoolYearType_with_the_EdFi_schema_is_the_EdFi_SchoolYearType()
        {
            _actualResultForEdFiStandardName.ShouldBe(true);
        }

        [Assert]
        public void Should_indicate_the_non_SchoolYearType_name_is_NOT_the_EdFi_SchoolYearType()
        {
            _actualResultForMisnamedResource.ShouldBe(false);
        }

        [Assert]
        public void Should_indicate_the_SchoolYearType_with_an_extension_schema_is_NOT_the_EdFi_SchoolYearType()
        {
            _actualResultForNonEdFiSchema.ShouldBe(false);
        }
    }
}
