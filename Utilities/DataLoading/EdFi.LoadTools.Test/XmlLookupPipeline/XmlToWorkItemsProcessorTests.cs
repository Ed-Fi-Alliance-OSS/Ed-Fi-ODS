// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using NUnit.Framework;

namespace EdFi.LoadTools.Test.XmlLookupPipeline
{
    [TestFixture]
    public class XmlToWorkItemsProcessorTests
    {
        private readonly XElement _lookupInsideIdentity = XElement.Parse(
            @"  <StudentAssessment>
    <AdministrationDate>2015-11-07</AdministrationDate>
    <ScoreResult>
      <Result>640</Result>
      <ResultDatatypeType>Integer</ResultDatatypeType>
      <AssessmentReportingMethod>College Board examination scores</AssessmentReportingMethod>
    </ScoreResult>
    <StudentReference>
      <StudentIdentity>
        <StudentUniqueId>605750</StudentUniqueId>
        <TestReference>
            <TestLookup>
                <Name>Some Lookup Name</Name>
            </TestLookup>
        </TestReference>
      </StudentIdentity>
      <StudentLookup>
        <StudentUniqueId>605750</StudentUniqueId>
        <Name>
          <FirstName>Kent</FirstName>
          <LastSurname>Wyatt</LastSurname>
        </Name>
        <BirthData>
          <BirthDate>1995-10-31</BirthDate>
        </BirthData>
        <EducationOrganizationReference>
          <EducationOrganizationLookup>
            <EducationOrganizationId>255901001</EducationOrganizationId>
          </EducationOrganizationLookup>
        </EducationOrganizationReference>
      </StudentLookup>
    </StudentReference>
    <AssessmentReference>
      <AssessmentLookup>
        <AssessmentTitle>SAT-HighestCompositeSection</AssessmentTitle>
        <AcademicSubject>
          <CodeValue>Writing</CodeValue>
        </AcademicSubject>
        <AssessedGradeLevel>
          <CodeValue>Twelfth grade</CodeValue>
        </AssessedGradeLevel>
      </AssessmentLookup>
    </AssessmentReference>
  </StudentAssessment>
");

        private readonly XElement _nestedLookups = XElement.Parse(
            @"  <StudentAssessment>
    <AdministrationDate>2015-11-07</AdministrationDate>
    <ScoreResult>
      <Result>640</Result>
      <ResultDatatypeType>Integer</ResultDatatypeType>
      <AssessmentReportingMethod>College Board examination scores</AssessmentReportingMethod>
    </ScoreResult>
    <StudentReference>
      <StudentLookup>
        <StudentUniqueId>605750</StudentUniqueId>
        <Name>
          <FirstName>Kent</FirstName>
          <LastSurname>Wyatt</LastSurname>
        </Name>
        <BirthData>
          <BirthDate>1995-10-31</BirthDate>
        </BirthData>
        <EducationOrganizationReference>
          <EducationOrganizationLookup>
            <EducationOrganizationId>255901001</EducationOrganizationId>
          </EducationOrganizationLookup>
        </EducationOrganizationReference>
      </StudentLookup>
    </StudentReference>
    <AssessmentReference>
      <AssessmentLookup>
        <AssessmentTitle>SAT-HighestCompositeSection</AssessmentTitle>
        <AcademicSubject>
          <CodeValue>Writing</CodeValue>
        </AcademicSubject>
        <AssessedGradeLevel>
          <CodeValue>Twelfth grade</CodeValue>
        </AssessedGradeLevel>
      </AssessmentLookup>
    </AssessmentReference>
  </StudentAssessment>
");

        private readonly XElement _resolvedLookup = XElement.Parse(
            @"  <StudentAssessment>
    <AdministrationDate>2015-11-07</AdministrationDate>
    <ScoreResult>
      <Result>640</Result>
      <ResultDatatypeType>Integer</ResultDatatypeType>
      <AssessmentReportingMethod>College Board examination scores</AssessmentReportingMethod>
    </ScoreResult>
    <StudentReference>
      <StudentIdentity>
        <StudentUniqueId>605750</StudentUniqueId>
      </StudentIdentity>
      <StudentLookup>
        <StudentUniqueId>605750</StudentUniqueId>
        <Name>
          <FirstName>Kent</FirstName>
          <LastSurname>Wyatt</LastSurname>
        </Name>
        <BirthData>
          <BirthDate>1995-10-31</BirthDate>
        </BirthData>
        <EducationOrganizationReference>
          <EducationOrganizationLookup>
            <EducationOrganizationId>255901001</EducationOrganizationId>
          </EducationOrganizationLookup>
        </EducationOrganizationReference>
      </StudentLookup>
    </StudentReference>
    <AssessmentReference>
      <AssessmentLookup>
        <AssessmentTitle>SAT-HighestCompositeSection</AssessmentTitle>
        <AcademicSubject>
          <CodeValue>Writing</CodeValue>
        </AcademicSubject>
        <AssessedGradeLevel>
          <CodeValue>Twelfth grade</CodeValue>
        </AssessedGradeLevel>
      </AssessmentLookup>
    </AssessmentReference>
  </StudentAssessment>
");

        private XmlLookupWorkItem[] TestWorkItems(XElement xElement)
        {
            var processor = new XmlToWorkItemsProcessor();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xElement.ToString()));
            var reader = new XmlTextReader(stream);
            var workItems = processor.GetLookupWorkItems(reader).ToArray();

            foreach (var xmlLookupWorkItem in workItems)
            {
                Console.WriteLine(xmlLookupWorkItem.LookupXElement);
            }

            return workItems;
        }

        [Test]
        public void Should_have_one_work_items_lookup()
        {
            var items = TestWorkItems(_resolvedLookup);
            Assert.AreEqual(1, items.Length);
        }

        [Test]
        public void Should_have_two_work_items_lookup()
        {
            var items = TestWorkItems(_lookupInsideIdentity);
            Assert.AreEqual(2, items.Length);
        }

        [Test]
        public void Should_have_three_work_items_lookups()
        {
            var items = TestWorkItems(_nestedLookups);
            Assert.AreEqual(3, items.Length);
        }
    }
}
