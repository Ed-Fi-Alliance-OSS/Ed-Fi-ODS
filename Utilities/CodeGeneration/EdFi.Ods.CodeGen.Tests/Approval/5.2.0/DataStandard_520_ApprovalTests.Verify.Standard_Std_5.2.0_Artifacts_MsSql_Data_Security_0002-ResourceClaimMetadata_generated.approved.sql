DECLARE @ClaimSetId INT;
DECLARE @AuthorizationStrategyId INT;

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
 WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/services/identity');

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

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'absenceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'academicHonorCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'academicSubjectDescriptor', N'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/academicWeek')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'academicWeek', N'http://ed-fi.org/ods/identity/claims/academicWeek',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/accommodationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'accommodationDescriptor', N'http://ed-fi.org/ods/identity/claims/accommodationDescriptor',
@managedDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/accountabilityRating')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'accountabilityRating', N'http://ed-fi.org/ods/identity/claims/accountabilityRating',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'accountTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'achievementCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'additionalCreditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'addressTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'administrationEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'administrativeFundingControlDescriptor', N'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessment')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessment', N'http://ed-fi.org/ods/identity/claims/assessment',
@assessmentMetadataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentItem')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentItem', N'http://ed-fi.org/ods/identity/claims/assessmentItem',
@assessmentMetadataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentItemCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentItemResultDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor',
@managedDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentReportingMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor',
@managedDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard',
@assessmentMetadataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'assignmentLateStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'attemptStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'attendanceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/balanceSheetDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'balanceSheetDimension', N'http://ed-fi.org/ods/identity/claims/balanceSheetDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'barrierToInternetAccessInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/behaviorDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'behaviorDescriptor', N'http://ed-fi.org/ods/identity/claims/behaviorDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/bellSchedule')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'bellSchedule', N'http://ed-fi.org/ods/identity/claims/bellSchedule',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/busRouteDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'busRouteDescriptor', N'http://ed-fi.org/ods/identity/claims/busRouteDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/calendar')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'calendar', N'http://ed-fi.org/ods/identity/claims/calendar',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/calendarDate')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'calendarDate', N'http://ed-fi.org/ods/identity/claims/calendarDate',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'calendarEventDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'calendarTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'careerPathwayDescriptor', N'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'charterApprovalAgencyTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'charterStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/chartOfAccount')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'chartOfAccount', N'http://ed-fi.org/ods/identity/claims/chartOfAccount',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'citizenshipStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/classPeriod')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'classPeriod', N'http://ed-fi.org/ods/identity/claims/classPeriod',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'classroomPositionDescriptor', N'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/cohort')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'cohort', N'http://ed-fi.org/ods/identity/claims/cohort',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'cohortScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'cohortTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'cohortYearTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/communityOrganization')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'communityOrganization', N'http://ed-fi.org/ods/identity/claims/communityOrganization',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/communityProvider')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'communityProvider', N'http://ed-fi.org/ods/identity/claims/communityProvider',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/communityProviderLicense')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'communityProviderLicense', N'http://ed-fi.org/ods/identity/claims/communityProviderLicense',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'competencyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/competencyObjective')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'competencyObjective', N'http://ed-fi.org/ods/identity/claims/competencyObjective',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/contact')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'contact', N'http://ed-fi.org/ods/identity/claims/contact',
@peopleResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'contactTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/contentClassDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'contentClassDescriptor', N'http://ed-fi.org/ods/identity/claims/contentClassDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'continuationOfServicesReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/costRateDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'costRateDescriptor', N'http://ed-fi.org/ods/identity/claims/costRateDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/countryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'countryDescriptor', N'http://ed-fi.org/ods/identity/claims/countryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/course')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'course', N'http://ed-fi.org/ods/identity/claims/course',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseAttemptResultDescriptor', N'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseDefinedByDescriptor', N'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseGPAApplicabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseLevelCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseOffering')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseOffering', N'http://ed-fi.org/ods/identity/claims/courseOffering',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseRepeatCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/courseTranscript')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'courseTranscript', N'http://ed-fi.org/ods/identity/claims/courseTranscript',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/credential')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'credential', N'http://ed-fi.org/ods/identity/claims/credential',
@educationStandardsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'credentialFieldDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'credentialTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'creditCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'creditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/crisisEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'crisisEvent', N'http://ed-fi.org/ods/identity/claims/crisisEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/crisisTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'crisisTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/crisisTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'cteProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'curriculumUsedDescriptor', N'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'deliveryMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/descriptorMapping')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'descriptorMapping', N'http://ed-fi.org/ods/identity/claims/descriptorMapping',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'diagnosisDescriptor', N'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'diplomaLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'diplomaTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disabilityDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disabilityDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disabilityDeterminationSourceTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disciplineAction')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disciplineAction', N'http://ed-fi.org/ods/identity/claims/disciplineAction',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disciplineActionLengthDifferenceReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disciplineDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disciplineDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disciplineIncident')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disciplineIncident', N'http://ed-fi.org/ods/identity/claims/disciplineIncident',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'disciplineIncidentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/displacedStudentStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'displacedStudentStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/displacedStudentStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationalEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationContent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationContent', N'http://ed-fi.org/ods/identity/claims/educationContent',
NULL);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationAssociationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationInterventionPrescriptionAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationNetwork', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationNetworkAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationOrganizationPeerAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationPlanDescriptor', N'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/educationServiceCenter')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'educationServiceCenter', N'http://ed-fi.org/ods/identity/claims/educationServiceCenter',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'electronicMailTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/eligibilityDelayReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'eligibilityDelayReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/eligibilityDelayReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/eligibilityEvaluationTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'eligibilityEvaluationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/eligibilityEvaluationTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'employmentStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/enrollmentTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'enrollmentTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/enrollmentTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'entryGradeLevelReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'entryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/evaluationDelayReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'evaluationDelayReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/evaluationDelayReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/evaluationRubricDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'evaluationRubricDimension', N'http://ed-fi.org/ods/identity/claims/evaluationRubricDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'eventCircumstanceDescriptor', N'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'exitWithdrawTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'feederSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'financialCollectionDescriptor', N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/functionDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'functionDimension', N'http://ed-fi.org/ods/identity/claims/functionDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/fundDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'fundDimension', N'http://ed-fi.org/ods/identity/claims/fundDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/grade')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'grade', N'http://ed-fi.org/ods/identity/claims/grade',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradebookEntry')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradebookEntry', N'http://ed-fi.org/ods/identity/claims/gradebookEntry',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradebookEntryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradeLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradePointAverageTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradingPeriod')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradingPeriod', N'http://ed-fi.org/ods/identity/claims/gradingPeriod',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gradingPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/graduationPlan')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'graduationPlan', N'http://ed-fi.org/ods/identity/claims/graduationPlan',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'graduationPlanTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'gunFreeSchoolsActReportingStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'homelessPrimaryNighttimeResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'homelessProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/ideaPartDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'ideaPartDescriptor', N'http://ed-fi.org/ods/identity/claims/ideaPartDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'identificationDocumentUseDescriptor', N'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/immunizationTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'immunizationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/immunizationTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'incidentLocationDescriptor', N'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/indicatorDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'indicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'indicatorGroupDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'indicatorLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'institutionTelephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'interactivityStyleDescriptor', N'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'internetAccessTypeInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'internetPerformanceInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/intervention')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'intervention', N'http://ed-fi.org/ods/identity/claims/intervention',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'interventionClassDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'interventionEffectivenessRatingDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/interventionPrescription')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'interventionPrescription', N'http://ed-fi.org/ods/identity/claims/interventionPrescription',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/interventionStudy')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'interventionStudy', N'http://ed-fi.org/ods/identity/claims/interventionStudy',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/languageDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'languageDescriptor', N'http://ed-fi.org/ods/identity/claims/languageDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'languageInstructionProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/languageUseDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'languageUseDescriptor', N'http://ed-fi.org/ods/identity/claims/languageUseDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/learningStandard')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'learningStandard', N'http://ed-fi.org/ods/identity/claims/learningStandard',
@educationStandardsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'learningStandardCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'learningStandardEquivalenceAssociation', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation',
@educationStandardsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'learningStandardEquivalenceStrengthDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'learningStandardScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'levelOfEducationDescriptor', N'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'licenseStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'licenseTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'limitedEnglishProficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localAccount')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localAccount', N'http://ed-fi.org/ods/identity/claims/localAccount',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localActual')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localActual', N'http://ed-fi.org/ods/identity/claims/localActual',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localBudget')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localBudget', N'http://ed-fi.org/ods/identity/claims/localBudget',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localContractedStaff')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localContractedStaff', N'http://ed-fi.org/ods/identity/claims/localContractedStaff',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localeDescriptor', N'http://ed-fi.org/ods/identity/claims/localeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localEducationAgency')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localEducationAgency', N'http://ed-fi.org/ods/identity/claims/localEducationAgency',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localEducationAgencyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localEncumbrance')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localEncumbrance', N'http://ed-fi.org/ods/identity/claims/localEncumbrance',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/localPayroll')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'localPayroll', N'http://ed-fi.org/ods/identity/claims/localPayroll',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/location')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'location', N'http://ed-fi.org/ods/identity/claims/location',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'magnetSpecialProgramEmphasisSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'mediumOfInstructionDescriptor', N'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'methodCreditEarnedDescriptor', N'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'migrantEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'modelEntityDescriptor', N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/monitoredDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'monitoredDescriptor', N'http://ed-fi.org/ods/identity/claims/monitoredDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'neglectedOrDelinquentProgramDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'neglectedOrDelinquentProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'networkPurposeDescriptor', N'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/nonMedicalImmunizationExemptionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'nonMedicalImmunizationExemptionDescriptor', N'http://ed-fi.org/ods/identity/claims/nonMedicalImmunizationExemptionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/objectDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'objectDimension', N'http://ed-fi.org/ods/identity/claims/objectDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/objectiveAssessment')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'objectiveAssessment', N'http://ed-fi.org/ods/identity/claims/objectiveAssessment',
@assessmentMetadataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/openStaffPosition')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'openStaffPosition', N'http://ed-fi.org/ods/identity/claims/openStaffPosition',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'operationalStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/operationalUnitDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'operationalUnitDimension', N'http://ed-fi.org/ods/identity/claims/operationalUnitDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/organizationDepartment')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'organizationDepartment', N'http://ed-fi.org/ods/identity/claims/organizationDepartment',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'otherNameTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/participationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'participationDescriptor', N'http://ed-fi.org/ods/identity/claims/participationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'participationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'performanceBaseConversionDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'performanceLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor',
@managedDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/person')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'person', N'http://ed-fi.org/ods/identity/claims/person',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'personalInformationVerificationDescriptor', N'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'platformTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/populationServedDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'populationServedDescriptor', N'http://ed-fi.org/ods/identity/claims/populationServedDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/postingResultDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'postingResultDescriptor', N'http://ed-fi.org/ods/identity/claims/postingResultDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/postSecondaryEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'postSecondaryEvent', N'http://ed-fi.org/ods/identity/claims/postSecondaryEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'postSecondaryEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'postSecondaryInstitution', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'postSecondaryInstitutionLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'primaryLearningDeviceAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'primaryLearningDeviceAwayFromSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'primaryLearningDeviceProviderDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'proficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/program')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'program', N'http://ed-fi.org/ods/identity/claims/program',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programAssignmentDescriptor', N'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programDimension', N'http://ed-fi.org/ods/identity/claims/programDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programEvaluation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programEvaluation', N'http://ed-fi.org/ods/identity/claims/programEvaluation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programEvaluationElement')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programEvaluationElement', N'http://ed-fi.org/ods/identity/claims/programEvaluationElement',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programEvaluationObjective')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programEvaluationObjective', N'http://ed-fi.org/ods/identity/claims/programEvaluationObjective',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programEvaluationPeriodDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programEvaluationPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/programEvaluationPeriodDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programEvaluationTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programEvaluationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/programEvaluationTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programSponsorDescriptor', N'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/programTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'programTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/programTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/progressDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'progressDescriptor', N'http://ed-fi.org/ods/identity/claims/progressDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'progressLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/projectDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'projectDimension', N'http://ed-fi.org/ods/identity/claims/projectDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'providerCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'providerProfitabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'providerStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'publicationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/questionFormDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'questionFormDescriptor', N'http://ed-fi.org/ods/identity/claims/questionFormDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/raceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'raceDescriptor', N'http://ed-fi.org/ods/identity/claims/raceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/ratingLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'ratingLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/ratingLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'reasonExitedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'reasonNotTestedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'recognitionTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/relationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'relationDescriptor', N'http://ed-fi.org/ods/identity/claims/relationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'repeatIdentifierDescriptor', N'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/reportCard')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'reportCard', N'http://ed-fi.org/ods/identity/claims/reportCard',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'reporterDescriptionDescriptor', N'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'reportingTagDescriptor', N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'residencyStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'responseIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'responsibilityDescriptor', N'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/restraintEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'restraintEvent', N'http://ed-fi.org/ods/identity/claims/restraintEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'restraintEventReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'resultDatatypeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'retestIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/school')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'school', N'http://ed-fi.org/ods/identity/claims/school',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolChoiceBasisDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolChoiceBasisDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolChoiceBasisDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolChoiceImplementStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolFoodServiceProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/schoolYearType')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'schoolYearType', N'http://ed-fi.org/ods/identity/claims/schoolYearType',
@typesResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/section')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'section', N'http://ed-fi.org/ods/identity/claims/section',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sectionAttendanceTakenEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sectionAttendanceTakenEvent', N'http://ed-fi.org/ods/identity/claims/sectionAttendanceTakenEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sectionCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sectionTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sectionTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/sectionTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/separationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'separationDescriptor', N'http://ed-fi.org/ods/identity/claims/separationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'separationReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/serviceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'serviceDescriptor', N'http://ed-fi.org/ods/identity/claims/serviceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/session')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'session', N'http://ed-fi.org/ods/identity/claims/session',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sexDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sexDescriptor', N'http://ed-fi.org/ods/identity/claims/sexDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sourceDimension')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sourceDimension', N'http://ed-fi.org/ods/identity/claims/sourceDimension',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'sourceSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/specialEducationExitReasonDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'specialEducationExitReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationExitReasonDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'specialEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staff')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staff', N'http://ed-fi.org/ods/identity/claims/staff',
@peopleResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffAbsenceEvent', N'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffClassificationDescriptor', N'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffCohortAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffCohortAssociation', N'http://ed-fi.org/ods/identity/claims/staffCohortAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffEducationOrganizationAssignmentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation',
@primaryRelationshipsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffEducationOrganizationContactAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffEducationOrganizationEmploymentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation',
@primaryRelationshipsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffLeave')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffLeave', N'http://ed-fi.org/ods/identity/claims/staffLeave',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffLeaveEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffProgramAssociation', N'http://ed-fi.org/ods/identity/claims/staffProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/staffSectionAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'staffSectionAssociation', N'http://ed-fi.org/ods/identity/claims/staffSectionAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'stateAbbreviationDescriptor', N'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/stateEducationAgency')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'stateEducationAgency', N'http://ed-fi.org/ods/identity/claims/stateEducationAgency',
@educationOrganizationsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/student')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'student', N'http://ed-fi.org/ods/identity/claims/student',
@peopleResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentAcademicRecord')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentAcademicRecord', N'http://ed-fi.org/ods/identity/claims/studentAcademicRecord',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentAssessment')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentAssessment', N'http://ed-fi.org/ods/identity/claims/studentAssessment',
@assessmentMetadataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentAssessmentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentCohortAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentCohortAssociation', N'http://ed-fi.org/ods/identity/claims/studentCohortAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentCompetencyObjective', N'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentContactAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentContactAssociation', N'http://ed-fi.org/ods/identity/claims/studentContactAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentCTEProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentEducationOrganizationResponsibilityAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentGradebookEntry')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentGradebookEntry', N'http://ed-fi.org/ods/identity/claims/studentGradebookEntry',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentHealth')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentHealth', N'http://ed-fi.org/ods/identity/claims/studentHealth',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentHomelessProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentInterventionAssociation', N'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentInterventionAttendanceEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentInterventionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentInterventionAttendanceEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentLanguageInstructionProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentMigrantEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentNeglectedOrDelinquentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentProgramAttendanceEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentProgramAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentProgramAttendanceEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentProgramEvaluation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentProgramEvaluation', N'http://ed-fi.org/ods/identity/claims/studentProgramEvaluation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation',
@primaryRelationshipsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSchoolAttendanceEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSchoolAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSchoolAttendanceEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSchoolFoodServiceProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSectionAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSectionAssociation', N'http://ed-fi.org/ods/identity/claims/studentSectionAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSectionAttendanceEvent')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSectionAttendanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSectionAttendanceEvent',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSpecialEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramEligibilityAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentSpecialEducationProgramEligibilityAssociation', N'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramEligibilityAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentTitleIPartAProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/studentTransportation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'studentTransportation', N'http://ed-fi.org/ods/identity/claims/studentTransportation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'submissionStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/supporterMilitaryConnectionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'supporterMilitaryConnectionDescriptor', N'http://ed-fi.org/ods/identity/claims/supporterMilitaryConnectionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/survey')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'survey', N'http://ed-fi.org/ods/identity/claims/survey',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyCourseAssociation', N'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyProgramAssociation', N'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyQuestion')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyQuestion', N'http://ed-fi.org/ods/identity/claims/surveyQuestion',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyQuestionResponse', N'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyResponse')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyResponse', N'http://ed-fi.org/ods/identity/claims/surveyResponse',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveyResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveySection')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveySection', N'http://ed-fi.org/ods/identity/claims/surveySection',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveySectionAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveySectionAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveySectionResponse')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveySectionResponse', N'http://ed-fi.org/ods/identity/claims/surveySectionResponse',
@surveyDomainResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveySectionResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'surveySectionResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation',
@relationshipBasedDataResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'teachingCredentialBasisDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'teachingCredentialDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'technicalSkillsAssessmentDescriptor', N'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'telephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/termDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'termDescriptor', N'http://ed-fi.org/ods/identity/claims/termDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'titleIPartAParticipantDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'titleIPartAProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'titleIPartASchoolDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/transportationPublicExpenseEligibilityTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'transportationPublicExpenseEligibilityTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/transportationPublicExpenseEligibilityTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/transportationTypeDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'transportationTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/transportationTypeDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/travelDayofWeekDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'travelDayofWeekDescriptor', N'http://ed-fi.org/ods/identity/claims/travelDayofWeekDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/travelDirectionDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'travelDirectionDescriptor', N'http://ed-fi.org/ods/identity/claims/travelDirectionDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/visaDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'visaDescriptor', N'http://ed-fi.org/ods/identity/claims/visaDescriptor',
@systemDescriptorsResourceClaimId);

