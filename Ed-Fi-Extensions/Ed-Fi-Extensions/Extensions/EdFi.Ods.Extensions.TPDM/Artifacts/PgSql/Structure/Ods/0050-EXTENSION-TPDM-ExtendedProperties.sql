-- Extended Properties [tpdm].[AccreditationStatusDescriptor] --
COMMENT ON TABLE tpdm.AccreditationStatusDescriptor IS 'Accreditation Status for a Teacher Preparation Provider.';
COMMENT ON COLUMN tpdm.AccreditationStatusDescriptor.AccreditationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[AidTypeDescriptor] --
COMMENT ON TABLE tpdm.AidTypeDescriptor IS 'This descriptor defines the classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.AidTypeDescriptor.AidTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicantProfile] --
COMMENT ON TABLE tpdm.ApplicantProfile IS 'The profile of the person making an application';
COMMENT ON COLUMN tpdm.ApplicantProfile.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfile.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.ApplicantProfile.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.ApplicantProfile.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.ApplicantProfile.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.ApplicantProfile.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.ApplicantProfile.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.ApplicantProfile.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.ApplicantProfile.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN tpdm.ApplicantProfile.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".';
COMMENT ON COLUMN tpdm.ApplicantProfile.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN tpdm.ApplicantProfile.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.ApplicantProfile.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.ApplicantProfile.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.ApplicantProfile.HighestCompletedLevelOfEducationDescriptorId IS 'The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).';
COMMENT ON COLUMN tpdm.ApplicantProfile.YearsOfPriorProfessionalExperience IS 'The total number of years that an individual has previously held a similar professional position in one or more education institutions.';
COMMENT ON COLUMN tpdm.ApplicantProfile.YearsOfPriorTeachingExperience IS 'The total number of years that an individual has previously held a teaching position in one or more education institutions.';
COMMENT ON COLUMN tpdm.ApplicantProfile.HighlyQualifiedTeacher IS 'An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.';

-- Extended Properties [tpdm].[ApplicantProfileAddress] --
COMMENT ON TABLE tpdm.ApplicantProfileAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [tpdm].[ApplicantProfileAddressPeriod] --
COMMENT ON TABLE tpdm.ApplicantProfileAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.ApplicantProfileAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[ApplicantProfileApplicantCharacteristic] --
COMMENT ON TABLE tpdm.ApplicantProfileApplicantCharacteristic IS 'Reflects important characteristics of the applicant''s home situation:
      Displaced Homemaker, Immigrant, Migratory, Military Parent, Pregnant Teen, Single Parent, and Unaccompanied Youth.';
COMMENT ON COLUMN tpdm.ApplicantProfileApplicantCharacteristic.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileApplicantCharacteristic.StudentCharacteristicDescriptorId IS 'The characteristic designated for the Student.';
COMMENT ON COLUMN tpdm.ApplicantProfileApplicantCharacteristic.BeginDate IS 'The date the characteristic was designated.';
COMMENT ON COLUMN tpdm.ApplicantProfileApplicantCharacteristic.EndDate IS 'The date the characteristic was removed.';
COMMENT ON COLUMN tpdm.ApplicantProfileApplicantCharacteristic.DesignatedBy IS 'The person, organization, or department that designated the characteristic.';

-- Extended Properties [tpdm].[ApplicantProfileBackgroundCheck] --
COMMENT ON TABLE tpdm.ApplicantProfileBackgroundCheck IS 'Applicant background check history and disposition.';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.ApplicantProfileBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[ApplicantProfileDisability] --
COMMENT ON TABLE tpdm.ApplicantProfileDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisability.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[ApplicantProfileDisabilityDesignation] --
COMMENT ON TABLE tpdm.ApplicantProfileDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisabilityDesignation.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.ApplicantProfileDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';

-- Extended Properties [tpdm].[ApplicantProfileEducatorPreparationProgramName] --
COMMENT ON TABLE tpdm.ApplicantProfileEducatorPreparationProgramName IS 'The Teacher Preparation Program(s) completed by the teacher.';
COMMENT ON COLUMN tpdm.ApplicantProfileEducatorPreparationProgramName.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileEducatorPreparationProgramName.EducatorPreparationProgramName IS 'The Teacher Preparation Program(s) completed by the teacher.';

-- Extended Properties [tpdm].[ApplicantProfileElectronicMail] --
COMMENT ON TABLE tpdm.ApplicantProfileElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.ApplicantProfileElectronicMail.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantProfileElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN tpdm.ApplicantProfileElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantProfileElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [tpdm].[ApplicantProfileGradePointAverage] --
COMMENT ON TABLE tpdm.ApplicantProfileGradePointAverage IS 'Data that provides information on a measure of average performance in a group of courses taken by an individual.';
COMMENT ON COLUMN tpdm.ApplicantProfileGradePointAverage.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileGradePointAverage.GradePointAverageTypeDescriptorId IS 'The system used for calculating the grade point average for an individual.';
COMMENT ON COLUMN tpdm.ApplicantProfileGradePointAverage.IsCumulative IS 'Indicator of whether or not the Grade Point Average value is cumulative.';
COMMENT ON COLUMN tpdm.ApplicantProfileGradePointAverage.GradePointAverageValue IS 'The value of the grade points earned divided by the number of credits attempted.';
COMMENT ON COLUMN tpdm.ApplicantProfileGradePointAverage.MaxGradePointAverageValue IS 'The maximum value for the grade point average.';

-- Extended Properties [tpdm].[ApplicantProfileHighlyQualifiedAcademicSubject] --
COMMENT ON TABLE tpdm.ApplicantProfileHighlyQualifiedAcademicSubject IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.ApplicantProfileHighlyQualifiedAcademicSubject.AcademicSubjectDescriptorId IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.ApplicantProfileHighlyQualifiedAcademicSubject.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';

-- Extended Properties [tpdm].[ApplicantProfileIdentificationDocument] --
COMMENT ON TABLE tpdm.ApplicantProfileIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.ApplicantProfileIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[ApplicantProfileInternationalAddress] --
COMMENT ON TABLE tpdm.ApplicantProfileInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the person moved to that address.';
COMMENT ON COLUMN tpdm.ApplicantProfileInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.';

-- Extended Properties [tpdm].[ApplicantProfileLanguage] --
COMMENT ON TABLE tpdm.ApplicantProfileLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.ApplicantProfileLanguage.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';

-- Extended Properties [tpdm].[ApplicantProfileLanguageUse] --
COMMENT ON TABLE tpdm.ApplicantProfileLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.ApplicantProfileLanguageUse.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.ApplicantProfileLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';

-- Extended Properties [tpdm].[ApplicantProfilePersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.ApplicantProfilePersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.ApplicantProfilePersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[ApplicantProfileRace] --
COMMENT ON TABLE tpdm.ApplicantProfileRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.ApplicantProfileRace.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';

-- Extended Properties [tpdm].[ApplicantProfileTelephone] --
COMMENT ON TABLE tpdm.ApplicantProfileTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.ApplicantProfileTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[ApplicantProfileVisa] --
COMMENT ON TABLE tpdm.ApplicantProfileVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN tpdm.ApplicantProfileVisa.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicantProfileVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [tpdm].[Application] --
COMMENT ON TABLE tpdm.Application IS 'An application for employment or acceptance.';
COMMENT ON COLUMN tpdm.Application.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.Application.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.Application.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Application.ApplicationDate IS 'The month, day, and year the application was submitted.';
COMMENT ON COLUMN tpdm.Application.ApplicationStatusDescriptorId IS 'Indicates the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).';
COMMENT ON COLUMN tpdm.Application.CurrentEmployee IS 'Indicator as to whether the applicant is a current employee of the school district.';
COMMENT ON COLUMN tpdm.Application.AcademicSubjectDescriptorId IS 'The academic subject for which the application is made.';
COMMENT ON COLUMN tpdm.Application.AcceptedDate IS 'The date of acceptance, if offered.';
COMMENT ON COLUMN tpdm.Application.ApplicationSourceDescriptorId IS 'Specifies the source for the application (e.g., Job fair, website, referral).';
COMMENT ON COLUMN tpdm.Application.FirstContactDate IS 'Date applicant was first contacted after submitting application.';
COMMENT ON COLUMN tpdm.Application.HighNeedsAcademicSubjectDescriptorId IS 'The high need academic subject for the application, if any.';
COMMENT ON COLUMN tpdm.Application.HireStatusDescriptorId IS 'Indicates the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).';
COMMENT ON COLUMN tpdm.Application.HiringSourceDescriptorId IS 'The source for the application (e.g.,job fair, website, referral, etc.).';
COMMENT ON COLUMN tpdm.Application.WithdrawDate IS 'The date the application was withdrawn by the applicant.';
COMMENT ON COLUMN tpdm.Application.WithdrawReasonDescriptorId IS 'Reason applicant withdrew application.';
COMMENT ON COLUMN tpdm.Application.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';

-- Extended Properties [tpdm].[ApplicationEvent] --
COMMENT ON TABLE tpdm.ApplicationEvent IS 'The life cycle events associated with an application (phone screen, review, interview, etc.).';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEventTypeDescriptorId IS 'Description of application event (e.g., added to pool, phone screen, interview, sample lesson).';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EventDate IS 'The date of the application event, or begin date if an interval.';
COMMENT ON COLUMN tpdm.ApplicationEvent.SequenceNumber IS 'The sequence number of the application events. This is used to discriminate between mutiple events of the same type in the same day.';
COMMENT ON COLUMN tpdm.ApplicationEvent.EventEndDate IS 'The end date of the event, if an interval.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEvaluationScore IS 'Application evaluation score, if applicable.';
COMMENT ON COLUMN tpdm.ApplicationEvent.ApplicationEventResultDescriptorId IS 'The recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).';
COMMENT ON COLUMN tpdm.ApplicationEvent.SchoolYear IS 'Identifier for a school year.';
COMMENT ON COLUMN tpdm.ApplicationEvent.TermDescriptorId IS 'This descriptor defines the term of a session during the school year (e.g., Fall Semester).';

-- Extended Properties [tpdm].[ApplicationEventResultDescriptor] --
COMMENT ON TABLE tpdm.ApplicationEventResultDescriptor IS 'The descriptor holds the recommendation, result or conclusion of the application event (e.g., Continue, exit, recommend for hire).';
COMMENT ON COLUMN tpdm.ApplicationEventResultDescriptor.ApplicationEventResultDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationEventTypeDescriptor] --
COMMENT ON TABLE tpdm.ApplicationEventTypeDescriptor IS 'The descriptor holds the description of application event (e.g., added to pool, phone screen, interview, sample lesson).';
COMMENT ON COLUMN tpdm.ApplicationEventTypeDescriptor.ApplicationEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationRecruitmentEventAttendance] --
COMMENT ON TABLE tpdm.ApplicationRecruitmentEventAttendance IS 'The recuitment event(s) associated with the Application.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.ApplicationRecruitmentEventAttendance.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';

