begin transaction;

do $$
DECLARE claimSet_Id INT;
DECLARE authorizationStrategy_Id INT;
DECLARE application_Id INT;

DECLARE peopleResourceClaimId INT;
DECLARE relationshipBasedDataResourceClaimId INT;
DECLARE assessmentMetadataResourceClaimId INT;
DECLARE educationStandardsResourceClaimId INT;
DECLARE primaryRelationshipsResourceClaimId INT;
DECLARE educationOrganizationsResourceClaimId INT;
DECLARE typesResourceClaimId INT;
DECLARE systemDescriptorsResourceClaimId INT;
DECLARE managedDescriptorsResourceClaimId INT;
DECLARE identityResourceClaimId INT;
DECLARE surveyDomainResourceClaimId INT;

begin
/* --------------------------------- */
/*             Actions               */
/* --------------------------------- */

IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Create' AND ActionUri = 'http://ed-fi.org/odsapi/actions/create') THEN

    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Create' , 'http://ed-fi.org/odsapi/actions/create'); 
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Read' AND ActionUri = 'http://ed-fi.org/odsapi/actions/read') THEN

    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Read' , 'http://ed-fi.org/odsapi/actions/read');
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Update' AND ActionUri = 'http://ed-fi.org/odsapi/actions/update') THEN

    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Update' , 'http://ed-fi.org/odsapi/actions/update');
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.Actions WHERE ActionName = 'Delete' AND ActionUri = 'http://ed-fi.org/odsapi/actions/delete') THEN

    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('Delete' , 'http://ed-fi.org/odsapi/actions/delete');
END IF;
/* --------------------------------- */

/* --------------------------------- */
/*           Applications            */
/* --------------------------------- */
IF NOT EXISTS(SELECT 1 FROM dbo.Applications WHERE ApplicationName ='Ed-Fi ODS API') THEN

    INSERT INTO dbo.Applications (ApplicationName)
    VALUES ('Ed-Fi ODS API');
END IF;

SELECT applicationid INTO application_Id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

/* --------------------------------- */

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */
IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='NoFurtherAuthorizationRequired') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('No Further Authorization Required', 'NoFurtherAuthorizationRequired', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsAndPeople') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsOnly') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='NamespaceBased') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Namespace Based', 'NamespaceBased', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithPeopleOnly') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with People only', 'RelationshipsWithPeopleOnly', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithStudentsOnly') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with Students only', 'RelationshipsWithStudentsOnly', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithStudentsOnlyThroughEdOrgAssociation') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with Students only (through StudentEducationOrganizationAssociation)', 'RelationshipsWithStudentsOnlyThroughEdOrgAssociation', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='OwnershipBased') THEN

    INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Ownership Based', 'OwnershipBased', application_Id);
END IF;

/* --------------------------------- */

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='SIS Vor' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('SIS Vor', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ed-Fi Sandbox' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Ed-Fi Sandbox', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Roster Vor' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Roster Vor', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Vor' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Assessment Vor', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Assessment Read' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Assessment Read', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Bootstrap Descriptors and EdOrgs' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Bootstrap Descriptors and EdOrgs', application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName ='Ownership Based Test' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    VALUES ('Ownership Based Test', application_Id);
END IF;

/* --------------------------------- */

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/edFiTypes' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'types', N'types', N'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', NULL, application_Id);
END IF;

SELECT ResourceClaimID INTO typesResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/edFiTypes' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/systemDescriptors' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'systemDescriptors', N'systemDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO systemDescriptorsResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/systemDescriptors' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/managedDescriptors' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'managedDescriptors', N'managedDescriptors', N'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO managedDescriptorsResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/managedDescriptors' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationOrganizations' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'educationOrganizations', N'educationOrganizations', N'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO educationOrganizationsResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationOrganizations' AND Application_ApplicationId = application_Id; 


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/people' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'people', N'people', N'http://ed-fi.org/ods/identity/claims/domains/people', NULL, application_Id);
    SELECT peopleResourceClaimId = SCOPE_IDENTITY();
END IF;

SELECT ResourceClaimId INTO peopleResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/people' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData' AND Application_ApplicationId = application_Id) THEN

    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'relationshipBasedData', N'relationshipBasedData', N'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO relationshipBasedDataResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'assessmentMetadata', N'assessmentMetadata', N'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO assessmentMetadataResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/identity' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'identity', N'identity', N'http://ed-fi.org/ods/identity/claims/domains/identity', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO identityResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/identity' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationStandards' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'educationStandards', N'educationStandards', N'http://ed-fi.org/ods/identity/claims/domains/educationStandards', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO educationStandardsResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/educationStandards' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/primaryRelationships' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'primaryRelationships', N'primaryRelationships', N'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO primaryRelationshipsResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/primaryRelationships' AND Application_ApplicationId = application_Id; 

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/surveyDomain' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'surveyDomain', N'surveyDomain', N'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', NULL, application_Id);
END IF;

SELECT ResourceClaimId INTO surveyDomainResourceClaimId FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/domains/surveyDomain' AND Application_ApplicationId = application_Id; 

/* --------------------------------- */

