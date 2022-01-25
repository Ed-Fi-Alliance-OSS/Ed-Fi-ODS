DECLARE @ClaimSetId INT;
DECLARE @AuthorizationStrategyId INT;
DECLARE @applicationId INT;

DECLARE @peopleResourceClaimId INT;
DECLARE @relationshipBasedDataResourceClaimId INT;
DECLARE @assessmentMetadataResourceClaimId INT;
DECLARE @educationStandardsResourceClaimId INT;
DECLARE @primaryRelationshipsResourceClaimId INT;
DECLARE @educationOrganizationsResourceClaimId INT;
DECLARE @typesResourceClaimId INT;
DECLARE @systemDescriptorsResourceClaimId INT;
DECLARE @managedDescriptorsResourceClaimId INT;
DECLARE @identityResourceClaimId INT;
DECLARE @surveyDomainResourceClaimId INT;

/* --------------------------------- */
/*             Actions               */
/* --------------------------------- */

INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Create' , 'http://ed-fi.org/odsapi/actions/create');
INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Read' , 'http://ed-fi.org/odsapi/actions/read');
INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Update' , 'http://ed-fi.org/odsapi/actions/update');
INSERT INTO [dbo].[Actions] ([ActionName], [ActionUri]) VALUES ('Delete' , 'http://ed-fi.org/odsapi/actions/delete');

/* --------------------------------- */

/* --------------------------------- */
/*           Applications            */
/* --------------------------------- */

INSERT INTO [dbo].[Applications] ([ApplicationName])
VALUES ('Ed-Fi ODS API');

SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

/* --------------------------------- */

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Namespace Based', 'NamespaceBased', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Relationships with Students only (through StudentEducationOrganizationAssociation)', 'RelationshipsWithStudentsOnlyThroughEdOrgAssociation', @applicationId);

INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
VALUES ('Ownership Based', 'OwnershipBased', @applicationId);

/* --------------------------------- */

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('SIS Vendor', @applicationId);

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('Ed-Fi Sandbox', @applicationId);

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('Roster Vendor', @applicationId);

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('Assessment Vendor', @applicationId);

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('Assessment Read', @applicationId);

INSERT INTO [dbo].[ClaimSets] ([ClaimSetName], [Application_ApplicationId])
VALUES ('Bootstrap Descriptors and EdOrgs', @applicationId);

/* --------------------------------- */

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'types', N'types', N'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', NULL, @applicationId);
SELECT @typesResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'systemDescriptors', N'systemDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', NULL, @applicationId);
SELECT @systemDescriptorsResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'managedDescriptors', N'managedDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', NULL, @applicationId);
SELECT @managedDescriptorsResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizations', N'educationOrganizations', N'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', NULL, @applicationId);
SELECT @educationOrganizationsResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'people', N'people', N'http://ed-fi.org/ods/identity/claims/domains/people', NULL, @applicationId);
SELECT @peopleResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'relationshipBasedData', N'relationshipBasedData', N'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', NULL, @applicationId);
SELECT @relationshipBasedDataResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentMetadata', N'assessmentMetadata', N'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', NULL, @applicationId);
SELECT @assessmentMetadataResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'identity', N'identity', N'http://ed-fi.org/ods/identity/claims/domains/identity', NULL, @applicationId);
SELECT @identityResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationStandards', N'educationStandards', N'http://ed-fi.org/ods/identity/claims/domains/educationStandards', NULL, @applicationId);
SELECT @educationStandardsResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryRelationships', N'primaryRelationships', N'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', NULL, @applicationId);
SELECT @primaryRelationshipsResourceClaimId = SCOPE_IDENTITY();

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyDomain', N'surveyDomain', N'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', NULL, @applicationId);
SELECT @surveyDomainResourceClaimId = SCOPE_IDENTITY();

/* --------------------------------- */