-- Extended Properties [tpdm].[ApplicationScoreResult] --
COMMENT ON TABLE tpdm.ApplicationScoreResult IS 'A meaningful score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.AssessmentReportingMethodDescriptorId IS 'The method that the administrator of the assessment uses to report the performance and achievement of all students. It may be a qualitative method such as performance level descriptors or a quantitative method such as a numerical grade or cut score. More than one type of reporting method may be used.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.Result IS 'The value of a meaningful raw score or statistical expression of the performance of an individual. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.ApplicationScoreResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[ApplicationSourceDescriptor] --
COMMENT ON TABLE tpdm.ApplicationSourceDescriptor IS 'The descriptor holds the source for the application (e.g., Job fair, website, referral).';
COMMENT ON COLUMN tpdm.ApplicationSourceDescriptor.ApplicationSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationStatusDescriptor] --
COMMENT ON TABLE tpdm.ApplicationStatusDescriptor IS 'The descriptor holds the current status of the application (e.g., received, phone screen, interview, awaiting decision, etc.).';
COMMENT ON COLUMN tpdm.ApplicationStatusDescriptor.ApplicationStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ApplicationTerm] --
COMMENT ON TABLE tpdm.ApplicationTerm IS 'The intended term of enrollment for which the application is being submitted.';
COMMENT ON COLUMN tpdm.ApplicationTerm.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';
COMMENT ON COLUMN tpdm.ApplicationTerm.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.ApplicationTerm.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.ApplicationTerm.TermDescriptorId IS 'The intended term of enrollment for which the application is being submitted.';

-- Extended Properties [tpdm].[AssessmentExtension] --
COMMENT ON TABLE tpdm.AssessmentExtension IS '';
COMMENT ON COLUMN tpdm.AssessmentExtension.AssessmentIdentifier IS 'A unique number or alphanumeric code assigned to an assessment.';
COMMENT ON COLUMN tpdm.AssessmentExtension.Namespace IS 'Namespace for the Assessment.';
COMMENT ON COLUMN tpdm.AssessmentExtension.ProgramGatewayDescriptorId IS 'Identifies the program gateway an assessment may be associated with for continuation in the program.';

-- Extended Properties [tpdm].[BackgroundCheckStatusDescriptor] --
COMMENT ON TABLE tpdm.BackgroundCheckStatusDescriptor IS 'This descriptor holds the  status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.BackgroundCheckStatusDescriptor.BackgroundCheckStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[BackgroundCheckTypeDescriptor] --
COMMENT ON TABLE tpdm.BackgroundCheckTypeDescriptor IS 'This descriptor defines the classification of the background check a person receives.';
COMMENT ON COLUMN tpdm.BackgroundCheckTypeDescriptor.BackgroundCheckTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Candidate] --
COMMENT ON TABLE tpdm.Candidate IS 'A candidate is a person is enrolled in a educator preparation program and is a candidate to become an educator.';
COMMENT ON COLUMN tpdm.Candidate.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.Candidate.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.Candidate.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.Candidate.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.Candidate.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.Candidate.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.Candidate.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.Candidate.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.Candidate.BirthDate IS 'The month, day, and year on which an individual was born.';
COMMENT ON COLUMN tpdm.Candidate.BirthCity IS 'The city the student was born in.';
COMMENT ON COLUMN tpdm.Candidate.BirthStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.';
COMMENT ON COLUMN tpdm.Candidate.BirthInternationalProvince IS 'For students born outside of the U.S., the Province or jurisdiction in which an individual is born.';
COMMENT ON COLUMN tpdm.Candidate.BirthCountryDescriptorId IS 'The country in which an individual is born. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.Candidate.DateEnteredUS IS 'For students born outside of the U.S., the date the student entered the U.S.';
COMMENT ON COLUMN tpdm.Candidate.MultipleBirthStatus IS 'Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)';
COMMENT ON COLUMN tpdm.Candidate.BirthSexDescriptorId IS 'A person''s gender at birth.';
COMMENT ON COLUMN tpdm.Candidate.ProfileThumbnail IS 'Locator for the student photo.';
COMMENT ON COLUMN tpdm.Candidate.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino."';
COMMENT ON COLUMN tpdm.Candidate.OldEthnicityDescriptorId IS 'Previous definition of Ethnicity combining Hispanic/Latino and race: 1 - American Indian or Alaskan Native 2 - Asian or Pacific Islander 3 - Black, not of Hispanic origin 4 - Hispanic 5 - White, not of Hispanic origin.';
COMMENT ON COLUMN tpdm.Candidate.CitizenshipStatusDescriptorId IS 'An indicator of whether or not the person is a U.S. citizen.';
COMMENT ON COLUMN tpdm.Candidate.EconomicDisadvantaged IS 'An indication of inadequate financial condition of an individual''s family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.';
COMMENT ON COLUMN tpdm.Candidate.LimitedEnglishProficiencyDescriptorId IS 'An indication that the student has been identified as limited English proficient by the Language Proficiency Assessment Committee (LPAC), or English proficient.';
COMMENT ON COLUMN tpdm.Candidate.DisplacementStatus IS 'Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.';
COMMENT ON COLUMN tpdm.Candidate.LoginId IS 'The login ID for the user; used for security access control interface.';
COMMENT ON COLUMN tpdm.Candidate.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.Candidate.TuitionCost IS 'The tuition for a person''s participation in a program, service. or course.';
COMMENT ON COLUMN tpdm.Candidate.EnglishLanguageExamDescriptorId IS 'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).';
COMMENT ON COLUMN tpdm.Candidate.PreviousCareerDescriptorId IS 'The career previous for an individual.';
COMMENT ON COLUMN tpdm.Candidate.ProgramComplete IS 'An indication of whether a candidate has completed the educator preparation program.';
COMMENT ON COLUMN tpdm.Candidate.FirstGenerationStudent IS 'Indicator of whether individual is a first generation college student.';
COMMENT ON COLUMN tpdm.Candidate.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Candidate.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.Candidate.ApplicationIdentifier IS 'Identifier assigned to the application for a candidate or open staff position.';
COMMENT ON COLUMN tpdm.Candidate.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Candidate.ApplicantProfileIdentifier IS 'Identifier assigned to a person making formal application for entrance into a program or an open staff position.';

-- Extended Properties [tpdm].[CandidateAddress] --
COMMENT ON TABLE tpdm.CandidateAddress IS 'The set of elements that describes an address, including the street address, city, state, and ZIP code.';
COMMENT ON COLUMN tpdm.CandidateAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.CandidateAddress.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateAddress.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.ApartmentRoomSuiteNumber IS 'The apartment, room, or suite number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddress.BuildingSiteNumber IS 'The number of the building on the site, if more than one building shares the same address.';
COMMENT ON COLUMN tpdm.CandidateAddress.NameOfCounty IS 'The name of the county, parish, borough, or comparable unit (within a state) in
                      ''which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.CountyFIPSCode IS 'The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the "first-order subdivisions" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.';
COMMENT ON COLUMN tpdm.CandidateAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateAddress.DoNotPublishIndicator IS 'An indication that the address should not be published.';
COMMENT ON COLUMN tpdm.CandidateAddress.CongressionalDistrict IS 'The congressional district in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddress.LocaleDescriptorId IS 'A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).';

-- Extended Properties [tpdm].[CandidateAddressPeriod] --
COMMENT ON TABLE tpdm.CandidateAddressPeriod IS 'The time periods for which the address is valid. For physical addresses, the periods in which the person lived at that address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.City IS 'The name of the city in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.PostalCode IS 'The five or nine digit zip code or overseas postal code portion of an address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.StateAbbreviationDescriptorId IS 'The abbreviation for the state (within the United States) or outlying area in which an address is located.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.StreetNumberName IS 'The street number and street name or post office box number of an address.';
COMMENT ON COLUMN tpdm.CandidateAddressPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[CandidateAid] --
COMMENT ON TABLE tpdm.CandidateAid IS 'This entity represents the financial aid a person is awarded.';
COMMENT ON COLUMN tpdm.CandidateAid.AidTypeDescriptorId IS 'The classification of financial aid awarded to a person for the academic term/year.';
COMMENT ON COLUMN tpdm.CandidateAid.BeginDate IS 'The date the award was designated.';
COMMENT ON COLUMN tpdm.CandidateAid.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateAid.EndDate IS 'The date the award was removed.';
COMMENT ON COLUMN tpdm.CandidateAid.AidConditionDescription IS 'The description of the condition (e.g., placement in a high need school) under which the aid was given.';
COMMENT ON COLUMN tpdm.CandidateAid.AidAmount IS 'The amount of financial aid awarded to a person for the term/year.';
COMMENT ON COLUMN tpdm.CandidateAid.PellGrantRecipient IS 'Indicates a person who receives Pell Grant aid.';

