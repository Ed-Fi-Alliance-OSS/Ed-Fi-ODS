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

SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications]
 WHERE [ApplicationName] = 'Ed-Fi ODS API');

SELECT @typesResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes');

SELECT @systemDescriptorsResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors');

SELECT @managedDescriptorsResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors');

SELECT @educationOrganizationsResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations');

SELECT @peopleResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/people');

SELECT @relationshipBasedDataResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData');

SELECT @assessmentMetadataResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata');

SELECT @identityResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/identity');

SELECT @educationStandardsResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/educationStandards');

SELECT @primaryRelationshipsResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships');

SELECT @surveyDomainResourceClaimId = (SELECT [ResourceClaimId] FROM [dbo].[ResourceClaims]
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain');

/* ==================================================================================================================================== */

/* --------------------------------- */
/*        Resource Claims            */
/* --------------------------------- */

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'absenceEventCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'absenceEventCategoryDescriptor', N'absenceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'academicHonorCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicHonorCategoryDescriptor', N'academicHonorCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'academicSubjectDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicSubjectDescriptor', N'academicSubjectDescriptor', N'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'academicWeek')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'academicWeek', N'academicWeek', N'http://ed-fi.org/ods/identity/claims/academicWeek',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'accommodationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accommodationDescriptor', N'accommodationDescriptor', N'http://ed-fi.org/ods/identity/claims/accommodationDescriptor',
@managedDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'accountabilityRating')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accountabilityRating', N'accountabilityRating', N'http://ed-fi.org/ods/identity/claims/accountabilityRating',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'accountTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'accountTypeDescriptor', N'accountTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'achievementCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'achievementCategoryDescriptor', N'achievementCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'additionalCreditTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'additionalCreditTypeDescriptor', N'additionalCreditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'addressTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'addressTypeDescriptor', N'addressTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'administrationEnvironmentDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'administrationEnvironmentDescriptor', N'administrationEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'administrativeFundingControlDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'administrativeFundingControlDescriptor', N'administrativeFundingControlDescriptor', N'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'ancestryEthnicOriginDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'ancestryEthnicOriginDescriptor', N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessment')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessment', N'assessment', N'http://ed-fi.org/ods/identity/claims/assessment',
@assessmentMetadataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentCategoryDescriptor', N'assessmentCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentIdentificationSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentIdentificationSystemDescriptor', N'assessmentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentItem')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItem', N'assessmentItem', N'http://ed-fi.org/ods/identity/claims/assessmentItem',
@assessmentMetadataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentItemCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItemCategoryDescriptor', N'assessmentItemCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentItemResultDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentItemResultDescriptor', N'assessmentItemResultDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentPeriodDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentPeriodDescriptor', N'assessmentPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor',
@managedDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentReportingMethodDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentReportingMethodDescriptor', N'assessmentReportingMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor',
@managedDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assessmentScoreRangeLearningStandard')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assessmentScoreRangeLearningStandard', N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard',
@assessmentMetadataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'assignmentLateStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'assignmentLateStatusDescriptor', N'assignmentLateStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'attemptStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'attemptStatusDescriptor', N'attemptStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'attendanceEventCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'attendanceEventCategoryDescriptor', N'attendanceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'balanceSheetDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'balanceSheetDimension', N'balanceSheetDimension', N'http://ed-fi.org/ods/identity/claims/balanceSheetDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'barrierToInternetAccessInResidenceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'barrierToInternetAccessInResidenceDescriptor', N'barrierToInternetAccessInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'behaviorDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'behaviorDescriptor', N'behaviorDescriptor', N'http://ed-fi.org/ods/identity/claims/behaviorDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'bellSchedule')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'bellSchedule', N'bellSchedule', N'http://ed-fi.org/ods/identity/claims/bellSchedule',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'calendar')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendar', N'calendar', N'http://ed-fi.org/ods/identity/claims/calendar',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'calendarDate')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarDate', N'calendarDate', N'http://ed-fi.org/ods/identity/claims/calendarDate',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'calendarEventDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarEventDescriptor', N'calendarEventDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'calendarTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'calendarTypeDescriptor', N'calendarTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'careerPathwayDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'careerPathwayDescriptor', N'careerPathwayDescriptor', N'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'charterApprovalAgencyTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'charterApprovalAgencyTypeDescriptor', N'charterApprovalAgencyTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'charterStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'charterStatusDescriptor', N'charterStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'chartOfAccount')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'chartOfAccount', N'chartOfAccount', N'http://ed-fi.org/ods/identity/claims/chartOfAccount',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'citizenshipStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'citizenshipStatusDescriptor', N'citizenshipStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'classPeriod')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'classPeriod', N'classPeriod', N'http://ed-fi.org/ods/identity/claims/classPeriod',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'classroomPositionDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'classroomPositionDescriptor', N'classroomPositionDescriptor', N'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cohort')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohort', N'cohort', N'http://ed-fi.org/ods/identity/claims/cohort',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cohortScopeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortScopeDescriptor', N'cohortScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cohortTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortTypeDescriptor', N'cohortTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cohortYearTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cohortYearTypeDescriptor', N'cohortYearTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'communityOrganization')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityOrganization', N'communityOrganization', N'http://ed-fi.org/ods/identity/claims/communityOrganization',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'communityProvider')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityProvider', N'communityProvider', N'http://ed-fi.org/ods/identity/claims/communityProvider',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'communityProviderLicense')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'communityProviderLicense', N'communityProviderLicense', N'http://ed-fi.org/ods/identity/claims/communityProviderLicense',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'competencyLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'competencyLevelDescriptor', N'competencyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'competencyObjective')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'competencyObjective', N'competencyObjective', N'http://ed-fi.org/ods/identity/claims/competencyObjective',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'contactTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'contactTypeDescriptor', N'contactTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'contentClassDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'contentClassDescriptor', N'contentClassDescriptor', N'http://ed-fi.org/ods/identity/claims/contentClassDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'continuationOfServicesReasonDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'continuationOfServicesReasonDescriptor', N'continuationOfServicesReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'costRateDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'costRateDescriptor', N'costRateDescriptor', N'http://ed-fi.org/ods/identity/claims/costRateDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'countryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'countryDescriptor', N'countryDescriptor', N'http://ed-fi.org/ods/identity/claims/countryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'course')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'course', N'course', N'http://ed-fi.org/ods/identity/claims/course',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseAttemptResultDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseAttemptResultDescriptor', N'courseAttemptResultDescriptor', N'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseDefinedByDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseDefinedByDescriptor', N'courseDefinedByDescriptor', N'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseGPAApplicabilityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseGPAApplicabilityDescriptor', N'courseGPAApplicabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseIdentificationSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseIdentificationSystemDescriptor', N'courseIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseLevelCharacteristicDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseLevelCharacteristicDescriptor', N'courseLevelCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseOffering')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseOffering', N'courseOffering', N'http://ed-fi.org/ods/identity/claims/courseOffering',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseRepeatCodeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseRepeatCodeDescriptor', N'courseRepeatCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'courseTranscript')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'courseTranscript', N'courseTranscript', N'http://ed-fi.org/ods/identity/claims/courseTranscript',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'credential')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credential', N'credential', N'http://ed-fi.org/ods/identity/claims/credential',
@educationStandardsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'credentialFieldDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credentialFieldDescriptor', N'credentialFieldDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'credentialTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'credentialTypeDescriptor', N'credentialTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'creditCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'creditCategoryDescriptor', N'creditCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'creditTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'creditTypeDescriptor', N'creditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'cteProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'cteProgramServiceDescriptor', N'cteProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'curriculumUsedDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'curriculumUsedDescriptor', N'curriculumUsedDescriptor', N'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'deliveryMethodDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'deliveryMethodDescriptor', N'deliveryMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'descriptorMapping')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'descriptorMapping', N'descriptorMapping', N'http://ed-fi.org/ods/identity/claims/descriptorMapping',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'diagnosisDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diagnosisDescriptor', N'diagnosisDescriptor', N'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'diplomaLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diplomaLevelDescriptor', N'diplomaLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'diplomaTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'diplomaTypeDescriptor', N'diplomaTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disabilityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDescriptor', N'disabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disabilityDesignationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDesignationDescriptor', N'disabilityDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disabilityDeterminationSourceTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disabilityDeterminationSourceTypeDescriptor', N'disabilityDeterminationSourceTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disciplineAction')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineAction', N'disciplineAction', N'http://ed-fi.org/ods/identity/claims/disciplineAction',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disciplineActionLengthDifferenceReasonDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineActionLengthDifferenceReasonDescriptor', N'disciplineActionLengthDifferenceReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disciplineDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineDescriptor', N'disciplineDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disciplineIncident')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineIncident', N'disciplineIncident', N'http://ed-fi.org/ods/identity/claims/disciplineIncident',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'disciplineIncidentParticipationCodeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'disciplineIncidentParticipationCodeDescriptor', N'disciplineIncidentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationalEnvironmentDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationalEnvironmentDescriptor', N'educationalEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationContent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationContent', N'educationContent', N'http://ed-fi.org/ods/identity/claims/educationContent',
NULL, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationAssociationTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationAssociationTypeDescriptor', N'educationOrganizationAssociationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationCategoryDescriptor', N'educationOrganizationCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationIdentificationSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationIdentificationSystemDescriptor', N'educationOrganizationIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationInterventionPrescriptionAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationInterventionPrescriptionAssociation', N'educationOrganizationInterventionPrescriptionAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationNetwork')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationNetwork', N'educationOrganizationNetwork', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationNetworkAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationNetworkAssociation', N'educationOrganizationNetworkAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationOrganizationPeerAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationOrganizationPeerAssociation', N'educationOrganizationPeerAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationPlanDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationPlanDescriptor', N'educationPlanDescriptor', N'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'educationServiceCenter')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'educationServiceCenter', N'educationServiceCenter', N'http://ed-fi.org/ods/identity/claims/educationServiceCenter',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'electronicMailTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'electronicMailTypeDescriptor', N'electronicMailTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'employmentStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'employmentStatusDescriptor', N'employmentStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'entryGradeLevelReasonDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'entryGradeLevelReasonDescriptor', N'entryGradeLevelReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'entryTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'entryTypeDescriptor', N'entryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'eventCircumstanceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'eventCircumstanceDescriptor', N'eventCircumstanceDescriptor', N'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'exitWithdrawTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'exitWithdrawTypeDescriptor', N'exitWithdrawTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'feederSchoolAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'feederSchoolAssociation', N'feederSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'financialCollectionDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'financialCollectionDescriptor', N'financialCollectionDescriptor', N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'functionDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'functionDimension', N'functionDimension', N'http://ed-fi.org/ods/identity/claims/functionDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'fundDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'fundDimension', N'fundDimension', N'http://ed-fi.org/ods/identity/claims/fundDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'grade')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'grade', N'grade', N'http://ed-fi.org/ods/identity/claims/grade',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradebookEntry')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradebookEntry', N'gradebookEntry', N'http://ed-fi.org/ods/identity/claims/gradebookEntry',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradebookEntryTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradebookEntryTypeDescriptor', N'gradebookEntryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradeLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradeLevelDescriptor', N'gradeLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradePointAverageTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradePointAverageTypeDescriptor', N'gradePointAverageTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradeTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradeTypeDescriptor', N'gradeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradingPeriod')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradingPeriod', N'gradingPeriod', N'http://ed-fi.org/ods/identity/claims/gradingPeriod',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gradingPeriodDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gradingPeriodDescriptor', N'gradingPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'graduationPlan')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'graduationPlan', N'graduationPlan', N'http://ed-fi.org/ods/identity/claims/graduationPlan',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'graduationPlanTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'graduationPlanTypeDescriptor', N'graduationPlanTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'gunFreeSchoolsActReportingStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'gunFreeSchoolsActReportingStatusDescriptor', N'gunFreeSchoolsActReportingStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'homelessPrimaryNighttimeResidenceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'homelessPrimaryNighttimeResidenceDescriptor', N'homelessPrimaryNighttimeResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'homelessProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'homelessProgramServiceDescriptor', N'homelessProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'identificationDocumentUseDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'identificationDocumentUseDescriptor', N'identificationDocumentUseDescriptor', N'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'incidentLocationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'incidentLocationDescriptor', N'incidentLocationDescriptor', N'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'indicatorDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorDescriptor', N'indicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'indicatorGroupDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorGroupDescriptor', N'indicatorGroupDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'indicatorLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'indicatorLevelDescriptor', N'indicatorLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'institutionTelephoneNumberTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'institutionTelephoneNumberTypeDescriptor', N'institutionTelephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'interactivityStyleDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interactivityStyleDescriptor', N'interactivityStyleDescriptor', N'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'internetAccessDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetAccessDescriptor', N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'internetAccessTypeInResidenceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetAccessTypeInResidenceDescriptor', N'internetAccessTypeInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'internetPerformanceInResidenceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'internetPerformanceInResidenceDescriptor', N'internetPerformanceInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'intervention')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'intervention', N'intervention', N'http://ed-fi.org/ods/identity/claims/intervention',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'interventionClassDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionClassDescriptor', N'interventionClassDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'interventionEffectivenessRatingDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionEffectivenessRatingDescriptor', N'interventionEffectivenessRatingDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'interventionPrescription')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionPrescription', N'interventionPrescription', N'http://ed-fi.org/ods/identity/claims/interventionPrescription',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'interventionStudy')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'interventionStudy', N'interventionStudy', N'http://ed-fi.org/ods/identity/claims/interventionStudy',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'languageDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageDescriptor', N'languageDescriptor', N'http://ed-fi.org/ods/identity/claims/languageDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'languageInstructionProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageInstructionProgramServiceDescriptor', N'languageInstructionProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'languageUseDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'languageUseDescriptor', N'languageUseDescriptor', N'http://ed-fi.org/ods/identity/claims/languageUseDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningObjective')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningObjective', N'learningObjective', N'http://ed-fi.org/ods/identity/claims/learningObjective',
@educationStandardsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandard')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandard', N'learningStandard', N'http://ed-fi.org/ods/identity/claims/learningStandard',
@educationStandardsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardCategoryDescriptor', N'learningStandardCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardEquivalenceAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceAssociation', N'learningStandardEquivalenceAssociation', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation',
@educationStandardsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardEquivalenceStrengthDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardEquivalenceStrengthDescriptor', N'learningStandardEquivalenceStrengthDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'learningStandardScopeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'learningStandardScopeDescriptor', N'learningStandardScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'levelOfEducationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'levelOfEducationDescriptor', N'levelOfEducationDescriptor', N'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'licenseStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'licenseStatusDescriptor', N'licenseStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'licenseTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'licenseTypeDescriptor', N'licenseTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'limitedEnglishProficiencyDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'limitedEnglishProficiencyDescriptor', N'limitedEnglishProficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localAccount')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localAccount', N'localAccount', N'http://ed-fi.org/ods/identity/claims/localAccount',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localActual')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localActual', N'localActual', N'http://ed-fi.org/ods/identity/claims/localActual',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localBudget')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localBudget', N'localBudget', N'http://ed-fi.org/ods/identity/claims/localBudget',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localContractedStaff')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localContractedStaff', N'localContractedStaff', N'http://ed-fi.org/ods/identity/claims/localContractedStaff',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localeDescriptor', N'localeDescriptor', N'http://ed-fi.org/ods/identity/claims/localeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localEducationAgency')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localEducationAgency', N'localEducationAgency', N'http://ed-fi.org/ods/identity/claims/localEducationAgency',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localEducationAgencyCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localEducationAgencyCategoryDescriptor', N'localEducationAgencyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localEncumbrance')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localEncumbrance', N'localEncumbrance', N'http://ed-fi.org/ods/identity/claims/localEncumbrance',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'localPayroll')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'localPayroll', N'localPayroll', N'http://ed-fi.org/ods/identity/claims/localPayroll',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'location')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'location', N'location', N'http://ed-fi.org/ods/identity/claims/location',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'magnetSpecialProgramEmphasisSchoolDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'magnetSpecialProgramEmphasisSchoolDescriptor', N'magnetSpecialProgramEmphasisSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'mediumOfInstructionDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'mediumOfInstructionDescriptor', N'mediumOfInstructionDescriptor', N'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'methodCreditEarnedDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'methodCreditEarnedDescriptor', N'methodCreditEarnedDescriptor', N'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'migrantEducationProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'migrantEducationProgramServiceDescriptor', N'migrantEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'modelEntityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'modelEntityDescriptor', N'modelEntityDescriptor', N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'monitoredDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'monitoredDescriptor', N'monitoredDescriptor', N'http://ed-fi.org/ods/identity/claims/monitoredDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'neglectedOrDelinquentProgramDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'neglectedOrDelinquentProgramDescriptor', N'neglectedOrDelinquentProgramDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'neglectedOrDelinquentProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'neglectedOrDelinquentProgramServiceDescriptor', N'neglectedOrDelinquentProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'networkPurposeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'networkPurposeDescriptor', N'networkPurposeDescriptor', N'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'objectDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'objectDimension', N'objectDimension', N'http://ed-fi.org/ods/identity/claims/objectDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'objectiveAssessment')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'objectiveAssessment', N'objectiveAssessment', N'http://ed-fi.org/ods/identity/claims/objectiveAssessment',
@assessmentMetadataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'oldEthnicityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'oldEthnicityDescriptor', N'oldEthnicityDescriptor', N'http://ed-fi.org/ods/identity/claims/oldEthnicityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'openStaffPosition')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'openStaffPosition', N'openStaffPosition', N'http://ed-fi.org/ods/identity/claims/openStaffPosition',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'operationalStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'operationalStatusDescriptor', N'operationalStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'operationalUnitDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'operationalUnitDimension', N'operationalUnitDimension', N'http://ed-fi.org/ods/identity/claims/operationalUnitDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'organizationDepartment')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'organizationDepartment', N'organizationDepartment', N'http://ed-fi.org/ods/identity/claims/organizationDepartment',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'otherNameTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'otherNameTypeDescriptor', N'otherNameTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'parent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'parent', N'parent', N'http://ed-fi.org/ods/identity/claims/parent',
@peopleResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'participationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'participationDescriptor', N'participationDescriptor', N'http://ed-fi.org/ods/identity/claims/participationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'participationStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'participationStatusDescriptor', N'participationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'performanceBaseConversionDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'performanceBaseConversionDescriptor', N'performanceBaseConversionDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'performanceLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'performanceLevelDescriptor', N'performanceLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor',
@managedDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'person')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'person', N'person', N'http://ed-fi.org/ods/identity/claims/person',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'personalInformationVerificationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'personalInformationVerificationDescriptor', N'personalInformationVerificationDescriptor', N'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'platformTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'platformTypeDescriptor', N'platformTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'populationServedDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'populationServedDescriptor', N'populationServedDescriptor', N'http://ed-fi.org/ods/identity/claims/populationServedDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'postingResultDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postingResultDescriptor', N'postingResultDescriptor', N'http://ed-fi.org/ods/identity/claims/postingResultDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'postSecondaryEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryEvent', N'postSecondaryEvent', N'http://ed-fi.org/ods/identity/claims/postSecondaryEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'postSecondaryEventCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryEventCategoryDescriptor', N'postSecondaryEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'postSecondaryInstitution')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryInstitution', N'postSecondaryInstitution', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'postSecondaryInstitutionLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'postSecondaryInstitutionLevelDescriptor', N'postSecondaryInstitutionLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'primaryLearningDeviceAccessDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceAccessDescriptor', N'primaryLearningDeviceAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'primaryLearningDeviceAwayFromSchoolDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceAwayFromSchoolDescriptor', N'primaryLearningDeviceAwayFromSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'primaryLearningDeviceProviderDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'primaryLearningDeviceProviderDescriptor', N'primaryLearningDeviceProviderDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'proficiencyDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'proficiencyDescriptor', N'proficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'program')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'program', N'program', N'http://ed-fi.org/ods/identity/claims/program',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'programAssignmentDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programAssignmentDescriptor', N'programAssignmentDescriptor', N'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'programCharacteristicDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programCharacteristicDescriptor', N'programCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'programDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programDimension', N'programDimension', N'http://ed-fi.org/ods/identity/claims/programDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'programSponsorDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programSponsorDescriptor', N'programSponsorDescriptor', N'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'programTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'programTypeDescriptor', N'programTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/programTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'progressDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'progressDescriptor', N'progressDescriptor', N'http://ed-fi.org/ods/identity/claims/progressDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'progressLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'progressLevelDescriptor', N'progressLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'projectDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'projectDimension', N'projectDimension', N'http://ed-fi.org/ods/identity/claims/projectDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'providerCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerCategoryDescriptor', N'providerCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'providerProfitabilityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerProfitabilityDescriptor', N'providerProfitabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'providerStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'providerStatusDescriptor', N'providerStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'publicationStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'publicationStatusDescriptor', N'publicationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'questionFormDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'questionFormDescriptor', N'questionFormDescriptor', N'http://ed-fi.org/ods/identity/claims/questionFormDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'raceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'raceDescriptor', N'raceDescriptor', N'http://ed-fi.org/ods/identity/claims/raceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'reasonExitedDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reasonExitedDescriptor', N'reasonExitedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'reasonNotTestedDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reasonNotTestedDescriptor', N'reasonNotTestedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'recognitionTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'recognitionTypeDescriptor', N'recognitionTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'relationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'relationDescriptor', N'relationDescriptor', N'http://ed-fi.org/ods/identity/claims/relationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'repeatIdentifierDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'repeatIdentifierDescriptor', N'repeatIdentifierDescriptor', N'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'reportCard')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reportCard', N'reportCard', N'http://ed-fi.org/ods/identity/claims/reportCard',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'reporterDescriptionDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reporterDescriptionDescriptor', N'reporterDescriptionDescriptor', N'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'reportingTagDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'reportingTagDescriptor', N'reportingTagDescriptor', N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'residencyStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'residencyStatusDescriptor', N'residencyStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'responseIndicatorDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'responseIndicatorDescriptor', N'responseIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'responsibilityDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'responsibilityDescriptor', N'responsibilityDescriptor', N'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'restraintEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'restraintEvent', N'restraintEvent', N'http://ed-fi.org/ods/identity/claims/restraintEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'restraintEventReasonDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'restraintEventReasonDescriptor', N'restraintEventReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'resultDatatypeTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'resultDatatypeTypeDescriptor', N'resultDatatypeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'retestIndicatorDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'retestIndicatorDescriptor', N'retestIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'school')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'school', N'school', N'http://ed-fi.org/ods/identity/claims/school',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'schoolCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolCategoryDescriptor', N'schoolCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'schoolChoiceImplementStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolChoiceImplementStatusDescriptor', N'schoolChoiceImplementStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'schoolFoodServiceProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolFoodServiceProgramServiceDescriptor', N'schoolFoodServiceProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'schoolTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolTypeDescriptor', N'schoolTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'schoolYearType')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'schoolYearType', N'schoolYearType', N'http://ed-fi.org/ods/identity/claims/schoolYearType',
@typesResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'section')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'section', N'section', N'http://ed-fi.org/ods/identity/claims/section',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'sectionAttendanceTakenEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sectionAttendanceTakenEvent', N'sectionAttendanceTakenEvent', N'http://ed-fi.org/ods/identity/claims/sectionAttendanceTakenEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'sectionCharacteristicDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sectionCharacteristicDescriptor', N'sectionCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'separationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'separationDescriptor', N'separationDescriptor', N'http://ed-fi.org/ods/identity/claims/separationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'separationReasonDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'separationReasonDescriptor', N'separationReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'serviceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'serviceDescriptor', N'serviceDescriptor', N'http://ed-fi.org/ods/identity/claims/serviceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'session')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'session', N'session', N'http://ed-fi.org/ods/identity/claims/session',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'sexDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sexDescriptor', N'sexDescriptor', N'http://ed-fi.org/ods/identity/claims/sexDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'sourceDimension')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sourceDimension', N'sourceDimension', N'http://ed-fi.org/ods/identity/claims/sourceDimension',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'sourceSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'sourceSystemDescriptor', N'sourceSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'specialEducationProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'specialEducationProgramServiceDescriptor', N'specialEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'specialEducationSettingDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'specialEducationSettingDescriptor', N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staff')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staff', N'staff', N'http://ed-fi.org/ods/identity/claims/staff',
@peopleResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffAbsenceEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffAbsenceEvent', N'staffAbsenceEvent', N'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffClassificationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffClassificationDescriptor', N'staffClassificationDescriptor', N'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffCohortAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffCohortAssociation', N'staffCohortAssociation', N'http://ed-fi.org/ods/identity/claims/staffCohortAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffDisciplineIncidentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffDisciplineIncidentAssociation', N'staffDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffEducationOrganizationAssignmentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationAssignmentAssociation', N'staffEducationOrganizationAssignmentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation',
@primaryRelationshipsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffEducationOrganizationContactAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationContactAssociation', N'staffEducationOrganizationContactAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffEducationOrganizationEmploymentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffEducationOrganizationEmploymentAssociation', N'staffEducationOrganizationEmploymentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation',
@primaryRelationshipsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffIdentificationSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffIdentificationSystemDescriptor', N'staffIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffLeave')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffLeave', N'staffLeave', N'http://ed-fi.org/ods/identity/claims/staffLeave',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffLeaveEventCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffLeaveEventCategoryDescriptor', N'staffLeaveEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffProgramAssociation', N'staffProgramAssociation', N'http://ed-fi.org/ods/identity/claims/staffProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffSchoolAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffSchoolAssociation', N'staffSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'staffSectionAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'staffSectionAssociation', N'staffSectionAssociation', N'http://ed-fi.org/ods/identity/claims/staffSectionAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'stateAbbreviationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'stateAbbreviationDescriptor', N'stateAbbreviationDescriptor', N'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'stateEducationAgency')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'stateEducationAgency', N'stateEducationAgency', N'http://ed-fi.org/ods/identity/claims/stateEducationAgency',
@educationOrganizationsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'student')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'student', N'student', N'http://ed-fi.org/ods/identity/claims/student',
@peopleResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentAcademicRecord')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentAcademicRecord', N'studentAcademicRecord', N'http://ed-fi.org/ods/identity/claims/studentAcademicRecord',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentAssessment')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentAssessment', N'studentAssessment', N'http://ed-fi.org/ods/identity/claims/studentAssessment',
@assessmentMetadataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentAssessmentEducationOrganizationAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentAssessmentEducationOrganizationAssociation', N'studentAssessmentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentCharacteristicDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCharacteristicDescriptor', N'studentCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentCohortAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCohortAssociation', N'studentCohortAssociation', N'http://ed-fi.org/ods/identity/claims/studentCohortAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentCompetencyObjective')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCompetencyObjective', N'studentCompetencyObjective', N'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentCTEProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentCTEProgramAssociation', N'studentCTEProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentDisciplineIncidentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentAssociation', N'studentDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentDisciplineIncidentBehaviorAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentDisciplineIncidentNonOffenderAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentDisciplineIncidentNonOffenderAssociation', N'studentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentEducationOrganizationAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentEducationOrganizationAssociation', N'studentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentEducationOrganizationResponsibilityAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentEducationOrganizationResponsibilityAssociation', N'studentEducationOrganizationResponsibilityAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentGradebookEntry')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentGradebookEntry', N'studentGradebookEntry', N'http://ed-fi.org/ods/identity/claims/studentGradebookEntry',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentHomelessProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentHomelessProgramAssociation', N'studentHomelessProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentIdentificationSystemDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentIdentificationSystemDescriptor', N'studentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentInterventionAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentInterventionAssociation', N'studentInterventionAssociation', N'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentInterventionAttendanceEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentInterventionAttendanceEvent', N'studentInterventionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentInterventionAttendanceEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentLanguageInstructionProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentLanguageInstructionProgramAssociation', N'studentLanguageInstructionProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentLearningObjective')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentLearningObjective', N'studentLearningObjective', N'http://ed-fi.org/ods/identity/claims/studentLearningObjective',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentMigrantEducationProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentMigrantEducationProgramAssociation', N'studentMigrantEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentNeglectedOrDelinquentProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentNeglectedOrDelinquentProgramAssociation', N'studentNeglectedOrDelinquentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentParentAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentParentAssociation', N'studentParentAssociation', N'http://ed-fi.org/ods/identity/claims/studentParentAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentParticipationCodeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentParticipationCodeDescriptor', N'studentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentProgramAssociation', N'studentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentProgramAttendanceEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentProgramAttendanceEvent', N'studentProgramAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentProgramAttendanceEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSchoolAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolAssociation', N'studentSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation',
@primaryRelationshipsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSchoolAttendanceEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolAttendanceEvent', N'studentSchoolAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSchoolAttendanceEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSchoolFoodServiceProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSchoolFoodServiceProgramAssociation', N'studentSchoolFoodServiceProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSectionAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSectionAssociation', N'studentSectionAssociation', N'http://ed-fi.org/ods/identity/claims/studentSectionAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSectionAttendanceEvent')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSectionAttendanceEvent', N'studentSectionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSectionAttendanceEvent',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentSpecialEducationProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentSpecialEducationProgramAssociation', N'studentSpecialEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'studentTitleIPartAProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'studentTitleIPartAProgramAssociation', N'studentTitleIPartAProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'submissionStatusDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'submissionStatusDescriptor', N'submissionStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'survey')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'survey', N'survey', N'http://ed-fi.org/ods/identity/claims/survey',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyCategoryDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyCategoryDescriptor', N'surveyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyCourseAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyCourseAssociation', N'surveyCourseAssociation', N'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyLevelDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyLevelDescriptor', N'surveyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyProgramAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyProgramAssociation', N'surveyProgramAssociation', N'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyQuestion')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyQuestion', N'surveyQuestion', N'http://ed-fi.org/ods/identity/claims/surveyQuestion',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyQuestionResponse')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyQuestionResponse', N'surveyQuestionResponse', N'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyResponse')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponse', N'surveyResponse', N'http://ed-fi.org/ods/identity/claims/surveyResponse',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyResponseEducationOrganizationTargetAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponseEducationOrganizationTargetAssociation', N'surveyResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveyResponseStaffTargetAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveyResponseStaffTargetAssociation', N'surveyResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveySection')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySection', N'surveySection', N'http://ed-fi.org/ods/identity/claims/surveySection',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveySectionAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionAssociation', N'surveySectionAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveySectionResponse')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponse', N'surveySectionResponse', N'http://ed-fi.org/ods/identity/claims/surveySectionResponse',
@surveyDomainResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveySectionResponseEducationOrganizationTargetAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponseEducationOrganizationTargetAssociation', N'surveySectionResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'surveySectionResponseStaffTargetAssociation')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'surveySectionResponseStaffTargetAssociation', N'surveySectionResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation',
@relationshipBasedDataResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'teachingCredentialBasisDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'teachingCredentialBasisDescriptor', N'teachingCredentialBasisDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'teachingCredentialDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'teachingCredentialDescriptor', N'teachingCredentialDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'technicalSkillsAssessmentDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'technicalSkillsAssessmentDescriptor', N'technicalSkillsAssessmentDescriptor', N'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'telephoneNumberTypeDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'telephoneNumberTypeDescriptor', N'telephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'termDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'termDescriptor', N'termDescriptor', N'http://ed-fi.org/ods/identity/claims/termDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'titleIPartAParticipantDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartAParticipantDescriptor', N'titleIPartAParticipantDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'titleIPartAProgramServiceDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartAProgramServiceDescriptor', N'titleIPartAProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'titleIPartASchoolDesignationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'titleIPartASchoolDesignationDescriptor', N'titleIPartASchoolDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'tribalAffiliationDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'tribalAffiliationDescriptor', N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'visaDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'visaDescriptor', N'visaDescriptor', N'http://ed-fi.org/ods/identity/claims/visaDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ResourceName] = 'weaponDescriptor')
BEGIN

