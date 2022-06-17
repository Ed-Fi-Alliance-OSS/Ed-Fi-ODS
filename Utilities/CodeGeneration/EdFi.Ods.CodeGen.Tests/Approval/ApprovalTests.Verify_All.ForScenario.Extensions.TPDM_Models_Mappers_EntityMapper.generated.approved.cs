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
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: AccreditationStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.AccreditationStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class AccreditationStatusDescriptorMapper
    {
        public static bool SynchronizeTo(this IAccreditationStatusDescriptor source, IAccreditationStatusDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IAccreditationStatusDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AccreditationStatusDescriptorId != target.AccreditationStatusDescriptorId)
            {
                source.AccreditationStatusDescriptorId = target.AccreditationStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IAccreditationStatusDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IAccreditationStatusDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AccreditationStatusDescriptorId = source.AccreditationStatusDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IAccreditationStatusDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: AidTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.AidTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class AidTypeDescriptorMapper
    {
        public static bool SynchronizeTo(this IAidTypeDescriptor source, IAidTypeDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IAidTypeDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AidTypeDescriptorId != target.AidTypeDescriptorId)
            {
                source.AidTypeDescriptorId = target.AidTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IAidTypeDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IAidTypeDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AidTypeDescriptorId = source.AidTypeDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IAidTypeDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: Candidate

namespace EdFi.Ods.Entities.Common.TPDM //.CandidateAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CandidateMapper
    {
        public static bool SynchronizeTo(this ICandidate source, ICandidate target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CandidateIdentifier != target.CandidateIdentifier)
            {
                source.CandidateIdentifier = target.CandidateIdentifier;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBirthCitySupported)
                && target.BirthCity != source.BirthCity)
            {
                target.BirthCity = source.BirthCity;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBirthCountryDescriptorSupported)
                && target.BirthCountryDescriptor != source.BirthCountryDescriptor)
            {
                target.BirthCountryDescriptor = source.BirthCountryDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBirthDateSupported)
                && target.BirthDate != source.BirthDate)
            {
                target.BirthDate = source.BirthDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBirthInternationalProvinceSupported)
                && target.BirthInternationalProvince != source.BirthInternationalProvince)
            {
                target.BirthInternationalProvince = source.BirthInternationalProvince;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBirthSexDescriptorSupported)
                && target.BirthSexDescriptor != source.BirthSexDescriptor)
            {
                target.BirthSexDescriptor = source.BirthSexDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBirthStateAbbreviationDescriptorSupported)
                && target.BirthStateAbbreviationDescriptor != source.BirthStateAbbreviationDescriptor)
            {
                target.BirthStateAbbreviationDescriptor = source.BirthStateAbbreviationDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDateEnteredUSSupported)
                && target.DateEnteredUS != source.DateEnteredUS)
            {
                target.DateEnteredUS = source.DateEnteredUS;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDisplacementStatusSupported)
                && target.DisplacementStatus != source.DisplacementStatus)
            {
                target.DisplacementStatus = source.DisplacementStatus;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEconomicDisadvantagedSupported)
                && target.EconomicDisadvantaged != source.EconomicDisadvantaged)
            {
                target.EconomicDisadvantaged = source.EconomicDisadvantaged;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEnglishLanguageExamDescriptorSupported)
                && target.EnglishLanguageExamDescriptor != source.EnglishLanguageExamDescriptor)
            {
                target.EnglishLanguageExamDescriptor = source.EnglishLanguageExamDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsFirstGenerationStudentSupported)
                && target.FirstGenerationStudent != source.FirstGenerationStudent)
            {
                target.FirstGenerationStudent = source.FirstGenerationStudent;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsFirstNameSupported)
                && target.FirstName != source.FirstName)
            {
                target.FirstName = source.FirstName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGenderDescriptorSupported)
                && target.GenderDescriptor != source.GenderDescriptor)
            {
                target.GenderDescriptor = source.GenderDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGenerationCodeSuffixSupported)
                && target.GenerationCodeSuffix != source.GenerationCodeSuffix)
            {
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHispanicLatinoEthnicitySupported)
                && target.HispanicLatinoEthnicity != source.HispanicLatinoEthnicity)
            {
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLastSurnameSupported)
                && target.LastSurname != source.LastSurname)
            {
                target.LastSurname = source.LastSurname;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLimitedEnglishProficiencyDescriptorSupported)
                && target.LimitedEnglishProficiencyDescriptor != source.LimitedEnglishProficiencyDescriptor)
            {
                target.LimitedEnglishProficiencyDescriptor = source.LimitedEnglishProficiencyDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMaidenNameSupported)
                && target.MaidenName != source.MaidenName)
            {
                target.MaidenName = source.MaidenName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMiddleNameSupported)
                && target.MiddleName != source.MiddleName)
            {
                target.MiddleName = source.MiddleName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMultipleBirthStatusSupported)
                && target.MultipleBirthStatus != source.MultipleBirthStatus)
            {
                target.MultipleBirthStatus = source.MultipleBirthStatus;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPersonalTitlePrefixSupported)
                && target.PersonalTitlePrefix != source.PersonalTitlePrefix)
            {
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPersonIdSupported)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSexDescriptorSupported)
                && target.SexDescriptor != source.SexDescriptor)
            {
                target.SexDescriptor = source.SexDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSourceSystemDescriptorSupported)
                && target.SourceSystemDescriptor != source.SourceSystemDescriptor)
            {
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCandidateAddressesSupported)
            {
                isModified |=
                    source.CandidateAddresses.SynchronizeCollectionTo(
                        target.CandidateAddresses,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateAddressIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateDisabilitiesSupported)
            {
                isModified |=
                    source.CandidateDisabilities.SynchronizeCollectionTo(
                        target.CandidateDisabilities,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateDisabilityIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateElectronicMailsSupported)
            {
                isModified |=
                    source.CandidateElectronicMails.SynchronizeCollectionTo(
                        target.CandidateElectronicMails,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateElectronicMailIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateLanguagesSupported)
            {
                isModified |=
                    source.CandidateLanguages.SynchronizeCollectionTo(
                        target.CandidateLanguages,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateLanguageIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateOtherNamesSupported)
            {
                isModified |=
                    source.CandidateOtherNames.SynchronizeCollectionTo(
                        target.CandidateOtherNames,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateOtherNameIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidatePersonalIdentificationDocumentsSupported)
            {
                isModified |=
                    source.CandidatePersonalIdentificationDocuments.SynchronizeCollectionTo(
                        target.CandidatePersonalIdentificationDocuments,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidatePersonalIdentificationDocumentIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateRacesSupported)
            {
                isModified |=
                    source.CandidateRaces.SynchronizeCollectionTo(
                        target.CandidateRaces,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateRaceIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateTelephonesSupported)
            {
                isModified |=
                    source.CandidateTelephones.SynchronizeCollectionTo(
                        target.CandidateTelephones,
                        onChildAdded: child =>
                            {
                                child.Candidate = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateTelephoneIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICandidate source, ICandidate target, Action<ICandidate, ICandidate> onMapped)
        {
            var sourceSynchSupport = source as ICandidateSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CandidateIdentifier = source.CandidateIdentifier;

            // Copy non-PK properties

            if (sourceSynchSupport.IsBirthCitySupported)
                target.BirthCity = source.BirthCity;
            else
                targetSynchSupport.IsBirthCitySupported = false;

            if (sourceSynchSupport.IsBirthCountryDescriptorSupported)
                target.BirthCountryDescriptor = source.BirthCountryDescriptor;
            else
                targetSynchSupport.IsBirthCountryDescriptorSupported = false;

            if (sourceSynchSupport.IsBirthDateSupported)
                target.BirthDate = source.BirthDate;
            else
                targetSynchSupport.IsBirthDateSupported = false;

            if (sourceSynchSupport.IsBirthInternationalProvinceSupported)
                target.BirthInternationalProvince = source.BirthInternationalProvince;
            else
                targetSynchSupport.IsBirthInternationalProvinceSupported = false;

            if (sourceSynchSupport.IsBirthSexDescriptorSupported)
                target.BirthSexDescriptor = source.BirthSexDescriptor;
            else
                targetSynchSupport.IsBirthSexDescriptorSupported = false;

            if (sourceSynchSupport.IsBirthStateAbbreviationDescriptorSupported)
                target.BirthStateAbbreviationDescriptor = source.BirthStateAbbreviationDescriptor;
            else
                targetSynchSupport.IsBirthStateAbbreviationDescriptorSupported = false;

            if (sourceSynchSupport.IsDateEnteredUSSupported)
                target.DateEnteredUS = source.DateEnteredUS;
            else
                targetSynchSupport.IsDateEnteredUSSupported = false;

            if (sourceSynchSupport.IsDisplacementStatusSupported)
                target.DisplacementStatus = source.DisplacementStatus;
            else
                targetSynchSupport.IsDisplacementStatusSupported = false;

            if (sourceSynchSupport.IsEconomicDisadvantagedSupported)
                target.EconomicDisadvantaged = source.EconomicDisadvantaged;
            else
                targetSynchSupport.IsEconomicDisadvantagedSupported = false;

            if (sourceSynchSupport.IsEnglishLanguageExamDescriptorSupported)
                target.EnglishLanguageExamDescriptor = source.EnglishLanguageExamDescriptor;
            else
                targetSynchSupport.IsEnglishLanguageExamDescriptorSupported = false;

            if (sourceSynchSupport.IsFirstGenerationStudentSupported)
                target.FirstGenerationStudent = source.FirstGenerationStudent;
            else
                targetSynchSupport.IsFirstGenerationStudentSupported = false;

            if (sourceSynchSupport.IsFirstNameSupported)
                target.FirstName = source.FirstName;
            else
                targetSynchSupport.IsFirstNameSupported = false;

            if (sourceSynchSupport.IsGenderDescriptorSupported)
                target.GenderDescriptor = source.GenderDescriptor;
            else
                targetSynchSupport.IsGenderDescriptorSupported = false;

            if (sourceSynchSupport.IsGenerationCodeSuffixSupported)
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
            else
                targetSynchSupport.IsGenerationCodeSuffixSupported = false;

            if (sourceSynchSupport.IsHispanicLatinoEthnicitySupported)
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            else
                targetSynchSupport.IsHispanicLatinoEthnicitySupported = false;

            if (sourceSynchSupport.IsLastSurnameSupported)
                target.LastSurname = source.LastSurname;
            else
                targetSynchSupport.IsLastSurnameSupported = false;

            if (sourceSynchSupport.IsLimitedEnglishProficiencyDescriptorSupported)
                target.LimitedEnglishProficiencyDescriptor = source.LimitedEnglishProficiencyDescriptor;
            else
                targetSynchSupport.IsLimitedEnglishProficiencyDescriptorSupported = false;

            if (sourceSynchSupport.IsMaidenNameSupported)
                target.MaidenName = source.MaidenName;
            else
                targetSynchSupport.IsMaidenNameSupported = false;

            if (sourceSynchSupport.IsMiddleNameSupported)
                target.MiddleName = source.MiddleName;
            else
                targetSynchSupport.IsMiddleNameSupported = false;

            if (sourceSynchSupport.IsMultipleBirthStatusSupported)
                target.MultipleBirthStatus = source.MultipleBirthStatus;
            else
                targetSynchSupport.IsMultipleBirthStatusSupported = false;

            if (sourceSynchSupport.IsPersonalTitlePrefixSupported)
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
            else
                targetSynchSupport.IsPersonalTitlePrefixSupported = false;

            if (sourceSynchSupport.IsPersonIdSupported)
                target.PersonId = source.PersonId;
            else
                targetSynchSupport.IsPersonIdSupported = false;

            if (sourceSynchSupport.IsSexDescriptorSupported)
                target.SexDescriptor = source.SexDescriptor;
            else
                targetSynchSupport.IsSexDescriptorSupported = false;

            if (sourceSynchSupport.IsSourceSystemDescriptorSupported)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            else
                targetSynchSupport.IsSourceSystemDescriptorSupported = false;

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

            if (sourceSynchSupport.IsCandidateAddressesSupported)
            {
                targetSynchSupport.IsCandidateAddressIncluded = sourceSynchSupport.IsCandidateAddressIncluded;
                source.CandidateAddresses.MapCollectionTo(target.CandidateAddresses, target);
            }
            else
            {
                targetSynchSupport.IsCandidateAddressesSupported = false;
            }

            if (sourceSynchSupport.IsCandidateDisabilitiesSupported)
            {
                targetSynchSupport.IsCandidateDisabilityIncluded = sourceSynchSupport.IsCandidateDisabilityIncluded;
                source.CandidateDisabilities.MapCollectionTo(target.CandidateDisabilities, target);
            }
            else
            {
                targetSynchSupport.IsCandidateDisabilitiesSupported = false;
            }

            if (sourceSynchSupport.IsCandidateElectronicMailsSupported)
            {
                targetSynchSupport.IsCandidateElectronicMailIncluded = sourceSynchSupport.IsCandidateElectronicMailIncluded;
                source.CandidateElectronicMails.MapCollectionTo(target.CandidateElectronicMails, target);
            }
            else
            {
                targetSynchSupport.IsCandidateElectronicMailsSupported = false;
            }

            if (sourceSynchSupport.IsCandidateLanguagesSupported)
            {
                targetSynchSupport.IsCandidateLanguageIncluded = sourceSynchSupport.IsCandidateLanguageIncluded;
                source.CandidateLanguages.MapCollectionTo(target.CandidateLanguages, target);
            }
            else
            {
                targetSynchSupport.IsCandidateLanguagesSupported = false;
            }

            if (sourceSynchSupport.IsCandidateOtherNamesSupported)
            {
                targetSynchSupport.IsCandidateOtherNameIncluded = sourceSynchSupport.IsCandidateOtherNameIncluded;
                source.CandidateOtherNames.MapCollectionTo(target.CandidateOtherNames, target);
            }
            else
            {
                targetSynchSupport.IsCandidateOtherNamesSupported = false;
            }

            if (sourceSynchSupport.IsCandidatePersonalIdentificationDocumentsSupported)
            {
                targetSynchSupport.IsCandidatePersonalIdentificationDocumentIncluded = sourceSynchSupport.IsCandidatePersonalIdentificationDocumentIncluded;
                source.CandidatePersonalIdentificationDocuments.MapCollectionTo(target.CandidatePersonalIdentificationDocuments, target);
            }
            else
            {
                targetSynchSupport.IsCandidatePersonalIdentificationDocumentsSupported = false;
            }

            if (sourceSynchSupport.IsCandidateRacesSupported)
            {
                targetSynchSupport.IsCandidateRaceIncluded = sourceSynchSupport.IsCandidateRaceIncluded;
                source.CandidateRaces.MapCollectionTo(target.CandidateRaces, target);
            }
            else
            {
                targetSynchSupport.IsCandidateRacesSupported = false;
            }

            if (sourceSynchSupport.IsCandidateTelephonesSupported)
            {
                targetSynchSupport.IsCandidateTelephoneIncluded = sourceSynchSupport.IsCandidateTelephoneIncluded;
                source.CandidateTelephones.MapCollectionTo(target.CandidateTelephones, target);
            }
            else
            {
                targetSynchSupport.IsCandidateTelephonesSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateSynchronizationSourceSupport 
    {
        bool IsBirthCitySupported { get; set; }
        bool IsBirthCountryDescriptorSupported { get; set; }
        bool IsBirthDateSupported { get; set; }
        bool IsBirthInternationalProvinceSupported { get; set; }
        bool IsBirthSexDescriptorSupported { get; set; }
        bool IsBirthStateAbbreviationDescriptorSupported { get; set; }
        bool IsCandidateAddressesSupported { get; set; }
        bool IsCandidateDisabilitiesSupported { get; set; }
        bool IsCandidateElectronicMailsSupported { get; set; }
        bool IsCandidateLanguagesSupported { get; set; }
        bool IsCandidateOtherNamesSupported { get; set; }
        bool IsCandidatePersonalIdentificationDocumentsSupported { get; set; }
        bool IsCandidateRacesSupported { get; set; }
        bool IsCandidateTelephonesSupported { get; set; }
        bool IsDateEnteredUSSupported { get; set; }
        bool IsDisplacementStatusSupported { get; set; }
        bool IsEconomicDisadvantagedSupported { get; set; }
        bool IsEnglishLanguageExamDescriptorSupported { get; set; }
        bool IsFirstGenerationStudentSupported { get; set; }
        bool IsFirstNameSupported { get; set; }
        bool IsGenderDescriptorSupported { get; set; }
        bool IsGenerationCodeSuffixSupported { get; set; }
        bool IsHispanicLatinoEthnicitySupported { get; set; }
        bool IsLastSurnameSupported { get; set; }
        bool IsLimitedEnglishProficiencyDescriptorSupported { get; set; }
        bool IsMaidenNameSupported { get; set; }
        bool IsMiddleNameSupported { get; set; }
        bool IsMultipleBirthStatusSupported { get; set; }
        bool IsPersonalTitlePrefixSupported { get; set; }
        bool IsPersonIdSupported { get; set; }
        bool IsSexDescriptorSupported { get; set; }
        bool IsSourceSystemDescriptorSupported { get; set; }
        Func<ICandidateAddress, bool> IsCandidateAddressIncluded { get; set; }
        Func<ICandidateDisability, bool> IsCandidateDisabilityIncluded { get; set; }
        Func<ICandidateElectronicMail, bool> IsCandidateElectronicMailIncluded { get; set; }
        Func<ICandidateLanguage, bool> IsCandidateLanguageIncluded { get; set; }
        Func<ICandidateOtherName, bool> IsCandidateOtherNameIncluded { get; set; }
        Func<ICandidatePersonalIdentificationDocument, bool> IsCandidatePersonalIdentificationDocumentIncluded { get; set; }
        Func<ICandidateRace, bool> IsCandidateRaceIncluded { get; set; }
        Func<ICandidateTelephone, bool> IsCandidateTelephoneIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateAddressMapper
    {
        public static bool SynchronizeTo(this ICandidateAddress source, ICandidateAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateAddressSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsApartmentRoomSuiteNumberSupported)
                && target.ApartmentRoomSuiteNumber != source.ApartmentRoomSuiteNumber)
            {
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBuildingSiteNumberSupported)
                && target.BuildingSiteNumber != source.BuildingSiteNumber)
            {
                target.BuildingSiteNumber = source.BuildingSiteNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCongressionalDistrictSupported)
                && target.CongressionalDistrict != source.CongressionalDistrict)
            {
                target.CongressionalDistrict = source.CongressionalDistrict;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCountyFIPSCodeSupported)
                && target.CountyFIPSCode != source.CountyFIPSCode)
            {
                target.CountyFIPSCode = source.CountyFIPSCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDoNotPublishIndicatorSupported)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLatitudeSupported)
                && target.Latitude != source.Latitude)
            {
                target.Latitude = source.Latitude;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLocaleDescriptorSupported)
                && target.LocaleDescriptor != source.LocaleDescriptor)
            {
                target.LocaleDescriptor = source.LocaleDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLongitudeSupported)
                && target.Longitude != source.Longitude)
            {
                target.Longitude = source.Longitude;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNameOfCountySupported)
                && target.NameOfCounty != source.NameOfCounty)
            {
                target.NameOfCounty = source.NameOfCounty;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCandidateAddressPeriodsSupported)
            {
                isModified |=
                    source.CandidateAddressPeriods.SynchronizeCollectionTo(
                        target.CandidateAddressPeriods,
                        onChildAdded: child =>
                            {
                                child.CandidateAddress = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateAddressPeriodIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateAddress source, ICandidateAddress target, Action<ICandidateAddress, ICandidateAddress> onMapped)
        {
            var sourceSynchSupport = source as ICandidateAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateAddressSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.AddressTypeDescriptor = source.AddressTypeDescriptor;
            target.City = source.City;
            target.PostalCode = source.PostalCode;
            target.StateAbbreviationDescriptor = source.StateAbbreviationDescriptor;
            target.StreetNumberName = source.StreetNumberName;

            // Copy non-PK properties

            if (sourceSynchSupport.IsApartmentRoomSuiteNumberSupported)
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
            else
                targetSynchSupport.IsApartmentRoomSuiteNumberSupported = false;

            if (sourceSynchSupport.IsBuildingSiteNumberSupported)
                target.BuildingSiteNumber = source.BuildingSiteNumber;
            else
                targetSynchSupport.IsBuildingSiteNumberSupported = false;

            if (sourceSynchSupport.IsCongressionalDistrictSupported)
                target.CongressionalDistrict = source.CongressionalDistrict;
            else
                targetSynchSupport.IsCongressionalDistrictSupported = false;

            if (sourceSynchSupport.IsCountyFIPSCodeSupported)
                target.CountyFIPSCode = source.CountyFIPSCode;
            else
                targetSynchSupport.IsCountyFIPSCodeSupported = false;

            if (sourceSynchSupport.IsDoNotPublishIndicatorSupported)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
            else
                targetSynchSupport.IsDoNotPublishIndicatorSupported = false;

            if (sourceSynchSupport.IsLatitudeSupported)
                target.Latitude = source.Latitude;
            else
                targetSynchSupport.IsLatitudeSupported = false;

            if (sourceSynchSupport.IsLocaleDescriptorSupported)
                target.LocaleDescriptor = source.LocaleDescriptor;
            else
                targetSynchSupport.IsLocaleDescriptorSupported = false;

            if (sourceSynchSupport.IsLongitudeSupported)
                target.Longitude = source.Longitude;
            else
                targetSynchSupport.IsLongitudeSupported = false;

            if (sourceSynchSupport.IsNameOfCountySupported)
                target.NameOfCounty = source.NameOfCounty;
            else
                targetSynchSupport.IsNameOfCountySupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsCandidateAddressPeriodsSupported)
            {
                targetSynchSupport.IsCandidateAddressPeriodIncluded = sourceSynchSupport.IsCandidateAddressPeriodIncluded;
                source.CandidateAddressPeriods.MapCollectionTo(target.CandidateAddressPeriods, target);
            }
            else
            {
                targetSynchSupport.IsCandidateAddressPeriodsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateAddressSynchronizationSourceSupport 
    {
        bool IsApartmentRoomSuiteNumberSupported { get; set; }
        bool IsBuildingSiteNumberSupported { get; set; }
        bool IsCandidateAddressPeriodsSupported { get; set; }
        bool IsCongressionalDistrictSupported { get; set; }
        bool IsCountyFIPSCodeSupported { get; set; }
        bool IsDoNotPublishIndicatorSupported { get; set; }
        bool IsLatitudeSupported { get; set; }
        bool IsLocaleDescriptorSupported { get; set; }
        bool IsLongitudeSupported { get; set; }
        bool IsNameOfCountySupported { get; set; }
        Func<ICandidateAddressPeriod, bool> IsCandidateAddressPeriodIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateAddressPeriodMapper
    {
        public static bool SynchronizeTo(this ICandidateAddressPeriod source, ICandidateAddressPeriod target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateAddressPeriodSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.BeginDate != target.BeginDate)
            {
                source.BeginDate = target.BeginDate;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
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
            var sourceSynchSupport = source as ICandidateAddressPeriodSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateAddressPeriodSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;

            // Copy non-PK properties

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateAddressPeriodSynchronizationSourceSupport 
    {
        bool IsEndDateSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateDisabilityMapper
    {
        public static bool SynchronizeTo(this ICandidateDisability source, ICandidateDisability target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateDisabilitySynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.DisabilityDescriptor != target.DisabilityDescriptor)
            {
                source.DisabilityDescriptor = target.DisabilityDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsDisabilityDeterminationSourceTypeDescriptorSupported)
                && target.DisabilityDeterminationSourceTypeDescriptor != source.DisabilityDeterminationSourceTypeDescriptor)
            {
                target.DisabilityDeterminationSourceTypeDescriptor = source.DisabilityDeterminationSourceTypeDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDisabilityDiagnosisSupported)
                && target.DisabilityDiagnosis != source.DisabilityDiagnosis)
            {
                target.DisabilityDiagnosis = source.DisabilityDiagnosis;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOrderOfDisabilitySupported)
                && target.OrderOfDisability != source.OrderOfDisability)
            {
                target.OrderOfDisability = source.OrderOfDisability;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCandidateDisabilityDesignationsSupported)
            {
                isModified |=
                    source.CandidateDisabilityDesignations.SynchronizeCollectionTo(
                        target.CandidateDisabilityDesignations,
                        onChildAdded: child =>
                            {
                                child.CandidateDisability = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateDisabilityDesignationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateDisability source, ICandidateDisability target, Action<ICandidateDisability, ICandidateDisability> onMapped)
        {
            var sourceSynchSupport = source as ICandidateDisabilitySynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateDisabilitySynchronizationSourceSupport;

            // Copy contextual primary key values
            target.DisabilityDescriptor = source.DisabilityDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsDisabilityDeterminationSourceTypeDescriptorSupported)
                target.DisabilityDeterminationSourceTypeDescriptor = source.DisabilityDeterminationSourceTypeDescriptor;
            else
                targetSynchSupport.IsDisabilityDeterminationSourceTypeDescriptorSupported = false;

            if (sourceSynchSupport.IsDisabilityDiagnosisSupported)
                target.DisabilityDiagnosis = source.DisabilityDiagnosis;
            else
                targetSynchSupport.IsDisabilityDiagnosisSupported = false;

            if (sourceSynchSupport.IsOrderOfDisabilitySupported)
                target.OrderOfDisability = source.OrderOfDisability;
            else
                targetSynchSupport.IsOrderOfDisabilitySupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsCandidateDisabilityDesignationsSupported)
            {
                targetSynchSupport.IsCandidateDisabilityDesignationIncluded = sourceSynchSupport.IsCandidateDisabilityDesignationIncluded;
                source.CandidateDisabilityDesignations.MapCollectionTo(target.CandidateDisabilityDesignations, target);
            }
            else
            {
                targetSynchSupport.IsCandidateDisabilityDesignationsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateDisabilitySynchronizationSourceSupport 
    {
        bool IsCandidateDisabilityDesignationsSupported { get; set; }
        bool IsDisabilityDeterminationSourceTypeDescriptorSupported { get; set; }
        bool IsDisabilityDiagnosisSupported { get; set; }
        bool IsOrderOfDisabilitySupported { get; set; }
        Func<ICandidateDisabilityDesignation, bool> IsCandidateDisabilityDesignationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateDisabilityDesignationMapper
    {
        public static bool SynchronizeTo(this ICandidateDisabilityDesignation source, ICandidateDisabilityDesignation target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateDisabilityDesignationSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ICandidateDisabilityDesignationSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateDisabilityDesignationSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateDisabilityDesignationSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateElectronicMailMapper
    {
        public static bool SynchronizeTo(this ICandidateElectronicMail source, ICandidateElectronicMail target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateElectronicMailSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsDoNotPublishIndicatorSupported)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPrimaryEmailAddressIndicatorSupported)
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
            var sourceSynchSupport = source as ICandidateElectronicMailSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateElectronicMailSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.ElectronicMailAddress = source.ElectronicMailAddress;
            target.ElectronicMailTypeDescriptor = source.ElectronicMailTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsDoNotPublishIndicatorSupported)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
            else
                targetSynchSupport.IsDoNotPublishIndicatorSupported = false;

            if (sourceSynchSupport.IsPrimaryEmailAddressIndicatorSupported)
                target.PrimaryEmailAddressIndicator = source.PrimaryEmailAddressIndicator;
            else
                targetSynchSupport.IsPrimaryEmailAddressIndicatorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateElectronicMailSynchronizationSourceSupport 
    {
        bool IsDoNotPublishIndicatorSupported { get; set; }
        bool IsPrimaryEmailAddressIndicatorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateLanguageMapper
    {
        public static bool SynchronizeTo(this ICandidateLanguage source, ICandidateLanguage target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateLanguageSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.LanguageDescriptor != target.LanguageDescriptor)
            {
                source.LanguageDescriptor = target.LanguageDescriptor;
            }

            // Copy non-PK properties


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCandidateLanguageUsesSupported)
            {
                isModified |=
                    source.CandidateLanguageUses.SynchronizeCollectionTo(
                        target.CandidateLanguageUses,
                        onChildAdded: child =>
                            {
                                child.CandidateLanguage = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateLanguageUseIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateLanguage source, ICandidateLanguage target, Action<ICandidateLanguage, ICandidateLanguage> onMapped)
        {
            var sourceSynchSupport = source as ICandidateLanguageSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateLanguageSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.LanguageDescriptor = source.LanguageDescriptor;

            // Copy non-PK properties

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsCandidateLanguageUsesSupported)
            {
                targetSynchSupport.IsCandidateLanguageUseIncluded = sourceSynchSupport.IsCandidateLanguageUseIncluded;
                source.CandidateLanguageUses.MapCollectionTo(target.CandidateLanguageUses, target);
            }
            else
            {
                targetSynchSupport.IsCandidateLanguageUsesSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateLanguageSynchronizationSourceSupport 
    {
        bool IsCandidateLanguageUsesSupported { get; set; }
        Func<ICandidateLanguageUse, bool> IsCandidateLanguageUseIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateLanguageUseMapper
    {
        public static bool SynchronizeTo(this ICandidateLanguageUse source, ICandidateLanguageUse target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateLanguageUseSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ICandidateLanguageUseSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateLanguageUseSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateLanguageUseSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateOtherNameMapper
    {
        public static bool SynchronizeTo(this ICandidateOtherName source, ICandidateOtherName target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateOtherNameSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.OtherNameTypeDescriptor != target.OtherNameTypeDescriptor)
            {
                source.OtherNameTypeDescriptor = target.OtherNameTypeDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsFirstNameSupported)
                && target.FirstName != source.FirstName)
            {
                target.FirstName = source.FirstName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGenerationCodeSuffixSupported)
                && target.GenerationCodeSuffix != source.GenerationCodeSuffix)
            {
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLastSurnameSupported)
                && target.LastSurname != source.LastSurname)
            {
                target.LastSurname = source.LastSurname;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMiddleNameSupported)
                && target.MiddleName != source.MiddleName)
            {
                target.MiddleName = source.MiddleName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPersonalTitlePrefixSupported)
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
            var sourceSynchSupport = source as ICandidateOtherNameSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateOtherNameSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.OtherNameTypeDescriptor = source.OtherNameTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsFirstNameSupported)
                target.FirstName = source.FirstName;
            else
                targetSynchSupport.IsFirstNameSupported = false;

            if (sourceSynchSupport.IsGenerationCodeSuffixSupported)
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
            else
                targetSynchSupport.IsGenerationCodeSuffixSupported = false;

            if (sourceSynchSupport.IsLastSurnameSupported)
                target.LastSurname = source.LastSurname;
            else
                targetSynchSupport.IsLastSurnameSupported = false;

            if (sourceSynchSupport.IsMiddleNameSupported)
                target.MiddleName = source.MiddleName;
            else
                targetSynchSupport.IsMiddleNameSupported = false;

            if (sourceSynchSupport.IsPersonalTitlePrefixSupported)
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
            else
                targetSynchSupport.IsPersonalTitlePrefixSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateOtherNameSynchronizationSourceSupport 
    {
        bool IsFirstNameSupported { get; set; }
        bool IsGenerationCodeSuffixSupported { get; set; }
        bool IsLastSurnameSupported { get; set; }
        bool IsMiddleNameSupported { get; set; }
        bool IsPersonalTitlePrefixSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidatePersonalIdentificationDocumentMapper
    {
        public static bool SynchronizeTo(this ICandidatePersonalIdentificationDocument source, ICandidatePersonalIdentificationDocument target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsDocumentExpirationDateSupported)
                && target.DocumentExpirationDate != source.DocumentExpirationDate)
            {
                target.DocumentExpirationDate = source.DocumentExpirationDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDocumentTitleSupported)
                && target.DocumentTitle != source.DocumentTitle)
            {
                target.DocumentTitle = source.DocumentTitle;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIssuerCountryDescriptorSupported)
                && target.IssuerCountryDescriptor != source.IssuerCountryDescriptor)
            {
                target.IssuerCountryDescriptor = source.IssuerCountryDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIssuerDocumentIdentificationCodeSupported)
                && target.IssuerDocumentIdentificationCode != source.IssuerDocumentIdentificationCode)
            {
                target.IssuerDocumentIdentificationCode = source.IssuerDocumentIdentificationCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsIssuerNameSupported)
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
            var sourceSynchSupport = source as ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.IdentificationDocumentUseDescriptor = source.IdentificationDocumentUseDescriptor;
            target.PersonalInformationVerificationDescriptor = source.PersonalInformationVerificationDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsDocumentExpirationDateSupported)
                target.DocumentExpirationDate = source.DocumentExpirationDate;
            else
                targetSynchSupport.IsDocumentExpirationDateSupported = false;

            if (sourceSynchSupport.IsDocumentTitleSupported)
                target.DocumentTitle = source.DocumentTitle;
            else
                targetSynchSupport.IsDocumentTitleSupported = false;

            if (sourceSynchSupport.IsIssuerCountryDescriptorSupported)
                target.IssuerCountryDescriptor = source.IssuerCountryDescriptor;
            else
                targetSynchSupport.IsIssuerCountryDescriptorSupported = false;

            if (sourceSynchSupport.IsIssuerDocumentIdentificationCodeSupported)
                target.IssuerDocumentIdentificationCode = source.IssuerDocumentIdentificationCode;
            else
                targetSynchSupport.IsIssuerDocumentIdentificationCodeSupported = false;

            if (sourceSynchSupport.IsIssuerNameSupported)
                target.IssuerName = source.IssuerName;
            else
                targetSynchSupport.IsIssuerNameSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidatePersonalIdentificationDocumentSynchronizationSourceSupport 
    {
        bool IsDocumentExpirationDateSupported { get; set; }
        bool IsDocumentTitleSupported { get; set; }
        bool IsIssuerCountryDescriptorSupported { get; set; }
        bool IsIssuerDocumentIdentificationCodeSupported { get; set; }
        bool IsIssuerNameSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateRaceMapper
    {
        public static bool SynchronizeTo(this ICandidateRace source, ICandidateRace target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateRaceSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ICandidateRaceSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateRaceSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateRaceSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateTelephoneMapper
    {
        public static bool SynchronizeTo(this ICandidateTelephone source, ICandidateTelephone target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateTelephoneSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsDoNotPublishIndicatorSupported)
                && target.DoNotPublishIndicator != source.DoNotPublishIndicator)
            {
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsOrderOfPrioritySupported)
                && target.OrderOfPriority != source.OrderOfPriority)
            {
                target.OrderOfPriority = source.OrderOfPriority;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTextMessageCapabilityIndicatorSupported)
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
            var sourceSynchSupport = source as ICandidateTelephoneSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateTelephoneSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.TelephoneNumber = source.TelephoneNumber;
            target.TelephoneNumberTypeDescriptor = source.TelephoneNumberTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsDoNotPublishIndicatorSupported)
                target.DoNotPublishIndicator = source.DoNotPublishIndicator;
            else
                targetSynchSupport.IsDoNotPublishIndicatorSupported = false;

            if (sourceSynchSupport.IsOrderOfPrioritySupported)
                target.OrderOfPriority = source.OrderOfPriority;
            else
                targetSynchSupport.IsOrderOfPrioritySupported = false;

            if (sourceSynchSupport.IsTextMessageCapabilityIndicatorSupported)
                target.TextMessageCapabilityIndicator = source.TextMessageCapabilityIndicator;
            else
                targetSynchSupport.IsTextMessageCapabilityIndicatorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateTelephoneSynchronizationSourceSupport 
    {
        bool IsDoNotPublishIndicatorSupported { get; set; }
        bool IsOrderOfPrioritySupported { get; set; }
        bool IsTextMessageCapabilityIndicatorSupported { get; set; }
    }

}
// Aggregate: CandidateEducatorPreparationProgramAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.CandidateEducatorPreparationProgramAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationMapper
    {
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociation source, ICandidateEducatorPreparationProgramAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEPPProgramPathwayDescriptorSupported)
                && target.EPPProgramPathwayDescriptor != source.EPPProgramPathwayDescriptor)
            {
                target.EPPProgramPathwayDescriptor = source.EPPProgramPathwayDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReasonExitedDescriptorSupported)
                && target.ReasonExitedDescriptor != source.ReasonExitedDescriptor)
            {
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported)
            {
                isModified |=
                    source.CandidateEducatorPreparationProgramAssociationCohortYears.SynchronizeCollectionTo(
                        target.CandidateEducatorPreparationProgramAssociationCohortYears,
                        onChildAdded: child =>
                            {
                                child.CandidateEducatorPreparationProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported)
            {
                isModified |=
                    source.CandidateEducatorPreparationProgramAssociationDegreeSpecializations.SynchronizeCollectionTo(
                        target.CandidateEducatorPreparationProgramAssociationDegreeSpecializations,
                        onChildAdded: child =>
                            {
                                child.CandidateEducatorPreparationProgramAssociation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICandidateEducatorPreparationProgramAssociation source, ICandidateEducatorPreparationProgramAssociation target, Action<ICandidateEducatorPreparationProgramAssociation, ICandidateEducatorPreparationProgramAssociation> onMapped)
        {
            var sourceSynchSupport = source as ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.BeginDate = source.BeginDate;
            target.CandidateIdentifier = source.CandidateIdentifier;
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsEPPProgramPathwayDescriptorSupported)
                target.EPPProgramPathwayDescriptor = source.EPPProgramPathwayDescriptor;
            else
                targetSynchSupport.IsEPPProgramPathwayDescriptorSupported = false;

            if (sourceSynchSupport.IsReasonExitedDescriptorSupported)
                target.ReasonExitedDescriptor = source.ReasonExitedDescriptor;
            else
                targetSynchSupport.IsReasonExitedDescriptorSupported = false;

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

            if (sourceSynchSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported)
            {
                targetSynchSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded = sourceSynchSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded;
                source.CandidateEducatorPreparationProgramAssociationCohortYears.MapCollectionTo(target.CandidateEducatorPreparationProgramAssociationCohortYears, target);
            }
            else
            {
                targetSynchSupport.IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported = false;
            }

            if (sourceSynchSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported)
            {
                targetSynchSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded = sourceSynchSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded;
                source.CandidateEducatorPreparationProgramAssociationDegreeSpecializations.MapCollectionTo(target.CandidateEducatorPreparationProgramAssociationDegreeSpecializations, target);
            }
            else
            {
                targetSynchSupport.IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationSynchronizationSourceSupport 
    {
        bool IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported { get; set; }
        bool IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported { get; set; }
        bool IsEndDateSupported { get; set; }
        bool IsEPPProgramPathwayDescriptorSupported { get; set; }
        bool IsReasonExitedDescriptorSupported { get; set; }
        Func<ICandidateEducatorPreparationProgramAssociationCohortYear, bool> IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded { get; set; }
        Func<ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, bool> IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationCohortYearMapper
    {
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociationCohortYear source, ICandidateEducatorPreparationProgramAssociationCohortYear target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsTermDescriptorSupported)
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
            var sourceSynchSupport = source as ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.CohortYearTypeDescriptor = source.CohortYearTypeDescriptor;
            target.SchoolYear = source.SchoolYear;

            // Copy non-PK properties

            if (sourceSynchSupport.IsTermDescriptorSupported)
                target.TermDescriptor = source.TermDescriptor;
            else
                targetSynchSupport.IsTermDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationCohortYearSynchronizationSourceSupport 
    {
        bool IsTermDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CandidateEducatorPreparationProgramAssociationDegreeSpecializationMapper
    {
        public static bool SynchronizeTo(this ICandidateEducatorPreparationProgramAssociationDegreeSpecialization source, ICandidateEducatorPreparationProgramAssociationDegreeSpecialization target)
        {
            bool isModified = false;

            var sourceSupport = source as ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.MajorSpecialization != target.MajorSpecialization)
            {
                source.MajorSpecialization = target.MajorSpecialization;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinorSpecializationSupported)
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
            var sourceSynchSupport = source as ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport;
            var targetSynchSupport = target as ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.MajorSpecialization = source.MajorSpecialization;

            // Copy non-PK properties

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsMinorSpecializationSupported)
                target.MinorSpecialization = source.MinorSpecialization;
            else
                targetSynchSupport.IsMinorSpecializationSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationDegreeSpecializationSynchronizationSourceSupport 
    {
        bool IsEndDateSupported { get; set; }
        bool IsMinorSpecializationSupported { get; set; }
    }

}
// Aggregate: CertificationRouteDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CertificationRouteDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CertificationRouteDescriptorMapper
    {
        public static bool SynchronizeTo(this ICertificationRouteDescriptor source, ICertificationRouteDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as ICertificationRouteDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CertificationRouteDescriptorId != target.CertificationRouteDescriptorId)
            {
                source.CertificationRouteDescriptorId = target.CertificationRouteDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as ICertificationRouteDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as ICertificationRouteDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CertificationRouteDescriptorId = source.CertificationRouteDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICertificationRouteDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: CoteachingStyleObservedDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CoteachingStyleObservedDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CoteachingStyleObservedDescriptorMapper
    {
        public static bool SynchronizeTo(this ICoteachingStyleObservedDescriptor source, ICoteachingStyleObservedDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as ICoteachingStyleObservedDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CoteachingStyleObservedDescriptorId != target.CoteachingStyleObservedDescriptorId)
            {
                source.CoteachingStyleObservedDescriptorId = target.CoteachingStyleObservedDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as ICoteachingStyleObservedDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as ICoteachingStyleObservedDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CoteachingStyleObservedDescriptorId = source.CoteachingStyleObservedDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICoteachingStyleObservedDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: Credential

namespace EdFi.Ods.Entities.Common.TPDM //.CredentialAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CredentialExtensionMapper
    {
        public static bool SynchronizeTo(this ICredentialExtension source, ICredentialExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as ICredentialExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.Credential as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("TPDM"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBoardCertificationIndicatorSupported)
                && target.BoardCertificationIndicator != source.BoardCertificationIndicator)
            {
                target.BoardCertificationIndicator = source.BoardCertificationIndicator;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCertificationRouteDescriptorSupported)
                && target.CertificationRouteDescriptor != source.CertificationRouteDescriptor)
            {
                target.CertificationRouteDescriptor = source.CertificationRouteDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCertificationTitleSupported)
                && target.CertificationTitle != source.CertificationTitle)
            {
                target.CertificationTitle = source.CertificationTitle;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCredentialStatusDateSupported)
                && target.CredentialStatusDate != source.CredentialStatusDate)
            {
                target.CredentialStatusDate = source.CredentialStatusDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCredentialStatusDescriptorSupported)
                && target.CredentialStatusDescriptor != source.CredentialStatusDescriptor)
            {
                target.CredentialStatusDescriptor = source.CredentialStatusDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEducatorRoleDescriptorSupported)
                && target.EducatorRoleDescriptor != source.EducatorRoleDescriptor)
            {
                target.EducatorRoleDescriptor = source.EducatorRoleDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPersonIdSupported)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSourceSystemDescriptorSupported)
                && target.SourceSystemDescriptor != source.SourceSystemDescriptor)
            {
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsCredentialStudentAcademicRecordsSupported)
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
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsCredentialStudentAcademicRecordIncluded);
            }


            return isModified;
        }



        public static void MapTo(this ICredentialExtension source, ICredentialExtension target, Action<ICredentialExtension, ICredentialExtension> onMapped)
        {
            var sourceSynchSupport = source as ICredentialExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as ICredentialExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsBoardCertificationIndicatorSupported)
                target.BoardCertificationIndicator = source.BoardCertificationIndicator;
            else
                targetSynchSupport.IsBoardCertificationIndicatorSupported = false;

            if (sourceSynchSupport.IsCertificationRouteDescriptorSupported)
                target.CertificationRouteDescriptor = source.CertificationRouteDescriptor;
            else
                targetSynchSupport.IsCertificationRouteDescriptorSupported = false;

            if (sourceSynchSupport.IsCertificationTitleSupported)
                target.CertificationTitle = source.CertificationTitle;
            else
                targetSynchSupport.IsCertificationTitleSupported = false;

            if (sourceSynchSupport.IsCredentialStatusDateSupported)
                target.CredentialStatusDate = source.CredentialStatusDate;
            else
                targetSynchSupport.IsCredentialStatusDateSupported = false;

            if (sourceSynchSupport.IsCredentialStatusDescriptorSupported)
                target.CredentialStatusDescriptor = source.CredentialStatusDescriptor;
            else
                targetSynchSupport.IsCredentialStatusDescriptorSupported = false;

            if (sourceSynchSupport.IsEducatorRoleDescriptorSupported)
                target.EducatorRoleDescriptor = source.EducatorRoleDescriptor;
            else
                targetSynchSupport.IsEducatorRoleDescriptorSupported = false;

            if (sourceSynchSupport.IsPersonIdSupported)
                target.PersonId = source.PersonId;
            else
                targetSynchSupport.IsPersonIdSupported = false;

            if (sourceSynchSupport.IsSourceSystemDescriptorSupported)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            else
                targetSynchSupport.IsSourceSystemDescriptorSupported = false;

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

            if (sourceSynchSupport.IsCredentialStudentAcademicRecordsSupported)
            {
                targetSynchSupport.IsCredentialStudentAcademicRecordIncluded = sourceSynchSupport.IsCredentialStudentAcademicRecordIncluded;
                source.CredentialStudentAcademicRecords.MapCollectionTo(target.CredentialStudentAcademicRecords, target.Credential);
            }
            else
            {
                targetSynchSupport.IsCredentialStudentAcademicRecordsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICredentialExtensionSynchronizationSourceSupport 
    {
        bool IsBoardCertificationIndicatorSupported { get; set; }
        bool IsCertificationRouteDescriptorSupported { get; set; }
        bool IsCertificationTitleSupported { get; set; }
        bool IsCredentialStatusDateSupported { get; set; }
        bool IsCredentialStatusDescriptorSupported { get; set; }
        bool IsCredentialStudentAcademicRecordsSupported { get; set; }
        bool IsEducatorRoleDescriptorSupported { get; set; }
        bool IsPersonIdSupported { get; set; }
        bool IsSourceSystemDescriptorSupported { get; set; }
        Func<ICredentialStudentAcademicRecord, bool> IsCredentialStudentAcademicRecordIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class CredentialStudentAcademicRecordMapper
    {
        public static bool SynchronizeTo(this ICredentialStudentAcademicRecord source, ICredentialStudentAcademicRecord target)
        {
            bool isModified = false;

            var sourceSupport = source as ICredentialStudentAcademicRecordSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ICredentialStudentAcademicRecordSynchronizationSourceSupport;
            var targetSynchSupport = target as ICredentialStudentAcademicRecordSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICredentialStudentAcademicRecordSynchronizationSourceSupport 
    {
    }

}
// Aggregate: CredentialStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.CredentialStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class CredentialStatusDescriptorMapper
    {
        public static bool SynchronizeTo(this ICredentialStatusDescriptor source, ICredentialStatusDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as ICredentialStatusDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.CredentialStatusDescriptorId != target.CredentialStatusDescriptorId)
            {
                source.CredentialStatusDescriptorId = target.CredentialStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as ICredentialStatusDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as ICredentialStatusDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.CredentialStatusDescriptorId = source.CredentialStatusDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ICredentialStatusDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EducatorPreparationProgram

namespace EdFi.Ods.Entities.Common.TPDM //.EducatorPreparationProgramAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EducatorPreparationProgramMapper
    {
        public static bool SynchronizeTo(this IEducatorPreparationProgram source, IEducatorPreparationProgram target)
        {
            bool isModified = false;

            var sourceSupport = source as IEducatorPreparationProgramSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsAccreditationStatusDescriptorSupported)
                && target.AccreditationStatusDescriptor != source.AccreditationStatusDescriptor)
            {
                target.AccreditationStatusDescriptor = source.AccreditationStatusDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsProgramIdSupported)
                && target.ProgramId != source.ProgramId)
            {
                target.ProgramId = source.ProgramId;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEducatorPreparationProgramGradeLevelsSupported)
            {
                isModified |=
                    source.EducatorPreparationProgramGradeLevels.SynchronizeCollectionTo(
                        target.EducatorPreparationProgramGradeLevels,
                        onChildAdded: child =>
                            {
                                child.EducatorPreparationProgram = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEducatorPreparationProgramGradeLevelIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEducatorPreparationProgram source, IEducatorPreparationProgram target, Action<IEducatorPreparationProgram, IEducatorPreparationProgram> onMapped)
        {
            var sourceSynchSupport = source as IEducatorPreparationProgramSynchronizationSourceSupport;
            var targetSynchSupport = target as IEducatorPreparationProgramSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducationOrganizationId = source.EducationOrganizationId;
            target.ProgramName = source.ProgramName;
            target.ProgramTypeDescriptor = source.ProgramTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsAccreditationStatusDescriptorSupported)
                target.AccreditationStatusDescriptor = source.AccreditationStatusDescriptor;
            else
                targetSynchSupport.IsAccreditationStatusDescriptorSupported = false;

            if (sourceSynchSupport.IsProgramIdSupported)
                target.ProgramId = source.ProgramId;
            else
                targetSynchSupport.IsProgramIdSupported = false;

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

            if (sourceSynchSupport.IsEducatorPreparationProgramGradeLevelsSupported)
            {
                targetSynchSupport.IsEducatorPreparationProgramGradeLevelIncluded = sourceSynchSupport.IsEducatorPreparationProgramGradeLevelIncluded;
                source.EducatorPreparationProgramGradeLevels.MapCollectionTo(target.EducatorPreparationProgramGradeLevels, target);
            }
            else
            {
                targetSynchSupport.IsEducatorPreparationProgramGradeLevelsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEducatorPreparationProgramSynchronizationSourceSupport 
    {
        bool IsAccreditationStatusDescriptorSupported { get; set; }
        bool IsEducatorPreparationProgramGradeLevelsSupported { get; set; }
        bool IsProgramIdSupported { get; set; }
        Func<IEducatorPreparationProgramGradeLevel, bool> IsEducatorPreparationProgramGradeLevelIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EducatorPreparationProgramGradeLevelMapper
    {
        public static bool SynchronizeTo(this IEducatorPreparationProgramGradeLevel source, IEducatorPreparationProgramGradeLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IEducatorPreparationProgramGradeLevelSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as IEducatorPreparationProgramGradeLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IEducatorPreparationProgramGradeLevelSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEducatorPreparationProgramGradeLevelSynchronizationSourceSupport 
    {
    }

}
// Aggregate: EducatorRoleDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EducatorRoleDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EducatorRoleDescriptorMapper
    {
        public static bool SynchronizeTo(this IEducatorRoleDescriptor source, IEducatorRoleDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEducatorRoleDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EducatorRoleDescriptorId != target.EducatorRoleDescriptorId)
            {
                source.EducatorRoleDescriptorId = target.EducatorRoleDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEducatorRoleDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEducatorRoleDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EducatorRoleDescriptorId = source.EducatorRoleDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEducatorRoleDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EnglishLanguageExamDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EnglishLanguageExamDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EnglishLanguageExamDescriptorMapper
    {
        public static bool SynchronizeTo(this IEnglishLanguageExamDescriptor source, IEnglishLanguageExamDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEnglishLanguageExamDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EnglishLanguageExamDescriptorId != target.EnglishLanguageExamDescriptorId)
            {
                source.EnglishLanguageExamDescriptorId = target.EnglishLanguageExamDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEnglishLanguageExamDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEnglishLanguageExamDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EnglishLanguageExamDescriptorId = source.EnglishLanguageExamDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEnglishLanguageExamDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EPPProgramPathwayDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EPPProgramPathwayDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EPPProgramPathwayDescriptorMapper
    {
        public static bool SynchronizeTo(this IEPPProgramPathwayDescriptor source, IEPPProgramPathwayDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEPPProgramPathwayDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EPPProgramPathwayDescriptorId != target.EPPProgramPathwayDescriptorId)
            {
                source.EPPProgramPathwayDescriptorId = target.EPPProgramPathwayDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEPPProgramPathwayDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEPPProgramPathwayDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EPPProgramPathwayDescriptorId = source.EPPProgramPathwayDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEPPProgramPathwayDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: Evaluation

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationMapper
    {
        public static bool SynchronizeTo(this IEvaluation source, IEvaluation target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsEvaluationDescriptionSupported)
                && target.EvaluationDescription != source.EvaluationDescription)
            {
                target.EvaluationDescription = source.EvaluationDescription;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEvaluationTypeDescriptorSupported)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsInterRaterReliabilityScoreSupported)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationRatingLevelsSupported)
            {
                isModified |=
                    source.EvaluationRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationRatingLevels,
                        onChildAdded: child =>
                            {
                                child.Evaluation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationRatingLevelIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluation source, IEvaluation target, Action<IEvaluation, IEvaluation> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsEvaluationDescriptionSupported)
                target.EvaluationDescription = source.EvaluationDescription;
            else
                targetSynchSupport.IsEvaluationDescriptionSupported = false;

            if (sourceSynchSupport.IsEvaluationTypeDescriptorSupported)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
            else
                targetSynchSupport.IsEvaluationTypeDescriptorSupported = false;

            if (sourceSynchSupport.IsInterRaterReliabilityScoreSupported)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
            else
                targetSynchSupport.IsInterRaterReliabilityScoreSupported = false;

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

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

            if (sourceSynchSupport.IsEvaluationRatingLevelsSupported)
            {
                targetSynchSupport.IsEvaluationRatingLevelIncluded = sourceSynchSupport.IsEvaluationRatingLevelIncluded;
                source.EvaluationRatingLevels.MapCollectionTo(target.EvaluationRatingLevels, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationRatingLevelsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationSynchronizationSourceSupport 
    {
        bool IsEvaluationDescriptionSupported { get; set; }
        bool IsEvaluationRatingLevelsSupported { get; set; }
        bool IsEvaluationTypeDescriptorSupported { get; set; }
        bool IsInterRaterReliabilityScoreSupported { get; set; }
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
        Func<IEvaluationRatingLevel, bool> IsEvaluationRatingLevelIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingLevelMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingLevel source, IEvaluationRatingLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingLevelSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingLevelSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingLevelSynchronizationSourceSupport 
    {
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
    }

}
// Aggregate: EvaluationElement

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementMapper
    {
        public static bool SynchronizeTo(this IEvaluationElement source, IEvaluationElement target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationElementSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsEvaluationTypeDescriptorSupported)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSortOrderSupported)
                && target.SortOrder != source.SortOrder)
            {
                target.SortOrder = source.SortOrder;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationElementRatingLevelsSupported)
            {
                isModified |=
                    source.EvaluationElementRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationElementRatingLevels,
                        onChildAdded: child =>
                            {
                                child.EvaluationElement = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationElementRatingLevelIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationElement source, IEvaluationElement target, Action<IEvaluationElement, IEvaluationElement> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationElementSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationElementSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsEvaluationTypeDescriptorSupported)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
            else
                targetSynchSupport.IsEvaluationTypeDescriptorSupported = false;

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

            if (sourceSynchSupport.IsSortOrderSupported)
                target.SortOrder = source.SortOrder;
            else
                targetSynchSupport.IsSortOrderSupported = false;

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

            if (sourceSynchSupport.IsEvaluationElementRatingLevelsSupported)
            {
                targetSynchSupport.IsEvaluationElementRatingLevelIncluded = sourceSynchSupport.IsEvaluationElementRatingLevelIncluded;
                source.EvaluationElementRatingLevels.MapCollectionTo(target.EvaluationElementRatingLevels, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationElementRatingLevelsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationElementSynchronizationSourceSupport 
    {
        bool IsEvaluationElementRatingLevelsSupported { get; set; }
        bool IsEvaluationTypeDescriptorSupported { get; set; }
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
        bool IsSortOrderSupported { get; set; }
        Func<IEvaluationElementRatingLevel, bool> IsEvaluationElementRatingLevelIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingLevelMapper
    {
        public static bool SynchronizeTo(this IEvaluationElementRatingLevel source, IEvaluationElementRatingLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationElementRatingLevelSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
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
            var sourceSynchSupport = source as IEvaluationElementRatingLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationElementRatingLevelSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationElementRatingLevelSynchronizationSourceSupport 
    {
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
    }

}
// Aggregate: EvaluationElementRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingMapper
    {
        public static bool SynchronizeTo(this IEvaluationElementRating source, IEvaluationElementRating target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationElementRatingSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsAreaOfRefinementSupported)
                && target.AreaOfRefinement != source.AreaOfRefinement)
            {
                target.AreaOfRefinement = source.AreaOfRefinement;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsAreaOfReinforcementSupported)
                && target.AreaOfReinforcement != source.AreaOfReinforcement)
            {
                target.AreaOfReinforcement = source.AreaOfReinforcement;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCommentsSupported)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEvaluationElementRatingLevelDescriptorSupported)
                && target.EvaluationElementRatingLevelDescriptor != source.EvaluationElementRatingLevelDescriptor)
            {
                target.EvaluationElementRatingLevelDescriptor = source.EvaluationElementRatingLevelDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsFeedbackSupported)
                && target.Feedback != source.Feedback)
            {
                target.Feedback = source.Feedback;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationElementRatingResultsSupported)
            {
                isModified |=
                    source.EvaluationElementRatingResults.SynchronizeCollectionTo(
                        target.EvaluationElementRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationElementRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationElementRatingResultIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationElementRating source, IEvaluationElementRating target, Action<IEvaluationElementRating, IEvaluationElementRating> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationElementRatingSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationElementRatingSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsAreaOfRefinementSupported)
                target.AreaOfRefinement = source.AreaOfRefinement;
            else
                targetSynchSupport.IsAreaOfRefinementSupported = false;

            if (sourceSynchSupport.IsAreaOfReinforcementSupported)
                target.AreaOfReinforcement = source.AreaOfReinforcement;
            else
                targetSynchSupport.IsAreaOfReinforcementSupported = false;

            if (sourceSynchSupport.IsCommentsSupported)
                target.Comments = source.Comments;
            else
                targetSynchSupport.IsCommentsSupported = false;

            if (sourceSynchSupport.IsEvaluationElementRatingLevelDescriptorSupported)
                target.EvaluationElementRatingLevelDescriptor = source.EvaluationElementRatingLevelDescriptor;
            else
                targetSynchSupport.IsEvaluationElementRatingLevelDescriptorSupported = false;

            if (sourceSynchSupport.IsFeedbackSupported)
                target.Feedback = source.Feedback;
            else
                targetSynchSupport.IsFeedbackSupported = false;

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

            if (sourceSynchSupport.IsEvaluationElementRatingResultsSupported)
            {
                targetSynchSupport.IsEvaluationElementRatingResultIncluded = sourceSynchSupport.IsEvaluationElementRatingResultIncluded;
                source.EvaluationElementRatingResults.MapCollectionTo(target.EvaluationElementRatingResults, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationElementRatingResultsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationElementRatingSynchronizationSourceSupport 
    {
        bool IsAreaOfRefinementSupported { get; set; }
        bool IsAreaOfReinforcementSupported { get; set; }
        bool IsCommentsSupported { get; set; }
        bool IsEvaluationElementRatingLevelDescriptorSupported { get; set; }
        bool IsEvaluationElementRatingResultsSupported { get; set; }
        bool IsFeedbackSupported { get; set; }
        Func<IEvaluationElementRatingResult, bool> IsEvaluationElementRatingResultIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingResultMapper
    {
        public static bool SynchronizeTo(this IEvaluationElementRatingResult source, IEvaluationElementRatingResult target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationElementRatingResultSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsResultDatatypeTypeDescriptorSupported)
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
            var sourceSynchSupport = source as IEvaluationElementRatingResultSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationElementRatingResultSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (sourceSynchSupport.IsResultDatatypeTypeDescriptorSupported)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
            else
                targetSynchSupport.IsResultDatatypeTypeDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationElementRatingResultSynchronizationSourceSupport 
    {
        bool IsResultDatatypeTypeDescriptorSupported { get; set; }
    }

}
// Aggregate: EvaluationElementRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationElementRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationElementRatingLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IEvaluationElementRatingLevelDescriptor source, IEvaluationElementRatingLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationElementRatingLevelDescriptorId != target.EvaluationElementRatingLevelDescriptorId)
            {
                source.EvaluationElementRatingLevelDescriptorId = target.EvaluationElementRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationElementRatingLevelDescriptorId = source.EvaluationElementRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationElementRatingLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EvaluationObjective

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationObjectiveAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveMapper
    {
        public static bool SynchronizeTo(this IEvaluationObjective source, IEvaluationObjective target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationObjectiveSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsEvaluationObjectiveDescriptionSupported)
                && target.EvaluationObjectiveDescription != source.EvaluationObjectiveDescription)
            {
                target.EvaluationObjectiveDescription = source.EvaluationObjectiveDescription;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEvaluationTypeDescriptorSupported)
                && target.EvaluationTypeDescriptor != source.EvaluationTypeDescriptor)
            {
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
                && target.MinRating != source.MinRating)
            {
                target.MinRating = source.MinRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSortOrderSupported)
                && target.SortOrder != source.SortOrder)
            {
                target.SortOrder = source.SortOrder;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationObjectiveRatingLevelsSupported)
            {
                isModified |=
                    source.EvaluationObjectiveRatingLevels.SynchronizeCollectionTo(
                        target.EvaluationObjectiveRatingLevels,
                        onChildAdded: child =>
                            {
                                child.EvaluationObjective = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationObjectiveRatingLevelIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationObjective source, IEvaluationObjective target, Action<IEvaluationObjective, IEvaluationObjective> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationObjectiveSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationObjectiveSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsEvaluationObjectiveDescriptionSupported)
                target.EvaluationObjectiveDescription = source.EvaluationObjectiveDescription;
            else
                targetSynchSupport.IsEvaluationObjectiveDescriptionSupported = false;

            if (sourceSynchSupport.IsEvaluationTypeDescriptorSupported)
                target.EvaluationTypeDescriptor = source.EvaluationTypeDescriptor;
            else
                targetSynchSupport.IsEvaluationTypeDescriptorSupported = false;

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

            if (sourceSynchSupport.IsSortOrderSupported)
                target.SortOrder = source.SortOrder;
            else
                targetSynchSupport.IsSortOrderSupported = false;

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

            if (sourceSynchSupport.IsEvaluationObjectiveRatingLevelsSupported)
            {
                targetSynchSupport.IsEvaluationObjectiveRatingLevelIncluded = sourceSynchSupport.IsEvaluationObjectiveRatingLevelIncluded;
                source.EvaluationObjectiveRatingLevels.MapCollectionTo(target.EvaluationObjectiveRatingLevels, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationObjectiveRatingLevelsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationObjectiveSynchronizationSourceSupport 
    {
        bool IsEvaluationObjectiveDescriptionSupported { get; set; }
        bool IsEvaluationObjectiveRatingLevelsSupported { get; set; }
        bool IsEvaluationTypeDescriptorSupported { get; set; }
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
        bool IsSortOrderSupported { get; set; }
        Func<IEvaluationObjectiveRatingLevel, bool> IsEvaluationObjectiveRatingLevelIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingLevelMapper
    {
        public static bool SynchronizeTo(this IEvaluationObjectiveRatingLevel source, IEvaluationObjectiveRatingLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationObjectiveRatingLevelSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
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
            var sourceSynchSupport = source as IEvaluationObjectiveRatingLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationObjectiveRatingLevelSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationObjectiveRatingLevelSynchronizationSourceSupport 
    {
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
    }

}
// Aggregate: EvaluationObjectiveRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationObjectiveRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingMapper
    {
        public static bool SynchronizeTo(this IEvaluationObjectiveRating source, IEvaluationObjectiveRating target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationObjectiveRatingSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsCommentsSupported)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsObjectiveRatingLevelDescriptorSupported)
                && target.ObjectiveRatingLevelDescriptor != source.ObjectiveRatingLevelDescriptor)
            {
                target.ObjectiveRatingLevelDescriptor = source.ObjectiveRatingLevelDescriptor;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationObjectiveRatingResultsSupported)
            {
                isModified |=
                    source.EvaluationObjectiveRatingResults.SynchronizeCollectionTo(
                        target.EvaluationObjectiveRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationObjectiveRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationObjectiveRatingResultIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationObjectiveRating source, IEvaluationObjectiveRating target, Action<IEvaluationObjectiveRating, IEvaluationObjectiveRating> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationObjectiveRatingSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationObjectiveRatingSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsCommentsSupported)
                target.Comments = source.Comments;
            else
                targetSynchSupport.IsCommentsSupported = false;

            if (sourceSynchSupport.IsObjectiveRatingLevelDescriptorSupported)
                target.ObjectiveRatingLevelDescriptor = source.ObjectiveRatingLevelDescriptor;
            else
                targetSynchSupport.IsObjectiveRatingLevelDescriptorSupported = false;

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

            if (sourceSynchSupport.IsEvaluationObjectiveRatingResultsSupported)
            {
                targetSynchSupport.IsEvaluationObjectiveRatingResultIncluded = sourceSynchSupport.IsEvaluationObjectiveRatingResultIncluded;
                source.EvaluationObjectiveRatingResults.MapCollectionTo(target.EvaluationObjectiveRatingResults, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationObjectiveRatingResultsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationObjectiveRatingSynchronizationSourceSupport 
    {
        bool IsCommentsSupported { get; set; }
        bool IsEvaluationObjectiveRatingResultsSupported { get; set; }
        bool IsObjectiveRatingLevelDescriptorSupported { get; set; }
        Func<IEvaluationObjectiveRatingResult, bool> IsEvaluationObjectiveRatingResultIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationObjectiveRatingResultMapper
    {
        public static bool SynchronizeTo(this IEvaluationObjectiveRatingResult source, IEvaluationObjectiveRatingResult target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationObjectiveRatingResultSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsResultDatatypeTypeDescriptorSupported)
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
            var sourceSynchSupport = source as IEvaluationObjectiveRatingResultSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationObjectiveRatingResultSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (sourceSynchSupport.IsResultDatatypeTypeDescriptorSupported)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
            else
                targetSynchSupport.IsResultDatatypeTypeDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationObjectiveRatingResultSynchronizationSourceSupport 
    {
        bool IsResultDatatypeTypeDescriptorSupported { get; set; }
    }

}
// Aggregate: EvaluationPeriodDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationPeriodDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationPeriodDescriptorMapper
    {
        public static bool SynchronizeTo(this IEvaluationPeriodDescriptor source, IEvaluationPeriodDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationPeriodDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationPeriodDescriptorId != target.EvaluationPeriodDescriptorId)
            {
                source.EvaluationPeriodDescriptorId = target.EvaluationPeriodDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEvaluationPeriodDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationPeriodDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationPeriodDescriptorId = source.EvaluationPeriodDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationPeriodDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EvaluationRating

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingMapper
    {
        public static bool SynchronizeTo(this IEvaluationRating source, IEvaluationRating target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsEvaluationRatingLevelDescriptorSupported)
                && target.EvaluationRatingLevelDescriptor != source.EvaluationRatingLevelDescriptor)
            {
                target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEvaluationRatingStatusDescriptorSupported)
                && target.EvaluationRatingStatusDescriptor != source.EvaluationRatingStatusDescriptor)
            {
                target.EvaluationRatingStatusDescriptor = source.EvaluationRatingStatusDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLocalCourseCodeSupported)
                && target.LocalCourseCode != source.LocalCourseCode)
            {
                target.LocalCourseCode = source.LocalCourseCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSchoolIdSupported)
                && target.SchoolId != source.SchoolId)
            {
                target.SchoolId = source.SchoolId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSectionIdentifierSupported)
                && target.SectionIdentifier != source.SectionIdentifier)
            {
                target.SectionIdentifier = source.SectionIdentifier;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSessionNameSupported)
                && target.SessionName != source.SessionName)
            {
                target.SessionName = source.SessionName;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsEvaluationRatingResultsSupported)
            {
                isModified |=
                    source.EvaluationRatingResults.SynchronizeCollectionTo(
                        target.EvaluationRatingResults,
                        onChildAdded: child =>
                            {
                                child.EvaluationRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationRatingResultIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsEvaluationRatingReviewersSupported)
            {
                isModified |=
                    source.EvaluationRatingReviewers.SynchronizeCollectionTo(
                        target.EvaluationRatingReviewers,
                        onChildAdded: child =>
                            {
                                child.EvaluationRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsEvaluationRatingReviewerIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IEvaluationRating source, IEvaluationRating target, Action<IEvaluationRating, IEvaluationRating> onMapped)
        {
            var sourceSynchSupport = source as IEvaluationRatingSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsEvaluationRatingLevelDescriptorSupported)
                target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;
            else
                targetSynchSupport.IsEvaluationRatingLevelDescriptorSupported = false;

            if (sourceSynchSupport.IsEvaluationRatingStatusDescriptorSupported)
                target.EvaluationRatingStatusDescriptor = source.EvaluationRatingStatusDescriptor;
            else
                targetSynchSupport.IsEvaluationRatingStatusDescriptorSupported = false;

            if (sourceSynchSupport.IsLocalCourseCodeSupported)
                target.LocalCourseCode = source.LocalCourseCode;
            else
                targetSynchSupport.IsLocalCourseCodeSupported = false;

            if (sourceSynchSupport.IsSchoolIdSupported)
                target.SchoolId = source.SchoolId;
            else
                targetSynchSupport.IsSchoolIdSupported = false;

            if (sourceSynchSupport.IsSectionIdentifierSupported)
                target.SectionIdentifier = source.SectionIdentifier;
            else
                targetSynchSupport.IsSectionIdentifierSupported = false;

            if (sourceSynchSupport.IsSessionNameSupported)
                target.SessionName = source.SessionName;
            else
                targetSynchSupport.IsSessionNameSupported = false;

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

            if (sourceSynchSupport.IsEvaluationRatingResultsSupported)
            {
                targetSynchSupport.IsEvaluationRatingResultIncluded = sourceSynchSupport.IsEvaluationRatingResultIncluded;
                source.EvaluationRatingResults.MapCollectionTo(target.EvaluationRatingResults, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationRatingResultsSupported = false;
            }

            if (sourceSynchSupport.IsEvaluationRatingReviewersSupported)
            {
                targetSynchSupport.IsEvaluationRatingReviewerIncluded = sourceSynchSupport.IsEvaluationRatingReviewerIncluded;
                source.EvaluationRatingReviewers.MapCollectionTo(target.EvaluationRatingReviewers, target);
            }
            else
            {
                targetSynchSupport.IsEvaluationRatingReviewersSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingSynchronizationSourceSupport 
    {
        bool IsEvaluationRatingLevelDescriptorSupported { get; set; }
        bool IsEvaluationRatingResultsSupported { get; set; }
        bool IsEvaluationRatingReviewersSupported { get; set; }
        bool IsEvaluationRatingStatusDescriptorSupported { get; set; }
        bool IsLocalCourseCodeSupported { get; set; }
        bool IsSchoolIdSupported { get; set; }
        bool IsSectionIdentifierSupported { get; set; }
        bool IsSessionNameSupported { get; set; }
        Func<IEvaluationRatingResult, bool> IsEvaluationRatingResultIncluded { get; set; }
        Func<IEvaluationRatingReviewer, bool> IsEvaluationRatingReviewerIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingResultMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingResult source, IEvaluationRatingResult target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingResultSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsResultDatatypeTypeDescriptorSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingResultSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingResultSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (sourceSynchSupport.IsResultDatatypeTypeDescriptorSupported)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
            else
                targetSynchSupport.IsResultDatatypeTypeDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingResultSynchronizationSourceSupport 
    {
        bool IsResultDatatypeTypeDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingReviewerMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingReviewer source, IEvaluationRatingReviewer target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingReviewerSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsReviewerPersonIdSupported)
                && target.ReviewerPersonId != source.ReviewerPersonId)
            {
                target.ReviewerPersonId = source.ReviewerPersonId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReviewerSourceSystemDescriptorSupported)
                && target.ReviewerSourceSystemDescriptor != source.ReviewerSourceSystemDescriptor)
            {
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // EvaluationRatingReviewerReceivedTraining
            if (sourceSupport == null || sourceSupport.IsEvaluationRatingReviewerReceivedTrainingSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingReviewerSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingReviewerSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;

            // Copy non-PK properties

            if (sourceSynchSupport.IsReviewerPersonIdSupported)
                target.ReviewerPersonId = source.ReviewerPersonId;
            else
                targetSynchSupport.IsReviewerPersonIdSupported = false;

            if (sourceSynchSupport.IsReviewerSourceSystemDescriptorSupported)
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
            else
                targetSynchSupport.IsReviewerSourceSystemDescriptorSupported = false;

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
            // EvaluationRatingReviewerReceivedTraining (Source)
            if (sourceSynchSupport.IsEvaluationRatingReviewerReceivedTrainingSupported)
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
            else
            {
                targetSynchSupport.IsEvaluationRatingReviewerReceivedTrainingSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingReviewerSynchronizationSourceSupport 
    {
        bool IsEvaluationRatingReviewerReceivedTrainingSupported { get; set; }
        bool IsReviewerPersonIdSupported { get; set; }
        bool IsReviewerSourceSystemDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingReviewerReceivedTrainingMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingReviewerReceivedTraining source, IEvaluationRatingReviewerReceivedTraining target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsInterRaterReliabilityScoreSupported)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReceivedTrainingDateSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsInterRaterReliabilityScoreSupported)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
            else
                targetSynchSupport.IsInterRaterReliabilityScoreSupported = false;

            if (sourceSynchSupport.IsReceivedTrainingDateSupported)
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;
            else
                targetSynchSupport.IsReceivedTrainingDateSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport 
    {
        bool IsInterRaterReliabilityScoreSupported { get; set; }
        bool IsReceivedTrainingDateSupported { get; set; }
    }

}
// Aggregate: EvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingLevelDescriptor source, IEvaluationRatingLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptorId != target.EvaluationRatingLevelDescriptorId)
            {
                source.EvaluationRatingLevelDescriptorId = target.EvaluationRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptorId = source.EvaluationRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EvaluationRatingStatusDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationRatingStatusDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationRatingStatusDescriptorMapper
    {
        public static bool SynchronizeTo(this IEvaluationRatingStatusDescriptor source, IEvaluationRatingStatusDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationRatingStatusDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingStatusDescriptorId != target.EvaluationRatingStatusDescriptorId)
            {
                source.EvaluationRatingStatusDescriptorId = target.EvaluationRatingStatusDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEvaluationRatingStatusDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationRatingStatusDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationRatingStatusDescriptorId = source.EvaluationRatingStatusDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationRatingStatusDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: EvaluationTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.EvaluationTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class EvaluationTypeDescriptorMapper
    {
        public static bool SynchronizeTo(this IEvaluationTypeDescriptor source, IEvaluationTypeDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IEvaluationTypeDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationTypeDescriptorId != target.EvaluationTypeDescriptorId)
            {
                source.EvaluationTypeDescriptorId = target.EvaluationTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IEvaluationTypeDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IEvaluationTypeDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.EvaluationTypeDescriptorId = source.EvaluationTypeDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IEvaluationTypeDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: FinancialAid

namespace EdFi.Ods.Entities.Common.TPDM //.FinancialAidAggregate
{
    [ExcludeFromCodeCoverage]
    public static class FinancialAidMapper
    {
        public static bool SynchronizeTo(this IFinancialAid source, IFinancialAid target)
        {
            bool isModified = false;

            var sourceSupport = source as IFinancialAidSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsAidAmountSupported)
                && target.AidAmount != source.AidAmount)
            {
                target.AidAmount = source.AidAmount;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsAidConditionDescriptionSupported)
                && target.AidConditionDescription != source.AidConditionDescription)
            {
                target.AidConditionDescription = source.AidConditionDescription;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPellGrantRecipientSupported)
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
            var sourceSynchSupport = source as IFinancialAidSynchronizationSourceSupport;
            var targetSynchSupport = target as IFinancialAidSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.AidTypeDescriptor = source.AidTypeDescriptor;
            target.BeginDate = source.BeginDate;
            target.StudentUniqueId = source.StudentUniqueId;

            // Copy non-PK properties

            if (sourceSynchSupport.IsAidAmountSupported)
                target.AidAmount = source.AidAmount;
            else
                targetSynchSupport.IsAidAmountSupported = false;

            if (sourceSynchSupport.IsAidConditionDescriptionSupported)
                target.AidConditionDescription = source.AidConditionDescription;
            else
                targetSynchSupport.IsAidConditionDescriptionSupported = false;

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsPellGrantRecipientSupported)
                target.PellGrantRecipient = source.PellGrantRecipient;
            else
                targetSynchSupport.IsPellGrantRecipientSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IFinancialAidSynchronizationSourceSupport 
    {
        bool IsAidAmountSupported { get; set; }
        bool IsAidConditionDescriptionSupported { get; set; }
        bool IsEndDateSupported { get; set; }
        bool IsPellGrantRecipientSupported { get; set; }
    }

}
// Aggregate: GenderDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.GenderDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class GenderDescriptorMapper
    {
        public static bool SynchronizeTo(this IGenderDescriptor source, IGenderDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IGenderDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.GenderDescriptorId != target.GenderDescriptorId)
            {
                source.GenderDescriptorId = target.GenderDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IGenderDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IGenderDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.GenderDescriptorId = source.GenderDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IGenderDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: ObjectiveRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.ObjectiveRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class ObjectiveRatingLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IObjectiveRatingLevelDescriptor source, IObjectiveRatingLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IObjectiveRatingLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ObjectiveRatingLevelDescriptorId != target.ObjectiveRatingLevelDescriptorId)
            {
                source.ObjectiveRatingLevelDescriptorId = target.ObjectiveRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IObjectiveRatingLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IObjectiveRatingLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ObjectiveRatingLevelDescriptorId = source.ObjectiveRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IObjectiveRatingLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: PerformanceEvaluation

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluation source, IPerformanceEvaluation target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsAcademicSubjectDescriptorSupported)
                && target.AcademicSubjectDescriptor != source.AcademicSubjectDescriptor)
            {
                target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPerformanceEvaluationDescriptionSupported)
                && target.PerformanceEvaluationDescription != source.PerformanceEvaluationDescription)
            {
                target.PerformanceEvaluationDescription = source.PerformanceEvaluationDescription;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsPerformanceEvaluationGradeLevelsSupported)
            {
                isModified |=
                    source.PerformanceEvaluationGradeLevels.SynchronizeCollectionTo(
                        target.PerformanceEvaluationGradeLevels,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsPerformanceEvaluationGradeLevelIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsPerformanceEvaluationRatingLevelsSupported)
            {
                isModified |=
                    source.PerformanceEvaluationRatingLevels.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingLevels,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluation = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsPerformanceEvaluationRatingLevelIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluation source, IPerformanceEvaluation target, Action<IPerformanceEvaluation, IPerformanceEvaluation> onMapped)
        {
            var sourceSynchSupport = source as IPerformanceEvaluationSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsAcademicSubjectDescriptorSupported)
                target.AcademicSubjectDescriptor = source.AcademicSubjectDescriptor;
            else
                targetSynchSupport.IsAcademicSubjectDescriptorSupported = false;

            if (sourceSynchSupport.IsPerformanceEvaluationDescriptionSupported)
                target.PerformanceEvaluationDescription = source.PerformanceEvaluationDescription;
            else
                targetSynchSupport.IsPerformanceEvaluationDescriptionSupported = false;

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

            if (sourceSynchSupport.IsPerformanceEvaluationGradeLevelsSupported)
            {
                targetSynchSupport.IsPerformanceEvaluationGradeLevelIncluded = sourceSynchSupport.IsPerformanceEvaluationGradeLevelIncluded;
                source.PerformanceEvaluationGradeLevels.MapCollectionTo(target.PerformanceEvaluationGradeLevels, target);
            }
            else
            {
                targetSynchSupport.IsPerformanceEvaluationGradeLevelsSupported = false;
            }

            if (sourceSynchSupport.IsPerformanceEvaluationRatingLevelsSupported)
            {
                targetSynchSupport.IsPerformanceEvaluationRatingLevelIncluded = sourceSynchSupport.IsPerformanceEvaluationRatingLevelIncluded;
                source.PerformanceEvaluationRatingLevels.MapCollectionTo(target.PerformanceEvaluationRatingLevels, target);
            }
            else
            {
                targetSynchSupport.IsPerformanceEvaluationRatingLevelsSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationSynchronizationSourceSupport 
    {
        bool IsAcademicSubjectDescriptorSupported { get; set; }
        bool IsPerformanceEvaluationDescriptionSupported { get; set; }
        bool IsPerformanceEvaluationGradeLevelsSupported { get; set; }
        bool IsPerformanceEvaluationRatingLevelsSupported { get; set; }
        Func<IPerformanceEvaluationGradeLevel, bool> IsPerformanceEvaluationGradeLevelIncluded { get; set; }
        Func<IPerformanceEvaluationRatingLevel, bool> IsPerformanceEvaluationRatingLevelIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationGradeLevelMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationGradeLevel source, IPerformanceEvaluationGradeLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationGradeLevelSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as IPerformanceEvaluationGradeLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationGradeLevelSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationGradeLevelSynchronizationSourceSupport 
    {
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingLevelMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingLevel source, IPerformanceEvaluationRatingLevel target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingLevelSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.EvaluationRatingLevelDescriptor != target.EvaluationRatingLevelDescriptor)
            {
                source.EvaluationRatingLevelDescriptor = target.EvaluationRatingLevelDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsMaxRatingSupported)
                && target.MaxRating != source.MaxRating)
            {
                target.MaxRating = source.MaxRating;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMinRatingSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationRatingLevelSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingLevelSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.EvaluationRatingLevelDescriptor = source.EvaluationRatingLevelDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsMaxRatingSupported)
                target.MaxRating = source.MaxRating;
            else
                targetSynchSupport.IsMaxRatingSupported = false;

            if (sourceSynchSupport.IsMinRatingSupported)
                target.MinRating = source.MinRating;
            else
                targetSynchSupport.IsMinRatingSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelSynchronizationSourceSupport 
    {
        bool IsMaxRatingSupported { get; set; }
        bool IsMinRatingSupported { get; set; }
    }

}
// Aggregate: PerformanceEvaluationRating

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationRatingAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRating source, IPerformanceEvaluationRating target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsActualDateSupported)
                && target.ActualDate != source.ActualDate)
            {
                target.ActualDate = source.ActualDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsActualDurationSupported)
                && target.ActualDuration != source.ActualDuration)
            {
                target.ActualDuration = source.ActualDuration;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsActualTimeSupported)
                && target.ActualTime != source.ActualTime)
            {
                target.ActualTime = source.ActualTime;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsAnnouncedSupported)
                && target.Announced != source.Announced)
            {
                target.Announced = source.Announced;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCommentsSupported)
                && target.Comments != source.Comments)
            {
                target.Comments = source.Comments;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCoteachingStyleObservedDescriptorSupported)
                && target.CoteachingStyleObservedDescriptor != source.CoteachingStyleObservedDescriptor)
            {
                target.CoteachingStyleObservedDescriptor = source.CoteachingStyleObservedDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPerformanceEvaluationRatingLevelDescriptorSupported)
                && target.PerformanceEvaluationRatingLevelDescriptor != source.PerformanceEvaluationRatingLevelDescriptor)
            {
                target.PerformanceEvaluationRatingLevelDescriptor = source.PerformanceEvaluationRatingLevelDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsScheduleDateSupported)
                && target.ScheduleDate != source.ScheduleDate)
            {
                target.ScheduleDate = source.ScheduleDate;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsPerformanceEvaluationRatingResultsSupported)
            {
                isModified |=
                    source.PerformanceEvaluationRatingResults.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingResults,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluationRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsPerformanceEvaluationRatingResultIncluded);
            }

            if (sourceSupport == null || sourceSupport.IsPerformanceEvaluationRatingReviewersSupported)
            {
                isModified |=
                    source.PerformanceEvaluationRatingReviewers.SynchronizeCollectionTo(
                        target.PerformanceEvaluationRatingReviewers,
                        onChildAdded: child =>
                            {
                                child.PerformanceEvaluationRating = target;
                            },
                        includeItem: sourceSupport == null
                            ? null
                            : sourceSupport.IsPerformanceEvaluationRatingReviewerIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IPerformanceEvaluationRating source, IPerformanceEvaluationRating target, Action<IPerformanceEvaluationRating, IPerformanceEvaluationRating> onMapped)
        {
            var sourceSynchSupport = source as IPerformanceEvaluationRatingSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsActualDateSupported)
                target.ActualDate = source.ActualDate;
            else
                targetSynchSupport.IsActualDateSupported = false;

            if (sourceSynchSupport.IsActualDurationSupported)
                target.ActualDuration = source.ActualDuration;
            else
                targetSynchSupport.IsActualDurationSupported = false;

            if (sourceSynchSupport.IsActualTimeSupported)
                target.ActualTime = source.ActualTime;
            else
                targetSynchSupport.IsActualTimeSupported = false;

            if (sourceSynchSupport.IsAnnouncedSupported)
                target.Announced = source.Announced;
            else
                targetSynchSupport.IsAnnouncedSupported = false;

            if (sourceSynchSupport.IsCommentsSupported)
                target.Comments = source.Comments;
            else
                targetSynchSupport.IsCommentsSupported = false;

            if (sourceSynchSupport.IsCoteachingStyleObservedDescriptorSupported)
                target.CoteachingStyleObservedDescriptor = source.CoteachingStyleObservedDescriptor;
            else
                targetSynchSupport.IsCoteachingStyleObservedDescriptorSupported = false;

            if (sourceSynchSupport.IsPerformanceEvaluationRatingLevelDescriptorSupported)
                target.PerformanceEvaluationRatingLevelDescriptor = source.PerformanceEvaluationRatingLevelDescriptor;
            else
                targetSynchSupport.IsPerformanceEvaluationRatingLevelDescriptorSupported = false;

            if (sourceSynchSupport.IsScheduleDateSupported)
                target.ScheduleDate = source.ScheduleDate;
            else
                targetSynchSupport.IsScheduleDateSupported = false;

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

            if (sourceSynchSupport.IsPerformanceEvaluationRatingResultsSupported)
            {
                targetSynchSupport.IsPerformanceEvaluationRatingResultIncluded = sourceSynchSupport.IsPerformanceEvaluationRatingResultIncluded;
                source.PerformanceEvaluationRatingResults.MapCollectionTo(target.PerformanceEvaluationRatingResults, target);
            }
            else
            {
                targetSynchSupport.IsPerformanceEvaluationRatingResultsSupported = false;
            }

            if (sourceSynchSupport.IsPerformanceEvaluationRatingReviewersSupported)
            {
                targetSynchSupport.IsPerformanceEvaluationRatingReviewerIncluded = sourceSynchSupport.IsPerformanceEvaluationRatingReviewerIncluded;
                source.PerformanceEvaluationRatingReviewers.MapCollectionTo(target.PerformanceEvaluationRatingReviewers, target);
            }
            else
            {
                targetSynchSupport.IsPerformanceEvaluationRatingReviewersSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingSynchronizationSourceSupport 
    {
        bool IsActualDateSupported { get; set; }
        bool IsActualDurationSupported { get; set; }
        bool IsActualTimeSupported { get; set; }
        bool IsAnnouncedSupported { get; set; }
        bool IsCommentsSupported { get; set; }
        bool IsCoteachingStyleObservedDescriptorSupported { get; set; }
        bool IsPerformanceEvaluationRatingLevelDescriptorSupported { get; set; }
        bool IsPerformanceEvaluationRatingResultsSupported { get; set; }
        bool IsPerformanceEvaluationRatingReviewersSupported { get; set; }
        bool IsScheduleDateSupported { get; set; }
        Func<IPerformanceEvaluationRatingResult, bool> IsPerformanceEvaluationRatingResultIncluded { get; set; }
        Func<IPerformanceEvaluationRatingReviewer, bool> IsPerformanceEvaluationRatingReviewerIncluded { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingResultMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingResult source, IPerformanceEvaluationRatingResult target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingResultSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsResultDatatypeTypeDescriptorSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationRatingResultSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingResultSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.Rating = source.Rating;
            target.RatingResultTitle = source.RatingResultTitle;

            // Copy non-PK properties

            if (sourceSynchSupport.IsResultDatatypeTypeDescriptorSupported)
                target.ResultDatatypeTypeDescriptor = source.ResultDatatypeTypeDescriptor;
            else
                targetSynchSupport.IsResultDatatypeTypeDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingResultSynchronizationSourceSupport 
    {
        bool IsResultDatatypeTypeDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingReviewerMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingReviewer source, IPerformanceEvaluationRatingReviewer target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsReviewerPersonIdSupported)
                && target.ReviewerPersonId != source.ReviewerPersonId)
            {
                target.ReviewerPersonId = source.ReviewerPersonId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReviewerSourceSystemDescriptorSupported)
                && target.ReviewerSourceSystemDescriptor != source.ReviewerSourceSystemDescriptor)
            {
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
                isModified = true;
            }

            // ----------------------------------
            //   Synch One-to-one relationships
            // ----------------------------------
            // PerformanceEvaluationRatingReviewerReceivedTraining
            if (sourceSupport == null || sourceSupport.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.FirstName = source.FirstName;
            target.LastSurname = source.LastSurname;

            // Copy non-PK properties

            if (sourceSynchSupport.IsReviewerPersonIdSupported)
                target.ReviewerPersonId = source.ReviewerPersonId;
            else
                targetSynchSupport.IsReviewerPersonIdSupported = false;

            if (sourceSynchSupport.IsReviewerSourceSystemDescriptorSupported)
                target.ReviewerSourceSystemDescriptor = source.ReviewerSourceSystemDescriptor;
            else
                targetSynchSupport.IsReviewerSourceSystemDescriptorSupported = false;

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
            // PerformanceEvaluationRatingReviewerReceivedTraining (Source)
            if (sourceSynchSupport.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported)
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
            else
            {
                targetSynchSupport.IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported = false;
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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerSynchronizationSourceSupport 
    {
        bool IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported { get; set; }
        bool IsReviewerPersonIdSupported { get; set; }
        bool IsReviewerSourceSystemDescriptorSupported { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingReviewerReceivedTrainingMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingReviewerReceivedTraining source, IPerformanceEvaluationRatingReviewerReceivedTraining target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsInterRaterReliabilityScoreSupported)
                && target.InterRaterReliabilityScore != source.InterRaterReliabilityScore)
            {
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsReceivedTrainingDateSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsInterRaterReliabilityScoreSupported)
                target.InterRaterReliabilityScore = source.InterRaterReliabilityScore;
            else
                targetSynchSupport.IsInterRaterReliabilityScoreSupported = false;

            if (sourceSynchSupport.IsReceivedTrainingDateSupported)
                target.ReceivedTrainingDate = source.ReceivedTrainingDate;
            else
                targetSynchSupport.IsReceivedTrainingDateSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerReceivedTrainingSynchronizationSourceSupport 
    {
        bool IsInterRaterReliabilityScoreSupported { get; set; }
        bool IsReceivedTrainingDateSupported { get; set; }
    }

}
// Aggregate: PerformanceEvaluationRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationRatingLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationRatingLevelDescriptor source, IPerformanceEvaluationRatingLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PerformanceEvaluationRatingLevelDescriptorId != target.PerformanceEvaluationRatingLevelDescriptorId)
            {
                source.PerformanceEvaluationRatingLevelDescriptorId = target.PerformanceEvaluationRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.PerformanceEvaluationRatingLevelDescriptorId = source.PerformanceEvaluationRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: PerformanceEvaluationTypeDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.PerformanceEvaluationTypeDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class PerformanceEvaluationTypeDescriptorMapper
    {
        public static bool SynchronizeTo(this IPerformanceEvaluationTypeDescriptor source, IPerformanceEvaluationTypeDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.PerformanceEvaluationTypeDescriptorId != target.PerformanceEvaluationTypeDescriptorId)
            {
                source.PerformanceEvaluationTypeDescriptorId = target.PerformanceEvaluationTypeDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.PerformanceEvaluationTypeDescriptorId = source.PerformanceEvaluationTypeDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IPerformanceEvaluationTypeDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: RubricDimension

namespace EdFi.Ods.Entities.Common.TPDM //.RubricDimensionAggregate
{
    [ExcludeFromCodeCoverage]
    public static class RubricDimensionMapper
    {
        public static bool SynchronizeTo(this IRubricDimension source, IRubricDimension target)
        {
            bool isModified = false;

            var sourceSupport = source as IRubricDimensionSynchronizationSourceSupport;

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

            if ((sourceSupport == null || sourceSupport.IsCriterionDescriptionSupported)
                && target.CriterionDescription != source.CriterionDescription)
            {
                target.CriterionDescription = source.CriterionDescription;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDimensionOrderSupported)
                && target.DimensionOrder != source.DimensionOrder)
            {
                target.DimensionOrder = source.DimensionOrder;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsRubricRatingLevelDescriptorSupported)
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
            var sourceSynchSupport = source as IRubricDimensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IRubricDimensionSynchronizationSourceSupport;

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

            if (sourceSynchSupport.IsCriterionDescriptionSupported)
                target.CriterionDescription = source.CriterionDescription;
            else
                targetSynchSupport.IsCriterionDescriptionSupported = false;

            if (sourceSynchSupport.IsDimensionOrderSupported)
                target.DimensionOrder = source.DimensionOrder;
            else
                targetSynchSupport.IsDimensionOrderSupported = false;

            if (sourceSynchSupport.IsRubricRatingLevelDescriptorSupported)
                target.RubricRatingLevelDescriptor = source.RubricRatingLevelDescriptor;
            else
                targetSynchSupport.IsRubricRatingLevelDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IRubricDimensionSynchronizationSourceSupport 
    {
        bool IsCriterionDescriptionSupported { get; set; }
        bool IsDimensionOrderSupported { get; set; }
        bool IsRubricRatingLevelDescriptorSupported { get; set; }
    }

}
// Aggregate: RubricRatingLevelDescriptor

namespace EdFi.Ods.Entities.Common.TPDM //.RubricRatingLevelDescriptorAggregate
{
    [ExcludeFromCodeCoverage]
    public static class RubricRatingLevelDescriptorMapper
    {
        public static bool SynchronizeTo(this IRubricRatingLevelDescriptor source, IRubricRatingLevelDescriptor target)
        {
            bool isModified = false;

            var sourceSupport = source as IRubricRatingLevelDescriptorSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.RubricRatingLevelDescriptorId != target.RubricRatingLevelDescriptorId)
            {
                source.RubricRatingLevelDescriptorId = target.RubricRatingLevelDescriptorId;
            }

            // Copy inherited non-PK properties


            if ((sourceSupport == null || sourceSupport.IsCodeValueSupported)
                && target.CodeValue != source.CodeValue)
            {
                target.CodeValue = source.CodeValue;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsDescriptionSupported)
                && target.Description != source.Description)
            {
                target.Description = source.Description;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveBeginDateSupported)
                && target.EffectiveBeginDate != source.EffectiveBeginDate)
            {
                target.EffectiveBeginDate = source.EffectiveBeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEffectiveEndDateSupported)
                && target.EffectiveEndDate != source.EffectiveEndDate)
            {
                target.EffectiveEndDate = source.EffectiveEndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNamespaceSupported)
                && target.Namespace != source.Namespace)
            {
                target.Namespace = source.Namespace;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPriorDescriptorIdSupported)
                && target.PriorDescriptorId != source.PriorDescriptorId)
            {
                target.PriorDescriptorId = source.PriorDescriptorId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsShortDescriptionSupported)
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
            var sourceSynchSupport = source as IRubricRatingLevelDescriptorSynchronizationSourceSupport;
            var targetSynchSupport = target as IRubricRatingLevelDescriptorSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.RubricRatingLevelDescriptorId = source.RubricRatingLevelDescriptorId;

            // Copy inherited non-PK properties

            if (sourceSynchSupport.IsCodeValueSupported)
                target.CodeValue = source.CodeValue;
            else
                targetSynchSupport.IsCodeValueSupported = false;

            if (sourceSynchSupport.IsDescriptionSupported)
                target.Description = source.Description;
            else
                targetSynchSupport.IsDescriptionSupported = false;

            if (sourceSynchSupport.IsEffectiveBeginDateSupported)
                target.EffectiveBeginDate = source.EffectiveBeginDate;
            else
                targetSynchSupport.IsEffectiveBeginDateSupported = false;

            if (sourceSynchSupport.IsEffectiveEndDateSupported)
                target.EffectiveEndDate = source.EffectiveEndDate;
            else
                targetSynchSupport.IsEffectiveEndDateSupported = false;

            if (sourceSynchSupport.IsNamespaceSupported)
                target.Namespace = source.Namespace;
            else
                targetSynchSupport.IsNamespaceSupported = false;

            if (sourceSynchSupport.IsPriorDescriptorIdSupported)
                target.PriorDescriptorId = source.PriorDescriptorId;
            else
                targetSynchSupport.IsPriorDescriptorIdSupported = false;

            if (sourceSynchSupport.IsShortDescriptionSupported)
                target.ShortDescription = source.ShortDescription;
            else
                targetSynchSupport.IsShortDescriptionSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IRubricRatingLevelDescriptorSynchronizationSourceSupport 
    {
        bool IsCodeValueSupported { get; set; }
        bool IsDescriptionSupported { get; set; }
        bool IsEffectiveBeginDateSupported { get; set; }
        bool IsEffectiveEndDateSupported { get; set; }
        bool IsNamespaceSupported { get; set; }
        bool IsPriorDescriptorIdSupported { get; set; }
        bool IsShortDescriptionSupported { get; set; }
    }

}
// Aggregate: School

namespace EdFi.Ods.Entities.Common.TPDM //.SchoolAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SchoolExtensionMapper
    {
        public static bool SynchronizeTo(this ISchoolExtension source, ISchoolExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as ISchoolExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.School as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("TPDM"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsPostSecondaryInstitutionIdSupported)
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
            var sourceSynchSupport = source as ISchoolExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as ISchoolExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsPostSecondaryInstitutionIdSupported)
                target.PostSecondaryInstitutionId = source.PostSecondaryInstitutionId;
            else
                targetSynchSupport.IsPostSecondaryInstitutionIdSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISchoolExtensionSynchronizationSourceSupport 
    {
        bool IsPostSecondaryInstitutionIdSupported { get; set; }
    }

}
// Aggregate: SurveyResponse

namespace EdFi.Ods.Entities.Common.TPDM //.SurveyResponseAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveyResponseExtensionMapper
    {
        public static bool SynchronizeTo(this ISurveyResponseExtension source, ISurveyResponseExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as ISurveyResponseExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.SurveyResponse as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("TPDM"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsPersonIdSupported)
                && target.PersonId != source.PersonId)
            {
                target.PersonId = source.PersonId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSourceSystemDescriptorSupported)
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
            var sourceSynchSupport = source as ISurveyResponseExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as ISurveyResponseExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsPersonIdSupported)
                target.PersonId = source.PersonId;
            else
                targetSynchSupport.IsPersonIdSupported = false;

            if (sourceSynchSupport.IsSourceSystemDescriptorSupported)
                target.SourceSystemDescriptor = source.SourceSystemDescriptor;
            else
                targetSynchSupport.IsSourceSystemDescriptorSupported = false;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISurveyResponseExtensionSynchronizationSourceSupport 
    {
        bool IsPersonIdSupported { get; set; }
        bool IsSourceSystemDescriptorSupported { get; set; }
    }

}
// Aggregate: SurveyResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.SurveyResponsePersonTargetAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveyResponsePersonTargetAssociationMapper
    {
        public static bool SynchronizeTo(this ISurveyResponsePersonTargetAssociation source, ISurveyResponsePersonTargetAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as ISurveyResponsePersonTargetAssociationSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ISurveyResponsePersonTargetAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as ISurveyResponsePersonTargetAssociationSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISurveyResponsePersonTargetAssociationSynchronizationSourceSupport 
    {
    }

}
// Aggregate: SurveySectionResponsePersonTargetAssociation

namespace EdFi.Ods.Entities.Common.TPDM //.SurveySectionResponsePersonTargetAssociationAggregate
{
    [ExcludeFromCodeCoverage]
    public static class SurveySectionResponsePersonTargetAssociationMapper
    {
        public static bool SynchronizeTo(this ISurveySectionResponsePersonTargetAssociation source, ISurveySectionResponsePersonTargetAssociation target)
        {
            bool isModified = false;

            var sourceSupport = source as ISurveySectionResponsePersonTargetAssociationSynchronizationSourceSupport;

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
            var sourceSynchSupport = source as ISurveySectionResponsePersonTargetAssociationSynchronizationSourceSupport;
            var targetSynchSupport = target as ISurveySectionResponsePersonTargetAssociationSynchronizationSourceSupport;

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

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface ISurveySectionResponsePersonTargetAssociationSynchronizationSourceSupport 
    {
    }

}