-- Extended Properties [tpdm].[CandidateBackgroundCheck] --
COMMENT ON TABLE tpdm.CandidateBackgroundCheck IS 'Applicant background check history and disposition.';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.CandidateBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[CandidateCharacteristic] --
COMMENT ON TABLE tpdm.CandidateCharacteristic IS 'Reflects important characteristics of the candidate (e.g, immigrant, first generation graduate, economically disadvantaged)';
COMMENT ON COLUMN tpdm.CandidateCharacteristic.CandidateCharacteristicDescriptorId IS 'The characteristic designated for the candidate.';
COMMENT ON COLUMN tpdm.CandidateCharacteristic.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateCharacteristic.BeginDate IS 'The date the characteristic was designated.';
COMMENT ON COLUMN tpdm.CandidateCharacteristic.EndDate IS 'The date the characteristic was removed.';
COMMENT ON COLUMN tpdm.CandidateCharacteristic.DesignatedBy IS 'The person, organization, or department that designated the characteristic.';

-- Extended Properties [tpdm].[CandidateCharacteristicDescriptor] --
COMMENT ON TABLE tpdm.CandidateCharacteristicDescriptor IS 'Reflects important charactersitics of the candidate (e.g, immigrant, first generation graduate, economically disadvantaged)';
COMMENT ON COLUMN tpdm.CandidateCharacteristicDescriptor.CandidateCharacteristicDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CandidateCohortYear] --
COMMENT ON TABLE tpdm.CandidateCohortYear IS 'The type and year of a cohort (e.g., 9th grade) the student belongs to as determined by the year that student entered a specific grade.';
COMMENT ON COLUMN tpdm.CandidateCohortYear.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateCohortYear.CohortYearTypeDescriptorId IS 'The type of cohort year (9th grade, graduation).';
COMMENT ON COLUMN tpdm.CandidateCohortYear.SchoolYear IS 'The value of the  school year for the Cohort.';

-- Extended Properties [tpdm].[CandidateDegreeSpecialization] --
COMMENT ON TABLE tpdm.CandidateDegreeSpecialization IS 'Information around the area(s) of specialization for an individual.';
COMMENT ON COLUMN tpdm.CandidateDegreeSpecialization.BeginDate IS 'The month, day, and year on which the Teacher Candidate first declared specialization.';
COMMENT ON COLUMN tpdm.CandidateDegreeSpecialization.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateDegreeSpecialization.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.CandidateDegreeSpecialization.MinorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.CandidateDegreeSpecialization.EndDate IS 'The month, day, and year on which the Teacher Candidate exited the declared specialization.';

-- Extended Properties [tpdm].[CandidateDisability] --
COMMENT ON TABLE tpdm.CandidateDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisability.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.CandidateDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.CandidateDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[CandidateDisabilityDesignation] --
COMMENT ON TABLE tpdm.CandidateDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.CandidateDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociation] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociation IS 'Information about the association between the Teacher Candidate and the EducatorPreparationProgram';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EndDate IS 'The end date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.ReasonExitedDescriptorId IS 'Reason exited for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.EPPProgramPathwayDescriptorId IS 'A code for describing the program pathway, for example: Residency, Internship, Traditional';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.MajorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociation.MinorSpecialization IS 'The major area for a degree or area of specialization for a certificate.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b IS 'Indicator(s) or metric(s) computed for the candidate in the EPP.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.BeginDate IS 'The begin date for the association.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.IndicatorGroup IS 'The name for a group of indicators.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.Indicator IS 'The value of the indicator or metric.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_0d7c2b.DesignatedBy IS 'The person, organization, or department that designated the program association.';

-- Extended Properties [tpdm].[CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14] --
COMMENT ON TABLE tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14 IS 'The time periods for which the indicator was effective.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.CandidateEducatorPreparationProgramAssociationCandidateI_fc4f14.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[CandidateElectronicMail] --
COMMENT ON TABLE tpdm.CandidateElectronicMail IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.ElectronicMailAddress IS 'The electronic mail (e-mail) address listed for an individual or organization.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.ElectronicMailTypeDescriptorId IS 'The type of email listed for an individual or organization. For example: Home/Personal, Work, etc.)';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.PrimaryEmailAddressIndicator IS 'An indication that the electronic mail address should be used as the principal electronic mail address for an individual or organization.';
COMMENT ON COLUMN tpdm.CandidateElectronicMail.DoNotPublishIndicator IS 'An indication that the electronic email address should not be published.';

-- Extended Properties [tpdm].[CandidateEPPProgramDegree] --
COMMENT ON TABLE tpdm.CandidateEPPProgramDegree IS 'Details of the degree.';
COMMENT ON COLUMN tpdm.CandidateEPPProgramDegree.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a degree.';
COMMENT ON COLUMN tpdm.CandidateEPPProgramDegree.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateEPPProgramDegree.EPPDegreeTypeDescriptorId IS 'A code for describing the degree type that a candidate accomplishes.';
COMMENT ON COLUMN tpdm.CandidateEPPProgramDegree.GradeLevelDescriptorId IS 'The grade level associated with the degree plan for the candidate.';

-- Extended Properties [tpdm].[CandidateIdentificationCode] --
COMMENT ON TABLE tpdm.CandidateIdentificationCode IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a candidate.';
COMMENT ON COLUMN tpdm.CandidateIdentificationCode.AssigningOrganizationIdentificationCode IS 'The organization code or name assigning the StudentIdentificationCode.';
COMMENT ON COLUMN tpdm.CandidateIdentificationCode.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateIdentificationCode.IdentificationCode IS 'A unique number or alphanumeric code assigned to a person by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN tpdm.CandidateIdentificationCode.StudentIdentificationSystemDescriptorId IS 'A coding scheme that is used for identification and record-keeping purposes by schools, social services, or other agencies to refer to a candidate.';

-- Extended Properties [tpdm].[CandidateIdentificationDocument] --
COMMENT ON TABLE tpdm.CandidateIdentificationDocument IS 'Describe the documentation of citizenship.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.CandidateIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[CandidateIndicator] --
COMMENT ON TABLE tpdm.CandidateIndicator IS 'Indicator(s) or metric(s) computed for the candidate.';
COMMENT ON COLUMN tpdm.CandidateIndicator.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateIndicator.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN tpdm.CandidateIndicator.IndicatorGroup IS 'The name for a group of indicators.';
COMMENT ON COLUMN tpdm.CandidateIndicator.Indicator IS 'The value of the indicator or metric.';
COMMENT ON COLUMN tpdm.CandidateIndicator.DesignatedBy IS 'The person, organization, or department that designated the program association.';

-- Extended Properties [tpdm].[CandidateIndicatorPeriod] --
COMMENT ON TABLE tpdm.CandidateIndicatorPeriod IS 'The time periods for which the indicator was effective.';
COMMENT ON COLUMN tpdm.CandidateIndicatorPeriod.BeginDate IS 'The month, day, and year for the start of the period.';
COMMENT ON COLUMN tpdm.CandidateIndicatorPeriod.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateIndicatorPeriod.IndicatorName IS 'The name of the indicator or metric.';
COMMENT ON COLUMN tpdm.CandidateIndicatorPeriod.EndDate IS 'The month, day, and year for the end of the period.';

-- Extended Properties [tpdm].[CandidateInternationalAddress] --
COMMENT ON TABLE tpdm.CandidateInternationalAddress IS 'The set of elements that describes an international address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.AddressTypeDescriptorId IS 'The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.AddressLine1 IS 'The first line of the address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.AddressLine2 IS 'The second line of the address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.AddressLine3 IS 'The third line of the address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.AddressLine4 IS 'The fourth line of the address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.CountryDescriptorId IS 'The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.Latitude IS 'The geographic latitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.Longitude IS 'The geographic longitude of the physical address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.BeginDate IS 'The first date the address is valid. For physical addresses, the date the person moved to that address.';
COMMENT ON COLUMN tpdm.CandidateInternationalAddress.EndDate IS 'The last date the address is valid. For physical addresses, this would be the date the person moved from that address.';

-- Extended Properties [tpdm].[CandidateLanguage] --
COMMENT ON TABLE tpdm.CandidateLanguage IS 'The language(s) the individual uses to communicate.';
COMMENT ON COLUMN tpdm.CandidateLanguage.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateLanguage.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';

-- Extended Properties [tpdm].[CandidateLanguageUse] --
COMMENT ON TABLE tpdm.CandidateLanguageUse IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.LanguageDescriptorId IS 'A specification of which written or spoken communication is being used.';
COMMENT ON COLUMN tpdm.CandidateLanguageUse.LanguageUseDescriptorId IS 'A description of how the language is used (e.g. Home Language, Native Language, Spoken Language).';

-- Extended Properties [tpdm].[CandidateOtherName] --
COMMENT ON TABLE tpdm.CandidateOtherName IS 'Other names (e.g., alias, nickname, previous legal name) associated with a person.';
COMMENT ON COLUMN tpdm.CandidateOtherName.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateOtherName.OtherNameTypeDescriptorId IS 'The types of alternate names for a person.';
COMMENT ON COLUMN tpdm.CandidateOtherName.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.CandidateOtherName.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.CandidateOtherName.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.CandidateOtherName.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.CandidateOtherName.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';

