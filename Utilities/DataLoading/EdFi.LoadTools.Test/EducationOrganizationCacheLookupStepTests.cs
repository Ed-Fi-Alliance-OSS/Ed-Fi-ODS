// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Xml.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class EducationOrganizationCacheLookupStepTests
    {
        private static Dictionary<string, List<LookupProperty>> _lookupPropertyValuesByName;

        private readonly string _educationOrganizationReferenceElement = @"<EducationOrganizationLookup>
			                                                        <EducationOrganizationIdentificationCode>
				                                                        <IdentificationCode>255950</IdentificationCode>
				                                                        <EducationOrganizationIdentificationSystem>uri://ed-fi.org/EducationOrganizationIdentificationSystemDescriptor#NCES</EducationOrganizationIdentificationSystem>
			                                                        </EducationOrganizationIdentificationCode>
			                                                        <NameOfInstitution>Region 9</NameOfInstitution>
			                                                        <EducationOrganizationCategory>uri://ed-fi.org/EducationOrganizationCategoryDescriptor#School</EducationOrganizationCategory>
                                                                    </EducationOrganizationLookup>";

        [Test]
        public void Should_correctly_build_lookup_property_dictionary_from_LookupXml()
        {
            var xelement = XElement.Parse(_educationOrganizationReferenceElement);

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "EducationOrganization", LookupName = "EducationOrganizationLookup",
                           IdentityName = "EducationOrganizationIdentity"
                       };

            var step = new EducationOrganizationCacheLookupStep(
                new TestEducationOrganizationIdentityCache(
                    new List<int>
                    {
                        9999
                    }));

            step.Process(item);

            Assert.AreEqual(_lookupPropertyValuesByName.Count, 4);

            foreach (var expectedKey in new List<string>
                                        {
                                            "EducationOrganizationCategory", "EducationOrganizationIdentificationSystem", "IdentificationCode",
                                            "NameOfInstitution"
                                        })
            {
                Assert.IsTrue(_lookupPropertyValuesByName.ContainsKey(expectedKey));
            }
        }

        [Test]
        public void Should_correctly_set_IdentityXElement_if_EdOrg_found_in_identity_cache()
        {
            var xelement = XElement.Parse(_educationOrganizationReferenceElement);

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "EducationOrganization", LookupName = "EducationOrganizationLookup",
                           IdentityName = "EducationOrganizationIdentity"
                       };

            var step = new EducationOrganizationCacheLookupStep(
                new TestEducationOrganizationIdentityCache(
                    new List<int>
                    {
                        9999
                    }));

            step.Process(item);

            Assert.AreEqual(
                item.IdentityXElement.ToString(),
                new XElement(item.IdentityName, new XElement($"{item.ResourceName}Id", 9999)).ToString());
        }

        [Test]
        public void Should_not_set_IdentityXElement_if_no_EdOrg_is_found_in_cache()
        {
            var xelement = XElement.Parse(_educationOrganizationReferenceElement);

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "EducationOrganization", LookupName = "EducationOrganizationLookup",
                           IdentityName = "EducationOrganizationIdentity"
                       };

            var step = new EducationOrganizationCacheLookupStep(
                new TestEducationOrganizationIdentityCache(new List<int>()));

            step.Process(item);

            Assert.IsNull(item.IdentityXElement);
        }

        [Test]
        public void Should_not_set_IdentityXElement_more_than_1_edorg_is_found_in_cache_for_provided_lookup_columns()
        {
            var xelement = XElement.Parse(_educationOrganizationReferenceElement);

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "EducationOrganization", LookupName = "EducationOrganizationLookup",
                           IdentityName = "EducationOrganizationIdentity"
                       };

            var step = new EducationOrganizationCacheLookupStep(
                new TestEducationOrganizationIdentityCache(
                    new List<int>
                    {
                        123, 456
                    }));

            step.Process(item);

            Assert.IsNull(item.IdentityXElement);
        }

        [Test]
        public void Should_only_process_education_organization_lookups()
        {
            var xelement = XElement.Parse(_educationOrganizationReferenceElement);

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "EducationOrganization", LookupName = "NotEducationOrganizationLookup",
                           IdentityName = "EducationOrganizationIdentity"
                       };

            var step = new EducationOrganizationCacheLookupStep(
                new TestEducationOrganizationIdentityCache(
                    new List<int>
                    {
                        123, 456
                    }));

            step.Process(item);

            Assert.IsNull(item.IdentityXElement);
        }

        private class TestEducationOrganizationIdentityCache : IEducationOrganizationIdentityCache
        {
            private readonly List<int> _educationOrganizationIds;

            public TestEducationOrganizationIdentityCache(List<int> educationOrganizationIds)
            {
                _educationOrganizationIds = educationOrganizationIds;
            }

            public IEnumerable<int> Get(Dictionary<string, List<LookupProperty>> lookupPropertyValuesByName)
            {
                _lookupPropertyValuesByName = lookupPropertyValuesByName;
                return _educationOrganizationIds;
            }
        }
    }
}