/* --------------------------------- */
/*        Resource Claims            */
/* --------------------------------- */

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'absenceEventCategoryDescriptor', N'absenceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicHonorCategoryDescriptor', N'academicHonorCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicSubjectDescriptor', N'academicSubjectDescriptor', N'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicWeek', N'academicWeek', N'http://ed-fi.org/ods/identity/claims/academicWeek', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accommodationDescriptor', N'accommodationDescriptor', N'http://ed-fi.org/ods/identity/claims/accommodationDescriptor', @managedDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'account', N'account', N'http://ed-fi.org/ods/identity/claims/account', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accountabilityRating', N'accountabilityRating', N'http://ed-fi.org/ods/identity/claims/accountabilityRating', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accountClassificationDescriptor', N'accountClassificationDescriptor', N'http://ed-fi.org/ods/identity/claims/accountClassificationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accountCode', N'accountCode', N'http://ed-fi.org/ods/identity/claims/accountCode', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'achievementCategoryDescriptor', N'achievementCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'actual', N'actual', N'http://ed-fi.org/ods/identity/claims/actual', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'additionalCreditTypeDescriptor', N'additionalCreditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'addressTypeDescriptor', N'addressTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'administrationEnvironmentDescriptor', N'administrationEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'administrativeFundingControlDescriptor', N'administrativeFundingControlDescriptor', N'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'ancestryEthnicOriginDescriptor', N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessment', N'assessment', N'http://ed-fi.org/ods/identity/claims/assessment', @assessmentMetadataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentCategoryDescriptor', N'assessmentCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentIdentificationSystemDescriptor', N'assessmentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItem', N'assessmentItem', N'http://ed-fi.org/ods/identity/claims/assessmentItem', @assessmentMetadataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItemCategoryDescriptor', N'assessmentItemCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItemResultDescriptor', N'assessmentItemResultDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentPeriodDescriptor', N'assessmentPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor', @managedDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentReportingMethodDescriptor', N'assessmentReportingMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor', @managedDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentScoreRangeLearningStandard', N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard', @assessmentMetadataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'attemptStatusDescriptor', N'attemptStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'attendanceEventCategoryDescriptor', N'attendanceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'barrierToInternetAccessInResidenceDescriptor', N'barrierToInternetAccessInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'behaviorDescriptor', N'behaviorDescriptor', N'http://ed-fi.org/ods/identity/claims/behaviorDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'bellSchedule', N'bellSchedule', N'http://ed-fi.org/ods/identity/claims/bellSchedule', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'budget', N'budget', N'http://ed-fi.org/ods/identity/claims/budget', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendar', N'calendar', N'http://ed-fi.org/ods/identity/claims/calendar', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarDate', N'calendarDate', N'http://ed-fi.org/ods/identity/claims/calendarDate', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarEventDescriptor', N'calendarEventDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarTypeDescriptor', N'calendarTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'careerPathwayDescriptor', N'careerPathwayDescriptor', N'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'charterApprovalAgencyTypeDescriptor', N'charterApprovalAgencyTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'charterStatusDescriptor', N'charterStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'citizenshipStatusDescriptor', N'citizenshipStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'classPeriod', N'classPeriod', N'http://ed-fi.org/ods/identity/claims/classPeriod', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'classroomPositionDescriptor', N'classroomPositionDescriptor', N'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohort', N'cohort', N'http://ed-fi.org/ods/identity/claims/cohort', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortScopeDescriptor', N'cohortScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortTypeDescriptor', N'cohortTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortYearTypeDescriptor', N'cohortYearTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityOrganization', N'communityOrganization', N'http://ed-fi.org/ods/identity/claims/communityOrganization', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityProvider', N'communityProvider', N'http://ed-fi.org/ods/identity/claims/communityProvider', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityProviderLicense', N'communityProviderLicense', N'http://ed-fi.org/ods/identity/claims/communityProviderLicense', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'competencyLevelDescriptor', N'competencyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'competencyObjective', N'competencyObjective', N'http://ed-fi.org/ods/identity/claims/competencyObjective', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'contactTypeDescriptor', N'contactTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'contentClassDescriptor', N'contentClassDescriptor', N'http://ed-fi.org/ods/identity/claims/contentClassDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'continuationOfServicesReasonDescriptor', N'continuationOfServicesReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'contractedStaff', N'contractedStaff', N'http://ed-fi.org/ods/identity/claims/contractedStaff', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'costRateDescriptor', N'costRateDescriptor', N'http://ed-fi.org/ods/identity/claims/costRateDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'countryDescriptor', N'countryDescriptor', N'http://ed-fi.org/ods/identity/claims/countryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'course', N'course', N'http://ed-fi.org/ods/identity/claims/course', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseAttemptResultDescriptor', N'courseAttemptResultDescriptor', N'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseDefinedByDescriptor', N'courseDefinedByDescriptor', N'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseGPAApplicabilityDescriptor', N'courseGPAApplicabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseIdentificationSystemDescriptor', N'courseIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseLevelCharacteristicDescriptor', N'courseLevelCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseOffering', N'courseOffering', N'http://ed-fi.org/ods/identity/claims/courseOffering', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseRepeatCodeDescriptor', N'courseRepeatCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseTranscript', N'courseTranscript', N'http://ed-fi.org/ods/identity/claims/courseTranscript', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credential', N'credential', N'http://ed-fi.org/ods/identity/claims/credential', @educationStandardsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credentialFieldDescriptor', N'credentialFieldDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credentialTypeDescriptor', N'credentialTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'creditCategoryDescriptor', N'creditCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'creditTypeDescriptor', N'creditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cteProgramServiceDescriptor', N'cteProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'curriculumUsedDescriptor', N'curriculumUsedDescriptor', N'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'deliveryMethodDescriptor', N'deliveryMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diagnosisDescriptor', N'diagnosisDescriptor', N'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diplomaLevelDescriptor', N'diplomaLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diplomaTypeDescriptor', N'diplomaTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDescriptor', N'disabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDesignationDescriptor', N'disabilityDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDeterminationSourceTypeDescriptor', N'disabilityDeterminationSourceTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineAction', N'disciplineAction', N'http://ed-fi.org/ods/identity/claims/disciplineAction', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineActionLengthDifferenceReasonDescriptor', N'disciplineActionLengthDifferenceReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineDescriptor', N'disciplineDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineIncident', N'disciplineIncident', N'http://ed-fi.org/ods/identity/claims/disciplineIncident', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineIncidentParticipationCodeDescriptor', N'disciplineIncidentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationalEnvironmentDescriptor', N'educationalEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationContent', N'educationContent', N'http://ed-fi.org/ods/identity/claims/educationContent', NULL, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationCategoryDescriptor', N'educationOrganizationCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationIdentificationSystemDescriptor', N'educationOrganizationIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationInterventionPrescriptionAssociation', N'educationOrganizationInterventionPrescriptionAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationNetwork', N'educationOrganizationNetwork', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationNetworkAssociation', N'educationOrganizationNetworkAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationPeerAssociation', N'educationOrganizationPeerAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationPlanDescriptor', N'educationPlanDescriptor', N'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationServiceCenter', N'educationServiceCenter', N'http://ed-fi.org/ods/identity/claims/educationServiceCenter', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'electronicMailTypeDescriptor', N'electronicMailTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'employmentStatusDescriptor', N'employmentStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'entryGradeLevelReasonDescriptor', N'entryGradeLevelReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'entryTypeDescriptor', N'entryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'eventCircumstanceDescriptor', N'eventCircumstanceDescriptor', N'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'exitWithdrawTypeDescriptor', N'exitWithdrawTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'feederSchoolAssociation', N'feederSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'grade', N'grade', N'http://ed-fi.org/ods/identity/claims/grade', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradebookEntry', N'gradebookEntry', N'http://ed-fi.org/ods/identity/claims/gradebookEntry', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradebookEntryTypeDescriptor', N'gradebookEntryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradeLevelDescriptor', N'gradeLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradePointAverageTypeDescriptor', N'gradePointAverageTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradeTypeDescriptor', N'gradeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradingPeriod', N'gradingPeriod', N'http://ed-fi.org/ods/identity/claims/gradingPeriod', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradingPeriodDescriptor', N'gradingPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'graduationPlan', N'graduationPlan', N'http://ed-fi.org/ods/identity/claims/graduationPlan', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'graduationPlanTypeDescriptor', N'graduationPlanTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gunFreeSchoolsActReportingStatusDescriptor', N'gunFreeSchoolsActReportingStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'homelessPrimaryNighttimeResidenceDescriptor', N'homelessPrimaryNighttimeResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'homelessProgramServiceDescriptor', N'homelessProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'identificationDocumentUseDescriptor', N'identificationDocumentUseDescriptor', N'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'incidentLocationDescriptor', N'incidentLocationDescriptor', N'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorDescriptor', N'indicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorGroupDescriptor', N'indicatorGroupDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorLevelDescriptor', N'indicatorLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'institutionTelephoneNumberTypeDescriptor', N'institutionTelephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interactivityStyleDescriptor', N'interactivityStyleDescriptor', N'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetAccessDescriptor', N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetAccessTypeInResidenceDescriptor', N'internetAccessTypeInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetPerformanceInResidenceDescriptor', N'internetPerformanceInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'intervention', N'intervention', N'http://ed-fi.org/ods/identity/claims/intervention', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionClassDescriptor', N'interventionClassDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionEffectivenessRatingDescriptor', N'interventionEffectivenessRatingDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionPrescription', N'interventionPrescription', N'http://ed-fi.org/ods/identity/claims/interventionPrescription', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionStudy', N'interventionStudy', N'http://ed-fi.org/ods/identity/claims/interventionStudy', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageDescriptor', N'languageDescriptor', N'http://ed-fi.org/ods/identity/claims/languageDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageInstructionProgramServiceDescriptor', N'languageInstructionProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageUseDescriptor', N'languageUseDescriptor', N'http://ed-fi.org/ods/identity/claims/languageUseDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningObjective', N'learningObjective', N'http://ed-fi.org/ods/identity/claims/learningObjective', @educationStandardsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandard', N'learningStandard', N'http://ed-fi.org/ods/identity/claims/learningStandard', @educationStandardsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardCategoryDescriptor', N'learningStandardCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceAssociation', N'learningStandardEquivalenceAssociation', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation', @educationStandardsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceStrengthDescriptor', N'learningStandardEquivalenceStrengthDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardScopeDescriptor', N'learningStandardScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'levelOfEducationDescriptor', N'levelOfEducationDescriptor', N'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'licenseStatusDescriptor', N'licenseStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'licenseTypeDescriptor', N'licenseTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'limitedEnglishProficiencyDescriptor', N'limitedEnglishProficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localeDescriptor', N'localeDescriptor', N'http://ed-fi.org/ods/identity/claims/localeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localEducationAgency', N'localEducationAgency', N'http://ed-fi.org/ods/identity/claims/localEducationAgency', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localEducationAgencyCategoryDescriptor', N'localEducationAgencyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'location', N'location', N'http://ed-fi.org/ods/identity/claims/location', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'magnetSpecialProgramEmphasisSchoolDescriptor', N'magnetSpecialProgramEmphasisSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'mediumOfInstructionDescriptor', N'mediumOfInstructionDescriptor', N'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'methodCreditEarnedDescriptor', N'methodCreditEarnedDescriptor', N'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'migrantEducationProgramServiceDescriptor', N'migrantEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'monitoredDescriptor', N'monitoredDescriptor', N'http://ed-fi.org/ods/identity/claims/monitoredDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'neglectedOrDelinquentProgramDescriptor', N'neglectedOrDelinquentProgramDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'neglectedOrDelinquentProgramServiceDescriptor', N'neglectedOrDelinquentProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'networkPurposeDescriptor', N'networkPurposeDescriptor', N'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'objectiveAssessment', N'objectiveAssessment', N'http://ed-fi.org/ods/identity/claims/objectiveAssessment', @assessmentMetadataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'oldEthnicityDescriptor', N'oldEthnicityDescriptor', N'http://ed-fi.org/ods/identity/claims/oldEthnicityDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'openStaffPosition', N'openStaffPosition', N'http://ed-fi.org/ods/identity/claims/openStaffPosition', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'operationalStatusDescriptor', N'operationalStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'organizationDepartment', N'organizationDepartment', N'http://ed-fi.org/ods/identity/claims/organizationDepartment', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'otherNameTypeDescriptor', N'otherNameTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'parent', N'parent', N'http://ed-fi.org/ods/identity/claims/parent', @peopleResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'participationDescriptor', N'participationDescriptor', N'http://ed-fi.org/ods/identity/claims/participationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'participationStatusDescriptor', N'participationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'payroll', N'payroll', N'http://ed-fi.org/ods/identity/claims/payroll', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'performanceBaseConversionDescriptor', N'performanceBaseConversionDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'performanceLevelDescriptor', N'performanceLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor', @managedDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'person', N'person', N'http://ed-fi.org/ods/identity/claims/person', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'personalInformationVerificationDescriptor', N'personalInformationVerificationDescriptor', N'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'platformTypeDescriptor', N'platformTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'populationServedDescriptor', N'populationServedDescriptor', N'http://ed-fi.org/ods/identity/claims/populationServedDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postingResultDescriptor', N'postingResultDescriptor', N'http://ed-fi.org/ods/identity/claims/postingResultDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryEvent', N'postSecondaryEvent', N'http://ed-fi.org/ods/identity/claims/postSecondaryEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryEventCategoryDescriptor', N'postSecondaryEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryInstitution', N'postSecondaryInstitution', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryInstitutionLevelDescriptor', N'postSecondaryInstitutionLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceAccessDescriptor', N'primaryLearningDeviceAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceAwayFromSchoolDescriptor', N'primaryLearningDeviceAwayFromSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceProviderDescriptor', N'primaryLearningDeviceProviderDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'proficiencyDescriptor', N'proficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'program', N'program', N'http://ed-fi.org/ods/identity/claims/program', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programAssignmentDescriptor', N'programAssignmentDescriptor', N'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programCharacteristicDescriptor', N'programCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programSponsorDescriptor', N'programSponsorDescriptor', N'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programTypeDescriptor', N'programTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/programTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'progressDescriptor', N'progressDescriptor', N'http://ed-fi.org/ods/identity/claims/progressDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'progressLevelDescriptor', N'progressLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerCategoryDescriptor', N'providerCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerProfitabilityDescriptor', N'providerProfitabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerStatusDescriptor', N'providerStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'publicationStatusDescriptor', N'publicationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'questionFormDescriptor', N'questionFormDescriptor', N'http://ed-fi.org/ods/identity/claims/questionFormDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'raceDescriptor', N'raceDescriptor', N'http://ed-fi.org/ods/identity/claims/raceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reasonExitedDescriptor', N'reasonExitedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reasonNotTestedDescriptor', N'reasonNotTestedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'recognitionTypeDescriptor', N'recognitionTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'relationDescriptor', N'relationDescriptor', N'http://ed-fi.org/ods/identity/claims/relationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'repeatIdentifierDescriptor', N'repeatIdentifierDescriptor', N'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reportCard', N'reportCard', N'http://ed-fi.org/ods/identity/claims/reportCard', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reporterDescriptionDescriptor', N'reporterDescriptionDescriptor', N'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'residencyStatusDescriptor', N'residencyStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'responseIndicatorDescriptor', N'responseIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'responsibilityDescriptor', N'responsibilityDescriptor', N'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'restraintEvent', N'restraintEvent', N'http://ed-fi.org/ods/identity/claims/restraintEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'restraintEventReasonDescriptor', N'restraintEventReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'resultDatatypeTypeDescriptor', N'resultDatatypeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'retestIndicatorDescriptor', N'retestIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'school', N'school', N'http://ed-fi.org/ods/identity/claims/school', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolCategoryDescriptor', N'schoolCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolChoiceImplementStatusDescriptor', N'schoolChoiceImplementStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolFoodServiceProgramServiceDescriptor', N'schoolFoodServiceProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolTypeDescriptor', N'schoolTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolYearType', N'schoolYearType', N'http://ed-fi.org/ods/identity/claims/schoolYearType', @typesResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'section', N'section', N'http://ed-fi.org/ods/identity/claims/section', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sectionAttendanceTakenEvent', N'sectionAttendanceTakenEvent', N'http://ed-fi.org/ods/identity/claims/sectionAttendanceTakenEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sectionCharacteristicDescriptor', N'sectionCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'separationDescriptor', N'separationDescriptor', N'http://ed-fi.org/ods/identity/claims/separationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'separationReasonDescriptor', N'separationReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'serviceDescriptor', N'serviceDescriptor', N'http://ed-fi.org/ods/identity/claims/serviceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'session', N'session', N'http://ed-fi.org/ods/identity/claims/session', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sexDescriptor', N'sexDescriptor', N'http://ed-fi.org/ods/identity/claims/sexDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sourceSystemDescriptor', N'sourceSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'specialEducationProgramServiceDescriptor', N'specialEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'specialEducationSettingDescriptor', N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staff', N'staff', N'http://ed-fi.org/ods/identity/claims/staff', @peopleResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffAbsenceEvent', N'staffAbsenceEvent', N'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffClassificationDescriptor', N'staffClassificationDescriptor', N'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffCohortAssociation', N'staffCohortAssociation', N'http://ed-fi.org/ods/identity/claims/staffCohortAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffDisciplineIncidentAssociation', N'staffDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationAssignmentAssociation', N'staffEducationOrganizationAssignmentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation', @primaryRelationshipsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationContactAssociation', N'staffEducationOrganizationContactAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationEmploymentAssociation', N'staffEducationOrganizationEmploymentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation', @primaryRelationshipsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffIdentificationSystemDescriptor', N'staffIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffLeave', N'staffLeave', N'http://ed-fi.org/ods/identity/claims/staffLeave', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffLeaveEventCategoryDescriptor', N'staffLeaveEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffProgramAssociation', N'staffProgramAssociation', N'http://ed-fi.org/ods/identity/claims/staffProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffSchoolAssociation', N'staffSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffSectionAssociation', N'staffSectionAssociation', N'http://ed-fi.org/ods/identity/claims/staffSectionAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'stateAbbreviationDescriptor', N'stateAbbreviationDescriptor', N'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'stateEducationAgency', N'stateEducationAgency', N'http://ed-fi.org/ods/identity/claims/stateEducationAgency', @educationOrganizationsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'student', N'student', N'http://ed-fi.org/ods/identity/claims/student', @peopleResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentAcademicRecord', N'studentAcademicRecord', N'http://ed-fi.org/ods/identity/claims/studentAcademicRecord', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentAssessment', N'studentAssessment', N'http://ed-fi.org/ods/identity/claims/studentAssessment', @assessmentMetadataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCharacteristicDescriptor', N'studentCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCohortAssociation', N'studentCohortAssociation', N'http://ed-fi.org/ods/identity/claims/studentCohortAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCompetencyObjective', N'studentCompetencyObjective', N'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCTEProgramAssociation', N'studentCTEProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentAssociation', N'studentDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentNonOffenderAssociation', N'studentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentEducationOrganizationAssociation', N'studentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentEducationOrganizationResponsibilityAssociation', N'studentEducationOrganizationResponsibilityAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentGradebookEntry', N'studentGradebookEntry', N'http://ed-fi.org/ods/identity/claims/studentGradebookEntry', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentHomelessProgramAssociation', N'studentHomelessProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentIdentificationSystemDescriptor', N'studentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentInterventionAssociation', N'studentInterventionAssociation', N'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentInterventionAttendanceEvent', N'studentInterventionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentInterventionAttendanceEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentLanguageInstructionProgramAssociation', N'studentLanguageInstructionProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentLearningObjective', N'studentLearningObjective', N'http://ed-fi.org/ods/identity/claims/studentLearningObjective', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentMigrantEducationProgramAssociation', N'studentMigrantEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentNeglectedOrDelinquentProgramAssociation', N'studentNeglectedOrDelinquentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentParentAssociation', N'studentParentAssociation', N'http://ed-fi.org/ods/identity/claims/studentParentAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentParticipationCodeDescriptor', N'studentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentProgramAssociation', N'studentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentProgramAttendanceEvent', N'studentProgramAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentProgramAttendanceEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolAssociation', N'studentSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation', @primaryRelationshipsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolAttendanceEvent', N'studentSchoolAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSchoolAttendanceEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolFoodServiceProgramAssociation', N'studentSchoolFoodServiceProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSectionAssociation', N'studentSectionAssociation', N'http://ed-fi.org/ods/identity/claims/studentSectionAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSectionAttendanceEvent', N'studentSectionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSectionAttendanceEvent', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSpecialEducationProgramAssociation', N'studentSpecialEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentTitleIPartAProgramAssociation', N'studentTitleIPartAProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'survey', N'survey', N'http://ed-fi.org/ods/identity/claims/survey', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyCategoryDescriptor', N'surveyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyCourseAssociation', N'surveyCourseAssociation', N'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyLevelDescriptor', N'surveyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyProgramAssociation', N'surveyProgramAssociation', N'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyQuestion', N'surveyQuestion', N'http://ed-fi.org/ods/identity/claims/surveyQuestion', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyQuestionResponse', N'surveyQuestionResponse', N'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponse', N'surveyResponse', N'http://ed-fi.org/ods/identity/claims/surveyResponse', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponseEducationOrganizationTargetAssociation', N'surveyResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponseStaffTargetAssociation', N'surveyResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySection', N'surveySection', N'http://ed-fi.org/ods/identity/claims/surveySection', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionAssociation', N'surveySectionAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponse', N'surveySectionResponse', N'http://ed-fi.org/ods/identity/claims/surveySectionResponse', @surveyDomainResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponseEducationOrganizationTargetAssociation', N'surveySectionResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponseStaffTargetAssociation', N'surveySectionResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'teachingCredentialBasisDescriptor', N'teachingCredentialBasisDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'teachingCredentialDescriptor', N'teachingCredentialDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'technicalSkillsAssessmentDescriptor', N'technicalSkillsAssessmentDescriptor', N'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'telephoneNumberTypeDescriptor', N'telephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'termDescriptor', N'termDescriptor', N'http://ed-fi.org/ods/identity/claims/termDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartAParticipantDescriptor', N'titleIPartAParticipantDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartAProgramServiceDescriptor', N'titleIPartAProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartASchoolDesignationDescriptor', N'titleIPartASchoolDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'tribalAffiliationDescriptor', N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'visaDescriptor', N'visaDescriptor', N'http://ed-fi.org/ods/identity/claims/visaDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'weaponDescriptor', N'weaponDescriptor', N'http://ed-fi.org/ods/identity/claims/weaponDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