-- Extended Properties [tpdm].[CandidatePersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.CandidatePersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.CandidatePersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[CandidateRace] --
COMMENT ON TABLE tpdm.CandidateRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.CandidateRace.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The data model allows for multiple entries so that each individual can specify all appropriate races.';

-- Extended Properties [tpdm].[CandidateRelationshipToStaffAssociation] --
COMMENT ON TABLE tpdm.CandidateRelationshipToStaffAssociation IS 'This describes a relationship between a (current) candidate and a staff person, typically at a K12 partnering district in the role of a mentor teacher, coordinating teacher, supervising principal, etc. It could also describe the relationship between a (current) candidate and a university staff member, i.e., field placement supervisor, advisor, etc. This is a relationship between two different people';
COMMENT ON COLUMN tpdm.CandidateRelationshipToStaffAssociation.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateRelationshipToStaffAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.CandidateRelationshipToStaffAssociation.StaffToCandidateRelationshipDescriptorId IS 'Defines the staff relationship to the candidate (e.g., supervising principal, mentor, coordinating teacher, etc. )';
COMMENT ON COLUMN tpdm.CandidateRelationshipToStaffAssociation.BeginDate IS 'The month, day, and year on which the candidate is associated to the staff.';
COMMENT ON COLUMN tpdm.CandidateRelationshipToStaffAssociation.EndDate IS 'The month, day, and year on which the candidate stops association with the staff.';

-- Extended Properties [tpdm].[CandidateTelephone] --
COMMENT ON TABLE tpdm.CandidateTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.CandidateTelephone.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.CandidateTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.CandidateTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.CandidateTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[CandidateVisa] --
COMMENT ON TABLE tpdm.CandidateVisa IS 'An indicator of a non-US citizen''s Visa type.';
COMMENT ON COLUMN tpdm.CandidateVisa.CandidateIdentifier IS 'A unique alphanumeric code assigned to a candidate.';
COMMENT ON COLUMN tpdm.CandidateVisa.VisaDescriptorId IS 'An indicator of a non-US citizen''s Visa type.';

-- Extended Properties [tpdm].[Certification] --
COMMENT ON TABLE tpdm.Certification IS 'An offering by an official granting authority of a certification or license that qualifies persons to perform specific job functions, such as full fill a teaching assignment.';
COMMENT ON COLUMN tpdm.Certification.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.Certification.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.Certification.CertificationTitle IS 'The title of the Certification.';
COMMENT ON COLUMN tpdm.Certification.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Certification.CertificationLevelDescriptorId IS 'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.';
COMMENT ON COLUMN tpdm.Certification.CertificationFieldDescriptorId IS 'The field of certification (e.g., Mathematics, Music).';
COMMENT ON COLUMN tpdm.Certification.CertificationStandardDescriptorId IS 'The standard, law or policy defining the certification.';
COMMENT ON COLUMN tpdm.Certification.MinimumDegreeDescriptorId IS 'The minimum level of degree, if any, required for Certification.';
COMMENT ON COLUMN tpdm.Certification.EducatorRoleDescriptorId IS 'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.Certification.PopulationServedDescriptorId IS 'The type of students the Section is offered and tailored to; for example: Bilingual students, Remedial education students, Gifted and talented students, Career and Technical Education students, Special education students.';
COMMENT ON COLUMN tpdm.Certification.InstructionalSettingDescriptorId IS 'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.';
COMMENT ON COLUMN tpdm.Certification.EffectiveDate IS 'The year, month and day on which the Certification is offered.';
COMMENT ON COLUMN tpdm.Certification.EndDate IS 'The month, day, and year on which the Certification offering is expected to end.';

-- Extended Properties [tpdm].[CertificationCertificationExam] --
COMMENT ON TABLE tpdm.CertificationCertificationExam IS 'The Certification Eams required for the Certification.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationExamNamespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationCertificationExam.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationExam] --
COMMENT ON TABLE tpdm.CertificationExam IS 'An examination required by one or more Certifications.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExam.Namespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamTitle IS 'The title of the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExam.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CertificationExam.CertificationExamTypeDescriptorId IS 'The type or category of Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExam.EffectiveDate IS 'The year, month and day on which the CertificationExam is offered.';
COMMENT ON COLUMN tpdm.CertificationExam.EndDate IS 'The month, day, and year on which the CertificationExam offering is expected to end.';

-- Extended Properties [tpdm].[CertificationExamResult] --
COMMENT ON TABLE tpdm.CertificationExamResult IS 'The person''s result from taking a Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamDate IS 'The year, month and day on which the CertificationExam is taken.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamIdentifier IS 'Identifier or serial number assigned to the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.Namespace IS 'Namespace for the CertificationExam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.CertificationExamResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.CertificationExamResult.AttemptNumber IS 'The number of the person''s attempt for the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamScore IS 'The score result for the Certification Exam attempt.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamPassIndicator IS 'Indicator that the person passed the Certification Exam.';
COMMENT ON COLUMN tpdm.CertificationExamResult.CertificationExamStatusDescriptorId IS 'The status of the Certification Exam attempt.';

-- Extended Properties [tpdm].[CertificationExamStatusDescriptor] --
COMMENT ON TABLE tpdm.CertificationExamStatusDescriptor IS 'The status of the exam.';
COMMENT ON COLUMN tpdm.CertificationExamStatusDescriptor.CertificationExamStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationExamTypeDescriptor] --
COMMENT ON TABLE tpdm.CertificationExamTypeDescriptor IS 'The descriptor holds the type of certification exam that was taken.';
COMMENT ON COLUMN tpdm.CertificationExamTypeDescriptor.CertificationExamTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationFieldDescriptor] --
COMMENT ON TABLE tpdm.CertificationFieldDescriptor IS 'The field of certification for the credential (e.g., Mathematics, Music).';
COMMENT ON COLUMN tpdm.CertificationFieldDescriptor.CertificationFieldDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationGradeLevel] --
COMMENT ON TABLE tpdm.CertificationGradeLevel IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.GradeLevelDescriptorId IS 'The grade level(s) certified for teaching.';
COMMENT ON COLUMN tpdm.CertificationGradeLevel.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationLevelDescriptor] --
COMMENT ON TABLE tpdm.CertificationLevelDescriptor IS 'The level (e.g., Elementary, Secondary) or category (administrative, specialist) of the Certification.';
COMMENT ON COLUMN tpdm.CertificationLevelDescriptor.CertificationLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationRoute] --
COMMENT ON TABLE tpdm.CertificationRoute IS 'The process, program ,or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.CertificationRouteDescriptorId IS 'The process, program ,or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CertificationRoute.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';

-- Extended Properties [tpdm].[CertificationRouteDescriptor] --
COMMENT ON TABLE tpdm.CertificationRouteDescriptor IS 'The process, program ,or pathway used to obtain a certification.';
COMMENT ON COLUMN tpdm.CertificationRouteDescriptor.CertificationRouteDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CertificationStandardDescriptor] --
COMMENT ON TABLE tpdm.CertificationStandardDescriptor IS 'The standard, law or policy defining the certification.';
COMMENT ON COLUMN tpdm.CertificationStandardDescriptor.CertificationStandardDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CoteachingStyleObservedDescriptor] --
COMMENT ON TABLE tpdm.CoteachingStyleObservedDescriptor IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.CoteachingStyleObservedDescriptor.CoteachingStyleObservedDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialEvent] --
COMMENT ON TABLE tpdm.CredentialEvent IS 'An event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventDate IS 'The year, month and day of the Credential Event.';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventTypeDescriptorId IS 'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialEvent.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialEvent.CredentialEventReason IS 'The reason for the credential event, or any other descriptive text.';

-- Extended Properties [tpdm].[CredentialEventTypeDescriptor] --
COMMENT ON TABLE tpdm.CredentialEventTypeDescriptor IS 'The type of event associated with a person''s Credential (e.g, suspension, revocation, or renewal).';
COMMENT ON COLUMN tpdm.CredentialEventTypeDescriptor.CredentialEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialExtension] --
COMMENT ON TABLE tpdm.CredentialExtension IS '';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialExtension.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialExtension.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.CredentialExtension.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationTitle IS 'The title of the certification obtained by the educator.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.CredentialExtension.CertificationRouteDescriptorId IS 'The process, program, or pathway used to obtain certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.BoardCertificationIndicator IS 'Indicator that the credential was granted under the authority of a national Board Certification.';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDescriptorId IS 'The most recent status of the credential (e.g., active, suspended, etc.).';
COMMENT ON COLUMN tpdm.CredentialExtension.CredentialStatusDate IS 'The month, day, and year on which the credential status was effective.';

-- Extended Properties [tpdm].[CredentialStatusDescriptor] --
COMMENT ON TABLE tpdm.CredentialStatusDescriptor IS 'The most recent status of the credential (e.g., active, suspended, etc.).';
COMMENT ON COLUMN tpdm.CredentialStatusDescriptor.CredentialStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[CredentialStudentAcademicRecord] --
COMMENT ON TABLE tpdm.CredentialStudentAcademicRecord IS 'Reference to the person''s Student Academic Records for the school(s) with which the Credential is associated.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.CredentialIdentifier IS 'Identifier or serial number assigned to the credential.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StateOfIssueStateAbbreviationDescriptorId IS 'The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which a license/credential was issued.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.CredentialStudentAcademicRecord.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[DegreeDescriptor] --
COMMENT ON TABLE tpdm.DegreeDescriptor IS 'The minimum level of degree, if any, required for Certification.';
COMMENT ON COLUMN tpdm.DegreeDescriptor.DegreeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EducatorPreparationProgram] --
COMMENT ON TABLE tpdm.EducatorPreparationProgram IS 'The Educator Preparation Program is designed to prepare students to become licensed educators.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.ProgramId IS 'A unique number or alphanumeric code assigned to a program by a school, school system, a state, or other agency or entity.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.EducatorPreparationProgramTypeDescriptorId IS 'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.EducatorPreparationProgram.AccreditationStatusDescriptorId IS 'The current accreditation status of the Educator Preparation Program (e.g., active, pending, revoked,...).';

-- Extended Properties [tpdm].[EducatorPreparationProgramGradeLevel] --
COMMENT ON TABLE tpdm.EducatorPreparationProgramGradeLevel IS 'The grade levels served at the EPP Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.GradeLevelDescriptorId IS 'The grade levels served at the EPP Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramGradeLevel.ProgramTypeDescriptorId IS 'The type of program.';

