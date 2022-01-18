begin transaction;

/* --------------------------------- */
/*      Applications and Actions     */
/* --------------------------------- */
do $$
begin
    insert into dbo.Applications (ApplicationName) values ('Ed-Fi ODS API');

    insert into dbo.Actions (ActionName, ActionUri) values ('Create' , 'http://ed-fi.org/odsapi/actions/create');
    insert into dbo.Actions (ActionName, ActionUri) values ('Read' , 'http://ed-fi.org/odsapi/actions/read');
    insert into dbo.Actions (ActionName, ActionUri) values ('Update' , 'http://ed-fi.org/odsapi/actions/update');
    insert into dbo.Actions (ActionName, ActionUri) values ('Delete' , 'http://ed-fi.org/odsapi/actions/delete');
end;
$$;

/* --------------------------------- */
/*      Authorization Strategies     */
/* --------------------------------- */
do $$
    DECLARE application_id INT;
begin
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('No Further Authorization Required', 'NoFurtherAuthorizationRequired', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Relationships with Education Organizations and People', 'RelationshipsWithEdOrgsAndPeople', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Relationships with Education Organizations only', 'RelationshipsWithEdOrgsOnly', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Namespace Based', 'NamespaceBased', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Relationships with People only', 'RelationshipsWithPeopleOnly', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Relationships with Students only', 'RelationshipsWithStudentsOnly', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Relationships with Students only (through StudentEducationOrganizationAssociation)', 'RelationshipsWithStudentsOnlyThroughEdOrgAssociation', application_id);

    insert into dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    values ('Ownership Based', 'OwnershipBased', application_id);

end $$;

/* --------------------------------- */
/*           Claimsets               */
/* --------------------------------- */
do $$
    declare application_id int;
begin
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('SIS Vendor', application_id);

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('Ed-Fi Sandbox', application_id);

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('Roster Vendor', application_id);

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('Assessment Vendor', application_id);

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('Assessment Read', application_id);

    insert into dbo.ClaimSets (ClaimSetName, Application_ApplicationId)
    values ('Bootstrap Descriptors and EdOrgs', application_id);

end $$;

/* --------------------------------- */
/*     Parent resource claims        */
/* --------------------------------- */
do $$
    declare application_id int;