/* --------------------------------- */

/* ---------------------------------------------------  */
/*     ClaimSetResourceClaimActions        */
/* ---------------------------------------------------- */

/* SIS Vendors Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'SIS Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
   (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read','Update','Delete')) AS ac
WHERE ResourceName IN ('people'
    , 'relationshipBasedData'
    , 'assessmentMetadata'
    , 'managedDescriptors'
    , 'primaryRelationships'
    , 'educationStandards'
    , 'educationContent')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('people'
    , 'relationshipBasedData'
    , 'assessmentMetadata'
    , 'managedDescriptors'
    , 'primaryRelationships'
    , 'educationStandards'
    , 'educationContent');

/* EdFi Sandbox Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox');

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'identity')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create', 'Update')) AS ac
WHERE ResourceName IN ('identity')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null  FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read','Update','Delete')) AS ac
WHERE ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null  FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain');

/* EdFi Sandbox Claims with Overrides */

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('communityProviderLicense');

/* Roster Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Roster Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
    'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
    'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation');

/* Assessment Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Vendor');

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
WHERE ResourceName IN ('assessmentMetadata')
UNION
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('learningObjective', 'learningStandard', 'student');

/* Assessment Read Resource Claims */
SET @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Read');
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student');

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs');

INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN (
    'systemDescriptors',
    'managedDescriptors',
    'educationOrganizations',
    -- from Interchange-Standards.xml
    'learningObjective',
    'learningStandard',
    'learningStandardEquivalenceAssociation',
    -- from Interchange-EducationOrganization.xml
    'accountabilityRating',
    'classPeriod',
    'communityProviderLicense',
    'course',
    'educationOrganizationPeerAssociation',
    'feederSchoolAssociation',
    'location',
    'program'
);