-- Extended Properties [tpdm].[EducatorPreparationProgramTypeDescriptor] --
COMMENT ON TABLE tpdm.EducatorPreparationProgramTypeDescriptor IS 'The descriptor holds the type of educator prep program (e.g., college, alternative, TFA, etc.).';
COMMENT ON COLUMN tpdm.EducatorPreparationProgramTypeDescriptor.EducatorPreparationProgramTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EducatorRoleDescriptor] --
COMMENT ON TABLE tpdm.EducatorRoleDescriptor IS 'The role authorized by the Certification (e.g., Principal, Reading Specialist), typically associated with service and administrative certifications.';
COMMENT ON COLUMN tpdm.EducatorRoleDescriptor.EducatorRoleDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EnglishLanguageExamDescriptor] --
COMMENT ON TABLE tpdm.EnglishLanguageExamDescriptor IS 'Indicates that a person passed, failed, or did not take an English Language assessment (e.g., TOEFFL).';
COMMENT ON COLUMN tpdm.EnglishLanguageExamDescriptor.EnglishLanguageExamDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EPPDegreeTypeDescriptor] --
COMMENT ON TABLE tpdm.EPPDegreeTypeDescriptor IS 'Details of the degree.';
COMMENT ON COLUMN tpdm.EPPDegreeTypeDescriptor.EPPDegreeTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EPPProgramPathwayDescriptor] --
COMMENT ON TABLE tpdm.EPPProgramPathwayDescriptor IS 'A code for describing the program pathway, for example: Residency, Internship, Traditional';
COMMENT ON COLUMN tpdm.EPPProgramPathwayDescriptor.EPPProgramPathwayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Evaluation] --
COMMENT ON TABLE tpdm.Evaluation IS 'An evaluation instrument appled to evaluate an educator.  The evaluation could be internally developed, or could be an industry recognized instrument such as TTESS or Marzano.';
COMMENT ON COLUMN tpdm.Evaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.Evaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.Evaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.Evaluation.MinRating IS 'The minimum summary numerical rating or score for the evaluation. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.Evaluation.MaxRating IS 'The maximum summary numerical rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.Evaluation.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.Evaluation.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[EvaluationElement] --
COMMENT ON TABLE tpdm.EvaluationElement IS 'The lowest-level Elements or criterion of performance being evaluated by rubric, quantitative measure, or aggregate survey response.';
COMMENT ON COLUMN tpdm.EvaluationElement.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElement.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElement.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElement.SortOrder IS 'The sort order of this Evaluation Element.';
COMMENT ON COLUMN tpdm.EvaluationElement.MinRating IS 'The minimum summary numerical rating or score for the evaluation element. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationElement.MaxRating IS 'The maximum summary numerical rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElement.EvaluationTypeDescriptorId IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';

-- Extended Properties [tpdm].[EvaluationElementRating] --
COMMENT ON TABLE tpdm.EvaluationElementRating IS 'The lowest-level rating for an Evaluation Element for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.EvaluationElementRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfRefinement IS 'Area(s) identified for person to refine or improve as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.AreaOfReinforcement IS 'Area(s) identified for reinforcement or positive feedback as part of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.EvaluationElementRating.Feedback IS 'Feedback provided to the evaluated person.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationElementRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationElementRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingLevelDescriptor.EvaluationElementRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationElementRatingResult] --
COMMENT ON TABLE tpdm.EvaluationElementRatingResult IS 'The numerical summary rating or score for the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationElementRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationObjective] --
COMMENT ON TABLE tpdm.EvaluationObjective IS 'A subcomponent of an Evaluation, a specific educator Objective or domain of performance that is being evaluated.  ';
COMMENT ON COLUMN tpdm.EvaluationObjective.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjective.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjective.SortOrder IS 'The sort order of this Evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.MinRating IS 'The minimum summary numerical rating or score for the evaluation Objective. If omitted, assumed to be 0.0.';
COMMENT ON COLUMN tpdm.EvaluationObjective.MaxRating IS 'The maximum summary numerical rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjective.EvaluationTypeDescriptorId IS 'The type of the evaluation Objective (e.g., observation, principal, peer, student survey, student growth).';

-- Extended Properties [tpdm].[EvaluationObjectiveRating] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRating IS 'The rating for the component Evaluation Objective for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.ObjectiveRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRating.Comments IS 'Any comments about the performance evaluation to be captured.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationObjectiveRatingResult] --
COMMENT ON TABLE tpdm.EvaluationObjectiveRatingResult IS 'The numerical summary rating or score for the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationObjectiveRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationPeriodDescriptor] --
COMMENT ON TABLE tpdm.EvaluationPeriodDescriptor IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationPeriodDescriptor.EvaluationPeriodDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRating] --
COMMENT ON TABLE tpdm.EvaluationRating IS 'The summary weighting for the Evaluation instrument for an individual educator.';
COMMENT ON COLUMN tpdm.EvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRating.EvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationRating.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.EvaluationRating.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.EvaluationRating.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.EvaluationRating.SchoolId IS 'The identifier assigned to a school.';