INSERT [dbo].[ResourceClaims] ([DisplayName], [ResourceName], [ClaimName], [ParentResourceClaimId], [Application_ApplicationId])
VALUES (N'weaponDescriptor', N'weaponDescriptor', N'http://ed-fi.org/ods/identity/claims/weaponDescriptor',
@systemDescriptorsResourceClaimId, @applicationId);

END

/* ==================================================================================================================================== */

/* ---------------------------------------------------  */
/*     ClaimSetResourceClaimActions        */
/* ---------------------------------------------------- */

/* SIS Vendors Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'SIS Vendor');

WITH SisVendorClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
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
        , 'educationContent')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM SisVendorClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* EdFi Sandbox Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Ed-Fi Sandbox');

WITH EdFiSandboxClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
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
        'educationContent', 'surveyDomain')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM EdFiSandboxClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* EdFi Sandbox Claims with Overrides */

WITH EdFiSandboxClaimsWithOverrides (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
    WHERE ResourceName IN ('communityProviderLicense')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM EdFiSandboxClaimsWithOverrides claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* Roster Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Roster Vendor');

WITH RosterVendorClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Read')) AS ac
    WHERE ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
        'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
        'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM RosterVendorClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* Assessment Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Vendor');

WITH AssessmentVendorClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
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
    WHERE ResourceName IN ('learningObjective', 'learningStandard', 'student')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM AssessmentVendorClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* Assessment Read Resource Claims */

