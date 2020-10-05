// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Bogus;
using EdFi.Ods.Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi;
using EdFi.Ods.Entities.NHibernate.EducationOrganizationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;

namespace EdFi.Ods.WebApi.ProfileSpecFlowTests.Fakes
{
    public class FakeGenerator
    {
        private readonly IDictionary<int, string> _descriptorsById = new Dictionary<int, string>();
        private readonly IDictionary<int, string> _educationOrganizationNameById = new Dictionary<int, string>();

        public List<SchoolCategory> SchoolCategories(int total = 1)
        {
            return new Faker<SchoolCategory>()
                .RuleFor(
                    p => p.SchoolCategoryDescriptor,
                    f => $"SchoolCategoryDescriptor#{f.Random.String2(10)}")
                .RuleFor(p => p.SchoolCategoryDescriptorId, f => f.Random.Int(1, 1000))
                .Generate(total);
        }

        public List<EducationOrganizationAddress> EducationOrganizationAddresses(int total = 1)
        {
            return new Faker<EducationOrganizationAddress>()
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.PostalCode, f => f.Address.ZipCode())
                .RuleFor(p => p.StreetNumberName, f => f.Address.StreetAddress())
                .RuleFor(p => p.BuildingSiteNumber, f => f.Address.BuildingNumber())
                .RuleFor(p => p.StateAbbreviationDescriptor, f => $"StateAbbreviationDescriptor#{f.Address.StateAbbr()}")
                .RuleFor(p => p.StateAbbreviationDescriptorId, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.AddressTypeDescriptor, f => $"AddressTypeDescriptor#{f.Random.String2((10))}")
                .Generate(total);
        }

        public List<EducationOrganizationCategory> EducationOrganizationCategories(int total = 1)
        {
            return new Faker<EducationOrganizationCategory>()
                .RuleFor(
                    p => p.EducationOrganizationCategoryDescriptor,
                    f => $"EducationOrganizationCategoryDescriptor#{f.Random.String2(10)}")
                .RuleFor(p => p.EducationOrganizationCategoryDescriptorId, f => f.Random.Int(1, 1000))
                .Generate(total);
        }

        public List<SchoolGradeLevel> SchoolGradeLevels(int total = 1)
        {
            return new Faker<SchoolGradeLevel>()
                .RuleFor(p => p.GradeLevelDescriptor, f => $"GradeLevelDescriptor#{f.Random.String2(10)}")
                .RuleFor(p => p.GradeLevelDescriptorId, f => f.Random.Int(1, 1000))
                .Generate(total);
        }

        public List<School> Schools(int total = 1)
        {
            return new Faker<School>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.SchoolId, f => f.IndexFaker)
                .RuleFor(p => p.SchoolCategories, f => SchoolCategories(f.Random.Int(1, 5)))
                .RuleFor(p => p.SchoolTypeDescriptor, f => $"SchoolCategoryDescriptor#{f.Random.String2(10)}")
                .RuleFor(p => p.SchoolTypeDescriptorId, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.EducationOrganizationAddresses, f => EducationOrganizationAddresses(f.Random.Int(1, 3)))
                .RuleFor(p => p.EducationOrganizationId, f => f.IndexFaker)
                .RuleFor(p => p.NameOfInstitution, f => f.Company.CompanyName())
                .RuleFor(p => p.EducationOrganizationCategories, f => EducationOrganizationCategories(f.Random.Int(1,5)))
                .RuleFor(p => p.SchoolTypeDescriptorId, f => f.Random.Int(1, 1000))
                .RuleFor(p => p.SchoolTypeDescriptor, f => $"SchoolTypeDescriptor#{f.Random.String2(10)}")
                .RuleFor(p => p.SchoolGradeLevels, f => SchoolGradeLevels(f.Random.Int(1, 13)))
                .RuleFor(p => p.WebSite, f => f.Internet.Url())
                .Generate(total);
        }

        public List<StudentSpecialEducationProgramAssociation> StudentSpecialEducationProgramAssociations(int total = 1)
        {
            return new Faker<StudentSpecialEducationProgramAssociation>()
                .Generate(total);
        }
    }
}