/* --------------------------------- */
/*        Resource Claims            */
/* --------------------------------- */

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN
    INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    VALUES (N'absenceEventCategoryDescriptor', N'absenceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN
INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'academicHonorCategoryDescriptor', N'academicHonorCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'academicSubjectDescriptor', N'academicSubjectDescriptor', N'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/academicWeek' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'academicWeek', N'academicWeek', N'http://ed-fi.org/ods/identity/claims/academicWeek', relationshipBasedDataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/accommodationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'accommodationDescriptor', N'accommodationDescriptor', N'http://ed-fi.org/ods/identity/claims/accommodationDescriptor', managedDescriptorsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/accountabilityRating' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'accountabilityRating', N'accountabilityRating', N'http://ed-fi.org/ods/identity/claims/accountabilityRating', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/accountTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'accountTypeDescriptor', N'accountTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'achievementCategoryDescriptor', N'achievementCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'additionalCreditTypeDescriptor', N'additionalCreditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/addressTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'addressTypeDescriptor', N'addressTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'administrationEnvironmentDescriptor', N'administrationEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'administrativeFundingControlDescriptor', N'administrativeFundingControlDescriptor', N'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'ancestryEthnicOriginDescriptor', N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessment' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessment', N'assessment', N'http://ed-fi.org/ods/identity/claims/assessment', assessmentMetadataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentCategoryDescriptor', N'assessmentCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentIdentificationSystemDescriptor', N'assessmentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentItem' AND Application_ApplicationId = application_Id) THEN
INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentItem', N'assessmentItem', N'http://ed-fi.org/ods/identity/claims/assessmentItem', assessmentMetadataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentItemCategoryDescriptor', N'assessmentItemCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentItemResultDescriptor', N'assessmentItemResultDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentPeriodDescriptor', N'assessmentPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor', managedDescriptorsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentReportingMethodDescriptor', N'assessmentReportingMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor', managedDescriptorsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assessmentScoreRangeLearningStandard', N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard', assessmentMetadataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'assignmentLateStatusDescriptor', N'assignmentLateStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'attemptStatusDescriptor', N'attemptStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/attanceEventCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'attanceEventCategoryDescriptor', N'attanceEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/attanceEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/balanceSheetDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'balanceSheetDimension', N'balanceSheetDimension', N'http://ed-fi.org/ods/identity/claims/balanceSheetDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'barrierToInternetAccessInResidenceDescriptor', N'barrierToInternetAccessInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/behaviorDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'behaviorDescriptor', N'behaviorDescriptor', N'http://ed-fi.org/ods/identity/claims/behaviorDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/bellSchedule' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'bellSchedule', N'bellSchedule', N'http://ed-fi.org/ods/identity/claims/bellSchedule', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/calar' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'calar', N'calar', N'http://ed-fi.org/ods/identity/claims/calar', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/calarDate' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'calarDate', N'calarDate', N'http://ed-fi.org/ods/identity/claims/calarDate', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/calarEventDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'calarEventDescriptor', N'calarEventDescriptor', N'http://ed-fi.org/ods/identity/claims/calarEventDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/calarTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'calarTypeDescriptor', N'calarTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/calarTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'careerPathwayDescriptor', N'careerPathwayDescriptor', N'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'charterApprovalAgencyTypeDescriptor', N'charterApprovalAgencyTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/charterStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'charterStatusDescriptor', N'charterStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/chartOfAccount' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'chartOfAccount', N'chartOfAccount', N'http://ed-fi.org/ods/identity/claims/chartOfAccount', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'citizenshipStatusDescriptor', N'citizenshipStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/classPeriod' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'classPeriod', N'classPeriod', N'http://ed-fi.org/ods/identity/claims/classPeriod', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'classroomPositionDescriptor', N'classroomPositionDescriptor', N'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/cohort' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'cohort', N'cohort', N'http://ed-fi.org/ods/identity/claims/cohort', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'cohortScopeDescriptor', N'cohortScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'cohortTypeDescriptor', N'cohortTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'cohortYearTypeDescriptor', N'cohortYearTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/communityOrganization' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'communityOrganization', N'communityOrganization', N'http://ed-fi.org/ods/identity/claims/communityOrganization', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/communityProvider' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'communityProvider', N'communityProvider', N'http://ed-fi.org/ods/identity/claims/communityProvider', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/communityProviderLicense' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'communityProviderLicense', N'communityProviderLicense', N'http://ed-fi.org/ods/identity/claims/communityProviderLicense', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'competencyLevelDescriptor', N'competencyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/competencyObjective' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'competencyObjective', N'competencyObjective', N'http://ed-fi.org/ods/identity/claims/competencyObjective', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/contactTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'contactTypeDescriptor', N'contactTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/contentClassDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'contentClassDescriptor', N'contentClassDescriptor', N'http://ed-fi.org/ods/identity/claims/contentClassDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'continuationOfServicesReasonDescriptor', N'continuationOfServicesReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/costRateDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'costRateDescriptor', N'costRateDescriptor', N'http://ed-fi.org/ods/identity/claims/costRateDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/countryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'countryDescriptor', N'countryDescriptor', N'http://ed-fi.org/ods/identity/claims/countryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/course' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'course', N'course', N'http://ed-fi.org/ods/identity/claims/course', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseAttemptResultDescriptor', N'courseAttemptResultDescriptor', N'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseDefinedByDescriptor', N'courseDefinedByDescriptor', N'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseGPAApplicabilityDescriptor', N'courseGPAApplicabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseIdentificationSystemDescriptor', N'courseIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseLevelCharacteristicDescriptor', N'courseLevelCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseOffering' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseOffering', N'courseOffering', N'http://ed-fi.org/ods/identity/claims/courseOffering', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseRepeatCodeDescriptor', N'courseRepeatCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/courseTranscript' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'courseTranscript', N'courseTranscript', N'http://ed-fi.org/ods/identity/claims/courseTranscript', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/credential' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'credential', N'credential', N'http://ed-fi.org/ods/identity/claims/credential', educationStandardsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'credentialFieldDescriptor', N'credentialFieldDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'credentialTypeDescriptor', N'credentialTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'creditCategoryDescriptor', N'creditCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/creditTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'creditTypeDescriptor', N'creditTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'cteProgramServiceDescriptor', N'cteProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'curriculumUsedDescriptor', N'curriculumUsedDescriptor', N'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'deliveryMethodDescriptor', N'deliveryMethodDescriptor', N'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/descriptorMapping' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'descriptorMapping', N'descriptorMapping', N'http://ed-fi.org/ods/identity/claims/descriptorMapping', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/diagnosisDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'diagnosisDescriptor', N'diagnosisDescriptor', N'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'diplomaLevelDescriptor', N'diplomaLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'diplomaTypeDescriptor', N'diplomaTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disabilityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disabilityDescriptor', N'disabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disabilityDesignationDescriptor', N'disabilityDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disabilityDeterminationSourceTypeDescriptor', N'disabilityDeterminationSourceTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disciplineAction' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disciplineAction', N'disciplineAction', N'http://ed-fi.org/ods/identity/claims/disciplineAction', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disciplineActionLengthDifferenceReasonDescriptor', N'disciplineActionLengthDifferenceReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disciplineDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disciplineDescriptor', N'disciplineDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disciplineIncident' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disciplineIncident', N'disciplineIncident', N'http://ed-fi.org/ods/identity/claims/disciplineIncident', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'disciplineIncidentParticipationCodeDescriptor', N'disciplineIncidentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationalEnvironmentDescriptor', N'educationalEnvironmentDescriptor', N'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationContent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationContent', N'educationContent', N'http://ed-fi.org/ods/identity/claims/educationContent', NULL, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationCategoryDescriptor', N'educationOrganizationCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationIdentificationSystemDescriptor', N'educationOrganizationIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationInterventionPrescriptionAssociation', N'educationOrganizationInterventionPrescriptionAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationNetwork', N'educationOrganizationNetwork', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationNetworkAssociation', N'educationOrganizationNetworkAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationOrganizationPeerAssociation', N'educationOrganizationPeerAssociation', N'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationPlanDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationPlanDescriptor', N'educationPlanDescriptor', N'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/educationServiceCenter' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'educationServiceCenter', N'educationServiceCenter', N'http://ed-fi.org/ods/identity/claims/educationServiceCenter', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'electronicMailTypeDescriptor', N'electronicMailTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'employmentStatusDescriptor', N'employmentStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'entryGradeLevelReasonDescriptor', N'entryGradeLevelReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/entryTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'entryTypeDescriptor', N'entryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'eventCircumstanceDescriptor', N'eventCircumstanceDescriptor', N'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'exitWithdrawTypeDescriptor', N'exitWithdrawTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/feederSchoolAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'feederSchoolAssociation', N'feederSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'financialCollectionDescriptor', N'financialCollectionDescriptor', N'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/functionDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'functionDimension', N'functionDimension', N'http://ed-fi.org/ods/identity/claims/functionDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/fundDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'fundDimension', N'fundDimension', N'http://ed-fi.org/ods/identity/claims/fundDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/grade' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'grade', N'grade', N'http://ed-fi.org/ods/identity/claims/grade', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradebookEntry' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradebookEntry', N'gradebookEntry', N'http://ed-fi.org/ods/identity/claims/gradebookEntry', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradebookEntryTypeDescriptor', N'gradebookEntryTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradeLevelDescriptor', N'gradeLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradePointAverageTypeDescriptor', N'gradePointAverageTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradeTypeDescriptor', N'gradeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradingPeriod' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradingPeriod', N'gradingPeriod', N'http://ed-fi.org/ods/identity/claims/gradingPeriod', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gradingPeriodDescriptor', N'gradingPeriodDescriptor', N'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/graduationPlan' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'graduationPlan', N'graduationPlan', N'http://ed-fi.org/ods/identity/claims/graduationPlan', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'graduationPlanTypeDescriptor', N'graduationPlanTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'gunFreeSchoolsActReportingStatusDescriptor', N'gunFreeSchoolsActReportingStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'homelessPrimaryNighttimeResidenceDescriptor', N'homelessPrimaryNighttimeResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'homelessProgramServiceDescriptor', N'homelessProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'identificationDocumentUseDescriptor', N'identificationDocumentUseDescriptor', N'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'incidentLocationDescriptor', N'incidentLocationDescriptor', N'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/indicatorDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'indicatorDescriptor', N'indicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'indicatorGroupDescriptor', N'indicatorGroupDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'indicatorLevelDescriptor', N'indicatorLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'institutionTelephoneNumberTypeDescriptor', N'institutionTelephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'interactivityStyleDescriptor', N'interactivityStyleDescriptor', N'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/internetAccessDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'internetAccessDescriptor', N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'internetAccessTypeInResidenceDescriptor', N'internetAccessTypeInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'internetPerformanceInResidenceDescriptor', N'internetPerformanceInResidenceDescriptor', N'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/intervention' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'intervention', N'intervention', N'http://ed-fi.org/ods/identity/claims/intervention', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/interventionClassDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'interventionClassDescriptor', N'interventionClassDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'interventionEffectivenessRatingDescriptor', N'interventionEffectivenessRatingDescriptor', N'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/interventionPrescription' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'interventionPrescription', N'interventionPrescription', N'http://ed-fi.org/ods/identity/claims/interventionPrescription', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/interventionStudy' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'interventionStudy', N'interventionStudy', N'http://ed-fi.org/ods/identity/claims/interventionStudy', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/languageDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'languageDescriptor', N'languageDescriptor', N'http://ed-fi.org/ods/identity/claims/languageDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'languageInstructionProgramServiceDescriptor', N'languageInstructionProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/languageUseDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'languageUseDescriptor', N'languageUseDescriptor', N'http://ed-fi.org/ods/identity/claims/languageUseDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningObjective' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningObjective', N'learningObjective', N'http://ed-fi.org/ods/identity/claims/learningObjective', educationStandardsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningStandard' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningStandard', N'learningStandard', N'http://ed-fi.org/ods/identity/claims/learningStandard', educationStandardsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningStandardCategoryDescriptor', N'learningStandardCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningStandardEquivalenceAssociation', N'learningStandardEquivalenceAssociation', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation', educationStandardsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningStandardEquivalenceStrengthDescriptor', N'learningStandardEquivalenceStrengthDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'learningStandardScopeDescriptor', N'learningStandardScopeDescriptor', N'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'levelOfEducationDescriptor', N'levelOfEducationDescriptor', N'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'licenseStatusDescriptor', N'licenseStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'licenseTypeDescriptor', N'licenseTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'limitedEnglishProficiencyDescriptor', N'limitedEnglishProficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localAccount' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localAccount', N'localAccount', N'http://ed-fi.org/ods/identity/claims/localAccount', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localActual' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localActual', N'localActual', N'http://ed-fi.org/ods/identity/claims/localActual', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localBudget' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localBudget', N'localBudget', N'http://ed-fi.org/ods/identity/claims/localBudget', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localContractedStaff' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localContractedStaff', N'localContractedStaff', N'http://ed-fi.org/ods/identity/claims/localContractedStaff', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localeDescriptor', N'localeDescriptor', N'http://ed-fi.org/ods/identity/claims/localeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localEducationAgency' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localEducationAgency', N'localEducationAgency', N'http://ed-fi.org/ods/identity/claims/localEducationAgency', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localEducationAgencyCategoryDescriptor', N'localEducationAgencyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localEncumbrance' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localEncumbrance', N'localEncumbrance', N'http://ed-fi.org/ods/identity/claims/localEncumbrance', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/localPayroll' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'localPayroll', N'localPayroll', N'http://ed-fi.org/ods/identity/claims/localPayroll', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/location' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'location', N'location', N'http://ed-fi.org/ods/identity/claims/location', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'magnetSpecialProgramEmphasisSchoolDescriptor', N'magnetSpecialProgramEmphasisSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'mediumOfInstructionDescriptor', N'mediumOfInstructionDescriptor', N'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'methodCreditEarnedDescriptor', N'methodCreditEarnedDescriptor', N'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'migrantEducationProgramServiceDescriptor', N'migrantEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/modelEntityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'modelEntityDescriptor', N'modelEntityDescriptor', N'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/monitoredDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'monitoredDescriptor', N'monitoredDescriptor', N'http://ed-fi.org/ods/identity/claims/monitoredDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'neglectedOrDelinquentProgramDescriptor', N'neglectedOrDelinquentProgramDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'neglectedOrDelinquentProgramServiceDescriptor', N'neglectedOrDelinquentProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'networkPurposeDescriptor', N'networkPurposeDescriptor', N'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/objectDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'objectDimension', N'objectDimension', N'http://ed-fi.org/ods/identity/claims/objectDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/objectiveAssessment' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'objectiveAssessment', N'objectiveAssessment', N'http://ed-fi.org/ods/identity/claims/objectiveAssessment', assessmentMetadataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/oldEthnicityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'oldEthnicityDescriptor', N'oldEthnicityDescriptor', N'http://ed-fi.org/ods/identity/claims/oldEthnicityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/openStaffPosition' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'openStaffPosition', N'openStaffPosition', N'http://ed-fi.org/ods/identity/claims/openStaffPosition', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'operationalStatusDescriptor', N'operationalStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/operationalUnitDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'operationalUnitDimension', N'operationalUnitDimension', N'http://ed-fi.org/ods/identity/claims/operationalUnitDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/organizationDepartment' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'organizationDepartment', N'organizationDepartment', N'http://ed-fi.org/ods/identity/claims/organizationDepartment', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'otherNameTypeDescriptor', N'otherNameTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/parent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'parent', N'parent', N'http://ed-fi.org/ods/identity/claims/parent', peopleResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/participationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'participationDescriptor', N'participationDescriptor', N'http://ed-fi.org/ods/identity/claims/participationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/participationStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'participationStatusDescriptor', N'participationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'performanceBaseConversionDescriptor', N'performanceBaseConversionDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'performanceLevelDescriptor', N'performanceLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor', managedDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/person' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'person', N'person', N'http://ed-fi.org/ods/identity/claims/person', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'personalInformationVerificationDescriptor', N'personalInformationVerificationDescriptor', N'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/platformTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'platformTypeDescriptor', N'platformTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/populationServedDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'populationServedDescriptor', N'populationServedDescriptor', N'http://ed-fi.org/ods/identity/claims/populationServedDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/postingResultDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'postingResultDescriptor', N'postingResultDescriptor', N'http://ed-fi.org/ods/identity/claims/postingResultDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/postSecondaryEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'postSecondaryEvent', N'postSecondaryEvent', N'http://ed-fi.org/ods/identity/claims/postSecondaryEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'postSecondaryEventCategoryDescriptor', N'postSecondaryEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/postSecondaryInstitution' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'postSecondaryInstitution', N'postSecondaryInstitution', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'postSecondaryInstitutionLevelDescriptor', N'postSecondaryInstitutionLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'primaryLearningDeviceAccessDescriptor', N'primaryLearningDeviceAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'primaryLearningDeviceAwayFromSchoolDescriptor', N'primaryLearningDeviceAwayFromSchoolDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'primaryLearningDeviceProviderDescriptor', N'primaryLearningDeviceProviderDescriptor', N'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/proficiencyDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'proficiencyDescriptor', N'proficiencyDescriptor', N'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/program' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'program', N'program', N'http://ed-fi.org/ods/identity/claims/program', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'programAssignmentDescriptor', N'programAssignmentDescriptor', N'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'programCharacteristicDescriptor', N'programCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/programDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'programDimension', N'programDimension', N'http://ed-fi.org/ods/identity/claims/programDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/programSponsorDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'programSponsorDescriptor', N'programSponsorDescriptor', N'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/programTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'programTypeDescriptor', N'programTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/programTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/progressDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'progressDescriptor', N'progressDescriptor', N'http://ed-fi.org/ods/identity/claims/progressDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/progressLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'progressLevelDescriptor', N'progressLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/projectDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'projectDimension', N'projectDimension', N'http://ed-fi.org/ods/identity/claims/projectDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'providerCategoryDescriptor', N'providerCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'providerProfitabilityDescriptor', N'providerProfitabilityDescriptor', N'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/providerStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'providerStatusDescriptor', N'providerStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'publicationStatusDescriptor', N'publicationStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/questionFormDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'questionFormDescriptor', N'questionFormDescriptor', N'http://ed-fi.org/ods/identity/claims/questionFormDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/raceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'raceDescriptor', N'raceDescriptor', N'http://ed-fi.org/ods/identity/claims/raceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'reasonExitedDescriptor', N'reasonExitedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'reasonNotTestedDescriptor', N'reasonNotTestedDescriptor', N'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'recognitionTypeDescriptor', N'recognitionTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/relationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'relationDescriptor', N'relationDescriptor', N'http://ed-fi.org/ods/identity/claims/relationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'repeatIdentifierDescriptor', N'repeatIdentifierDescriptor', N'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/reportCard' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'reportCard', N'reportCard', N'http://ed-fi.org/ods/identity/claims/reportCard', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'reporterDescriptionDescriptor', N'reporterDescriptionDescriptor', N'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/reportingTagDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'reportingTagDescriptor', N'reportingTagDescriptor', N'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'residencyStatusDescriptor', N'residencyStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'responseIndicatorDescriptor', N'responseIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/responsibilityDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'responsibilityDescriptor', N'responsibilityDescriptor', N'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/restraintEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'restraintEvent', N'restraintEvent', N'http://ed-fi.org/ods/identity/claims/restraintEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'restraintEventReasonDescriptor', N'restraintEventReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'resultDatatypeTypeDescriptor', N'resultDatatypeTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'retestIndicatorDescriptor', N'retestIndicatorDescriptor', N'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/school' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'school', N'school', N'http://ed-fi.org/ods/identity/claims/school', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'schoolCategoryDescriptor', N'schoolCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'schoolChoiceImplementStatusDescriptor', N'schoolChoiceImplementStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'schoolFoodServiceProgramServiceDescriptor', N'schoolFoodServiceProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'schoolTypeDescriptor', N'schoolTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/schoolYearType' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'schoolYearType', N'schoolYearType', N'http://ed-fi.org/ods/identity/claims/schoolYearType', typesResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/section' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'section', N'section', N'http://ed-fi.org/ods/identity/claims/section', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/sectionAttanceTakenEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'sectionAttanceTakenEvent', N'sectionAttanceTakenEvent', N'http://ed-fi.org/ods/identity/claims/sectionAttanceTakenEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'sectionCharacteristicDescriptor', N'sectionCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/separationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'separationDescriptor', N'separationDescriptor', N'http://ed-fi.org/ods/identity/claims/separationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/separationReasonDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'separationReasonDescriptor', N'separationReasonDescriptor', N'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/serviceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'serviceDescriptor', N'serviceDescriptor', N'http://ed-fi.org/ods/identity/claims/serviceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/session' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'session', N'session', N'http://ed-fi.org/ods/identity/claims/session', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/sexDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'sexDescriptor', N'sexDescriptor', N'http://ed-fi.org/ods/identity/claims/sexDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/sourceDimension' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'sourceDimension', N'sourceDimension', N'http://ed-fi.org/ods/identity/claims/sourceDimension', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'sourceSystemDescriptor', N'sourceSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'specialEducationProgramServiceDescriptor', N'specialEducationProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'specialEducationSettingDescriptor', N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staff' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staff', N'staff', N'http://ed-fi.org/ods/identity/claims/staff', peopleResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffAbsenceEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffAbsenceEvent', N'staffAbsenceEvent', N'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffClassificationDescriptor', N'staffClassificationDescriptor', N'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffCohortAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffCohortAssociation', N'staffCohortAssociation', N'http://ed-fi.org/ods/identity/claims/staffCohortAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffDisciplineIncidentAssociation', N'staffDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffEducationOrganizationAssignmentAssociation', N'staffEducationOrganizationAssignmentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation', primaryRelationshipsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffEducationOrganizationContactAssociation', N'staffEducationOrganizationContactAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffEducationOrganizationEmploymentAssociation', N'staffEducationOrganizationEmploymentAssociation', N'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation', primaryRelationshipsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffIdentificationSystemDescriptor', N'staffIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffLeave' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffLeave', N'staffLeave', N'http://ed-fi.org/ods/identity/claims/staffLeave', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffLeaveEventCategoryDescriptor', N'staffLeaveEventCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffProgramAssociation', N'staffProgramAssociation', N'http://ed-fi.org/ods/identity/claims/staffProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffSchoolAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffSchoolAssociation', N'staffSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/staffSectionAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'staffSectionAssociation', N'staffSectionAssociation', N'http://ed-fi.org/ods/identity/claims/staffSectionAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'stateAbbreviationDescriptor', N'stateAbbreviationDescriptor', N'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/stateEducationAgency' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'stateEducationAgency', N'stateEducationAgency', N'http://ed-fi.org/ods/identity/claims/stateEducationAgency', educationOrganizationsResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/student' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'student', N'student', N'http://ed-fi.org/ods/identity/claims/student', peopleResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentAcademicRecord' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentAcademicRecord', N'studentAcademicRecord', N'http://ed-fi.org/ods/identity/claims/studentAcademicRecord', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentAssessment' AND Application_ApplicationId = application_Id) THEN
INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentAssessment', N'studentAssessment', N'http://ed-fi.org/ods/identity/claims/studentAssessment', assessmentMetadataResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentCharacteristicDescriptor', N'studentCharacteristicDescriptor', N'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentCohortAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentCohortAssociation', N'studentCohortAssociation', N'http://ed-fi.org/ods/identity/claims/studentCohortAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentCompetencyObjective' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentCompetencyObjective', N'studentCompetencyObjective', N'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentCTEProgramAssociation', N'studentCTEProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentDisciplineIncidentAssociation', N'studentDisciplineIncidentAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOfferAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentDisciplineIncidentNonOfferAssociation', N'studentDisciplineIncidentNonOfferAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOfferAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentEducationOrganizationAssociation', N'studentEducationOrganizationAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentEducationOrganizationResponsibilityAssociation', N'studentEducationOrganizationResponsibilityAssociation', N'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentGradebookEntry' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentGradebookEntry', N'studentGradebookEntry', N'http://ed-fi.org/ods/identity/claims/studentGradebookEntry', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentHomelessProgramAssociation', N'studentHomelessProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentIdentificationSystemDescriptor', N'studentIdentificationSystemDescriptor', N'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentInterventionAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentInterventionAssociation', N'studentInterventionAssociation', N'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentInterventionAttanceEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentInterventionAttanceEvent', N'studentInterventionAttanceEvent', N'http://ed-fi.org/ods/identity/claims/studentInterventionAttanceEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentLanguageInstructionProgramAssociation', N'studentLanguageInstructionProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentLearningObjective' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentLearningObjective', N'studentLearningObjective', N'http://ed-fi.org/ods/identity/claims/studentLearningObjective', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentMigrantEducationProgramAssociation', N'studentMigrantEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentNeglectedOrDelinquentProgramAssociation', N'studentNeglectedOrDelinquentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentParentAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentParentAssociation', N'studentParentAssociation', N'http://ed-fi.org/ods/identity/claims/studentParentAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentParticipationCodeDescriptor', N'studentParticipationCodeDescriptor', N'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentProgramAssociation', N'studentProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentProgramAttanceEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentProgramAttanceEvent', N'studentProgramAttanceEvent', N'http://ed-fi.org/ods/identity/claims/studentProgramAttanceEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSchoolAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSchoolAssociation', N'studentSchoolAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation', primaryRelationshipsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSchoolAttanceEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSchoolAttanceEvent', N'studentSchoolAttanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSchoolAttanceEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSchoolFoodServiceProgramAssociation', N'studentSchoolFoodServiceProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSectionAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSectionAssociation', N'studentSectionAssociation', N'http://ed-fi.org/ods/identity/claims/studentSectionAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSectionAttanceEvent' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSectionAttanceEvent', N'studentSectionAttanceEvent', N'http://ed-fi.org/ods/identity/claims/studentSectionAttanceEvent', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentSpecialEducationProgramAssociation', N'studentSpecialEducationProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'studentTitleIPartAProgramAssociation', N'studentTitleIPartAProgramAssociation', N'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'submissionStatusDescriptor', N'submissionStatusDescriptor', N'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/survey' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'survey', N'survey', N'http://ed-fi.org/ods/identity/claims/survey', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyCategoryDescriptor', N'surveyCategoryDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyCourseAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyCourseAssociation', N'surveyCourseAssociation', N'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyLevelDescriptor', N'surveyLevelDescriptor', N'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyProgramAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyProgramAssociation', N'surveyProgramAssociation', N'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyQuestion' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyQuestion', N'surveyQuestion', N'http://ed-fi.org/ods/identity/claims/surveyQuestion', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyQuestionResponse' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyQuestionResponse', N'surveyQuestionResponse', N'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyResponse' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyResponse', N'surveyResponse', N'http://ed-fi.org/ods/identity/claims/surveyResponse', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyResponseEducationOrganizationTargetAssociation', N'surveyResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveyResponseStaffTargetAssociation', N'surveyResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveySection' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveySection', N'surveySection', N'http://ed-fi.org/ods/identity/claims/surveySection', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveySectionAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveySectionAssociation', N'surveySectionAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveySectionResponse' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveySectionResponse', N'surveySectionResponse', N'http://ed-fi.org/ods/identity/claims/surveySectionResponse', surveyDomainResourceClaimId, application_Id);
END IF;

IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveySectionResponseEducationOrganizationTargetAssociation', N'surveySectionResponseEducationOrganizationTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'surveySectionResponseStaffTargetAssociation', N'surveySectionResponseStaffTargetAssociation', N'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation', relationshipBasedDataResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'teachingCredentialBasisDescriptor', N'teachingCredentialBasisDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'teachingCredentialDescriptor', N'teachingCredentialDescriptor', N'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'technicalSkillsAssessmentDescriptor', N'technicalSkillsAssessmentDescriptor', N'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'telephoneNumberTypeDescriptor', N'telephoneNumberTypeDescriptor', N'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/termDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'termDescriptor', N'termDescriptor', N'http://ed-fi.org/ods/identity/claims/termDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'titleIPartAParticipantDescriptor', N'titleIPartAParticipantDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'titleIPartAProgramServiceDescriptor', N'titleIPartAProgramServiceDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'titleIPartASchoolDesignationDescriptor', N'titleIPartASchoolDesignationDescriptor', N'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'tribalAffiliationDescriptor', N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/visaDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'visaDescriptor', N'visaDescriptor', N'http://ed-fi.org/ods/identity/claims/visaDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName ='http://ed-fi.org/ods/identity/claims/weaponDescriptor' AND Application_ApplicationId = application_Id) THEN

INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES (N'weaponDescriptor', N'weaponDescriptor', N'http://ed-fi.org/ods/identity/claims/weaponDescriptor', systemDescriptorsResourceClaimId, application_Id);
END IF;


/* --------------------------------- */

/* ---------------------------------------------------  */
/*     ClaimSetResourceClaimActions        */
/* ---------------------------------------------------- */

/* SIS Vors Claims */

SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'SIS Vor';

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
   (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read','Update','Delete')) as ac on true
WHERE ResourceName IN ('people'
    , 'relationshipBasedData'
    , 'assessmentMetadata'
    , 'managedDescriptors'
    , 'primaryRelationships'
    , 'educationStandards'
    , 'educationContent')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('people'
    , 'relationshipBasedData'
    , 'assessmentMetadata'
    , 'managedDescriptors'
    , 'primaryRelationships'
    , 'educationStandards'
    , 'educationContent')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);


/* EdFi Sandbox Claims */

SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Ed-Fi Sandbox';

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('types', 'identity')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create', 'Update')) as ac on true
WHERE ResourceName IN ('identity')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null  FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read','Update','Delete')) as ac on true
WHERE ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null  FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* EdFi Sandbox Claims with Overrides */

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create','Read','Update','Delete')) as ac on true
WHERE ResourceName IN ('communityProviderLicense')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* Roster Vor Claims */

SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Roster Vor';

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
    'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
    'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* Assessment Vor Claims */

SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Assessment Vor';

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create','Read','Update','Delete')) as ac on true
WHERE ResourceName IN ('assessmentMetadata')
UNION
SELECT ac.ActionId, claimSet_Id, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('learningObjective', 'learningStandard', 'student')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* Assessment Read Resource Claims */
SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Assessment Read';
INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Bootstrap Descriptors and EdOrgs';

INSERT INTO dbo.ClaimSetResourceClaimActions
    (ActionId
    ,ClaimSetId
    ,ResourceClaimId
    ,ValidationRuleSetNameOverride)
SELECT ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
FROM
(
SELECT ac.ActionId, claimSet_Id AS ClaimSetId, ResourceClaimId, null AS ValidationRuleSetNameOverride
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
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
)
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActions WHERE ActionId = result.ActionId AND ClaimSetId = result.ClaimSetId AND ResourceClaimId = result.ResourceClaimId);