SET @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Assessment Read');

WITH AssessmentReadResourceClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Read')) AS ac
    WHERE ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM AssessmentReadResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs');

WITH BootstrapDescriptorsAndEdOrgsClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
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
        'stateEducationAgency')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM BootstrapDescriptorsAndEdOrgsClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActions] WHERE ActionId = claims.ActionId AND ClaimSetId = claims.ClaimSetId
                    AND ResourceClaimId = claims.ResourceClaimId);

/* ==================================================================================================================================== */

/* --------------------------------- */
/* ResourceClaimActions */
/* --------------------------------- */

/* NoFurtherAuthorizationRequired */

WITH NoFurtherAuthorizationRequiredResourceClaims (ActionId, ResourceClaimId, ValidationRuleSetName)
AS
(
    SELECT ac.ActionId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Read')) AS ac
    WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors',
            'identity', 'credential', 'person' )
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
    WHERE ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
)
INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM NoFurtherAuthorizationRequiredResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActions] WHERE ActionId = claims.ActionId AND ResourceClaimId = claims.ResourceClaimId);

/* NamespaceBased */

WITH NamespaceBasedResourceClaims (ActionId, ResourceClaimId, ValidationRuleSetName)
AS
(
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
    WHERE ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata',
        'educationStandards', 'educationContent', 'surveyDomain')
)
INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM NamespaceBasedResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActions] WHERE ActionId = claims.ActionId AND ResourceClaimId = claims.ResourceClaimId);