-- Extended Properties [tpdm].[EvaluationRatingLevel] --
COMMENT ON TABLE tpdm.EvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[EvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.EvaluationRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.EvaluationRatingLevelDescriptor.EvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[EvaluationRatingResult] --
COMMENT ON TABLE tpdm.EvaluationRatingResult IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[EvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.ReviewerPersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewer.ReviewerSourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[EvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.EvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';
COMMENT ON COLUMN tpdm.EvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[EvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.EvaluationTypeDescriptor IS 'The type of the evaluation (e.g., observation, principal, peer, student survey, student growth).';
COMMENT ON COLUMN tpdm.EvaluationTypeDescriptor.EvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FederalLocaleCodeDescriptor] --
COMMENT ON TABLE tpdm.FederalLocaleCodeDescriptor IS 'The descriptor holds the federal locale code applicable to an education organization.';
COMMENT ON COLUMN tpdm.FederalLocaleCodeDescriptor.FederalLocaleCodeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FieldworkExperience] --
COMMENT ON TABLE tpdm.FieldworkExperience IS 'The information regarding a postsecondary instructional course in a particular field of study that typically involves a prescribed number or instruction periods or meetings for enrolled students.';
COMMENT ON COLUMN tpdm.FieldworkExperience.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperience.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperience.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.FieldworkExperience.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.FieldworkExperience.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.FieldworkExperience.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.FieldworkExperience.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.FieldworkExperience.FieldworkTypeDescriptorId IS 'The type of fieldwork being executed by a staff.';
COMMENT ON COLUMN tpdm.FieldworkExperience.HoursCompleted IS 'The number of hours completed during the fieldwork experience.';
COMMENT ON COLUMN tpdm.FieldworkExperience.EndDate IS 'The month, day, and year on which the staff ends fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperience.ProgramGatewayDescriptorId IS 'The descriptor holds the program gateway that is associated with continuation in a program.';

-- Extended Properties [tpdm].[FieldworkExperienceCoteaching] --
COMMENT ON TABLE tpdm.FieldworkExperienceCoteaching IS 'The act of two teachers (teacher candidate and cooperating teacher) working together with groups of students; sharing the planning, organization, delivery, and assessment of instruction, as well as the physical space.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.CoteachingBeginDate IS 'The month, day, and year on which the teacher candidate first starts co-teaching.';
COMMENT ON COLUMN tpdm.FieldworkExperienceCoteaching.CoteachingEndDate IS 'The month, day, and year on which the teacher candidate stopped co-teaching.';

-- Extended Properties [tpdm].[FieldworkExperienceSectionAssociation] --
COMMENT ON TABLE tpdm.FieldworkExperienceSectionAssociation IS 'Associates fieldwork with a section';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.BeginDate IS 'The month, day, and year on which the staff first starts fieldwork.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.FieldworkIdentifier IS 'The unique identifier for the fieldwork experience';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.FieldworkExperienceSectionAssociation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';

-- Extended Properties [tpdm].[FieldworkTypeDescriptor] --
COMMENT ON TABLE tpdm.FieldworkTypeDescriptor IS 'The descriptor holds the type of fieldwork being executed by a teacher candidate.';
COMMENT ON COLUMN tpdm.FieldworkTypeDescriptor.FieldworkTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[FundingSourceDescriptor] --
COMMENT ON TABLE tpdm.FundingSourceDescriptor IS 'The descriptor holds the funding source (e.g., federal, district).';
COMMENT ON COLUMN tpdm.FundingSourceDescriptor.FundingSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[GenderDescriptor] --
COMMENT ON TABLE tpdm.GenderDescriptor IS 'The gender with with a person associates.';
COMMENT ON COLUMN tpdm.GenderDescriptor.GenderDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[Goal] --
COMMENT ON TABLE tpdm.Goal IS 'Goal for performance improvement assigned to an educator associated with an Evaluation Element.';
COMMENT ON COLUMN tpdm.Goal.AssignmentDate IS 'The month, day, and year on which the goal was assigned.';
COMMENT ON COLUMN tpdm.Goal.GoalTitle IS 'The name or title of the goal.';
COMMENT ON COLUMN tpdm.Goal.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.Goal.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.Goal.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.Goal.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.Goal.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.Goal.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.Goal.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.Goal.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.Goal.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.Goal.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.Goal.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.Goal.GoalTypeDescriptorId IS 'The type of the goal (e.g., management, instruction).';
COMMENT ON COLUMN tpdm.Goal.GoalDescription IS 'The description of the goal.';
COMMENT ON COLUMN tpdm.Goal.DueDate IS 'The month, day, and year on which the goal is due or expected to be completed.';
COMMENT ON COLUMN tpdm.Goal.CompletedIndicator IS 'Indicator that the goal was completed.';
COMMENT ON COLUMN tpdm.Goal.CompletedDate IS 'The month, day, and year on which the goal was completed.';
COMMENT ON COLUMN tpdm.Goal.Comments IS 'Any comments about the goal or its completion to be captured.';

-- Extended Properties [tpdm].[GoalTypeDescriptor] --
COMMENT ON TABLE tpdm.GoalTypeDescriptor IS 'The type of the goal (e.g., management, instruction).';
COMMENT ON COLUMN tpdm.GoalTypeDescriptor.GoalTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[GraduationPlanRequiredCertification] --
COMMENT ON TABLE tpdm.GraduationPlanRequiredCertification IS 'The title or reference to the certifiation(s) required for graduation.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationTitle IS 'The title of the Certification required for Graduation.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.GraduationPlanTypeDescriptorId IS 'The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.GraduationSchoolYear IS 'The school year the student is expected to graduate.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationIdentifier IS 'Identifier or serial number assigned to the Certification.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.Namespace IS 'Namespace for the Certification, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.GraduationPlanRequiredCertification.CertificationRouteDescriptorId IS 'The process, program ,or pathway used to obtain certification.';

-- Extended Properties [tpdm].[HireStatusDescriptor] --
COMMENT ON TABLE tpdm.HireStatusDescriptor IS 'The descriptor holds the current status of the application for hire (e.g., applied, recommended, rejected, exited, offered, hired).';
COMMENT ON COLUMN tpdm.HireStatusDescriptor.HireStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[HiringSourceDescriptor] --
COMMENT ON TABLE tpdm.HiringSourceDescriptor IS 'The descriptor holds the source for the application (e.g.,job fair, website, referral, etc.).';
COMMENT ON COLUMN tpdm.HiringSourceDescriptor.HiringSourceDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[InstructionalSettingDescriptor] --
COMMENT ON TABLE tpdm.InstructionalSettingDescriptor IS 'The setting authorized by the Certification in which a child receives education and related services; for example: Classroom, Virtual, Vocational.';
COMMENT ON COLUMN tpdm.InstructionalSettingDescriptor.InstructionalSettingDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[LengthOfContractDescriptor] --
COMMENT ON TABLE tpdm.LengthOfContractDescriptor IS 'The length of contract (e.g., 12 month, 9 month, summer).';
COMMENT ON COLUMN tpdm.LengthOfContractDescriptor.LengthOfContractDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[LocalEducationAgencyExtension] --
COMMENT ON TABLE tpdm.LocalEducationAgencyExtension IS '';
COMMENT ON COLUMN tpdm.LocalEducationAgencyExtension.LocalEducationAgencyId IS 'The identifier assigned to a local education agency.';
COMMENT ON COLUMN tpdm.LocalEducationAgencyExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[ObjectiveRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.ObjectiveRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.ObjectiveRatingLevelDescriptor.ObjectiveRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionEvent] --
COMMENT ON TABLE tpdm.OpenStaffPositionEvent IS 'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.EventDate IS 'Date of the open staff position event.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.OpenStaffPositionEventTypeDescriptorId IS 'Reflects milestones like vacancy approved, vacancy posted, date onboarded, processing date, orientation date, etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEvent.OpenStaffPositionEventStatusDescriptorId IS 'Reflects the status of the milestone (e.g., pending, completed, cancelled).';

-- Extended Properties [tpdm].[OpenStaffPositionEventStatusDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionEventStatusDescriptor IS 'The descriptor holds the status of the milestone (e.g., pending, completed, cancelled).';
COMMENT ON COLUMN tpdm.OpenStaffPositionEventStatusDescriptor.OpenStaffPositionEventStatusDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionEventTypeDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionEventTypeDescriptor IS 'The descriptor holds the milestones like vacancy approved, vacancy posted, date onboarded. processing date, orientation date  etc.';
COMMENT ON COLUMN tpdm.OpenStaffPositionEventTypeDescriptor.OpenStaffPositionEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[OpenStaffPositionExtension] --
COMMENT ON TABLE tpdm.OpenStaffPositionExtension IS '';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.SchoolYear IS 'The identifier for the school year for which the OpenStaffPosition is seeking to fill.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.FullTimeEquivalency IS 'The ratio between the hours of work expected in a position and the hours of work normally expected in a full-time position in the same setting.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.OpenStaffPositionReasonDescriptorId IS 'The reason for the open staff position (e.g., new position, replacement, etc.).';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.IsActive IS 'Indicator of whether the OpenStaffPosition is currently Active.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.MaxSalary IS 'The maximum salary or wage a person is paid before deductions (excluding differentials) but including annuities.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.MinSalary IS 'The minimum salary or wage a person is paid before deductions (excluding differentials) but including annuities.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.FundingSourceDescriptorId IS 'The funding source for open staff position.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.HighNeedAcademicSubject IS 'Indicator as to whether the OpenStaffPosition is filling a high-need subject area designated as a teacher shortage that may be eligible for special grants, aid or compensation.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.PositionControlNumber IS 'Identifier assigned to the position to be filled.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.TermDescriptorId IS 'The first term for the Session during the school year for which the OpenStaffPosition is seeking to fill.';
COMMENT ON COLUMN tpdm.OpenStaffPositionExtension.TotalBudgeted IS 'Including salary, the fully loaded cost budgeted for this teacher.';

-- Extended Properties [tpdm].[OpenStaffPositionReasonDescriptor] --
COMMENT ON TABLE tpdm.OpenStaffPositionReasonDescriptor IS 'The descriptor holds the reason for the open staff position (e.g., new position, replacement, etc.).';
COMMENT ON COLUMN tpdm.OpenStaffPositionReasonDescriptor.OpenStaffPositionReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluation] --
COMMENT ON TABLE tpdm.PerformanceEvaluation IS 'A performance evaluation of an educator, typically regularly scheduled and uniformly applied, comporsed of one or more Evaluations.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluation.AcademicSubjectDescriptorId IS 'The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of a performance evaluation.';

-- Extended Properties [tpdm].[PerformanceEvaluationGradeLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationGradeLevel IS 'The grade levels involved with the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.GradeLevelDescriptorId IS 'The grade levels involved with the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationGradeLevel.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[PerformanceEvaluationProgramGateway] --
COMMENT ON TABLE tpdm.PerformanceEvaluationProgramGateway IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.ProgramGatewayDescriptorId IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationProgramGateway.TermDescriptorId IS 'The term for the session during the school year.';

-- Extended Properties [tpdm].[PerformanceEvaluationRating] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRating IS 'The summary rating for a Performance Evaluation across all Evaluation instruments for an individual educator.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDate IS 'The month, day, and year on which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Announced IS 'An indicator of whether the performance evaluation was announced or not.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.Comments IS 'Any comments about the performance evaluation to be captured.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.CoteachingStyleObservedDescriptorId IS 'A type of co-teaching observed as part of the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualDuration IS 'The actual or estimated number of clock minutes during which the performance evaluation was conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.PerformanceEvaluationRatingLevelDescriptorId IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ScheduleDate IS 'The month, day, and year on which the performance evaluation was to be conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRating.ActualTime IS 'An indication of the the time at which the performance evaluation was conducted.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevel] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevel IS 'The descriptive level(s) of ratings (cut scores) for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.EvaluationRatingLevelDescriptorId IS 'The title for a level of rating or evaluation band (e.g., Excellent, Acceptable, Needs Improvement, Unacceptable).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MinRating IS 'The minimum numerical rating or score to achieve the evaluation rating level.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevel.MaxRating IS 'The maximum numerical rating or score to achieve the evaluation rating level.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingLevelDescriptor IS 'The rating level achieved based upon the rating or score.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingLevelDescriptor.PerformanceEvaluationRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingResult] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingResult IS 'The numerical summary rating or score for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.Rating IS 'The numerical summary rating or score for the evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.RatingResultTitle IS 'The title of Rating Result.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingResult.ResultDatatypeTypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewer] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewer IS 'The person(s) that conducted the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.ReviewerPersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewer.ReviewerSourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[PerformanceEvaluationRatingReviewerReceivedTraining] --
COMMENT ON TABLE tpdm.PerformanceEvaluationRatingReviewerReceivedTraining IS 'An indication that the person administering the performance evauation has or has not received training on conducting performance measures.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.ReceivedTrainingDate IS 'The date on which the person administering the performance meausre received training on how to conduct performance measures.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationRatingReviewerReceivedTraining.InterRaterReliabilityScore IS 'A score indicating how much homogeneity, or consensus, there is in the ratings given by judges.';

-- Extended Properties [tpdm].[PerformanceEvaluationTypeDescriptor] --
COMMENT ON TABLE tpdm.PerformanceEvaluationTypeDescriptor IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.PerformanceEvaluationTypeDescriptor.PerformanceEvaluationTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[PostSecondaryInstitutionExtension] --
COMMENT ON TABLE tpdm.PostSecondaryInstitutionExtension IS '';
COMMENT ON COLUMN tpdm.PostSecondaryInstitutionExtension.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';
COMMENT ON COLUMN tpdm.PostSecondaryInstitutionExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[PreviousCareerDescriptor] --
COMMENT ON TABLE tpdm.PreviousCareerDescriptor IS 'The descriptor holds the previous career of an individual.';
COMMENT ON COLUMN tpdm.PreviousCareerDescriptor.PreviousCareerDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentEvent] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentEvent IS 'Information about a professional development event.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.Namespace IS 'Namespace for the event, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentTitle IS 'The title or name for a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentOfferedByDescriptorId IS 'A code describing an organization that is offering a specific professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.TotalHours IS 'The number of total hours the professional development contains.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.Required IS 'An indication of whether a teacher candidate is active in a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.MultipleSession IS 'An indication of whether or not a professional development event is comprised of multiple sessions or not.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEvent.ProfessionalDevelopmentReason IS 'The reported reason for a teacher candidate''s professional development.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentEventAttendance] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentEventAttendance IS 'This event entity represents the recording of whether a staff is in attendance for professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceDate IS 'Date for this attendance event.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.Namespace IS 'Namespace for the event, typically associated with the issuing authority.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.ProfessionalDevelopmentTitle IS 'The title or name for a professional development.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceEventCategoryDescriptorId IS 'A code describing the attendance event, for example:
       Present
       Unexcused absence
       Excused absence
       Tardy.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentEventAttendance.AttendanceEventReason IS 'The reported reason for a teacher candidate''s absence.';

-- Extended Properties [tpdm].[ProfessionalDevelopmentOfferedByDescriptor] --
COMMENT ON TABLE tpdm.ProfessionalDevelopmentOfferedByDescriptor IS 'The descriptor holds the organization that a professional development is offered by.';
COMMENT ON COLUMN tpdm.ProfessionalDevelopmentOfferedByDescriptor.ProfessionalDevelopmentOfferedByDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[ProgramGatewayDescriptor] --
COMMENT ON TABLE tpdm.ProgramGatewayDescriptor IS 'Identifies the program gateway that may be associated for continuation in the program.';
COMMENT ON COLUMN tpdm.ProgramGatewayDescriptor.ProgramGatewayDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[QuantitativeMeasure] --
COMMENT ON TABLE tpdm.QuantitativeMeasure IS 'A quantitative measure of educator performance associated with an Evaluation Element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureIdentifier IS 'An assigned unique identifier for the quantitative measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureTypeDescriptorId IS 'The type of the quantitative measure (e.g., achievement, growth).';
COMMENT ON COLUMN tpdm.QuantitativeMeasure.QuantitativeMeasureDatatypeDescriptorId IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';