/* --------------------------------- */
/* ResourceClaimActions */
/* --------------------------------- */

/* NoFurtherAuthorizationRequired */

INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Update')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Delete')) AS ac
WHERE ResourceName IN ('educationOrganizations', 'people', 'credential', 'person');

/* NamespaceBased */

INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read')) AS ac
WHERE ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create', 'Update', 'Delete')) AS ac
WHERE ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain');

/* RelationshipsWithEdOrgsAndPeople */

INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Read', 'Update')) AS ac
WHERE ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Delete')) AS ac
WHERE ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships');

/* RelationshipsWithStudentsOnly */

INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('studentParentAssociation');

/* RelationshipsWithEdOrgsOnly */

INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ac.ActionId, ResourceClaimId, null
FROM [dbo].[ResourceClaims]
CROSS APPLY
    (SELECT ActionId
    FROM [dbo].[Actions]
    WHERE ActionName IN ('Create')) AS ac
WHERE ResourceName IN ('primaryRelationships')

/* --------------------------------- */

/* ------------------------------------------- */
/* ResourceClaimActionAuthorizationStrategies */
/* --------------------------------------------- */

/* NoFurtherAuthorizationRequired */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])


SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read')
    AND RC.ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person')

UNION

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')

UNION

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Update')
    AND RC.ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )

UNION

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Delete')
    AND RC.ResourceName IN ('educationOrganizations', 'people', 'credential', 'person');


/* NamespaceBased */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NamespaceBased');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read')
    AND RC.ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )

UNION

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create', 'Update', 'Delete')
    AND RC.ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain')


/* RelationshipsWithEdOrgsAndPeople */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])

SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read', 'Update')
    AND RC.ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('relationshipBasedData')
UNION
SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Delete')
    AND RC.ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships')



/* RelationshipsWithStudentsOnly */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('studentParentAssociation')

/* RelationshipsWithEdOrgsOnly */

SET @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly');

INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('primaryRelationships')


/* -------------------------------------------------------------- */
/*     ClaimSetResourceClaimActionAuthorizationStrategyOverrides  */
/* -------------------------------------------------------------- */

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT @AuthorizationStrategyId = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies] WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');
SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([ClaimSetResourceClaimActionId]
    ,[AuthorizationStrategyId])


SELECT CSRCAA.ClaimSetResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ClaimSetResourceClaimActions] CSRCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =CSRCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = CSRCAA.ActionId
    INNER JOIN [dbo].[ClaimSets] CS on CS.ClaimSetId = CSRCAA.ClaimSetId
    WHERE  CS.ClaimSetId =@ClaimSetId
    AND A.ActionName IN ('Create','Read','Update','Delete')
    AND RC.ResourceName IN ('communityProviderLicense')


SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs');

INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([ClaimSetResourceClaimActionId]
    ,[AuthorizationStrategyId])

SELECT CSRCAA.ClaimSetResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ClaimSetResourceClaimActions] CSRCAA
    INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =CSRCAA.ResourceClaimId
    INNER JOIN [dbo].[Actions] A on A.ActionId = CSRCAA.ActionId
    INNER JOIN [dbo].[ClaimSets] CS on CS.ClaimSetId = CSRCAA.ClaimSetId
    WHERE  CS.ClaimSetId =@ClaimSetId
    AND A.ActionName IN ('Create')
    AND RC.ResourceName IN (
    'systemDescriptors',
    'managedDescriptors',
    'educationOrganizations',
    -- from Interchange-Standards.xml
    'learningObjective',
    'learningStandard',
    'learningStandardEquivalenceAssociation',
    -- from Interchange-EducationOrganization.xml
    'accountabilityRating',
    'classPeriod',
    'communityOrganization',
    'communityProvider',
    'communityProviderLicense',
    'course',
    'educationOrganizationNetwork',
    'educationOrganizationNetworkAssociation',
    'educationOrganizationPeerAssociation',
    'educationServiceCenter',
    'feederSchoolAssociation',
    'localEducationAgency',
    'location',
    'postSecondaryInstitution',
    'program',
    'school',
    'stateEducationAgency'
)