/* RelationshipsWithEdOrgsAndPeople */

WITH RelationshipsWithEdOrgsAndPeopleResourceClaims (ActionId, ResourceClaimId, ValidationRuleSetName)
AS
(
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
    WHERE ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships')
)
INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM RelationshipsWithEdOrgsAndPeopleResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActions] WHERE ActionId = claims.ActionId AND ResourceClaimId = claims.ResourceClaimId);

/* RelationshipsWithStudentsOnly */

WITH RelationshipsWithStudentsOnlyResourceClaims (ActionId, ResourceClaimId, ValidationRuleSetName)
AS
(
    SELECT ac.ActionId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Create')) AS ac
    WHERE ResourceName IN ('studentParentAssociation')
)
INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM RelationshipsWithStudentsOnlyResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActions] WHERE ActionId = claims.ActionId AND ResourceClaimId = claims.ResourceClaimId);

/* RelationshipsWithEdOrgsOnly */

WITH RelationshipsWithEdOrgsOnlyResourceClaims (ActionId, ResourceClaimId, ValidationRuleSetName)
AS
(
    SELECT ac.ActionId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Create')) AS ac
    WHERE ResourceName IN ('primaryRelationships')
)
INSERT INTO [dbo].[ResourceClaimActions]
    ([ActionId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetName])
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM RelationshipsWithEdOrgsOnlyResourceClaims claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActions] WHERE ActionId = claims.ActionId AND ResourceClaimId = claims.ResourceClaimId);