/* --------------------------------- */
/* ResourceClaimActions */
/* --------------------------------- */

/* NoFurtherAuthorizationRequired */

INSERT INTO dbo.ResourceClaimActions
    (ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName)
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM
(
SELECT ac.ActionId, ResourceClaimId, null AS ValidationRuleSetName
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Update')) as ac on true
WHERE ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
UNION
SELECT ac.ActionId, ResourceClaimId, null FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Delete')) as ac on true
WHERE ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ActionId = result.ActionId AND ResourceClaimId = result.ResourceClaimId);

/* NamespaceBased */

INSERT INTO dbo.ResourceClaimActions
    (ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName)
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM
(
SELECT ac.ActionId, ResourceClaimId, null AS ValidationRuleSetName
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read')) as ac on true
WHERE ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create', 'Update', 'Delete')) as ac on true
WHERE ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ActionId = result.ActionId AND ResourceClaimId = result.ResourceClaimId);
/* RelationshipsWithEdOrgsAndPeople */

INSERT INTO dbo.ResourceClaimActions
    (ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName)
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM
(
SELECT ac.ActionId, ResourceClaimId, null AS ValidationRuleSetName
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Read', 'Update')) as ac on true
WHERE ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('relationshipBasedData')
UNION
SELECT ac.ActionId, ResourceClaimId, null
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Delete')) as ac on true
WHERE ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ActionId = result.ActionId AND ResourceClaimId = result.ResourceClaimId);