END

IF NOT EXISTS(SELECT 1 FROM [dbo].[ResourceClaims] WHERE [ClaimName] = 'http://ed-fi.org/ods/identity/claims/weaponDescriptor')
BEGIN

    INSERT [dbo].[ResourceClaims] ([ResourceName], [ClaimName], [ParentResourceClaimId])
    VALUES (N'weaponDescriptor', N'http://ed-fi.org/ods/identity/claims/weaponDescriptor',
@systemDescriptorsResourceClaimId);

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
    WHERE ResourceName IN ('academicSubjectDescriptor', 'assessmentMetadata', 'learningObjective', 'managedDescriptors', 'learningStandard')
    UNION
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Read')) AS ac
    WHERE ResourceName IN ('student', 'systemDescriptors', 'types')
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

/* District Hosted SIS Vendor Claims */

SELECT @ClaimSetId = (SELECT ClaimSetId FROM [dbo].[ClaimSets] WHERE [ClaimSetName] = 'District Hosted SIS Vendor');

WITH DistrictHostedSisVendorClaims (ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride)
AS
(
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
       (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Read')) AS ac
    WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'localEducationAgency')
    UNION
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Update')) AS ac
    WHERE ResourceName IN ('localEducationAgency')
    UNION
    SELECT ac.ActionId, @ClaimSetId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Create','Read','Update','Delete')) AS ac
    WHERE ResourceName IN ('assessmentMetadata'
        , 'educationContent'
        , 'educationStandards'
        , 'managedDescriptors'
        , 'people'
        , 'primaryRelationships'
        , 'relationshipBasedData'
        , 'school'
        , 'organizationDepartment')
)
INSERT INTO [dbo].[ClaimSetResourceClaimActions]
    ([ActionId]
    ,[ClaimSetId]
    ,[ResourceClaimId]
    ,[ValidationRuleSetNameOverride])
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM DistrictHostedSisVendorClaims claims
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
    WHERE ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData', 'organizationDepartment')
    UNION
    SELECT ac.ActionId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Create')) AS ac
    WHERE ResourceName IN ('relationshipBasedData', 'organizationDepartment')
    UNION
    SELECT ac.ActionId, ResourceClaimId, null
    FROM [dbo].[ResourceClaims]
    CROSS APPLY
        (SELECT ActionId
        FROM [dbo].[Actions]
        WHERE ActionName IN ('Delete')) AS ac
    WHERE ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships', 'organizationDepartment')
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
        AND RC.ResourceName IN ('assessmentMetadata', 'educationContent', 'surveyDomain' )
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
        AND RC.ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData', 'organizationDepartment')
    UNION
    SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
        WHERE A.ActionName IN ('Create')
        AND RC.ResourceName IN ('relationshipBasedData', 'organizationDepartment')
    UNION
    SELECT RCAA.ResourceClaimActionId,@AuthorizationStrategyId FROM  [dbo].[ResourceClaimActions] RCAA
        INNER JOIN [dbo].[ResourceClaims] RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        INNER JOIN [dbo].[Actions] A on A.ActionId = RCAA.ActionId
        WHERE A.ActionName IN ('Delete')
        AND RC.ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships', 'organizationDepartment')
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