/* ==================================================================================================================================== */

/* ------------------------------------------- */
/* ResourceClaimActionAuthorizationStrategies */
/* --------------------------------------------- */

/* NoFurtherAuthorizationRequired */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');

WITH NoFurtherAuthorizationRequiredAuthorizationStrategies (ResourceClaimActionId, AuthorizationStrategyId)
AS
(
    SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
        WHERE A.ActionName IN ('Read')
        AND RC.ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors',
            'identity', 'credential', 'person')
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
        AND RC.ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
)
INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM NoFurtherAuthorizationRequiredAuthorizationStrategies claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActionAuthorizationStrategies] WHERE ResourceClaimActionId = claims.ResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* NamespaceBased */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'NamespaceBased');

WITH NamespaceBasedAuthorizationStrategies (ResourceClaimActionId, AuthorizationStrategyId)
AS
(
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
        AND RC.ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata',
            'educationStandards', 'educationContent', 'surveyDomain')
)
INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM NamespaceBasedAuthorizationStrategies claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActionAuthorizationStrategies] WHERE ResourceClaimActionId = claims.ResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithEdOrgsAndPeople */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople');

WITH RelationshipsWithEdOrgsAndPeopleAuthorizationStrategies (ResourceClaimActionId, AuthorizationStrategyId)
AS
(
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
)
INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM RelationshipsWithEdOrgsAndPeopleAuthorizationStrategies claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActionAuthorizationStrategies] WHERE ResourceClaimActionId = claims.ResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithStudentsOnly */

SELECT @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly');

WITH RelationshipsWithStudentsOnlyAuthorizationStrategies (ResourceClaimActionId, AuthorizationStrategyId)
AS
(
    SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
        WHERE A.ActionName IN ('Create')
        AND RC.ResourceName IN ('studentParentAssociation')
)
INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM RelationshipsWithStudentsOnlyAuthorizationStrategies claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActionAuthorizationStrategies] WHERE ResourceClaimActionId = claims.ResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithEdOrgsOnly */

SET @AuthorizationStrategyId  = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly');

WITH RelationshipsWithEdOrgsOnlyAuthorizationStrategies (ResourceClaimActionId, AuthorizationStrategyId)
AS
(
    SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
        WHERE A.ActionName IN ('Create')
        AND RC.ResourceName IN ('primaryRelationships')
)
INSERT INTO [dbo].[ResourceClaimActionAuthorizationStrategies]
    ([ResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM RelationshipsWithEdOrgsOnlyAuthorizationStrategies claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ResourceClaimActionAuthorizationStrategies] WHERE ResourceClaimActionId = claims.ResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* ==================================================================================================================================== */

/* -------------------------------------------------------------- */
/*     ClaimSetResourceClaimActionAuthorizationStrategyOverrides  */
/* -------------------------------------------------------------- */

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT @AuthorizationStrategyId = (SELECT AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
    WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired');
SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'Bootstrap Descriptors and EdOrgs');

WITH ActionAuthorizationStrategyOverrides (ClaimSetResourceClaimActionId, AuthorizationStrategyId)
AS
(
    SELECT CSRCAA.ClaimSetResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ClaimSetResourceClaimActions] CSRCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =CSRCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = CSRCAA.ActionId
        INNER JOIN [dbo].[ClaimSets] CS on CS.ClaimSetId = CSRCAA.ClaimSetId
        WHERE CS.ClaimSetId = @ClaimSetId
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
            'stateEducationAgency')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides]
    ([ClaimSetResourceClaimActionId]
    ,[AuthorizationStrategyId])
SELECT ClaimSetResourceClaimActionId, AuthorizationStrategyId
FROM ActionAuthorizationStrategyOverrides claims
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ClaimSetResourceClaimActionAuthorizationStrategyOverrides] WHERE ClaimSetResourceClaimActionId = claims.ClaimSetResourceClaimActionId
                    AND AuthorizationStrategyId = claims.AuthorizationStrategyId);