-- Extended Properties [tpdm].[QuantitativeMeasureDatatypeDescriptor] --
COMMENT ON TABLE tpdm.QuantitativeMeasureDatatypeDescriptor IS 'The datatype of the result. The results can be expressed as a number, percentile, range, level, etc.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureDatatypeDescriptor.QuantitativeMeasureDatatypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[QuantitativeMeasureScore] --
COMMENT ON TABLE tpdm.QuantitativeMeasureScore IS 'The score or value for a Quantitative Measure achieved by an individual educator.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.QuantitativeMeasureIdentifier IS 'An assigned unique identifier for the quantitative measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.ScoreValue IS 'The score value for the quantitive measure.';
COMMENT ON COLUMN tpdm.QuantitativeMeasureScore.StandardError IS 'The standard error for the quantitative measure.';

-- Extended Properties [tpdm].[QuantitativeMeasureTypeDescriptor] --
COMMENT ON TABLE tpdm.QuantitativeMeasureTypeDescriptor IS 'The type of the quantitative measure (e.g., achievement, growth).';
COMMENT ON COLUMN tpdm.QuantitativeMeasureTypeDescriptor.QuantitativeMeasureTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RecruitmentEvent] --
COMMENT ON TABLE tpdm.RecruitmentEvent IS 'Events associated with the recruitment process.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventDescription IS 'The long description of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.RecruitmentEventTypeDescriptorId IS 'The type of event.';
COMMENT ON COLUMN tpdm.RecruitmentEvent.EventLocation IS 'The location of the event.';

-- Extended Properties [tpdm].[RecruitmentEventAttendance] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendance IS 'A prospect for employment or acceptance that has not yet made formal application that has attended recruitment event, such as a  job fair or university recruiting visit.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.Applied IS 'Indicator of whether the prospect applied for a position.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.ElectronicMailAddress IS 'The numbers, letters, and symbols used to identify an electronic mail (e-mail) user within the network to which the individual or organization belongs.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.HispanicLatinoEthnicity IS 'An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, "Spanish origin," can be used in addition to "Hispanic or Latino".';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.Met IS 'Indicator whether the person was met by a representative of the education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.PersonalTitlePrefix IS 'A prefix used to denote the title, degree, position, or seniority of the person.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.FirstName IS 'A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.MiddleName IS 'A secondary name given to an individual at birth, baptism, or during another naming ceremony.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.LastSurname IS 'The name borne in common by members of a family.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.GenerationCodeSuffix IS 'An appendage, if any, used to denote an individual''s generation in his family (e.g., Jr., Sr., III).';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.MaidenName IS 'The person''s maiden name.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.Notes IS 'Additional notes about the prospect.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.PreScreeningRating IS 'The rating initially assigned to the prospect prior to an official screening.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.RecruitmentEventAttendeeTypeDescriptorId IS 'Reflects the type of prospect, such as EPP Applicant, Hire, or Mentor Teacher.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.Referral IS 'Indicator of whether the prospect was a referral.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.ReferredBy IS 'The person making the referral.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.SexDescriptorId IS 'A person''s gender.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.SocialMediaNetworkName IS 'The social media network name (e.g., LinkedIn, Twitter, etc.) associated with the SocialMediaUserName.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendance.SocialMediaUserName IS 'The user name of the person on social media.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceCurrentPosition] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceCurrentPosition IS 'The current position of the prospect.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.NameOfInstitution IS 'The formal name of the education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.Location IS 'The location, typically City and State, for the institution.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.PositionTitle IS 'The descriptive name of an individual''s position.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPosition.AcademicSubjectDescriptorId IS 'The academic subject the staff person''s assignment to a school.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceCurrentPositionGradeLevel] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel IS 'The set of grade levels for which the individual''s assignment is responsible.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel.GradeLevelDescriptorId IS 'The set of grade levels for which the individual''s assignment is responsible.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceCurrentPositionGradeLevel.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceDisability] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceDisability IS 'The disability condition(s) that best describes an individual''s impairment.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.DisabilityDiagnosis IS 'A description of the disability diagnosis.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.OrderOfDisability IS 'The order by severity of student''s disabilities: 1- Primary, 2 -  Secondary, 3 - Tertiary, etc.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisability.DisabilityDeterminationSourceTypeDescriptorId IS 'The source that provided the disability determination.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceDisabilityDesignation] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceDisabilityDesignation IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.DisabilityDescriptorId IS 'A disability category that describes a child''s impairment.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.DisabilityDesignationDescriptorId IS 'Whether the disability is IDEA, Section 504, or other disability designation.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceDisabilityDesignation.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';

-- Extended Properties [tpdm].[RecruitmentEventAttendancePersonalIdentificationDocument] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendancePersonalIdentificationDocument IS 'The documents presented as evident to verify one''s personal identity; for example: drivers license, passport, birth certificate, etc.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.IdentificationDocumentUseDescriptorId IS 'The primary function of the document used for establishing identity.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.PersonalInformationVerificationDescriptorId IS 'The category of the document relative to its purpose.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.DocumentTitle IS 'The title of the document given by the issuer.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.DocumentExpirationDate IS 'The day when the document  expires, if null then never expires.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.IssuerDocumentIdentificationCode IS 'The unique identifier on the issuer''s identification system.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.IssuerName IS 'Name of the entity or institution that issued the document.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendancePersonalIdentificationDocument.IssuerCountryDescriptorId IS 'Country of origin of the document. It is strongly recommended that entries use only ISO 3166 2-letter country codes.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceRace] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceRace IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRace.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRace.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRace.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRace.RaceDescriptorId IS 'The general racial category which most clearly reflects the individual''s recognition of his or her community or with which the individual most identifies. The way this data element is listed, it must allow for multiple entries so that each individual can specify all appropriate races.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRace.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7 IS 'The qualifications of a prospective educator.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.Eligible IS 'An indication of whether the prospect is eligible for the position.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.CapacityToServe IS 'An indication of whether or not a prospect mentor teacher has capacity to serve.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.YearsOfServiceCurrentPlacement IS 'The total number of years of service at the current school.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceRecruitmentEventAttendeeQualif_82dbb7.YearsOfServiceTotal IS 'The total number of years of service as a teacher.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceTelephone] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceTelephone IS 'The 10-digit telephone number, including the area code, for the person.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.TelephoneNumber IS 'The telephone number including the area code, and extension, if applicable.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.TelephoneNumberTypeDescriptorId IS 'The type of communication number listed for an individual or organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.OrderOfPriority IS 'The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.TextMessageCapabilityIndicator IS 'An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTelephone.DoNotPublishIndicator IS 'An indication that the telephone number should not be published.';

-- Extended Properties [tpdm].[RecruitmentEventAttendanceTouchpoint] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendanceTouchpoint IS 'Content associated with different touchpoints with the prospect.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.EventDate IS 'The date of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.EventTitle IS 'The title of the event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.RecruitmentEventAttendeeIdentifier IS 'The identifier for the attendee to a recuitment event.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.TouchpointContent IS 'The content associated with or an artifact from the touchpoint.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendanceTouchpoint.TouchpointDate IS 'The date of the touchpoint.';

-- Extended Properties [tpdm].[RecruitmentEventAttendeeTypeDescriptor] --
COMMENT ON TABLE tpdm.RecruitmentEventAttendeeTypeDescriptor IS 'Reflects the type of prospect, such as TPP Applicant, Hire, or Mentor Teacher.';
COMMENT ON COLUMN tpdm.RecruitmentEventAttendeeTypeDescriptor.RecruitmentEventAttendeeTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RecruitmentEventTypeDescriptor] --
COMMENT ON TABLE tpdm.RecruitmentEventTypeDescriptor IS 'The type of event.';
COMMENT ON COLUMN tpdm.RecruitmentEventTypeDescriptor.RecruitmentEventTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[RubricDimension] --
COMMENT ON TABLE tpdm.RubricDimension IS 'The cells of a rubric, consisting of a qualitative decription, definition, or exemplar with the associated rubric rating and rating level.';
COMMENT ON COLUMN tpdm.RubricDimension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.RubricDimension.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.RubricDimension.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRating IS 'The rating achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.RubricDimension.RubricRatingLevelDescriptorId IS 'The rating level achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.CriterionDescription IS 'The criterion description for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricDimension.DimensionOrder IS 'The order for the rubric dimension.';

-- Extended Properties [tpdm].[RubricRatingLevelDescriptor] --
COMMENT ON TABLE tpdm.RubricRatingLevelDescriptor IS 'The rating level achieved for the rubric dimension.';
COMMENT ON COLUMN tpdm.RubricRatingLevelDescriptor.RubricRatingLevelDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SalaryTypeDescriptor] --
COMMENT ON TABLE tpdm.SalaryTypeDescriptor IS 'The descriptor holds the type of salary that a staff member is receiving.';
COMMENT ON COLUMN tpdm.SalaryTypeDescriptor.SalaryTypeDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[SchoolExtension] --
COMMENT ON TABLE tpdm.SchoolExtension IS '';
COMMENT ON COLUMN tpdm.SchoolExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.SchoolExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';
COMMENT ON COLUMN tpdm.SchoolExtension.PostSecondaryInstitutionId IS 'The ID of the post secondary institution.';
COMMENT ON COLUMN tpdm.SchoolExtension.ImprovingSchool IS 'An indication of whether a school is identified as an improving school.';
COMMENT ON COLUMN tpdm.SchoolExtension.AccreditationStatusDescriptorId IS 'Accreditation Status for a Education Preparation Provider.';

