// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers
{
    public static class OpenApiCompositeHelper
    {
        public static string CategoryName => CompositeDefinition.XPathSelectElement("/Category")
                                                                .AttributeValue("name");

        public static IReadOnlyList<XElement> Routes => CompositeDefinition.XPathSelectElements("/Category/Routes/Route")
                                                                           .ToList();

        public static IReadOnlyList<XElement> CompositeDefinitions => CompositeDefinition.XPathSelectElements("/Category/Composites/Composite")
                                                                                         .ToList();

        public static XElement CompositeDefinition => XElement.Parse(
            @"<?xml version='1.0' encoding='utf-8' ?>
                        <CompositeMetadata>
                          <Category displayName='Ed-Fi Assessment' name='assessment'>
                            <Routes>
                              <Route relativeRouteTemplate='/localEducationAgencies/{LocalEducationAgency.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/schools/{School.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/staffs/{Staff.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/sections/{Section.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/programs/{Program.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/students/{Student.Id}/{compositeName}' />
                              <Route relativeRouteTemplate='/assessments/{Assessment.Id}/{compositeName}' />
                            </Routes>
                            <Composites>
                              <Composite name='Assessment'>
                                <Specification>
                                  <Parameter name='LocalEducationAgency.Id' filterPath='StudentAssessments->Student->StudentSchoolAssociations->School->LocalEducationAgency.Id' />
                                  <Parameter name='School.Id' filterPath='StudentAssessments->Student->StudentSchoolAssociations->School.Id' />
                                  <Parameter name='Staff.Id' filterPath='AssessmentSections->Section->StaffSectionAssociations->Staff.Id' />
                                  <Parameter name='Section.Id' filterPath='AssessmentSections->Section.Id' />
                                  <Parameter name='Program.Id' filterPath='AssessmentPrograms->Program.Id' />
                                  <Parameter name='Student.Id' filterPath='StudentAssessments->Student.Id' />
                                </Specification>
                                <BaseResource name='Assessment'>
                                  <Property name='Id' />
                                  <Property name='AssessmentTitle' />
                                  <Collection name='AssessmentAcademicSubjects' displayName='academicSubjects'>
                                    <Property name='AcademicSubjectDescriptor' />
                                  </Collection>
                                  <Collection name='AssessmentAssessedGradeLevels' displayName='assessedGradeLevels'>
                                    <Property name='GradeLevelDescriptor' />
                                  </Collection>
                                  <Property name='AssessmentVersion' />
                                  <Property name='AssessmentCategoryDescriptor' />
                                  <Property name='AssessmentForm' />
                                  <Property name='AssessmentFamily' />
                                  <LinkedCollection name='ObjectiveAssessments' useHierarchy='true'>
                                    <Property name='Id' />
                                    <Property name='IdentificationCode' />
                                    <Property name='Description' />
                                    <Property name='MaxRawScore' />
                                    <Property name='Nomenclature' />
                                    <Property name='PercentOfAssessment' />
                                    <Collection name='ObjectiveAssessmentPerformanceLevels'>
                                      <Property name='PerformanceLevelDescriptor' />
                                      <Property name='AssessmentReportingMethodDescriptor' />
                                      <Property name='MinimumScore' />
                                      <Property name='MaximumScore' />
                                      <Property name='ResultDatatypeTypeDescriptor' />
                                    </Collection>
                                    <Collection name='ObjectiveAssessmentLearningObjectives' displayName='learningObjectives'>
                                      <ReferencedResource name='LearningObjectiveReference' flatten='true'>
                                        <Property name='Id' />
                                        <Property name='Objective' />
                                        <Collection name='LearningObjectiveGradeLevels' displayName='gradeLevels'>
                                          <Property name='GradeLevelDescriptor' />
                                        </Collection>
                                        <Collection name='LearningObjectiveAcademicSubjects' displayName='academicSubjects'>
                                          <Property name='AcademicSubjectDescriptor' />
                                        </Collection>
                                        <Property name='Description' />
                                        <Property name='LearningObjectiveId' />
                                        <Property name='Nomenclature' />
                                        <Property name='SuccessCriteria' />
                                        <Collection name='LearningObjectiveLearningStandards' displayName='learningStandards'>
                                          <ReferencedResource name='LearningStandardReference' flatten='true'>
                                            <Property name='Id' />
                                            <Property name='Description' />
                                            <Property name='LearningStandardId' />
                                            <Property name='Namespace' />
                                            <Property name='CourseTitle' />
                                            <Collection name='LearningStandardIdentificationCodes' displayName='learningStandardIdentificationCodes'>
                                              <Property name='IdentificationCode' />
                                              <Property name='ContentStandardName' />
                                            </Collection>
                                            <Property name='LearningStandardItemCode' />
                                            <Property name='SuccessCriteria' />
                                            <Property name='URI' />
                                          </ReferencedResource>
                                        </Collection>
                                      </ReferencedResource>
                                    </Collection>
                                  </LinkedCollection>
                                </BaseResource>
                              </Composite>
                            </Composites>
                          </Category>
                        </CompositeMetadata>");
    }
}