begin
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('types', 'types', 'http://ed-fi.org/ods/identity/claims/domains/edFiTypes', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('systemDescriptors', 'systemDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('managedDescriptors', 'managedDescriptors', 'http://ed-fi.org/ods/identity/claims/domains/managedDescriptors', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizations', 'educationOrganizations', 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('people', 'people', 'http://ed-fi.org/ods/identity/claims/domains/people', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('relationshipBasedData', 'relationshipBasedData', 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentMetadata', 'assessmentMetadata', 'http://ed-fi.org/ods/identity/claims/domains/assessmentMetadata', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('identity', 'identity', 'http://ed-fi.org/ods/identity/claims/domains/identity', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationStandards', 'educationStandards', 'http://ed-fi.org/ods/identity/claims/domains/educationStandards', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('primaryRelationships', 'primaryRelationships', 'http://ed-fi.org/ods/identity/claims/domains/primaryRelationships', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyDomain', 'surveyDomain', 'http://ed-fi.org/ods/identity/claims/domains/surveyDomain', null, application_id);

end $$;

/* --------------------------------- */
/*        Resource Claims            */
/* --------------------------------- */
do $$
    declare application_id int;

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
    select ApplicationId into application_id from dbo.Applications where ApplicationName = 'Ed-Fi ODS API';

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


    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('absenceEventCategoryDescriptor', 'absenceEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/absenceEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('academicHonorCategoryDescriptor', 'academicHonorCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/academicHonorCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('academicSubjectDescriptor', 'academicSubjectDescriptor', 'http://ed-fi.org/ods/identity/claims/academicSubjectDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('academicWeek', 'academicWeek', 'http://ed-fi.org/ods/identity/claims/academicWeek', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('accommodationDescriptor', 'accommodationDescriptor', 'http://ed-fi.org/ods/identity/claims/accommodationDescriptor', managedDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('account', 'account', 'http://ed-fi.org/ods/identity/claims/account', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('accountabilityRating', 'accountabilityRating', 'http://ed-fi.org/ods/identity/claims/accountabilityRating', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('accountClassificationDescriptor', 'accountClassificationDescriptor', 'http://ed-fi.org/ods/identity/claims/accountClassificationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('accountCode', 'accountCode', 'http://ed-fi.org/ods/identity/claims/accountCode', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('achievementCategoryDescriptor', 'achievementCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/achievementCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('actual', 'actual', 'http://ed-fi.org/ods/identity/claims/actual', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('additionalCreditTypeDescriptor', 'additionalCreditTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/additionalCreditTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('addressTypeDescriptor', 'addressTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/addressTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('administrationEnvironmentDescriptor', 'administrationEnvironmentDescriptor', 'http://ed-fi.org/ods/identity/claims/administrationEnvironmentDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('administrativeFundingControlDescriptor', 'administrativeFundingControlDescriptor', 'http://ed-fi.org/ods/identity/claims/administrativeFundingControlDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('ancestryEthnicOriginDescriptor', 'ancestryEthnicOriginDescriptor', 'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessment', 'assessment', 'http://ed-fi.org/ods/identity/claims/assessment', assessmentMetadataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentCategoryDescriptor', 'assessmentCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentIdentificationSystemDescriptor', 'assessmentIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentItem', 'assessmentItem', 'http://ed-fi.org/ods/identity/claims/assessmentItem', assessmentMetadataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentItemCategoryDescriptor', 'assessmentItemCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentItemCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentItemResultDescriptor', 'assessmentItemResultDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentItemResultDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentPeriodDescriptor', 'assessmentPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentPeriodDescriptor', managedDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentReportingMethodDescriptor', 'assessmentReportingMethodDescriptor', 'http://ed-fi.org/ods/identity/claims/assessmentReportingMethodDescriptor', managedDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('assessmentScoreRangeLearningStandard', 'assessmentScoreRangeLearningStandard', 'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard', assessmentMetadataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('attemptStatusDescriptor', 'attemptStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/attemptStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('attendanceEventCategoryDescriptor', 'attendanceEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/attendanceEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('barrierToInternetAccessInResidenceDescriptor', 'barrierToInternetAccessInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/barrierToInternetAccessInResidenceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('behaviorDescriptor', 'behaviorDescriptor', 'http://ed-fi.org/ods/identity/claims/behaviorDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('bellSchedule', 'bellSchedule', 'http://ed-fi.org/ods/identity/claims/bellSchedule', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('budget', 'budget', 'http://ed-fi.org/ods/identity/claims/budget', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('calendar', 'calendar', 'http://ed-fi.org/ods/identity/claims/calendar', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('calendarDate', 'calendarDate', 'http://ed-fi.org/ods/identity/claims/calendarDate', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('calendarEventDescriptor', 'calendarEventDescriptor', 'http://ed-fi.org/ods/identity/claims/calendarEventDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('calendarTypeDescriptor', 'calendarTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/calendarTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('careerPathwayDescriptor', 'careerPathwayDescriptor', 'http://ed-fi.org/ods/identity/claims/careerPathwayDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('charterApprovalAgencyTypeDescriptor', 'charterApprovalAgencyTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/charterApprovalAgencyTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('charterStatusDescriptor', 'charterStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/charterStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('citizenshipStatusDescriptor', 'citizenshipStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/citizenshipStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('classPeriod', 'classPeriod', 'http://ed-fi.org/ods/identity/claims/classPeriod', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('classroomPositionDescriptor', 'classroomPositionDescriptor', 'http://ed-fi.org/ods/identity/claims/classroomPositionDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('cohort', 'cohort', 'http://ed-fi.org/ods/identity/claims/cohort', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('cohortScopeDescriptor', 'cohortScopeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortScopeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('cohortTypeDescriptor', 'cohortTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('cohortYearTypeDescriptor', 'cohortYearTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/cohortYearTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('communityOrganization', 'communityOrganization', 'http://ed-fi.org/ods/identity/claims/communityOrganization', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('communityProvider', 'communityProvider', 'http://ed-fi.org/ods/identity/claims/communityProvider', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('communityProviderLicense', 'communityProviderLicense', 'http://ed-fi.org/ods/identity/claims/communityProviderLicense', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('competencyLevelDescriptor', 'competencyLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/competencyLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('competencyObjective', 'competencyObjective', 'http://ed-fi.org/ods/identity/claims/competencyObjective', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('contactTypeDescriptor', 'contactTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/contactTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('contentClassDescriptor', 'contentClassDescriptor', 'http://ed-fi.org/ods/identity/claims/contentClassDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('continuationOfServicesReasonDescriptor', 'continuationOfServicesReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/continuationOfServicesReasonDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('contractedStaff', 'contractedStaff', 'http://ed-fi.org/ods/identity/claims/contractedStaff', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('costRateDescriptor', 'costRateDescriptor', 'http://ed-fi.org/ods/identity/claims/costRateDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('countryDescriptor', 'countryDescriptor', 'http://ed-fi.org/ods/identity/claims/countryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('course', 'course', 'http://ed-fi.org/ods/identity/claims/course', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseAttemptResultDescriptor', 'courseAttemptResultDescriptor', 'http://ed-fi.org/ods/identity/claims/courseAttemptResultDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseDefinedByDescriptor', 'courseDefinedByDescriptor', 'http://ed-fi.org/ods/identity/claims/courseDefinedByDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseGPAApplicabilityDescriptor', 'courseGPAApplicabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/courseGPAApplicabilityDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseIdentificationSystemDescriptor', 'courseIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/courseIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseLevelCharacteristicDescriptor', 'courseLevelCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/courseLevelCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseOffering', 'courseOffering', 'http://ed-fi.org/ods/identity/claims/courseOffering', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseRepeatCodeDescriptor', 'courseRepeatCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/courseRepeatCodeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('courseTranscript', 'courseTranscript', 'http://ed-fi.org/ods/identity/claims/courseTranscript', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('credential', 'credential', 'http://ed-fi.org/ods/identity/claims/credential', educationStandardsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('credentialFieldDescriptor', 'credentialFieldDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialFieldDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('credentialTypeDescriptor', 'credentialTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/credentialTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('creditCategoryDescriptor', 'creditCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/creditCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('creditTypeDescriptor', 'creditTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/creditTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('cteProgramServiceDescriptor', 'cteProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/cteProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('curriculumUsedDescriptor', 'curriculumUsedDescriptor', 'http://ed-fi.org/ods/identity/claims/curriculumUsedDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('deliveryMethodDescriptor', 'deliveryMethodDescriptor', 'http://ed-fi.org/ods/identity/claims/deliveryMethodDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('diagnosisDescriptor', 'diagnosisDescriptor', 'http://ed-fi.org/ods/identity/claims/diagnosisDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('diplomaLevelDescriptor', 'diplomaLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/diplomaLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('diplomaTypeDescriptor', 'diplomaTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/diplomaTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disabilityDescriptor', 'disabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disabilityDesignationDescriptor', 'disabilityDesignationDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDesignationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disabilityDeterminationSourceTypeDescriptor', 'disabilityDeterminationSourceTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/disabilityDeterminationSourceTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disciplineAction', 'disciplineAction', 'http://ed-fi.org/ods/identity/claims/disciplineAction', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disciplineActionLengthDifferenceReasonDescriptor', 'disciplineActionLengthDifferenceReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineActionLengthDifferenceReasonDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disciplineDescriptor', 'disciplineDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disciplineIncident', 'disciplineIncident', 'http://ed-fi.org/ods/identity/claims/disciplineIncident', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('disciplineIncidentParticipationCodeDescriptor', 'disciplineIncidentParticipationCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/disciplineIncidentParticipationCodeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationalEnvironmentDescriptor', 'educationalEnvironmentDescriptor', 'http://ed-fi.org/ods/identity/claims/educationalEnvironmentDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationContent', 'educationContent', 'http://ed-fi.org/ods/identity/claims/educationContent', null, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationCategoryDescriptor', 'educationOrganizationCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationIdentificationSystemDescriptor', 'educationOrganizationIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationInterventionPrescriptionAssociation', 'educationOrganizationInterventionPrescriptionAssociation', 'http://ed-fi.org/ods/identity/claims/educationOrganizationInterventionPrescriptionAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationNetwork', 'educationOrganizationNetwork', 'http://ed-fi.org/ods/identity/claims/educationOrganizationNetwork', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationNetworkAssociation', 'educationOrganizationNetworkAssociation', 'http://ed-fi.org/ods/identity/claims/educationOrganizationNetworkAssociation', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationOrganizationPeerAssociation', 'educationOrganizationPeerAssociation', 'http://ed-fi.org/ods/identity/claims/educationOrganizationPeerAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationPlanDescriptor', 'educationPlanDescriptor', 'http://ed-fi.org/ods/identity/claims/educationPlanDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('educationServiceCenter', 'educationServiceCenter', 'http://ed-fi.org/ods/identity/claims/educationServiceCenter', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('electronicMailTypeDescriptor', 'electronicMailTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/electronicMailTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('employmentStatusDescriptor', 'employmentStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/employmentStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('entryGradeLevelReasonDescriptor', 'entryGradeLevelReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/entryGradeLevelReasonDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('entryTypeDescriptor', 'entryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/entryTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('eventCircumstanceDescriptor', 'eventCircumstanceDescriptor', 'http://ed-fi.org/ods/identity/claims/eventCircumstanceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('exitWithdrawTypeDescriptor', 'exitWithdrawTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/exitWithdrawTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('feederSchoolAssociation', 'feederSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/feederSchoolAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('grade', 'grade', 'http://ed-fi.org/ods/identity/claims/grade', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradebookEntry', 'gradebookEntry', 'http://ed-fi.org/ods/identity/claims/gradebookEntry', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradebookEntryTypeDescriptor', 'gradebookEntryTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradebookEntryTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradeLevelDescriptor', 'gradeLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradePointAverageTypeDescriptor', 'gradePointAverageTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradePointAverageTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradeTypeDescriptor', 'gradeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/gradeTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradingPeriod', 'gradingPeriod', 'http://ed-fi.org/ods/identity/claims/gradingPeriod', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gradingPeriodDescriptor', 'gradingPeriodDescriptor', 'http://ed-fi.org/ods/identity/claims/gradingPeriodDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('graduationPlan', 'graduationPlan', 'http://ed-fi.org/ods/identity/claims/graduationPlan', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('graduationPlanTypeDescriptor', 'graduationPlanTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/graduationPlanTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('gunFreeSchoolsActReportingStatusDescriptor', 'gunFreeSchoolsActReportingStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/gunFreeSchoolsActReportingStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('homelessPrimaryNighttimeResidenceDescriptor', 'homelessPrimaryNighttimeResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/homelessPrimaryNighttimeResidenceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('homelessProgramServiceDescriptor', 'homelessProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/homelessProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('identificationDocumentUseDescriptor', 'identificationDocumentUseDescriptor', 'http://ed-fi.org/ods/identity/claims/identificationDocumentUseDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('incidentLocationDescriptor', 'incidentLocationDescriptor', 'http://ed-fi.org/ods/identity/claims/incidentLocationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('indicatorDescriptor', 'indicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('indicatorGroupDescriptor', 'indicatorGroupDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorGroupDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('indicatorLevelDescriptor', 'indicatorLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/indicatorLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('institutionTelephoneNumberTypeDescriptor', 'institutionTelephoneNumberTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/institutionTelephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('interactivityStyleDescriptor', 'interactivityStyleDescriptor', 'http://ed-fi.org/ods/identity/claims/interactivityStyleDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('internetAccessDescriptor', 'internetAccessDescriptor', 'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('internetAccessTypeInResidenceDescriptor', 'internetAccessTypeInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/internetAccessTypeInResidenceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('internetPerformanceInResidenceDescriptor', 'internetPerformanceInResidenceDescriptor', 'http://ed-fi.org/ods/identity/claims/internetPerformanceInResidenceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('intervention', 'intervention', 'http://ed-fi.org/ods/identity/claims/intervention', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('interventionClassDescriptor', 'interventionClassDescriptor', 'http://ed-fi.org/ods/identity/claims/interventionClassDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('interventionEffectivenessRatingDescriptor', 'interventionEffectivenessRatingDescriptor', 'http://ed-fi.org/ods/identity/claims/interventionEffectivenessRatingDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('interventionPrescription', 'interventionPrescription', 'http://ed-fi.org/ods/identity/claims/interventionPrescription', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('interventionStudy', 'interventionStudy', 'http://ed-fi.org/ods/identity/claims/interventionStudy', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('languageDescriptor', 'languageDescriptor', 'http://ed-fi.org/ods/identity/claims/languageDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('languageInstructionProgramServiceDescriptor', 'languageInstructionProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/languageInstructionProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('languageUseDescriptor', 'languageUseDescriptor', 'http://ed-fi.org/ods/identity/claims/languageUseDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningObjective', 'learningObjective', 'http://ed-fi.org/ods/identity/claims/learningObjective', educationStandardsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningStandard', 'learningStandard', 'http://ed-fi.org/ods/identity/claims/learningStandard', educationStandardsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningStandardCategoryDescriptor', 'learningStandardCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningStandardEquivalenceAssociation', 'learningStandardEquivalenceAssociation', 'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceAssociation', educationStandardsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningStandardEquivalenceStrengthDescriptor', 'learningStandardEquivalenceStrengthDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardEquivalenceStrengthDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('learningStandardScopeDescriptor', 'learningStandardScopeDescriptor', 'http://ed-fi.org/ods/identity/claims/learningStandardScopeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('levelOfEducationDescriptor', 'levelOfEducationDescriptor', 'http://ed-fi.org/ods/identity/claims/levelOfEducationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('licenseStatusDescriptor', 'licenseStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/licenseStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('licenseTypeDescriptor', 'licenseTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/licenseTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('limitedEnglishProficiencyDescriptor', 'limitedEnglishProficiencyDescriptor', 'http://ed-fi.org/ods/identity/claims/limitedEnglishProficiencyDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('localeDescriptor', 'localeDescriptor', 'http://ed-fi.org/ods/identity/claims/localeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('localEducationAgency', 'localEducationAgency', 'http://ed-fi.org/ods/identity/claims/localEducationAgency', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('localEducationAgencyCategoryDescriptor', 'localEducationAgencyCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/localEducationAgencyCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('location', 'location', 'http://ed-fi.org/ods/identity/claims/location', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('magnetSpecialProgramEmphasisSchoolDescriptor', 'magnetSpecialProgramEmphasisSchoolDescriptor', 'http://ed-fi.org/ods/identity/claims/magnetSpecialProgramEmphasisSchoolDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('mediumOfInstructionDescriptor', 'mediumOfInstructionDescriptor', 'http://ed-fi.org/ods/identity/claims/mediumOfInstructionDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('methodCreditEarnedDescriptor', 'methodCreditEarnedDescriptor', 'http://ed-fi.org/ods/identity/claims/methodCreditEarnedDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('migrantEducationProgramServiceDescriptor', 'migrantEducationProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/migrantEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('monitoredDescriptor', 'monitoredDescriptor', 'http://ed-fi.org/ods/identity/claims/monitoredDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('neglectedOrDelinquentProgramDescriptor', 'neglectedOrDelinquentProgramDescriptor', 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('neglectedOrDelinquentProgramServiceDescriptor', 'neglectedOrDelinquentProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/neglectedOrDelinquentProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('networkPurposeDescriptor', 'networkPurposeDescriptor', 'http://ed-fi.org/ods/identity/claims/networkPurposeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('objectiveAssessment', 'objectiveAssessment', 'http://ed-fi.org/ods/identity/claims/objectiveAssessment', assessmentMetadataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('oldEthnicityDescriptor', 'oldEthnicityDescriptor', 'http://ed-fi.org/ods/identity/claims/oldEthnicityDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('openStaffPosition', 'openStaffPosition', 'http://ed-fi.org/ods/identity/claims/openStaffPosition', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('operationalStatusDescriptor', 'operationalStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/operationalStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('organizationDepartment', 'organizationDepartment', 'http://ed-fi.org/ods/identity/claims/organizationDepartment', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('otherNameTypeDescriptor', 'otherNameTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/otherNameTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('parent', 'parent', 'http://ed-fi.org/ods/identity/claims/parent', peopleResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('participationDescriptor', 'participationDescriptor', 'http://ed-fi.org/ods/identity/claims/participationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('participationStatusDescriptor', 'participationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/participationStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('payroll', 'payroll', 'http://ed-fi.org/ods/identity/claims/payroll', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('performanceBaseConversionDescriptor', 'performanceBaseConversionDescriptor', 'http://ed-fi.org/ods/identity/claims/performanceBaseConversionDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('performanceLevelDescriptor', 'performanceLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/performanceLevelDescriptor', managedDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('person', 'person', 'http://ed-fi.org/ods/identity/claims/person', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('personalInformationVerificationDescriptor', 'personalInformationVerificationDescriptor', 'http://ed-fi.org/ods/identity/claims/personalInformationVerificationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('platformTypeDescriptor', 'platformTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/platformTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('populationServedDescriptor', 'populationServedDescriptor', 'http://ed-fi.org/ods/identity/claims/populationServedDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('postingResultDescriptor', 'postingResultDescriptor', 'http://ed-fi.org/ods/identity/claims/postingResultDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('postSecondaryEvent', 'postSecondaryEvent', 'http://ed-fi.org/ods/identity/claims/postSecondaryEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('postSecondaryEventCategoryDescriptor', 'postSecondaryEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/postSecondaryEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('postSecondaryInstitution', 'postSecondaryInstitution', 'http://ed-fi.org/ods/identity/claims/postSecondaryInstitution', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('postSecondaryInstitutionLevelDescriptor', 'postSecondaryInstitutionLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/postSecondaryInstitutionLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('primaryLearningDeviceAccessDescriptor', 'primaryLearningDeviceAccessDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAccessDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('primaryLearningDeviceAwayFromSchoolDescriptor', 'primaryLearningDeviceAwayFromSchoolDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceAwayFromSchoolDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('primaryLearningDeviceProviderDescriptor', 'primaryLearningDeviceProviderDescriptor', 'http://ed-fi.org/ods/identity/claims/primaryLearningDeviceProviderDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('proficiencyDescriptor', 'proficiencyDescriptor', 'http://ed-fi.org/ods/identity/claims/proficiencyDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('program', 'program', 'http://ed-fi.org/ods/identity/claims/program', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('programAssignmentDescriptor', 'programAssignmentDescriptor', 'http://ed-fi.org/ods/identity/claims/programAssignmentDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('programCharacteristicDescriptor', 'programCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/programCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('programSponsorDescriptor', 'programSponsorDescriptor', 'http://ed-fi.org/ods/identity/claims/programSponsorDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('programTypeDescriptor', 'programTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/programTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('progressDescriptor', 'progressDescriptor', 'http://ed-fi.org/ods/identity/claims/progressDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('progressLevelDescriptor', 'progressLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/progressLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('providerCategoryDescriptor', 'providerCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/providerCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('providerProfitabilityDescriptor', 'providerProfitabilityDescriptor', 'http://ed-fi.org/ods/identity/claims/providerProfitabilityDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('providerStatusDescriptor', 'providerStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/providerStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('publicationStatusDescriptor', 'publicationStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/publicationStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('questionFormDescriptor', 'questionFormDescriptor', 'http://ed-fi.org/ods/identity/claims/questionFormDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('raceDescriptor', 'raceDescriptor', 'http://ed-fi.org/ods/identity/claims/raceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('reasonExitedDescriptor', 'reasonExitedDescriptor', 'http://ed-fi.org/ods/identity/claims/reasonExitedDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('reasonNotTestedDescriptor', 'reasonNotTestedDescriptor', 'http://ed-fi.org/ods/identity/claims/reasonNotTestedDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('recognitionTypeDescriptor', 'recognitionTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/recognitionTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('relationDescriptor', 'relationDescriptor', 'http://ed-fi.org/ods/identity/claims/relationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('repeatIdentifierDescriptor', 'repeatIdentifierDescriptor', 'http://ed-fi.org/ods/identity/claims/repeatIdentifierDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('reportCard', 'reportCard', 'http://ed-fi.org/ods/identity/claims/reportCard', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('reporterDescriptionDescriptor', 'reporterDescriptionDescriptor', 'http://ed-fi.org/ods/identity/claims/reporterDescriptionDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('residencyStatusDescriptor', 'residencyStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/residencyStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('responseIndicatorDescriptor', 'responseIndicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/responseIndicatorDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('responsibilityDescriptor', 'responsibilityDescriptor', 'http://ed-fi.org/ods/identity/claims/responsibilityDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('restraintEvent', 'restraintEvent', 'http://ed-fi.org/ods/identity/claims/restraintEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('restraintEventReasonDescriptor', 'restraintEventReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/restraintEventReasonDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('resultDatatypeTypeDescriptor', 'resultDatatypeTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/resultDatatypeTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('retestIndicatorDescriptor', 'retestIndicatorDescriptor', 'http://ed-fi.org/ods/identity/claims/retestIndicatorDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('school', 'school', 'http://ed-fi.org/ods/identity/claims/school', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('schoolCategoryDescriptor', 'schoolCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('schoolChoiceImplementStatusDescriptor', 'schoolChoiceImplementStatusDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolChoiceImplementStatusDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('schoolFoodServiceProgramServiceDescriptor', 'schoolFoodServiceProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolFoodServiceProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('schoolTypeDescriptor', 'schoolTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/schoolTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('schoolYearType', 'schoolYearType', 'http://ed-fi.org/ods/identity/claims/schoolYearType', typesResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('section', 'section', 'http://ed-fi.org/ods/identity/claims/section', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('sectionAttendanceTakenEvent', 'sectionAttendanceTakenEvent', 'http://ed-fi.org/ods/identity/claims/sectionAttendanceTakenEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('sectionCharacteristicDescriptor', 'sectionCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/sectionCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('separationDescriptor', 'separationDescriptor', 'http://ed-fi.org/ods/identity/claims/separationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('separationReasonDescriptor', 'separationReasonDescriptor', 'http://ed-fi.org/ods/identity/claims/separationReasonDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('serviceDescriptor', 'serviceDescriptor', 'http://ed-fi.org/ods/identity/claims/serviceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('session', 'session', 'http://ed-fi.org/ods/identity/claims/session', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('sexDescriptor', 'sexDescriptor', 'http://ed-fi.org/ods/identity/claims/sexDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('sourceSystemDescriptor', 'sourceSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/sourceSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('specialEducationProgramServiceDescriptor', 'specialEducationProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/specialEducationProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('specialEducationSettingDescriptor', 'specialEducationSettingDescriptor', 'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staff', 'staff', 'http://ed-fi.org/ods/identity/claims/staff', peopleResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffAbsenceEvent', 'staffAbsenceEvent', 'http://ed-fi.org/ods/identity/claims/staffAbsenceEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffClassificationDescriptor', 'staffClassificationDescriptor', 'http://ed-fi.org/ods/identity/claims/staffClassificationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffCohortAssociation', 'staffCohortAssociation', 'http://ed-fi.org/ods/identity/claims/staffCohortAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffDisciplineIncidentAssociation', 'staffDisciplineIncidentAssociation', 'http://ed-fi.org/ods/identity/claims/staffDisciplineIncidentAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffEducationOrganizationAssignmentAssociation', 'staffEducationOrganizationAssignmentAssociation', 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationAssignmentAssociation', primaryRelationshipsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffEducationOrganizationContactAssociation', 'staffEducationOrganizationContactAssociation', 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationContactAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffEducationOrganizationEmploymentAssociation', 'staffEducationOrganizationEmploymentAssociation', 'http://ed-fi.org/ods/identity/claims/staffEducationOrganizationEmploymentAssociation', primaryRelationshipsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffIdentificationSystemDescriptor', 'staffIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/staffIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffLeave', 'staffLeave', 'http://ed-fi.org/ods/identity/claims/staffLeave', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffLeaveEventCategoryDescriptor', 'staffLeaveEventCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/staffLeaveEventCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffProgramAssociation', 'staffProgramAssociation', 'http://ed-fi.org/ods/identity/claims/staffProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffSchoolAssociation', 'staffSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/staffSchoolAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('staffSectionAssociation', 'staffSectionAssociation', 'http://ed-fi.org/ods/identity/claims/staffSectionAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('stateAbbreviationDescriptor', 'stateAbbreviationDescriptor', 'http://ed-fi.org/ods/identity/claims/stateAbbreviationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('stateEducationAgency', 'stateEducationAgency', 'http://ed-fi.org/ods/identity/claims/stateEducationAgency', educationOrganizationsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('student', 'student', 'http://ed-fi.org/ods/identity/claims/student', peopleResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentAcademicRecord', 'studentAcademicRecord', 'http://ed-fi.org/ods/identity/claims/studentAcademicRecord', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentAssessment', 'studentAssessment', 'http://ed-fi.org/ods/identity/claims/studentAssessment', assessmentMetadataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentCharacteristicDescriptor', 'studentCharacteristicDescriptor', 'http://ed-fi.org/ods/identity/claims/studentCharacteristicDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentCohortAssociation', 'studentCohortAssociation', 'http://ed-fi.org/ods/identity/claims/studentCohortAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentCompetencyObjective', 'studentCompetencyObjective', 'http://ed-fi.org/ods/identity/claims/studentCompetencyObjective', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentCTEProgramAssociation', 'studentCTEProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentCTEProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentDisciplineIncidentAssociation', 'studentDisciplineIncidentAssociation', 'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentDisciplineIncidentBehaviorAssociation', 'studentDisciplineIncidentBehaviorAssociation', 'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentDisciplineIncidentNonOffenderAssociation', 'studentDisciplineIncidentNonOffenderAssociation', 'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentEducationOrganizationAssociation', 'studentEducationOrganizationAssociation', 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentEducationOrganizationResponsibilityAssociation', 'studentEducationOrganizationResponsibilityAssociation', 'http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentGradebookEntry', 'studentGradebookEntry', 'http://ed-fi.org/ods/identity/claims/studentGradebookEntry', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentHomelessProgramAssociation', 'studentHomelessProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentHomelessProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentIdentificationSystemDescriptor', 'studentIdentificationSystemDescriptor', 'http://ed-fi.org/ods/identity/claims/studentIdentificationSystemDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentInterventionAssociation', 'studentInterventionAssociation', 'http://ed-fi.org/ods/identity/claims/studentInterventionAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentInterventionAttendanceEvent', 'studentInterventionAttendanceEvent', 'http://ed-fi.org/ods/identity/claims/studentInterventionAttendanceEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentLanguageInstructionProgramAssociation', 'studentLanguageInstructionProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentLanguageInstructionProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentLearningObjective', 'studentLearningObjective', 'http://ed-fi.org/ods/identity/claims/studentLearningObjective', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentMigrantEducationProgramAssociation', 'studentMigrantEducationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentMigrantEducationProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentNeglectedOrDelinquentProgramAssociation', 'studentNeglectedOrDelinquentProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentNeglectedOrDelinquentProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentParentAssociation', 'studentParentAssociation', 'http://ed-fi.org/ods/identity/claims/studentParentAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentParticipationCodeDescriptor', 'studentParticipationCodeDescriptor', 'http://ed-fi.org/ods/identity/claims/studentParticipationCodeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentProgramAssociation', 'studentProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentProgramAttendanceEvent', 'studentProgramAttendanceEvent', 'http://ed-fi.org/ods/identity/claims/studentProgramAttendanceEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSchoolAssociation', 'studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/studentSchoolAssociation', primaryRelationshipsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSchoolAttendanceEvent', 'studentSchoolAttendanceEvent', 'http://ed-fi.org/ods/identity/claims/studentSchoolAttendanceEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSchoolFoodServiceProgramAssociation', 'studentSchoolFoodServiceProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentSchoolFoodServiceProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSectionAssociation', 'studentSectionAssociation', 'http://ed-fi.org/ods/identity/claims/studentSectionAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSectionAttendanceEvent', 'studentSectionAttendanceEvent', 'http://ed-fi.org/ods/identity/claims/studentSectionAttendanceEvent', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentSpecialEducationProgramAssociation', 'studentSpecialEducationProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentSpecialEducationProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('studentTitleIPartAProgramAssociation', 'studentTitleIPartAProgramAssociation', 'http://ed-fi.org/ods/identity/claims/studentTitleIPartAProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('survey', 'survey', 'http://ed-fi.org/ods/identity/claims/survey', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyCategoryDescriptor', 'surveyCategoryDescriptor', 'http://ed-fi.org/ods/identity/claims/surveyCategoryDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyCourseAssociation', 'surveyCourseAssociation', 'http://ed-fi.org/ods/identity/claims/surveyCourseAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyLevelDescriptor', 'surveyLevelDescriptor', 'http://ed-fi.org/ods/identity/claims/surveyLevelDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyProgramAssociation', 'surveyProgramAssociation', 'http://ed-fi.org/ods/identity/claims/surveyProgramAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyQuestion', 'surveyQuestion', 'http://ed-fi.org/ods/identity/claims/surveyQuestion', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyQuestionResponse', 'surveyQuestionResponse', 'http://ed-fi.org/ods/identity/claims/surveyQuestionResponse', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyResponse', 'surveyResponse', 'http://ed-fi.org/ods/identity/claims/surveyResponse', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyResponseEducationOrganizationTargetAssociation', 'surveyResponseEducationOrganizationTargetAssociation', 'http://ed-fi.org/ods/identity/claims/surveyResponseEducationOrganizationTargetAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveyResponseStaffTargetAssociation', 'surveyResponseStaffTargetAssociation', 'http://ed-fi.org/ods/identity/claims/surveyResponseStaffTargetAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveySection', 'surveySection', 'http://ed-fi.org/ods/identity/claims/surveySection', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveySectionAssociation', 'surveySectionAssociation', 'http://ed-fi.org/ods/identity/claims/surveySectionAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveySectionResponse', 'surveySectionResponse', 'http://ed-fi.org/ods/identity/claims/surveySectionResponse', surveyDomainResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveySectionResponseEducationOrganizationTargetAssociation', 'surveySectionResponseEducationOrganizationTargetAssociation', 'http://ed-fi.org/ods/identity/claims/surveySectionResponseEducationOrganizationTargetAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('surveySectionResponseStaffTargetAssociation', 'surveySectionResponseStaffTargetAssociation', 'http://ed-fi.org/ods/identity/claims/surveySectionResponseStaffTargetAssociation', relationshipBasedDataResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('teachingCredentialBasisDescriptor', 'teachingCredentialBasisDescriptor', 'http://ed-fi.org/ods/identity/claims/teachingCredentialBasisDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('teachingCredentialDescriptor', 'teachingCredentialDescriptor', 'http://ed-fi.org/ods/identity/claims/teachingCredentialDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('technicalSkillsAssessmentDescriptor', 'technicalSkillsAssessmentDescriptor', 'http://ed-fi.org/ods/identity/claims/technicalSkillsAssessmentDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('telephoneNumberTypeDescriptor', 'telephoneNumberTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/telephoneNumberTypeDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('termDescriptor', 'termDescriptor', 'http://ed-fi.org/ods/identity/claims/termDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('titleIPartAParticipantDescriptor', 'titleIPartAParticipantDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartAParticipantDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('titleIPartAProgramServiceDescriptor', 'titleIPartAProgramServiceDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartAProgramServiceDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('titleIPartASchoolDesignationDescriptor', 'titleIPartASchoolDesignationDescriptor', 'http://ed-fi.org/ods/identity/claims/titleIPartASchoolDesignationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('tribalAffiliationDescriptor', 'tribalAffiliationDescriptor', 'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('visaDescriptor', 'visaDescriptor', 'http://ed-fi.org/ods/identity/claims/visaDescriptor', systemDescriptorsResourceClaimId, application_id);

    insert into dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
    values ('weaponDescriptor', 'weaponDescriptor', 'http://ed-fi.org/ods/identity/claims/weaponDescriptor', systemDescriptorsResourceClaimId, application_id);
end $$;

/* ------------------------------------------------- */
/*     ClaimSetResourceClaimActions    */
/* ------------------------------------------------ */
do $$
    declare claim_set_id int;
    declare authorization_strategy_id int;
begin

    /* SIS Vendors Claims */
    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'SIS Vendor';

    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
       (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations')
    union
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
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
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
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
    , 'educationContent');

    /* EdFi Sandbox Claims */
    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Ed-Fi Sandbox';

    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('types', 'identity')
    union
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create', 'Update')) as ac on true
    where ResourceName IN ('identity')
    union
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read','Update','Delete')) as ac on true
    where ResourceName IN ('systemDescriptors', 'educationOrganizations', 'people', 'relationshipBasedData',
        'assessmentMetadata', 'managedDescriptors', 'primaryRelationships', 'educationStandards',
        'educationContent', 'surveyDomain')
     union
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create')) as ac on true
    where ResourceName IN ('systemDescriptors','educationOrganizations','people', 'relationshipBasedData',
    'assessmentMetadata', 'managedDescriptors',  'primaryRelationships', 'educationStandards',
    'educationContent', 'surveyDomain');

    /* EdFi Sandbox Claims with Overrides */

     insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast (null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create','Read','Update','Delete')) as ac on true
    where ResourceName IN ('communityProviderLicense');

    /* Roster Vendor Claims */
    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Roster Vendor';

    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('educationOrganizations', 'section', 'student', 'staff', 'courseOffering',
        'session', 'classPeriod', 'location', 'course', 'staffSectionAssociation',
        'staffEducationOrganizationAssignmentAssociation', 'studentSectionAssociation', 'studentSchoolAssociation');

    /* Assessment Vendor Claims */
    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Assessment Vendor';

    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create','Read','Update','Delete')) as ac on true
    where ResourceName IN ('assessmentMetadata')
    union
    select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('learningObjective', 'learningStandard', 'student');

    /* Assessment Read Resource Claims */
    select ClaimSetId into claim_set_id from dbo.ClaimSets where ClaimSetName = 'Assessment Read';

 insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
 select ac.ActionId, claim_set_id, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('assessmentMetadata', 'learningObjective', 'learningStandard', 'student');

    /* Bootstrap Descriptors and EdOrgs Claims */

    select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs';
    insert into dbo.ClaimSetResourceClaimActions
        (ActionId
        ,ClaimSetId
        ,ResourceClaimId
        ,ValidationRuleSetNameOverride)
    select ac.ActionId, claim_set_id, ResourceClaimId, cast (null as int)
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
    'communityProviderLicense',
    'course',
    'educationOrganizationPeerAssociation',
    'feederSchoolAssociation',
    'location',
    'program'
    );

end $$;

/* --------------------------------- */
/* ResourceClaimActions */
/* --------------------------------- */
do $$
    declare authorization_strategy_id int;
begin

    /* NoFurtherAuthorizationRequired */

    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person' )
    union
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create')) as ac on true
    where ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')
    union
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Update')) as ac on true
    where ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )
    union
    select ac.ActionId, ResourceClaimId, cast(null as int) from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Delete')) as ac on true
    where ResourceName IN ('educationOrganizations', 'people', 'credential', 'person');

    /* NamespaceBased */

    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read')) as ac on true
    where ResourceName IN ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
    union
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create', 'Update', 'Delete')) as ac on true
    where ResourceName IN ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain');

    /* RelationshipsWithEdOrgsAndPeople */

    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Read', 'Update')) as ac on true
    where ResourceName IN ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
    union
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create')) as ac on true
    where ResourceName IN ('relationshipBasedData')
    union
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Delete')) as ac on true
    where ResourceName IN ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships');

    /* RelationshipsWithStudentsOnly */

    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create')) as ac on true
    where ResourceName IN ('studentParentAssociation');

    /* RelationshipsWithEdOrgsOnly */

    insert into dbo.ResourceClaimActions
        (ActionId
        ,ResourceClaimId
        ,ValidationRuleSetName)
    select ac.ActionId, ResourceClaimId, cast(null as int)
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName IN ('Create')) as ac on true
    where ResourceName IN ('primaryRelationships');

end $$;

/* ------------------------------------------ */
/* ResourceClaimActionAuthorizationStrategies */
/* ------------------------------------------ */

/* NoFurtherAuthorizationRequired */

do $$
    declare authorization_strategy_id int;
begin

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

    insert into dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)

    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName IN ('Read')
    and RC.ResourceName IN ('types', 'systemDescriptors', 'educationOrganizations', 'course', 'managedDescriptors', 'identity', 'credential', 'person')

    union

    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
        inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        inner join dbo.Actions A on A.ActionId = RCAA.ActionId
        where A.ActionName IN ('Create')
        and RC.ResourceName IN ('educationOrganizations', 'credential', 'people', 'identity', 'person')

    union

    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
        inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        inner join dbo.Actions A on A.ActionId = RCAA.ActionId
        where A.ActionName IN ('Update')
        and RC.ResourceName IN ('educationOrganizations', 'identity', 'credential', 'person' )

    union

    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
        inner join dbo.ResourceClaims RC ON  RC.ResourceClaimId =RCAA.ResourceClaimId
        inner join dbo.Actions A on A.ActionId = RCAA.ActionId
        where A.ActionName IN ('Delete')
        and RC.ResourceName IN ('educationOrganizations', 'people', 'credential', 'person');


/* NamespaceBased */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'NamespaceBased';

    insert into dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)

    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Read')
    and RC.ResourceName in ('assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain' )
    union
    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Create', 'Update', 'Delete')
    and RC.ResourceName in ('systemDescriptors', 'managedDescriptors', 'assessmentMetadata', 'educationStandards', 'educationContent', 'surveyDomain');




