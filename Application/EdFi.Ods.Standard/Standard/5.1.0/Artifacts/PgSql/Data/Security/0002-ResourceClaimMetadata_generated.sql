begin transaction;

/* --------------------------------- */
/*        Resource Claims            */
/* --------------------------------- */
do $$

    declare typesResourceClaimId int;
    declare systemDescriptorsResourceClaimId int;
    declare managedDescriptorsResourceClaimId int;
    declare educationOrganizationsResourceClaimId int;
    declare peopleResourceClaimId int;
    declare relationshipBasedDataResourceClaimId int;
    declare assessmentMetadataResourceClaimId int;
    declare identityResourceClaimId int;
    declare educationStandardsResourceClaimId int;
    declare primaryRelationshipsResourceClaimId int;
    declare surveyDomainResourceClaimId int;
begin

    select ResourceClaimId into typesResourceClaimId from dbo.ResourceClaims where ResourceName = 'types';
    select ResourceClaimId into systemDescriptorsResourceClaimId from dbo.ResourceClaims where ResourceName = 'systemDescriptors';
    select ResourceClaimId into managedDescriptorsResourceClaimId from dbo.ResourceClaims where ResourceName = 'managedDescriptors';
    select ResourceClaimId into educationOrganizationsResourceClaimId from dbo.ResourceClaims where ResourceName = 'educationOrganizations';
    select ResourceClaimId into peopleResourceClaimId from dbo.ResourceClaims where ResourceName = 'people';
    select ResourceClaimId into relationshipBasedDataResourceClaimId from dbo.ResourceClaims where ResourceName = 'relationshipBasedData';
    select ResourceClaimId into assessmentMetadataResourceClaimId from dbo.ResourceClaims where ResourceName = 'assessmentMetadata';
    select ResourceClaimId into identityResourceClaimId from dbo.ResourceClaims where ResourceName = 'identity';
    select ResourceClaimId into educationStandardsResourceClaimId from dbo.ResourceClaims where ResourceName = 'educationStandards';
    select ResourceClaimId into primaryRelationshipsResourceClaimId from dbo.ResourceClaims where ResourceName = 'primaryRelationships';
    select ResourceClaimId into surveyDomainResourceClaimId from dbo.ResourceClaims where ResourceName = 'surveyDomain';

