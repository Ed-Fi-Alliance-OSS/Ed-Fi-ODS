// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Tests.EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi
{
    /// <summary>
    /// A class which represents the edfi.Staff table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Staff
    {
        // =============================================================
        //                          Collections
        // -------------------------------------------------------------

        private IList<StaffLanguage> _staffLanguages;

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public Staff()
        {
            StaffLanguages = new List<StaffLanguage>();
        }

        // -------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the Staff resource.
        /// </summary>
        [DataMember(Name = "id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique alphanumeric code assigned to a staff.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "staffUniqueId")]
        [NaturalKeyMember]
        [UniqueId]
        public string StaffUniqueId { get; set; }

        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The month, day, and year on which an individual was born.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "birthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>

        // NOT in a reference, IS a lookup column 
        [DataMember(Name = "citizenshipStatusType")]
        public string CitizenshipStatusType { get; set; }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "generationCodeSuffix")]
        public string GenerationCodeSuffix { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>

        // NOT in a reference, IS a lookup column 
        [DataMember(Name = "highestCompletedLevelOfEducationDescriptor")]
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "highlyQualifiedTeacher")]
        public bool? HighlyQualifiedTeacher { get; set; }

        /// <summary>
        /// An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\"
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "hispanicLatinoEthnicity")]
        public bool HispanicLatinoEthnicity { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "lastSurname")]
        public string LastSurname { get; set; }

        /// <summary>
        /// The login ID for the user; used for security access control interface.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "loginId")]
        public string LoginId { get; set; }

        /// <summary>
        /// The person's maiden name.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "maidenName")]
        public string MaidenName { get; set; }

        /// <summary>
        /// A secondary name given to an individual at birth, baptism, or during another naming ceremony.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin
        /// </summary>

        // NOT in a reference, IS a lookup column 
        [DataMember(Name = "oldEthnicityType")]
        public string OldEthnicityType { get; set; }

        /// <summary>
        /// A prefix used to denote the title, degree, position, or seniority of the person.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "personalTitlePrefix")]
        public string PersonalTitlePrefix { get; set; }

        /// <summary>
        /// A person''s gender.
        /// </summary>

        // NOT in a reference, IS a lookup column 
        [DataMember(Name = "sexType")]
        public string SexType { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a similar professional position in one or more education institutions.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "yearsOfPriorProfessionalExperience")]
        [Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? YearsOfPriorProfessionalExperience { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a teaching position in one or more education institutions.
        /// </summary>

        // NOT in a reference, NOT a lookup column 
        [DataMember(Name = "yearsOfPriorTeachingExperience")]
        [Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? YearsOfPriorTeachingExperience { get; set; }

        // -------------------------------------------------------------

        [JsonProperty("_ext")]
        [JsonConverter(
            typeof(ExtensionsConverterWithAssemblyOverride),
            "Staff",
            "Staff")]
        public IDictionary Extensions { get; set; }

        [DataMember(Name = "languages")]
        public IList<StaffLanguage> StaffLanguages
        {
            get { return _staffLanguages; }
            set
            {
                if (value == null)
                {
                    return;
                }

                _staffLanguages = value;
            }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name = "_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------
    }
}