/* RelationshipsWithEdOrgsAndPeople */

    select AuthorizationStrategyId into authorization_strategy_id
    from dbo.AuthorizationStrategies
    where AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeople';

    insert into dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Read', 'Update')
    and RC.ResourceName in ('primaryRelationships', 'studentParentAssociation', 'people', 'relationshipBasedData')
	union
	select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Create')
    and RC.ResourceName in ('relationshipBasedData')
	union
    select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Delete')
    and RC.ResourceName in ('relationshipBasedData', 'studentParentAssociation', 'primaryRelationships');


/* RelationshipsWithStudentsOnly */

select AuthorizationStrategyId into authorization_strategy_id
from dbo.AuthorizationStrategies
where AuthorizationStrategyName = 'RelationshipsWithStudentsOnly';

insert into dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Create')
    and RC.ResourceName in ('studentParentAssociation');

/* RelationshipsWithEdOrgsOnly */

select AuthorizationStrategyId into authorization_strategy_id
from dbo.AuthorizationStrategies
where AuthorizationStrategyName = 'RelationshipsWithEdOrgsOnly';

insert into dbo.ResourceClaimActionAuthorizationStrategies
    (ResourceClaimActionId
    ,AuthorizationStrategyId)
select RCAA.ResourceClaimActionId,authorization_strategy_id FROM  dbo.ResourceClaimActions RCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =RCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = RCAA.ActionId
    where A.ActionName in ('Create')
    and RC.ResourceName in ('primaryRelationships');

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

select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Ed-Fi Sandbox';

insert into dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    (ClaimSetResourceClaimActionId
    ,AuthorizationStrategyId)
select CSRCAA.ClaimSetResourceClaimActionId,authorization_strategy_id FROM  dbo.ClaimSetResourceClaimActions CSRCAA
    inner join dbo.ResourceClaims RC on  RC.ResourceClaimId =CSRCAA.ResourceClaimId
    inner join dbo.Actions A on A.ActionId = CSRCAA.ActionId
    inner join dbo.ClaimSets CS on CS.ClaimSetId = CSRCAA.ClaimSetId
    where CS.ClaimSetId = claim_set_id
    and A.ActionName in ('Create','Read','Update','Delete')
    and RC.ResourceName in ('communityProviderLicense');

select ClaimSetId INTO claim_set_id from dbo.ClaimSets where ClaimSetName = 'Bootstrap Descriptors and EdOrgs';

insert into dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    (ClaimSetResourceClaimActionId
    ,AuthorizationStrategyId)
select CSRCAA.ClaimSetResourceClaimActionId,authorization_strategy_id FROM  dbo.ClaimSetResourceClaimActions CSRCAA
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
    'stateEducationAgency');
end $$;

commit;