/* ------------------------------------------------- */
/*     Resource Claims      */
/* ------------------------------------------------ */

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='absenceEventCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('absenceEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='academicHonorCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('academicHonorCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='academicSubjectDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('academicSubjectDescriptor', 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='accommodationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('accommodationDescriptor', 'http://ed-fi.org/ods/identity/claims/accommodationDescriptor', managedDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='accountTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('accountTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/accountTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='achievementCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('achievementCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='additionalCreditTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('additionalCreditTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='addressTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('addressTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='administrationEnvironmentDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('administrationEnvironmentDescriptor', 'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='administrativeFundingControlDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('administrativeFundingControlDescriptor', 'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='ancestryEthnicOriginDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('ancestryEthnicOriginDescriptor', 'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentIdentificationSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentItemCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentItemCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentItemResultDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentItemResultDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentPeriodDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor', managedDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assessmentReportingMethodDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assessmentReportingMethodDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor', managedDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='assignmentLateStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('assignmentLateStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/assignmentLateStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='attemptStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('attemptStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='attendanceEventCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('attendanceEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='barrierToInternetAccessInResidenceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('barrierToInternetAccessInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='behaviorDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('behaviorDescriptor', 'http://ed-fi.org/ods/identity/claims/behaviorDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='busRouteDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('busRouteDescriptor', 'http://ed-fi.org/ods/identity/claims/busRouteDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='calendarEventDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('calendarEventDescriptor', 'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='calendarTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('calendarTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='careerPathwayDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('careerPathwayDescriptor', 'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='charterApprovalAgencyTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('charterApprovalAgencyTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='charterStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('charterStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='citizenshipStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('citizenshipStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='classroomPositionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('classroomPositionDescriptor', 'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='cohortScopeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('cohortScopeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='cohortTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('cohortTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='cohortYearTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('cohortYearTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='competencyLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('competencyLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='contactTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('contactTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='contentClassDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('contentClassDescriptor', 'http://ed-fi.org/ods/identity/claims/contentClassDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='continuationOfServicesReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('continuationOfServicesReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='costRateDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('costRateDescriptor', 'http://ed-fi.org/ods/identity/claims/costRateDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='countryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('countryDescriptor', 'http://ed-fi.org/ods/identity/claims/countryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseAttemptResultDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseAttemptResultDescriptor', 'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseDefinedByDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseDefinedByDescriptor', 'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseGPAApplicabilityDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseGPAApplicabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseIdentificationSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseLevelCharacteristicDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseLevelCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='courseRepeatCodeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('courseRepeatCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='credentialFieldDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('credentialFieldDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='credentialTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('credentialTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='creditCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('creditCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='creditTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('creditTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='crisisTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('crisisTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/crisisTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='cteProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('cteProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='curriculumUsedDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('curriculumUsedDescriptor', 'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='deliveryMethodDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('deliveryMethodDescriptor', 'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='diagnosisDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('diagnosisDescriptor', 'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='diplomaLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('diplomaLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='diplomaTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('diplomaTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disabilityDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disabilityDesignationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disabilityDesignationDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disabilityDeterminationSourceTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disabilityDeterminationSourceTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disciplineActionLengthDifferenceReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disciplineActionLengthDifferenceReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disciplineDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disciplineDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='disciplineIncidentParticipationCodeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('disciplineIncidentParticipationCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='displacedStudentStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('displacedStudentStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/displacedStudentStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='educationalEnvironmentDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('educationalEnvironmentDescriptor', 'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='educationOrganizationAssociationTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('educationOrganizationAssociationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='educationOrganizationCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('educationOrganizationCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='educationOrganizationIdentificationSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('educationOrganizationIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='educationPlanDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('educationPlanDescriptor', 'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='electronicMailTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('electronicMailTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='eligibilityDelayReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('eligibilityDelayReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/eligibilityDelayReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='eligibilityEvaluationTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('eligibilityEvaluationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/eligibilityEvaluationTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='employmentStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('employmentStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='enrollmentTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('enrollmentTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/enrollmentTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='entryGradeLevelReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('entryGradeLevelReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='entryTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('entryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='evaluationDelayReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('evaluationDelayReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/evaluationDelayReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='eventCircumstanceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('eventCircumstanceDescriptor', 'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='exitWithdrawTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('exitWithdrawTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='financialCollectionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('financialCollectionDescriptor', 'http://ed-fi.org/ods/identity/claims/financialCollectionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gradebookEntryTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gradebookEntryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gradeLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gradeLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gradePointAverageTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gradePointAverageTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gradeTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gradeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gradingPeriodDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gradingPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='graduationPlanTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('graduationPlanTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='gunFreeSchoolsActReportingStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('gunFreeSchoolsActReportingStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='homelessPrimaryNighttimeResidenceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('homelessPrimaryNighttimeResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='homelessProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('homelessProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='ideaPartDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('ideaPartDescriptor', 'http://ed-fi.org/ods/identity/claims/ideaPartDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='identificationDocumentUseDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('identificationDocumentUseDescriptor', 'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='immunizationTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('immunizationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/immunizationTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='incidentLocationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('incidentLocationDescriptor', 'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='indicatorDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('indicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='indicatorGroupDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('indicatorGroupDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='indicatorLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('indicatorLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='institutionTelephoneNumberTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('institutionTelephoneNumberTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='interactivityStyleDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('interactivityStyleDescriptor', 'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='internetAccessDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('internetAccessDescriptor', 'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='internetAccessTypeInResidenceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('internetAccessTypeInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='internetPerformanceInResidenceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('internetPerformanceInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='interventionClassDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('interventionClassDescriptor', 'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='interventionEffectivenessRatingDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('interventionEffectivenessRatingDescriptor', 'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='languageDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('languageDescriptor', 'http://ed-fi.org/ods/identity/claims/languageDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='languageInstructionProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('languageInstructionProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='languageUseDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('languageUseDescriptor', 'http://ed-fi.org/ods/identity/claims/languageUseDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='learningStandardCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('learningStandardCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='learningStandardEquivalenceStrengthDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('learningStandardEquivalenceStrengthDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='learningStandardScopeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('learningStandardScopeDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='levelOfEducationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('levelOfEducationDescriptor', 'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='licenseStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('licenseStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='licenseTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('licenseTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='limitedEnglishProficiencyDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('limitedEnglishProficiencyDescriptor', 'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='localeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('localeDescriptor', 'http://ed-fi.org/ods/identity/claims/localeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='localEducationAgencyCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('localEducationAgencyCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='magnetSpecialProgramEmphasisSchoolDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('magnetSpecialProgramEmphasisSchoolDescriptor', 'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='mediumOfInstructionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('mediumOfInstructionDescriptor', 'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='methodCreditEarnedDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('methodCreditEarnedDescriptor', 'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='migrantEducationProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('migrantEducationProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='modelEntityDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('modelEntityDescriptor', 'http://ed-fi.org/ods/identity/claims/modelEntityDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='monitoredDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('monitoredDescriptor', 'http://ed-fi.org/ods/identity/claims/monitoredDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='neglectedOrDelinquentProgramDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('neglectedOrDelinquentProgramDescriptor', 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='neglectedOrDelinquentProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('neglectedOrDelinquentProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='networkPurposeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('networkPurposeDescriptor', 'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='nonMedicalImmunizationExemptionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('nonMedicalImmunizationExemptionDescriptor', 'http://ed-fi.org/ods/identity/claims/nonMedicalImmunizationExemptionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='operationalStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('operationalStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='otherNameTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('otherNameTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='participationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('participationDescriptor', 'http://ed-fi.org/ods/identity/claims/participationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='participationStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('participationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='performanceBaseConversionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('performanceBaseConversionDescriptor', 'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='performanceLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('performanceLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor', managedDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='personalInformationVerificationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('personalInformationVerificationDescriptor', 'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='platformTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('platformTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='populationServedDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('populationServedDescriptor', 'http://ed-fi.org/ods/identity/claims/populationServedDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='postingResultDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('postingResultDescriptor', 'http://ed-fi.org/ods/identity/claims/postingResultDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='postSecondaryEventCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('postSecondaryEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='postSecondaryInstitutionLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('postSecondaryInstitutionLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='primaryLearningDeviceAccessDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('primaryLearningDeviceAccessDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='primaryLearningDeviceAwayFromSchoolDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('primaryLearningDeviceAwayFromSchoolDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='primaryLearningDeviceProviderDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('primaryLearningDeviceProviderDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='proficiencyDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('proficiencyDescriptor', 'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programAssignmentDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programAssignmentDescriptor', 'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programCharacteristicDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programEvaluationPeriodDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programEvaluationPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/programEvaluationPeriodDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programEvaluationTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programEvaluationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/programEvaluationTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programSponsorDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programSponsorDescriptor', 'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='programTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('programTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/programTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='progressDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('progressDescriptor', 'http://ed-fi.org/ods/identity/claims/progressDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='progressLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('progressLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='providerCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('providerCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='providerProfitabilityDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('providerProfitabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='providerStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('providerStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='publicationStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('publicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='questionFormDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('questionFormDescriptor', 'http://ed-fi.org/ods/identity/claims/questionFormDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='raceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('raceDescriptor', 'http://ed-fi.org/ods/identity/claims/raceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='ratingLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('ratingLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/ratingLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='reasonExitedDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('reasonExitedDescriptor', 'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='reasonNotTestedDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('reasonNotTestedDescriptor', 'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='recognitionTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('recognitionTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='relationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('relationDescriptor', 'http://ed-fi.org/ods/identity/claims/relationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='repeatIdentifierDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('repeatIdentifierDescriptor', 'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='reporterDescriptionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('reporterDescriptionDescriptor', 'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='reportingTagDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('reportingTagDescriptor', 'http://ed-fi.org/ods/identity/claims/reportingTagDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='residencyStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('residencyStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='responseIndicatorDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('responseIndicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='responsibilityDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('responsibilityDescriptor', 'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='restraintEventReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('restraintEventReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='resultDatatypeTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('resultDatatypeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='retestIndicatorDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('retestIndicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='schoolCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('schoolCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='schoolChoiceBasisDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('schoolChoiceBasisDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolChoiceBasisDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='schoolChoiceImplementStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('schoolChoiceImplementStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='schoolFoodServiceProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('schoolFoodServiceProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='schoolTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('schoolTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='sectionCharacteristicDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('sectionCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='sectionTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('sectionTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/sectionTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='separationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('separationDescriptor', 'http://ed-fi.org/ods/identity/claims/separationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='separationReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('separationReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='serviceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('serviceDescriptor', 'http://ed-fi.org/ods/identity/claims/serviceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='sexDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('sexDescriptor', 'http://ed-fi.org/ods/identity/claims/sexDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='sourceSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('sourceSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='specialEducationExitReasonDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('specialEducationExitReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/specialEducationExitReasonDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='specialEducationProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('specialEducationProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='specialEducationSettingDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('specialEducationSettingDescriptor', 'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='staffClassificationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('staffClassificationDescriptor', 'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='staffIdentificationSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('staffIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='staffLeaveEventCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('staffLeaveEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='stateAbbreviationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('stateAbbreviationDescriptor', 'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='studentCharacteristicDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('studentCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='studentIdentificationSystemDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('studentIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='studentParticipationCodeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('studentParticipationCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='submissionStatusDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('submissionStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/submissionStatusDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='supporterMilitaryConnectionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('supporterMilitaryConnectionDescriptor', 'http://ed-fi.org/ods/identity/claims/supporterMilitaryConnectionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='surveyCategoryDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('surveyCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='surveyLevelDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('surveyLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='teachingCredentialBasisDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('teachingCredentialBasisDescriptor', 'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='teachingCredentialDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('teachingCredentialDescriptor', 'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='technicalSkillsAssessmentDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('technicalSkillsAssessmentDescriptor', 'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='telephoneNumberTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('telephoneNumberTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='termDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('termDescriptor', 'http://ed-fi.org/ods/identity/claims/termDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='titleIPartAParticipantDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('titleIPartAParticipantDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='titleIPartAProgramServiceDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('titleIPartAProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='titleIPartASchoolDesignationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('titleIPartASchoolDesignationDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='transportationPublicExpenseEligibilityTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('transportationPublicExpenseEligibilityTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/transportationPublicExpenseEligibilityTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='transportationTypeDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('transportationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/transportationTypeDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='travelDayofWeekDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('travelDayofWeekDescriptor', 'http://ed-fi.org/ods/identity/claims/travelDayofWeekDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='travelDirectionDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('travelDirectionDescriptor', 'http://ed-fi.org/ods/identity/claims/travelDirectionDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='tribalAffiliationDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('tribalAffiliationDescriptor', 'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='visaDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('visaDescriptor', 'http://ed-fi.org/ods/identity/claims/visaDescriptor', systemDescriptorsResourceClaimId);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName ='weaponDescriptor') THEN
    insert into dbo.ResourceClaims (ResourceName, ClaimName, ParentResourceClaimId)
    values ('weaponDescriptor', 'http://ed-fi.org/ods/identity/claims/weaponDescriptor', systemDescriptorsResourceClaimId);
    END IF;

end $$;

/* ------------------------------------------------- */
/*     ClaimSetResourceClaimActions    */
/* ------------------------------------------------ */
do $$
    declare claim_set_id int;
begin

    /* SIS Vendors Claims */

    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'SIS Vendor';

    WITH SisVendorClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
           (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read','Update','Delete')) as ac on true
        where ResourceName IN ('people'
            , 'relationshipBasedData'
            , 'assessmentMetadata'
            , 'managedDescriptors'
            , 'primaryRelationships'
            , 'educationStandards'
            , 'educationContent')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('people'
        , 'relationshipBasedData'
        , 'assessmentMetadata'
        , 'managedDescriptors'
        , 'primaryRelationships'
        , 'educationStandards'
        , 'educationContent')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from SisVendorClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* EdFi Sandbox Claims */

    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Ed-Fi Sandbox';

    WITH EdFiSandboxClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('types', 'identity')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create', 'Update')) as ac on true
        where ResourceName IN ('identity')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read','Update','Delete')) as ac on true
        where ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
            'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
            'educationContent', 'surveyDomain')
         union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('systemDescriptors','educationOrganizations','people', 'relationshipBasedData',
        'assessmentMetadata', 'managedDescriptors',  'primaryRelationships', 'educationStandards',
        'educationContent', 'surveyDomain')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from EdFiSandboxClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* EdFi Sandbox Claims with Overrides */

    WITH EdFiSandboxClaimsWithOverrides AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast (null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create','Read','Update','Delete')) as ac on true
        where ResourceName IN ('communityProviderLicense')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from EdFiSandboxClaimsWithOverrides claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* Roster Vendor Claims */

    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Roster Vendor';

    WITH RosterVendorClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
            'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
            'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from RosterVendorClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* Assessment Vendor Claims */

    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Assessment Vendor';

    WITH AssessmentVendorClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create','Read','Update','Delete')) as ac on true
        where ResourceName IN ('academicSubjectDescriptor', 'assessmentMetadata', 'learningObjective', 'managedDescriptors', 'learningStandard')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('student', 'systemDescriptors', 'types')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from AssessmentVendorClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* Assessment Read Resource Claims */

    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Assessment Read';

    WITH AssessmentReadResourceClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from AssessmentReadResourceClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* Bootstrap Descriptors and EdOrgs Claims */

    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs';

    WITH BootstrapDescriptorsAndEdOrgsClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast (null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN (
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
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from BootstrapDescriptorsAndEdOrgsClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

    /* District Hosted SIS Vendor Claims */

    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'District Hosted SIS Vendor';

    WITH DistrictHostedSisVendorClaims AS (
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'localEducationAgency')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Update')) as ac on true
        where ResourceName IN ('localEducationAgency')
        union
        select ac.ActionId, claim_set_id as ClaimSetId, ResourceClaimId, cast(null as int) as ValidationRuleSetNameOverride
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create','Read','Update','Delete')) as ac on true
        where ResourceName IN ('assessmentMetadata'
            , 'educationContent'
            , 'educationStandards'
            , 'managedDescriptors'
            , 'people'
            , 'primaryRelationships'
            , 'relationshipBasedData'
            , 'school'
            , 'organizationDepartment')
    )
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ActionId, ClaimSetId, ResourceClaimId, ValidationRuleSetNameOverride
    from DistrictHostedSisVendorClaims claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActions where actionId = claims.actionId AND ClaimSetId = claims.ClaimSetId
        and ResourceClaimId = claims.ResourceClaimId);

end $$;

/* --------------------------------- */
/* ResourceClaimActions */
/* --------------------------------- */
do $$
    declare authorization_strategy_id int;
begin

    /* NoFurtherAuthorizationRequired */

    WITH NoFurtherAuthorizationRequiredResourceClaims AS (
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Update')) as ac on true
        where ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Delete')) as ac on true
        where ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
    )
    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ActionId, ResourceClaimId, ValidationRuleSetName
    from NoFurtherAuthorizationRequiredResourceClaims claims
    where not exists (select 1 from dbo.ResourceClaimActions where actionId = claims.actionId AND ResourceClaimId = claims.ResourceClaimId);

    /* NamespaceBased */

    WITH NamespaceBasedResourceClaims AS (
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read')) as ac on true
        where ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create', 'Update', 'Delete')) as ac on true
        where ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain')
    )
    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ActionId, ResourceClaimId, ValidationRuleSetName
    from NamespaceBasedResourceClaims claims
    where not exists (select 1 from dbo.ResourceClaimActions where actionId = claims.actionId AND ResourceClaimId = claims.ResourceClaimId);

    /* RelationshipsWithEdOrgsAndPeople */

    WITH RelationshipsWithEdOrgsAndPeopleResourceClaims AS (
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Read', 'Update')) as ac on true
        where ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData', 'organizationDepartment')
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('relationshipBasedData', 'organizationDepartment')
        union
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Delete')) as ac on true
        where ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships', 'organizationDepartment')
    )
    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ActionId, ResourceClaimId, ValidationRuleSetName
    from RelationshipsWithEdOrgsAndPeopleResourceClaims claims
    where not exists (select 1 from dbo.ResourceClaimActions where actionId = claims.actionId AND ResourceClaimId = claims.ResourceClaimId);

    /* RelationshipsWithStudentsOnly */

    WITH RelationshipsWithStudentsOnlyResourceClaims AS (
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('studentParentAssociation')
    )
    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ActionId, ResourceClaimId, ValidationRuleSetName
    from RelationshipsWithStudentsOnlyResourceClaims claims
    where not exists (select 1 from dbo.ResourceClaimActions where actionId = claims.actionId AND ResourceClaimId = claims.ResourceClaimId);

    /* RelationshipsWithEdOrgsOnly */

    WITH RelationshipsWithEdOrgsOnlyResourceClaims AS (
        select ac.ActionId, ResourceClaimId, cast(null as int) as ValidationRuleSetName
        from dbo.ResourceClaims
        inner join lateral
            (select ActionId
            from dbo.Actions
            where ActionName IN ('Create')) as ac on true
        where ResourceName IN ('primaryRelationships')
    )
    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ActionId, ResourceClaimId, ValidationRuleSetName
    from RelationshipsWithEdOrgsOnlyResourceClaims claims
    where not exists (select 1 from dbo.ResourceClaimActions where actionId = claims.actionId AND ResourceClaimId = claims.ResourceClaimId);

end $$;

/* ------------------------------------------ */
/* ResourceClaimActionAuthorizationStrategies */
/* ------------------------------------------ */

do $$
    declare authorization_strategy_id int;
begin

    /* NoFurtherAuthorizationRequired */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    WITH NoFurtherAuthorizationRequiredAuthorizationStrategies AS (
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName IN ('Read')
            and RC.ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person')
        union
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName IN ('Create')
            and RC.ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
        union
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName IN ('Update')
            and RC.ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
        union
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName IN ('Delete')
            and RC.ResourceName IN ('educationOrganizations', 'people', 'credential', 'person')
    )
    insert into dbo.ResourceClaimActionAuthorizationStrategies
        (ResourceClaimActionId
        ,AuthorizationStrategyId)
    select ResourceClaimActionId,AuthorizationStrategyId
    from NoFurtherAuthorizationRequiredAuthorizationStrategies claims
    where not exists (select 1 from dbo.ResourceClaimActionAuthorizationStrategies where ResourceClaimActionId = claims.ResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* NamespaceBased */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'NamespaceBased';

    WITH NamespaceBasedAuthorizationStrategies AS (
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Read')
            and RC.ResourceName in ('assessmentMetadata', 'educationContent', 'surveyDomain' )
        union
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Create', 'Update', 'Delete')
            and RC.ResourceName in ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain')
    )
    insert into dbo.ResourceClaimActionAuthorizationStrategies
        (ResourceClaimActionId
        ,AuthorizationStrategyId)
    select ResourceClaimActionId,AuthorizationStrategyId
    from NamespaceBasedAuthorizationStrategies claims
    where not exists (select 1 from dbo.ResourceClaimActionAuthorizationStrategies where ResourceClaimActionId = claims.ResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithEdOrgsAndPeople */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    WITH RelationshipsWithEdOrgsAndPeopleAuthorizationStrategies AS (
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Read', 'Update')
            and RC.ResourceName in ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData', 'organizationDepartment')
	    union
	    select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Create')
            and RC.ResourceName in ('relationshipBasedData', 'organizationDepartment')
	    union
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Delete')
            and RC.ResourceName in ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships', 'organizationDepartment')
    )
    insert into dbo.ResourceClaimActionAuthorizationStrategies
        (ResourceClaimActionId
        ,AuthorizationStrategyId)
    select ResourceClaimActionId,AuthorizationStrategyId
    from RelationshipsWithEdOrgsAndPeopleAuthorizationStrategies claims
    where not exists (select 1 from dbo.ResourceClaimActionAuthorizationStrategies where ResourceClaimActionId = claims.ResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithStudentsOnly */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'RelationshipsWithStudentsOnly';

    WITH RelationshipsWithStudentsOnlyAuthorizationStrategies AS (
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Create')
            and RC.ResourceName in ('studentParentAssociation')
    )
    insert into dbo.ResourceClaimActionAuthorizationStrategies
        (ResourceClaimActionId
        ,AuthorizationStrategyId)
    select ResourceClaimActionId,AuthorizationStrategyId
    from RelationshipsWithStudentsOnlyAuthorizationStrategies claims
    where not exists (select 1 from dbo.ResourceClaimActionAuthorizationStrategies where ResourceClaimActionId = claims.ResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

/* RelationshipsWithEdOrgsOnly */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

    WITH RelationshipsWithEdOrgsOnlyAuthorizationStrategies AS (
        select RCAA.ResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ResourceClaimActions RCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = RCAA.ActionId
            where A.ActionName in ('Create')
            and RC.ResourceName in ('primaryRelationships')
    )
    insert into dbo.ResourceClaimActionAuthorizationStrategies
        (ResourceClaimActionId
        ,AuthorizationStrategyId)
    select ResourceClaimActionId,AuthorizationStrategyId
    from RelationshipsWithEdOrgsOnlyAuthorizationStrategies claims
    where not exists (select 1 from dbo.ResourceClaimActionAuthorizationStrategies where ResourceClaimActionId = claims.ResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

end $$;

/* --------------------------------------------------------------- */
/*     ClaimSetResourceClaimActionAuthorizationStrategyOverrides   */
/* --------------------------------------------------------------- */

/* Bootstrap Descriptors and EdOrgs Claims */

do $$
    declare claim_set_id int;
    declare authorization_strategy_id int;
begin

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs';

    WITH ActionAuthorizationStrategyOverrides AS (
        select CSRCAA.ClaimSetResourceClaimActionId,authorization_strategy_id as AuthorizationStrategyId FROM  dbo.ClaimSetResourceClaimActions CSRCAA
            inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =CSRCAA.ResourceClaimId
            inner join dbo.Actions A on A.ActionId = CSRCAA.ActionId
            inner join dbo.ClaimSets CS on CS.ClaimSetId = CSRCAA.ClaimSetId
            where CS.ClaimSetId = claim_set_id
            and A.ActionName in ('Create')
            and RC.ResourceName in (
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
    insert into dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
        (ClaimSetResourceClaimActionId
        ,AuthorizationStrategyId)
    select ClaimSetResourceClaimActionId,AuthorizationStrategyId
    from ActionAuthorizationStrategyOverrides claims
    where not exists (select 1 from dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides where ClaimSetResourceClaimActionId = claims.ClaimSetResourceClaimActionId
        and AuthorizationStrategyId = claims.AuthorizationStrategyId);

end $$;

commit;