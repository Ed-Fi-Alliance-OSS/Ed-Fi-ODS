using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: AccreditationStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.AccreditationStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class AccreditationStatusDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_AccreditationStatusDescriptor = new FullName("tpdm", "AccreditationStatusDescriptor");
    
        public static bool SynchronizeTo(this IAccreditationStatusDescriptor source, IAccreditationStatusDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (AccreditationStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_AccreditationStatusDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AccreditationStatusDescriptorId != target.AccreditationStatusDescriptorId)
            {
                source.AccreditationStatusDescriptorId = target.AccreditationStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IAccreditationStatusDescriptor source, IAccreditationStatusDescriptor target, Action<IAccreditationStatusDescriptor, IAccreditationStatusDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (AccreditationStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_AccreditationStatusDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AccreditationStatusDescriptorId = source.AccreditationStatusDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: AidTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.AidTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class AidTypeDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_AidTypeDescriptor = new FullName("tpdm", "AidTypeDescriptor");
    
        public static bool SynchronizeTo(this IAidTypeDescriptor source, IAidTypeDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (AidTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_AidTypeDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AidTypeDescriptorId != target.AidTypeDescriptorId)
            {
                source.AidTypeDescriptorId = target.AidTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IAidTypeDescriptor source, IAidTypeDescriptor target, Action<IAidTypeDescriptor, IAidTypeDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (AidTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_AidTypeDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AidTypeDescriptorId = source.AidTypeDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: Candidate

namespace EdFi.Ods.Entities.Common.TPDM //.CandidateAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CandidateMapper
    {
        private static readonly FullName _fullName_tpdm_Candidate = new FullName("tpdm", "Candidate");
    
        public static bool SynchronizeTo(this ICandidate source, ICandidate target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_Candidate);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CandidateIdentifier != target.CandidateIdentifier)
            {
                source.CandidateIdentifier = target.CandidateIdentifier;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsBirthCitySupported != false)
                && target.BirthCity != source.BirthCity)
            {
                target.BirthCity = source.BirthCity;
                isModified = true;
            }

            if ((mappingContract?.IsBirthCountryDescriptorSupported != false)
                && target.BirthCountryDescriptor != source.BirthCountryDescriptor)
            {
                target.BirthCountryDescriptor = source.BirthCountryDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsBirthDateSupported != false)
                && target.BirthDate != source.BirthDate)
            {
                target.BirthDate = source.BirthDate;
                isModified = true;
            }

            if ((mappingContract?.IsBirthInternationalProvinceSupported != false)
                && target.BirthInternationalProvince != source.BirthInternationalProvince)
            {
                target.BirthInternationalProvince = source.BirthInternationalProvince;
                isModified = true;
            }

            if ((mappingContract?.IsBirthSexDescriptorSupported != false)
                && target.BirthSexDescriptor != source.BirthSexDescriptor)
            {
                target.BirthSexDescriptor = source.BirthSexDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsBirthStateAbbreviationDescriptorSupported != false)
                && target.BirthStateAbbreviationDescriptor != source.BirthStateAbbreviationDescriptor)
            {
                target.BirthStateAbbreviationDescriptor = source.BirthStateAbbreviationDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsDateEnteredUSSupported != false)
                && target.DateEnteredUS != source.DateEnteredUS)
            {
                target.DateEnteredUS = source.DateEnteredUS;
                isModified = true;
            }

            if ((mappingContract?.IsDisplacementStatusSupported != false)
                && target.DisplacementStatus != source.DisplacementStatus)
            {
                target.DisplacementStatus = source.DisplacementStatus;
                isModified = true;
            }

            if ((mappingContract?.IsEconomicDisadvantagedSupported != false)
                && target.EconomicDisadvantaged != source.EconomicDisadvantaged)
            {
                target.EconomicDisadvantaged = source.EconomicDisadvantaged;
                isModified = true;
            }

            if ((mappingContract?.IsEnglishLanguageExamDescriptorSupported != false)
                && target.EnglishLanguageExamDescriptor != source.EnglishLanguageExamDescriptor)
            {
                target.EnglishLanguageExamDescriptor = source.EnglishLanguageExamDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsFirstGenerationStudentSupported != false)
                && target.FirstGenerationStudent != source.FirstGenerationStudent)
            {
                target.FirstGenerationStudent = source.FirstGenerationStudent;
                isModified = true;
            }

            if ((mappingContract?.IsFirstNameSupported != false)
                && target.FirstName != source.FirstName)
            {
                target.FirstName = source.FirstName;
                isModified = true;
            }

            if ((mappingContract?.IsGenderDescriptorSupported != false)
                && target.GenderDescriptor != source.GenderDescriptor)
            {
                target.GenderDescriptor = source.GenderDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsGenerationCodeSuffixSupported != false)
                && target.GenerationCodeSuffix != source.GenerationCodeSuffix)
            {
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
                isModified = true;
            }

            if ((mappingContract?.IsHispanicLatinoEthnicitySupported != false)
                && target.HispanicLatinoEthnicity != source.HispanicLatinoEthnicity)
            {
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
                isModified = true;
            }

            if ((mappingContract?.IsLastSurnameSupported != false)
                && target.LastSurname != source.LastSurname)
            {
                target.LastSurname = source.LastSurname;
                isModified = true;
            }

            if ((mappingContract?.IsLimitedEnglishProficiencyDescriptorSupported != false)
                && target.LimitedEnglishProficiencyDescriptor != source.LimitedEnglishProficiencyDescriptor)
            {
                target.LimitedEnglishProficiencyDescriptor = source.LimitedEnglishProficiencyDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsMaidenNameSupported != false)
                && target.MaidenName != source.MaidenName)
            {
                target.MaidenName = source.MaidenName;
                isModified = true;
            }

            if ((mappingContract?.IsMiddleNameSupported != false)
                && target.MiddleName != source.MiddleName)
            {
                target.MiddleName = source.MiddleName;
                isModified = true;
            }

            if ((mappingContract?.IsMultipleBirthStatusSupported != false)
                && target.MultipleBirthStatus != source.MultipleBirthStatus)
            {
                target.MultipleBirthStatus = source.MultipleBirthStatus;
                isModified = true;
            }

            if ((mappingContract?.IsPersonalTitlePrefixSupported != false)
                && target.PersonalTitlePrefix != source.PersonalTitlePrefix)
            {
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
                isModified = true;
            }

            if ((mappingContract?.IsPersonIdSupported != false)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((mappingContract?.IsSexDescriptorSupported != false)
                && target.SexDescriptor != source.SexDescriptor)
            {
                target.SexDescriptor = source.SexDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsSourceSystemDescriptorSupported != false)
                && target.SourceSystemDescriptor != source.SourceSystemDescriptor)
            {
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsCandidateAddressesSupported ?? true)
            {
                isModified |=
                    source.CandidateAddresses.SynchronizeCollectionTo(
                        target.CandidateAddresses,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateAddressIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateDisabilitiesSupported ?? true)
            {
                isModified |=
                    source.CandidateDisabilities.SynchronizeCollectionTo(
                        target.CandidateDisabilities,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateDisabilityIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateElectronicMailsSupported ?? true)
            {
                isModified |=
                    source.CandidateElectronicMails.SynchronizeCollectionTo(
                        target.CandidateElectronicMails,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateElectronicMailIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateLanguagesSupported ?? true)
            {
                isModified |=
                    source.CandidateLanguages.SynchronizeCollectionTo(
                        target.CandidateLanguages,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateLanguageIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateOtherNamesSupported ?? true)
            {
                isModified |=
                    source.CandidateOtherNames.SynchronizeCollectionTo(
                        target.CandidateOtherNames,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateOtherNameIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidatePersonalIdentificationDocumentsSupported ?? true)
            {
                isModified |=
                    source.CandidatePersonalIdentificationDocuments.SynchronizeCollectionTo(
                        target.CandidatePersonalIdentificationDocuments,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidatePersonalIdentificationDocumentIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateRacesSupported ?? true)
            {
                isModified |=
                    source.CandidateRaces.SynchronizeCollectionTo(
                        target.CandidateRaces,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateRaceIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateTelephonesSupported ?? true)
            {
                isModified |=
                    source.CandidateTelephones.SynchronizeCollectionTo(
                        target.CandidateTelephones,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateTelephoneIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICandidate source, ICandidate target, Action<ICandidate, ICandidate> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_Candidate);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CandidateIdentifier = source.CandidateIdentifier;

            // Copy non-PK properties

            if (mappingContract?.IsBirthCitySupported != false)
                target.BirthCity = source.BirthCity;

            if (mappingContract?.IsBirthCountryDescriptorSupported != false)
                target.BirthCountryDescriptor = source.BirthCountryDescriptor;

            if (mappingContract?.IsBirthDateSupported != false)
                target.BirthDate = source.BirthDate;

            if (mappingContract?.IsBirthInternationalProvinceSupported != false)
                target.BirthInternationalProvince = source.BirthInternationalProvince;

            if (mappingContract?.IsBirthSexDescriptorSupported != false)
                target.BirthSexDescriptor = source.BirthSexDescriptor;

            if (mappingContract?.IsBirthStateAbbreviationDescriptorSupported != false)
                target.BirthStateAbbreviationDescriptor = source.BirthStateAbbreviationDescriptor;

            if (mappingContract?.IsDateEnteredUSSupported != false)
                target.DateEnteredUS = source.DateEnteredUS;

            if (mappingContract?.IsDisplacementStatusSupported != false)
                target.DisplacementStatus = source.DisplacementStatus;

            if (mappingContract?.IsEconomicDisadvantagedSupported != false)
                target.EconomicDisadvantaged = source.EconomicDisadvantaged;

            if (mappingContract?.IsEnglishLanguageExamDescriptorSupported != false)
                target.EnglishLanguageExamDescriptor = source.EnglishLanguageExamDescriptor;

            if (mappingContract?.IsFirstGenerationStudentSupported != false)
                target.FirstGenerationStudent = source.FirstGenerationStudent;

            if (mappingContract?.IsFirstNameSupported != false)
                target.FirstName = source.FirstName;

            if (mappingContract?.IsGenderDescriptorSupported != false)
                target.GenderDescriptor = source.GenderDescriptor;

            if (mappingContract?.IsGenerationCodeSuffixSupported != false)
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;

            if (mappingContract?.IsHispanicLatinoEthnicitySupported != false)
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;

            if (mappingContract?.IsLastSurnameSupported != false)
                target.LastSurname = source.LastSurname;

            if (mappingContract?.IsLimitedEnglishProficiencyDescriptorSupported != false)
                target.LimitedEnglishProficiencyDescriptor = source.LimitedEnglishProficiencyDescriptor;

            if (mappingContract?.IsMaidenNameSupported != false)
                target.MaidenName = source.MaidenName;

            if (mappingContract?.IsMiddleNameSupported != false)
                target.MiddleName = source.MiddleName;

            if (mappingContract?.IsMultipleBirthStatusSupported != false)
                target.MultipleBirthStatus = source.MultipleBirthStatus;

            if (mappingContract?.IsPersonalTitlePrefixSupported != false)
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;

            if (mappingContract?.IsPersonIdSupported != false)
                target.PersonId = source.PersonId;

            if (mappingContract?.IsSexDescriptorSupported != false)
                target.SexDescriptor = source.SexDescriptor;

            if (mappingContract?.IsSourceSystemDescriptorSupported != false)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCandidateAddressesSupported != false)
            {
                source.CandidateAddresses.MapCollectionTo(target.CandidateAddresses, target, mappingContract?.IsCandidateAddressIncluded);
            }

            if (mappingContract?.IsCandidateDisabilitiesSupported != false)
            {
                source.CandidateDisabilities.MapCollectionTo(target.CandidateDisabilities, target, mappingContract?.IsCandidateDisabilityIncluded);
            }

            if (mappingContract?.IsCandidateElectronicMailsSupported != false)
            {
                source.CandidateElectronicMails.MapCollectionTo(target.CandidateElectronicMails, target, mappingContract?.IsCandidateElectronicMailIncluded);
            }

            if (mappingContract?.IsCandidateLanguagesSupported != false)
            {
                source.CandidateLanguages.MapCollectionTo(target.CandidateLanguages, target, mappingContract?.IsCandidateLanguageIncluded);
            }

            if (mappingContract?.IsCandidateOtherNamesSupported != false)
            {
                source.CandidateOtherNames.MapCollectionTo(target.CandidateOtherNames, target, mappingContract?.IsCandidateOtherNameIncluded);
            }

            if (mappingContract?.IsCandidatePersonalIdentificationDocumentsSupported != false)
            {
                source.CandidatePersonalIdentificationDocuments.MapCollectionTo(target.CandidatePersonalIdentificationDocuments, target, mappingContract?.IsCandidatePersonalIdentificationDocumentIncluded);
            }

            if (mappingContract?.IsCandidateRacesSupported != false)
            {
                source.CandidateRaces.MapCollectionTo(target.CandidateRaces, target, mappingContract?.IsCandidateRaceIncluded);
            }

            if (mappingContract?.IsCandidateTelephonesSupported != false)
            {
                source.CandidateTelephones.MapCollectionTo(target.CandidateTelephones, target, mappingContract?.IsCandidateTelephoneIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateAddressMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateAddress = new FullName("tpdm", "CandidateAddress");
    
        public static bool SynchronizeTo(this ICandidateAddress source, ICandidateAddress target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateAddress);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AddressTypeDescriptor != target.AddressTypeDescriptor)
            {
                source.AddressTypeDescriptor = target.AddressTypeDescriptor;
            }
            if (source.City != target.City)
            {
                source.City = target.City;
            }
            if (source.PostalCode != target.PostalCode)
            {
                source.PostalCode = target.PostalCode;
            }
            if (source.StateAbbreviationDescriptor != target.StateAbbreviationDescriptor)
            {
                source.StateAbbreviationDescriptor = target.StateAbbreviationDescriptor;
            }
            if (source.StreetNumberName != target.StreetNumberName)
            {
                source.StreetNumberName = target.StreetNumberName;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsApartmentRoomSuiteNumberSupported != false)
                && target.ApartmentRoomSuiteNumber != source.ApartmentRoomSuiteNumber)
            {
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
                isModified = true;
            }

            if ((mappingContract?.IsBuildingSiteNumberSupported != false)
                && target.BuildingSiteNumber != source.BuildingSiteNumber)
            {
                target.BuildingSiteNumber = source.BuildingSiteNumber;
                isModified = true;
            }

            if ((mappingContract?.IsCongressionalDistrictSupported != false)
                && target.CongressionalDistrict != source.CongressionalDistrict)
            {
                target.CongressionalDistrict = source.CongressionalDistrict;
                isModified = true;
            }

            if ((mappingContract?.IsCountyFIPSCodeSupported != false)
                && target.CountyFIPSCode != source.CountyFIPSCode)
            {
                target.CountyFIPSCode = source.CountyFIPSCode;
                isModified = true;
            }

            if ((mappingContract?.IsDoNotPublishIndicatorSupported != false)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsLatitudeSupported != false)
                && target.Latitude != source.Latitude)
            {
                target.Latitude = source.Latitude;
                isModified = true;
            }

            if ((mappingContract?.IsLocaleDescriptorSupported != false)
                && target.LocaleDescriptor != source.LocaleDescriptor)
            {
                target.LocaleDescriptor = source.LocaleDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsLongitudeSupported != false)
                && target.Longitude != source.Longitude)
            {
                target.Longitude = source.Longitude;
                isModified = true;
            }

            if ((mappingContract?.IsNameOfCountySupported != false)
                && target.NameOfCounty != source.NameOfCounty)
            {
                target.NameOfCounty = source.NameOfCounty;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsCandidateAddressPeriodsSupported ?? true)
            {
                isModified |=
                    source.CandidateAddressPeriods.SynchronizeCollectionTo(
                        target.CandidateAddressPeriods,
                        onChildAdded: child =>
                            {
                                child.CandidateAddress = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateAddressPeriodIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateAddress source, ICandidateAddress target, Action<ICandidateAddress, ICandidateAddress> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateAddressMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateAddress);
    
            // Copy contextual primary key values
            target.AddressTypeDescriptor = source.AddressTypeDescriptor;
            target.City = source.City;
            target.PostalCode = source.PostalCode;
            target.StateAbbreviationDescriptor = source.StateAbbreviationDescriptor;
            target.StreetNumberName = source.StreetNumberName;

            // Copy non-PK properties

            if (mappingContract?.IsApartmentRoomSuiteNumberSupported != false)
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;

            if (mappingContract?.IsBuildingSiteNumberSupported != false)
                target.BuildingSiteNumber = source.BuildingSiteNumber;

            if (mappingContract?.IsCongressionalDistrictSupported != false)
                target.CongressionalDistrict = source.CongressionalDistrict;

            if (mappingContract?.IsCountyFIPSCodeSupported != false)
                target.CountyFIPSCode = source.CountyFIPSCode;

            if (mappingContract?.IsDoNotPublishIndicatorSupported != false)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;

            if (mappingContract?.IsLatitudeSupported != false)
                target.Latitude = source.Latitude;

            if (mappingContract?.IsLocaleDescriptorSupported != false)
                target.LocaleDescriptor = source.LocaleDescriptor;

            if (mappingContract?.IsLongitudeSupported != false)
                target.Longitude = source.Longitude;

            if (mappingContract?.IsNameOfCountySupported != false)
                target.NameOfCounty = source.NameOfCounty;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCandidateAddressPeriodsSupported != false)
            {
                source.CandidateAddressPeriods.MapCollectionTo(target.CandidateAddressPeriods, target, mappingContract?.IsCandidateAddressPeriodIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateAddressPeriodMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateAddressPeriod = new FullName("tpdm", "CandidateAddressPeriod");
    
        public static bool SynchronizeTo(this ICandidateAddressPeriod source, ICandidateAddressPeriod target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateAddressPeriodMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateAddressPeriod);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateAddressPeriod source, ICandidateAddressPeriod target, Action<ICandidateAddressPeriod, ICandidateAddressPeriod> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateAddressPeriodMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateAddressPeriod);
    
            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;

            // Copy non-PK properties

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateDisabilityMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateDisability = new FullName("tpdm", "CandidateDisability");
    
        public static bool SynchronizeTo(this ICandidateDisability source, ICandidateDisability target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateDisabilityMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateDisability);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DisabilityDescriptor != target.DisabilityDescriptor)
            {
                source.DisabilityDescriptor = target.DisabilityDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsDisabilityDeterminationSourceTypeDescriptorSupported != false)
                && target.DisabilityDeterminationSourceTypeDescriptor != source.DisabilityDeterminationSourceTypeDescriptor)
            {
                target.DisabilityDeterminationSourceTypeDescriptor = source.DisabilityDeterminationSourceTypeDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsDisabilityDiagnosisSupported != false)
                && target.DisabilityDiagnosis != source.DisabilityDiagnosis)
            {
                target.DisabilityDiagnosis = source.DisabilityDiagnosis;
                isModified = true;
            }

            if ((mappingContract?.IsOrderOfDisabilitySupported != false)
                && target.OrderOfDisability != source.OrderOfDisability)
            {
                target.OrderOfDisability = source.OrderOfDisability;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsCandidateDisabilityDesignationsSupported ?? true)
            {
                isModified |=
                    source.CandidateDisabilityDesignations.SynchronizeCollectionTo(
                        target.CandidateDisabilityDesignations,
                        onChildAdded: child =>
                            {
                                child.CandidateDisability = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateDisabilityDesignationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateDisability source, ICandidateDisability target, Action<ICandidateDisability, ICandidateDisability> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateDisabilityMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateDisability);
    
            // Copy contextual primary key values
            target.DisabilityDescriptor = source.DisabilityDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsDisabilityDeterminationSourceTypeDescriptorSupported != false)
                target.DisabilityDeterminationSourceTypeDescriptor = source.DisabilityDeterminationSourceTypeDescriptor;

            if (mappingContract?.IsDisabilityDiagnosisSupported != false)
                target.DisabilityDiagnosis = source.DisabilityDiagnosis;

            if (mappingContract?.IsOrderOfDisabilitySupported != false)
                target.OrderOfDisability = source.OrderOfDisability;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCandidateDisabilityDesignationsSupported != false)
            {
                source.CandidateDisabilityDesignations.MapCollectionTo(target.CandidateDisabilityDesignations, target, mappingContract?.IsCandidateDisabilityDesignationIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateDisabilityDesignationMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateDisabilityDesignation = new FullName("tpdm", "CandidateDisabilityDesignation");
    
        public static bool SynchronizeTo(this ICandidateDisabilityDesignation source, ICandidateDisabilityDesignation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateDisabilityDesignationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateDisabilityDesignation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DisabilityDesignationDescriptor != target.DisabilityDesignationDescriptor)
            {
                source.DisabilityDesignationDescriptor = target.DisabilityDesignationDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateDisabilityDesignation source, ICandidateDisabilityDesignation target, Action<ICandidateDisabilityDesignation, ICandidateDisabilityDesignation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateDisabilityDesignationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateDisabilityDesignation);
    
            // Copy contextual primary key values
            target.DisabilityDesignationDescriptor = source.DisabilityDesignationDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateElectronicMailMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateElectronicMail = new FullName("tpdm", "CandidateElectronicMail");
    
        public static bool SynchronizeTo(this ICandidateElectronicMail source, ICandidateElectronicMail target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateElectronicMailMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateElectronicMail);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ElectronicMailAddress != target.ElectronicMailAddress)
            {
                source.ElectronicMailAddress = target.ElectronicMailAddress;
            }
            if (source.ElectronicMailTypeDescriptor != target.ElectronicMailTypeDescriptor)
            {
                source.ElectronicMailTypeDescriptor = target.ElectronicMailTypeDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsDoNotPublishIndicatorSupported != false)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsPrimaryEmailAddressIndicatorSupported != false)
                && target.PrimaryEmailAddressIndicator != source.PrimaryEmailAddressIndicator)
            {
                target.PrimaryEmailAddressIndicator = source.PrimaryEmailAddressIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateElectronicMail source, ICandidateElectronicMail target, Action<ICandidateElectronicMail, ICandidateElectronicMail> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateElectronicMailMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateElectronicMail);
    
            // Copy contextual primary key values
            target.ElectronicMailAddress = source.ElectronicMailAddress;
            target.ElectronicMailTypeDescriptor = source.ElectronicMailTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsDoNotPublishIndicatorSupported != false)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;

            if (mappingContract?.IsPrimaryEmailAddressIndicatorSupported != false)
                target.PrimaryEmailAddressIndicator = source.PrimaryEmailAddressIndicator;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateLanguageMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateLanguage = new FullName("tpdm", "CandidateLanguage");
    
        public static bool SynchronizeTo(this ICandidateLanguage source, ICandidateLanguage target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateLanguageMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateLanguage);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.LanguageDescriptor != target.LanguageDescriptor)
            {
                source.LanguageDescriptor = target.LanguageDescriptor;
            }

            // Copy non-PK properties


            // Sync lists
            if (mappingContract?.IsCandidateLanguageUsesSupported ?? true)
            {
                isModified |=
                    source.CandidateLanguageUses.SynchronizeCollectionTo(
                        target.CandidateLanguageUses,
                        onChildAdded: child =>
                            {
                                child.CandidateLanguage = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateLanguageUseIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateLanguage source, ICandidateLanguage target, Action<ICandidateLanguage, ICandidateLanguage> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateLanguageMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateLanguage);
    
            // Copy contextual primary key values
            target.LanguageDescriptor = source.LanguageDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCandidateLanguageUsesSupported != false)
            {
                source.CandidateLanguageUses.MapCollectionTo(target.CandidateLanguageUses, target, mappingContract?.IsCandidateLanguageUseIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateLanguageUseMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateLanguageUse = new FullName("tpdm", "CandidateLanguageUse");
    
        public static bool SynchronizeTo(this ICandidateLanguageUse source, ICandidateLanguageUse target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateLanguageUseMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateLanguageUse);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.LanguageUseDescriptor != target.LanguageUseDescriptor)
            {
                source.LanguageUseDescriptor = target.LanguageUseDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateLanguageUse source, ICandidateLanguageUse target, Action<ICandidateLanguageUse, ICandidateLanguageUse> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateLanguageUseMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateLanguageUse);
    
            // Copy contextual primary key values
            target.LanguageUseDescriptor = source.LanguageUseDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateOtherNameMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateOtherName = new FullName("tpdm", "CandidateOtherName");
    
        public static bool SynchronizeTo(this ICandidateOtherName source, ICandidateOtherName target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateOtherNameMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateOtherName);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.OtherNameTypeDescriptor != target.OtherNameTypeDescriptor)
            {
                source.OtherNameTypeDescriptor = target.OtherNameTypeDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsFirstNameSupported != false)
                && target.FirstName != source.FirstName)
            {
                target.FirstName = source.FirstName;
                isModified = true;
            }

            if ((mappingContract?.IsGenerationCodeSuffixSupported != false)
                && target.GenerationCodeSuffix != source.GenerationCodeSuffix)
            {
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
                isModified = true;
            }

            if ((mappingContract?.IsLastSurnameSupported != false)
                && target.LastSurname != source.LastSurname)
            {
                target.LastSurname = source.LastSurname;
                isModified = true;
            }

            if ((mappingContract?.IsMiddleNameSupported != false)
                && target.MiddleName != source.MiddleName)
            {
                target.MiddleName = source.MiddleName;
                isModified = true;
            }

            if ((mappingContract?.IsPersonalTitlePrefixSupported != false)
                && target.PersonalTitlePrefix != source.PersonalTitlePrefix)
            {
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateOtherName source, ICandidateOtherName target, Action<ICandidateOtherName, ICandidateOtherName> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateOtherNameMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateOtherName);
    
            // Copy contextual primary key values
            target.OtherNameTypeDescriptor = source.OtherNameTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsFirstNameSupported != false)
                target.FirstName = source.FirstName;

            if (mappingContract?.IsGenerationCodeSuffixSupported != false)
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;

            if (mappingContract?.IsLastSurnameSupported != false)
                target.LastSurname = source.LastSurname;

            if (mappingContract?.IsMiddleNameSupported != false)
                target.MiddleName = source.MiddleName;

            if (mappingContract?.IsPersonalTitlePrefixSupported != false)
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidatePersonalIdentificationDocumentMapper
    {
        private static readonly FullName _fullName_tpdm_CandidatePersonalIdentificationDocument = new FullName("tpdm", "CandidatePersonalIdentificationDocument");
    
        public static bool SynchronizeTo(this ICandidatePersonalIdentificationDocument source, ICandidatePersonalIdentificationDocument target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidatePersonalIdentificationDocumentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidatePersonalIdentificationDocument);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.IdentificationDocumentUseDescriptor != target.IdentificationDocumentUseDescriptor)
            {
                source.IdentificationDocumentUseDescriptor = target.IdentificationDocumentUseDescriptor;
            }
            if (source.PersonalInformationVerificationDescriptor != target.PersonalInformationVerificationDescriptor)
            {
                source.PersonalInformationVerificationDescriptor = target.PersonalInformationVerificationDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsDocumentExpirationDateSupported != false)
                && target.DocumentExpirationDate != source.DocumentExpirationDate)
            {
                target.DocumentExpirationDate = source.DocumentExpirationDate;
                isModified = true;
            }

            if ((mappingContract?.IsDocumentTitleSupported != false)
                && target.DocumentTitle != source.DocumentTitle)
            {
                target.DocumentTitle = source.DocumentTitle;
                isModified = true;
            }

            if ((mappingContract?.IsIssuerCountryDescriptorSupported != false)
                && target.IssuerCountryDescriptor != source.IssuerCountryDescriptor)
            {
                target.IssuerCountryDescriptor = source.IssuerCountryDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsIssuerDocumentIdentificationCodeSupported != false)
                && target.IssuerDocumentIdentificationCode != source.IssuerDocumentIdentificationCode)
            {
                target.IssuerDocumentIdentificationCode = source.IssuerDocumentIdentificationCode;
                isModified = true;
            }

            if ((mappingContract?.IsIssuerNameSupported != false)
                && target.IssuerName != source.IssuerName)
            {
                target.IssuerName = source.IssuerName;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidatePersonalIdentificationDocument source, ICandidatePersonalIdentificationDocument target, Action<ICandidatePersonalIdentificationDocument, ICandidatePersonalIdentificationDocument> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidatePersonalIdentificationDocumentMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidatePersonalIdentificationDocument);
    
            // Copy contextual primary key values
            target.IdentificationDocumentUseDescriptor = source.IdentificationDocumentUseDescriptor;
            target.PersonalInformationVerificationDescriptor = source.PersonalInformationVerificationDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsDocumentExpirationDateSupported != false)
                target.DocumentExpirationDate = source.DocumentExpirationDate;

            if (mappingContract?.IsDocumentTitleSupported != false)
                target.DocumentTitle = source.DocumentTitle;

            if (mappingContract?.IsIssuerCountryDescriptorSupported != false)
                target.IssuerCountryDescriptor = source.IssuerCountryDescriptor;

            if (mappingContract?.IsIssuerDocumentIdentificationCodeSupported != false)
                target.IssuerDocumentIdentificationCode = source.IssuerDocumentIdentificationCode;

            if (mappingContract?.IsIssuerNameSupported != false)
                target.IssuerName = source.IssuerName;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateRaceMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateRace = new FullName("tpdm", "CandidateRace");
    
        public static bool SynchronizeTo(this ICandidateRace source, ICandidateRace target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateRaceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateRace);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.RaceDescriptor != target.RaceDescriptor)
            {
                source.RaceDescriptor = target.RaceDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateRace source, ICandidateRace target, Action<ICandidateRace, ICandidateRace> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateRaceMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateRace);
    
            // Copy contextual primary key values
            target.RaceDescriptor = source.RaceDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateTelephoneMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateTelephone = new FullName("tpdm", "CandidateTelephone");
    
        public static bool SynchronizeTo(this ICandidateTelephone source, ICandidateTelephone target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateTelephone);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.TelephoneNumber != target.TelephoneNumber)
            {
                source.TelephoneNumber = target.TelephoneNumber;
            }
            if (source.TelephoneNumberTypeDescriptor != target.TelephoneNumberTypeDescriptor)
            {
                source.TelephoneNumberTypeDescriptor = target.TelephoneNumberTypeDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsDoNotPublishIndicatorSupported != false)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsOrderOfPrioritySupported != false)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
                && target.TextMessageCapabilityIndicator != source.TextMessageCapabilityIndicator)
            {
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateTelephone source, ICandidateTelephone target, Action<ICandidateTelephone, ICandidateTelephone> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateTelephoneMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateTelephone);
    
            // Copy contextual primary key values
            target.TelephoneNumber = source.TelephoneNumber;
            target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsDoNotPublishIndicatorSupported != false)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;

            if (mappingContract?.IsOrderOfPrioritySupported != false)
                target.OrderOfPriority = source.OrderOfPriority;

            if (mappingContract?.IsTextMessageCapabilityIndicatorSupported != false)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: CandidateEducatorPreparationProgramAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.CandidateEducatorPreparationProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateEducatorPreparationProgramAssociation = new FullName("tpdm", "CandidateEducatorPreparationProgramAssociation");
    
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociation source, ICandidateEducatorPreparationProgramAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateEducatorPreparationProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }
            if (source.CandidateIdentifier != target.CandidateIdentifier)
            {
                source.CandidateIdentifier = target.CandidateIdentifier;
            }
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.ProgramName != target.ProgramName)
            {
                source.ProgramName = target.ProgramName;
            }
            if (source.ProgramTypeDescriptor != target.ProgramTypeDescriptor)
            {
                source.ProgramTypeDescriptor = target.ProgramTypeDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((mappingContract?.IsEPPProgramPathwayDescriptorSupported != false)
                && target.EPPProgramPathwayDescriptor != source.EPPProgramPathwayDescriptor)
            {
                target.EPPProgramPathwayDescriptor = source.EPPProgramPathwayDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsReasonExitedDescriptorSupported != false)
                && target.ReasonExitedDescriptor != source.ReasonExitedDescriptor)
            {
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported ?? true)
            {
                isModified |=
                    source.CandidateEducatorPreparationProgramAssociationCohortYears.SynchronizeCollectionTo(
                        target.CandidateEducatorPreparationProgramAssociationCohortYears,
                        onChildAdded: child =>
                            {
                                child.CandidateEducatorPreparationProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported ?? true)
            {
                isModified |=
                    source.CandidateEducatorPreparationProgramAssociationDegreeSpecializations.SynchronizeCollectionTo(
                        target.CandidateEducatorPreparationProgramAssociationDegreeSpecializations,
                        onChildAdded: child =>
                            {
                                child.CandidateEducatorPreparationProgramAssociation = target;
                            },
                        includeItem: item => mappingContract?.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateEducatorPreparationProgramAssociation source, ICandidateEducatorPreparationProgramAssociation target, Action<ICandidateEducatorPreparationProgramAssociation, ICandidateEducatorPreparationProgramAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateEducatorPreparationProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;
            target.CandidateIdentifier = source.CandidateIdentifier;
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsEPPProgramPathwayDescriptorSupported != false)
                target.EPPProgramPathwayDescriptor = source.EPPProgramPathwayDescriptor;

            if (mappingContract?.IsReasonExitedDescriptorSupported != false)
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.CandidateResourceId = source.CandidateResourceId;
                target.CandidateDiscriminator = source.CandidateDiscriminator;
                target.EducatorPreparationProgramResourceId = source.EducatorPreparationProgramResourceId;
                target.EducatorPreparationProgramDiscriminator = source.EducatorPreparationProgramDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported != false)
            {
                source.CandidateEducatorPreparationProgramAssociationCohortYears.MapCollectionTo(target.CandidateEducatorPreparationProgramAssociationCohortYears, target, mappingContract?.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded);
            }

            if (mappingContract?.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported != false)
            {
                source.CandidateEducatorPreparationProgramAssociationDegreeSpecializations.MapCollectionTo(target.CandidateEducatorPreparationProgramAssociationDegreeSpecializations, target, mappingContract?.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationCohortYearMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateEducatorPreparationProgramAssociationCohortYear = new FullName("tpdm", "CandidateEducatorPreparationProgramAssociationCohortYear");
    
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociationCohortYear source, ICandidateEducatorPreparationProgramAssociationCohortYear target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateEducatorPreparationProgramAssociationCohortYearMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociationCohortYear);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CohortYearTypeDescriptor != target.CohortYearTypeDescriptor)
            {
                source.CohortYearTypeDescriptor = target.CohortYearTypeDescriptor;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsTermDescriptorSupported != false)
                && target.TermDescriptor != source.TermDescriptor)
            {
                target.TermDescriptor = source.TermDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateEducatorPreparationProgramAssociationCohortYear source, ICandidateEducatorPreparationProgramAssociationCohortYear target, Action<ICandidateEducatorPreparationProgramAssociationCohortYear, ICandidateEducatorPreparationProgramAssociationCohortYear> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateEducatorPreparationProgramAssociationCohortYearMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociationCohortYear);
    
            // Copy contextual primary key values
            target.CohortYearTypeDescriptor = source.CohortYearTypeDescriptor;
            target.SchoolYear = source.SchoolYear;

            // Copy non-PK properties

            if (mappingContract?.IsTermDescriptorSupported != false)
                target.TermDescriptor = source.TermDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.SchoolYearTypeResourceId = source.SchoolYearTypeResourceId;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationDegreeSpecializationMapper
    {
        private static readonly FullName _fullName_tpdm_CandidateEducatorPreparationProgramAssociationDegreeSpecialization = new FullName("tpdm", "CandidateEducatorPreparationProgramAssociationDegreeSpecialization");
    
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociationDegreeSpecialization source, ICandidateEducatorPreparationProgramAssociationDegreeSpecialization target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CandidateEducatorPreparationProgramAssociationDegreeSpecializationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociationDegreeSpecialization);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.MajorSpecialization != target.MajorSpecialization)
            {
                source.MajorSpecialization = target.MajorSpecialization;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((mappingContract?.IsMinorSpecializationSupported != false)
                && target.MinorSpecialization != source.MinorSpecialization)
            {
                target.MinorSpecialization = source.MinorSpecialization;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICandidateEducatorPreparationProgramAssociationDegreeSpecialization source, ICandidateEducatorPreparationProgramAssociationDegreeSpecialization target, Action<ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, ICandidateEducatorPreparationProgramAssociationDegreeSpecialization> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CandidateEducatorPreparationProgramAssociationDegreeSpecializationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CandidateEducatorPreparationProgramAssociationDegreeSpecialization);
    
            // Copy contextual primary key values
            target.MajorSpecialization = source.MajorSpecialization;

            // Copy non-PK properties

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsMinorSpecializationSupported != false)
                target.MinorSpecialization = source.MinorSpecialization;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: CertificationRouteDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CertificationRouteDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CertificationRouteDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_CertificationRouteDescriptor = new FullName("tpdm", "CertificationRouteDescriptor");
    
        public static bool SynchronizeTo(this ICertificationRouteDescriptor source, ICertificationRouteDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CertificationRouteDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CertificationRouteDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CertificationRouteDescriptorId != target.CertificationRouteDescriptorId)
            {
                source.CertificationRouteDescriptorId = target.CertificationRouteDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICertificationRouteDescriptor source, ICertificationRouteDescriptor target, Action<ICertificationRouteDescriptor, ICertificationRouteDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CertificationRouteDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CertificationRouteDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CertificationRouteDescriptorId = source.CertificationRouteDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: CoteachingStyleObservedDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CoteachingStyleObservedDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CoteachingStyleObservedDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_CoteachingStyleObservedDescriptor = new FullName("tpdm", "CoteachingStyleObservedDescriptor");
    
        public static bool SynchronizeTo(this ICoteachingStyleObservedDescriptor source, ICoteachingStyleObservedDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CoteachingStyleObservedDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CoteachingStyleObservedDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CoteachingStyleObservedDescriptorId != target.CoteachingStyleObservedDescriptorId)
            {
                source.CoteachingStyleObservedDescriptorId = target.CoteachingStyleObservedDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICoteachingStyleObservedDescriptor source, ICoteachingStyleObservedDescriptor target, Action<ICoteachingStyleObservedDescriptor, ICoteachingStyleObservedDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CoteachingStyleObservedDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CoteachingStyleObservedDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CoteachingStyleObservedDescriptorId = source.CoteachingStyleObservedDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: Credential

namespace EdFi.Ods.Entities.Common.TPDM //.CredentialAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CredentialExtensionMapper
    {
        private static readonly FullName _fullName_tpdm_CredentialExtension = new FullName("tpdm", "CredentialExtension");
    
        public static bool SynchronizeTo(this ICredentialExtension source, ICredentialExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CredentialExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialExtension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsBoardCertificationIndicatorSupported != false)
                && target.BoardCertificationIndicator != source.BoardCertificationIndicator)
            {
                target.BoardCertificationIndicator = source.BoardCertificationIndicator;
                isModified = true;
            }

            if ((mappingContract?.IsCertificationRouteDescriptorSupported != false)
                && target.CertificationRouteDescriptor != source.CertificationRouteDescriptor)
            {
                target.CertificationRouteDescriptor = source.CertificationRouteDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsCertificationTitleSupported != false)
                && target.CertificationTitle != source.CertificationTitle)
            {
                target.CertificationTitle = source.CertificationTitle;
                isModified = true;
            }

            if ((mappingContract?.IsCredentialStatusDateSupported != false)
                && target.CredentialStatusDate != source.CredentialStatusDate)
            {
                target.CredentialStatusDate = source.CredentialStatusDate;
                isModified = true;
            }

            if ((mappingContract?.IsCredentialStatusDescriptorSupported != false)
                && target.CredentialStatusDescriptor != source.CredentialStatusDescriptor)
            {
                target.CredentialStatusDescriptor = source.CredentialStatusDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsEducatorRoleDescriptorSupported != false)
                && target.EducatorRoleDescriptor != source.EducatorRoleDescriptor)
            {
                target.EducatorRoleDescriptor = source.EducatorRoleDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsPersonIdSupported != false)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((mappingContract?.IsSourceSystemDescriptorSupported != false)
                && target.SourceSystemDescriptor != source.SourceSystemDescriptor)
            {
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsCredentialStudentAcademicRecordsSupported ?? true)
            {
                isModified |=
                    source.CredentialStudentAcademicRecords.SynchronizeCollectionTo(
                        target.CredentialStudentAcademicRecords,
                        onChildAdded: child =>
                            {
                                child.CredentialExtension = target;

                                // Extension class "children" need to reference the Ed-Fi Standard entity as the parent
                                (child as IChildEntity)?.SetParent(target.Credential);
                            },
                        includeItem: item => mappingContract?.IsCredentialStudentAcademicRecordIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this ICredentialExtension source, ICredentialExtension target, Action<ICredentialExtension, ICredentialExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CredentialExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsBoardCertificationIndicatorSupported != false)
                target.BoardCertificationIndicator = source.BoardCertificationIndicator;

            if (mappingContract?.IsCertificationRouteDescriptorSupported != false)
                target.CertificationRouteDescriptor = source.CertificationRouteDescriptor;

            if (mappingContract?.IsCertificationTitleSupported != false)
                target.CertificationTitle = source.CertificationTitle;

            if (mappingContract?.IsCredentialStatusDateSupported != false)
                target.CredentialStatusDate = source.CredentialStatusDate;

            if (mappingContract?.IsCredentialStatusDescriptorSupported != false)
                target.CredentialStatusDescriptor = source.CredentialStatusDescriptor;

            if (mappingContract?.IsEducatorRoleDescriptorSupported != false)
                target.EducatorRoleDescriptor = source.EducatorRoleDescriptor;

            if (mappingContract?.IsPersonIdSupported != false)
                target.PersonId = source.PersonId;

            if (mappingContract?.IsSourceSystemDescriptorSupported != false)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsCredentialStudentAcademicRecordsSupported != false)
            {
                source.CredentialStudentAcademicRecords.MapCollectionTo(target.CredentialStudentAcademicRecords, target.Credential, mappingContract?.IsCredentialStudentAcademicRecordIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class CredentialStudentAcademicRecordMapper
    {
        private static readonly FullName _fullName_tpdm_CredentialStudentAcademicRecord = new FullName("tpdm", "CredentialStudentAcademicRecord");
    
        public static bool SynchronizeTo(this ICredentialStudentAcademicRecord source, ICredentialStudentAcademicRecord target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CredentialStudentAcademicRecordMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialStudentAcademicRecord);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICredentialStudentAcademicRecord source, ICredentialStudentAcademicRecord target, Action<ICredentialStudentAcademicRecord, ICredentialStudentAcademicRecord> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CredentialStudentAcademicRecordMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialStudentAcademicRecord);
    
            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.SchoolYear = source.SchoolYear;
            target.StudentUniqueId = source.StudentUniqueId;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentAcademicRecordResourceId = source.StudentAcademicRecordResourceId;
                target.StudentAcademicRecordDiscriminator = source.StudentAcademicRecordDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: CredentialStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CredentialStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CredentialStatusDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_CredentialStatusDescriptor = new FullName("tpdm", "CredentialStatusDescriptor");
    
        public static bool SynchronizeTo(this ICredentialStatusDescriptor source, ICredentialStatusDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (CredentialStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialStatusDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CredentialStatusDescriptorId != target.CredentialStatusDescriptorId)
            {
                source.CredentialStatusDescriptorId = target.CredentialStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this ICredentialStatusDescriptor source, ICredentialStatusDescriptor target, Action<ICredentialStatusDescriptor, ICredentialStatusDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (CredentialStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_CredentialStatusDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CredentialStatusDescriptorId = source.CredentialStatusDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EducatorPreparationProgram

namespace EdFi.Ods.Entities.Common.TPDM //.EducatorPreparationProgramAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EducatorPreparationProgramMapper
    {
        private static readonly FullName _fullName_tpdm_EducatorPreparationProgram = new FullName("tpdm", "EducatorPreparationProgram");
    
        public static bool SynchronizeTo(this IEducatorPreparationProgram source, IEducatorPreparationProgram target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EducatorPreparationProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorPreparationProgram);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.ProgramName != target.ProgramName)
            {
                source.ProgramName = target.ProgramName;
            }
            if (source.ProgramTypeDescriptor != target.ProgramTypeDescriptor)
            {
                source.ProgramTypeDescriptor = target.ProgramTypeDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAccreditationStatusDescriptorSupported != false)
                && target.AccreditationStatusDescriptor != source.AccreditationStatusDescriptor)
            {
                target.AccreditationStatusDescriptor = source.AccreditationStatusDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsProgramIdSupported != false)
                && target.ProgramId != source.ProgramId)
            {
                target.ProgramId = source.ProgramId;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEducatorPreparationProgramGradeLevelsSupported ?? true)
            {
                isModified |=
                    source.EducatorPreparationProgramGradeLevels.SynchronizeCollectionTo(
                        target.EducatorPreparationProgramGradeLevels,
                        onChildAdded: child =>
                            {
                                child.EducatorPreparationProgram = target;
                            },
                        includeItem: item => mappingContract?.IsEducatorPreparationProgramGradeLevelIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEducatorPreparationProgram source, IEducatorPreparationProgram target, Action<IEducatorPreparationProgram, IEducatorPreparationProgram> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EducatorPreparationProgramMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorPreparationProgram);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsAccreditationStatusDescriptorSupported != false)
                target.AccreditationStatusDescriptor = source.AccreditationStatusDescriptor;

            if (mappingContract?.IsProgramIdSupported != false)
                target.ProgramId = source.ProgramId;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EducationOrganizationResourceId = source.EducationOrganizationResourceId;
                target.EducationOrganizationDiscriminator = source.EducationOrganizationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEducatorPreparationProgramGradeLevelsSupported != false)
            {
                source.EducatorPreparationProgramGradeLevels.MapCollectionTo(target.EducatorPreparationProgramGradeLevels, target, mappingContract?.IsEducatorPreparationProgramGradeLevelIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EducatorPreparationProgramGradeLevelMapper
    {
        private static readonly FullName _fullName_tpdm_EducatorPreparationProgramGradeLevel = new FullName("tpdm", "EducatorPreparationProgramGradeLevel");
    
        public static bool SynchronizeTo(this IEducatorPreparationProgramGradeLevel source, IEducatorPreparationProgramGradeLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EducatorPreparationProgramGradeLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorPreparationProgramGradeLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.GradeLevelDescriptor != target.GradeLevelDescriptor)
            {
                source.GradeLevelDescriptor = target.GradeLevelDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEducatorPreparationProgramGradeLevel source, IEducatorPreparationProgramGradeLevel target, Action<IEducatorPreparationProgramGradeLevel, IEducatorPreparationProgramGradeLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EducatorPreparationProgramGradeLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorPreparationProgramGradeLevel);
    
            // Copy contextual primary key values
            target.GradeLevelDescriptor = source.GradeLevelDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EducatorRoleDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EducatorRoleDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EducatorRoleDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EducatorRoleDescriptor = new FullName("tpdm", "EducatorRoleDescriptor");
    
        public static bool SynchronizeTo(this IEducatorRoleDescriptor source, IEducatorRoleDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EducatorRoleDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorRoleDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducatorRoleDescriptorId != target.EducatorRoleDescriptorId)
            {
                source.EducatorRoleDescriptorId = target.EducatorRoleDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEducatorRoleDescriptor source, IEducatorRoleDescriptor target, Action<IEducatorRoleDescriptor, IEducatorRoleDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EducatorRoleDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EducatorRoleDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducatorRoleDescriptorId = source.EducatorRoleDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EnglishLanguageExamDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EnglishLanguageExamDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EnglishLanguageExamDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EnglishLanguageExamDescriptor = new FullName("tpdm", "EnglishLanguageExamDescriptor");
    
        public static bool SynchronizeTo(this IEnglishLanguageExamDescriptor source, IEnglishLanguageExamDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EnglishLanguageExamDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EnglishLanguageExamDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EnglishLanguageExamDescriptorId != target.EnglishLanguageExamDescriptorId)
            {
                source.EnglishLanguageExamDescriptorId = target.EnglishLanguageExamDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEnglishLanguageExamDescriptor source, IEnglishLanguageExamDescriptor target, Action<IEnglishLanguageExamDescriptor, IEnglishLanguageExamDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EnglishLanguageExamDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EnglishLanguageExamDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EnglishLanguageExamDescriptorId = source.EnglishLanguageExamDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EPPProgramPathwayDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EPPProgramPathwayDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EPPProgramPathwayDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EPPProgramPathwayDescriptor = new FullName("tpdm", "EPPProgramPathwayDescriptor");
    
        public static bool SynchronizeTo(this IEPPProgramPathwayDescriptor source, IEPPProgramPathwayDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EPPProgramPathwayDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EPPProgramPathwayDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EPPProgramPathwayDescriptorId != target.EPPProgramPathwayDescriptorId)
            {
                source.EPPProgramPathwayDescriptorId = target.EPPProgramPathwayDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEPPProgramPathwayDescriptor source, IEPPProgramPathwayDescriptor target, Action<IEPPProgramPathwayDescriptor, IEPPProgramPathwayDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EPPProgramPathwayDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EPPProgramPathwayDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EPPProgramPathwayDescriptorId = source.EPPProgramPathwayDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: Evaluation

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationMapper
    {
        private static readonly FullName _fullName_tpdm_Evaluation = new FullName("tpdm", "Evaluation");
    
        public static bool SynchronizeTo(this IEvaluation source, IEvaluation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_Evaluation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEvaluationDescriptionSupported != false)
                && target.EvaluationDescription != source.EvaluationDescription)
            {
                target.EvaluationDescription = source.EvaluationDescription;
                isModified = true;
            }

            if ((mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationRatingLevelsSupported ?? true)
            {
                isModified |=
                    source.EvaluationRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationRatingLevels,
                        onChildAdded: child =>
                            {
                                child.Evaluation = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationRatingLevelIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluation source, IEvaluation target, Action<IEvaluation, IEvaluation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_Evaluation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.SchoolYear = source.SchoolYear;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsEvaluationDescriptionSupported != false)
                target.EvaluationDescription = source.EvaluationDescription;

            if (mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;

            if (mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PerformanceEvaluationResourceId = source.PerformanceEvaluationResourceId;
                target.PerformanceEvaluationDiscriminator = source.PerformanceEvaluationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationRatingLevelsSupported != false)
            {
                source.EvaluationRatingLevels.MapCollectionTo(target.EvaluationRatingLevels, target, mappingContract?.IsEvaluationRatingLevelIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingLevelMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingLevel = new FullName("tpdm", "EvaluationRatingLevel");
    
        public static bool SynchronizeTo(this IEvaluationRatingLevel source, IEvaluationRatingLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingLevel source, IEvaluationRatingLevel target, Action<IEvaluationRatingLevel, IEvaluationRatingLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingLevel);
    
            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationElement

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationElement = new FullName("tpdm", "EvaluationElement");
    
        public static bool SynchronizeTo(this IEvaluationElement source, IEvaluationElement target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationElementMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElement);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationElementTitle != target.EvaluationElementTitle)
            {
                source.EvaluationElementTitle = target.EvaluationElementTitle;
            }
            if (source.EvaluationObjectiveTitle != target.EvaluationObjectiveTitle)
            {
                source.EvaluationObjectiveTitle = target.EvaluationObjectiveTitle;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }

            if ((mappingContract?.IsSortOrderSupported != false)
                && target.SortOrder != source.SortOrder)
            {
                target.SortOrder = source.SortOrder;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationElementRatingLevelsSupported ?? true)
            {
                isModified |=
                    source.EvaluationElementRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationElementRatingLevels,
                        onChildAdded: child =>
                            {
                                child.EvaluationElement = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationElementRatingLevelIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationElement source, IEvaluationElement target, Action<IEvaluationElement, IEvaluationElement> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationElementMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElement);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationElementTitle = source.EvaluationElementTitle;
            target.EvaluationObjectiveTitle = source.EvaluationObjectiveTitle;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.SchoolYear = source.SchoolYear;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            if (mappingContract?.IsSortOrderSupported != false)
                target.SortOrder = source.SortOrder;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationObjectiveResourceId = source.EvaluationObjectiveResourceId;
                target.EvaluationObjectiveDiscriminator = source.EvaluationObjectiveDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationElementRatingLevelsSupported != false)
            {
                source.EvaluationElementRatingLevels.MapCollectionTo(target.EvaluationElementRatingLevels, target, mappingContract?.IsEvaluationElementRatingLevelIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingLevelMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationElementRatingLevel = new FullName("tpdm", "EvaluationElementRatingLevel");
    
        public static bool SynchronizeTo(this IEvaluationElementRatingLevel source, IEvaluationElementRatingLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationElementRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationElementRatingLevel source, IEvaluationElementRatingLevel target, Action<IEvaluationElementRatingLevel, IEvaluationElementRatingLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationElementRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingLevel);
    
            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationElementRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationElementRating = new FullName("tpdm", "EvaluationElementRating");
    
        public static bool SynchronizeTo(this IEvaluationElementRating source, IEvaluationElementRating target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationElementRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRating);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationDate != target.EvaluationDate)
            {
                source.EvaluationDate = target.EvaluationDate;
            }
            if (source.EvaluationElementTitle != target.EvaluationElementTitle)
            {
                source.EvaluationElementTitle = target.EvaluationElementTitle;
            }
            if (source.EvaluationObjectiveTitle != target.EvaluationObjectiveTitle)
            {
                source.EvaluationObjectiveTitle = target.EvaluationObjectiveTitle;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAreaOfRefinementSupported != false)
                && target.AreaOfRefinement != source.AreaOfRefinement)
            {
                target.AreaOfRefinement = source.AreaOfRefinement;
                isModified = true;
            }

            if ((mappingContract?.IsAreaOfReinforcementSupported != false)
                && target.AreaOfReinforcement != source.AreaOfReinforcement)
            {
                target.AreaOfReinforcement = source.AreaOfReinforcement;
                isModified = true;
            }

            if ((mappingContract?.IsCommentsSupported != false)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((mappingContract?.IsEvaluationElementRatingLevelDescriptorSupported != false)
                && target.EvaluationElementRatingLevelDescriptor != source.EvaluationElementRatingLevelDescriptor)
            {
                target.EvaluationElementRatingLevelDescriptor = source.EvaluationElementRatingLevelDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsFeedbackSupported != false)
                && target.Feedback != source.Feedback)
            {
                target.Feedback = source.Feedback;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationElementRatingResultsSupported ?? true)
            {
                isModified |=
                    source.EvaluationElementRatingResults.SynchronizeCollectionTo(
                        target.EvaluationElementRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationElementRating = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationElementRatingResultIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationElementRating source, IEvaluationElementRating target, Action<IEvaluationElementRating, IEvaluationElementRating> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationElementRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRating);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationDate = source.EvaluationDate;
            target.EvaluationElementTitle = source.EvaluationElementTitle;
            target.EvaluationObjectiveTitle = source.EvaluationObjectiveTitle;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.PersonId = source.PersonId;
            target.SchoolYear = source.SchoolYear;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsAreaOfRefinementSupported != false)
                target.AreaOfRefinement = source.AreaOfRefinement;

            if (mappingContract?.IsAreaOfReinforcementSupported != false)
                target.AreaOfReinforcement = source.AreaOfReinforcement;

            if (mappingContract?.IsCommentsSupported != false)
                target.Comments = source.Comments;

            if (mappingContract?.IsEvaluationElementRatingLevelDescriptorSupported != false)
                target.EvaluationElementRatingLevelDescriptor = source.EvaluationElementRatingLevelDescriptor;

            if (mappingContract?.IsFeedbackSupported != false)
                target.Feedback = source.Feedback;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationElementResourceId = source.EvaluationElementResourceId;
                target.EvaluationElementDiscriminator = source.EvaluationElementDiscriminator;
                target.EvaluationObjectiveRatingResourceId = source.EvaluationObjectiveRatingResourceId;
                target.EvaluationObjectiveRatingDiscriminator = source.EvaluationObjectiveRatingDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationElementRatingResultsSupported != false)
            {
                source.EvaluationElementRatingResults.MapCollectionTo(target.EvaluationElementRatingResults, target, mappingContract?.IsEvaluationElementRatingResultIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingResultMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationElementRatingResult = new FullName("tpdm", "EvaluationElementRatingResult");
    
        public static bool SynchronizeTo(this IEvaluationElementRatingResult source, IEvaluationElementRatingResult target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationElementRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingResult);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Rating != target.Rating)
            {
                source.Rating = target.Rating;
            }
            if (source.RatingResultTitle != target.RatingResultTitle)
            {
                source.RatingResultTitle = target.RatingResultTitle;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                && target.ResultDatatypeTypeDescriptor != source.ResultDatatypeTypeDescriptor)
            {
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationElementRatingResult source, IEvaluationElementRatingResult target, Action<IEvaluationElementRatingResult, IEvaluationElementRatingResult> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationElementRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingResult);
    
            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationElementRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingLevelDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationElementRatingLevelDescriptor = new FullName("tpdm", "EvaluationElementRatingLevelDescriptor");
    
        public static bool SynchronizeTo(this IEvaluationElementRatingLevelDescriptor source, IEvaluationElementRatingLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationElementRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationElementRatingLevelDescriptorId != target.EvaluationElementRatingLevelDescriptorId)
            {
                source.EvaluationElementRatingLevelDescriptorId = target.EvaluationElementRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationElementRatingLevelDescriptor source, IEvaluationElementRatingLevelDescriptor target, Action<IEvaluationElementRatingLevelDescriptor, IEvaluationElementRatingLevelDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationElementRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationElementRatingLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationElementRatingLevelDescriptorId = source.EvaluationElementRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationObjective

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationObjectiveAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationObjective = new FullName("tpdm", "EvaluationObjective");
    
        public static bool SynchronizeTo(this IEvaluationObjective source, IEvaluationObjective target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationObjectiveMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjective);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationObjectiveTitle != target.EvaluationObjectiveTitle)
            {
                source.EvaluationObjectiveTitle = target.EvaluationObjectiveTitle;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEvaluationObjectiveDescriptionSupported != false)
                && target.EvaluationObjectiveDescription != source.EvaluationObjectiveDescription)
            {
                target.EvaluationObjectiveDescription = source.EvaluationObjectiveDescription;
                isModified = true;
            }

            if ((mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }

            if ((mappingContract?.IsSortOrderSupported != false)
                && target.SortOrder != source.SortOrder)
            {
                target.SortOrder = source.SortOrder;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationObjectiveRatingLevelsSupported ?? true)
            {
                isModified |=
                    source.EvaluationObjectiveRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationObjectiveRatingLevels,
                        onChildAdded: child =>
                            {
                                child.EvaluationObjective = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationObjectiveRatingLevelIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationObjective source, IEvaluationObjective target, Action<IEvaluationObjective, IEvaluationObjective> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationObjectiveMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjective);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationObjectiveTitle = source.EvaluationObjectiveTitle;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.SchoolYear = source.SchoolYear;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsEvaluationObjectiveDescriptionSupported != false)
                target.EvaluationObjectiveDescription = source.EvaluationObjectiveDescription;

            if (mappingContract?.IsEvaluationTypeDescriptorSupported != false)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            if (mappingContract?.IsSortOrderSupported != false)
                target.SortOrder = source.SortOrder;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationResourceId = source.EvaluationResourceId;
                target.EvaluationDiscriminator = source.EvaluationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationObjectiveRatingLevelsSupported != false)
            {
                source.EvaluationObjectiveRatingLevels.MapCollectionTo(target.EvaluationObjectiveRatingLevels, target, mappingContract?.IsEvaluationObjectiveRatingLevelIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingLevelMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationObjectiveRatingLevel = new FullName("tpdm", "EvaluationObjectiveRatingLevel");
    
        public static bool SynchronizeTo(this IEvaluationObjectiveRatingLevel source, IEvaluationObjectiveRatingLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationObjectiveRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRatingLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationObjectiveRatingLevel source, IEvaluationObjectiveRatingLevel target, Action<IEvaluationObjectiveRatingLevel, IEvaluationObjectiveRatingLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationObjectiveRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRatingLevel);
    
            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationObjectiveRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationObjectiveRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationObjectiveRating = new FullName("tpdm", "EvaluationObjectiveRating");
    
        public static bool SynchronizeTo(this IEvaluationObjectiveRating source, IEvaluationObjectiveRating target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationObjectiveRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRating);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationDate != target.EvaluationDate)
            {
                source.EvaluationDate = target.EvaluationDate;
            }
            if (source.EvaluationObjectiveTitle != target.EvaluationObjectiveTitle)
            {
                source.EvaluationObjectiveTitle = target.EvaluationObjectiveTitle;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsCommentsSupported != false)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((mappingContract?.IsObjectiveRatingLevelDescriptorSupported != false)
                && target.ObjectiveRatingLevelDescriptor != source.ObjectiveRatingLevelDescriptor)
            {
                target.ObjectiveRatingLevelDescriptor = source.ObjectiveRatingLevelDescriptor;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationObjectiveRatingResultsSupported ?? true)
            {
                isModified |=
                    source.EvaluationObjectiveRatingResults.SynchronizeCollectionTo(
                        target.EvaluationObjectiveRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationObjectiveRating = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationObjectiveRatingResultIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationObjectiveRating source, IEvaluationObjectiveRating target, Action<IEvaluationObjectiveRating, IEvaluationObjectiveRating> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationObjectiveRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRating);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationDate = source.EvaluationDate;
            target.EvaluationObjectiveTitle = source.EvaluationObjectiveTitle;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.PersonId = source.PersonId;
            target.SchoolYear = source.SchoolYear;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsCommentsSupported != false)
                target.Comments = source.Comments;

            if (mappingContract?.IsObjectiveRatingLevelDescriptorSupported != false)
                target.ObjectiveRatingLevelDescriptor = source.ObjectiveRatingLevelDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationObjectiveResourceId = source.EvaluationObjectiveResourceId;
                target.EvaluationObjectiveDiscriminator = source.EvaluationObjectiveDiscriminator;
                target.EvaluationRatingResourceId = source.EvaluationRatingResourceId;
                target.EvaluationRatingDiscriminator = source.EvaluationRatingDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationObjectiveRatingResultsSupported != false)
            {
                source.EvaluationObjectiveRatingResults.MapCollectionTo(target.EvaluationObjectiveRatingResults, target, mappingContract?.IsEvaluationObjectiveRatingResultIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingResultMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationObjectiveRatingResult = new FullName("tpdm", "EvaluationObjectiveRatingResult");
    
        public static bool SynchronizeTo(this IEvaluationObjectiveRatingResult source, IEvaluationObjectiveRatingResult target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationObjectiveRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRatingResult);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Rating != target.Rating)
            {
                source.Rating = target.Rating;
            }
            if (source.RatingResultTitle != target.RatingResultTitle)
            {
                source.RatingResultTitle = target.RatingResultTitle;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                && target.ResultDatatypeTypeDescriptor != source.ResultDatatypeTypeDescriptor)
            {
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationObjectiveRatingResult source, IEvaluationObjectiveRatingResult target, Action<IEvaluationObjectiveRatingResult, IEvaluationObjectiveRatingResult> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationObjectiveRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationObjectiveRatingResult);
    
            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationPeriodDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationPeriodDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationPeriodDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationPeriodDescriptor = new FullName("tpdm", "EvaluationPeriodDescriptor");
    
        public static bool SynchronizeTo(this IEvaluationPeriodDescriptor source, IEvaluationPeriodDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationPeriodDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationPeriodDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationPeriodDescriptorId != target.EvaluationPeriodDescriptorId)
            {
                source.EvaluationPeriodDescriptorId = target.EvaluationPeriodDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationPeriodDescriptor source, IEvaluationPeriodDescriptor target, Action<IEvaluationPeriodDescriptor, IEvaluationPeriodDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationPeriodDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationPeriodDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationPeriodDescriptorId = source.EvaluationPeriodDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRating = new FullName("tpdm", "EvaluationRating");
    
        public static bool SynchronizeTo(this IEvaluationRating source, IEvaluationRating target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRating);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationDate != target.EvaluationDate)
            {
                source.EvaluationDate = target.EvaluationDate;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsEvaluationRatingLevelDescriptorSupported != false)
                && target.EvaluationRatingLevelDescriptor != source.EvaluationRatingLevelDescriptor)
            {
                target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsEvaluationRatingStatusDescriptorSupported != false)
                && target.EvaluationRatingStatusDescriptor != source.EvaluationRatingStatusDescriptor)
            {
                target.EvaluationRatingStatusDescriptor = source.EvaluationRatingStatusDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsLocalCourseCodeSupported != false)
                && target.LocalCourseCode != source.LocalCourseCode)
            {
                target.LocalCourseCode = source.LocalCourseCode;
                isModified = true;
            }

            if ((mappingContract?.IsSchoolIdSupported != false)
                && target.SchoolId != source.SchoolId)
            {
                target.SchoolId = source.SchoolId;
                isModified = true;
            }

            if ((mappingContract?.IsSectionIdentifierSupported != false)
                && target.SectionIdentifier != source.SectionIdentifier)
            {
                target.SectionIdentifier = source.SectionIdentifier;
                isModified = true;
            }

            if ((mappingContract?.IsSessionNameSupported != false)
                && target.SessionName != source.SessionName)
            {
                target.SessionName = source.SessionName;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsEvaluationRatingResultsSupported ?? true)
            {
                isModified |=
                    source.EvaluationRatingResults.SynchronizeCollectionTo(
                        target.EvaluationRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationRating = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationRatingResultIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsEvaluationRatingReviewersSupported ?? true)
            {
                isModified |=
                    source.EvaluationRatingReviewers.SynchronizeCollectionTo(
                        target.EvaluationRatingReviewers,
                        onChildAdded: child =>
                            {
                                child.EvaluationRating = target;
                            },
                        includeItem: item => mappingContract?.IsEvaluationRatingReviewerIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationRating source, IEvaluationRating target, Action<IEvaluationRating, IEvaluationRating> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRating);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationDate = source.EvaluationDate;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.PersonId = source.PersonId;
            target.SchoolYear = source.SchoolYear;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsEvaluationRatingLevelDescriptorSupported != false)
                target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            if (mappingContract?.IsEvaluationRatingStatusDescriptorSupported != false)
                target.EvaluationRatingStatusDescriptor = source.EvaluationRatingStatusDescriptor;

            if (mappingContract?.IsLocalCourseCodeSupported != false)
                target.LocalCourseCode = source.LocalCourseCode;

            if (mappingContract?.IsSchoolIdSupported != false)
                target.SchoolId = source.SchoolId;

            if (mappingContract?.IsSectionIdentifierSupported != false)
                target.SectionIdentifier = source.SectionIdentifier;

            if (mappingContract?.IsSessionNameSupported != false)
                target.SessionName = source.SessionName;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationResourceId = source.EvaluationResourceId;
                target.EvaluationDiscriminator = source.EvaluationDiscriminator;
                target.PerformanceEvaluationRatingResourceId = source.PerformanceEvaluationRatingResourceId;
                target.PerformanceEvaluationRatingDiscriminator = source.PerformanceEvaluationRatingDiscriminator;
                target.SectionResourceId = source.SectionResourceId;
                target.SectionDiscriminator = source.SectionDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsEvaluationRatingResultsSupported != false)
            {
                source.EvaluationRatingResults.MapCollectionTo(target.EvaluationRatingResults, target, mappingContract?.IsEvaluationRatingResultIncluded);
            }

            if (mappingContract?.IsEvaluationRatingReviewersSupported != false)
            {
                source.EvaluationRatingReviewers.MapCollectionTo(target.EvaluationRatingReviewers, target, mappingContract?.IsEvaluationRatingReviewerIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingResultMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingResult = new FullName("tpdm", "EvaluationRatingResult");
    
        public static bool SynchronizeTo(this IEvaluationRatingResult source, IEvaluationRatingResult target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingResult);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Rating != target.Rating)
            {
                source.Rating = target.Rating;
            }
            if (source.RatingResultTitle != target.RatingResultTitle)
            {
                source.RatingResultTitle = target.RatingResultTitle;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                && target.ResultDatatypeTypeDescriptor != source.ResultDatatypeTypeDescriptor)
            {
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingResult source, IEvaluationRatingResult target, Action<IEvaluationRatingResult, IEvaluationRatingResult> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingResult);
    
            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingReviewerMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingReviewer = new FullName("tpdm", "EvaluationRatingReviewer");
    
        public static bool SynchronizeTo(this IEvaluationRatingReviewer source, IEvaluationRatingReviewer target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingReviewerMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingReviewer);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FirstName != target.FirstName)
            {
                source.FirstName = target.FirstName;
            }
            if (source.LastSurname != target.LastSurname)
            {
                source.LastSurname = target.LastSurname;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsReviewerPersonIdSupported != false)
                && target.ReviewerPersonId != source.ReviewerPersonId)
            {
                target.ReviewerPersonId = source.ReviewerPersonId;
                isModified = true;
            }

            if ((mappingContract?.IsReviewerSourceSystemDescriptorSupported != false)
                && target.ReviewerSourceSystemDescriptor != source.ReviewerSourceSystemDescriptor)
            {
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // EvaluationRatingReviewerReceivedTraining (EvaluationRatingReviewerReceivedTraining)
            if (mappingContract?.IsEvaluationRatingReviewerReceivedTrainingSupported != false)
            {
                if (source.EvaluationRatingReviewerReceivedTraining == null)
                {
                    if (target.EvaluationRatingReviewerReceivedTraining != null)
                    {
                        target.EvaluationRatingReviewerReceivedTraining = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.EvaluationRatingReviewerReceivedTraining == null)
                    {
                        var itemType = target.GetType().GetProperty("EvaluationRatingReviewerReceivedTraining").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.EvaluationRatingReviewerReceivedTraining = (IEvaluationRatingReviewerReceivedTraining) newItem;
                    }

                    isModified |= source.EvaluationRatingReviewerReceivedTraining.Synchronize(target.EvaluationRatingReviewerReceivedTraining);
                }
            }

            // -------------------------------------------------------------

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingReviewer source, IEvaluationRatingReviewer target, Action<IEvaluationRatingReviewer, IEvaluationRatingReviewer> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingReviewerMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingReviewer);
    
            // Copy contextual primary key values
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;

            // Copy non-PK properties

            if (mappingContract?.IsReviewerPersonIdSupported != false)
                target.ReviewerPersonId = source.ReviewerPersonId;

            if (mappingContract?.IsReviewerSourceSystemDescriptorSupported != false)
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.ReviewerPersonResourceId = source.ReviewerPersonResourceId;
                target.ReviewerPersonDiscriminator = source.ReviewerPersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // EvaluationRatingReviewerReceivedTraining (EvaluationRatingReviewerReceivedTraining) (Source)
            if (mappingContract?.IsEvaluationRatingReviewerReceivedTrainingSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("EvaluationRatingReviewerReceivedTraining");

                if (itemProperty != null)
                {
                    if (source.EvaluationRatingReviewerReceivedTraining == null)
                    {
                        target.EvaluationRatingReviewerReceivedTraining = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetEvaluationRatingReviewerReceivedTraining = Activator.CreateInstance(itemType);
                        (targetEvaluationRatingReviewerReceivedTraining as IChildEntity)?.SetParent(target);
                        source.EvaluationRatingReviewerReceivedTraining.Map(targetEvaluationRatingReviewerReceivedTraining);

                        // Update the target reference appropriately
                        target.EvaluationRatingReviewerReceivedTraining = (IEvaluationRatingReviewerReceivedTraining) targetEvaluationRatingReviewerReceivedTraining;
                    }
                }
            }
            // -------------------------------------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingReviewerReceivedTrainingMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingReviewerReceivedTraining = new FullName("tpdm", "EvaluationRatingReviewerReceivedTraining");
    
        public static bool SynchronizeTo(this IEvaluationRatingReviewerReceivedTraining source, IEvaluationRatingReviewerReceivedTraining target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingReviewerReceivedTrainingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingReviewerReceivedTraining);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((mappingContract?.IsReceivedTrainingDateSupported != false)
                && target.ReceivedTrainingDate != source.ReceivedTrainingDate)
            {
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingReviewerReceivedTraining source, IEvaluationRatingReviewerReceivedTraining target, Action<IEvaluationRatingReviewerReceivedTraining, IEvaluationRatingReviewerReceivedTraining> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingReviewerReceivedTrainingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingReviewerReceivedTraining);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;

            if (mappingContract?.IsReceivedTrainingDateSupported != false)
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingLevelDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingLevelDescriptor = new FullName("tpdm", "EvaluationRatingLevelDescriptor");
    
        public static bool SynchronizeTo(this IEvaluationRatingLevelDescriptor source, IEvaluationRatingLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptorId != target.EvaluationRatingLevelDescriptorId)
            {
                source.EvaluationRatingLevelDescriptorId = target.EvaluationRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingLevelDescriptor source, IEvaluationRatingLevelDescriptor target, Action<IEvaluationRatingLevelDescriptor, IEvaluationRatingLevelDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptorId = source.EvaluationRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationRatingStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingStatusDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationRatingStatusDescriptor = new FullName("tpdm", "EvaluationRatingStatusDescriptor");
    
        public static bool SynchronizeTo(this IEvaluationRatingStatusDescriptor source, IEvaluationRatingStatusDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationRatingStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingStatusDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingStatusDescriptorId != target.EvaluationRatingStatusDescriptorId)
            {
                source.EvaluationRatingStatusDescriptorId = target.EvaluationRatingStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationRatingStatusDescriptor source, IEvaluationRatingStatusDescriptor target, Action<IEvaluationRatingStatusDescriptor, IEvaluationRatingStatusDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationRatingStatusDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationRatingStatusDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationRatingStatusDescriptorId = source.EvaluationRatingStatusDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: EvaluationTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationTypeDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_EvaluationTypeDescriptor = new FullName("tpdm", "EvaluationTypeDescriptor");
    
        public static bool SynchronizeTo(this IEvaluationTypeDescriptor source, IEvaluationTypeDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (EvaluationTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationTypeDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationTypeDescriptorId != target.EvaluationTypeDescriptorId)
            {
                source.EvaluationTypeDescriptorId = target.EvaluationTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IEvaluationTypeDescriptor source, IEvaluationTypeDescriptor target, Action<IEvaluationTypeDescriptor, IEvaluationTypeDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (EvaluationTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_EvaluationTypeDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationTypeDescriptorId = source.EvaluationTypeDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: FinancialAid

namespace EdFi.Ods.Entities.Common.TPDM //.FinancialAidAggregate
{
    [ExcludeFromCodeCoverage]
    public static class FinancialAidMapper
    {
        private static readonly FullName _fullName_tpdm_FinancialAid = new FullName("tpdm", "FinancialAid");
    
        public static bool SynchronizeTo(this IFinancialAid source, IFinancialAid target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (FinancialAidMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_FinancialAid);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AidTypeDescriptor != target.AidTypeDescriptor)
            {
                source.AidTypeDescriptor = target.AidTypeDescriptor;
            }
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }
            if (source.StudentUniqueId != target.StudentUniqueId)
            {
                source.StudentUniqueId = target.StudentUniqueId;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAidAmountSupported != false)
                && target.AidAmount != source.AidAmount)
            {
                target.AidAmount = source.AidAmount;
                isModified = true;
            }

            if ((mappingContract?.IsAidConditionDescriptionSupported != false)
                && target.AidConditionDescription != source.AidConditionDescription)
            {
                target.AidConditionDescription = source.AidConditionDescription;
                isModified = true;
            }

            if ((mappingContract?.IsEndDateSupported != false)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((mappingContract?.IsPellGrantRecipientSupported != false)
                && target.PellGrantRecipient != source.PellGrantRecipient)
            {
                target.PellGrantRecipient = source.PellGrantRecipient;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IFinancialAid source, IFinancialAid target, Action<IFinancialAid, IFinancialAid> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (FinancialAidMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_FinancialAid);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AidTypeDescriptor = source.AidTypeDescriptor;
            target.BeginDate = source.BeginDate;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (mappingContract?.IsAidAmountSupported != false)
                target.AidAmount = source.AidAmount;

            if (mappingContract?.IsAidConditionDescriptionSupported != false)
                target.AidConditionDescription = source.AidConditionDescription;

            if (mappingContract?.IsEndDateSupported != false)
                target.EndDate = source.EndDate;

            if (mappingContract?.IsPellGrantRecipientSupported != false)
                target.PellGrantRecipient = source.PellGrantRecipient;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.StudentResourceId = source.StudentResourceId;
                target.StudentDiscriminator = source.StudentDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: GenderDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.GenderDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class GenderDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_GenderDescriptor = new FullName("tpdm", "GenderDescriptor");
    
        public static bool SynchronizeTo(this IGenderDescriptor source, IGenderDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (GenderDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_GenderDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.GenderDescriptorId != target.GenderDescriptorId)
            {
                source.GenderDescriptorId = target.GenderDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IGenderDescriptor source, IGenderDescriptor target, Action<IGenderDescriptor, IGenderDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (GenderDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_GenderDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.GenderDescriptorId = source.GenderDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: ObjectiveRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.ObjectiveRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ObjectiveRatingLevelDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_ObjectiveRatingLevelDescriptor = new FullName("tpdm", "ObjectiveRatingLevelDescriptor");
    
        public static bool SynchronizeTo(this IObjectiveRatingLevelDescriptor source, IObjectiveRatingLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (ObjectiveRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_ObjectiveRatingLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ObjectiveRatingLevelDescriptorId != target.ObjectiveRatingLevelDescriptorId)
            {
                source.ObjectiveRatingLevelDescriptorId = target.ObjectiveRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IObjectiveRatingLevelDescriptor source, IObjectiveRatingLevelDescriptor target, Action<IObjectiveRatingLevelDescriptor, IObjectiveRatingLevelDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (ObjectiveRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_ObjectiveRatingLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ObjectiveRatingLevelDescriptorId = source.ObjectiveRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: PerformanceEvaluation

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluation = new FullName("tpdm", "PerformanceEvaluation");
    
        public static bool SynchronizeTo(this IPerformanceEvaluation source, IPerformanceEvaluation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsAcademicSubjectDescriptorSupported != false)
                && target.AcademicSubjectDescriptor != source.AcademicSubjectDescriptor)
            {
                target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsPerformanceEvaluationDescriptionSupported != false)
                && target.PerformanceEvaluationDescription != source.PerformanceEvaluationDescription)
            {
                target.PerformanceEvaluationDescription = source.PerformanceEvaluationDescription;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsPerformanceEvaluationGradeLevelsSupported ?? true)
            {
                isModified |=
                    source.PerformanceEvaluationGradeLevels.SynchronizeCollectionTo(
                        target.PerformanceEvaluationGradeLevels,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluation = target;
                            },
                        includeItem: item => mappingContract?.IsPerformanceEvaluationGradeLevelIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsPerformanceEvaluationRatingLevelsSupported ?? true)
            {
                isModified |=
                    source.PerformanceEvaluationRatingLevels.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingLevels,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluation = target;
                            },
                        includeItem: item => mappingContract?.IsPerformanceEvaluationRatingLevelIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluation source, IPerformanceEvaluation target, Action<IPerformanceEvaluation, IPerformanceEvaluation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.SchoolYear = source.SchoolYear;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsAcademicSubjectDescriptorSupported != false)
                target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;

            if (mappingContract?.IsPerformanceEvaluationDescriptionSupported != false)
                target.PerformanceEvaluationDescription = source.PerformanceEvaluationDescription;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EducationOrganizationResourceId = source.EducationOrganizationResourceId;
                target.EducationOrganizationDiscriminator = source.EducationOrganizationDiscriminator;
                target.SchoolYearTypeResourceId = source.SchoolYearTypeResourceId;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsPerformanceEvaluationGradeLevelsSupported != false)
            {
                source.PerformanceEvaluationGradeLevels.MapCollectionTo(target.PerformanceEvaluationGradeLevels, target, mappingContract?.IsPerformanceEvaluationGradeLevelIncluded);
            }

            if (mappingContract?.IsPerformanceEvaluationRatingLevelsSupported != false)
            {
                source.PerformanceEvaluationRatingLevels.MapCollectionTo(target.PerformanceEvaluationRatingLevels, target, mappingContract?.IsPerformanceEvaluationRatingLevelIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationGradeLevelMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationGradeLevel = new FullName("tpdm", "PerformanceEvaluationGradeLevel");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationGradeLevel source, IPerformanceEvaluationGradeLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationGradeLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationGradeLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.GradeLevelDescriptor != target.GradeLevelDescriptor)
            {
                source.GradeLevelDescriptor = target.GradeLevelDescriptor;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationGradeLevel source, IPerformanceEvaluationGradeLevel target, Action<IPerformanceEvaluationGradeLevel, IPerformanceEvaluationGradeLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationGradeLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationGradeLevel);
    
            // Copy contextual primary key values
            target.GradeLevelDescriptor = source.GradeLevelDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingLevelMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRatingLevel = new FullName("tpdm", "PerformanceEvaluationRatingLevel");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingLevel source, IPerformanceEvaluationRatingLevel target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingLevel);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsMaxRatingSupported != false)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((mappingContract?.IsMinRatingSupported != false)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRatingLevel source, IPerformanceEvaluationRatingLevel target, Action<IPerformanceEvaluationRatingLevel, IPerformanceEvaluationRatingLevel> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingLevelMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingLevel);
    
            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsMaxRatingSupported != false)
                target.MaxRating = source.MaxRating;

            if (mappingContract?.IsMinRatingSupported != false)
                target.MinRating = source.MinRating;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: PerformanceEvaluationRating

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRating = new FullName("tpdm", "PerformanceEvaluationRating");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRating source, IPerformanceEvaluationRating target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRating);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsActualDateSupported != false)
                && target.ActualDate != source.ActualDate)
            {
                target.ActualDate = source.ActualDate;
                isModified = true;
            }

            if ((mappingContract?.IsActualDurationSupported != false)
                && target.ActualDuration != source.ActualDuration)
            {
                target.ActualDuration = source.ActualDuration;
                isModified = true;
            }

            if ((mappingContract?.IsActualTimeSupported != false)
                && target.ActualTime != source.ActualTime)
            {
                target.ActualTime = source.ActualTime;
                isModified = true;
            }

            if ((mappingContract?.IsAnnouncedSupported != false)
                && target.Announced != source.Announced)
            {
                target.Announced = source.Announced;
                isModified = true;
            }

            if ((mappingContract?.IsCommentsSupported != false)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((mappingContract?.IsCoteachingStyleObservedDescriptorSupported != false)
                && target.CoteachingStyleObservedDescriptor != source.CoteachingStyleObservedDescriptor)
            {
                target.CoteachingStyleObservedDescriptor = source.CoteachingStyleObservedDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsPerformanceEvaluationRatingLevelDescriptorSupported != false)
                && target.PerformanceEvaluationRatingLevelDescriptor != source.PerformanceEvaluationRatingLevelDescriptor)
            {
                target.PerformanceEvaluationRatingLevelDescriptor = source.PerformanceEvaluationRatingLevelDescriptor;
                isModified = true;
            }

            if ((mappingContract?.IsScheduleDateSupported != false)
                && target.ScheduleDate != source.ScheduleDate)
            {
                target.ScheduleDate = source.ScheduleDate;
                isModified = true;
            }


            // Sync lists
            if (mappingContract?.IsPerformanceEvaluationRatingResultsSupported ?? true)
            {
                isModified |=
                    source.PerformanceEvaluationRatingResults.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingResults,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluationRating = target;
                            },
                        includeItem: item => mappingContract?.IsPerformanceEvaluationRatingResultIncluded?.Invoke(item) ?? true);
            }

            if (mappingContract?.IsPerformanceEvaluationRatingReviewersSupported ?? true)
            {
                isModified |=
                    source.PerformanceEvaluationRatingReviewers.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingReviewers,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluationRating = target;
                            },
                        includeItem: item => mappingContract?.IsPerformanceEvaluationRatingReviewerIncluded?.Invoke(item) ?? true);
            }


            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRating source, IPerformanceEvaluationRating target, Action<IPerformanceEvaluationRating, IPerformanceEvaluationRating> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRating);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.PersonId = source.PersonId;
            target.SchoolYear = source.SchoolYear;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsActualDateSupported != false)
                target.ActualDate = source.ActualDate;

            if (mappingContract?.IsActualDurationSupported != false)
                target.ActualDuration = source.ActualDuration;

            if (mappingContract?.IsActualTimeSupported != false)
                target.ActualTime = source.ActualTime;

            if (mappingContract?.IsAnnouncedSupported != false)
                target.Announced = source.Announced;

            if (mappingContract?.IsCommentsSupported != false)
                target.Comments = source.Comments;

            if (mappingContract?.IsCoteachingStyleObservedDescriptorSupported != false)
                target.CoteachingStyleObservedDescriptor = source.CoteachingStyleObservedDescriptor;

            if (mappingContract?.IsPerformanceEvaluationRatingLevelDescriptorSupported != false)
                target.PerformanceEvaluationRatingLevelDescriptor = source.PerformanceEvaluationRatingLevelDescriptor;

            if (mappingContract?.IsScheduleDateSupported != false)
                target.ScheduleDate = source.ScheduleDate;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PerformanceEvaluationResourceId = source.PerformanceEvaluationResourceId;
                target.PerformanceEvaluationDiscriminator = source.PerformanceEvaluationDiscriminator;
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (mappingContract?.IsPerformanceEvaluationRatingResultsSupported != false)
            {
                source.PerformanceEvaluationRatingResults.MapCollectionTo(target.PerformanceEvaluationRatingResults, target, mappingContract?.IsPerformanceEvaluationRatingResultIncluded);
            }

            if (mappingContract?.IsPerformanceEvaluationRatingReviewersSupported != false)
            {
                source.PerformanceEvaluationRatingReviewers.MapCollectionTo(target.PerformanceEvaluationRatingReviewers, target, mappingContract?.IsPerformanceEvaluationRatingReviewerIncluded);
            }


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingResultMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRatingResult = new FullName("tpdm", "PerformanceEvaluationRatingResult");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingResult source, IPerformanceEvaluationRatingResult target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingResult);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Rating != target.Rating)
            {
                source.Rating = target.Rating;
            }
            if (source.RatingResultTitle != target.RatingResultTitle)
            {
                source.RatingResultTitle = target.RatingResultTitle;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                && target.ResultDatatypeTypeDescriptor != source.ResultDatatypeTypeDescriptor)
            {
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRatingResult source, IPerformanceEvaluationRatingResult target, Action<IPerformanceEvaluationRatingResult, IPerformanceEvaluationRatingResult> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingResultMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingResult);
    
            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (mappingContract?.IsResultDatatypeTypeDescriptorSupported != false)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingReviewerMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRatingReviewer = new FullName("tpdm", "PerformanceEvaluationRatingReviewer");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingReviewer source, IPerformanceEvaluationRatingReviewer target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingReviewerMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingReviewer);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.FirstName != target.FirstName)
            {
                source.FirstName = target.FirstName;
            }
            if (source.LastSurname != target.LastSurname)
            {
                source.LastSurname = target.LastSurname;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsReviewerPersonIdSupported != false)
                && target.ReviewerPersonId != source.ReviewerPersonId)
            {
                target.ReviewerPersonId = source.ReviewerPersonId;
                isModified = true;
            }

            if ((mappingContract?.IsReviewerSourceSystemDescriptorSupported != false)
                && target.ReviewerSourceSystemDescriptor != source.ReviewerSourceSystemDescriptor)
            {
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // PerformanceEvaluationRatingReviewerReceivedTraining (PerformanceEvaluationRatingReviewerReceivedTraining)
            if (mappingContract?.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported != false)
            {
                if (source.PerformanceEvaluationRatingReviewerReceivedTraining == null)
                {
                    if (target.PerformanceEvaluationRatingReviewerReceivedTraining != null)
                    {
                        target.PerformanceEvaluationRatingReviewerReceivedTraining = null;
                        isModified = true;
                    }
                }
                else
                {
                    if (target.PerformanceEvaluationRatingReviewerReceivedTraining == null)
                    {
                        var itemType = target.GetType().GetProperty("PerformanceEvaluationRatingReviewerReceivedTraining").PropertyType;
                        var newItem = Activator.CreateInstance(itemType);
                        target.PerformanceEvaluationRatingReviewerReceivedTraining = (IPerformanceEvaluationRatingReviewerReceivedTraining) newItem;
                    }

                    isModified |= source.PerformanceEvaluationRatingReviewerReceivedTraining.Synchronize(target.PerformanceEvaluationRatingReviewerReceivedTraining);
                }
            }

            // -------------------------------------------------------------

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRatingReviewer source, IPerformanceEvaluationRatingReviewer target, Action<IPerformanceEvaluationRatingReviewer, IPerformanceEvaluationRatingReviewer> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingReviewerMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingReviewer);
    
            // Copy contextual primary key values
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;

            // Copy non-PK properties

            if (mappingContract?.IsReviewerPersonIdSupported != false)
                target.ReviewerPersonId = source.ReviewerPersonId;

            if (mappingContract?.IsReviewerSourceSystemDescriptorSupported != false)
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.ReviewerPersonResourceId = source.ReviewerPersonResourceId;
                target.ReviewerPersonDiscriminator = source.ReviewerPersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------
            // PerformanceEvaluationRatingReviewerReceivedTraining (PerformanceEvaluationRatingReviewerReceivedTraining) (Source)
            if (mappingContract?.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported != false)
            {
                var itemProperty = target.GetType().GetProperty("PerformanceEvaluationRatingReviewerReceivedTraining");

                if (itemProperty != null)
                {
                    if (source.PerformanceEvaluationRatingReviewerReceivedTraining == null)
                    {
                        target.PerformanceEvaluationRatingReviewerReceivedTraining = null;
                    }
                    else
                    {
                        var itemType = itemProperty.PropertyType;
                        object targetPerformanceEvaluationRatingReviewerReceivedTraining = Activator.CreateInstance(itemType);
                        (targetPerformanceEvaluationRatingReviewerReceivedTraining as IChildEntity)?.SetParent(target);
                        source.PerformanceEvaluationRatingReviewerReceivedTraining.Map(targetPerformanceEvaluationRatingReviewerReceivedTraining);

                        // Update the target reference appropriately
                        target.PerformanceEvaluationRatingReviewerReceivedTraining = (IPerformanceEvaluationRatingReviewerReceivedTraining) targetPerformanceEvaluationRatingReviewerReceivedTraining;
                    }
                }
            }
            // -------------------------------------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingReviewerReceivedTrainingMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRatingReviewerReceivedTraining = new FullName("tpdm", "PerformanceEvaluationRatingReviewerReceivedTraining");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingReviewerReceivedTraining source, IPerformanceEvaluationRatingReviewerReceivedTraining target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingReviewerReceivedTrainingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingReviewerReceivedTraining);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((mappingContract?.IsReceivedTrainingDateSupported != false)
                && target.ReceivedTrainingDate != source.ReceivedTrainingDate)
            {
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRatingReviewerReceivedTraining source, IPerformanceEvaluationRatingReviewerReceivedTraining target, Action<IPerformanceEvaluationRatingReviewerReceivedTraining, IPerformanceEvaluationRatingReviewerReceivedTraining> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingReviewerReceivedTrainingMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingReviewerReceivedTraining);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsInterRaterReliabilityScoreSupported != false)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;

            if (mappingContract?.IsReceivedTrainingDateSupported != false)
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: PerformanceEvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingLevelDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationRatingLevelDescriptor = new FullName("tpdm", "PerformanceEvaluationRatingLevelDescriptor");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingLevelDescriptor source, IPerformanceEvaluationRatingLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PerformanceEvaluationRatingLevelDescriptorId != target.PerformanceEvaluationRatingLevelDescriptorId)
            {
                source.PerformanceEvaluationRatingLevelDescriptorId = target.PerformanceEvaluationRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRatingLevelDescriptor source, IPerformanceEvaluationRatingLevelDescriptor target, Action<IPerformanceEvaluationRatingLevelDescriptor, IPerformanceEvaluationRatingLevelDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationRatingLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.PerformanceEvaluationRatingLevelDescriptorId = source.PerformanceEvaluationRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: PerformanceEvaluationTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationTypeDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_PerformanceEvaluationTypeDescriptor = new FullName("tpdm", "PerformanceEvaluationTypeDescriptor");
    
        public static bool SynchronizeTo(this IPerformanceEvaluationTypeDescriptor source, IPerformanceEvaluationTypeDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (PerformanceEvaluationTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationTypeDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PerformanceEvaluationTypeDescriptorId != target.PerformanceEvaluationTypeDescriptorId)
            {
                source.PerformanceEvaluationTypeDescriptorId = target.PerformanceEvaluationTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationTypeDescriptor source, IPerformanceEvaluationTypeDescriptor target, Action<IPerformanceEvaluationTypeDescriptor, IPerformanceEvaluationTypeDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (PerformanceEvaluationTypeDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_PerformanceEvaluationTypeDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.PerformanceEvaluationTypeDescriptorId = source.PerformanceEvaluationTypeDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: RubricDimension

namespace EdFi.Ods.Entities.Common.TPDM //.RubricDimensionAggregate
{
    [ExcludeFromCodeCoverage]
    public static class RubricDimensionMapper
    {
        private static readonly FullName _fullName_tpdm_RubricDimension = new FullName("tpdm", "RubricDimension");
    
        public static bool SynchronizeTo(this IRubricDimension source, IRubricDimension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (RubricDimensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_RubricDimension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }
            if (source.EvaluationElementTitle != target.EvaluationElementTitle)
            {
                source.EvaluationElementTitle = target.EvaluationElementTitle;
            }
            if (source.EvaluationObjectiveTitle != target.EvaluationObjectiveTitle)
            {
                source.EvaluationObjectiveTitle = target.EvaluationObjectiveTitle;
            }
            if (source.EvaluationPeriodDescriptor != target.EvaluationPeriodDescriptor)
            {
                source.EvaluationPeriodDescriptor = target.EvaluationPeriodDescriptor;
            }
            if (source.EvaluationTitle != target.EvaluationTitle)
            {
                source.EvaluationTitle = target.EvaluationTitle;
            }
            if (source.PerformanceEvaluationTitle != target.PerformanceEvaluationTitle)
            {
                source.PerformanceEvaluationTitle = target.PerformanceEvaluationTitle;
            }
            if (source.PerformanceEvaluationTypeDescriptor != target.PerformanceEvaluationTypeDescriptor)
            {
                source.PerformanceEvaluationTypeDescriptor = target.PerformanceEvaluationTypeDescriptor;
            }
            if (source.RubricRating != target.RubricRating)
            {
                source.RubricRating = target.RubricRating;
            }
            if (source.SchoolYear != target.SchoolYear)
            {
                source.SchoolYear = target.SchoolYear;
            }
            if (source.TermDescriptor != target.TermDescriptor)
            {
                source.TermDescriptor = target.TermDescriptor;
            }

            // Copy non-PK properties

            if ((mappingContract?.IsCriterionDescriptionSupported != false)
                && target.CriterionDescription != source.CriterionDescription)
            {
                target.CriterionDescription = source.CriterionDescription;
                isModified = true;
            }

            if ((mappingContract?.IsDimensionOrderSupported != false)
                && target.DimensionOrder != source.DimensionOrder)
            {
                target.DimensionOrder = source.DimensionOrder;
                isModified = true;
            }

            if ((mappingContract?.IsRubricRatingLevelDescriptorSupported != false)
                && target.RubricRatingLevelDescriptor != source.RubricRatingLevelDescriptor)
            {
                target.RubricRatingLevelDescriptor = source.RubricRatingLevelDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IRubricDimension source, IRubricDimension target, Action<IRubricDimension, IRubricDimension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (RubricDimensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_RubricDimension);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.EvaluationElementTitle = source.EvaluationElementTitle;
            target.EvaluationObjectiveTitle = source.EvaluationObjectiveTitle;
            target.EvaluationPeriodDescriptor = source.EvaluationPeriodDescriptor;
            target.EvaluationTitle = source.EvaluationTitle;
            target.PerformanceEvaluationTitle = source.PerformanceEvaluationTitle;
            target.PerformanceEvaluationTypeDescriptor = source.PerformanceEvaluationTypeDescriptor;
            target.RubricRating = source.RubricRating;
            target.SchoolYear = source.SchoolYear;
            target.TermDescriptor = source.TermDescriptor;

            // Copy non-PK properties

            if (mappingContract?.IsCriterionDescriptionSupported != false)
                target.CriterionDescription = source.CriterionDescription;

            if (mappingContract?.IsDimensionOrderSupported != false)
                target.DimensionOrder = source.DimensionOrder;

            if (mappingContract?.IsRubricRatingLevelDescriptorSupported != false)
                target.RubricRatingLevelDescriptor = source.RubricRatingLevelDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EvaluationElementResourceId = source.EvaluationElementResourceId;
                target.EvaluationElementDiscriminator = source.EvaluationElementDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: RubricRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.RubricRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class RubricRatingLevelDescriptorMapper
    {
        private static readonly FullName _fullName_tpdm_RubricRatingLevelDescriptor = new FullName("tpdm", "RubricRatingLevelDescriptor");
    
        public static bool SynchronizeTo(this IRubricRatingLevelDescriptor source, IRubricRatingLevelDescriptor target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (RubricRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_RubricRatingLevelDescriptor);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.RubricRatingLevelDescriptorId != target.RubricRatingLevelDescriptorId)
            {
                source.RubricRatingLevelDescriptorId = target.RubricRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((mappingContract?.IsCodeValueSupported != false)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((mappingContract?.IsDescriptionSupported != false)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveBeginDateSupported != false)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((mappingContract?.IsEffectiveEndDateSupported != false)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((mappingContract?.IsNamespaceSupported != false)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((mappingContract?.IsPriorDescriptorIdSupported != false)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((mappingContract?.IsShortDescriptionSupported != false)
                && target.ShortDescription != source.ShortDescription)
            {
                target.ShortDescription = source.ShortDescription;
                isModified = true;
            }

            // Copy non-PK properties


            // Synch inherited lists

            // Sync lists

            return isModified;
        }



        public static void MapTo(this IRubricRatingLevelDescriptor source, IRubricRatingLevelDescriptor target, Action<IRubricRatingLevelDescriptor, IRubricRatingLevelDescriptor> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (RubricRatingLevelDescriptorMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_RubricRatingLevelDescriptor);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.RubricRatingLevelDescriptorId = source.RubricRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (mappingContract?.IsCodeValueSupported != false)
                target.CodeValue = source.CodeValue;

            if (mappingContract?.IsDescriptionSupported != false)
                target.Description = source.Description;

            if (mappingContract?.IsEffectiveBeginDateSupported != false)
                target.EffectiveBeginDate = source.EffectiveBeginDate;

            if (mappingContract?.IsEffectiveEndDateSupported != false)
                target.EffectiveEndDate = source.EffectiveEndDate;

            if (mappingContract?.IsNamespaceSupported != false)
                target.Namespace = source.Namespace;

            if (mappingContract?.IsPriorDescriptorIdSupported != false)
                target.PriorDescriptorId = source.PriorDescriptorId;

            if (mappingContract?.IsShortDescriptionSupported != false)
                target.ShortDescription = source.ShortDescription;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map inherited lists

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: School

namespace EdFi.Ods.Entities.Common.TPDM //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolExtensionMapper
    {
        private static readonly FullName _fullName_tpdm_SchoolExtension = new FullName("tpdm", "SchoolExtension");
    
        public static bool SynchronizeTo(this ISchoolExtension source, ISchoolExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SchoolExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SchoolExtension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsPostSecondaryInstitutionIdSupported != false)
                && target.PostSecondaryInstitutionId != source.PostSecondaryInstitutionId)
            {
                target.PostSecondaryInstitutionId = source.PostSecondaryInstitutionId;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISchoolExtension source, ISchoolExtension target, Action<ISchoolExtension, ISchoolExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SchoolExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SchoolExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsPostSecondaryInstitutionIdSupported != false)
                target.PostSecondaryInstitutionId = source.PostSecondaryInstitutionId;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PostSecondaryInstitutionResourceId = source.PostSecondaryInstitutionResourceId;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: SurveyResponse

namespace EdFi.Ods.Entities.Common.TPDM //.SurveyResponseAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveyResponseExtensionMapper
    {
        private static readonly FullName _fullName_tpdm_SurveyResponseExtension = new FullName("tpdm", "SurveyResponseExtension");
    
        public static bool SynchronizeTo(this ISurveyResponseExtension source, ISurveyResponseExtension target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SurveyResponseExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveyResponseExtension);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((mappingContract?.IsPersonIdSupported != false)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((mappingContract?.IsSourceSystemDescriptorSupported != false)
                && target.SourceSystemDescriptor != source.SourceSystemDescriptor)
            {
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISurveyResponseExtension source, ISurveyResponseExtension target, Action<ISurveyResponseExtension, ISurveyResponseExtension> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SurveyResponseExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveyResponseExtension);
    
            // Copy contextual primary key values

            // Copy non-PK properties

            if (mappingContract?.IsPersonIdSupported != false)
                target.PersonId = source.PersonId;

            if (mappingContract?.IsSourceSystemDescriptorSupported != false)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: SurveyResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.SurveyResponsePersonTargetAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveyResponsePersonTargetAssociationMapper
    {
        private static readonly FullName _fullName_tpdm_SurveyResponsePersonTargetAssociation = new FullName("tpdm", "SurveyResponsePersonTargetAssociation");
    
        public static bool SynchronizeTo(this ISurveyResponsePersonTargetAssociation source, ISurveyResponsePersonTargetAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SurveyResponsePersonTargetAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveyResponsePersonTargetAssociation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Namespace != target.Namespace)
            {
                source.Namespace = target.Namespace;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.SurveyIdentifier != target.SurveyIdentifier)
            {
                source.SurveyIdentifier = target.SurveyIdentifier;
            }
            if (source.SurveyResponseIdentifier != target.SurveyResponseIdentifier)
            {
                source.SurveyResponseIdentifier = target.SurveyResponseIdentifier;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISurveyResponsePersonTargetAssociation source, ISurveyResponsePersonTargetAssociation target, Action<ISurveyResponsePersonTargetAssociation, ISurveyResponsePersonTargetAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SurveyResponsePersonTargetAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveyResponsePersonTargetAssociation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.Namespace = source.Namespace;
            target.PersonId = source.PersonId;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.SurveyIdentifier = source.SurveyIdentifier;
            target.SurveyResponseIdentifier = source.SurveyResponseIdentifier;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
                target.SurveyResponseResourceId = source.SurveyResponseResourceId;
                target.SurveyResponseDiscriminator = source.SurveyResponseDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
// Aggregate: SurveySectionResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.SurveySectionResponsePersonTargetAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveySectionResponsePersonTargetAssociationMapper
    {
        private static readonly FullName _fullName_tpdm_SurveySectionResponsePersonTargetAssociation = new FullName("tpdm", "SurveySectionResponsePersonTargetAssociation");
    
        public static bool SynchronizeTo(this ISurveySectionResponsePersonTargetAssociation source, ISurveySectionResponsePersonTargetAssociation target)
        {
            bool isModified = false;

            // Get the mapping contract for knowing what values to synchronize through to target entity
            var mappingContract = (SurveySectionResponsePersonTargetAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveySectionResponsePersonTargetAssociation);
            

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.Namespace != target.Namespace)
            {
                source.Namespace = target.Namespace;
            }
            if (source.PersonId != target.PersonId)
            {
                source.PersonId = target.PersonId;
            }
            if (source.SourceSystemDescriptor != target.SourceSystemDescriptor)
            {
                source.SourceSystemDescriptor = target.SourceSystemDescriptor;
            }
            if (source.SurveyIdentifier != target.SurveyIdentifier)
            {
                source.SurveyIdentifier = target.SurveyIdentifier;
            }
            if (source.SurveyResponseIdentifier != target.SurveyResponseIdentifier)
            {
                source.SurveyResponseIdentifier = target.SurveyResponseIdentifier;
            }
            if (source.SurveySectionTitle != target.SurveySectionTitle)
            {
                source.SurveySectionTitle = target.SurveySectionTitle;
            }

            // Copy non-PK properties


            // Sync lists

            return isModified;
        }



        public static void MapTo(this ISurveySectionResponsePersonTargetAssociation source, ISurveySectionResponsePersonTargetAssociation target, Action<ISurveySectionResponsePersonTargetAssociation, ISurveySectionResponsePersonTargetAssociation> onMapped)
        {
            // Get the mapping contract for determining what values to map through to target
            var mappingContract = (SurveySectionResponsePersonTargetAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_tpdm_SurveySectionResponsePersonTargetAssociation);
    
            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.Namespace = source.Namespace;
            target.PersonId = source.PersonId;
            target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            target.SurveyIdentifier = source.SurveyIdentifier;
            target.SurveyResponseIdentifier = source.SurveyResponseIdentifier;
            target.SurveySectionTitle = source.SurveySectionTitle;

            // Copy non-PK properties

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.PersonResourceId = source.PersonResourceId;
                target.PersonDiscriminator = source.PersonDiscriminator;
                target.SurveySectionResponseResourceId = source.SurveySectionResponseResourceId;
                target.SurveySectionResponseDiscriminator = source.SurveySectionResponseDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            // Convert source to an ETag, if appropriate
            if (target is IHasETag entityWithETag)
                entityWithETag.ETag = GeneratedArtifactStaticDependencies.ETagProvider.GetETag(source);

            // Copy/assign LastModifiedDate, if appropriate
            if (target is IDateVersionedEntity targetDateVersionedEntity)
            {
                if (source is IHasETag etagSource)
                {
                    // Convert resource's supplied eTag value to entity's LastModifiedDate
                    targetDateVersionedEntity.LastModifiedDate = GeneratedArtifactStaticDependencies.ETagProvider.GetDateTime(etagSource.ETag);
                }
                else if (source is IDateVersionedEntity sourceDateVersionedEntity)
                {
                    // Copy LastModifiedDate, when mapping from entities to resources/entities
                    targetDateVersionedEntity.LastModifiedDate = sourceDateVersionedEntity.LastModifiedDate;
                }
            }
        }
    }

}