/* RelationshipsWithStudentsOnly */

INSERT INTO dbo.ResourceClaimActions
    (ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName)
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM
(
SELECT ac.ActionId, ResourceClaimId, null AS ValidationRuleSetName
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('studentParentAssociation')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ActionId = result.ActionId AND ResourceClaimId = result.ResourceClaimId);

/* RelationshipsWithEdOrgsOnly */

INSERT INTO dbo.ResourceClaimActions
    (ActionId
    ,ResourceClaimId
    ,ValidationRuleSetName)
SELECT ActionId, ResourceClaimId, ValidationRuleSetName
FROM
(
SELECT ac.ActionId, ResourceClaimId, null AS ValidationRuleSetName
FROM dbo.ResourceClaims
inner join lateral
    (SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create')) as ac on true
WHERE ResourceName IN ('primaryRelationships')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActions WHERE ActionId = result.ActionId AND ResourceClaimId = result.ResourceClaimId);

/* --------------------------------- */

/* ------------------------------------------- */
/* ResourceClaimActionAuthorizationStrategies */
/* --------------------------------------------- */

/* NoFurtherAuthorizationRequired */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM
(
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id AS AuthorizationStrategyId
FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read')
    AND RC.ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person')

UNION

 SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')

UNION

SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Update')
    AND RC.ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )

UNION

SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Delete')
    AND RC.ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActionAuthorizationStrategies WHERE ResourceClaimActionId = result.ResourceClaimActionId AND AuthorizationStrategyId = result.AuthorizationStrategyId);