-- Extended Properties [tpdm].[StaffEducationOrganizationAssignmentAssociationExtension] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationAssignmentAssociationExtension IS '';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.BeginDate IS 'Month, day, and year of the start or effective date of a staff member''s employment, contract, or relationship with the LEA.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.StaffClassificationDescriptorId IS 'The titles of employment, official status, or rank of education staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationAssignmentAssociationExtension.YearsOfExperienceAtCurrentEducationOrganization IS 'The total number of years that an individual has previously held a teaching position in one or more education institutions.';

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationBackgroundCheck] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck IS 'Staff background check history and disposition.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.BackgroundCheckTypeDescriptorId IS 'The type of background check (e.g., online, criminal, employment).';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.BackgroundCheckRequestedDate IS 'The date the background check was requested.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.BackgroundCheckStatusDescriptorId IS 'The status of the background check (e.g., pending, under investigation, offense(s) found, etc.).';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.BackgroundCheckCompletedDate IS 'The date the background check was completed.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationBackgroundCheck.Fingerprint IS 'Indicates that a person has or has not completed a fingerprint.';

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationExtension] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationEmploymentAssociationExtension IS '';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.ProbationCompleteDate IS 'The date the probation period ended or is scheduled to end.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.LengthOfContractDescriptorId IS 'The length of contract (e.g., 12 month, 9 month, summer).';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.TenureTrack IS 'An indication that the staff is on track for tenure.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationExtension.Tenured IS 'Indicator of whether the staff member is tenured.';

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationSalary] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSalary IS 'Information regarding the salary of a staff member.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.SalaryMinRange IS 'The minimum salary range for a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.SalaryMaxRange IS 'The maximum salary range for a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.SalaryTypeDescriptorId IS 'The type of salary that a staff member is receiving.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSalary.SalaryAmount IS 'The salary of a staff member.';

-- Extended Properties [tpdm].[StaffEducationOrganizationEmploymentAssociationSeniority] --
COMMENT ON TABLE tpdm.StaffEducationOrganizationEmploymentAssociationSeniority IS 'Entries of job experience contributing to computations of seniority.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.CredentialFieldDescriptorId IS 'The field of the credential being applied.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.EmploymentStatusDescriptorId IS 'Reflects the type of employment or contract; for example:
        Probationary
        Contractual
        Substitute/temporary
        Tenured or permanent
        Volunteer/no contract
        ...';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.HireDate IS 'The month, day, and year on which an individual was hired for a position.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.NameOfInstitution IS 'The name of the education organization worked.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducationOrganizationEmploymentAssociationSeniority.YearsExperience IS 'The number of years of experience.';

-- Extended Properties [tpdm].[StaffEducatorPreparationProgram] --
COMMENT ON TABLE tpdm.StaffEducatorPreparationProgram IS 'The Educator Preparation Program(s) completed by the teacher.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgram.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgram.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgram.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgram.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffEducatorPreparationProgramAssociation] --
COMMENT ON TABLE tpdm.StaffEducatorPreparationProgramAssociation IS 'This association indicates the EducatorPreparationProgram associated with a Staff.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.ProgramName IS 'The name of the Educator Preparation Program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.ProgramTypeDescriptorId IS 'The type of program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.BeginDate IS 'Start date for the association of staff to this program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.EndDate IS 'End date for the association of staff to this program.';
COMMENT ON COLUMN tpdm.StaffEducatorPreparationProgramAssociation.Completer IS 'Indicator of whether the staff completed the EducatorPreparationProgram.';

-- Extended Properties [tpdm].[StaffEducatorResearch] --
COMMENT ON TABLE tpdm.StaffEducatorResearch IS 'Educator preparation provider faculty that instruct teacher candidates in content area or pedagogy.';
COMMENT ON COLUMN tpdm.StaffEducatorResearch.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffEducatorResearch.ResearchExperienceDate IS 'Month, day, and year of the start or effective date of a staff member''s teacher educator position for an Education Organization.';
COMMENT ON COLUMN tpdm.StaffEducatorResearch.ResearchExperienceTitle IS 'The title of the research experience.';
COMMENT ON COLUMN tpdm.StaffEducatorResearch.ResearchExperienceDescription IS 'The description of the research experience.';

-- Extended Properties [tpdm].[StaffExtension] --
COMMENT ON TABLE tpdm.StaffExtension IS '';
COMMENT ON COLUMN tpdm.StaffExtension.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';
COMMENT ON COLUMN tpdm.StaffExtension.GenderDescriptorId IS 'The gender with which a person associates.';
COMMENT ON COLUMN tpdm.StaffExtension.RequisitionNumber IS 'The number or identifier assigned to an open staff position, typically a requisition number assigned by Human Resources.';
COMMENT ON COLUMN tpdm.StaffExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';

-- Extended Properties [tpdm].[StaffHighlyQualifiedAcademicSubject] --
COMMENT ON TABLE tpdm.StaffHighlyQualifiedAcademicSubject IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.StaffHighlyQualifiedAcademicSubject.AcademicSubjectDescriptorId IS 'The academic subject(s) in which the staff is deemed to be "highly qualified".';
COMMENT ON COLUMN tpdm.StaffHighlyQualifiedAcademicSubject.StaffUSI IS 'A unique alphanumeric code assigned to a staff.';

-- Extended Properties [tpdm].[StaffToCandidateRelationshipDescriptor] --
COMMENT ON TABLE tpdm.StaffToCandidateRelationshipDescriptor IS 'Defines the staff relationship to the candidate (e.g., supervising principal, mentor, coordinating teacher, etc. )';
COMMENT ON COLUMN tpdm.StaffToCandidateRelationshipDescriptor.StaffToCandidateRelationshipDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

-- Extended Properties [tpdm].[StateEducationAgencyExtension] --
COMMENT ON TABLE tpdm.StateEducationAgencyExtension IS '';
COMMENT ON COLUMN tpdm.StateEducationAgencyExtension.StateEducationAgencyId IS 'The identifier assigned to a state education agency.';
COMMENT ON COLUMN tpdm.StateEducationAgencyExtension.FederalLocaleCodeDescriptorId IS 'The federal locale code associated with an education organization.';

-- Extended Properties [tpdm].[StudentGradebookEntryExtension] --
COMMENT ON TABLE tpdm.StudentGradebookEntryExtension IS '';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.BeginDate IS 'Month, day, and year of the Student''s entry or assignment to the Section.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.DateAssigned IS 'The date the assignment, homework, or assessment was assigned or executed.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.GradebookEntryTitle IS 'The name or title of the activity to be recorded in the GradebookEntry.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.LocalCourseCode IS 'The local code assigned by the School that identifies the course offering provided for the instruction of students.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SchoolId IS 'The identifier assigned to a school.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SectionIdentifier IS 'The local identifier assigned to a section.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.SessionName IS 'The identifier for the calendar for the academic session (e.g., 2010/11, 2011 Summer).';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.DateCompleted IS 'The date that the assignment was completed.';
COMMENT ON COLUMN tpdm.StudentGradebookEntryExtension.AssignmentPassed IS 'Indication of whether the assignment was passed or not.';

-- Extended Properties [tpdm].[SurveyResponseExtension] --
COMMENT ON TABLE tpdm.SurveyResponseExtension IS '';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveyResponseExtension.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';

-- Extended Properties [tpdm].[SurveyResponsePersonTargetAssociation] --
COMMENT ON TABLE tpdm.SurveyResponsePersonTargetAssociation IS 'The association provides information about the survey being taken and who the survey is about.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveyResponsePersonTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';

-- Extended Properties [tpdm].[SurveySectionAggregateResponse] --
COMMENT ON TABLE tpdm.SurveySectionAggregateResponse IS 'The aggregate or average score across the surveying population for a survey section being used for performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationDate IS 'The date for the person''s evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationElementTitle IS 'The name or title of the evaluation element.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.SurveySectionAggregateResponse.ScoreValue IS 'The score value for the aggregate survey section response.';

-- Extended Properties [tpdm].[SurveySectionExtension] --
COMMENT ON TABLE tpdm.SurveySectionExtension IS '';
COMMENT ON COLUMN tpdm.SurveySectionExtension.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SurveySectionTitle IS 'The title or label for the survey section.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.PerformanceEvaluationTitle IS 'An assigned unique identifier for the performance evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.TermDescriptorId IS 'The term for the session during the school year.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.PerformanceEvaluationTypeDescriptorId IS 'The type (e.g., walkthrough, summative) of performance evaluation conducted.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.SchoolYear IS 'The identifier for the school year.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationPeriodDescriptorId IS 'The period for the evaluation (e.g., BOY, MOY, EOY, Summer).';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EducationOrganizationId IS 'The identifier assigned to an education organization.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationTitle IS 'The name or title of the evaluation.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationObjectiveTitle IS 'The name or title of the evaluation Objective.';
COMMENT ON COLUMN tpdm.SurveySectionExtension.EvaluationElementTitle IS 'The name or title of the evaluation element.';

-- Extended Properties [tpdm].[SurveySectionResponsePersonTargetAssociation] --
COMMENT ON TABLE tpdm.SurveySectionResponsePersonTargetAssociation IS 'This association provides information about the survey section and the person the survey section is about.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.Namespace IS 'Namespace for the Survey.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.PersonId IS 'A unique alphanumeric code assigned to a person.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SourceSystemDescriptorId IS 'This descriptor defines the originating record source system for the person.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveyIdentifier IS 'The unique survey identifier from the survey tool.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveyResponseIdentifier IS 'The identifier of the survey typically from the survey application.';
COMMENT ON COLUMN tpdm.SurveySectionResponsePersonTargetAssociation.SurveySectionTitle IS 'The title or label for the survey section.';

-- Extended Properties [tpdm].[WithdrawReasonDescriptor] --
COMMENT ON TABLE tpdm.WithdrawReasonDescriptor IS 'The descriptor holds the reason applicant withdrew application.';
COMMENT ON COLUMN tpdm.WithdrawReasonDescriptor.WithdrawReasonDescriptorId IS 'A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.';

