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
using EdFi.Ods.Entities.Common.Sample;
using Newtonsoft.Json;
using FluentValidation.Results;

// Aggregate: ArtMediumDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.ArtMediumDescriptor.Sample
{
    /// <summary>
    /// A class which represents the sample.ArtMediumDescriptor table of the ArtMediumDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptor : Entities.Common.Sample.IArtMediumDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport
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
        /// The unique identifier for the ArtMediumDescriptor resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="artMediumDescriptorId"), NaturalKeyMember]
        public int ArtMediumDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return ArtMediumDescriptorId; }
            set { ArtMediumDescriptorId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IArtMediumDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if ((this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId == null
                || !(this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId.Equals(compareTo.ArtMediumDescriptorId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                //Derived Property
                if ((this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// A code or abbreviation that is used to refer to the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="codeValue")]
        public string CodeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveBeginDate { get; set; }

        /// <summary>
        /// The end date of the period when the descriptor is in effect.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveEndDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="priorDescriptorId")]
        public int? PriorDescriptorId { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortDescription")]
        public string ShortDescription { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ArtMediumDescriptorMapper.SynchronizeTo(this, (Entities.Common.Sample.IArtMediumDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ArtMediumDescriptorMapper.MapTo(this, (Entities.Common.Sample.IArtMediumDescriptor)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsCodeValueSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsDescriptionSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported    { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsNamespaceSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IArtMediumDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported    { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<ArtMediumDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ArtMediumDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Bus

namespace EdFi.Ods.Api.Common.Models.Resources.Bus.Sample
{
    /// <summary>
    /// Represents a reference to the Bus resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class BusReference
    {
        [DataMember(Name="busId"), NaturalKeyMember]
        public string BusId { get; set; }

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
            return BusId != default(string);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Bus",
                Href = $"/sample/buses/{ResourceId:n}"
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
    /// A class which represents the sample.Bus table of the Bus aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Bus : Entities.Common.Sample.IBus, IHasETag, Entities.Common.Sample.IBusSynchronizationSourceSupport
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
        /// The unique identifier for the Bus resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busId"), NaturalKeyMember]
        public string BusId { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBus;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBus).BusId == null
                || !(this as Entities.Common.Sample.IBus).BusId.Equals(compareTo.BusId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                // Standard Property
                if ((this as Entities.Common.Sample.IBus).BusId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBus).BusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.BusMapper.SynchronizeTo(this, (Entities.Common.Sample.IBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusMapper.MapTo(this, (Entities.Common.Sample.IBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusPutPostRequestValidator : FluentValidation.AbstractValidator<Bus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<Bus> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: BusRoute

namespace EdFi.Ods.Api.Common.Models.Resources.BusRoute.Sample
{
    /// <summary>
    /// Represents a reference to the BusRoute resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteReference
    {
        [DataMember(Name="busId"), NaturalKeyMember]
        public string BusId { get; set; }

        [DataMember(Name="busRouteNumber"), NaturalKeyMember]
        public int BusRouteNumber { get; set; }

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
            return BusId != default(string) && BusRouteNumber != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "BusRoute",
                Href = $"/sample/busRoutes/{ResourceId:n}"
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
    /// A class which represents the sample.BusRoute table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRoute : Entities.Common.Sample.IBusRoute, IHasETag, Entities.Common.Sample.IBusRouteSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public BusRoute()
        {
            BusRouteBusYears = new List<BusRouteBusYear>();
            BusRoutePrograms = new List<BusRouteProgram>();
            BusRouteServiceAreaPostalCodes = new List<BusRouteServiceAreaPostalCode>();
            BusRouteStartTimes = new List<BusRouteStartTime>();
            BusRouteTelephones = new List<BusRouteTelephone>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the BusRoute resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned;
        private StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociationReference _staffEducationOrganizationAssignmentAssociationReference;
        private StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociationReference ImplicitStaffEducationOrganizationAssignmentAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_staffEducationOrganizationAssignmentAssociationReference == null && !_staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned)
                    _staffEducationOrganizationAssignmentAssociationReference = new StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociationReference();

                return _staffEducationOrganizationAssignmentAssociationReference;
            }
        }

        [DataMember(Name="staffEducationOrganizationAssignmentAssociationReference")]
        public StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociationReference StaffEducationOrganizationAssignmentAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationAssignmentAssociationReference;

                return null;
            }
            set
            {
                _staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned = true;
                _staffEducationOrganizationAssignmentAssociationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the bus assigned to the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busId"), NaturalKeyMember]
        public string BusId { get; set; }

        /// <summary>
        /// A unique identifier for the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busRouteNumber"), NaturalKeyMember]
        public int BusRouteNumber { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRoute;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBusRoute).BusId == null
                || !(this as Entities.Common.Sample.IBusRoute).BusId.Equals(compareTo.BusId))
                return false;

            // Standard Property
            if ((this as Entities.Common.Sample.IBusRoute).BusRouteNumber == null
                || !(this as Entities.Common.Sample.IBusRoute).BusRouteNumber.Equals(compareTo.BusRouteNumber))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRoute).BusId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRoute).BusId.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRoute).BusRouteNumber != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRoute).BusRouteNumber.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// Month, day, and year of the start or effective date of a staff member's employment, contract, or relationship with the LEA.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        DateTime? Entities.Common.Sample.IBusRoute.BeginDate
        {
            get
            {
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffEducationOrganizationAssignmentAssociationReference.BeginDate;
                    }

                return default(DateTime?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationAssignmentAssociation
                _staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationAssignmentAssociationReference.BeginDate = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// The direction of the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busRouteDirection")]
        public string BusRouteDirection { get; set; }

        /// <summary>
        /// The number of minutes per week in which the bus route is operational.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busRouteDuration")]
        public int? BusRouteDuration { get; set; }

        /// <summary>
        /// An indication as to whether the bus route operates every weekday.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="daily")]
        public bool? Daily { get; set; }

        /// <summary>
        /// The disability served by the bus route, if applicable.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="disabilityDescriptor")]
        public string DisabilityDescriptor { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.Sample.IBusRoute.EducationOrganizationId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffEducationOrganizationAssignmentAssociationReference.EducationOrganizationId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationAssignmentAssociation
                _staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationAssignmentAssociationReference.EducationOrganizationId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// The approximate amount of time, in minutes, for the bus route operation each day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="expectedTransitTime")]
        public string ExpectedTransitTime { get; set; }

        /// <summary>
        /// The number of hours per week in which the bus route is operational.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal HoursPerWeek { get; set; }

        /// <summary>
        /// The approximate annual cost for the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="operatingCost")][Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public decimal OperatingCost { get; set; }

        /// <summary>
        /// The percentage of seats filled under optimal conditions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="optimalCapacity")][Range(typeof(decimal), "-9.9999", "9.9999")]
        public decimal? OptimalCapacity { get; set; }

        /// <summary>
        /// The titles of employment, official status, or rank of education staff.
        /// </summary>

        // IS in a reference (BusRoute.StaffClassificationDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IBusRoute.StaffClassificationDescriptor
        {
            get
            {
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffEducationOrganizationAssignmentAssociationReference.StaffClassificationDescriptor;
                    }

                return null;
            }
            set
            {
                ImplicitStaffEducationOrganizationAssignmentAssociationReference.StaffClassificationDescriptor = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a staff.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IBusRoute.StaffUniqueId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffEducationOrganizationAssignmentAssociationReference.StaffUniqueId;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationAssignmentAssociation
                _staffEducationOrganizationAssignmentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationAssignmentAssociationReference.StaffUniqueId = value;
            }
        }

        /// <summary>
        /// The date the bus route became operational.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="startDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The approximate weekly mileage for the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="weeklyMileage")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? WeeklyMileage { get; set; }
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
        private ICollection<BusRouteBusYear> _busRouteBusYears;
        private ICollection<Entities.Common.Sample.IBusRouteBusYear> _busRouteBusYearsCovariant;

        [DataMember(Name="busYears"), NoDuplicateMembers]
        public ICollection<BusRouteBusYear> BusRouteBusYears
        {
            get { return _busRouteBusYears; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<BusRouteBusYear>(value,
                    (s, e) => ((Entities.Common.Sample.IBusRouteBusYear)e.Item).BusRoute = this);
                _busRouteBusYears = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IBusRouteBusYear, BusRouteBusYear>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IBusRouteBusYear)e.Item).BusRoute = this;
                _busRouteBusYearsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteBusYear> Entities.Common.Sample.IBusRoute.BusRouteBusYears
        {
            get { return _busRouteBusYearsCovariant; }
            set { BusRouteBusYears = new List<BusRouteBusYear>(value.Cast<BusRouteBusYear>()); }
        }

        private ICollection<BusRouteProgram> _busRoutePrograms;
        private ICollection<Entities.Common.Sample.IBusRouteProgram> _busRouteProgramsCovariant;

        [DataMember(Name="programs"), NoDuplicateMembers]
        public ICollection<BusRouteProgram> BusRoutePrograms
        {
            get { return _busRoutePrograms; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<BusRouteProgram>(value,
                    (s, e) => ((Entities.Common.Sample.IBusRouteProgram)e.Item).BusRoute = this);
                _busRoutePrograms = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IBusRouteProgram, BusRouteProgram>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IBusRouteProgram)e.Item).BusRoute = this;
                _busRouteProgramsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteProgram> Entities.Common.Sample.IBusRoute.BusRoutePrograms
        {
            get { return _busRouteProgramsCovariant; }
            set { BusRoutePrograms = new List<BusRouteProgram>(value.Cast<BusRouteProgram>()); }
        }

        private ICollection<BusRouteServiceAreaPostalCode> _busRouteServiceAreaPostalCodes;
        private ICollection<Entities.Common.Sample.IBusRouteServiceAreaPostalCode> _busRouteServiceAreaPostalCodesCovariant;

        [DataMember(Name="serviceAreaPostalCodes"), NoDuplicateMembers]
        public ICollection<BusRouteServiceAreaPostalCode> BusRouteServiceAreaPostalCodes
        {
            get { return _busRouteServiceAreaPostalCodes; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<BusRouteServiceAreaPostalCode>(value,
                    (s, e) => ((Entities.Common.Sample.IBusRouteServiceAreaPostalCode)e.Item).BusRoute = this);
                _busRouteServiceAreaPostalCodes = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IBusRouteServiceAreaPostalCode, BusRouteServiceAreaPostalCode>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IBusRouteServiceAreaPostalCode)e.Item).BusRoute = this;
                _busRouteServiceAreaPostalCodesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteServiceAreaPostalCode> Entities.Common.Sample.IBusRoute.BusRouteServiceAreaPostalCodes
        {
            get { return _busRouteServiceAreaPostalCodesCovariant; }
            set { BusRouteServiceAreaPostalCodes = new List<BusRouteServiceAreaPostalCode>(value.Cast<BusRouteServiceAreaPostalCode>()); }
        }

        private ICollection<BusRouteStartTime> _busRouteStartTimes;
        private ICollection<Entities.Common.Sample.IBusRouteStartTime> _busRouteStartTimesCovariant;

        [DataMember(Name="startTimes"), NoDuplicateMembers]
        public ICollection<BusRouteStartTime> BusRouteStartTimes
        {
            get { return _busRouteStartTimes; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<BusRouteStartTime>(value,
                    (s, e) => ((Entities.Common.Sample.IBusRouteStartTime)e.Item).BusRoute = this);
                _busRouteStartTimes = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IBusRouteStartTime, BusRouteStartTime>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IBusRouteStartTime)e.Item).BusRoute = this;
                _busRouteStartTimesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteStartTime> Entities.Common.Sample.IBusRoute.BusRouteStartTimes
        {
            get { return _busRouteStartTimesCovariant; }
            set { BusRouteStartTimes = new List<BusRouteStartTime>(value.Cast<BusRouteStartTime>()); }
        }

        private ICollection<BusRouteTelephone> _busRouteTelephones;
        private ICollection<Entities.Common.Sample.IBusRouteTelephone> _busRouteTelephonesCovariant;

        [DataMember(Name="telephones"), NoDuplicateMembers]
        public ICollection<BusRouteTelephone> BusRouteTelephones
        {
            get { return _busRouteTelephones; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<BusRouteTelephone>(value,
                    (s, e) => ((Entities.Common.Sample.IBusRouteTelephone)e.Item).BusRoute = this);
                _busRouteTelephones = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IBusRouteTelephone, BusRouteTelephone>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IBusRouteTelephone)e.Item).BusRoute = this;
                _busRouteTelephonesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IBusRouteTelephone> Entities.Common.Sample.IBusRoute.BusRouteTelephones
        {
            get { return _busRouteTelephonesCovariant; }
            set { BusRouteTelephones = new List<BusRouteTelephone>(value.Cast<BusRouteTelephone>()); }
        }

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

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_busRouteBusYears != null) foreach (var item in _busRouteBusYears)
            {
                item.BusRoute = this;
            }

            if (_busRoutePrograms != null) foreach (var item in _busRoutePrograms)
            {
                item.BusRoute = this;
            }

            if (_busRouteServiceAreaPostalCodes != null) foreach (var item in _busRouteServiceAreaPostalCodes)
            {
                item.BusRoute = this;
            }

            if (_busRouteStartTimes != null) foreach (var item in _busRouteStartTimes)
            {
                item.BusRoute = this;
            }

            if (_busRouteTelephones != null) foreach (var item in _busRouteTelephones)
            {
                item.BusRoute = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.BusRouteMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRoute)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteMapper.MapTo(this, (Entities.Common.Sample.IBusRoute)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBeginDateSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteBusYearsSupported                { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteDirectionSupported               { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteDurationSupported                { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteProgramsSupported                { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteServiceAreaPostalCodesSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteStartTimesSupported              { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteTelephonesSupported              { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsDailySupported                           { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsDisabilityDescriptorSupported            { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsEducationOrganizationIdSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsExpectedTransitTimeSupported             { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsHoursPerWeekSupported                    { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsOperatingCostSupported                   { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsOptimalCapacitySupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsStaffClassificationDescriptorSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsStaffUniqueIdSupported                   { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsStartDateSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsWeeklyMileageSupported                   { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IBusRouteBusYear, bool> Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteBusYearIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IBusRouteProgram, bool> Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteProgramIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IBusRouteServiceAreaPostalCode, bool> Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteServiceAreaPostalCodeIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IBusRouteStartTime, bool> Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteStartTimeIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IBusRouteTelephone, bool> Entities.Common.Sample.IBusRouteSynchronizationSourceSupport.IsBusRouteTelephoneIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IBusRoute.StaffEducationOrganizationAssignmentAssociationResourceId
        {
            get { return null; }
            set { ImplicitStaffEducationOrganizationAssignmentAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IBusRoute.StaffEducationOrganizationAssignmentAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStaffEducationOrganizationAssignmentAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRoutePutPostRequestValidator : FluentValidation.AbstractValidator<BusRoute>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRoute> context, FluentValidation.Results.ValidationResult result)
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
            var busRouteBusYearsValidator = new BusRouteBusYearPutPostRequestValidator();

            foreach (var item in instance.BusRouteBusYears)
            {
                var validationResult = busRouteBusYearsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var busRouteProgramsValidator = new BusRouteProgramPutPostRequestValidator();

            foreach (var item in instance.BusRoutePrograms)
            {
                var validationResult = busRouteProgramsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var busRouteServiceAreaPostalCodesValidator = new BusRouteServiceAreaPostalCodePutPostRequestValidator();

            foreach (var item in instance.BusRouteServiceAreaPostalCodes)
            {
                var validationResult = busRouteServiceAreaPostalCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var busRouteStartTimesValidator = new BusRouteStartTimePutPostRequestValidator();

            foreach (var item in instance.BusRouteStartTimes)
            {
                var validationResult = busRouteStartTimesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var busRouteTelephonesValidator = new BusRouteTelephonePutPostRequestValidator();

            foreach (var item in instance.BusRouteTelephones)
            {
                var validationResult = busRouteTelephonesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.BusRouteBusYear table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteBusYear : Entities.Common.Sample.IBusRouteBusYear, Entities.Common.Sample.IBusRouteBusYearSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IBusRoute _busRoute;

        [IgnoreDataMember]
        Entities.Common.Sample.IBusRoute Entities.Common.Sample.IBusRouteBusYear.BusRoute
        {
            get { return _busRoute; }
            set { SetBusRoute(value); }
        }

        internal Entities.Common.Sample.IBusRoute BusRoute
        {
            set { SetBusRoute(value); }
        }

        private void SetBusRoute(Entities.Common.Sample.IBusRoute value)
        {
            _busRoute = value;
        }

        /// <summary>
        /// The years in which the bus route has been in active.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="busYear"), NaturalKeyMember]
        public short BusYear { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRouteBusYear;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBusRouteBusYear).BusYear == null
                || !(this as Entities.Common.Sample.IBusRouteBusYear).BusYear.Equals(compareTo.BusYear))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_busRoute != null)
                    hash = hash * 23 + _busRoute.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRouteBusYear).BusYear != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteBusYear).BusYear.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.BusRouteBusYearMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRouteBusYear)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteBusYearMapper.MapTo(this, (Entities.Common.Sample.IBusRouteBusYear)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRouteBusYearPutPostRequestValidator : FluentValidation.AbstractValidator<BusRouteBusYear>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRouteBusYear> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.BusRouteProgram table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteProgram : Entities.Common.Sample.IBusRouteProgram, Entities.Common.Sample.IBusRouteProgramSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _programReferenceExplicitlyAssigned;
        private Program.EdFi.ProgramReference _programReference;
        private Program.EdFi.ProgramReference ImplicitProgramReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_programReference == null && !_programReferenceExplicitlyAssigned)
                    _programReference = new Program.EdFi.ProgramReference();

                return _programReference;
            }
        }

        [DataMember(Name="programReference")][NaturalKeyMember]
        public Program.EdFi.ProgramReference ProgramReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitProgramReference != null
                    && (_programReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference;

                return null;
            }
            set
            {
                _programReferenceExplicitlyAssigned = true;
                _programReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IBusRoute _busRoute;

        [IgnoreDataMember]
        Entities.Common.Sample.IBusRoute Entities.Common.Sample.IBusRouteProgram.BusRoute
        {
            get { return _busRoute; }
            set { SetBusRoute(value); }
        }

        internal Entities.Common.Sample.IBusRoute BusRoute
        {
            set { SetBusRoute(value); }
        }

        private void SetBusRoute(Entities.Common.Sample.IBusRoute value)
        {
            _busRoute = value;
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.Sample.IBusRouteProgram.EducationOrganizationId
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IBusRouteProgram.ProgramName
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (BusRouteProgram.ProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IBusRouteProgram.ProgramTypeDescriptor
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitProgramReference.ProgramTypeDescriptor = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRouteProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId == null
                || !(this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IBusRouteProgram).ProgramName == null
                || !(this as Entities.Common.Sample.IBusRouteProgram).ProgramName.Equals(compareTo.ProgramName))
                return false;

            // Unified Type Property
            if ((this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor == null
                ||!(this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_busRoute != null)
                    hash = hash * 23 + _busRoute.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IBusRouteProgram).ProgramName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteProgram).ProgramName.GetHashCode();

                //Unified Type Property
                if ((this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.BusRouteProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRouteProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteProgramMapper.MapTo(this, (Entities.Common.Sample.IBusRouteProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IBusRouteProgram.ProgramResourceId
        {
            get { return null; }
            set { ImplicitProgramReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IBusRouteProgram.ProgramDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitProgramReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRouteProgramPutPostRequestValidator : FluentValidation.AbstractValidator<BusRouteProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRouteProgram> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.BusRouteServiceAreaPostalCode table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteServiceAreaPostalCode : Entities.Common.Sample.IBusRouteServiceAreaPostalCode, Entities.Common.Sample.IBusRouteServiceAreaPostalCodeSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IBusRoute _busRoute;

        [IgnoreDataMember]
        Entities.Common.Sample.IBusRoute Entities.Common.Sample.IBusRouteServiceAreaPostalCode.BusRoute
        {
            get { return _busRoute; }
            set { SetBusRoute(value); }
        }

        internal Entities.Common.Sample.IBusRoute BusRoute
        {
            set { SetBusRoute(value); }
        }

        private void SetBusRoute(Entities.Common.Sample.IBusRoute value)
        {
            _busRoute = value;
        }

        /// <summary>
        /// The postal codes served by the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="serviceAreaPostalCode"), NaturalKeyMember]
        public string ServiceAreaPostalCode { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRouteServiceAreaPostalCode;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode == null
                || !(this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode.Equals(compareTo.ServiceAreaPostalCode))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_busRoute != null)
                    hash = hash * 23 + _busRoute.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.BusRouteServiceAreaPostalCodeMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRouteServiceAreaPostalCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteServiceAreaPostalCodeMapper.MapTo(this, (Entities.Common.Sample.IBusRouteServiceAreaPostalCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRouteServiceAreaPostalCodePutPostRequestValidator : FluentValidation.AbstractValidator<BusRouteServiceAreaPostalCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRouteServiceAreaPostalCode> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.BusRouteStartTime table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteStartTime : Entities.Common.Sample.IBusRouteStartTime, Entities.Common.Sample.IBusRouteStartTimeSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IBusRoute _busRoute;

        [IgnoreDataMember]
        Entities.Common.Sample.IBusRoute Entities.Common.Sample.IBusRouteStartTime.BusRoute
        {
            get { return _busRoute; }
            set { SetBusRoute(value); }
        }

        internal Entities.Common.Sample.IBusRoute BusRoute
        {
            set { SetBusRoute(value); }
        }

        private void SetBusRoute(Entities.Common.Sample.IBusRoute value)
        {
            _busRoute = value;
        }

        /// <summary>
        /// The time the bus route begins.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="startTime"), NaturalKeyMember][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan StartTime { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRouteStartTime;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBusRouteStartTime).StartTime == null
                || !(this as Entities.Common.Sample.IBusRouteStartTime).StartTime.Equals(compareTo.StartTime))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_busRoute != null)
                    hash = hash * 23 + _busRoute.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRouteStartTime).StartTime != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteStartTime).StartTime.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.BusRouteStartTimeMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRouteStartTime)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteStartTimeMapper.MapTo(this, (Entities.Common.Sample.IBusRouteStartTime)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRouteStartTimePutPostRequestValidator : FluentValidation.AbstractValidator<BusRouteStartTime>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRouteStartTime> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.BusRouteTelephone table of the BusRoute aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class BusRouteTelephone : Entities.Common.Sample.IBusRouteTelephone, Entities.Common.Sample.IBusRouteTelephoneSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IBusRoute _busRoute;

        [IgnoreDataMember]
        Entities.Common.Sample.IBusRoute Entities.Common.Sample.IBusRouteTelephone.BusRoute
        {
            get { return _busRoute; }
            set { SetBusRoute(value); }
        }

        internal Entities.Common.Sample.IBusRoute BusRoute
        {
            set { SetBusRoute(value); }
        }

        private void SetBusRoute(Entities.Common.Sample.IBusRoute value)
        {
            _busRoute = value;
        }

        /// <summary>
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber"), NaturalKeyMember]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="telephoneNumberTypeDescriptor"), NaturalKeyMember]
        public string TelephoneNumberTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IBusRouteTelephone;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber == null
                || !(this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber.Equals(compareTo.TelephoneNumber))
                return false;

            // Standard Property
            if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor == null
                || !(this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor.Equals(compareTo.TelephoneNumberTypeDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_busRoute != null)
                    hash = hash * 23 + _busRoute.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication that the telephone number should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="orderOfPriority")]
        public int? OrderOfPriority { get; set; }

        /// <summary>
        /// An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="textMessageCapabilityIndicator")]
        public bool? TextMessageCapabilityIndicator { get; set; }
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
            return Entities.Common.Sample.BusRouteTelephoneMapper.SynchronizeTo(this, (Entities.Common.Sample.IBusRouteTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.BusRouteTelephoneMapper.MapTo(this, (Entities.Common.Sample.IBusRouteTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IBusRouteTelephoneSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteTelephoneSynchronizationSourceSupport.IsOrderOfPrioritySupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IBusRouteTelephoneSynchronizationSourceSupport.IsTextMessageCapabilityIndicatorSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class BusRouteTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<BusRouteTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<BusRouteTelephone> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: FavoriteBookCategoryDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.FavoriteBookCategoryDescriptor.Sample
{
    /// <summary>
    /// A class which represents the sample.FavoriteBookCategoryDescriptor table of the FavoriteBookCategoryDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptor : Entities.Common.Sample.IFavoriteBookCategoryDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport
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
        /// The unique identifier for the FavoriteBookCategoryDescriptor resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="favoriteBookCategoryDescriptorId"), NaturalKeyMember]
        public int FavoriteBookCategoryDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return FavoriteBookCategoryDescriptorId; }
            set { FavoriteBookCategoryDescriptorId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IFavoriteBookCategoryDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if ((this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId == null
                || !(this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId.Equals(compareTo.FavoriteBookCategoryDescriptorId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                //Derived Property
                if ((this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// A code or abbreviation that is used to refer to the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="codeValue")]
        public string CodeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveBeginDate { get; set; }

        /// <summary>
        /// The end date of the period when the descriptor is in effect.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveEndDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="priorDescriptorId")]
        public int? PriorDescriptorId { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortDescription")]
        public string ShortDescription { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.FavoriteBookCategoryDescriptorMapper.SynchronizeTo(this, (Entities.Common.Sample.IFavoriteBookCategoryDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.FavoriteBookCategoryDescriptorMapper.MapTo(this, (Entities.Common.Sample.IFavoriteBookCategoryDescriptor)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsCodeValueSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsDescriptionSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported    { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsNamespaceSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IFavoriteBookCategoryDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported    { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<FavoriteBookCategoryDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<FavoriteBookCategoryDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: MembershipTypeDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.MembershipTypeDescriptor.Sample
{
    /// <summary>
    /// A class which represents the sample.MembershipTypeDescriptor table of the MembershipTypeDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptor : Entities.Common.Sample.IMembershipTypeDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport
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
        /// The unique identifier for the MembershipTypeDescriptor resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="membershipTypeDescriptorId"), NaturalKeyMember]
        public int MembershipTypeDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return MembershipTypeDescriptorId; }
            set { MembershipTypeDescriptorId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IMembershipTypeDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if ((this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId == null
                || !(this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId.Equals(compareTo.MembershipTypeDescriptorId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                //Derived Property
                if ((this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// A code or abbreviation that is used to refer to the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="codeValue")]
        public string CodeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveBeginDate { get; set; }

        /// <summary>
        /// The end date of the period when the descriptor is in effect.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveEndDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="priorDescriptorId")]
        public int? PriorDescriptorId { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortDescription")]
        public string ShortDescription { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.MembershipTypeDescriptorMapper.SynchronizeTo(this, (Entities.Common.Sample.IMembershipTypeDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.MembershipTypeDescriptorMapper.MapTo(this, (Entities.Common.Sample.IMembershipTypeDescriptor)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsCodeValueSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsDescriptionSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsEffectiveBeginDateSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsEffectiveEndDateSupported    { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsNamespaceSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsPriorDescriptorIdSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IMembershipTypeDescriptorSynchronizationSourceSupport.IsShortDescriptionSupported    { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<MembershipTypeDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<MembershipTypeDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Parent

namespace EdFi.Ods.Api.Common.Models.Resources.Parent.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.ParentAddressExtension table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentAddressExtension : Entities.Common.Sample.IParentAddressExtension, Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public ParentAddressExtension()
        {
            ParentAddressSchoolDistricts = new List<ParentAddressSchoolDistrict>();
            ParentAddressTerms = new List<ParentAddressTerm>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IParentAddress _parentAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IParentAddress Entities.Common.Sample.IParentAddressExtension.ParentAddress
        {
            get { return _parentAddress; }
            set { SetParentAddress(value); }
        }

        internal Entities.Common.EdFi.IParentAddress ParentAddress
        {
            set { SetParentAddress(value); }
        }

        private void SetParentAddress(Entities.Common.EdFi.IParentAddress value)
        {
            _parentAddress = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentAddressExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentAddress == null || !_parentAddress.Equals(compareTo.ParentAddress))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentAddress != null)
                    hash = hash * 23 + _parentAddress.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment or housing complex name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="complex")]
        public string Complex { get; set; }

        /// <summary>
        /// An indicator if the address is on a bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="onBusRoute")]
        public bool OnBusRoute { get; set; }
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
        private ICollection<ParentAddressSchoolDistrict> _parentAddressSchoolDistricts;
        private ICollection<Entities.Common.Sample.IParentAddressSchoolDistrict> _parentAddressSchoolDistrictsCovariant;

        [DataMember(Name="schoolDistricts"), NoDuplicateMembers]
        public ICollection<ParentAddressSchoolDistrict> ParentAddressSchoolDistricts
        {
            get { return _parentAddressSchoolDistricts; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentAddressSchoolDistrict>(value,
                    (s, e) => ((Entities.Common.Sample.IParentAddressSchoolDistrict)e.Item).ParentAddressExtension = this);
                _parentAddressSchoolDistricts = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentAddressSchoolDistrict, ParentAddressSchoolDistrict>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentAddressSchoolDistrict)e.Item).ParentAddressExtension = this;
                _parentAddressSchoolDistrictsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentAddressSchoolDistrict> Entities.Common.Sample.IParentAddressExtension.ParentAddressSchoolDistricts
        {
            get { return _parentAddressSchoolDistrictsCovariant; }
            set { ParentAddressSchoolDistricts = new List<ParentAddressSchoolDistrict>(value.Cast<ParentAddressSchoolDistrict>()); }
        }

        private ICollection<ParentAddressTerm> _parentAddressTerms;
        private ICollection<Entities.Common.Sample.IParentAddressTerm> _parentAddressTermsCovariant;

        [DataMember(Name="terms"), NoDuplicateMembers]
        public ICollection<ParentAddressTerm> ParentAddressTerms
        {
            get { return _parentAddressTerms; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentAddressTerm>(value,
                    (s, e) => ((Entities.Common.Sample.IParentAddressTerm)e.Item).ParentAddressExtension = this);
                _parentAddressTerms = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentAddressTerm, ParentAddressTerm>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentAddressTerm)e.Item).ParentAddressExtension = this;
                _parentAddressTermsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentAddressTerm> Entities.Common.Sample.IParentAddressExtension.ParentAddressTerms
        {
            get { return _parentAddressTermsCovariant; }
            set { ParentAddressTerms = new List<ParentAddressTerm>(value.Cast<ParentAddressTerm>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_parentAddressSchoolDistricts != null) foreach (var item in _parentAddressSchoolDistricts)
            {
                item.ParentAddressExtension = this;
            }

            if (_parentAddressTerms != null) foreach (var item in _parentAddressTerms)
            {
                item.ParentAddressExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.ParentAddressExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentAddressExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentAddressExtensionMapper.MapTo(this, (Entities.Common.Sample.IParentAddressExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsComplexSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsOnBusRouteSupported                    { get { return true; } set { } }
        bool Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsParentAddressSchoolDistrictsSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsParentAddressTermsSupported            { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IParentAddressSchoolDistrict, bool> Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsParentAddressSchoolDistrictIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IParentAddressTerm, bool> Entities.Common.Sample.IParentAddressExtensionSynchronizationSourceSupport.IsParentAddressTermIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentAddressExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<ParentAddressExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentAddressExtension> context, FluentValidation.Results.ValidationResult result)
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
            var parentAddressSchoolDistrictsValidator = new ParentAddressSchoolDistrictPutPostRequestValidator();

            foreach (var item in instance.ParentAddressSchoolDistricts)
            {
                var validationResult = parentAddressSchoolDistrictsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var parentAddressTermsValidator = new ParentAddressTermPutPostRequestValidator();

            foreach (var item in instance.ParentAddressTerms)
            {
                var validationResult = parentAddressTermsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.ParentAddressSchoolDistrict table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentAddressSchoolDistrict : Entities.Common.Sample.IParentAddressSchoolDistrict, Entities.Common.Sample.IParentAddressSchoolDistrictSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentAddressExtension _parentAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentAddressExtension Entities.Common.Sample.IParentAddressSchoolDistrict.ParentAddressExtension
        {
            get { return _parentAddressExtension; }
            set { SetParentAddressExtension(value); }
        }

        internal Entities.Common.Sample.IParentAddressExtension ParentAddressExtension
        {
            set { SetParentAddressExtension(value); }
        }

        private void SetParentAddressExtension(Entities.Common.Sample.IParentAddressExtension value)
        {
            _parentAddressExtension = value;
        }

        /// <summary>
        /// The school district in which the address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolDistrict"), NaturalKeyMember]
        public string SchoolDistrict { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentAddressSchoolDistrict;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentAddressExtension == null || !_parentAddressExtension.Equals(compareTo.ParentAddressExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IParentAddressSchoolDistrict).SchoolDistrict == null
                || !(this as Entities.Common.Sample.IParentAddressSchoolDistrict).SchoolDistrict.Equals(compareTo.SchoolDistrict))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentAddressExtension != null)
                    hash = hash * 23 + _parentAddressExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IParentAddressSchoolDistrict).SchoolDistrict != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentAddressSchoolDistrict).SchoolDistrict.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentAddressSchoolDistrictMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentAddressSchoolDistrict)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentAddressSchoolDistrictMapper.MapTo(this, (Entities.Common.Sample.IParentAddressSchoolDistrict)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentAddressSchoolDistrictPutPostRequestValidator : FluentValidation.AbstractValidator<ParentAddressSchoolDistrict>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentAddressSchoolDistrict> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentAddressTerm table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentAddressTerm : Entities.Common.Sample.IParentAddressTerm, Entities.Common.Sample.IParentAddressTermSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentAddressExtension _parentAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentAddressExtension Entities.Common.Sample.IParentAddressTerm.ParentAddressExtension
        {
            get { return _parentAddressExtension; }
            set { SetParentAddressExtension(value); }
        }

        internal Entities.Common.Sample.IParentAddressExtension ParentAddressExtension
        {
            set { SetParentAddressExtension(value); }
        }

        private void SetParentAddressExtension(Entities.Common.Sample.IParentAddressExtension value)
        {
            _parentAddressExtension = value;
        }

        /// <summary>
        /// Terms applicable to this address.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="termDescriptor"), NaturalKeyMember]
        public string TermDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentAddressTerm;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentAddressExtension == null || !_parentAddressExtension.Equals(compareTo.ParentAddressExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IParentAddressTerm).TermDescriptor == null
                || !(this as Entities.Common.Sample.IParentAddressTerm).TermDescriptor.Equals(compareTo.TermDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentAddressExtension != null)
                    hash = hash * 23 + _parentAddressExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IParentAddressTerm).TermDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentAddressTerm).TermDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentAddressTermMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentAddressTerm)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentAddressTermMapper.MapTo(this, (Entities.Common.Sample.IParentAddressTerm)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentAddressTermPutPostRequestValidator : FluentValidation.AbstractValidator<ParentAddressTerm>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentAddressTerm> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentAuthor table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentAuthor : Entities.Common.Sample.IParentAuthor, Entities.Common.Sample.IParentAuthorSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentAuthor.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
        }

        /// <summary>
        /// The parent's favorite authors.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="author"), NaturalKeyMember]
        public string Author { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentAuthor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IParentAuthor).Author == null
                || !(this as Entities.Common.Sample.IParentAuthor).Author.Equals(compareTo.Author))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IParentAuthor).Author != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentAuthor).Author.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentAuthorMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentAuthor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentAuthorMapper.MapTo(this, (Entities.Common.Sample.IParentAuthor)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentAuthorPutPostRequestValidator : FluentValidation.AbstractValidator<ParentAuthor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentAuthor> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentCeilingHeight table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentCeilingHeight : Entities.Common.Sample.IParentCeilingHeight, Entities.Common.Sample.IParentCeilingHeightSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentCeilingHeight.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
        }

        /// <summary>
        /// The height of the ceiling in the rooms of the parent's home.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="ceilingHeight"), NaturalKeyMember]
        public decimal CeilingHeight { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentCeilingHeight;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IParentCeilingHeight).CeilingHeight == null
                || !(this as Entities.Common.Sample.IParentCeilingHeight).CeilingHeight.Equals(compareTo.CeilingHeight))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IParentCeilingHeight).CeilingHeight != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentCeilingHeight).CeilingHeight.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentCeilingHeightMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentCeilingHeight)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentCeilingHeightMapper.MapTo(this, (Entities.Common.Sample.IParentCeilingHeight)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentCeilingHeightPutPostRequestValidator : FluentValidation.AbstractValidator<ParentCeilingHeight>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentCeilingHeight> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentCTEProgram table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentCTEProgram : Entities.Common.Sample.IParentCTEProgram, Entities.Common.Sample.IParentCTEProgramSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentCTEProgram.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.ParentCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentCTEProgramMapper.MapTo(this, (Entities.Common.Sample.IParentCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IParentCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.IParentCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.IParentCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IParentCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<ParentCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentCTEProgram> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentEducationContent table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentEducationContent : Entities.Common.Sample.IParentEducationContent, Entities.Common.Sample.IParentEducationContentSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _educationContentReferenceExplicitlyAssigned;
        private EducationContent.EdFi.EducationContentReference _educationContentReference;
        private EducationContent.EdFi.EducationContentReference ImplicitEducationContentReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_educationContentReference == null && !_educationContentReferenceExplicitlyAssigned)
                    _educationContentReference = new EducationContent.EdFi.EducationContentReference();

                return _educationContentReference;
            }
        }

        [DataMember(Name="educationContentReference")][NaturalKeyMember]
        public EducationContent.EdFi.EducationContentReference EducationContentReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitEducationContentReference != null
                    && (_educationContentReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitEducationContentReference.IsReferenceFullyDefined()))
                    return ImplicitEducationContentReference;

                return null;
            }
            set
            {
                _educationContentReferenceExplicitlyAssigned = true;
                _educationContentReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentEducationContent.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
        }

        /// <summary>
        /// A unique identifier for the EducationContent.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IParentEducationContent.ContentIdentifier
        {
            get
            {
                if (ImplicitEducationContentReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitEducationContentReference.IsReferenceFullyDefined()))
                    return ImplicitEducationContentReference.ContentIdentifier;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // EducationContent
                _educationContentReferenceExplicitlyAssigned = false;
                ImplicitEducationContentReference.ContentIdentifier = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentEducationContent;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IParentEducationContent).ContentIdentifier == null
                || !(this as Entities.Common.Sample.IParentEducationContent).ContentIdentifier.Equals(compareTo.ContentIdentifier))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentEducationContent).ContentIdentifier != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentEducationContent).ContentIdentifier.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentEducationContentMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentEducationContent)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentEducationContentMapper.MapTo(this, (Entities.Common.Sample.IParentEducationContent)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IParentEducationContent.EducationContentResourceId
        {
            get { return null; }
            set { ImplicitEducationContentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IParentEducationContent.EducationContentDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitEducationContentReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentEducationContentPutPostRequestValidator : FluentValidation.AbstractValidator<ParentEducationContent>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentEducationContent> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentExtension table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentExtension : Entities.Common.Sample.IParentExtension, Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public ParentExtension()
        {
            ParentAuthors = new List<ParentAuthor>();
            ParentCeilingHeights = new List<ParentCeilingHeight>();
            ParentEducationContents = new List<ParentEducationContent>();
            ParentFavoriteBookTitles = new List<ParentFavoriteBookTitle>();
            ParentStudentProgramAssociations = new List<ParentStudentProgramAssociation>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IParent _parent;

        [IgnoreDataMember]
        Entities.Common.EdFi.IParent Entities.Common.Sample.IParentExtension.Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        internal Entities.Common.EdFi.IParent Parent
        {
            set { SetParent(value); }
        }

        private void SetParent(Entities.Common.EdFi.IParent value)
        {
            _parent = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parent == null || !_parent.Equals(compareTo.Parent))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parent != null)
                    hash = hash * 23 + _parent.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The time spent per day waiting in the car line.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="averageCarLineWait")]
        public string AverageCarLineWait { get; set; }

        /// <summary>
        /// The year in which the parent first became a parent.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="becameParent")]
        public short? BecameParent { get; set; }

        /// <summary>
        /// How much the parent spends on coffee in a week.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="coffeeSpend")][Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public decimal? CoffeeSpend { get; set; }

        /// <summary>
        /// The field in which the parent holds a credential.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="credentialFieldDescriptor")]
        public string CredentialFieldDescriptor { get; set; }

        /// <summary>
        /// The amount of time the parent spends reading to his/her children at bedtime.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// The parent's high school GPA.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="gpa")][Range(typeof(decimal), "-99999999999999.9999", "99999999999999.9999")]
        public decimal? GPA { get; set; }

        /// <summary>
        /// The date the parent graduated high school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="graduationDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? GraduationDate { get; set; }

        /// <summary>
        /// An indication as to whether the parent is a sports fan.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isSportsFan")]
        public bool IsSportsFan { get; set; }

        /// <summary>
        /// The parent's lucky number.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="luckyNumber")]
        public int? LuckyNumber { get; set; }

        /// <summary>
        /// The time the parent would prefer to wake up in the morning.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="preferredWakeUpTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan? PreferredWakeUpTime { get; set; }

        /// <summary>
        /// The percent likelihood that it will rain when the parent volunteers to chaperone a field trip.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="rainCertainty")][Range(typeof(decimal), "-9.9999", "9.9999")]
        public decimal? RainCertainty { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public ParentCTEProgram ParentCTEProgram { get; set; }

        Entities.Common.Sample.IParentCTEProgram Entities.Common.Sample.IParentExtension.ParentCTEProgram
        {
            get { return ParentCTEProgram; }
            set { ParentCTEProgram = (ParentCTEProgram) value; }
        }

        /// <summary>
        /// teacherConference
        /// </summary>
        [DataMember(Name = "teacherConference")]
        public ParentTeacherConference ParentTeacherConference { get; set; }

        Entities.Common.Sample.IParentTeacherConference Entities.Common.Sample.IParentExtension.ParentTeacherConference
        {
            get { return ParentTeacherConference; }
            set { ParentTeacherConference = (ParentTeacherConference) value; }
        }

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
        private ICollection<ParentAuthor> _parentAuthors;
        private ICollection<Entities.Common.Sample.IParentAuthor> _parentAuthorsCovariant;

        [DataMember(Name="authors"), NoDuplicateMembers]
        public ICollection<ParentAuthor> ParentAuthors
        {
            get { return _parentAuthors; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentAuthor>(value,
                    (s, e) => ((Entities.Common.Sample.IParentAuthor)e.Item).ParentExtension = this);
                _parentAuthors = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentAuthor, ParentAuthor>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentAuthor)e.Item).ParentExtension = this;
                _parentAuthorsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentAuthor> Entities.Common.Sample.IParentExtension.ParentAuthors
        {
            get { return _parentAuthorsCovariant; }
            set { ParentAuthors = new List<ParentAuthor>(value.Cast<ParentAuthor>()); }
        }

        private ICollection<ParentCeilingHeight> _parentCeilingHeights;
        private ICollection<Entities.Common.Sample.IParentCeilingHeight> _parentCeilingHeightsCovariant;

        [DataMember(Name="ceilingHeights"), NoDuplicateMembers]
        public ICollection<ParentCeilingHeight> ParentCeilingHeights
        {
            get { return _parentCeilingHeights; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentCeilingHeight>(value,
                    (s, e) => ((Entities.Common.Sample.IParentCeilingHeight)e.Item).ParentExtension = this);
                _parentCeilingHeights = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentCeilingHeight, ParentCeilingHeight>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentCeilingHeight)e.Item).ParentExtension = this;
                _parentCeilingHeightsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentCeilingHeight> Entities.Common.Sample.IParentExtension.ParentCeilingHeights
        {
            get { return _parentCeilingHeightsCovariant; }
            set { ParentCeilingHeights = new List<ParentCeilingHeight>(value.Cast<ParentCeilingHeight>()); }
        }

        private ICollection<ParentEducationContent> _parentEducationContents;
        private ICollection<Entities.Common.Sample.IParentEducationContent> _parentEducationContentsCovariant;

        [DataMember(Name="educationContents"), NoDuplicateMembers]
        public ICollection<ParentEducationContent> ParentEducationContents
        {
            get { return _parentEducationContents; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentEducationContent>(value,
                    (s, e) => ((Entities.Common.Sample.IParentEducationContent)e.Item).ParentExtension = this);
                _parentEducationContents = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentEducationContent, ParentEducationContent>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentEducationContent)e.Item).ParentExtension = this;
                _parentEducationContentsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentEducationContent> Entities.Common.Sample.IParentExtension.ParentEducationContents
        {
            get { return _parentEducationContentsCovariant; }
            set { ParentEducationContents = new List<ParentEducationContent>(value.Cast<ParentEducationContent>()); }
        }

        private ICollection<ParentFavoriteBookTitle> _parentFavoriteBookTitles;
        private ICollection<Entities.Common.Sample.IParentFavoriteBookTitle> _parentFavoriteBookTitlesCovariant;

        [DataMember(Name="favoriteBookTitles"), NoDuplicateMembers]
        public ICollection<ParentFavoriteBookTitle> ParentFavoriteBookTitles
        {
            get { return _parentFavoriteBookTitles; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentFavoriteBookTitle>(value,
                    (s, e) => ((Entities.Common.Sample.IParentFavoriteBookTitle)e.Item).ParentExtension = this);
                _parentFavoriteBookTitles = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentFavoriteBookTitle, ParentFavoriteBookTitle>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentFavoriteBookTitle)e.Item).ParentExtension = this;
                _parentFavoriteBookTitlesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentFavoriteBookTitle> Entities.Common.Sample.IParentExtension.ParentFavoriteBookTitles
        {
            get { return _parentFavoriteBookTitlesCovariant; }
            set { ParentFavoriteBookTitles = new List<ParentFavoriteBookTitle>(value.Cast<ParentFavoriteBookTitle>()); }
        }

        private ICollection<ParentStudentProgramAssociation> _parentStudentProgramAssociations;
        private ICollection<Entities.Common.Sample.IParentStudentProgramAssociation> _parentStudentProgramAssociationsCovariant;

        [DataMember(Name="studentProgramAssociations"), NoDuplicateMembers]
        public ICollection<ParentStudentProgramAssociation> ParentStudentProgramAssociations
        {
            get { return _parentStudentProgramAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentStudentProgramAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IParentStudentProgramAssociation)e.Item).ParentExtension = this);
                _parentStudentProgramAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IParentStudentProgramAssociation, ParentStudentProgramAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IParentStudentProgramAssociation)e.Item).ParentExtension = this;
                _parentStudentProgramAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IParentStudentProgramAssociation> Entities.Common.Sample.IParentExtension.ParentStudentProgramAssociations
        {
            get { return _parentStudentProgramAssociationsCovariant; }
            set { ParentStudentProgramAssociations = new List<ParentStudentProgramAssociation>(value.Cast<ParentStudentProgramAssociation>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_parentAuthors != null) foreach (var item in _parentAuthors)
            {
                item.ParentExtension = this;
            }

            if (_parentCeilingHeights != null) foreach (var item in _parentCeilingHeights)
            {
                item.ParentExtension = this;
            }

            if (_parentEducationContents != null) foreach (var item in _parentEducationContents)
            {
                item.ParentExtension = this;
            }

            if (_parentFavoriteBookTitles != null) foreach (var item in _parentFavoriteBookTitles)
            {
                item.ParentExtension = this;
            }

            if (_parentStudentProgramAssociations != null) foreach (var item in _parentStudentProgramAssociations)
            {
                item.ParentExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.ParentExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentExtensionMapper.MapTo(this, (Entities.Common.Sample.IParentExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsAverageCarLineWaitSupported                { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsBecameParentSupported                      { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsCoffeeSpendSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsCredentialFieldDescriptorSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsDurationSupported                          { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsGPASupported                               { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsGraduationDateSupported                    { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsIsSportsFanSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsLuckyNumberSupported                       { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentAuthorsSupported                     { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentCeilingHeightsSupported              { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentCTEProgramSupported                  { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentEducationContentsSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentFavoriteBookTitlesSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentStudentProgramAssociationsSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentTeacherConferenceSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsPreferredWakeUpTimeSupported               { get { return true; } set { } }
        bool Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsRainCertaintySupported                     { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IParentAuthor, bool> Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentAuthorIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IParentCeilingHeight, bool> Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentCeilingHeightIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IParentEducationContent, bool> Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentEducationContentIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IParentFavoriteBookTitle, bool> Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentFavoriteBookTitleIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IParentStudentProgramAssociation, bool> Entities.Common.Sample.IParentExtensionSynchronizationSourceSupport.IsParentStudentProgramAssociationIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<ParentExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentExtension> context, FluentValidation.Results.ValidationResult result)
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
            var parentAuthorsValidator = new ParentAuthorPutPostRequestValidator();

            foreach (var item in instance.ParentAuthors)
            {
                var validationResult = parentAuthorsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var parentCeilingHeightsValidator = new ParentCeilingHeightPutPostRequestValidator();

            foreach (var item in instance.ParentCeilingHeights)
            {
                var validationResult = parentCeilingHeightsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var parentEducationContentsValidator = new ParentEducationContentPutPostRequestValidator();

            foreach (var item in instance.ParentEducationContents)
            {
                var validationResult = parentEducationContentsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var parentFavoriteBookTitlesValidator = new ParentFavoriteBookTitlePutPostRequestValidator();

            foreach (var item in instance.ParentFavoriteBookTitles)
            {
                var validationResult = parentFavoriteBookTitlesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var parentStudentProgramAssociationsValidator = new ParentStudentProgramAssociationPutPostRequestValidator();

            foreach (var item in instance.ParentStudentProgramAssociations)
            {
                var validationResult = parentStudentProgramAssociationsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.ParentFavoriteBookTitle table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentFavoriteBookTitle : Entities.Common.Sample.IParentFavoriteBookTitle, Entities.Common.Sample.IParentFavoriteBookTitleSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentFavoriteBookTitle.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
        }

        /// <summary>
        /// The title of the parent's favorite book.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="favoriteBookTitle"), NaturalKeyMember]
        public string FavoriteBookTitle { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentFavoriteBookTitle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IParentFavoriteBookTitle).FavoriteBookTitle == null
                || !(this as Entities.Common.Sample.IParentFavoriteBookTitle).FavoriteBookTitle.Equals(compareTo.FavoriteBookTitle))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IParentFavoriteBookTitle).FavoriteBookTitle != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentFavoriteBookTitle).FavoriteBookTitle.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentFavoriteBookTitleMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentFavoriteBookTitleMapper.MapTo(this, (Entities.Common.Sample.IParentFavoriteBookTitle)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentFavoriteBookTitlePutPostRequestValidator : FluentValidation.AbstractValidator<ParentFavoriteBookTitle>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentFavoriteBookTitle> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentStudentProgramAssociation table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentStudentProgramAssociation : Entities.Common.Sample.IParentStudentProgramAssociation, Entities.Common.Sample.IParentStudentProgramAssociationSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _studentProgramAssociationReferenceExplicitlyAssigned;
        private StudentProgramAssociation.EdFi.StudentProgramAssociationReference _studentProgramAssociationReference;
        private StudentProgramAssociation.EdFi.StudentProgramAssociationReference ImplicitStudentProgramAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentProgramAssociationReference == null && !_studentProgramAssociationReferenceExplicitlyAssigned)
                    _studentProgramAssociationReference = new StudentProgramAssociation.EdFi.StudentProgramAssociationReference();

                return _studentProgramAssociationReference;
            }
        }

        [DataMember(Name="studentProgramAssociationReference")][NaturalKeyMember]
        public StudentProgramAssociation.EdFi.StudentProgramAssociationReference StudentProgramAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentProgramAssociationReference != null
                    && (_studentProgramAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference;

                return null;
            }
            set
            {
                _studentProgramAssociationReferenceExplicitlyAssigned = true;
                _studentProgramAssociationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentStudentProgramAssociation.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
        }

        /// <summary>
        /// The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        DateTime Entities.Common.Sample.IParentStudentProgramAssociation.BeginDate
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.BeginDate;

                return default(DateTime);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentProgramAssociation
                _studentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentProgramAssociationReference.BeginDate = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.Sample.IParentStudentProgramAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentProgramAssociation
                _studentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentProgramAssociationReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.Sample.IParentStudentProgramAssociation.ProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.ProgramEducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentProgramAssociation
                _studentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentProgramAssociationReference.ProgramEducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IParentStudentProgramAssociation.ProgramName
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.ProgramName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentProgramAssociation
                _studentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentProgramAssociationReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (ParentStudentProgramAssociation.ProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IParentStudentProgramAssociation.ProgramTypeDescriptor
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.ProgramTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitStudentProgramAssociationReference.ProgramTypeDescriptor = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IParentStudentProgramAssociation.StudentUniqueId
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.StudentUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentProgramAssociation
                _studentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentProgramAssociationReference.StudentUniqueId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentStudentProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).BeginDate == null
                || !(this as Entities.Common.Sample.IParentStudentProgramAssociation).BeginDate.Equals(compareTo.BeginDate))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).EducationOrganizationId == null
                || !(this as Entities.Common.Sample.IParentStudentProgramAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramEducationOrganizationId == null
                || !(this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramEducationOrganizationId.Equals(compareTo.ProgramEducationOrganizationId))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramName == null
                || !(this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramName.Equals(compareTo.ProgramName))
                return false;

            // Unified Type Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramTypeDescriptor == null
                ||!(this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).StudentUniqueId == null
                || !(this as Entities.Common.Sample.IParentStudentProgramAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).BeginDate != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).BeginDate.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).EducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).EducationOrganizationId.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramEducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramEducationOrganizationId.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramName.GetHashCode();

                //Unified Type Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramTypeDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).ProgramTypeDescriptor.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IParentStudentProgramAssociation).StudentUniqueId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IParentStudentProgramAssociation).StudentUniqueId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.ParentStudentProgramAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentStudentProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentStudentProgramAssociationMapper.MapTo(this, (Entities.Common.Sample.IParentStudentProgramAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IParentStudentProgramAssociation.StudentProgramAssociationResourceId
        {
            get { return null; }
            set { ImplicitStudentProgramAssociationReference.ResourceId = value ?? default(Guid); }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentStudentProgramAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<ParentStudentProgramAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentStudentProgramAssociation> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.ParentTeacherConference table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentTeacherConference : Entities.Common.Sample.IParentTeacherConference, Entities.Common.Sample.IParentTeacherConferenceSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IParentExtension _parentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IParentExtension Entities.Common.Sample.IParentTeacherConference.ParentExtension
        {
            get { return _parentExtension; }
            set { SetParentExtension(value); }
        }

        internal Entities.Common.Sample.IParentExtension ParentExtension
        {
            set { SetParentExtension(value); }
        }

        private void SetParentExtension(Entities.Common.Sample.IParentExtension value)
        {
            _parentExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IParentTeacherConference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parentExtension == null || !_parentExtension.Equals(compareTo.ParentExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_parentExtension != null)
                    hash = hash * 23 + _parentExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The day of the week the parent prefers to meet for parent-teacher conferences.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="dayOfWeek")]
        public string DayOfWeek { get; set; }

        /// <summary>
        /// The end time the parent prefers to meet for parent-teacher conferences.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The start time the parent prefers to meet for parent-teacher conferences.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="startTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan StartTime { get; set; }
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
            return Entities.Common.Sample.ParentTeacherConferenceMapper.SynchronizeTo(this, (Entities.Common.Sample.IParentTeacherConference)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ParentTeacherConferenceMapper.MapTo(this, (Entities.Common.Sample.IParentTeacherConference)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IParentTeacherConferenceSynchronizationSourceSupport.IsDayOfWeekSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IParentTeacherConferenceSynchronizationSourceSupport.IsEndTimeSupported    { get { return true; } set { } }
        bool Entities.Common.Sample.IParentTeacherConferenceSynchronizationSourceSupport.IsStartTimeSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentTeacherConferencePutPostRequestValidator : FluentValidation.AbstractValidator<ParentTeacherConference>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentTeacherConference> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: School

namespace EdFi.Ods.Api.Common.Models.Resources.School.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram, Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolCTEProgram.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.SchoolCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolCTEProgramMapper.MapTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCTEProgram> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus, Entities.Common.Sample.ISchoolDirectlyOwnedBusSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _directlyOwnedBusReferenceExplicitlyAssigned;
        private Bus.Sample.BusReference _directlyOwnedBusReference;
        private Bus.Sample.BusReference ImplicitDirectlyOwnedBusReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_directlyOwnedBusReference == null && !_directlyOwnedBusReferenceExplicitlyAssigned)
                    _directlyOwnedBusReference = new Bus.Sample.BusReference();

                return _directlyOwnedBusReference;
            }
        }

        [DataMember(Name="directlyOwnedBusReference")][NaturalKeyMember]
        public Bus.Sample.BusReference DirectlyOwnedBusReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_directlyOwnedBusReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference;

                return null;
            }
            set
            {
                _directlyOwnedBusReferenceExplicitlyAssigned = true;
                _directlyOwnedBusReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
        }

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusId
        {
            get
            {
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference.BusId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // DirectlyOwnedBus
                _directlyOwnedBusReferenceExplicitlyAssigned = false;
                ImplicitDirectlyOwnedBusReference.BusId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId == null
                || !(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.MapTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId
        {
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBusPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolDirectlyOwnedBus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolDirectlyOwnedBus> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension, Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public SchoolExtension()
        {
            SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.Sample.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the school is exemplary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isExemplary")]
        public bool? IsExemplary { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public SchoolCTEProgram SchoolCTEProgram { get; set; }

        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get { return SchoolCTEProgram; }
            set { SchoolCTEProgram = (SchoolCTEProgram) value; }
        }

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
        private ICollection<SchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBusesCovariant;

        [DataMember(Name="directlyOwnedBuses"), NoDuplicateMembers]
        public ICollection<SchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBuses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolDirectlyOwnedBus>(value,
                    (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this);
                _schoolDirectlyOwnedBuses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this;
                _schoolDirectlyOwnedBusesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> Entities.Common.Sample.ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBusesCovariant; }
            set { SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>(value.Cast<SchoolDirectlyOwnedBus>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_schoolDirectlyOwnedBuses != null) foreach (var item in _schoolDirectlyOwnedBuses)
            {
                item.SchoolExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolExtensionMapper.MapTo(this, (Entities.Common.Sample.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsIsExemplarySupported               { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolCTEProgramSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusesSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.ISchoolDirectlyOwnedBus, bool> Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
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
            var schoolDirectlyOwnedBusesValidator = new SchoolDirectlyOwnedBusPutPostRequestValidator();

            foreach (var item in instance.SchoolDirectlyOwnedBuses)
            {
                var validationResult = schoolDirectlyOwnedBusesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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
// Aggregate: Staff

namespace EdFi.Ods.Api.Common.Models.Resources.Staff.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StaffExtension table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffExtension : Entities.Common.Sample.IStaffExtension, Entities.Common.Sample.IStaffExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StaffExtension()
        {
            StaffPets = new List<StaffPet>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStaff _staff;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStaff Entities.Common.Sample.IStaffExtension.Staff
        {
            get { return _staff; }
            set { SetStaff(value); }
        }

        internal Entities.Common.EdFi.IStaff Staff
        {
            set { SetStaff(value); }
        }

        private void SetStaff(Entities.Common.EdFi.IStaff value)
        {
            _staff = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStaffExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staff == null || !_staff.Equals(compareTo.Staff))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_staff != null)
                    hash = hash * 23 + _staff.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The date the staff member adopted the first household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="firstPetOwnedDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? FirstPetOwnedDate { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// petPreference
        /// </summary>
        [DataMember(Name = "petPreference")]
        public StaffPetPreference StaffPetPreference { get; set; }

        Entities.Common.Sample.IStaffPetPreference Entities.Common.Sample.IStaffExtension.StaffPetPreference
        {
            get { return StaffPetPreference; }
            set { StaffPetPreference = (StaffPetPreference) value; }
        }

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
        private ICollection<StaffPet> _staffPets;
        private ICollection<Entities.Common.Sample.IStaffPet> _staffPetsCovariant;

        [DataMember(Name="pets"), NoDuplicateMembers]
        public ICollection<StaffPet> StaffPets
        {
            get { return _staffPets; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StaffPet>(value,
                    (s, e) => ((Entities.Common.Sample.IStaffPet)e.Item).StaffExtension = this);
                _staffPets = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStaffPet, StaffPet>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStaffPet)e.Item).StaffExtension = this;
                _staffPetsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStaffPet> Entities.Common.Sample.IStaffExtension.StaffPets
        {
            get { return _staffPetsCovariant; }
            set { StaffPets = new List<StaffPet>(value.Cast<StaffPet>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_staffPets != null) foreach (var item in _staffPets)
            {
                item.StaffExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StaffExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStaffExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StaffExtensionMapper.MapTo(this, (Entities.Common.Sample.IStaffExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStaffExtensionSynchronizationSourceSupport.IsFirstPetOwnedDateSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IStaffExtensionSynchronizationSourceSupport.IsStaffPetPreferenceSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStaffExtensionSynchronizationSourceSupport.IsStaffPetsSupported           { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStaffPet, bool> Entities.Common.Sample.IStaffExtensionSynchronizationSourceSupport.IsStaffPetIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StaffExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StaffExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffExtension> context, FluentValidation.Results.ValidationResult result)
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
            var staffPetsValidator = new StaffPetPutPostRequestValidator();

            foreach (var item in instance.StaffPets)
            {
                var validationResult = staffPetsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StaffPet table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffPet : Entities.Common.Sample.IStaffPet, Entities.Common.Sample.IStaffPetSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStaffExtension _staffExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStaffExtension Entities.Common.Sample.IStaffPet.StaffExtension
        {
            get { return _staffExtension; }
            set { SetStaffExtension(value); }
        }

        internal Entities.Common.Sample.IStaffExtension StaffExtension
        {
            set { SetStaffExtension(value); }
        }

        private void SetStaffExtension(Entities.Common.Sample.IStaffExtension value)
        {
            _staffExtension = value;
        }

        /// <summary>
        /// The pet's name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="petName"), NaturalKeyMember]
        public string PetName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStaffPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staffExtension == null || !_staffExtension.Equals(compareTo.StaffExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStaffPet).PetName == null
                || !(this as Entities.Common.Sample.IStaffPet).PetName.Equals(compareTo.PetName))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_staffExtension != null)
                    hash = hash * 23 + _staffExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStaffPet).PetName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStaffPet).PetName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the pet has been spayed/neutered.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isFixed")]
        public bool? IsFixed { get; set; }
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
            return Entities.Common.Sample.StaffPetMapper.SynchronizeTo(this, (Entities.Common.Sample.IStaffPet)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StaffPetMapper.MapTo(this, (Entities.Common.Sample.IStaffPet)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStaffPetSynchronizationSourceSupport.IsIsFixedSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StaffPetPutPostRequestValidator : FluentValidation.AbstractValidator<StaffPet>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffPet> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StaffPetPreference table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffPetPreference : Entities.Common.Sample.IStaffPetPreference, Entities.Common.Sample.IStaffPetPreferenceSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStaffExtension _staffExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStaffExtension Entities.Common.Sample.IStaffPetPreference.StaffExtension
        {
            get { return _staffExtension; }
            set { SetStaffExtension(value); }
        }

        internal Entities.Common.Sample.IStaffExtension StaffExtension
        {
            set { SetStaffExtension(value); }
        }

        private void SetStaffExtension(Entities.Common.Sample.IStaffExtension value)
        {
            _staffExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStaffPetPreference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staffExtension == null || !_staffExtension.Equals(compareTo.StaffExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_staffExtension != null)
                    hash = hash * 23 + _staffExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The preferred maximum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="maximumWeight")]
        public int MaximumWeight { get; set; }

        /// <summary>
        /// The preferred minimum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="minimumWeight")]
        public int MinimumWeight { get; set; }
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
            return Entities.Common.Sample.StaffPetPreferenceMapper.SynchronizeTo(this, (Entities.Common.Sample.IStaffPetPreference)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StaffPetPreferenceMapper.MapTo(this, (Entities.Common.Sample.IStaffPetPreference)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStaffPetPreferenceSynchronizationSourceSupport.IsMaximumWeightSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStaffPetPreferenceSynchronizationSourceSupport.IsMinimumWeightSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StaffPetPreferencePutPostRequestValidator : FluentValidation.AbstractValidator<StaffPetPreference>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffPetPreference> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Student

namespace EdFi.Ods.Api.Common.Models.Resources.Student.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentAquaticPet table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentAquaticPet : Entities.Common.Sample.IStudentAquaticPet, Entities.Common.Sample.IStudentAquaticPetSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentExtension _studentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentExtension Entities.Common.Sample.IStudentAquaticPet.StudentExtension
        {
            get { return _studentExtension; }
            set { SetStudentExtension(value); }
        }

        internal Entities.Common.Sample.IStudentExtension StudentExtension
        {
            set { SetStudentExtension(value); }
        }

        private void SetStudentExtension(Entities.Common.Sample.IStudentExtension value)
        {
            _studentExtension = value;
        }

        /// <summary>
        /// The minimum tank volume this aquatic pet requires.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="mimimumTankVolume"), NaturalKeyMember]
        public int MimimumTankVolume { get; set; }

        /// <summary>
        /// The pet's name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="petName"), NaturalKeyMember]
        public string PetName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentAquaticPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume == null
                || !(this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume.Equals(compareTo.MimimumTankVolume))
                return false;

            // Standard Property
            if ((this as Entities.Common.Sample.IStudentAquaticPet).PetName == null
                || !(this as Entities.Common.Sample.IStudentAquaticPet).PetName.Equals(compareTo.PetName))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentExtension != null)
                    hash = hash * 23 + _studentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentAquaticPet).PetName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentAquaticPet).PetName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the pet has been spayed/neutered.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isFixed")]
        public bool? IsFixed { get; set; }
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
            return Entities.Common.Sample.StudentAquaticPetMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentAquaticPet)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentAquaticPetMapper.MapTo(this, (Entities.Common.Sample.IStudentAquaticPet)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentAquaticPetSynchronizationSourceSupport.IsIsFixedSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentAquaticPetPutPostRequestValidator : FluentValidation.AbstractValidator<StudentAquaticPet>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAquaticPet> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentExtension table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentExtension : Entities.Common.Sample.IStudentExtension, Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentExtension()
        {
            StudentAquaticPets = new List<StudentAquaticPet>();
            StudentFavoriteBooks = new List<StudentFavoriteBook>();
            StudentPets = new List<StudentPet>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudent _student;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudent Entities.Common.Sample.IStudentExtension.Student
        {
            get { return _student; }
            set { SetStudent(value); }
        }

        internal Entities.Common.EdFi.IStudent Student
        {
            set { SetStudent(value); }
        }

        private void SetStudent(Entities.Common.EdFi.IStudent value)
        {
            _student = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_student == null || !_student.Equals(compareTo.Student))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_student != null)
                    hash = hash * 23 + _student.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// petPreference
        /// </summary>
        [DataMember(Name = "petPreference")]
        public StudentPetPreference StudentPetPreference { get; set; }

        Entities.Common.Sample.IStudentPetPreference Entities.Common.Sample.IStudentExtension.StudentPetPreference
        {
            get { return StudentPetPreference; }
            set { StudentPetPreference = (StudentPetPreference) value; }
        }

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
        private ICollection<StudentAquaticPet> _studentAquaticPets;
        private ICollection<Entities.Common.Sample.IStudentAquaticPet> _studentAquaticPetsCovariant;

        [DataMember(Name="aquaticPets"), NoDuplicateMembers]
        public ICollection<StudentAquaticPet> StudentAquaticPets
        {
            get { return _studentAquaticPets; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentAquaticPet>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentAquaticPet)e.Item).StudentExtension = this);
                _studentAquaticPets = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentAquaticPet, StudentAquaticPet>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentAquaticPet)e.Item).StudentExtension = this;
                _studentAquaticPetsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentAquaticPet> Entities.Common.Sample.IStudentExtension.StudentAquaticPets
        {
            get { return _studentAquaticPetsCovariant; }
            set { StudentAquaticPets = new List<StudentAquaticPet>(value.Cast<StudentAquaticPet>()); }
        }

        private ICollection<StudentFavoriteBook> _studentFavoriteBooks;
        private ICollection<Entities.Common.Sample.IStudentFavoriteBook> _studentFavoriteBooksCovariant;

        [DataMember(Name="favoriteBooks"), NoDuplicateMembers]
        public ICollection<StudentFavoriteBook> StudentFavoriteBooks
        {
            get { return _studentFavoriteBooks; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentFavoriteBook>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentFavoriteBook)e.Item).StudentExtension = this);
                _studentFavoriteBooks = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentFavoriteBook, StudentFavoriteBook>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentFavoriteBook)e.Item).StudentExtension = this;
                _studentFavoriteBooksCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentFavoriteBook> Entities.Common.Sample.IStudentExtension.StudentFavoriteBooks
        {
            get { return _studentFavoriteBooksCovariant; }
            set { StudentFavoriteBooks = new List<StudentFavoriteBook>(value.Cast<StudentFavoriteBook>()); }
        }

        private ICollection<StudentPet> _studentPets;
        private ICollection<Entities.Common.Sample.IStudentPet> _studentPetsCovariant;

        [DataMember(Name="pets"), NoDuplicateMembers]
        public ICollection<StudentPet> StudentPets
        {
            get { return _studentPets; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentPet>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentPet)e.Item).StudentExtension = this);
                _studentPets = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentPet, StudentPet>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentPet)e.Item).StudentExtension = this;
                _studentPetsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentPet> Entities.Common.Sample.IStudentExtension.StudentPets
        {
            get { return _studentPetsCovariant; }
            set { StudentPets = new List<StudentPet>(value.Cast<StudentPet>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentAquaticPets != null) foreach (var item in _studentAquaticPets)
            {
                item.StudentExtension = this;
            }

            if (_studentFavoriteBooks != null) foreach (var item in _studentFavoriteBooks)
            {
                item.StudentExtension = this;
            }

            if (_studentPets != null) foreach (var item in _studentPets)
            {
                item.StudentExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentAquaticPetsSupported    { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentFavoriteBooksSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentPetPreferenceSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentPetsSupported           { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentAquaticPet, bool> Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentAquaticPetIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentFavoriteBook, bool> Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentFavoriteBookIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentPet, bool> Entities.Common.Sample.IStudentExtensionSynchronizationSourceSupport.IsStudentPetIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentExtension> context, FluentValidation.Results.ValidationResult result)
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
            var studentAquaticPetsValidator = new StudentAquaticPetPutPostRequestValidator();

            foreach (var item in instance.StudentAquaticPets)
            {
                var validationResult = studentAquaticPetsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentFavoriteBooksValidator = new StudentFavoriteBookPutPostRequestValidator();

            foreach (var item in instance.StudentFavoriteBooks)
            {
                var validationResult = studentFavoriteBooksValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentPetsValidator = new StudentPetPutPostRequestValidator();

            foreach (var item in instance.StudentPets)
            {
                var validationResult = studentPetsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentFavoriteBook table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBook : Entities.Common.Sample.IStudentFavoriteBook, Entities.Common.Sample.IStudentFavoriteBookSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentFavoriteBook()
        {
            StudentFavoriteBookArtMedia = new List<StudentFavoriteBookArtMedium>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentExtension _studentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentExtension Entities.Common.Sample.IStudentFavoriteBook.StudentExtension
        {
            get { return _studentExtension; }
            set { SetStudentExtension(value); }
        }

        internal Entities.Common.Sample.IStudentExtension StudentExtension
        {
            set { SetStudentExtension(value); }
        }

        private void SetStudentExtension(Entities.Common.Sample.IStudentExtension value)
        {
            _studentExtension = value;
        }

        /// <summary>
        /// This is documentation.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="favoriteBookCategoryDescriptor"), NaturalKeyMember]
        public string FavoriteBookCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentFavoriteBook;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor == null
                || !(this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor.Equals(compareTo.FavoriteBookCategoryDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentExtension != null)
                    hash = hash * 23 + _studentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// This is documentation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bookTitle")]
        public string BookTitle { get; set; }
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
        private ICollection<StudentFavoriteBookArtMedium> _studentFavoriteBookArtMedia;
        private ICollection<Entities.Common.Sample.IStudentFavoriteBookArtMedium> _studentFavoriteBookArtMediaCovariant;

        [DataMember(Name="artMedia"), NoDuplicateMembers]
        public ICollection<StudentFavoriteBookArtMedium> StudentFavoriteBookArtMedia
        {
            get { return _studentFavoriteBookArtMedia; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentFavoriteBookArtMedium>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentFavoriteBookArtMedium)e.Item).StudentFavoriteBook = this);
                _studentFavoriteBookArtMedia = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentFavoriteBookArtMedium, StudentFavoriteBookArtMedium>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentFavoriteBookArtMedium)e.Item).StudentFavoriteBook = this;
                _studentFavoriteBookArtMediaCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentFavoriteBookArtMedium> Entities.Common.Sample.IStudentFavoriteBook.StudentFavoriteBookArtMedia
        {
            get { return _studentFavoriteBookArtMediaCovariant; }
            set { StudentFavoriteBookArtMedia = new List<StudentFavoriteBookArtMedium>(value.Cast<StudentFavoriteBookArtMedium>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentFavoriteBookArtMedia != null) foreach (var item in _studentFavoriteBookArtMedia)
            {
                item.StudentFavoriteBook = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentFavoriteBookMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentFavoriteBook)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentFavoriteBookMapper.MapTo(this, (Entities.Common.Sample.IStudentFavoriteBook)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentFavoriteBookSynchronizationSourceSupport.IsBookTitleSupported                    { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentFavoriteBookSynchronizationSourceSupport.IsStudentFavoriteBookArtMediaSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentFavoriteBookArtMedium, bool> Entities.Common.Sample.IStudentFavoriteBookSynchronizationSourceSupport.IsStudentFavoriteBookArtMediumIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBookPutPostRequestValidator : FluentValidation.AbstractValidator<StudentFavoriteBook>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentFavoriteBook> context, FluentValidation.Results.ValidationResult result)
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
            var studentFavoriteBookArtMediaValidator = new StudentFavoriteBookArtMediumPutPostRequestValidator();

            foreach (var item in instance.StudentFavoriteBookArtMedia)
            {
                var validationResult = studentFavoriteBookArtMediaValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentFavoriteBookArtMedium table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBookArtMedium : Entities.Common.Sample.IStudentFavoriteBookArtMedium, Entities.Common.Sample.IStudentFavoriteBookArtMediumSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentFavoriteBook _studentFavoriteBook;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentFavoriteBook Entities.Common.Sample.IStudentFavoriteBookArtMedium.StudentFavoriteBook
        {
            get { return _studentFavoriteBook; }
            set { SetStudentFavoriteBook(value); }
        }

        internal Entities.Common.Sample.IStudentFavoriteBook StudentFavoriteBook
        {
            set { SetStudentFavoriteBook(value); }
        }

        private void SetStudentFavoriteBook(Entities.Common.Sample.IStudentFavoriteBook value)
        {
            _studentFavoriteBook = value;
        }

        /// <summary>
        /// This is documentation.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="artMediumDescriptor"), NaturalKeyMember]
        public string ArtMediumDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentFavoriteBookArtMedium;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentFavoriteBook == null || !_studentFavoriteBook.Equals(compareTo.StudentFavoriteBook))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor == null
                || !(this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor.Equals(compareTo.ArtMediumDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentFavoriteBook != null)
                    hash = hash * 23 + _studentFavoriteBook.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// This is documentation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="artPieces")]
        public int? ArtPieces { get; set; }
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
            return Entities.Common.Sample.StudentFavoriteBookArtMediumMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentFavoriteBookArtMedium)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentFavoriteBookArtMediumMapper.MapTo(this, (Entities.Common.Sample.IStudentFavoriteBookArtMedium)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentFavoriteBookArtMediumSynchronizationSourceSupport.IsArtPiecesSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentFavoriteBookArtMediumPutPostRequestValidator : FluentValidation.AbstractValidator<StudentFavoriteBookArtMedium>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentFavoriteBookArtMedium> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentPet table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentPet : Entities.Common.Sample.IStudentPet, Entities.Common.Sample.IStudentPetSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentExtension _studentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentExtension Entities.Common.Sample.IStudentPet.StudentExtension
        {
            get { return _studentExtension; }
            set { SetStudentExtension(value); }
        }

        internal Entities.Common.Sample.IStudentExtension StudentExtension
        {
            set { SetStudentExtension(value); }
        }

        private void SetStudentExtension(Entities.Common.Sample.IStudentExtension value)
        {
            _studentExtension = value;
        }

        /// <summary>
        /// The pet's name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="petName"), NaturalKeyMember]
        public string PetName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentPet).PetName == null
                || !(this as Entities.Common.Sample.IStudentPet).PetName.Equals(compareTo.PetName))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentExtension != null)
                    hash = hash * 23 + _studentExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentPet).PetName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentPet).PetName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the pet has been spayed/neutered.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isFixed")]
        public bool? IsFixed { get; set; }
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
            return Entities.Common.Sample.StudentPetMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentPet)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentPetMapper.MapTo(this, (Entities.Common.Sample.IStudentPet)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentPetSynchronizationSourceSupport.IsIsFixedSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentPetPutPostRequestValidator : FluentValidation.AbstractValidator<StudentPet>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentPet> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentPetPreference table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentPetPreference : Entities.Common.Sample.IStudentPetPreference, Entities.Common.Sample.IStudentPetPreferenceSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentExtension _studentExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentExtension Entities.Common.Sample.IStudentPetPreference.StudentExtension
        {
            get { return _studentExtension; }
            set { SetStudentExtension(value); }
        }

        internal Entities.Common.Sample.IStudentExtension StudentExtension
        {
            set { SetStudentExtension(value); }
        }

        private void SetStudentExtension(Entities.Common.Sample.IStudentExtension value)
        {
            _studentExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentPetPreference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentExtension != null)
                    hash = hash * 23 + _studentExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The preferred maximum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="maximumWeight")]
        public int MaximumWeight { get; set; }

        /// <summary>
        /// The preferred minimum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="minimumWeight")]
        public int MinimumWeight { get; set; }
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
            return Entities.Common.Sample.StudentPetPreferenceMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentPetPreference)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentPetPreferenceMapper.MapTo(this, (Entities.Common.Sample.IStudentPetPreference)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentPetPreferenceSynchronizationSourceSupport.IsMaximumWeightSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentPetPreferenceSynchronizationSourceSupport.IsMinimumWeightSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentPetPreferencePutPostRequestValidator : FluentValidation.AbstractValidator<StudentPetPreference>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentPetPreference> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentArtProgramAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentArtProgramAssociation.Sample
{
    /// <summary>
    /// Represents a reference to the StudentArtProgramAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationReference
    {
        [DataMember(Name="beginDate"), NaturalKeyMember]
        public DateTime BeginDate { get; set; }

        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

        [DataMember(Name="programEducationOrganizationId"), NaturalKeyMember]
        public int ProgramEducationOrganizationId { get; set; }

        [DataMember(Name="programName"), NaturalKeyMember]
        public string ProgramName { get; set; }

        [DataMember(Name="programTypeDescriptor"), NaturalKeyMember]
        public string ProgramTypeDescriptor { get; set; }

        [DataMember(Name="studentUniqueId"), NaturalKeyMember]
        public string StudentUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


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
            return BeginDate != default(DateTime) && EducationOrganizationId != default(int) && ProgramEducationOrganizationId != default(int) && ProgramName != default(string) && ProgramTypeDescriptor != default(string) && StudentUniqueId != default(string);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentArtProgramAssociation",
                Href = $"/sample/studentArtProgramAssociations/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociation table of the StudentArtProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociation : Entities.Common.Sample.IStudentArtProgramAssociation, Entities.Common.EdFi.IGeneralStudentProgramAssociation, IHasETag, Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentArtProgramAssociation()
        {
            StudentArtProgramAssociationArtMedia = new List<StudentArtProgramAssociationArtMedium>();
            StudentArtProgramAssociationPortfolioYears = new List<StudentArtProgramAssociationPortfolioYears>();
            StudentArtProgramAssociationServices = new List<StudentArtProgramAssociationService>();
            StudentArtProgramAssociationStyles = new List<StudentArtProgramAssociationStyle>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the StudentArtProgramAssociation resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _educationOrganizationReferenceExplicitlyAssigned;
        private EducationOrganization.EdFi.EducationOrganizationReference _educationOrganizationReference;
        private EducationOrganization.EdFi.EducationOrganizationReference ImplicitEducationOrganizationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_educationOrganizationReference == null && !_educationOrganizationReferenceExplicitlyAssigned)
                    _educationOrganizationReference = new EducationOrganization.EdFi.EducationOrganizationReference();

                return _educationOrganizationReference;
            }
        }

        [DataMember(Name="educationOrganizationReference")][NaturalKeyMember]
        public EducationOrganization.EdFi.EducationOrganizationReference EducationOrganizationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitEducationOrganizationReference != null
                    && (_educationOrganizationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference;

                return null;
            }
            set
            {
                _educationOrganizationReferenceExplicitlyAssigned = true;
                _educationOrganizationReference = value;
            }
        }
        private bool _programReferenceExplicitlyAssigned;
        private Program.EdFi.ProgramReference _programReference;
        private Program.EdFi.ProgramReference ImplicitProgramReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_programReference == null && !_programReferenceExplicitlyAssigned)
                    _programReference = new Program.EdFi.ProgramReference();

                return _programReference;
            }
        }

        [DataMember(Name="programReference")][NaturalKeyMember]
        public Program.EdFi.ProgramReference ProgramReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitProgramReference != null
                    && (_programReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference;

                return null;
            }
            set
            {
                _programReferenceExplicitlyAssigned = true;
                _programReference = value;
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
        /// The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitEducationOrganizationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // EducationOrganization
                _educationOrganizationReferenceExplicitlyAssigned = false;
                ImplicitEducationOrganizationReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The formal name of the Program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramName
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (StudentArtProgramAssociation.ProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramTypeDescriptor
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitProgramReference.ProgramTypeDescriptor = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentUniqueId
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate.Equals(compareTo.BeginDate))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId.Equals(compareTo.ProgramEducationOrganizationId))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName.Equals(compareTo.ProgramName))
                return false;

            // Unified Type Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor == null
                ||!(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName.GetHashCode();

                //Unified Type Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The month, day, and year on which the Student exited the Program or stopped receiving services.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The reason the child left the Program within a school or district.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="reasonExitedDescriptor")]
        public string ReasonExitedDescriptor { get; set; }

        /// <summary>
        /// Indicates whether the Student received services during the summer session or between sessions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="servedOutsideOfRegularSession")]
        public bool? ServedOutsideOfRegularSession { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The total number of art pieces completed by the student during the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="artPieces")]
        public int? ArtPieces { get; set; }

        /// <summary>
        /// Start date for the program's art exhibit to display the student's work.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="exhibitDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ExhibitDate { get; set; }

        /// <summary>
        /// The number of hours a student spends in the program each school day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerDay")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? HoursPerDay { get; set; }

        /// <summary>
        /// A unique identification code used to identify the student's artwork produced in the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="identificationCode")]
        public string IdentificationCode { get; set; }

        /// <summary>
        /// The student's reserved time for use of the kiln.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="kilnReservation")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan? KilnReservation { get; set; }

        /// <summary>
        /// The number of clock minutes dedicated to the student's kiln reservation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="kilnReservationLength")]
        public string KilnReservationLength { get; set; }

        /// <summary>
        /// Percentage of the mediums taught in the program which the student mastered.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="masteredMediums")][Range(typeof(decimal), "-9.9999", "9.9999")]
        public decimal? MasteredMediums { get; set; }

        /// <summary>
        /// Number of days the student is in attendance at the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="numberOfDaysInAttendance")][Range(typeof(decimal), "-99999999999999.9999", "99999999999999.9999")]
        public decimal? NumberOfDaysInAttendance { get; set; }

        /// <summary>
        /// The total number of pieces in the student's portfolio.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="portfolioPieces")]
        public int? PortfolioPieces { get; set; }

        /// <summary>
        /// Indicator that the student participated in art education at a private agency or institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="privateArtProgram")]
        public bool PrivateArtProgram { get; set; }

        /// <summary>
        /// Required program fees to purchase materials for the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="programFees")][Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public decimal? ProgramFees { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //              Inherited One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// participationStatus
        /// </summary>
        [DataMember(Name = "participationStatus")]
        public Api.Common.Models.Resources.GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationParticipationStatus GeneralStudentProgramAssociationParticipationStatus { get; set; }

        Entities.Common.EdFi.IGeneralStudentProgramAssociationParticipationStatus Entities.Common.EdFi.IGeneralStudentProgramAssociation.GeneralStudentProgramAssociationParticipationStatus
        {
            get { return GeneralStudentProgramAssociationParticipationStatus; }
            set { GeneralStudentProgramAssociationParticipationStatus = (Api.Common.Models.Resources.GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationParticipationStatus) value; }
        }

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
        private ICollection<StudentArtProgramAssociationArtMedium> _studentArtProgramAssociationArtMedia;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium> _studentArtProgramAssociationArtMediaCovariant;

        [DataMember(Name="artMedia"), NoDuplicateMembers]
        public ICollection<StudentArtProgramAssociationArtMedium> StudentArtProgramAssociationArtMedia
        {
            get { return _studentArtProgramAssociationArtMedia; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentArtProgramAssociationArtMedium>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationArtMedium)e.Item).StudentArtProgramAssociation = this);
                _studentArtProgramAssociationArtMedia = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium, StudentArtProgramAssociationArtMedium>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationArtMedium)e.Item).StudentArtProgramAssociation = this;
                _studentArtProgramAssociationArtMediaCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationArtMedia
        {
            get { return _studentArtProgramAssociationArtMediaCovariant; }
            set { StudentArtProgramAssociationArtMedia = new List<StudentArtProgramAssociationArtMedium>(value.Cast<StudentArtProgramAssociationArtMedium>()); }
        }

        private ICollection<StudentArtProgramAssociationPortfolioYears> _studentArtProgramAssociationPortfolioYears;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears> _studentArtProgramAssociationPortfolioYearsCovariant;

        [DataMember(Name="portfolioYears"), NoDuplicateMembers]
        public ICollection<StudentArtProgramAssociationPortfolioYears> StudentArtProgramAssociationPortfolioYears
        {
            get { return _studentArtProgramAssociationPortfolioYears; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentArtProgramAssociationPortfolioYears>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears)e.Item).StudentArtProgramAssociation = this);
                _studentArtProgramAssociationPortfolioYears = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, StudentArtProgramAssociationPortfolioYears>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears)e.Item).StudentArtProgramAssociation = this;
                _studentArtProgramAssociationPortfolioYearsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationPortfolioYears
        {
            get { return _studentArtProgramAssociationPortfolioYearsCovariant; }
            set { StudentArtProgramAssociationPortfolioYears = new List<StudentArtProgramAssociationPortfolioYears>(value.Cast<StudentArtProgramAssociationPortfolioYears>()); }
        }

        private ICollection<StudentArtProgramAssociationService> _studentArtProgramAssociationServices;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationService> _studentArtProgramAssociationServicesCovariant;

        [DataMember(Name="services"), NoDuplicateMembers]
        public ICollection<StudentArtProgramAssociationService> StudentArtProgramAssociationServices
        {
            get { return _studentArtProgramAssociationServices; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentArtProgramAssociationService>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationService)e.Item).StudentArtProgramAssociation = this);
                _studentArtProgramAssociationServices = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentArtProgramAssociationService, StudentArtProgramAssociationService>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationService)e.Item).StudentArtProgramAssociation = this;
                _studentArtProgramAssociationServicesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationService> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationServices
        {
            get { return _studentArtProgramAssociationServicesCovariant; }
            set { StudentArtProgramAssociationServices = new List<StudentArtProgramAssociationService>(value.Cast<StudentArtProgramAssociationService>()); }
        }

        private ICollection<StudentArtProgramAssociationStyle> _studentArtProgramAssociationStyles;
        private ICollection<Entities.Common.Sample.IStudentArtProgramAssociationStyle> _studentArtProgramAssociationStylesCovariant;

        [DataMember(Name="styles"), NoDuplicateMembers]
        public ICollection<StudentArtProgramAssociationStyle> StudentArtProgramAssociationStyles
        {
            get { return _studentArtProgramAssociationStyles; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentArtProgramAssociationStyle>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationStyle)e.Item).StudentArtProgramAssociation = this);
                _studentArtProgramAssociationStyles = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentArtProgramAssociationStyle, StudentArtProgramAssociationStyle>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentArtProgramAssociationStyle)e.Item).StudentArtProgramAssociation = this;
                _studentArtProgramAssociationStylesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentArtProgramAssociationStyle> Entities.Common.Sample.IStudentArtProgramAssociation.StudentArtProgramAssociationStyles
        {
            get { return _studentArtProgramAssociationStylesCovariant; }
            set { StudentArtProgramAssociationStyles = new List<StudentArtProgramAssociationStyle>(value.Cast<StudentArtProgramAssociationStyle>()); }
        }

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

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentArtProgramAssociationArtMedia != null) foreach (var item in _studentArtProgramAssociationArtMedia)
            {
                item.StudentArtProgramAssociation = this;
            }

            if (_studentArtProgramAssociationPortfolioYears != null) foreach (var item in _studentArtProgramAssociationPortfolioYears)
            {
                item.StudentArtProgramAssociation = this;
            }

            if (_studentArtProgramAssociationServices != null) foreach (var item in _studentArtProgramAssociationServices)
            {
                item.StudentArtProgramAssociation = this;
            }

            if (_studentArtProgramAssociationStyles != null) foreach (var item in _studentArtProgramAssociationStyles)
            {
                item.StudentArtProgramAssociation = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentArtProgramAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentArtProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentArtProgramAssociationMapper.MapDerivedTo(this, (Entities.Common.Sample.IStudentArtProgramAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsArtPiecesSupported                                            { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsEndDateSupported                                              { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsExhibitDateSupported                                          { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsGeneralStudentProgramAssociationParticipationStatusSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsHoursPerDaySupported                                          { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsIdentificationCodeSupported                                   { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsKilnReservationSupported                                      { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsKilnReservationLengthSupported                                { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsMasteredMediumsSupported                                      { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsNumberOfDaysInAttendanceSupported                             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsPortfolioPiecesSupported                                      { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsPrivateArtProgramSupported                                    { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsProgramFeesSupported                                          { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsReasonExitedDescriptorSupported                               { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsServedOutsideOfRegularSessionSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationArtMediaSupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationPortfolioYearsSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationServicesSupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationStylesSupported                   { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentArtProgramAssociationArtMedium, bool> Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationArtMediumIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, bool> Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationPortfolioYearsIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentArtProgramAssociationService, bool> Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationServiceIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentArtProgramAssociationStyle, bool> Entities.Common.Sample.IStudentArtProgramAssociationSynchronizationSourceSupport.IsStudentArtProgramAssociationStyleIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationResourceId
        {
            get { return null; }
            set { ImplicitEducationOrganizationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitEducationOrganizationReference.Discriminator = value; }
        }


        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramResourceId
        {
            get { return null; }
            set { ImplicitProgramReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitProgramReference.Discriminator = value; }
        }


        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentResourceId
        {
            get { return null; }
            set { ImplicitStudentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentDiscriminator
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
    public class StudentArtProgramAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentArtProgramAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociation> context, FluentValidation.Results.ValidationResult result)
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
            var studentArtProgramAssociationArtMediaValidator = new StudentArtProgramAssociationArtMediumPutPostRequestValidator();

            foreach (var item in instance.StudentArtProgramAssociationArtMedia)
            {
                var validationResult = studentArtProgramAssociationArtMediaValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentArtProgramAssociationPortfolioYearsValidator = new StudentArtProgramAssociationPortfolioYearsPutPostRequestValidator();

            foreach (var item in instance.StudentArtProgramAssociationPortfolioYears)
            {
                var validationResult = studentArtProgramAssociationPortfolioYearsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentArtProgramAssociationServicesValidator = new StudentArtProgramAssociationServicePutPostRequestValidator();

            foreach (var item in instance.StudentArtProgramAssociationServices)
            {
                var validationResult = studentArtProgramAssociationServicesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentArtProgramAssociationStylesValidator = new StudentArtProgramAssociationStylePutPostRequestValidator();

            foreach (var item in instance.StudentArtProgramAssociationStyles)
            {
                var validationResult = studentArtProgramAssociationStylesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationArtMedium table of the StudentArtProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationArtMedium : Entities.Common.Sample.IStudentArtProgramAssociationArtMedium, Entities.Common.Sample.IStudentArtProgramAssociationArtMediumSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentArtProgramAssociation _studentArtProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentArtProgramAssociation Entities.Common.Sample.IStudentArtProgramAssociationArtMedium.StudentArtProgramAssociation
        {
            get { return _studentArtProgramAssociation; }
            set { SetStudentArtProgramAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentArtProgramAssociation StudentArtProgramAssociation
        {
            set { SetStudentArtProgramAssociation(value); }
        }

        private void SetStudentArtProgramAssociation(Entities.Common.Sample.IStudentArtProgramAssociation value)
        {
            _studentArtProgramAssociation = value;
        }

        /// <summary>
        /// The art mediums used in the program (i.e., paint, pencils, clay, etc.).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="artMediumDescriptor"), NaturalKeyMember]
        public string ArtMediumDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor.Equals(compareTo.ArtMediumDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentArtProgramAssociation != null)
                    hash = hash * 23 + _studentArtProgramAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentArtProgramAssociationArtMediumMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationArtMedium)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentArtProgramAssociationArtMediumMapper.MapTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationArtMedium)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationArtMediumPutPostRequestValidator : FluentValidation.AbstractValidator<StudentArtProgramAssociationArtMedium>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociationArtMedium> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationPortfolioYears table of the StudentArtProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationPortfolioYears : Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYearsSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentArtProgramAssociation _studentArtProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentArtProgramAssociation Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears.StudentArtProgramAssociation
        {
            get { return _studentArtProgramAssociation; }
            set { SetStudentArtProgramAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentArtProgramAssociation StudentArtProgramAssociation
        {
            set { SetStudentArtProgramAssociation(value); }
        }

        private void SetStudentArtProgramAssociation(Entities.Common.Sample.IStudentArtProgramAssociation value)
        {
            _studentArtProgramAssociation = value;
        }

        /// <summary>
        /// The of year(s) of work included in the student's portfolio.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="portfolioYears"), NaturalKeyMember]
        public short PortfolioYears { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears.Equals(compareTo.PortfolioYears))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentArtProgramAssociation != null)
                    hash = hash * 23 + _studentArtProgramAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentArtProgramAssociationPortfolioYearsMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentArtProgramAssociationPortfolioYearsMapper.MapTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationPortfolioYearsPutPostRequestValidator : FluentValidation.AbstractValidator<StudentArtProgramAssociationPortfolioYears>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociationPortfolioYears> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationService table of the StudentArtProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationService : Entities.Common.Sample.IStudentArtProgramAssociationService, Entities.Common.Sample.IStudentArtProgramAssociationServiceSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentArtProgramAssociation _studentArtProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentArtProgramAssociation Entities.Common.Sample.IStudentArtProgramAssociationService.StudentArtProgramAssociation
        {
            get { return _studentArtProgramAssociation; }
            set { SetStudentArtProgramAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentArtProgramAssociation StudentArtProgramAssociation
        {
            set { SetStudentArtProgramAssociation(value); }
        }

        private void SetStudentArtProgramAssociation(Entities.Common.Sample.IStudentArtProgramAssociation value)
        {
            _studentArtProgramAssociation = value;
        }

        /// <summary>
        /// Indicates the Service being provided to the student by the Program.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="serviceDescriptor"), NaturalKeyMember]
        public string ServiceDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationService;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor.Equals(compareTo.ServiceDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentArtProgramAssociation != null)
                    hash = hash * 23 + _studentArtProgramAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// True if service is a primary service.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryIndicator")]
        public bool? PrimaryIndicator { get; set; }

        /// <summary>
        /// First date the Student was in this option for the current school year.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="serviceBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ServiceBeginDate { get; set; }

        /// <summary>
        /// Last date the Student was in this option for the current school year.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="serviceEndDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ServiceEndDate { get; set; }
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
            return Entities.Common.Sample.StudentArtProgramAssociationServiceMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationService)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentArtProgramAssociationServiceMapper.MapTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationService)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentArtProgramAssociationServiceSynchronizationSourceSupport.IsPrimaryIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationServiceSynchronizationSourceSupport.IsServiceBeginDateSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentArtProgramAssociationServiceSynchronizationSourceSupport.IsServiceEndDateSupported    { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationServicePutPostRequestValidator : FluentValidation.AbstractValidator<StudentArtProgramAssociationService>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociationService> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentArtProgramAssociationStyle table of the StudentArtProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationStyle : Entities.Common.Sample.IStudentArtProgramAssociationStyle, Entities.Common.Sample.IStudentArtProgramAssociationStyleSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentArtProgramAssociation _studentArtProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentArtProgramAssociation Entities.Common.Sample.IStudentArtProgramAssociationStyle.StudentArtProgramAssociation
        {
            get { return _studentArtProgramAssociation; }
            set { SetStudentArtProgramAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentArtProgramAssociation StudentArtProgramAssociation
        {
            set { SetStudentArtProgramAssociation(value); }
        }

        private void SetStudentArtProgramAssociation(Entities.Common.Sample.IStudentArtProgramAssociation value)
        {
            _studentArtProgramAssociation = value;
        }

        /// <summary>
        /// The art style(s) exhibited by the student in the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="style"), NaturalKeyMember]
        public string Style { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationStyle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style == null
                || !(this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style.Equals(compareTo.Style))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentArtProgramAssociation != null)
                    hash = hash * 23 + _studentArtProgramAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentArtProgramAssociationStyleMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationStyle)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentArtProgramAssociationStyleMapper.MapTo(this, (Entities.Common.Sample.IStudentArtProgramAssociationStyle)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationStylePutPostRequestValidator : FluentValidation.AbstractValidator<StudentArtProgramAssociationStyle>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociationStyle> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentCTEProgramAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentCTEProgramAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentCTEProgramAssociationExtension table of the StudentCTEProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationExtension : Entities.Common.Sample.IStudentCTEProgramAssociationExtension, Entities.Common.Sample.IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentCTEProgramAssociation _studentCTEProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentCTEProgramAssociation Entities.Common.Sample.IStudentCTEProgramAssociationExtension.StudentCTEProgramAssociation
        {
            get { return _studentCTEProgramAssociation; }
            set { SetStudentCTEProgramAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentCTEProgramAssociation StudentCTEProgramAssociation
        {
            set { SetStudentCTEProgramAssociation(value); }
        }

        private void SetStudentCTEProgramAssociation(Entities.Common.EdFi.IStudentCTEProgramAssociation value)
        {
            _studentCTEProgramAssociation = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentCTEProgramAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentCTEProgramAssociation == null || !_studentCTEProgramAssociation.Equals(compareTo.StudentCTEProgramAssociation))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentCTEProgramAssociation != null)
                    hash = hash * 23 + _studentCTEProgramAssociation.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A unique identification code used to identify the student's artwork produced in the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="analysisCompleted")]
        public bool? AnalysisCompleted { get; set; }

        /// <summary>
        /// The date and time the CTEProgram analysis was completed.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="analysisDate")]
        public DateTime? AnalysisDate { get; set; }
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
            return Entities.Common.Sample.StudentCTEProgramAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentCTEProgramAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentCTEProgramAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentCTEProgramAssociationExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport.IsAnalysisCompletedSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentCTEProgramAssociationExtensionSynchronizationSourceSupport.IsAnalysisDateSupported       { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentCTEProgramAssociationExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentCTEProgramAssociationExtension> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentEducationOrganizationAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentEducationOrganizationAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressExtension : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension, Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentEducationOrganizationAssociationAddressExtension()
        {
            StudentEducationOrganizationAssociationAddressSchoolDistricts = new List<StudentEducationOrganizationAssociationAddressSchoolDistrict>();
            StudentEducationOrganizationAssociationAddressTerms = new List<StudentEducationOrganizationAssociationAddressTerm>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentEducationOrganizationAssociationAddress _studentEducationOrganizationAssociationAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentEducationOrganizationAssociationAddress Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddress
        {
            get { return _studentEducationOrganizationAssociationAddress; }
            set { SetStudentEducationOrganizationAssociationAddress(value); }
        }

        internal Entities.Common.EdFi.IStudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress
        {
            set { SetStudentEducationOrganizationAssociationAddress(value); }
        }

        private void SetStudentEducationOrganizationAssociationAddress(Entities.Common.EdFi.IStudentEducationOrganizationAssociationAddress value)
        {
            _studentEducationOrganizationAssociationAddress = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddress == null || !_studentEducationOrganizationAssociationAddress.Equals(compareTo.StudentEducationOrganizationAssociationAddress))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentEducationOrganizationAssociationAddress != null)
                    hash = hash * 23 + _studentEducationOrganizationAssociationAddress.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment or housing complex name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="complex")]
        public string Complex { get; set; }

        /// <summary>
        /// An indicator if the address is on a bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="onBusRoute")]
        public bool OnBusRoute { get; set; }
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
        private ICollection<StudentEducationOrganizationAssociationAddressSchoolDistrict> _studentEducationOrganizationAssociationAddressSchoolDistricts;
        private ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict> _studentEducationOrganizationAssociationAddressSchoolDistrictsCovariant;

        [DataMember(Name="schoolDistricts"), NoDuplicateMembers]
        public ICollection<StudentEducationOrganizationAssociationAddressSchoolDistrict> StudentEducationOrganizationAssociationAddressSchoolDistricts
        {
            get { return _studentEducationOrganizationAssociationAddressSchoolDistricts; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentEducationOrganizationAssociationAddressSchoolDistrict>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict)e.Item).StudentEducationOrganizationAssociationAddressExtension = this);
                _studentEducationOrganizationAssociationAddressSchoolDistricts = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict, StudentEducationOrganizationAssociationAddressSchoolDistrict>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict)e.Item).StudentEducationOrganizationAssociationAddressExtension = this;
                _studentEducationOrganizationAssociationAddressSchoolDistrictsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict> Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddressSchoolDistricts
        {
            get { return _studentEducationOrganizationAssociationAddressSchoolDistrictsCovariant; }
            set { StudentEducationOrganizationAssociationAddressSchoolDistricts = new List<StudentEducationOrganizationAssociationAddressSchoolDistrict>(value.Cast<StudentEducationOrganizationAssociationAddressSchoolDistrict>()); }
        }

        private ICollection<StudentEducationOrganizationAssociationAddressTerm> _studentEducationOrganizationAssociationAddressTerms;
        private ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm> _studentEducationOrganizationAssociationAddressTermsCovariant;

        [DataMember(Name="terms"), NoDuplicateMembers]
        public ICollection<StudentEducationOrganizationAssociationAddressTerm> StudentEducationOrganizationAssociationAddressTerms
        {
            get { return _studentEducationOrganizationAssociationAddressTerms; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentEducationOrganizationAssociationAddressTerm>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm)e.Item).StudentEducationOrganizationAssociationAddressExtension = this);
                _studentEducationOrganizationAssociationAddressTerms = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm, StudentEducationOrganizationAssociationAddressTerm>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm)e.Item).StudentEducationOrganizationAssociationAddressExtension = this;
                _studentEducationOrganizationAssociationAddressTermsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm> Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension.StudentEducationOrganizationAssociationAddressTerms
        {
            get { return _studentEducationOrganizationAssociationAddressTermsCovariant; }
            set { StudentEducationOrganizationAssociationAddressTerms = new List<StudentEducationOrganizationAssociationAddressTerm>(value.Cast<StudentEducationOrganizationAssociationAddressTerm>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentEducationOrganizationAssociationAddressSchoolDistricts != null) foreach (var item in _studentEducationOrganizationAssociationAddressSchoolDistricts)
            {
                item.StudentEducationOrganizationAssociationAddressExtension = this;
            }

            if (_studentEducationOrganizationAssociationAddressTerms != null) foreach (var item in _studentEducationOrganizationAssociationAddressTerms)
            {
                item.StudentEducationOrganizationAssociationAddressExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentEducationOrganizationAssociationAddressExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationAddressExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsComplexSupported                                                        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsOnBusRouteSupported                                                     { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationAddressTermsSupported            { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict, bool> Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm, bool> Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationAddressTermIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationAddressExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationAddressExtension> context, FluentValidation.Results.ValidationResult result)
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
            var studentEducationOrganizationAssociationAddressSchoolDistrictsValidator = new StudentEducationOrganizationAssociationAddressSchoolDistrictPutPostRequestValidator();

            foreach (var item in instance.StudentEducationOrganizationAssociationAddressSchoolDistricts)
            {
                var validationResult = studentEducationOrganizationAssociationAddressSchoolDistrictsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentEducationOrganizationAssociationAddressTermsValidator = new StudentEducationOrganizationAssociationAddressTermPutPostRequestValidator();

            foreach (var item in instance.StudentEducationOrganizationAssociationAddressTerms)
            {
                var validationResult = studentEducationOrganizationAssociationAddressTermsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressSchoolDistrict table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressSchoolDistrict : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict, Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrictSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension _studentEducationOrganizationAssociationAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict.StudentEducationOrganizationAssociationAddressExtension
        {
            get { return _studentEducationOrganizationAssociationAddressExtension; }
            set { SetStudentEducationOrganizationAssociationAddressExtension(value); }
        }

        internal Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension
        {
            set { SetStudentEducationOrganizationAssociationAddressExtension(value); }
        }

        private void SetStudentEducationOrganizationAssociationAddressExtension(Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension value)
        {
            _studentEducationOrganizationAssociationAddressExtension = value;
        }

        /// <summary>
        /// The school district in which the address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolDistrict"), NaturalKeyMember]
        public string SchoolDistrict { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension == null || !_studentEducationOrganizationAssociationAddressExtension.Equals(compareTo.StudentEducationOrganizationAssociationAddressExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict == null
                || !(this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict.Equals(compareTo.SchoolDistrict))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentEducationOrganizationAssociationAddressExtension != null)
                    hash = hash * 23 + _studentEducationOrganizationAssociationAddressExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentEducationOrganizationAssociationAddressSchoolDistrictMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationAddressSchoolDistrictMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressSchoolDistrictPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationAddressSchoolDistrict>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationAddressSchoolDistrict> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationAddressTerm table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressTerm : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm, Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTermSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension _studentEducationOrganizationAssociationAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm.StudentEducationOrganizationAssociationAddressExtension
        {
            get { return _studentEducationOrganizationAssociationAddressExtension; }
            set { SetStudentEducationOrganizationAssociationAddressExtension(value); }
        }

        internal Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension
        {
            set { SetStudentEducationOrganizationAssociationAddressExtension(value); }
        }

        private void SetStudentEducationOrganizationAssociationAddressExtension(Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension value)
        {
            _studentEducationOrganizationAssociationAddressExtension = value;
        }

        /// <summary>
        /// Terms applicable to this address.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="termDescriptor"), NaturalKeyMember]
        public string TermDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension == null || !_studentEducationOrganizationAssociationAddressExtension.Equals(compareTo.StudentEducationOrganizationAssociationAddressExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor == null
                || !(this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor.Equals(compareTo.TermDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentEducationOrganizationAssociationAddressExtension != null)
                    hash = hash * 23 + _studentEducationOrganizationAssociationAddressExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentEducationOrganizationAssociationAddressTermMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationAddressTermMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationAddressTermPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationAddressTerm>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationAddressTerm> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationStudentCharacteristicExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicExtension : Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension, Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentEducationOrganizationAssociationStudentCharacteristicExtension()
        {
            StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds = new List<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic _studentEducationOrganizationAssociationStudentCharacteristic;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension.StudentEducationOrganizationAssociationStudentCharacteristic
        {
            get { return _studentEducationOrganizationAssociationStudentCharacteristic; }
            set { SetStudentEducationOrganizationAssociationStudentCharacteristic(value); }
        }

        internal Entities.Common.EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic
        {
            set { SetStudentEducationOrganizationAssociationStudentCharacteristic(value); }
        }

        private void SetStudentEducationOrganizationAssociationStudentCharacteristic(Entities.Common.EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic value)
        {
            _studentEducationOrganizationAssociationStudentCharacteristic = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristic == null || !_studentEducationOrganizationAssociationStudentCharacteristic.Equals(compareTo.StudentEducationOrganizationAssociationStudentCharacteristic))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentEducationOrganizationAssociationStudentCharacteristic != null)
                    hash = hash * 23 + _studentEducationOrganizationAssociationStudentCharacteristic.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
        private ICollection<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> _studentEducationOrganizationAssociationStudentCharacteristicStudentNeeds;
        private ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> _studentEducationOrganizationAssociationStudentCharacteristicStudentNeedsCovariant;

        [DataMember(Name="studentNeeds"), NoDuplicateMembers]
        public ICollection<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds
        {
            get { return _studentEducationOrganizationAssociationStudentCharacteristicStudentNeeds; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed)e.Item).StudentEducationOrganizationAssociationStudentCharacteristicExtension = this);
                _studentEducationOrganizationAssociationStudentCharacteristicStudentNeeds = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed)e.Item).StudentEducationOrganizationAssociationStudentCharacteristicExtension = this;
                _studentEducationOrganizationAssociationStudentCharacteristicStudentNeedsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds
        {
            get { return _studentEducationOrganizationAssociationStudentCharacteristicStudentNeedsCovariant; }
            set { StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds = new List<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>(value.Cast<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentEducationOrganizationAssociationStudentCharacteristicStudentNeeds != null) foreach (var item in _studentEducationOrganizationAssociationStudentCharacteristicStudentNeeds)
            {
                item.StudentEducationOrganizationAssociationStudentCharacteristicExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, bool> Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtensionSynchronizationSourceSupport.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationStudentCharacteristicExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationStudentCharacteristicExtension> context, FluentValidation.Results.ValidationResult result)
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
            var studentEducationOrganizationAssociationStudentCharacteristicStudentNeedsValidator = new StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedPutPostRequestValidator();

            foreach (var item in instance.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds)
            {
                var validationResult = studentEducationOrganizationAssociationStudentCharacteristicStudentNeedsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed : Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension _studentEducationOrganizationAssociationStudentCharacteristicExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed.StudentEducationOrganizationAssociationStudentCharacteristicExtension
        {
            get { return _studentEducationOrganizationAssociationStudentCharacteristicExtension; }
            set { SetStudentEducationOrganizationAssociationStudentCharacteristicExtension(value); }
        }

        internal Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension StudentEducationOrganizationAssociationStudentCharacteristicExtension
        {
            set { SetStudentEducationOrganizationAssociationStudentCharacteristicExtension(value); }
        }

        private void SetStudentEducationOrganizationAssociationStudentCharacteristicExtension(Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension value)
        {
            _studentEducationOrganizationAssociationStudentCharacteristicExtension = value;
        }

        /// <summary>
        /// The month, day, and year for the start of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristicExtension == null || !_studentEducationOrganizationAssociationStudentCharacteristicExtension.Equals(compareTo.StudentEducationOrganizationAssociationStudentCharacteristicExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate == null
                || !(this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate.Equals(compareTo.BeginDate))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentEducationOrganizationAssociationStudentCharacteristicExtension != null)
                    hash = hash * 23 + _studentEducationOrganizationAssociationStudentCharacteristicExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The month, day, and year for the end of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Indicates the parent characteristic is a primary student need.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryStudentNeedIndicator")]
        public bool? PrimaryStudentNeedIndicator { get; set; }
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
            return Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport.IsEndDateSupported                      { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedSynchronizationSourceSupport.IsPrimaryStudentNeedIndicatorSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentGraduationPlanAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentGraduationPlanAssociation.Sample
{
    /// <summary>
    /// Represents a reference to the StudentGraduationPlanAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

        [DataMember(Name="graduationPlanTypeDescriptor"), NaturalKeyMember]
        public string GraduationPlanTypeDescriptor { get; set; }

        [DataMember(Name="graduationSchoolYear"), NaturalKeyMember]
        public short GraduationSchoolYear { get; set; }

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
            return EducationOrganizationId != default(int) && GraduationPlanTypeDescriptor != default(string) && GraduationSchoolYear != default(short) && StudentUniqueId != default(string);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentGraduationPlanAssociation",
                Href = $"/sample/studentGraduationPlanAssociations/{ResourceId:n}"
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
    /// A class which represents the sample.StudentGraduationPlanAssociation table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociation : Entities.Common.Sample.IStudentGraduationPlanAssociation, IHasETag, Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentGraduationPlanAssociation()
        {
            StudentGraduationPlanAssociationAcademicSubjects = new List<StudentGraduationPlanAssociationAcademicSubject>();
            StudentGraduationPlanAssociationCareerPathwayCodes = new List<StudentGraduationPlanAssociationCareerPathwayCode>();
            StudentGraduationPlanAssociationDescriptions = new List<StudentGraduationPlanAssociationDescription>();
            StudentGraduationPlanAssociationDesignatedBies = new List<StudentGraduationPlanAssociationDesignatedBy>();
            StudentGraduationPlanAssociationIndustryCredentials = new List<StudentGraduationPlanAssociationIndustryCredential>();
            StudentGraduationPlanAssociationStudentParentAssociations = new List<StudentGraduationPlanAssociationStudentParentAssociation>();
            StudentGraduationPlanAssociationYearsAttendeds = new List<StudentGraduationPlanAssociationYearsAttended>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the StudentGraduationPlanAssociation resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _graduationPlanReferenceExplicitlyAssigned;
        private GraduationPlan.EdFi.GraduationPlanReference _graduationPlanReference;
        private GraduationPlan.EdFi.GraduationPlanReference ImplicitGraduationPlanReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_graduationPlanReference == null && !_graduationPlanReferenceExplicitlyAssigned)
                    _graduationPlanReference = new GraduationPlan.EdFi.GraduationPlanReference();

                return _graduationPlanReference;
            }
        }

        [DataMember(Name="graduationPlanReference")][NaturalKeyMember]
        public GraduationPlan.EdFi.GraduationPlanReference GraduationPlanReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitGraduationPlanReference != null
                    && (_graduationPlanReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitGraduationPlanReference.IsReferenceFullyDefined()))
                    return ImplicitGraduationPlanReference;

                return null;
            }
            set
            {
                _graduationPlanReferenceExplicitlyAssigned = true;
                _graduationPlanReference = value;
            }
        }
        private bool _staffReferenceExplicitlyAssigned;
        private Staff.EdFi.StaffReference _staffReference;
        private Staff.EdFi.StaffReference ImplicitStaffReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_staffReference == null && !_staffReferenceExplicitlyAssigned)
                    _staffReference = new Staff.EdFi.StaffReference();

                return _staffReference;
            }
        }

        [DataMember(Name="staffReference")]
        public Staff.EdFi.StaffReference StaffReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStaffReference != null
                    && (_staffReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStaffReference.IsReferenceFullyDefined()))
                    return ImplicitStaffReference;

                return null;
            }
            set
            {
                _staffReferenceExplicitlyAssigned = true;
                _staffReference = value;
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
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.Sample.IStudentGraduationPlanAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitGraduationPlanReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitGraduationPlanReference.IsReferenceFullyDefined()))
                    return ImplicitGraduationPlanReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // GraduationPlan
                _graduationPlanReferenceExplicitlyAssigned = false;
                ImplicitGraduationPlanReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The type of academic plan the student is following for graduation: for example, Minimum, Recommended, Distinguished, or Standard.
        /// </summary>

        // IS in a reference (StudentGraduationPlanAssociation.GraduationPlanTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationPlanTypeDescriptor
        {
            get
            {
                if (ImplicitGraduationPlanReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitGraduationPlanReference.IsReferenceFullyDefined()))
                    return ImplicitGraduationPlanReference.GraduationPlanTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitGraduationPlanReference.GraduationPlanTypeDescriptor = value;
            }
        }

        /// <summary>
        /// The school year the student is expected to graduate.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        short Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationSchoolYear
        {
            get
            {
                if (ImplicitGraduationPlanReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitGraduationPlanReference.IsReferenceFullyDefined()))
                    return ImplicitGraduationPlanReference.GraduationSchoolYear;

                return default(short);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // GraduationPlan
                _graduationPlanReferenceExplicitlyAssigned = false;
                ImplicitGraduationPlanReference.GraduationSchoolYear = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentUniqueId
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;

            // Unified Type Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor == null
                ||!(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor.Equals(compareTo.GraduationPlanTypeDescriptor))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear.Equals(compareTo.GraduationSchoolYear))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId.GetHashCode();

                //Unified Type Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The time of day for the commencement ceremony.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="commencementTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan? CommencementTime { get; set; }

        /// <summary>
        /// The date the plan went into effect.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Any fees the student must resolve prior to graduation, such as library fines and overdue lunch accounts.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="graduationFee")][Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public decimal? GraduationFee { get; set; }

        /// <summary>
        /// The number of years remaining prior to graduation as of when the plan became effective.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="highSchoolDuration")]
        public string HighSchoolDuration { get; set; }

        /// <summary>
        /// The number of hours per week the student will attend to graduate.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal HoursPerWeek { get; set; }

        /// <summary>
        /// An indication as to whether the plan is active.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isActivePlan")]
        public bool? IsActivePlan { get; set; }

        /// <summary>
        /// The percentage of time the student must attend to graduate, relative to a full-time student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="requiredAttendance")][Range(typeof(decimal), "-9.9999", "9.9999")]
        public decimal? RequiredAttendance { get; set; }

        /// <summary>
        /// A unique alphanumeric code assigned to a staff.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StaffUniqueId
        {
            get
            {
                if (ImplicitStaffReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffReference.StaffUniqueId;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Staff
                _staffReferenceExplicitlyAssigned = false;
                ImplicitStaffReference.StaffUniqueId = value;
            }
        }

        /// <summary>
        /// The GPA the student is working toward.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="targetGPA")][Range(typeof(decimal), "-99999999999999.9999", "99999999999999.9999")]
        public decimal TargetGPA { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public StudentGraduationPlanAssociationCTEProgram StudentGraduationPlanAssociationCTEProgram { get; set; }

        Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationCTEProgram
        {
            get { return StudentGraduationPlanAssociationCTEProgram; }
            set { StudentGraduationPlanAssociationCTEProgram = (StudentGraduationPlanAssociationCTEProgram) value; }
        }

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
        private ICollection<StudentGraduationPlanAssociationAcademicSubject> _studentGraduationPlanAssociationAcademicSubjects;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject> _studentGraduationPlanAssociationAcademicSubjectsCovariant;

        [DataMember(Name="academicSubjects"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationAcademicSubject> StudentGraduationPlanAssociationAcademicSubjects
        {
            get { return _studentGraduationPlanAssociationAcademicSubjects; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationAcademicSubject>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationAcademicSubjects = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject, StudentGraduationPlanAssociationAcademicSubject>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationAcademicSubjectsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationAcademicSubjects
        {
            get { return _studentGraduationPlanAssociationAcademicSubjectsCovariant; }
            set { StudentGraduationPlanAssociationAcademicSubjects = new List<StudentGraduationPlanAssociationAcademicSubject>(value.Cast<StudentGraduationPlanAssociationAcademicSubject>()); }
        }

        private ICollection<StudentGraduationPlanAssociationCareerPathwayCode> _studentGraduationPlanAssociationCareerPathwayCodes;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode> _studentGraduationPlanAssociationCareerPathwayCodesCovariant;

        [DataMember(Name="careerPathwayCodes"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationCareerPathwayCode> StudentGraduationPlanAssociationCareerPathwayCodes
        {
            get { return _studentGraduationPlanAssociationCareerPathwayCodes; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationCareerPathwayCode>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationCareerPathwayCodes = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, StudentGraduationPlanAssociationCareerPathwayCode>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationCareerPathwayCodesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationCareerPathwayCodes
        {
            get { return _studentGraduationPlanAssociationCareerPathwayCodesCovariant; }
            set { StudentGraduationPlanAssociationCareerPathwayCodes = new List<StudentGraduationPlanAssociationCareerPathwayCode>(value.Cast<StudentGraduationPlanAssociationCareerPathwayCode>()); }
        }

        private ICollection<StudentGraduationPlanAssociationDescription> _studentGraduationPlanAssociationDescriptions;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription> _studentGraduationPlanAssociationDescriptionsCovariant;

        [DataMember(Name="descriptions"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationDescription> StudentGraduationPlanAssociationDescriptions
        {
            get { return _studentGraduationPlanAssociationDescriptions; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationDescription>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationDescription)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationDescriptions = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription, StudentGraduationPlanAssociationDescription>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationDescription)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationDescriptionsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationDescriptions
        {
            get { return _studentGraduationPlanAssociationDescriptionsCovariant; }
            set { StudentGraduationPlanAssociationDescriptions = new List<StudentGraduationPlanAssociationDescription>(value.Cast<StudentGraduationPlanAssociationDescription>()); }
        }

        private ICollection<StudentGraduationPlanAssociationDesignatedBy> _studentGraduationPlanAssociationDesignatedBies;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy> _studentGraduationPlanAssociationDesignatedBiesCovariant;

        [DataMember(Name="designatedBies"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationDesignatedBy> StudentGraduationPlanAssociationDesignatedBies
        {
            get { return _studentGraduationPlanAssociationDesignatedBies; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationDesignatedBy>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationDesignatedBies = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy, StudentGraduationPlanAssociationDesignatedBy>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationDesignatedBiesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationDesignatedBies
        {
            get { return _studentGraduationPlanAssociationDesignatedBiesCovariant; }
            set { StudentGraduationPlanAssociationDesignatedBies = new List<StudentGraduationPlanAssociationDesignatedBy>(value.Cast<StudentGraduationPlanAssociationDesignatedBy>()); }
        }

        private ICollection<StudentGraduationPlanAssociationIndustryCredential> _studentGraduationPlanAssociationIndustryCredentials;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential> _studentGraduationPlanAssociationIndustryCredentialsCovariant;

        [DataMember(Name="industryCredentials"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationIndustryCredential> StudentGraduationPlanAssociationIndustryCredentials
        {
            get { return _studentGraduationPlanAssociationIndustryCredentials; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationIndustryCredential>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationIndustryCredentials = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential, StudentGraduationPlanAssociationIndustryCredential>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationIndustryCredentialsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationIndustryCredentials
        {
            get { return _studentGraduationPlanAssociationIndustryCredentialsCovariant; }
            set { StudentGraduationPlanAssociationIndustryCredentials = new List<StudentGraduationPlanAssociationIndustryCredential>(value.Cast<StudentGraduationPlanAssociationIndustryCredential>()); }
        }

        private ICollection<StudentGraduationPlanAssociationStudentParentAssociation> _studentGraduationPlanAssociationStudentParentAssociations;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation> _studentGraduationPlanAssociationStudentParentAssociationsCovariant;

        [DataMember(Name="studentParentAssociations"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationStudentParentAssociation> StudentGraduationPlanAssociationStudentParentAssociations
        {
            get { return _studentGraduationPlanAssociationStudentParentAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationStudentParentAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationStudentParentAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation, StudentGraduationPlanAssociationStudentParentAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationStudentParentAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationStudentParentAssociations
        {
            get { return _studentGraduationPlanAssociationStudentParentAssociationsCovariant; }
            set { StudentGraduationPlanAssociationStudentParentAssociations = new List<StudentGraduationPlanAssociationStudentParentAssociation>(value.Cast<StudentGraduationPlanAssociationStudentParentAssociation>()); }
        }

        private ICollection<StudentGraduationPlanAssociationYearsAttended> _studentGraduationPlanAssociationYearsAttendeds;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended> _studentGraduationPlanAssociationYearsAttendedsCovariant;

        [DataMember(Name="yearsAttendeds"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationYearsAttended> StudentGraduationPlanAssociationYearsAttendeds
        {
            get { return _studentGraduationPlanAssociationYearsAttendeds; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationYearsAttended>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationYearsAttendeds = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, StudentGraduationPlanAssociationYearsAttended>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationYearsAttendedsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationYearsAttendeds
        {
            get { return _studentGraduationPlanAssociationYearsAttendedsCovariant; }
            set { StudentGraduationPlanAssociationYearsAttendeds = new List<StudentGraduationPlanAssociationYearsAttended>(value.Cast<StudentGraduationPlanAssociationYearsAttended>()); }
        }

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

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentGraduationPlanAssociationAcademicSubjects != null) foreach (var item in _studentGraduationPlanAssociationAcademicSubjects)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationCareerPathwayCodes != null) foreach (var item in _studentGraduationPlanAssociationCareerPathwayCodes)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationDescriptions != null) foreach (var item in _studentGraduationPlanAssociationDescriptions)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationDesignatedBies != null) foreach (var item in _studentGraduationPlanAssociationDesignatedBies)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationIndustryCredentials != null) foreach (var item in _studentGraduationPlanAssociationIndustryCredentials)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationStudentParentAssociations != null) foreach (var item in _studentGraduationPlanAssociationStudentParentAssociations)
            {
                item.StudentGraduationPlanAssociation = this;
            }

            if (_studentGraduationPlanAssociationYearsAttendeds != null) foreach (var item in _studentGraduationPlanAssociationYearsAttendeds)
            {
                item.StudentGraduationPlanAssociation = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentGraduationPlanAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsCommencementTimeSupported                                           { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsEffectiveDateSupported                                              { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsGraduationFeeSupported                                              { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsHighSchoolDurationSupported                                         { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsHoursPerWeekSupported                                               { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsIsActivePlanSupported                                               { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsRequiredAttendanceSupported                                         { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStaffUniqueIdSupported                                              { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationAcademicSubjectsSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationCareerPathwayCodesSupported         { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationCTEProgramSupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationDescriptionsSupported               { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationDesignatedBiesSupported             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationIndustryCredentialsSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationStudentParentAssociationsSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationYearsAttendedsSupported             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsTargetGPASupported                                                  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationAcademicSubjectIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationDescription, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationDescriptionIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationDesignatedByIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationIndustryCredentialIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationStudentParentAssociationIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, bool> Entities.Common.Sample.IStudentGraduationPlanAssociationSynchronizationSourceSupport.IsStudentGraduationPlanAssociationYearsAttendedIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationPlanResourceId
        {
            get { return null; }
            set { ImplicitGraduationPlanReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentGraduationPlanAssociation.GraduationPlanDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitGraduationPlanReference.Discriminator = value; }
        }


        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.StaffResourceId
        {
            get { return null; }
            set { ImplicitStaffReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StaffDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStaffReference.Discriminator = value; }
        }


        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentResourceId
        {
            get { return null; }
            set { ImplicitStudentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentDiscriminator
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
    public class StudentGraduationPlanAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociation> context, FluentValidation.Results.ValidationResult result)
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
            var studentGraduationPlanAssociationAcademicSubjectsValidator = new StudentGraduationPlanAssociationAcademicSubjectPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationAcademicSubjects)
            {
                var validationResult = studentGraduationPlanAssociationAcademicSubjectsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationCareerPathwayCodesValidator = new StudentGraduationPlanAssociationCareerPathwayCodePutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationCareerPathwayCodes)
            {
                var validationResult = studentGraduationPlanAssociationCareerPathwayCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationDescriptionsValidator = new StudentGraduationPlanAssociationDescriptionPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationDescriptions)
            {
                var validationResult = studentGraduationPlanAssociationDescriptionsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationDesignatedBiesValidator = new StudentGraduationPlanAssociationDesignatedByPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationDesignatedBies)
            {
                var validationResult = studentGraduationPlanAssociationDesignatedBiesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationIndustryCredentialsValidator = new StudentGraduationPlanAssociationIndustryCredentialPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationIndustryCredentials)
            {
                var validationResult = studentGraduationPlanAssociationIndustryCredentialsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationStudentParentAssociationsValidator = new StudentGraduationPlanAssociationStudentParentAssociationPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationStudentParentAssociations)
            {
                var validationResult = studentGraduationPlanAssociationStudentParentAssociationsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentGraduationPlanAssociationYearsAttendedsValidator = new StudentGraduationPlanAssociationYearsAttendedPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationYearsAttendeds)
            {
                var validationResult = studentGraduationPlanAssociationYearsAttendedsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationAcademicSubject table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationAcademicSubject : Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject, Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubjectSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// The student's favorite academic subjects.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="academicSubjectDescriptor"), NaturalKeyMember]
        public string AcademicSubjectDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor.Equals(compareTo.AcademicSubjectDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationAcademicSubjectMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationAcademicSubjectMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationAcademicSubjectPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationAcademicSubject>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationAcademicSubject> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationCareerPathwayCode table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCareerPathwayCode : Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCodeSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// The code representing the student's intended career pathway after graduation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="careerPathwayCode"), NaturalKeyMember]
        public int CareerPathwayCode { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode.Equals(compareTo.CareerPathwayCode))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationCareerPathwayCodeMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationCareerPathwayCodeMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCareerPathwayCodePutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationCareerPathwayCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationCareerPathwayCode> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationCTEProgram table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCTEProgram : Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram, Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationCTEProgramMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationCTEProgram> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationDescription table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDescription : Entities.Common.Sample.IStudentGraduationPlanAssociationDescription, Entities.Common.Sample.IStudentGraduationPlanAssociationDescriptionSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationDescription.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// A description of the graduation plan.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="description"), NaturalKeyMember]
        public string Description { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description.Equals(compareTo.Description))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationDescriptionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationDescription)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationDescriptionMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationDescription)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDescriptionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationDescription>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationDescription> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationDesignatedBy table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDesignatedBy : Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy, Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBySynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// The entity governing this graduation plan.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="designatedBy"), NaturalKeyMember]
        public string DesignatedBy { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy.Equals(compareTo.DesignatedBy))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationDesignatedByMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationDesignatedByMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDesignatedByPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationDesignatedBy>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationDesignatedBy> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationIndustryCredential table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationIndustryCredential : Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential, Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredentialSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// Industry-recognized credentials the student will have earned at graduation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="industryCredential"), NaturalKeyMember]
        public string IndustryCredential { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential.Equals(compareTo.IndustryCredential))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationIndustryCredentialMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationIndustryCredentialMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationIndustryCredentialPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationIndustryCredential>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationIndustryCredential> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// Represents a reference from the StudentGraduationPlanAssociationStudentParentAssociation entity to the StudentParentAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference
    {
        private Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation backReference;

        // Parameterless constructor for deserialization
        public StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference() { }

        // Constructor for inline initialization in parent
        public StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference(Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation backReference)
        {
            this.backReference = backReference;
        }

        // Expose back reference internally for access after JSON deserialization to enable link generation
        internal Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation BackReference
        {
            get { return backReference; }
            set { backReference = value; }
        }

        private string _studentUniqueId;

        [DataMember(Name="studentUniqueId"), NaturalKeyMember]
        public string StudentUniqueId
        {
            get => _studentUniqueId == default(string)
                    ? BackReference.StudentGraduationPlanAssociation.StudentUniqueId
                    : _studentUniqueId;
            set => _studentUniqueId = value;
        }

        [DataMember(Name="parentUniqueId"), NaturalKeyMember]
        public string ParentUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the referenced resource's identifier (i.e. "id" property).
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when a resource has been derived; otherwise <b>null</b>.
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
                    // Can't generate a link without the back reference
                    if (backReference == null)
                        return null;

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
            return ParentUniqueId != default(string)
                ;
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentParentAssociation",
                Href = $"/ed-fi/studentParentAssociations/{ResourceId:n}"
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
    }

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationStudentParentAssociation table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentParentAssociation : Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation, Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociationSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _studentParentAssociationReferenceExplicitlyAssigned;
        private StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference _studentParentAssociationReference;
        private StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference ImplicitStudentParentAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentParentAssociationReference == null && !_studentParentAssociationReferenceExplicitlyAssigned)
                    _studentParentAssociationReference = new StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference(this);

                return _studentParentAssociationReference;
            }
        }

        [DataMember(Name="studentParentAssociationReference")][NaturalKeyMember]
        public StudentGraduationPlanAssociationStudentParentAssociationToStudentParentAssociationReference StudentParentAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentParentAssociationReference != null
                    && (_studentParentAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentParentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentParentAssociationReference;

                return null;
            }
            set
            {
                _studentParentAssociationReferenceExplicitlyAssigned = true;
                _studentParentAssociationReference = value;
                _studentParentAssociationReference.BackReference = this;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;

            // Initialize unified key values from parent context when reference is being formed by outbound mapper
            if (!_studentParentAssociationReferenceExplicitlyAssigned)
            {
                ImplicitStudentParentAssociationReference.StudentUniqueId = _studentGraduationPlanAssociation.StudentUniqueId;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a parent.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.ParentUniqueId
        {
            get
            {
                if (ImplicitStudentParentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentParentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentParentAssociationReference.ParentUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentParentAssociation
                _studentParentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentParentAssociationReference.ParentUniqueId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation).ParentUniqueId == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation).ParentUniqueId.Equals(compareTo.ParentUniqueId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation).ParentUniqueId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation).ParentUniqueId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentParentAssociationReference != null)
                _studentParentAssociationReference.BackReference = this;
        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentGraduationPlanAssociationStudentParentAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationStudentParentAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.StudentParentAssociationResourceId
        {
            get { return null; }
            set { ImplicitStudentParentAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation.StudentParentAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentParentAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentParentAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationStudentParentAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationStudentParentAssociation> context, FluentValidation.Results.ValidationResult result)
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
            var sourcesForStudentUniqueId = GetStudentUniqueIdSources();

            if (!sourcesForStudentUniqueId.Select(t => t.Item2).Where(v => !v.IsDefaultValue()).AllEqual())
            {
                failures.Add(new ValidationFailure("StudentUniqueId",
                    $"Supplied values for unified key property 'studentUniqueId' on 'StudentGraduationPlanAssociationStudentParentAssociation' are not consistent: {string.Join(", ", sourcesForStudentUniqueId.Select(x => $"{x.Item1} = {x.Item2}"))}"));
            }

            IEnumerable<Tuple<string, string>> GetStudentUniqueIdSources()
            {
                // Obtain value from the parent
                yield return Tuple.Create("studentUniqueId (from parent context)", (instance as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentParentAssociation).StudentGraduationPlanAssociation.StudentUniqueId);

                // Obtain value from other references
                var valueFromStudentParentAssociationReference = instance.StudentParentAssociationReference?.StudentUniqueId;

                if (valueFromStudentParentAssociationReference != null)
                {
                    yield return Tuple.Create("studentParentAssociationReference.studentUniqueId", instance.StudentParentAssociationReference.StudentUniqueId);
                }

            }

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

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationYearsAttended table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationYearsAttended : Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttendedSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended.StudentGraduationPlanAssociation
        {
            get { return _studentGraduationPlanAssociation; }
            set { SetStudentGraduationPlanAssociation(value); }
        }

        internal Entities.Common.Sample.IStudentGraduationPlanAssociation StudentGraduationPlanAssociation
        {
            set { SetStudentGraduationPlanAssociation(value); }
        }

        private void SetStudentGraduationPlanAssociation(Entities.Common.Sample.IStudentGraduationPlanAssociation value)
        {
            _studentGraduationPlanAssociation = value;
        }

        /// <summary>
        /// The number of years the student will have attended high school by the time of graduation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="yearsAttended"), NaturalKeyMember]
        public short YearsAttended { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended == null
                || !(this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended.Equals(compareTo.YearsAttended))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentGraduationPlanAssociation != null)
                    hash = hash * 23 + _studentGraduationPlanAssociation.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentGraduationPlanAssociationYearsAttendedMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationYearsAttendedMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationYearsAttendedPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationYearsAttended>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationYearsAttended> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentParentAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentParentAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentParentAssociationDiscipline table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationDiscipline : Entities.Common.Sample.IStudentParentAssociationDiscipline, Entities.Common.Sample.IStudentParentAssociationDisciplineSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationDiscipline.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
        }

        /// <summary>
        /// The type of action used to discipline the student preferred by the parent.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="disciplineDescriptor"), NaturalKeyMember]
        public string DisciplineDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationDiscipline;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationDiscipline).DisciplineDescriptor == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationDiscipline).DisciplineDescriptor.Equals(compareTo.DisciplineDescriptor))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationDiscipline).DisciplineDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationDiscipline).DisciplineDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentParentAssociationDisciplineMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationDiscipline)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationDisciplineMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationDiscipline)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationDisciplinePutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationDiscipline>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationDiscipline> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationExtension table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationExtension : Entities.Common.Sample.IStudentParentAssociationExtension, Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentParentAssociationExtension()
        {
            StudentParentAssociationDisciplines = new List<StudentParentAssociationDiscipline>();
            StudentParentAssociationFavoriteBookTitles = new List<StudentParentAssociationFavoriteBookTitle>();
            StudentParentAssociationHoursPerWeeks = new List<StudentParentAssociationHoursPerWeek>();
            StudentParentAssociationPagesReads = new List<StudentParentAssociationPagesRead>();
            StudentParentAssociationStaffEducationOrganizationEmploymentAssociations = new List<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _interventionStudyReferenceExplicitlyAssigned;
        private InterventionStudy.EdFi.InterventionStudyReference _interventionStudyReference;
        private InterventionStudy.EdFi.InterventionStudyReference ImplicitInterventionStudyReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_interventionStudyReference == null && !_interventionStudyReferenceExplicitlyAssigned)
                    _interventionStudyReference = new InterventionStudy.EdFi.InterventionStudyReference();

                return _interventionStudyReference;
            }
        }

        [DataMember(Name="interventionStudyReference")]
        public InterventionStudy.EdFi.InterventionStudyReference InterventionStudyReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitInterventionStudyReference != null
                    && (_interventionStudyReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitInterventionStudyReference.IsReferenceFullyDefined()))
                    return ImplicitInterventionStudyReference;

                return null;
            }
            set
            {
                _interventionStudyReferenceExplicitlyAssigned = true;
                _interventionStudyReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentParentAssociation _studentParentAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentParentAssociation Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociation
        {
            get { return _studentParentAssociation; }
            set { SetStudentParentAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentParentAssociation StudentParentAssociation
        {
            set { SetStudentParentAssociation(value); }
        }

        private void SetStudentParentAssociation(Entities.Common.EdFi.IStudentParentAssociation value)
        {
            _studentParentAssociation = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociation == null || !_studentParentAssociation.Equals(compareTo.StudentParentAssociation))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociation != null)
                    hash = hash * 23 + _studentParentAssociation.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the parent regularly reads to the student before bed.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bedtimeReader")]
        public bool BedtimeReader { get; set; }

        /// <summary>
        /// The average number of pages the parent reads with the student each day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bedtimeReadingRate")][Range(typeof(decimal), "-9.9999", "9.9999")]
        public decimal? BedtimeReadingRate { get; set; }

        /// <summary>
        /// The parent's estimated monthly budget dedicated to books for the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bookBudget")][Range(typeof(decimal), "-922337203685477.5808", "922337203685477.5807")]
        public decimal? BookBudget { get; set; }

        /// <summary>
        /// The total number of books the parent has borrowed on behalf of the student to date.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="booksBorrowed")]
        public int? BooksBorrowed { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.Sample.IStudentParentAssociationExtension.EducationOrganizationId
        {
            get
            {
                if (ImplicitInterventionStudyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitInterventionStudyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitInterventionStudyReference.EducationOrganizationId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // InterventionStudy
                _interventionStudyReferenceExplicitlyAssigned = false;
                ImplicitInterventionStudyReference.EducationOrganizationId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A unique number or alphanumeric code assigned to an intervention study.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentParentAssociationExtension.InterventionStudyIdentificationCode
        {
            get
            {
                if (ImplicitInterventionStudyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitInterventionStudyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitInterventionStudyReference.InterventionStudyIdentificationCode;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // InterventionStudy
                _interventionStudyReferenceExplicitlyAssigned = false;
                ImplicitInterventionStudyReference.InterventionStudyIdentificationCode = value;
            }
        }

        /// <summary>
        /// The actual or estimated number of clock minutes for a given library visit.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="libraryDuration")]
        public int? LibraryDuration { get; set; }

        /// <summary>
        /// The student's regularly scheduled library time during the school day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="libraryTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan? LibraryTime { get; set; }

        /// <summary>
        /// Total number of visits a student is allowed to the library in a single school day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="libraryVisits")]
        public short? LibraryVisits { get; set; }

        /// <summary>
        /// Previous restrictions for student and/or teacher contact with the individual (e.g., the student may not be picked up by the individual).
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="priorContactRestrictions")]
        public string PriorContactRestrictions { get; set; }

        /// <summary>
        /// Date on which the parent first read the student Green Eggs and Ham by Dr. Seuss.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="readGreenEggsAndHamDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ReadGreenEggsAndHamDate { get; set; }

        /// <summary>
        /// The amount of time the parent spends reading to the student each day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="readingTimeSpent")]
        public string ReadingTimeSpent { get; set; }

        /// <summary>
        /// The year in which the student's reading habits are being recorded.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="studentRead")]
        public short? StudentRead { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// telephone
        /// </summary>
        [DataMember(Name = "telephone")]
        public StudentParentAssociationTelephone StudentParentAssociationTelephone { get; set; }

        Entities.Common.Sample.IStudentParentAssociationTelephone Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationTelephone
        {
            get { return StudentParentAssociationTelephone; }
            set { StudentParentAssociationTelephone = (StudentParentAssociationTelephone) value; }
        }

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
        private ICollection<StudentParentAssociationDiscipline> _studentParentAssociationDisciplines;
        private ICollection<Entities.Common.Sample.IStudentParentAssociationDiscipline> _studentParentAssociationDisciplinesCovariant;

        [DataMember(Name="disciplines"), NoDuplicateMembers]
        public ICollection<StudentParentAssociationDiscipline> StudentParentAssociationDisciplines
        {
            get { return _studentParentAssociationDisciplines; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentParentAssociationDiscipline>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentParentAssociationDiscipline)e.Item).StudentParentAssociationExtension = this);
                _studentParentAssociationDisciplines = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentParentAssociationDiscipline, StudentParentAssociationDiscipline>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentParentAssociationDiscipline)e.Item).StudentParentAssociationExtension = this;
                _studentParentAssociationDisciplinesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentParentAssociationDiscipline> Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationDisciplines
        {
            get { return _studentParentAssociationDisciplinesCovariant; }
            set { StudentParentAssociationDisciplines = new List<StudentParentAssociationDiscipline>(value.Cast<StudentParentAssociationDiscipline>()); }
        }

        private ICollection<StudentParentAssociationFavoriteBookTitle> _studentParentAssociationFavoriteBookTitles;
        private ICollection<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle> _studentParentAssociationFavoriteBookTitlesCovariant;

        [DataMember(Name="favoriteBookTitles"), NoDuplicateMembers]
        public ICollection<StudentParentAssociationFavoriteBookTitle> StudentParentAssociationFavoriteBookTitles
        {
            get { return _studentParentAssociationFavoriteBookTitles; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentParentAssociationFavoriteBookTitle>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle)e.Item).StudentParentAssociationExtension = this);
                _studentParentAssociationFavoriteBookTitles = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle, StudentParentAssociationFavoriteBookTitle>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle)e.Item).StudentParentAssociationExtension = this;
                _studentParentAssociationFavoriteBookTitlesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle> Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationFavoriteBookTitles
        {
            get { return _studentParentAssociationFavoriteBookTitlesCovariant; }
            set { StudentParentAssociationFavoriteBookTitles = new List<StudentParentAssociationFavoriteBookTitle>(value.Cast<StudentParentAssociationFavoriteBookTitle>()); }
        }

        private ICollection<StudentParentAssociationHoursPerWeek> _studentParentAssociationHoursPerWeeks;
        private ICollection<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek> _studentParentAssociationHoursPerWeeksCovariant;

        [DataMember(Name="hoursPerWeeks"), NoDuplicateMembers]
        public ICollection<StudentParentAssociationHoursPerWeek> StudentParentAssociationHoursPerWeeks
        {
            get { return _studentParentAssociationHoursPerWeeks; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentParentAssociationHoursPerWeek>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentParentAssociationHoursPerWeek)e.Item).StudentParentAssociationExtension = this);
                _studentParentAssociationHoursPerWeeks = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek, StudentParentAssociationHoursPerWeek>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentParentAssociationHoursPerWeek)e.Item).StudentParentAssociationExtension = this;
                _studentParentAssociationHoursPerWeeksCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek> Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationHoursPerWeeks
        {
            get { return _studentParentAssociationHoursPerWeeksCovariant; }
            set { StudentParentAssociationHoursPerWeeks = new List<StudentParentAssociationHoursPerWeek>(value.Cast<StudentParentAssociationHoursPerWeek>()); }
        }

        private ICollection<StudentParentAssociationPagesRead> _studentParentAssociationPagesReads;
        private ICollection<Entities.Common.Sample.IStudentParentAssociationPagesRead> _studentParentAssociationPagesReadsCovariant;

        [DataMember(Name="pagesReads"), NoDuplicateMembers]
        public ICollection<StudentParentAssociationPagesRead> StudentParentAssociationPagesReads
        {
            get { return _studentParentAssociationPagesReads; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentParentAssociationPagesRead>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentParentAssociationPagesRead)e.Item).StudentParentAssociationExtension = this);
                _studentParentAssociationPagesReads = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentParentAssociationPagesRead, StudentParentAssociationPagesRead>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentParentAssociationPagesRead)e.Item).StudentParentAssociationExtension = this;
                _studentParentAssociationPagesReadsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentParentAssociationPagesRead> Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationPagesReads
        {
            get { return _studentParentAssociationPagesReadsCovariant; }
            set { StudentParentAssociationPagesReads = new List<StudentParentAssociationPagesRead>(value.Cast<StudentParentAssociationPagesRead>()); }
        }

        private ICollection<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation> _studentParentAssociationStaffEducationOrganizationEmploymentAssociations;
        private ICollection<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> _studentParentAssociationStaffEducationOrganizationEmploymentAssociationsCovariant;

        [DataMember(Name="staffEducationOrganizationEmploymentAssociations"), NoDuplicateMembers]
        public ICollection<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation> StudentParentAssociationStaffEducationOrganizationEmploymentAssociations
        {
            get { return _studentParentAssociationStaffEducationOrganizationEmploymentAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation)e.Item).StudentParentAssociationExtension = this);
                _studentParentAssociationStaffEducationOrganizationEmploymentAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation)e.Item).StudentParentAssociationExtension = this;
                _studentParentAssociationStaffEducationOrganizationEmploymentAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> Entities.Common.Sample.IStudentParentAssociationExtension.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations
        {
            get { return _studentParentAssociationStaffEducationOrganizationEmploymentAssociationsCovariant; }
            set { StudentParentAssociationStaffEducationOrganizationEmploymentAssociations = new List<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>(value.Cast<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_studentParentAssociationDisciplines != null) foreach (var item in _studentParentAssociationDisciplines)
            {
                item.StudentParentAssociationExtension = this;
            }

            if (_studentParentAssociationFavoriteBookTitles != null) foreach (var item in _studentParentAssociationFavoriteBookTitles)
            {
                item.StudentParentAssociationExtension = this;
            }

            if (_studentParentAssociationHoursPerWeeks != null) foreach (var item in _studentParentAssociationHoursPerWeeks)
            {
                item.StudentParentAssociationExtension = this;
            }

            if (_studentParentAssociationPagesReads != null) foreach (var item in _studentParentAssociationPagesReads)
            {
                item.StudentParentAssociationExtension = this;
            }

            if (_studentParentAssociationStaffEducationOrganizationEmploymentAssociations != null) foreach (var item in _studentParentAssociationStaffEducationOrganizationEmploymentAssociations)
            {
                item.StudentParentAssociationExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentParentAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsBedtimeReaderSupported                                                             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsBedtimeReadingRateSupported                                                        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsBookBudgetSupported                                                                { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsBooksBorrowedSupported                                                             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsEducationOrganizationIdSupported                                                   { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsInterventionStudyIdentificationCodeSupported                                       { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsLibraryDurationSupported                                                           { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsLibraryTimeSupported                                                               { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsLibraryVisitsSupported                                                             { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsPriorContactRestrictionsSupported                                                  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsReadGreenEggsAndHamDateSupported                                                   { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsReadingTimeSpentSupported                                                          { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationDisciplinesSupported                                       { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationFavoriteBookTitlesSupported                                { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationHoursPerWeeksSupported                                     { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationPagesReadsSupported                                        { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationsSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationTelephoneSupported                                         { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentReadSupported                                                               { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.IStudentParentAssociationDiscipline, bool> Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationDisciplineIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle, bool> Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationFavoriteBookTitleIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentParentAssociationHoursPerWeek, bool> Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationHoursPerWeekIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentParentAssociationPagesRead, bool> Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationPagesReadIncluded
        {
            get { return null; }
            set { }
        }
        Func<Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, bool> Entities.Common.Sample.IStudentParentAssociationExtensionSynchronizationSourceSupport.IsStudentParentAssociationStaffEducationOrganizationEmploymentAssociationIncluded
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentParentAssociationExtension.InterventionStudyResourceId
        {
            get { return null; }
            set { ImplicitInterventionStudyReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentParentAssociationExtension.InterventionStudyDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitInterventionStudyReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationExtension> context, FluentValidation.Results.ValidationResult result)
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
            var studentParentAssociationDisciplinesValidator = new StudentParentAssociationDisciplinePutPostRequestValidator();

            foreach (var item in instance.StudentParentAssociationDisciplines)
            {
                var validationResult = studentParentAssociationDisciplinesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentParentAssociationFavoriteBookTitlesValidator = new StudentParentAssociationFavoriteBookTitlePutPostRequestValidator();

            foreach (var item in instance.StudentParentAssociationFavoriteBookTitles)
            {
                var validationResult = studentParentAssociationFavoriteBookTitlesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentParentAssociationHoursPerWeeksValidator = new StudentParentAssociationHoursPerWeekPutPostRequestValidator();

            foreach (var item in instance.StudentParentAssociationHoursPerWeeks)
            {
                var validationResult = studentParentAssociationHoursPerWeeksValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentParentAssociationPagesReadsValidator = new StudentParentAssociationPagesReadPutPostRequestValidator();

            foreach (var item in instance.StudentParentAssociationPagesReads)
            {
                var validationResult = studentParentAssociationPagesReadsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentParentAssociationStaffEducationOrganizationEmploymentAssociationsValidator = new StudentParentAssociationStaffEducationOrganizationEmploymentAssociationPutPostRequestValidator();

            foreach (var item in instance.StudentParentAssociationStaffEducationOrganizationEmploymentAssociations)
            {
                var validationResult = studentParentAssociationStaffEducationOrganizationEmploymentAssociationsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }


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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationFavoriteBookTitle table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationFavoriteBookTitle : Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle, Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitleSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
        }

        /// <summary>
        /// The title of the student's favorite book.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="favoriteBookTitle"), NaturalKeyMember]
        public string FavoriteBookTitle { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle).FavoriteBookTitle == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle).FavoriteBookTitle.Equals(compareTo.FavoriteBookTitle))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle).FavoriteBookTitle != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle).FavoriteBookTitle.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentParentAssociationFavoriteBookTitleMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationFavoriteBookTitleMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationFavoriteBookTitle)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationFavoriteBookTitlePutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationFavoriteBookTitle>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationFavoriteBookTitle> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationHoursPerWeek table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationHoursPerWeek : Entities.Common.Sample.IStudentParentAssociationHoursPerWeek, Entities.Common.Sample.IStudentParentAssociationHoursPerWeekSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationHoursPerWeek.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
        }

        /// <summary>
        /// Total number of hours per week a student and parent dedicates to reading.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek"), NaturalKeyMember]
        public decimal HoursPerWeek { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationHoursPerWeek;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationHoursPerWeek).HoursPerWeek == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationHoursPerWeek).HoursPerWeek.Equals(compareTo.HoursPerWeek))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationHoursPerWeek).HoursPerWeek != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationHoursPerWeek).HoursPerWeek.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentParentAssociationHoursPerWeekMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationHoursPerWeek)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationHoursPerWeekMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationHoursPerWeek)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationHoursPerWeekPutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationHoursPerWeek>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationHoursPerWeek> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationPagesRead table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationPagesRead : Entities.Common.Sample.IStudentParentAssociationPagesRead, Entities.Common.Sample.IStudentParentAssociationPagesReadSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationPagesRead.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
        }

        /// <summary>
        /// Total number of pages the parent has read the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="pagesRead"), NaturalKeyMember]
        public decimal PagesRead { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationPagesRead;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;


            // Standard Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationPagesRead).PagesRead == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationPagesRead).PagesRead.Equals(compareTo.PagesRead))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();

                // Standard Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationPagesRead).PagesRead != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationPagesRead).PagesRead.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentParentAssociationPagesReadMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationPagesRead)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationPagesReadMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationPagesRead)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationPagesReadPutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationPagesRead>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationPagesRead> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociation table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationStaffEducationOrganizationEmploymentAssociation : Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation, Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned;
        private StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociationReference _staffEducationOrganizationEmploymentAssociationReference;
        private StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociationReference ImplicitStaffEducationOrganizationEmploymentAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_staffEducationOrganizationEmploymentAssociationReference == null && !_staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned)
                    _staffEducationOrganizationEmploymentAssociationReference = new StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociationReference();

                return _staffEducationOrganizationEmploymentAssociationReference;
            }
        }

        [DataMember(Name="staffEducationOrganizationEmploymentAssociationReference")][NaturalKeyMember]
        public StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociationReference StaffEducationOrganizationEmploymentAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference;

                return null;
            }
            set
            {
                _staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned = true;
                _staffEducationOrganizationEmploymentAssociationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference.EducationOrganizationId;

                return default(int);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationEmploymentAssociation
                _staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationEmploymentAssociationReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// Reflects the type of employment or contract; for example:          Probationary          Contractual          Substitute/temporary          Tenured or permanent          Volunteer/no contract          ...
        /// </summary>

        // IS in a reference (StudentParentAssociationStaffEducationOrganizationEmploymentAssociation.EmploymentStatusDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.EmploymentStatusDescriptor
        {
            get
            {
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference.EmploymentStatusDescriptor;

                return null;
            }
            set
            {
                ImplicitStaffEducationOrganizationEmploymentAssociationReference.EmploymentStatusDescriptor = value;
            }
        }

        /// <summary>
        /// The month, day, and year on which an individual was hired for a position.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        DateTime Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.HireDate
        {
            get
            {
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference.HireDate;

                return default(DateTime);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationEmploymentAssociation
                _staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationEmploymentAssociationReference.HireDate = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a staff.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StaffUniqueId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference.StaffUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffEducationOrganizationEmploymentAssociation
                _staffEducationOrganizationEmploymentAssociationReferenceExplicitlyAssigned = false;
                ImplicitStaffEducationOrganizationEmploymentAssociationReference.StaffUniqueId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;


            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;

            // Unified Type Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor == null
                ||!(this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor.Equals(compareTo.EmploymentStatusDescriptor))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).HireDate == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).HireDate.Equals(compareTo.HireDate))
                return false;

            // Referenced Property
            if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId == null
                || !(this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId.Equals(compareTo.StaffUniqueId))
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId.GetHashCode();

                //Unified Type Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).HireDate != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).HireDate.GetHashCode();

                //Referenced Property
                if ((this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId != null)
                    hash = hash * 23 + (this as Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
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
            return Entities.Common.Sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationResourceId
        {
            get { return null; }
            set { ImplicitStaffEducationOrganizationEmploymentAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStaffEducationOrganizationEmploymentAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationStaffEducationOrganizationEmploymentAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationStaffEducationOrganizationEmploymentAssociation> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the sample.StudentParentAssociationTelephone table of the StudentParentAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationTelephone : Entities.Common.Sample.IStudentParentAssociationTelephone, Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentParentAssociationExtension _studentParentAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentParentAssociationExtension Entities.Common.Sample.IStudentParentAssociationTelephone.StudentParentAssociationExtension
        {
            get { return _studentParentAssociationExtension; }
            set { SetStudentParentAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentParentAssociationExtension StudentParentAssociationExtension
        {
            set { SetStudentParentAssociationExtension(value); }
        }

        private void SetStudentParentAssociationExtension(Entities.Common.Sample.IStudentParentAssociationExtension value)
        {
            _studentParentAssociationExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentParentAssociationTelephone;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentParentAssociationExtension == null || !_studentParentAssociationExtension.Equals(compareTo.StudentParentAssociationExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentParentAssociationExtension != null)
                    hash = hash * 23 + _studentParentAssociationExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication that the telephone number should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The order of priority assigned to telephone numbers to define which number to attempt first, second, etc.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="orderOfPriority")]
        public int? OrderOfPriority { get; set; }

        /// <summary>
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber")]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="telephoneNumberTypeDescriptor")]
        public string TelephoneNumberTypeDescriptor { get; set; }

        /// <summary>
        /// An indication that the telephone number is technically capable of sending and receiving Short Message Service (SMS) text messages.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="textMessageCapabilityIndicator")]
        public bool? TextMessageCapabilityIndicator { get; set; }
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
            return Entities.Common.Sample.StudentParentAssociationTelephoneMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentParentAssociationTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentParentAssociationTelephoneMapper.MapTo(this, (Entities.Common.Sample.IStudentParentAssociationTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported           { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport.IsOrderOfPrioritySupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport.IsTelephoneNumberSupported                 { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport.IsTelephoneNumberTypeDescriptorSupported   { get { return true; } set { } }
        bool Entities.Common.Sample.IStudentParentAssociationTelephoneSynchronizationSourceSupport.IsTextMessageCapabilityIndicatorSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<StudentParentAssociationTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentParentAssociationTelephone> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentSchoolAssociationExtension table of the StudentSchoolAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationExtension : Entities.Common.Sample.IStudentSchoolAssociationExtension, Entities.Common.Sample.IStudentSchoolAssociationExtensionSynchronizationSourceSupport
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
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentSchoolAssociation _studentSchoolAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentSchoolAssociation Entities.Common.Sample.IStudentSchoolAssociationExtension.StudentSchoolAssociation
        {
            get { return _studentSchoolAssociation; }
            set { SetStudentSchoolAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentSchoolAssociation StudentSchoolAssociation
        {
            set { SetStudentSchoolAssociation(value); }
        }

        private void SetStudentSchoolAssociation(Entities.Common.EdFi.IStudentSchoolAssociation value)
        {
            _studentSchoolAssociation = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.IStudentSchoolAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentSchoolAssociation == null || !_studentSchoolAssociation.Equals(compareTo.StudentSchoolAssociation))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_studentSchoolAssociation != null)
                    hash = hash * 23 + _studentSchoolAssociation.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// Membership Type identifies whether a school has primary responsibility for managing a specific student's curriculum or not.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="membershipTypeDescriptor")]
        public string MembershipTypeDescriptor { get; set; }
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
            return Entities.Common.Sample.StudentSchoolAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentSchoolAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentSchoolAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentSchoolAssociationExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.IStudentSchoolAssociationExtensionSynchronizationSourceSupport.IsMembershipTypeDescriptorSupported  { get { return true; } set { } }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentSchoolAssociationExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentSchoolAssociationExtension> context, FluentValidation.Results.ValidationResult result)
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