/* NamespaceBased */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NamespaceBased';

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)

SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM
(
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id AS AuthorizationStrategyId
FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read')
    AND RC.ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )

UNION

SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create', 'Update', 'Delete')
    AND RC.ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActionAuthorizationStrategies WHERE ResourceClaimActionId = result.ResourceClaimActionId AND AuthorizationStrategyId = result.AuthorizationStrategyId);


/* NamespaceBased THAT SHOULD BE REMOVED */

DELETE 
FROM dbo.ResourceClaimActionAuthorizationStrategies 
WHERE ResourceClaimActionAuthorizationStrategyId IN (
SELECT ResourceClaimActionAuthorizationStrategyId FROM dbo.ResourceClaimActionAuthorizationStrategies RCAS
INNER JOIN dbo.ResourceClaimActions RCAA ON  RCAS.ResourceClaimActionId = RCAA.ResourceClaimActionId
INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
WHERE AuthorizationStrategyId = AuthorizationStrategyId
AND RC.ResourceName IN ('educationStandards')
AND A.ActionName IN ('Read'));
/* RelationshipsWithEdOrgsAndPeople */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM
(
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id AS AuthorizationStrategyId
FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Read', 'Update')
    AND RC.ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
UNION
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('relationshipBasedData')
UNION
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Delete')
    AND RC.ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActionAuthorizationStrategies WHERE ResourceClaimActionId = result.ResourceClaimActionId AND AuthorizationStrategyId = result.AuthorizationStrategyId);



