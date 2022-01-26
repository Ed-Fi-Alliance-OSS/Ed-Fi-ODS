using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Adapters;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Entities.Common.EdFi;
using Newtonsoft.Json;
using FluentValidation.Results;

// Aggregate: StudentTransportation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentTransportation.SampleStudentTransportation
{
    /// <summary>
    /// Represents a reference to the StudentTransportation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentTransportationReference
    {
        [DataMember(Name="amBusNumber"), NaturalKeyMember]
        public string AMBusNumber { get; set; }

        [DataMember(Name="pmBusNumber"), NaturalKeyMember]
        public string PMBusNumber { get; set; }

        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        [DataMember(Name="studentUniqueId"), NaturalKeyMember]
        public string StudentUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (IsReferenceFullyDefined())
                        _link = CreateLink();
                }

                return _link;
            }
        }

        /// <summary>
        /// Indicates whether the reference has been fully defined (all key values are currently assigned non-default values).
        /// </summary>
        /// <returns><b>true</b> if the reference's properties are all set to non-default values; otherwise <b>false</b>.</returns>
        public bool IsReferenceFullyDefined()
        {
            return AMBusNumber != default(string) && PMBusNumber != default(string) && SchoolId != default(int) && StudentUniqueId != default(string);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentTransportation",
                Href = $"/sample-student-transportation/studentTransportations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the samplestudenttransportation.StudentTransportation table of the StudentTransportation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentTransportation : Entities.Common.SampleStudentTransportation.IStudentTransportation, IHasETag, Entities.Common.SampleStudentTransportation.IStudentTransportationSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the StudentTransportation resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _schoolReferenceExplicitlyAssigned;
        private School.EdFi.SchoolReference _schoolReference;
        private School.EdFi.SchoolReference ImplicitSchoolReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_schoolReference == null && !_schoolReferenceExplicitlyAssigned)
                    _schoolReference = new School.EdFi.SchoolReference();

                return _schoolReference;
            }
        }

        [DataMember(Name="schoolReference")][NaturalKeyMember]
        public School.EdFi.SchoolReference SchoolReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitSchoolReference != null
                    && (_schoolReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitSchoolReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolReference;

                return null;
            }
            set
            {
                _schoolReferenceExplicitlyAssigned = true;
                _schoolReference = value;
            }
        }
        private bool _studentReferenceExplicitlyAssigned;
        private Student.EdFi.StudentReference _studentReference;
        private Student.EdFi.StudentReference ImplicitStudentReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentReference == null && !_studentReferenceExplicitlyAssigned)
                    _studentReference = new Student.EdFi.StudentReference();

                return _studentReference;
            }
        }

        [DataMember(Name="studentReference")][NaturalKeyMember]
        public Student.EdFi.StudentReference StudentReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentReference != null
                    && (_studentReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference;

                return null;
            }
            set
            {
                _studentReferenceExplicitlyAssigned = true;
                _studentReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The bus that delivers the student to the school in the morning.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="amBusNumber"), NaturalKeyMember]
        public string AMBusNumber { get; set; }

        /// <summary>
        /// Te bus that delivers the student home in the afternoon.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="pmBusNumber"), NaturalKeyMember]
        public string PMBusNumber { get; set; }

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.SampleStudentTransportation.IStudentTransportation.SchoolId
        {
            get
            {
                if (ImplicitSchoolReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitSchoolReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolReference.SchoolId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // School
                _schoolReferenceExplicitlyAssigned = false;
                ImplicitSchoolReference.SchoolId = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.SampleStudentTransportation.IStudentTransportation.StudentUniqueId
        {
            get
            {
                if (ImplicitStudentReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference.StudentUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Student
                _studentReferenceExplicitlyAssigned = false;
                ImplicitStudentReference.StudentUniqueId = value;
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Equality
        // -------------------------------------------------------------

        /// <summary>
        /// Determines equality based on the natural key properties of the resource.
        /// </summary>
        /// <returns>
        /// A boolean value indicating equality result of the compared resources.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entities.Common.SampleStudentTransportation.IStudentTransportation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
             if ((this as Entities.Common.SampleStudentTransportation.IStudentTransportation).AMBusNumber.Equals(compareTo.AMBusNumber))
                return false;


            // Standard Property
             if ((this as Entities.Common.SampleStudentTransportation.IStudentTransportation).PMBusNumber.Equals(compareTo.PMBusNumber))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.SampleStudentTransportation.IStudentTransportation).SchoolId.Equals(compareTo.SchoolId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.SampleStudentTransportation.IStudentTransportation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
                return false;


            return true;
        }

        /// <summary>
        /// Builds the hash code based on the unique identifying values.
        /// </summary>
        /// <returns>
        /// A hash code for the resource.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                // Standard Property
                 hash = hash * 23 + (this as Entities.Common.SampleStudentTransportation.IStudentTransportation).AMBusNumber.GetHashCode();


                // Standard Property
                 hash = hash * 23 + (this as Entities.Common.SampleStudentTransportation.IStudentTransportation).PMBusNumber.GetHashCode();


                //Referenced Property
                hash = hash * 23 + (this as Entities.Common.SampleStudentTransportation.IStudentTransportation).SchoolId.GetHashCode();

                //Referenced Property
                hash = hash * 23 + (this as Entities.Common.SampleStudentTransportation.IStudentTransportation).StudentUniqueId.GetHashCode();
                return hash;
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The estimated distance, in miles, the student lives from the school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="estimatedMilesFromSchool")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal EstimatedMilesFromSchool { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //              Inherited One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Inherited Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.SampleStudentTransportation.StudentTransportationMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTransportation.IStudentTransportation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTransportation.StudentTransportationMapper.MapTo(this, (Entities.Common.SampleStudentTransportation.IStudentTransportation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.SampleStudentTransportation.IStudentTransportationSynchronizationSourceSupport.IsEstimatedMilesFromSchoolSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.SampleStudentTransportation.IStudentTransportation.SchoolResourceId
        {
            get { return null; }
            set { ImplicitSchoolReference.ResourceId = value ?? default(Guid); }
        }


        Guid? Entities.Common.SampleStudentTransportation.IStudentTransportation.StudentResourceId
        {
            get { return null; }
            set { ImplicitStudentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.SampleStudentTransportation.IStudentTransportation.StudentDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentTransportationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentTransportation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentTransportation> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------

            // Recursively invoke the child collection item validators

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    result.Errors.Add(failure);
                }

                return false;
            }

            return true;
        }
    }
    // -----------------------------------------------------------------

}