/* RelationshipsWithStudentsOnly */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithStudentsOnly';

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM
(
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id AS AuthorizationStrategyId
FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('studentParentAssociation')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActionAuthorizationStrategies WHERE ResourceClaimActionId = result.ResourceClaimActionId AND AuthorizationStrategyId = result.AuthorizationStrategyId);

/* RelationshipsWithEdOrgsOnly */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
SELECT ResourceClaimActionId, AuthorizationStrategyId
FROM
(
SELECT RCAA.ResourceClaimActionId,authorizationStrategy_Id AS AuthorizationStrategyId
FROM  dbo.ResourceClaimActions RCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = RCAA.ActionId
    WHERE A.ActionName IN ('Create')
    AND RC.ResourceName IN ('primaryRelationships')
) result
WHERE NOT EXISTS (SELECT 1 FROM dbo.ResourceClaimActionAuthorizationStrategies WHERE ResourceClaimActionId = result.ResourceClaimActionId AND AuthorizationStrategyId = result.AuthorizationStrategyId);


/* -------------------------------------------------------------- */
/*     ClaimSetResourceClaimActionAuthorizationStrategyOverrides  */
/* -------------------------------------------------------------- */

/* Bootstrap Descriptors and EdOrgs Claims */

SELECT AuthorizationStrategyId INTO authorizationStrategy_Id FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';
SELECT ClaimSetId INTO claimSet_Id FROM dbo.ClaimSets WHERE ClaimSetName = 'Bootstrap Descriptors and EdOrgs';

INSERT INTO dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    (ClaimSetResourceClaimActionId
    ,AuthorizationStrategyId)

SELECT CSRCAA.ClaimSetResourceClaimActionId, authorizationStrategy_Id FROM  dbo.ClaimSetResourceClaimActions CSRCAA
    INNER JOIN dbo.ResourceClaims RC ON  RC.ResourceClaimId =CSRCAA.ResourceClaimId
    INNER JOIN dbo.Actions A on A.ActionId = CSRCAA.ActionId
    INNER JOIN dbo.ClaimSets CS on CS.ClaimSetId = CSRCAA.ClaimSetId
    WHERE  CS.ClaimSetId =claimSet_Id
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
AND NOT EXISTS (SELECT 1 FROM dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides WHERE ClaimSetResourceClaimActionId = CSRCAA.ClaimSetResourceClaimActionId AND AuthorizationStrategyId = AuthorizationStrategyId);
end $$;
commit;
