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
using EdFi.Ods.Common.Models.Resource;
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
    public class ArtMediumDescriptor : Entities.Common.Sample.IArtMediumDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
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
            var compareTo = obj as Entities.Common.Sample.IArtMediumDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId.Equals(compareTo.ArtMediumDescriptorId))
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
            var hash = new HashCode();

            //Derived Property
            hash.Add((this as Entities.Common.Sample.IArtMediumDescriptor).ArtMediumDescriptorId);

            return hash.ToHashCode();
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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
    public class Bus : Entities.Common.Sample.IBus, IHasETag, IDateVersionedEntity
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
            var compareTo = obj as Entities.Common.Sample.IBus;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBus).BusId.Equals(compareTo.BusId))
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
            var hash = new HashCode();

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBus).BusId);

            return hash.ToHashCode();
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class BusRoute : Entities.Common.Sample.IBusRoute, IHasETag, IDateVersionedEntity, IHasRequiredMembersWithMeaningfulDefaultValues
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
            var compareTo = obj as Entities.Common.Sample.IBusRoute;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRoute).BusId.Equals(compareTo.BusId))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRoute).BusRouteNumber.Equals(compareTo.BusRouteNumber))
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
            var hash = new HashCode();

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRoute).BusId);


            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRoute).BusRouteNumber);

            return hash.ToHashCode();
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
        /// Month, day, and year of the start or effective date of a staff member's employment, contract, or relationship with the education organization.
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
        long? Entities.Common.Sample.IBusRoute.EducationOrganizationId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationAssignmentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationAssignmentAssociationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitStaffEducationOrganizationAssignmentAssociationReference.EducationOrganizationId;
                    }

                return default(long?);
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
        
        private bool _hoursPerWeekExplicitlyAssigned = false;
        private decimal _hoursPerWeek;

        /// <summary>
        /// The number of hours per week in which the bus route is operational.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek")]
        public decimal HoursPerWeek 
        { 
            get => _hoursPerWeek;
            set 
            { 
                _hoursPerWeek = value;
                _hoursPerWeekExplicitlyAssigned = true; 
            }
        }

        
        private bool _operatingCostExplicitlyAssigned = false;
        private decimal _operatingCost;

        /// <summary>
        /// The approximate annual cost for the bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="operatingCost")]
        public decimal OperatingCost 
        { 
            get => _operatingCost;
            set 
            { 
                _operatingCost = value;
                _operatingCostExplicitlyAssigned = true; 
            }
        }


        /// <summary>
        /// The percentage of seats filled under optimal conditions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="optimalCapacity")]
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
        [DataMember(Name="weeklyMileage")]
        public decimal? WeeklyMileage { get; set; }
        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_hoursPerWeekExplicitlyAssigned)
            {
                yield return "HoursPerWeek";
            }
            if (!_operatingCostExplicitlyAssigned)
            {
                yield return "OperatingCost";
            }
        }

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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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
        private static readonly FullName _fullName_sample_BusRoute = new FullName("sample", "BusRoute");

        protected override bool PreValidate(FluentValidation.ValidationContext<BusRoute> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.BusRouteMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.BusRouteMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_BusRoute));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsBusRouteBusYearIncluded != null)
                {
                    var hasInvalidBusRouteBusYearsItems = instance.BusRouteBusYears.Any(x => !mappingContract.Value.IsBusRouteBusYearIncluded(x));
        
                    if (hasInvalidBusRouteBusYearsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("BusRouteBusYear", $"A supplied 'BusRouteBusYear' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsBusRouteProgramIncluded != null)
                {
                    var hasInvalidBusRouteProgramsItems = instance.BusRoutePrograms.Any(x => !mappingContract.Value.IsBusRouteProgramIncluded(x));
        
                    if (hasInvalidBusRouteProgramsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("BusRouteProgram", $"A supplied 'BusRouteProgram' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsBusRouteServiceAreaPostalCodeIncluded != null)
                {
                    var hasInvalidBusRouteServiceAreaPostalCodesItems = instance.BusRouteServiceAreaPostalCodes.Any(x => !mappingContract.Value.IsBusRouteServiceAreaPostalCodeIncluded(x));
        
                    if (hasInvalidBusRouteServiceAreaPostalCodesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("BusRouteServiceAreaPostalCode", $"A supplied 'BusRouteServiceAreaPostalCode' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsBusRouteStartTimeIncluded != null)
                {
                    var hasInvalidBusRouteStartTimesItems = instance.BusRouteStartTimes.Any(x => !mappingContract.Value.IsBusRouteStartTimeIncluded(x));
        
                    if (hasInvalidBusRouteStartTimesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("BusRouteStartTime", $"A supplied 'BusRouteStartTime' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsBusRouteTelephoneIncluded != null)
                {
                    var hasInvalidBusRouteTelephonesItems = instance.BusRouteTelephones.Any(x => !mappingContract.Value.IsBusRouteTelephoneIncluded(x));
        
                    if (hasInvalidBusRouteTelephonesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("BusRouteTelephone", $"A supplied 'BusRouteTelephone' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class BusRouteBusYear : Entities.Common.Sample.IBusRouteBusYear
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
            var compareTo = obj as Entities.Common.Sample.IBusRouteBusYear;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRouteBusYear).BusYear.Equals(compareTo.BusYear))
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
            var hash = new HashCode();
            //Parent Property
            if (_busRoute != null)
                hash.Add(_busRoute);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRouteBusYear).BusYear);

            return hash.ToHashCode();
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
    public class BusRouteProgram : Entities.Common.Sample.IBusRouteProgram
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
        long Entities.Common.Sample.IBusRouteProgram.EducationOrganizationId
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.EducationOrganizationId;

                return default(long);
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
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
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
            var compareTo = obj as Entities.Common.Sample.IBusRouteProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IBusRouteProgram).ProgramName.Equals(compareTo.ProgramName))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_busRoute != null)
                hash.Add(_busRoute);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IBusRouteProgram).EducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IBusRouteProgram).ProgramName);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IBusRouteProgram).ProgramTypeDescriptor);

            return hash.ToHashCode();
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
    public class BusRouteServiceAreaPostalCode : Entities.Common.Sample.IBusRouteServiceAreaPostalCode
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
            var compareTo = obj as Entities.Common.Sample.IBusRouteServiceAreaPostalCode;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode.Equals(compareTo.ServiceAreaPostalCode))
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
            var hash = new HashCode();
            //Parent Property
            if (_busRoute != null)
                hash.Add(_busRoute);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRouteServiceAreaPostalCode).ServiceAreaPostalCode);

            return hash.ToHashCode();
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
    public class BusRouteStartTime : Entities.Common.Sample.IBusRouteStartTime
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
            var compareTo = obj as Entities.Common.Sample.IBusRouteStartTime;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRouteStartTime).StartTime.Equals(compareTo.StartTime))
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
            var hash = new HashCode();
            //Parent Property
            if (_busRoute != null)
                hash.Add(_busRoute);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRouteStartTime).StartTime);

            return hash.ToHashCode();
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
    public class BusRouteTelephone : Entities.Common.Sample.IBusRouteTelephone
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
            var compareTo = obj as Entities.Common.Sample.IBusRouteTelephone;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_busRoute == null || !_busRoute.Equals(compareTo.BusRoute))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber.Equals(compareTo.TelephoneNumber))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor.Equals(compareTo.TelephoneNumberTypeDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_busRoute != null)
                hash.Add(_busRoute);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumber);


            // Standard Property
                hash.Add((this as Entities.Common.Sample.IBusRouteTelephone).TelephoneNumberTypeDescriptor);

            return hash.ToHashCode();
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
// Aggregate: Contact

namespace EdFi.Ods.Api.Common.Models.Resources.Contact.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.ContactAddressExtension table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class ContactAddressExtension : Entities.Common.Sample.IContactAddressExtension, IHasRequiredMembersWithMeaningfulDefaultValues
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public ContactAddressExtension()
        {
            ContactAddressSchoolDistricts = new List<ContactAddressSchoolDistrict>();
            ContactAddressTerms = new List<ContactAddressTerm>();
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
        private Entities.Common.EdFi.IContactAddress _contactAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IContactAddress Entities.Common.Sample.IContactAddressExtension.ContactAddress
        {
            get { return _contactAddress; }
            set { SetContactAddress(value); }
        }

        internal Entities.Common.EdFi.IContactAddress ContactAddress
        {
            set { SetContactAddress(value); }
        }

        private void SetContactAddress(Entities.Common.EdFi.IContactAddress value)
        {
            _contactAddress = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactAddressExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactAddress == null || !_contactAddress.Equals(compareTo.ContactAddress))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactAddress != null)
                hash.Add(_contactAddress);
            return hash.ToHashCode();
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
        
        private bool _onBusRouteExplicitlyAssigned = false;
        private bool _onBusRoute;

        /// <summary>
        /// An indicator if the address is on a bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="onBusRoute")]
        public bool OnBusRoute 
        { 
            get => _onBusRoute;
            set 
            { 
                _onBusRoute = value;
                _onBusRouteExplicitlyAssigned = true; 
            }
        }

        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_onBusRouteExplicitlyAssigned)
            {
                yield return "OnBusRoute";
            }
        }

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
        private ICollection<ContactAddressSchoolDistrict> _contactAddressSchoolDistricts;
        private ICollection<Entities.Common.Sample.IContactAddressSchoolDistrict> _contactAddressSchoolDistrictsCovariant;

        [DataMember(Name="schoolDistricts"), NoDuplicateMembers]
        public ICollection<ContactAddressSchoolDistrict> ContactAddressSchoolDistricts
        {
            get { return _contactAddressSchoolDistricts; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactAddressSchoolDistrict>(value,
                    (s, e) => ((Entities.Common.Sample.IContactAddressSchoolDistrict)e.Item).ContactAddressExtension = this);
                _contactAddressSchoolDistricts = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactAddressSchoolDistrict, ContactAddressSchoolDistrict>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactAddressSchoolDistrict)e.Item).ContactAddressExtension = this;
                _contactAddressSchoolDistrictsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactAddressSchoolDistrict> Entities.Common.Sample.IContactAddressExtension.ContactAddressSchoolDistricts
        {
            get { return _contactAddressSchoolDistrictsCovariant; }
            set { ContactAddressSchoolDistricts = new List<ContactAddressSchoolDistrict>(value.Cast<ContactAddressSchoolDistrict>()); }
        }

        private ICollection<ContactAddressTerm> _contactAddressTerms;
        private ICollection<Entities.Common.Sample.IContactAddressTerm> _contactAddressTermsCovariant;

        [DataMember(Name="terms"), NoDuplicateMembers]
        public ICollection<ContactAddressTerm> ContactAddressTerms
        {
            get { return _contactAddressTerms; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactAddressTerm>(value,
                    (s, e) => ((Entities.Common.Sample.IContactAddressTerm)e.Item).ContactAddressExtension = this);
                _contactAddressTerms = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactAddressTerm, ContactAddressTerm>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactAddressTerm)e.Item).ContactAddressExtension = this;
                _contactAddressTermsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactAddressTerm> Entities.Common.Sample.IContactAddressExtension.ContactAddressTerms
        {
            get { return _contactAddressTermsCovariant; }
            set { ContactAddressTerms = new List<ContactAddressTerm>(value.Cast<ContactAddressTerm>()); }
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
            if (_contactAddressSchoolDistricts != null) foreach (var item in _contactAddressSchoolDistricts)
            {
                item.ContactAddressExtension = this;
            }

            if (_contactAddressTerms != null) foreach (var item in _contactAddressTerms)
            {
                item.ContactAddressExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.ContactAddressExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactAddressExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactAddressExtensionMapper.MapTo(this, (Entities.Common.Sample.IContactAddressExtension)target, null);
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
    public class ContactAddressExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<ContactAddressExtension>
    {
        private static readonly FullName _fullName_sample_ContactAddressExtension = new FullName("sample", "ContactAddressExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<ContactAddressExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.ContactAddressExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.ContactAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactAddressExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsContactAddressSchoolDistrictIncluded != null)
                {
                    var hasInvalidContactAddressSchoolDistrictsItems = instance.ContactAddressSchoolDistricts.Any(x => !mappingContract.Value.IsContactAddressSchoolDistrictIncluded(x));
        
                    if (hasInvalidContactAddressSchoolDistrictsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactAddressSchoolDistrict", $"A supplied 'ContactAddressSchoolDistrict' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsContactAddressTermIncluded != null)
                {
                    var hasInvalidContactAddressTermsItems = instance.ContactAddressTerms.Any(x => !mappingContract.Value.IsContactAddressTermIncluded(x));
        
                    if (hasInvalidContactAddressTermsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactAddressTerm", $"A supplied 'ContactAddressTerm' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
            // -----------------------
            //  Validate unified keys
            // -----------------------

            // Recursively invoke the child collection item validators
            var contactAddressSchoolDistrictsValidator = new ContactAddressSchoolDistrictPutPostRequestValidator();

            foreach (var item in instance.ContactAddressSchoolDistricts)
            {
                var validationResult = contactAddressSchoolDistrictsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var contactAddressTermsValidator = new ContactAddressTermPutPostRequestValidator();

            foreach (var item in instance.ContactAddressTerms)
            {
                var validationResult = contactAddressTermsValidator.Validate(item);

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
    /// A class which represents the sample.ContactAddressSchoolDistrict table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactAddressSchoolDistrict : Entities.Common.Sample.IContactAddressSchoolDistrict
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
        private Entities.Common.Sample.IContactAddressExtension _contactAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactAddressExtension Entities.Common.Sample.IContactAddressSchoolDistrict.ContactAddressExtension
        {
            get { return _contactAddressExtension; }
            set { SetContactAddressExtension(value); }
        }

        internal Entities.Common.Sample.IContactAddressExtension ContactAddressExtension
        {
            set { SetContactAddressExtension(value); }
        }

        private void SetContactAddressExtension(Entities.Common.Sample.IContactAddressExtension value)
        {
            _contactAddressExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactAddressSchoolDistrict;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactAddressExtension == null || !_contactAddressExtension.Equals(compareTo.ContactAddressExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IContactAddressSchoolDistrict).SchoolDistrict.Equals(compareTo.SchoolDistrict))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactAddressExtension != null)
                hash.Add(_contactAddressExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IContactAddressSchoolDistrict).SchoolDistrict);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactAddressSchoolDistrictMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactAddressSchoolDistrict)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactAddressSchoolDistrictMapper.MapTo(this, (Entities.Common.Sample.IContactAddressSchoolDistrict)target, null);
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
    public class ContactAddressSchoolDistrictPutPostRequestValidator : FluentValidation.AbstractValidator<ContactAddressSchoolDistrict>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactAddressSchoolDistrict> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactAddressTerm table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactAddressTerm : Entities.Common.Sample.IContactAddressTerm
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
        private Entities.Common.Sample.IContactAddressExtension _contactAddressExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactAddressExtension Entities.Common.Sample.IContactAddressTerm.ContactAddressExtension
        {
            get { return _contactAddressExtension; }
            set { SetContactAddressExtension(value); }
        }

        internal Entities.Common.Sample.IContactAddressExtension ContactAddressExtension
        {
            set { SetContactAddressExtension(value); }
        }

        private void SetContactAddressExtension(Entities.Common.Sample.IContactAddressExtension value)
        {
            _contactAddressExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactAddressTerm;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactAddressExtension == null || !_contactAddressExtension.Equals(compareTo.ContactAddressExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IContactAddressTerm).TermDescriptor.Equals(compareTo.TermDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactAddressExtension != null)
                hash.Add(_contactAddressExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IContactAddressTerm).TermDescriptor);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactAddressTermMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactAddressTerm)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactAddressTermMapper.MapTo(this, (Entities.Common.Sample.IContactAddressTerm)target, null);
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
    public class ContactAddressTermPutPostRequestValidator : FluentValidation.AbstractValidator<ContactAddressTerm>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactAddressTerm> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactAuthor table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactAuthor : Entities.Common.Sample.IContactAuthor
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactAuthor.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
        }

        /// <summary>
        /// The contact's favorite authors.
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
            var compareTo = obj as Entities.Common.Sample.IContactAuthor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IContactAuthor).Author.Equals(compareTo.Author))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IContactAuthor).Author);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactAuthorMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactAuthor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactAuthorMapper.MapTo(this, (Entities.Common.Sample.IContactAuthor)target, null);
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
    public class ContactAuthorPutPostRequestValidator : FluentValidation.AbstractValidator<ContactAuthor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactAuthor> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactCeilingHeight table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class ContactCeilingHeight : Entities.Common.Sample.IContactCeilingHeight, IHasRequiredMembersWithMeaningfulDefaultValues
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactCeilingHeight.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
        }
        
        private bool _ceilingHeightExplicitlyAssigned = false;
        private decimal _ceilingHeight;

        /// <summary>
        /// The height of the ceiling in the rooms of the contact's home.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="ceilingHeight"), NaturalKeyMember]
        public decimal CeilingHeight 
        { 
            get => _ceilingHeight;
            set 
            { 
                _ceilingHeight = value;
                _ceilingHeightExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IContactCeilingHeight;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IContactCeilingHeight).CeilingHeight.Equals(compareTo.CeilingHeight))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IContactCeilingHeight).CeilingHeight);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_ceilingHeightExplicitlyAssigned)
            {
                yield return "CeilingHeight";
            }
        }

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
            return Entities.Common.Sample.ContactCeilingHeightMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactCeilingHeight)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactCeilingHeightMapper.MapTo(this, (Entities.Common.Sample.IContactCeilingHeight)target, null);
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
    public class ContactCeilingHeightPutPostRequestValidator : FluentValidation.AbstractValidator<ContactCeilingHeight>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactCeilingHeight> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactCTEProgram table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactCTEProgram : Entities.Common.Sample.IContactCTEProgram
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactCTEProgram.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);
            return hash.ToHashCode();
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
        /// Number and description of the CIP code associated with the student's CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the student has completed the CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTE program is the student's primary CTE program.
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
            return Entities.Common.Sample.ContactCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactCTEProgramMapper.MapTo(this, (Entities.Common.Sample.IContactCTEProgram)target, null);
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
    public class ContactCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<ContactCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactCTEProgram> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactEducationContent table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactEducationContent : Entities.Common.Sample.IContactEducationContent
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactEducationContent.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
        }

        /// <summary>
        /// A unique identifier for the education content.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IContactEducationContent.ContentIdentifier
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
            var compareTo = obj as Entities.Common.Sample.IContactEducationContent;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactEducationContent).ContentIdentifier.Equals(compareTo.ContentIdentifier))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactEducationContent).ContentIdentifier);
            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactEducationContentMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactEducationContent)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactEducationContentMapper.MapTo(this, (Entities.Common.Sample.IContactEducationContent)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IContactEducationContent.EducationContentResourceId
        {
            get { return null; }
            set { ImplicitEducationContentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IContactEducationContent.EducationContentDiscriminator
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
    public class ContactEducationContentPutPostRequestValidator : FluentValidation.AbstractValidator<ContactEducationContent>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactEducationContent> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactExtension table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class ContactExtension : Entities.Common.Sample.IContactExtension, IHasRequiredMembersWithMeaningfulDefaultValues
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public ContactExtension()
        {
            ContactAuthors = new List<ContactAuthor>();
            ContactCeilingHeights = new List<ContactCeilingHeight>();
            ContactEducationContents = new List<ContactEducationContent>();
            ContactFavoriteBookTitles = new List<ContactFavoriteBookTitle>();
            ContactStudentProgramAssociations = new List<ContactStudentProgramAssociation>();
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
        private Entities.Common.EdFi.IContact _contact;

        [IgnoreDataMember]
        Entities.Common.EdFi.IContact Entities.Common.Sample.IContactExtension.Contact
        {
            get { return _contact; }
            set { SetContact(value); }
        }

        internal Entities.Common.EdFi.IContact Contact
        {
            set { SetContact(value); }
        }

        private void SetContact(Entities.Common.EdFi.IContact value)
        {
            _contact = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contact == null || !_contact.Equals(compareTo.Contact))
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
            var hash = new HashCode();
            //Parent Property
            if (_contact != null)
                hash.Add(_contact);
            return hash.ToHashCode();
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
        /// The year in which the contact first became a contact.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="becameParent")]
        public short? BecameParent { get; set; }

        /// <summary>
        /// How much the contact spends on coffee in a week.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="coffeeSpend")]
        public decimal? CoffeeSpend { get; set; }

        /// <summary>
        /// The field in which the contact holds a credential.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="credentialFieldDescriptor")]
        public string CredentialFieldDescriptor { get; set; }

        /// <summary>
        /// The amount of time the contact spends reading to his/her children at bedtime.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// The contact's high school GPA.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="gpa")]
        public decimal? GPA { get; set; }

        /// <summary>
        /// The date the contact graduated high school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="graduationDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? GraduationDate { get; set; }
        
        private bool _isSportsFanExplicitlyAssigned = false;
        private bool _isSportsFan;

        /// <summary>
        /// An indication as to whether the contact is a sports fan.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isSportsFan")]
        public bool IsSportsFan 
        { 
            get => _isSportsFan;
            set 
            { 
                _isSportsFan = value;
                _isSportsFanExplicitlyAssigned = true; 
            }
        }


        /// <summary>
        /// The contact's lucky number.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="luckyNumber")]
        public int? LuckyNumber { get; set; }

        /// <summary>
        /// The time the contact would prefer to wake up in the morning.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="preferredWakeUpTime")][JsonConverter(typeof(UtcTimeConverter))]
        public TimeSpan? PreferredWakeUpTime { get; set; }

        /// <summary>
        /// The percent likelihood that it will rain when the contact volunteers to chaperone a field trip.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="rainCertainty")]
        public decimal? RainCertainty { get; set; }
        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_isSportsFanExplicitlyAssigned)
            {
                yield return "IsSportsFan";
            }
        }

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public ContactCTEProgram ContactCTEProgram { get; set; }

        Entities.Common.Sample.IContactCTEProgram Entities.Common.Sample.IContactExtension.ContactCTEProgram
        {
            get { return ContactCTEProgram; }
            set { ContactCTEProgram = (ContactCTEProgram) value; }
        }

        /// <summary>
        /// teacherConference
        /// </summary>
        [DataMember(Name = "teacherConference")]
        public ContactTeacherConference ContactTeacherConference { get; set; }

        Entities.Common.Sample.IContactTeacherConference Entities.Common.Sample.IContactExtension.ContactTeacherConference
        {
            get { return ContactTeacherConference; }
            set { ContactTeacherConference = (ContactTeacherConference) value; }
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
        private ICollection<ContactAuthor> _contactAuthors;
        private ICollection<Entities.Common.Sample.IContactAuthor> _contactAuthorsCovariant;

        [DataMember(Name="authors"), NoDuplicateMembers]
        public ICollection<ContactAuthor> ContactAuthors
        {
            get { return _contactAuthors; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactAuthor>(value,
                    (s, e) => ((Entities.Common.Sample.IContactAuthor)e.Item).ContactExtension = this);
                _contactAuthors = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactAuthor, ContactAuthor>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactAuthor)e.Item).ContactExtension = this;
                _contactAuthorsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactAuthor> Entities.Common.Sample.IContactExtension.ContactAuthors
        {
            get { return _contactAuthorsCovariant; }
            set { ContactAuthors = new List<ContactAuthor>(value.Cast<ContactAuthor>()); }
        }

        private ICollection<ContactCeilingHeight> _contactCeilingHeights;
        private ICollection<Entities.Common.Sample.IContactCeilingHeight> _contactCeilingHeightsCovariant;

        [DataMember(Name="ceilingHeights"), NoDuplicateMembers]
        public ICollection<ContactCeilingHeight> ContactCeilingHeights
        {
            get { return _contactCeilingHeights; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactCeilingHeight>(value,
                    (s, e) => ((Entities.Common.Sample.IContactCeilingHeight)e.Item).ContactExtension = this);
                _contactCeilingHeights = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactCeilingHeight, ContactCeilingHeight>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactCeilingHeight)e.Item).ContactExtension = this;
                _contactCeilingHeightsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactCeilingHeight> Entities.Common.Sample.IContactExtension.ContactCeilingHeights
        {
            get { return _contactCeilingHeightsCovariant; }
            set { ContactCeilingHeights = new List<ContactCeilingHeight>(value.Cast<ContactCeilingHeight>()); }
        }

        private ICollection<ContactEducationContent> _contactEducationContents;
        private ICollection<Entities.Common.Sample.IContactEducationContent> _contactEducationContentsCovariant;

        [DataMember(Name="educationContents"), NoDuplicateMembers]
        public ICollection<ContactEducationContent> ContactEducationContents
        {
            get { return _contactEducationContents; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactEducationContent>(value,
                    (s, e) => ((Entities.Common.Sample.IContactEducationContent)e.Item).ContactExtension = this);
                _contactEducationContents = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactEducationContent, ContactEducationContent>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactEducationContent)e.Item).ContactExtension = this;
                _contactEducationContentsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactEducationContent> Entities.Common.Sample.IContactExtension.ContactEducationContents
        {
            get { return _contactEducationContentsCovariant; }
            set { ContactEducationContents = new List<ContactEducationContent>(value.Cast<ContactEducationContent>()); }
        }

        private ICollection<ContactFavoriteBookTitle> _contactFavoriteBookTitles;
        private ICollection<Entities.Common.Sample.IContactFavoriteBookTitle> _contactFavoriteBookTitlesCovariant;

        [DataMember(Name="favoriteBookTitles"), NoDuplicateMembers]
        public ICollection<ContactFavoriteBookTitle> ContactFavoriteBookTitles
        {
            get { return _contactFavoriteBookTitles; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactFavoriteBookTitle>(value,
                    (s, e) => ((Entities.Common.Sample.IContactFavoriteBookTitle)e.Item).ContactExtension = this);
                _contactFavoriteBookTitles = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactFavoriteBookTitle, ContactFavoriteBookTitle>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactFavoriteBookTitle)e.Item).ContactExtension = this;
                _contactFavoriteBookTitlesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactFavoriteBookTitle> Entities.Common.Sample.IContactExtension.ContactFavoriteBookTitles
        {
            get { return _contactFavoriteBookTitlesCovariant; }
            set { ContactFavoriteBookTitles = new List<ContactFavoriteBookTitle>(value.Cast<ContactFavoriteBookTitle>()); }
        }

        private ICollection<ContactStudentProgramAssociation> _contactStudentProgramAssociations;
        private ICollection<Entities.Common.Sample.IContactStudentProgramAssociation> _contactStudentProgramAssociationsCovariant;

        [DataMember(Name="studentProgramAssociations"), NoDuplicateMembers]
        public ICollection<ContactStudentProgramAssociation> ContactStudentProgramAssociations
        {
            get { return _contactStudentProgramAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ContactStudentProgramAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IContactStudentProgramAssociation)e.Item).ContactExtension = this);
                _contactStudentProgramAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IContactStudentProgramAssociation, ContactStudentProgramAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IContactStudentProgramAssociation)e.Item).ContactExtension = this;
                _contactStudentProgramAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IContactStudentProgramAssociation> Entities.Common.Sample.IContactExtension.ContactStudentProgramAssociations
        {
            get { return _contactStudentProgramAssociationsCovariant; }
            set { ContactStudentProgramAssociations = new List<ContactStudentProgramAssociation>(value.Cast<ContactStudentProgramAssociation>()); }
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
            if (_contactAuthors != null) foreach (var item in _contactAuthors)
            {
                item.ContactExtension = this;
            }

            if (_contactCeilingHeights != null) foreach (var item in _contactCeilingHeights)
            {
                item.ContactExtension = this;
            }

            if (_contactEducationContents != null) foreach (var item in _contactEducationContents)
            {
                item.ContactExtension = this;
            }

            if (_contactFavoriteBookTitles != null) foreach (var item in _contactFavoriteBookTitles)
            {
                item.ContactExtension = this;
            }

            if (_contactStudentProgramAssociations != null) foreach (var item in _contactStudentProgramAssociations)
            {
                item.ContactExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.ContactExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactExtensionMapper.MapTo(this, (Entities.Common.Sample.IContactExtension)target, null);
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
    public class ContactExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<ContactExtension>
    {
        private static readonly FullName _fullName_sample_ContactExtension = new FullName("sample", "ContactExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<ContactExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.ContactExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.ContactExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_ContactExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsContactAuthorIncluded != null)
                {
                    var hasInvalidContactAuthorsItems = instance.ContactAuthors.Any(x => !mappingContract.Value.IsContactAuthorIncluded(x));
        
                    if (hasInvalidContactAuthorsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactAuthor", $"A supplied 'ContactAuthor' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsContactCeilingHeightIncluded != null)
                {
                    var hasInvalidContactCeilingHeightsItems = instance.ContactCeilingHeights.Any(x => !mappingContract.Value.IsContactCeilingHeightIncluded(x));
        
                    if (hasInvalidContactCeilingHeightsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactCeilingHeight", $"A supplied 'ContactCeilingHeight' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsContactEducationContentIncluded != null)
                {
                    var hasInvalidContactEducationContentsItems = instance.ContactEducationContents.Any(x => !mappingContract.Value.IsContactEducationContentIncluded(x));
        
                    if (hasInvalidContactEducationContentsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactEducationContent", $"A supplied 'ContactEducationContent' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsContactFavoriteBookTitleIncluded != null)
                {
                    var hasInvalidContactFavoriteBookTitlesItems = instance.ContactFavoriteBookTitles.Any(x => !mappingContract.Value.IsContactFavoriteBookTitleIncluded(x));
        
                    if (hasInvalidContactFavoriteBookTitlesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactFavoriteBookTitle", $"A supplied 'ContactFavoriteBookTitle' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsContactStudentProgramAssociationIncluded != null)
                {
                    var hasInvalidContactStudentProgramAssociationsItems = instance.ContactStudentProgramAssociations.Any(x => !mappingContract.Value.IsContactStudentProgramAssociationIncluded(x));
        
                    if (hasInvalidContactStudentProgramAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ContactStudentProgramAssociation", $"A supplied 'ContactStudentProgramAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
            // -----------------------
            //  Validate unified keys
            // -----------------------

            // Recursively invoke the child collection item validators
            var contactAuthorsValidator = new ContactAuthorPutPostRequestValidator();

            foreach (var item in instance.ContactAuthors)
            {
                var validationResult = contactAuthorsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var contactCeilingHeightsValidator = new ContactCeilingHeightPutPostRequestValidator();

            foreach (var item in instance.ContactCeilingHeights)
            {
                var validationResult = contactCeilingHeightsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var contactEducationContentsValidator = new ContactEducationContentPutPostRequestValidator();

            foreach (var item in instance.ContactEducationContents)
            {
                var validationResult = contactEducationContentsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var contactFavoriteBookTitlesValidator = new ContactFavoriteBookTitlePutPostRequestValidator();

            foreach (var item in instance.ContactFavoriteBookTitles)
            {
                var validationResult = contactFavoriteBookTitlesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var contactStudentProgramAssociationsValidator = new ContactStudentProgramAssociationPutPostRequestValidator();

            foreach (var item in instance.ContactStudentProgramAssociations)
            {
                var validationResult = contactStudentProgramAssociationsValidator.Validate(item);

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
    /// A class which represents the sample.ContactFavoriteBookTitle table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactFavoriteBookTitle : Entities.Common.Sample.IContactFavoriteBookTitle
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactFavoriteBookTitle.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
        }

        /// <summary>
        /// The title of the contact's favorite book.
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
            var compareTo = obj as Entities.Common.Sample.IContactFavoriteBookTitle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IContactFavoriteBookTitle).FavoriteBookTitle.Equals(compareTo.FavoriteBookTitle))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IContactFavoriteBookTitle).FavoriteBookTitle);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactFavoriteBookTitleMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactFavoriteBookTitleMapper.MapTo(this, (Entities.Common.Sample.IContactFavoriteBookTitle)target, null);
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
    public class ContactFavoriteBookTitlePutPostRequestValidator : FluentValidation.AbstractValidator<ContactFavoriteBookTitle>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactFavoriteBookTitle> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactStudentProgramAssociation table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactStudentProgramAssociation : Entities.Common.Sample.IContactStudentProgramAssociation
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactStudentProgramAssociation.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
        }

        /// <summary>
        /// The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        DateTime Entities.Common.Sample.IContactStudentProgramAssociation.BeginDate
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
        long Entities.Common.Sample.IContactStudentProgramAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.EducationOrganizationId;

                return default(long);
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
        long Entities.Common.Sample.IContactStudentProgramAssociation.ProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentProgramAssociationReference.ProgramEducationOrganizationId;

                return default(long);
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
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IContactStudentProgramAssociation.ProgramName
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

        // IS in a reference (ContactStudentProgramAssociation.ProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IContactStudentProgramAssociation.ProgramTypeDescriptor
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
        string Entities.Common.Sample.IContactStudentProgramAssociation.StudentUniqueId
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
            var compareTo = obj as Entities.Common.Sample.IContactStudentProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).BeginDate.Equals(compareTo.BeginDate))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramEducationOrganizationId.Equals(compareTo.ProgramEducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramName.Equals(compareTo.ProgramName))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IContactStudentProgramAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).BeginDate);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).EducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramEducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramName);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).ProgramTypeDescriptor);


            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IContactStudentProgramAssociation).StudentUniqueId);
            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactStudentProgramAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactStudentProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactStudentProgramAssociationMapper.MapTo(this, (Entities.Common.Sample.IContactStudentProgramAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IContactStudentProgramAssociation.StudentProgramAssociationResourceId
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
    public class ContactStudentProgramAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<ContactStudentProgramAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactStudentProgramAssociation> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.ContactTeacherConference table of the Contact aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ContactTeacherConference : Entities.Common.Sample.IContactTeacherConference
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
        private Entities.Common.Sample.IContactExtension _contactExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IContactExtension Entities.Common.Sample.IContactTeacherConference.ContactExtension
        {
            get { return _contactExtension; }
            set { SetContactExtension(value); }
        }

        internal Entities.Common.Sample.IContactExtension ContactExtension
        {
            set { SetContactExtension(value); }
        }

        private void SetContactExtension(Entities.Common.Sample.IContactExtension value)
        {
            _contactExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IContactTeacherConference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_contactExtension == null || !_contactExtension.Equals(compareTo.ContactExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_contactExtension != null)
                hash.Add(_contactExtension);
            return hash.ToHashCode();
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
            return Entities.Common.Sample.ContactTeacherConferenceMapper.SynchronizeTo(this, (Entities.Common.Sample.IContactTeacherConference)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.ContactTeacherConferenceMapper.MapTo(this, (Entities.Common.Sample.IContactTeacherConference)target, null);
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
    public class ContactTeacherConferencePutPostRequestValidator : FluentValidation.AbstractValidator<ContactTeacherConference>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ContactTeacherConference> context, FluentValidation.Results.ValidationResult result)
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
    public class FavoriteBookCategoryDescriptor : Entities.Common.Sample.IFavoriteBookCategoryDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
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
            var compareTo = obj as Entities.Common.Sample.IFavoriteBookCategoryDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId.Equals(compareTo.FavoriteBookCategoryDescriptorId))
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
            var hash = new HashCode();

            //Derived Property
            hash.Add((this as Entities.Common.Sample.IFavoriteBookCategoryDescriptor).FavoriteBookCategoryDescriptorId);

            return hash.ToHashCode();
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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
    public class MembershipTypeDescriptor : Entities.Common.Sample.IMembershipTypeDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
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
            var compareTo = obj as Entities.Common.Sample.IMembershipTypeDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId.Equals(compareTo.MembershipTypeDescriptorId))
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
            var hash = new HashCode();

            //Derived Property
            hash.Add((this as Entities.Common.Sample.IMembershipTypeDescriptor).MembershipTypeDescriptorId);

            return hash.ToHashCode();
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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
// Aggregate: School

namespace EdFi.Ods.Api.Common.Models.Resources.School.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram
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
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_schoolExtension != null)
                hash.Add(_schoolExtension);
            return hash.ToHashCode();
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
        /// Number and description of the CIP code associated with the student's CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the student has completed the CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTE program is the student's primary CTE program.
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
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus
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
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId))
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
            var hash = new HashCode();
            //Parent Property
            if (_schoolExtension != null)
                hash.Add(_schoolExtension);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId);
            return hash.ToHashCode();
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
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension
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
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
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
            var hash = new HashCode();
            //Parent Property
            if (_school != null)
                hash.Add(_school);
            return hash.ToHashCode();
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
        private static readonly FullName _fullName_sample_SchoolExtension = new FullName("sample", "SchoolExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.SchoolExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.SchoolExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_SchoolExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsSchoolDirectlyOwnedBusIncluded != null)
                {
                    var hasInvalidSchoolDirectlyOwnedBusesItems = instance.SchoolDirectlyOwnedBuses.Any(x => !mappingContract.Value.IsSchoolDirectlyOwnedBusIncluded(x));
        
                    if (hasInvalidSchoolDirectlyOwnedBusesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("SchoolDirectlyOwnedBus", $"A supplied 'SchoolDirectlyOwnedBus' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StaffExtension : Entities.Common.Sample.IStaffExtension
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
            var compareTo = obj as Entities.Common.Sample.IStaffExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staff == null || !_staff.Equals(compareTo.Staff))
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
            var hash = new HashCode();
            //Parent Property
            if (_staff != null)
                hash.Add(_staff);
            return hash.ToHashCode();
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
        private static readonly FullName _fullName_sample_StaffExtension = new FullName("sample", "StaffExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StaffExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StaffExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StaffExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StaffExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStaffPetIncluded != null)
                {
                    var hasInvalidStaffPetsItems = instance.StaffPets.Any(x => !mappingContract.Value.IsStaffPetIncluded(x));
        
                    if (hasInvalidStaffPetsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StaffPet", $"A supplied 'StaffPet' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StaffPet : Entities.Common.Sample.IStaffPet
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
            var compareTo = obj as Entities.Common.Sample.IStaffPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staffExtension == null || !_staffExtension.Equals(compareTo.StaffExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStaffPet).PetName.Equals(compareTo.PetName))
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
            var hash = new HashCode();
            //Parent Property
            if (_staffExtension != null)
                hash.Add(_staffExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStaffPet).PetName);

            return hash.ToHashCode();
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StaffPetPreference : Entities.Common.Sample.IStaffPetPreference, IHasRequiredMembersWithMeaningfulDefaultValues
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
            var compareTo = obj as Entities.Common.Sample.IStaffPetPreference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staffExtension == null || !_staffExtension.Equals(compareTo.StaffExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_staffExtension != null)
                hash.Add(_staffExtension);
            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        
        private bool _maximumWeightExplicitlyAssigned = false;
        private int _maximumWeight;

        /// <summary>
        /// The preferred maximum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="maximumWeight")]
        public int MaximumWeight 
        { 
            get => _maximumWeight;
            set 
            { 
                _maximumWeight = value;
                _maximumWeightExplicitlyAssigned = true; 
            }
        }

        
        private bool _minimumWeightExplicitlyAssigned = false;
        private int _minimumWeight;

        /// <summary>
        /// The preferred minimum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="minimumWeight")]
        public int MinimumWeight 
        { 
            get => _minimumWeight;
            set 
            { 
                _minimumWeight = value;
                _minimumWeightExplicitlyAssigned = true; 
            }
        }

        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_maximumWeightExplicitlyAssigned)
            {
                yield return "MaximumWeight";
            }
            if (!_minimumWeightExplicitlyAssigned)
            {
                yield return "MinimumWeight";
            }
        }

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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentAquaticPet : Entities.Common.Sample.IStudentAquaticPet, IHasRequiredMembersWithMeaningfulDefaultValues
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
        
        private bool _mimimumTankVolumeExplicitlyAssigned = false;
        private int _mimimumTankVolume;

        /// <summary>
        /// The minimum tank volume this aquatic pet requires.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="mimimumTankVolume"), NaturalKeyMember]
        public int MimimumTankVolume 
        { 
            get => _mimimumTankVolume;
            set 
            { 
                _mimimumTankVolume = value;
                _mimimumTankVolumeExplicitlyAssigned = true; 
            }
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
            var compareTo = obj as Entities.Common.Sample.IStudentAquaticPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume.Equals(compareTo.MimimumTankVolume))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentAquaticPet).PetName.Equals(compareTo.PetName))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentExtension != null)
                hash.Add(_studentExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentAquaticPet).MimimumTankVolume);


            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentAquaticPet).PetName);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_mimimumTankVolumeExplicitlyAssigned)
            {
                yield return "MimimumTankVolume";
            }
        }

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
    public class StudentExtension : Entities.Common.Sample.IStudentExtension
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
            var compareTo = obj as Entities.Common.Sample.IStudentExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_student == null || !_student.Equals(compareTo.Student))
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
            var hash = new HashCode();
            //Parent Property
            if (_student != null)
                hash.Add(_student);
            return hash.ToHashCode();
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
        private static readonly FullName _fullName_sample_StudentExtension = new FullName("sample", "StudentExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentAquaticPetIncluded != null)
                {
                    var hasInvalidStudentAquaticPetsItems = instance.StudentAquaticPets.Any(x => !mappingContract.Value.IsStudentAquaticPetIncluded(x));
        
                    if (hasInvalidStudentAquaticPetsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentAquaticPet", $"A supplied 'StudentAquaticPet' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentFavoriteBookIncluded != null)
                {
                    var hasInvalidStudentFavoriteBooksItems = instance.StudentFavoriteBooks.Any(x => !mappingContract.Value.IsStudentFavoriteBookIncluded(x));
        
                    if (hasInvalidStudentFavoriteBooksItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentFavoriteBook", $"A supplied 'StudentFavoriteBook' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentPetIncluded != null)
                {
                    var hasInvalidStudentPetsItems = instance.StudentPets.Any(x => !mappingContract.Value.IsStudentPetIncluded(x));
        
                    if (hasInvalidStudentPetsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentPet", $"A supplied 'StudentPet' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StudentFavoriteBook : Entities.Common.Sample.IStudentFavoriteBook
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
            var compareTo = obj as Entities.Common.Sample.IStudentFavoriteBook;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor.Equals(compareTo.FavoriteBookCategoryDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentExtension != null)
                hash.Add(_studentExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentFavoriteBook).FavoriteBookCategoryDescriptor);

            return hash.ToHashCode();
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
        private static readonly FullName _fullName_sample_StudentFavoriteBook = new FullName("sample", "StudentFavoriteBook");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentFavoriteBook> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentFavoriteBookMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentFavoriteBookMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentFavoriteBook));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentFavoriteBookArtMediumIncluded != null)
                {
                    var hasInvalidStudentFavoriteBookArtMediaItems = instance.StudentFavoriteBookArtMedia.Any(x => !mappingContract.Value.IsStudentFavoriteBookArtMediumIncluded(x));
        
                    if (hasInvalidStudentFavoriteBookArtMediaItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentFavoriteBookArtMedium", $"A supplied 'StudentFavoriteBookArtMedium' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StudentFavoriteBookArtMedium : Entities.Common.Sample.IStudentFavoriteBookArtMedium
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
            var compareTo = obj as Entities.Common.Sample.IStudentFavoriteBookArtMedium;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentFavoriteBook == null || !_studentFavoriteBook.Equals(compareTo.StudentFavoriteBook))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor.Equals(compareTo.ArtMediumDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentFavoriteBook != null)
                hash.Add(_studentFavoriteBook);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentFavoriteBookArtMedium).ArtMediumDescriptor);

            return hash.ToHashCode();
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
    public class StudentPet : Entities.Common.Sample.IStudentPet
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
            var compareTo = obj as Entities.Common.Sample.IStudentPet;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentPet).PetName.Equals(compareTo.PetName))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentExtension != null)
                hash.Add(_studentExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentPet).PetName);

            return hash.ToHashCode();
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentPetPreference : Entities.Common.Sample.IStudentPetPreference, IHasRequiredMembersWithMeaningfulDefaultValues
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
            var compareTo = obj as Entities.Common.Sample.IStudentPetPreference;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentExtension == null || !_studentExtension.Equals(compareTo.StudentExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentExtension != null)
                hash.Add(_studentExtension);
            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        
        private bool _maximumWeightExplicitlyAssigned = false;
        private int _maximumWeight;

        /// <summary>
        /// The preferred maximum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="maximumWeight")]
        public int MaximumWeight 
        { 
            get => _maximumWeight;
            set 
            { 
                _maximumWeight = value;
                _maximumWeightExplicitlyAssigned = true; 
            }
        }

        
        private bool _minimumWeightExplicitlyAssigned = false;
        private int _minimumWeight;

        /// <summary>
        /// The preferred minimum weight of a household pet.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="minimumWeight")]
        public int MinimumWeight 
        { 
            get => _minimumWeight;
            set 
            { 
                _minimumWeight = value;
                _minimumWeightExplicitlyAssigned = true; 
            }
        }

        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_maximumWeightExplicitlyAssigned)
            {
                yield return "MaximumWeight";
            }
            if (!_minimumWeightExplicitlyAssigned)
            {
                yield return "MinimumWeight";
            }
        }

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
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }

        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public long EducationOrganizationId { get; set; }

        [DataMember(Name="programEducationOrganizationId"), NaturalKeyMember]
        public long ProgramEducationOrganizationId { get; set; }

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
            return BeginDate != default(DateTime) && EducationOrganizationId != default(long) && ProgramEducationOrganizationId != default(long) && ProgramName != default(string) && ProgramTypeDescriptor != default(string) && StudentUniqueId != default(string);
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentArtProgramAssociation : Entities.Common.Sample.IStudentArtProgramAssociation, Entities.Common.EdFi.IGeneralStudentProgramAssociation, IHasETag, IDateVersionedEntity, IHasRequiredMembersWithMeaningfulDefaultValues
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

            // Inherited lists
            GeneralStudentProgramAssociationProgramParticipationStatuses = new List<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>();
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
        long Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitEducationOrganizationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference.EducationOrganizationId;

                return default(long);
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
        long Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.EducationOrganizationId;

                return default(long);
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
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
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
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate.Equals(compareTo.BeginDate))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId.Equals(compareTo.ProgramEducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName.Equals(compareTo.ProgramName))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor.Equals(compareTo.ProgramTypeDescriptor))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
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
            var hash = new HashCode();

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).BeginDate);


            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).EducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramEducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramName);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).ProgramTypeDescriptor);


            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociation).StudentUniqueId);
            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The month, day, and year on which the student exited the program or stopped receiving services.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The reason the student left the program within a school or district.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="reasonExitedDescriptor")]
        public string ReasonExitedDescriptor { get; set; }

        /// <summary>
        /// Indicates whether the student received services during the summer session or between sessions.
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
        [DataMember(Name="hoursPerDay")]
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
        [DataMember(Name="masteredMediums")]
        public decimal? MasteredMediums { get; set; }

        /// <summary>
        /// Number of days the student is in attendance at the program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="numberOfDaysInAttendance")]
        public decimal? NumberOfDaysInAttendance { get; set; }

        /// <summary>
        /// The total number of pieces in the student's portfolio.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="portfolioPieces")]
        public int? PortfolioPieces { get; set; }
        
        private bool _privateArtProgramExplicitlyAssigned = false;
        private bool _privateArtProgram;

        /// <summary>
        /// Indicator that the student participated in art education at a private agency or institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="privateArtProgram")]
        public bool PrivateArtProgram 
        { 
            get => _privateArtProgram;
            set 
            { 
                _privateArtProgram = value;
                _privateArtProgramExplicitlyAssigned = true; 
            }
        }


        /// <summary>
        /// Required program fees to purchase materials for the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="programFees")]
        public decimal? ProgramFees { get; set; }
        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_privateArtProgramExplicitlyAssigned)
            {
                yield return "PrivateArtProgram";
            }
        }

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
        private ICollection<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus> _generalStudentProgramAssociationProgramParticipationStatuses;
        private ICollection<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus> _generalStudentProgramAssociationProgramParticipationStatusesCovariant;

        [DataMember(Name="programParticipationStatuses"), NoDuplicateMembers]
        public ICollection<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus> GeneralStudentProgramAssociationProgramParticipationStatuses
        {
            get { return _generalStudentProgramAssociationProgramParticipationStatuses; }
            set
            {
                _generalStudentProgramAssociationProgramParticipationStatuses = value;
                _generalStudentProgramAssociationProgramParticipationStatusesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus, GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus> Entities.Common.EdFi.IGeneralStudentProgramAssociation.GeneralStudentProgramAssociationProgramParticipationStatuses
        {
            get { return _generalStudentProgramAssociationProgramParticipationStatusesCovariant; }
            set { GeneralStudentProgramAssociationProgramParticipationStatuses = new List<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>(value.Cast<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>()); }
        }
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _generalStudentProgramAssociationProgramParticipationStatuses
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
        private static readonly FullName _fullName_sample_StudentArtProgramAssociation = new FullName("sample", "StudentArtProgramAssociation");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentArtProgramAssociation> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentArtProgramAssociationMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentArtProgramAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentArtProgramAssociation));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentArtProgramAssociationArtMediumIncluded != null)
                {
                    var hasInvalidStudentArtProgramAssociationArtMediaItems = instance.StudentArtProgramAssociationArtMedia.Any(x => !mappingContract.Value.IsStudentArtProgramAssociationArtMediumIncluded(x));
        
                    if (hasInvalidStudentArtProgramAssociationArtMediaItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentArtProgramAssociationArtMedium", $"A supplied 'StudentArtProgramAssociationArtMedium' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentArtProgramAssociationPortfolioYearsIncluded != null)
                {
                    var hasInvalidStudentArtProgramAssociationPortfolioYearsItems = instance.StudentArtProgramAssociationPortfolioYears.Any(x => !mappingContract.Value.IsStudentArtProgramAssociationPortfolioYearsIncluded(x));
        
                    if (hasInvalidStudentArtProgramAssociationPortfolioYearsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentArtProgramAssociationPortfolioYears", $"A supplied 'StudentArtProgramAssociationPortfolioYears' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentArtProgramAssociationServiceIncluded != null)
                {
                    var hasInvalidStudentArtProgramAssociationServicesItems = instance.StudentArtProgramAssociationServices.Any(x => !mappingContract.Value.IsStudentArtProgramAssociationServiceIncluded(x));
        
                    if (hasInvalidStudentArtProgramAssociationServicesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentArtProgramAssociationService", $"A supplied 'StudentArtProgramAssociationService' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentArtProgramAssociationStyleIncluded != null)
                {
                    var hasInvalidStudentArtProgramAssociationStylesItems = instance.StudentArtProgramAssociationStyles.Any(x => !mappingContract.Value.IsStudentArtProgramAssociationStyleIncluded(x));
        
                    if (hasInvalidStudentArtProgramAssociationStylesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentArtProgramAssociationStyle", $"A supplied 'StudentArtProgramAssociationStyle' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded != null)
                {
                    var hasInvalidGeneralStudentProgramAssociationProgramParticipationStatusesItems = instance.GeneralStudentProgramAssociationProgramParticipationStatuses.Any(x => !mappingContract.Value.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded(x));
        
                    if (hasInvalidGeneralStudentProgramAssociationProgramParticipationStatusesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("GeneralStudentProgramAssociationProgramParticipationStatus", $"A supplied 'GeneralStudentProgramAssociationProgramParticipationStatus' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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

            var generalStudentProgramAssociationProgramParticipationStatusesValidator = new GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatusPutPostRequestValidator();

            foreach (var item in instance.GeneralStudentProgramAssociationProgramParticipationStatuses)
            {
                var validationResult = generalStudentProgramAssociationProgramParticipationStatusesValidator.Validate(item);

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
    public class StudentArtProgramAssociationArtMedium : Entities.Common.Sample.IStudentArtProgramAssociationArtMedium
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
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor.Equals(compareTo.ArtMediumDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentArtProgramAssociation != null)
                hash.Add(_studentArtProgramAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociationArtMedium).ArtMediumDescriptor);

            return hash.ToHashCode();
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentArtProgramAssociationPortfolioYears : Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears, IHasRequiredMembersWithMeaningfulDefaultValues
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
        
        private bool _portfolioYearsExplicitlyAssigned = false;
        private short _portfolioYears;

        /// <summary>
        /// The of year(s) of work included in the student's portfolio.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="portfolioYears"), NaturalKeyMember]
        public short PortfolioYears 
        { 
            get => _portfolioYears;
            set 
            { 
                _portfolioYears = value;
                _portfolioYearsExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears.Equals(compareTo.PortfolioYears))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentArtProgramAssociation != null)
                hash.Add(_studentArtProgramAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociationPortfolioYears).PortfolioYears);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_portfolioYearsExplicitlyAssigned)
            {
                yield return "PortfolioYears";
            }
        }

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
    public class StudentArtProgramAssociationService : Entities.Common.Sample.IStudentArtProgramAssociationService
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
        /// Indicates the service being provided to the student by the program.
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
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationService;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor.Equals(compareTo.ServiceDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentArtProgramAssociation != null)
                hash.Add(_studentArtProgramAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociationService).ServiceDescriptor);

            return hash.ToHashCode();
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
        /// First date the student was in this option for the current school year.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="serviceBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ServiceBeginDate { get; set; }

        /// <summary>
        /// Last date the student was in this option for the current school year.
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
    public class StudentArtProgramAssociationStyle : Entities.Common.Sample.IStudentArtProgramAssociationStyle
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
            var compareTo = obj as Entities.Common.Sample.IStudentArtProgramAssociationStyle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentArtProgramAssociation == null || !_studentArtProgramAssociation.Equals(compareTo.StudentArtProgramAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style.Equals(compareTo.Style))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentArtProgramAssociation != null)
                hash.Add(_studentArtProgramAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentArtProgramAssociationStyle).Style);

            return hash.ToHashCode();
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
// Aggregate: StudentContactAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentContactAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentContactAssociationDiscipline table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentContactAssociationDiscipline : Entities.Common.Sample.IStudentContactAssociationDiscipline
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationDiscipline.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
        }

        /// <summary>
        /// The type of action used to discipline the student preferred by the contact.
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationDiscipline;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentContactAssociationDiscipline).DisciplineDescriptor.Equals(compareTo.DisciplineDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentContactAssociationDiscipline).DisciplineDescriptor);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.StudentContactAssociationDisciplineMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationDiscipline)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationDisciplineMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationDiscipline)target, null);
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
    public class StudentContactAssociationDisciplinePutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationDiscipline>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationDiscipline> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.StudentContactAssociationExtension table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentContactAssociationExtension : Entities.Common.Sample.IStudentContactAssociationExtension, IHasRequiredMembersWithMeaningfulDefaultValues
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentContactAssociationExtension()
        {
            StudentContactAssociationDisciplines = new List<StudentContactAssociationDiscipline>();
            StudentContactAssociationFavoriteBookTitles = new List<StudentContactAssociationFavoriteBookTitle>();
            StudentContactAssociationHoursPerWeeks = new List<StudentContactAssociationHoursPerWeek>();
            StudentContactAssociationPagesReads = new List<StudentContactAssociationPagesRead>();
            StudentContactAssociationStaffEducationOrganizationEmploymentAssociations = new List<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>();
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
        private Entities.Common.EdFi.IStudentContactAssociation _studentContactAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentContactAssociation Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociation
        {
            get { return _studentContactAssociation; }
            set { SetStudentContactAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentContactAssociation StudentContactAssociation
        {
            set { SetStudentContactAssociation(value); }
        }

        private void SetStudentContactAssociation(Entities.Common.EdFi.IStudentContactAssociation value)
        {
            _studentContactAssociation = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociation == null || !_studentContactAssociation.Equals(compareTo.StudentContactAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociation != null)
                hash.Add(_studentContactAssociation);
            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        
        private bool _bedtimeReaderExplicitlyAssigned = false;
        private bool _bedtimeReader;

        /// <summary>
        /// An indication as to whether the contact regularly reads to the student before bed.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bedtimeReader")]
        public bool BedtimeReader 
        { 
            get => _bedtimeReader;
            set 
            { 
                _bedtimeReader = value;
                _bedtimeReaderExplicitlyAssigned = true; 
            }
        }


        /// <summary>
        /// The average number of pages the contact reads with the student each day.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bedtimeReadingRate")]
        public decimal? BedtimeReadingRate { get; set; }

        /// <summary>
        /// The contact's estimated monthly budget dedicated to books for the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="bookBudget")]
        public decimal? BookBudget { get; set; }

        /// <summary>
        /// The total number of books the contact has borrowed on behalf of the student to date.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="booksBorrowed")]
        public int? BooksBorrowed { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long? Entities.Common.Sample.IStudentContactAssociationExtension.EducationOrganizationId
        {
            get
            {
                if (ImplicitInterventionStudyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitInterventionStudyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitInterventionStudyReference.EducationOrganizationId;
                    }

                return default(long?);
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
        string Entities.Common.Sample.IStudentContactAssociationExtension.InterventionStudyIdentificationCode
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
        /// Date on which the contact first read the student Green Eggs and Ham by Dr. Seuss.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="readGreenEggsAndHamDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ReadGreenEggsAndHamDate { get; set; }

        /// <summary>
        /// The amount of time the contact spends reading to the student each day.
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_bedtimeReaderExplicitlyAssigned)
            {
                yield return "BedtimeReader";
            }
        }

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// telephone
        /// </summary>
        [DataMember(Name = "telephone")]
        public StudentContactAssociationTelephone StudentContactAssociationTelephone { get; set; }

        Entities.Common.Sample.IStudentContactAssociationTelephone Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationTelephone
        {
            get { return StudentContactAssociationTelephone; }
            set { StudentContactAssociationTelephone = (StudentContactAssociationTelephone) value; }
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
        private ICollection<StudentContactAssociationDiscipline> _studentContactAssociationDisciplines;
        private ICollection<Entities.Common.Sample.IStudentContactAssociationDiscipline> _studentContactAssociationDisciplinesCovariant;

        [DataMember(Name="disciplines"), NoDuplicateMembers]
        public ICollection<StudentContactAssociationDiscipline> StudentContactAssociationDisciplines
        {
            get { return _studentContactAssociationDisciplines; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentContactAssociationDiscipline>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentContactAssociationDiscipline)e.Item).StudentContactAssociationExtension = this);
                _studentContactAssociationDisciplines = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentContactAssociationDiscipline, StudentContactAssociationDiscipline>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentContactAssociationDiscipline)e.Item).StudentContactAssociationExtension = this;
                _studentContactAssociationDisciplinesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentContactAssociationDiscipline> Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationDisciplines
        {
            get { return _studentContactAssociationDisciplinesCovariant; }
            set { StudentContactAssociationDisciplines = new List<StudentContactAssociationDiscipline>(value.Cast<StudentContactAssociationDiscipline>()); }
        }

        private ICollection<StudentContactAssociationFavoriteBookTitle> _studentContactAssociationFavoriteBookTitles;
        private ICollection<Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle> _studentContactAssociationFavoriteBookTitlesCovariant;

        [DataMember(Name="favoriteBookTitles"), NoDuplicateMembers]
        public ICollection<StudentContactAssociationFavoriteBookTitle> StudentContactAssociationFavoriteBookTitles
        {
            get { return _studentContactAssociationFavoriteBookTitles; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentContactAssociationFavoriteBookTitle>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle)e.Item).StudentContactAssociationExtension = this);
                _studentContactAssociationFavoriteBookTitles = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle, StudentContactAssociationFavoriteBookTitle>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle)e.Item).StudentContactAssociationExtension = this;
                _studentContactAssociationFavoriteBookTitlesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle> Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationFavoriteBookTitles
        {
            get { return _studentContactAssociationFavoriteBookTitlesCovariant; }
            set { StudentContactAssociationFavoriteBookTitles = new List<StudentContactAssociationFavoriteBookTitle>(value.Cast<StudentContactAssociationFavoriteBookTitle>()); }
        }

        private ICollection<StudentContactAssociationHoursPerWeek> _studentContactAssociationHoursPerWeeks;
        private ICollection<Entities.Common.Sample.IStudentContactAssociationHoursPerWeek> _studentContactAssociationHoursPerWeeksCovariant;

        [DataMember(Name="hoursPerWeeks"), NoDuplicateMembers]
        public ICollection<StudentContactAssociationHoursPerWeek> StudentContactAssociationHoursPerWeeks
        {
            get { return _studentContactAssociationHoursPerWeeks; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentContactAssociationHoursPerWeek>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentContactAssociationHoursPerWeek)e.Item).StudentContactAssociationExtension = this);
                _studentContactAssociationHoursPerWeeks = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentContactAssociationHoursPerWeek, StudentContactAssociationHoursPerWeek>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentContactAssociationHoursPerWeek)e.Item).StudentContactAssociationExtension = this;
                _studentContactAssociationHoursPerWeeksCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentContactAssociationHoursPerWeek> Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationHoursPerWeeks
        {
            get { return _studentContactAssociationHoursPerWeeksCovariant; }
            set { StudentContactAssociationHoursPerWeeks = new List<StudentContactAssociationHoursPerWeek>(value.Cast<StudentContactAssociationHoursPerWeek>()); }
        }

        private ICollection<StudentContactAssociationPagesRead> _studentContactAssociationPagesReads;
        private ICollection<Entities.Common.Sample.IStudentContactAssociationPagesRead> _studentContactAssociationPagesReadsCovariant;

        [DataMember(Name="pagesReads"), NoDuplicateMembers]
        public ICollection<StudentContactAssociationPagesRead> StudentContactAssociationPagesReads
        {
            get { return _studentContactAssociationPagesReads; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentContactAssociationPagesRead>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentContactAssociationPagesRead)e.Item).StudentContactAssociationExtension = this);
                _studentContactAssociationPagesReads = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentContactAssociationPagesRead, StudentContactAssociationPagesRead>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentContactAssociationPagesRead)e.Item).StudentContactAssociationExtension = this;
                _studentContactAssociationPagesReadsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentContactAssociationPagesRead> Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationPagesReads
        {
            get { return _studentContactAssociationPagesReadsCovariant; }
            set { StudentContactAssociationPagesReads = new List<StudentContactAssociationPagesRead>(value.Cast<StudentContactAssociationPagesRead>()); }
        }

        private ICollection<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation> _studentContactAssociationStaffEducationOrganizationEmploymentAssociations;
        private ICollection<Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation> _studentContactAssociationStaffEducationOrganizationEmploymentAssociationsCovariant;

        [DataMember(Name="staffEducationOrganizationEmploymentAssociations"), NoDuplicateMembers]
        public ICollection<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation> StudentContactAssociationStaffEducationOrganizationEmploymentAssociations
        {
            get { return _studentContactAssociationStaffEducationOrganizationEmploymentAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation)e.Item).StudentContactAssociationExtension = this);
                _studentContactAssociationStaffEducationOrganizationEmploymentAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation, StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation)e.Item).StudentContactAssociationExtension = this;
                _studentContactAssociationStaffEducationOrganizationEmploymentAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation> Entities.Common.Sample.IStudentContactAssociationExtension.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations
        {
            get { return _studentContactAssociationStaffEducationOrganizationEmploymentAssociationsCovariant; }
            set { StudentContactAssociationStaffEducationOrganizationEmploymentAssociations = new List<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>(value.Cast<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>()); }
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
            if (_studentContactAssociationDisciplines != null) foreach (var item in _studentContactAssociationDisciplines)
            {
                item.StudentContactAssociationExtension = this;
            }

            if (_studentContactAssociationFavoriteBookTitles != null) foreach (var item in _studentContactAssociationFavoriteBookTitles)
            {
                item.StudentContactAssociationExtension = this;
            }

            if (_studentContactAssociationHoursPerWeeks != null) foreach (var item in _studentContactAssociationHoursPerWeeks)
            {
                item.StudentContactAssociationExtension = this;
            }

            if (_studentContactAssociationPagesReads != null) foreach (var item in _studentContactAssociationPagesReads)
            {
                item.StudentContactAssociationExtension = this;
            }

            if (_studentContactAssociationStaffEducationOrganizationEmploymentAssociations != null) foreach (var item in _studentContactAssociationStaffEducationOrganizationEmploymentAssociations)
            {
                item.StudentContactAssociationExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentContactAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationExtension)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentContactAssociationExtension.InterventionStudyResourceId
        {
            get { return null; }
            set { ImplicitInterventionStudyReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentContactAssociationExtension.InterventionStudyDiscriminator
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
    public class StudentContactAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationExtension>
    {
        private static readonly FullName _fullName_sample_StudentContactAssociationExtension = new FullName("sample", "StudentContactAssociationExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentContactAssociationExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentContactAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentContactAssociationExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentContactAssociationDisciplineIncluded != null)
                {
                    var hasInvalidStudentContactAssociationDisciplinesItems = instance.StudentContactAssociationDisciplines.Any(x => !mappingContract.Value.IsStudentContactAssociationDisciplineIncluded(x));
        
                    if (hasInvalidStudentContactAssociationDisciplinesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentContactAssociationDiscipline", $"A supplied 'StudentContactAssociationDiscipline' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentContactAssociationFavoriteBookTitleIncluded != null)
                {
                    var hasInvalidStudentContactAssociationFavoriteBookTitlesItems = instance.StudentContactAssociationFavoriteBookTitles.Any(x => !mappingContract.Value.IsStudentContactAssociationFavoriteBookTitleIncluded(x));
        
                    if (hasInvalidStudentContactAssociationFavoriteBookTitlesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentContactAssociationFavoriteBookTitle", $"A supplied 'StudentContactAssociationFavoriteBookTitle' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentContactAssociationHoursPerWeekIncluded != null)
                {
                    var hasInvalidStudentContactAssociationHoursPerWeeksItems = instance.StudentContactAssociationHoursPerWeeks.Any(x => !mappingContract.Value.IsStudentContactAssociationHoursPerWeekIncluded(x));
        
                    if (hasInvalidStudentContactAssociationHoursPerWeeksItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentContactAssociationHoursPerWeek", $"A supplied 'StudentContactAssociationHoursPerWeek' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentContactAssociationPagesReadIncluded != null)
                {
                    var hasInvalidStudentContactAssociationPagesReadsItems = instance.StudentContactAssociationPagesReads.Any(x => !mappingContract.Value.IsStudentContactAssociationPagesReadIncluded(x));
        
                    if (hasInvalidStudentContactAssociationPagesReadsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentContactAssociationPagesRead", $"A supplied 'StudentContactAssociationPagesRead' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded != null)
                {
                    var hasInvalidStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItems = instance.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations.Any(x => !mappingContract.Value.IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded(x));
        
                    if (hasInvalidStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentContactAssociationStaffEducationOrganizationEmploymentAssociation", $"A supplied 'StudentContactAssociationStaffEducationOrganizationEmploymentAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
            // -----------------------
            //  Validate unified keys
            // -----------------------

            // Recursively invoke the child collection item validators
            var studentContactAssociationDisciplinesValidator = new StudentContactAssociationDisciplinePutPostRequestValidator();

            foreach (var item in instance.StudentContactAssociationDisciplines)
            {
                var validationResult = studentContactAssociationDisciplinesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentContactAssociationFavoriteBookTitlesValidator = new StudentContactAssociationFavoriteBookTitlePutPostRequestValidator();

            foreach (var item in instance.StudentContactAssociationFavoriteBookTitles)
            {
                var validationResult = studentContactAssociationFavoriteBookTitlesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentContactAssociationHoursPerWeeksValidator = new StudentContactAssociationHoursPerWeekPutPostRequestValidator();

            foreach (var item in instance.StudentContactAssociationHoursPerWeeks)
            {
                var validationResult = studentContactAssociationHoursPerWeeksValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentContactAssociationPagesReadsValidator = new StudentContactAssociationPagesReadPutPostRequestValidator();

            foreach (var item in instance.StudentContactAssociationPagesReads)
            {
                var validationResult = studentContactAssociationPagesReadsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var studentContactAssociationStaffEducationOrganizationEmploymentAssociationsValidator = new StudentContactAssociationStaffEducationOrganizationEmploymentAssociationPutPostRequestValidator();

            foreach (var item in instance.StudentContactAssociationStaffEducationOrganizationEmploymentAssociations)
            {
                var validationResult = studentContactAssociationStaffEducationOrganizationEmploymentAssociationsValidator.Validate(item);

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
    /// A class which represents the sample.StudentContactAssociationFavoriteBookTitle table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentContactAssociationFavoriteBookTitle : Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle).FavoriteBookTitle.Equals(compareTo.FavoriteBookTitle))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle).FavoriteBookTitle);

            return hash.ToHashCode();
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
            return Entities.Common.Sample.StudentContactAssociationFavoriteBookTitleMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationFavoriteBookTitleMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationFavoriteBookTitle)target, null);
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
    public class StudentContactAssociationFavoriteBookTitlePutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationFavoriteBookTitle>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationFavoriteBookTitle> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.StudentContactAssociationHoursPerWeek table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentContactAssociationHoursPerWeek : Entities.Common.Sample.IStudentContactAssociationHoursPerWeek, IHasRequiredMembersWithMeaningfulDefaultValues
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationHoursPerWeek.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
        }
        
        private bool _hoursPerWeekExplicitlyAssigned = false;
        private decimal _hoursPerWeek;

        /// <summary>
        /// Total number of hours per week a student and contact dedicates to reading.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek"), NaturalKeyMember]
        public decimal HoursPerWeek 
        { 
            get => _hoursPerWeek;
            set 
            { 
                _hoursPerWeek = value;
                _hoursPerWeekExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationHoursPerWeek;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentContactAssociationHoursPerWeek).HoursPerWeek.Equals(compareTo.HoursPerWeek))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentContactAssociationHoursPerWeek).HoursPerWeek);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_hoursPerWeekExplicitlyAssigned)
            {
                yield return "HoursPerWeek";
            }
        }

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
            return Entities.Common.Sample.StudentContactAssociationHoursPerWeekMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationHoursPerWeek)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationHoursPerWeekMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationHoursPerWeek)target, null);
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
    public class StudentContactAssociationHoursPerWeekPutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationHoursPerWeek>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationHoursPerWeek> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.StudentContactAssociationPagesRead table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentContactAssociationPagesRead : Entities.Common.Sample.IStudentContactAssociationPagesRead, IHasRequiredMembersWithMeaningfulDefaultValues
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationPagesRead.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
        }
        
        private bool _pagesReadExplicitlyAssigned = false;
        private decimal _pagesRead;

        /// <summary>
        /// Total number of pages the contact has read the student.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="pagesRead"), NaturalKeyMember]
        public decimal PagesRead 
        { 
            get => _pagesRead;
            set 
            { 
                _pagesRead = value;
                _pagesReadExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationPagesRead;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentContactAssociationPagesRead).PagesRead.Equals(compareTo.PagesRead))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentContactAssociationPagesRead).PagesRead);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_pagesReadExplicitlyAssigned)
            {
                yield return "PagesRead";
            }
        }

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
            return Entities.Common.Sample.StudentContactAssociationPagesReadMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationPagesRead)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationPagesReadMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationPagesRead)target, null);
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
    public class StudentContactAssociationPagesReadPutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationPagesRead>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationPagesRead> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.StudentContactAssociationStaffEducationOrganizationEmploymentAssociation table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentContactAssociationStaffEducationOrganizationEmploymentAssociation : Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitStaffEducationOrganizationEmploymentAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffEducationOrganizationEmploymentAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStaffEducationOrganizationEmploymentAssociationReference.EducationOrganizationId;

                return default(long);
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
        /// Reflects the type of employment or contract.
        /// </summary>

        // IS in a reference (StudentContactAssociationStaffEducationOrganizationEmploymentAssociation.EmploymentStatusDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.EmploymentStatusDescriptor
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
        DateTime Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.HireDate
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
        string Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.StaffUniqueId
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor.Equals(compareTo.EmploymentStatusDescriptor))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).HireDate.Equals(compareTo.HireDate))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId.Equals(compareTo.StaffUniqueId))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).EducationOrganizationId);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).EmploymentStatusDescriptor);


            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).HireDate);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation).StaffUniqueId);
            return hash.ToHashCode();
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
            return Entities.Common.Sample.StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationResourceId
        {
            get { return null; }
            set { ImplicitStaffEducationOrganizationEmploymentAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation.StaffEducationOrganizationEmploymentAssociationDiscriminator
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
    public class StudentContactAssociationStaffEducationOrganizationEmploymentAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationStaffEducationOrganizationEmploymentAssociation> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the sample.StudentContactAssociationTelephone table of the StudentContactAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentContactAssociationTelephone : Entities.Common.Sample.IStudentContactAssociationTelephone
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
        private Entities.Common.Sample.IStudentContactAssociationExtension _studentContactAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentContactAssociationExtension Entities.Common.Sample.IStudentContactAssociationTelephone.StudentContactAssociationExtension
        {
            get { return _studentContactAssociationExtension; }
            set { SetStudentContactAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentContactAssociationExtension StudentContactAssociationExtension
        {
            set { SetStudentContactAssociationExtension(value); }
        }

        private void SetStudentContactAssociationExtension(Entities.Common.Sample.IStudentContactAssociationExtension value)
        {
            _studentContactAssociationExtension = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentContactAssociationTelephone;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentContactAssociationExtension == null || !_studentContactAssociationExtension.Equals(compareTo.StudentContactAssociationExtension))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentContactAssociationExtension != null)
                hash.Add(_studentContactAssociationExtension);
            return hash.ToHashCode();
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
            return Entities.Common.Sample.StudentContactAssociationTelephoneMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentContactAssociationTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentContactAssociationTelephoneMapper.MapTo(this, (Entities.Common.Sample.IStudentContactAssociationTelephone)target, null);
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
    public class StudentContactAssociationTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<StudentContactAssociationTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentContactAssociationTelephone> context, FluentValidation.Results.ValidationResult result)
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
    public class StudentCTEProgramAssociationExtension : Entities.Common.Sample.IStudentCTEProgramAssociationExtension
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
            var compareTo = obj as Entities.Common.Sample.IStudentCTEProgramAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentCTEProgramAssociation == null || !_studentCTEProgramAssociation.Equals(compareTo.StudentCTEProgramAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentCTEProgramAssociation != null)
                hash.Add(_studentCTEProgramAssociation);
            return hash.ToHashCode();
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentEducationOrganizationAssociationAddressExtension : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension, IHasRequiredMembersWithMeaningfulDefaultValues
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddress == null || !_studentEducationOrganizationAssociationAddress.Equals(compareTo.StudentEducationOrganizationAssociationAddress))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociationAddress != null)
                hash.Add(_studentEducationOrganizationAssociationAddress);
            return hash.ToHashCode();
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
        
        private bool _onBusRouteExplicitlyAssigned = false;
        private bool _onBusRoute;

        /// <summary>
        /// An indicator if the address is on a bus route.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="onBusRoute")]
        public bool OnBusRoute 
        { 
            get => _onBusRoute;
            set 
            { 
                _onBusRoute = value;
                _onBusRouteExplicitlyAssigned = true; 
            }
        }

        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_onBusRouteExplicitlyAssigned)
            {
                yield return "OnBusRoute";
            }
        }

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
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationAddressExtension = new FullName("sample", "StudentEducationOrganizationAssociationAddressExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationAddressExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentEducationOrganizationAssociationAddressExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentEducationOrganizationAssociationAddressExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationAddressExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded != null)
                {
                    var hasInvalidStudentEducationOrganizationAssociationAddressSchoolDistrictsItems = instance.StudentEducationOrganizationAssociationAddressSchoolDistricts.Any(x => !mappingContract.Value.IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded(x));
        
                    if (hasInvalidStudentEducationOrganizationAssociationAddressSchoolDistrictsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentEducationOrganizationAssociationAddressSchoolDistrict", $"A supplied 'StudentEducationOrganizationAssociationAddressSchoolDistrict' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentEducationOrganizationAssociationAddressTermIncluded != null)
                {
                    var hasInvalidStudentEducationOrganizationAssociationAddressTermsItems = instance.StudentEducationOrganizationAssociationAddressTerms.Any(x => !mappingContract.Value.IsStudentEducationOrganizationAssociationAddressTermIncluded(x));
        
                    if (hasInvalidStudentEducationOrganizationAssociationAddressTermsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentEducationOrganizationAssociationAddressTerm", $"A supplied 'StudentEducationOrganizationAssociationAddressTerm' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StudentEducationOrganizationAssociationAddressSchoolDistrict : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension == null || !_studentEducationOrganizationAssociationAddressExtension.Equals(compareTo.StudentEducationOrganizationAssociationAddressExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict.Equals(compareTo.SchoolDistrict))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension != null)
                hash.Add(_studentEducationOrganizationAssociationAddressExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressSchoolDistrict).SchoolDistrict);

            return hash.ToHashCode();
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
    public class StudentEducationOrganizationAssociationAddressTerm : Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension == null || !_studentEducationOrganizationAssociationAddressExtension.Equals(compareTo.StudentEducationOrganizationAssociationAddressExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor.Equals(compareTo.TermDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociationAddressExtension != null)
                hash.Add(_studentEducationOrganizationAssociationAddressExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationAddressTerm).TermDescriptor);

            return hash.ToHashCode();
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
    /// Represents a reference from the StudentEducationOrganizationAssociationExtension entity to the Program resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationExtensionToProgramReference
    {
        private Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension backReference;

        // Parameterless constructor for deserialization
        public StudentEducationOrganizationAssociationExtensionToProgramReference() { }

        // Constructor for inline initialization in parent
        public StudentEducationOrganizationAssociationExtensionToProgramReference(Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension backReference)
        {
            this.backReference = backReference;
        }

        // Expose back reference internally for access after JSON deserialization to enable link generation
        internal Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension BackReference
        {
            get { return backReference; }
            set { backReference = value; }
        }

        private long _educationOrganizationId;

        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public long EducationOrganizationId
        {
            get => _educationOrganizationId == default(long)
                    ? BackReference.StudentEducationOrganizationAssociation.EducationOrganizationId
                    : _educationOrganizationId;
            set => _educationOrganizationId = value;
        }

        [DataMember(Name="name"), NaturalKeyMember]
        public string ProgramName { get; set; }

        [DataMember(Name="typeDescriptor"), NaturalKeyMember]
        public string ProgramTypeDescriptor { get; set; }

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
            return ProgramName != default(string)
                && ProgramTypeDescriptor != default(string)
                ;
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Program",
                Href = $"/ed-fi/programs/{ResourceId:n}"
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

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    }

    /// <summary>
    /// A class which represents the sample.StudentEducationOrganizationAssociationExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationExtension : Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension
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

        private bool _favoriteProgramReferenceExplicitlyAssigned;
        private StudentEducationOrganizationAssociationExtensionToProgramReference _favoriteProgramReference;
        private StudentEducationOrganizationAssociationExtensionToProgramReference ImplicitFavoriteProgramReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_favoriteProgramReference == null && !_favoriteProgramReferenceExplicitlyAssigned)
                    _favoriteProgramReference = new StudentEducationOrganizationAssociationExtensionToProgramReference(this);

                return _favoriteProgramReference;
            }
        }

        [DataMember(Name="favoriteProgramReference")]
        public StudentEducationOrganizationAssociationExtensionToProgramReference FavoriteProgramReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitFavoriteProgramReference != null
                    && (_favoriteProgramReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitFavoriteProgramReference.IsReferenceFullyDefined()))
                    return ImplicitFavoriteProgramReference;

                return null;
            }
            set
            {
                _favoriteProgramReferenceExplicitlyAssigned = true;
                _favoriteProgramReference = value;
                _favoriteProgramReference.BackReference = this;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentEducationOrganizationAssociation _studentEducationOrganizationAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentEducationOrganizationAssociation Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.StudentEducationOrganizationAssociation
        {
            get { return _studentEducationOrganizationAssociation; }
            set { SetStudentEducationOrganizationAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation
        {
            set { SetStudentEducationOrganizationAssociation(value); }
        }

        private void SetStudentEducationOrganizationAssociation(Entities.Common.EdFi.IStudentEducationOrganizationAssociation value)
        {
            _studentEducationOrganizationAssociation = value;

            // Initialize unified key values from parent context when reference is being formed by outbound mapper
            if (!_favoriteProgramReferenceExplicitlyAssigned)
            {
                ImplicitFavoriteProgramReference.EducationOrganizationId = _studentEducationOrganizationAssociation.EducationOrganizationId;
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociation == null || !_studentEducationOrganizationAssociation.Equals(compareTo.StudentEducationOrganizationAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociation != null)
                hash.Add(_studentEducationOrganizationAssociation);
            return hash.ToHashCode();
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
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramName
        {
            get
            {
                if (ImplicitFavoriteProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitFavoriteProgramReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitFavoriteProgramReference.ProgramName;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // FavoriteProgram
                _favoriteProgramReferenceExplicitlyAssigned = false;
                ImplicitFavoriteProgramReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (StudentEducationOrganizationAssociation.FavoriteProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramTypeDescriptor
        {
            get
            {
                if (ImplicitFavoriteProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitFavoriteProgramReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitFavoriteProgramReference.ProgramTypeDescriptor;
                    }

                return null;
            }
            set
            {
                ImplicitFavoriteProgramReference.ProgramTypeDescriptor = value;
            }
        }
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
            if (_favoriteProgramReference != null)
                _favoriteProgramReference.BackReference = this;
        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentEducationOrganizationAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentEducationOrganizationAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramResourceId
        {
            get { return null; }
            set { ImplicitFavoriteProgramReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension.FavoriteProgramDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitFavoriteProgramReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentEducationOrganizationAssociationExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationExtension> context, FluentValidation.Results.ValidationResult result)
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
            var sourcesForEducationOrganizationId = GetEducationOrganizationIdSources();

            if (!sourcesForEducationOrganizationId.Select(t => t.Item2).Where(v => !v.IsDefaultValue()).AllEqual())
            {
                failures.Add(new ValidationFailure("EducationOrganizationId",
                    $"Supplied values for unified key property 'educationOrganizationId' on 'StudentEducationOrganizationAssociationExtension' are not consistent: {string.Join(", ", sourcesForEducationOrganizationId.Select(x => $"{x.Item1} = {x.Item2}"))}"));
            }

            IEnumerable<Tuple<string, long>> GetEducationOrganizationIdSources()
            {
                // Obtain value from the parent
                yield return Tuple.Create("educationOrganizationId (from parent context)", (instance as Entities.Common.Sample.IStudentEducationOrganizationAssociationExtension).StudentEducationOrganizationAssociation.EducationOrganizationId);

                // Obtain value from other references
                var valueFromFavoriteProgramReference = instance.FavoriteProgramReference?.EducationOrganizationId;

                if (valueFromFavoriteProgramReference != null)
                {
                    yield return Tuple.Create("favoriteProgramReference.educationOrganizationId", instance.FavoriteProgramReference.EducationOrganizationId);
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
    /// A class which represents the sample.StudentEducationOrganizationAssociationStudentCharacteristicExtension table of the StudentEducationOrganizationAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationStudentCharacteristicExtension : Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristic == null || !_studentEducationOrganizationAssociationStudentCharacteristic.Equals(compareTo.StudentEducationOrganizationAssociationStudentCharacteristic))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristic != null)
                hash.Add(_studentEducationOrganizationAssociationStudentCharacteristic);
            return hash.ToHashCode();
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
        private static readonly FullName _fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicExtension = new FullName("sample", "StudentEducationOrganizationAssociationStudentCharacteristicExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentEducationOrganizationAssociationStudentCharacteristicExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentEducationOrganizationAssociationStudentCharacteristicExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded != null)
                {
                    var hasInvalidStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItems = instance.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds.Any(x => !mappingContract.Value.IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded(x));
        
                    if (hasInvalidStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed", $"A supplied 'StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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
    public class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed : Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed
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
            var compareTo = obj as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristicExtension == null || !_studentEducationOrganizationAssociationStudentCharacteristicExtension.Equals(compareTo.StudentEducationOrganizationAssociationStudentCharacteristicExtension))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate.Equals(compareTo.BeginDate))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentEducationOrganizationAssociationStudentCharacteristicExtension != null)
                hash.Add(_studentEducationOrganizationAssociationStudentCharacteristicExtension);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed).BeginDate);

            return hash.ToHashCode();
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
        public long EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(long) && GraduationPlanTypeDescriptor != default(string) && GraduationSchoolYear != default(short) && StudentUniqueId != default(string);
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentGraduationPlanAssociation : Entities.Common.Sample.IStudentGraduationPlanAssociation, IHasETag, IDateVersionedEntity, IHasRequiredMembersWithMeaningfulDefaultValues
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
            StudentGraduationPlanAssociationStudentContactAssociations = new List<StudentGraduationPlanAssociationStudentContactAssociation>();
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
        long Entities.Common.Sample.IStudentGraduationPlanAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitGraduationPlanReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitGraduationPlanReference.IsReferenceFullyDefined()))
                    return ImplicitGraduationPlanReference.EducationOrganizationId;

                return default(long);
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
        /// The type of academic plan the student is following for graduation.
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor.Equals(compareTo.GraduationPlanTypeDescriptor))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear.Equals(compareTo.GraduationSchoolYear))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId.Equals(compareTo.StudentUniqueId))
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
            var hash = new HashCode();

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).EducationOrganizationId);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationPlanTypeDescriptor);


            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).GraduationSchoolYear);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociation).StudentUniqueId);
            return hash.ToHashCode();
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
        [DataMember(Name="graduationFee")]
        public decimal? GraduationFee { get; set; }

        /// <summary>
        /// The number of years remaining prior to graduation as of when the plan became effective.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="highSchoolDuration")]
        public string HighSchoolDuration { get; set; }
        
        private bool _hoursPerWeekExplicitlyAssigned = false;
        private decimal _hoursPerWeek;

        /// <summary>
        /// The number of hours per week the student will attend to graduate.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hoursPerWeek")]
        public decimal HoursPerWeek 
        { 
            get => _hoursPerWeek;
            set 
            { 
                _hoursPerWeek = value;
                _hoursPerWeekExplicitlyAssigned = true; 
            }
        }


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
        [DataMember(Name="requiredAttendance")]
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
        
        private bool _targetGPAExplicitlyAssigned = false;
        private decimal _targetGPA;

        /// <summary>
        /// The GPA the student is working toward.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="targetGPA")]
        public decimal TargetGPA 
        { 
            get => _targetGPA;
            set 
            { 
                _targetGPA = value;
                _targetGPAExplicitlyAssigned = true; 
            }
        }

        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_hoursPerWeekExplicitlyAssigned)
            {
                yield return "HoursPerWeek";
            }
            if (!_targetGPAExplicitlyAssigned)
            {
                yield return "TargetGPA";
            }
        }

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

        private ICollection<StudentGraduationPlanAssociationStudentContactAssociation> _studentGraduationPlanAssociationStudentContactAssociations;
        private ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation> _studentGraduationPlanAssociationStudentContactAssociationsCovariant;

        [DataMember(Name="studentContactAssociations"), NoDuplicateMembers]
        public ICollection<StudentGraduationPlanAssociationStudentContactAssociation> StudentGraduationPlanAssociationStudentContactAssociations
        {
            get { return _studentGraduationPlanAssociationStudentContactAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentGraduationPlanAssociationStudentContactAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation)e.Item).StudentGraduationPlanAssociation = this);
                _studentGraduationPlanAssociationStudentContactAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation, StudentGraduationPlanAssociationStudentContactAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation)e.Item).StudentGraduationPlanAssociation = this;
                _studentGraduationPlanAssociationStudentContactAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation> Entities.Common.Sample.IStudentGraduationPlanAssociation.StudentGraduationPlanAssociationStudentContactAssociations
        {
            get { return _studentGraduationPlanAssociationStudentContactAssociationsCovariant; }
            set { StudentGraduationPlanAssociationStudentContactAssociations = new List<StudentGraduationPlanAssociationStudentContactAssociation>(value.Cast<StudentGraduationPlanAssociationStudentContactAssociation>()); }
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
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

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

            if (_studentGraduationPlanAssociationStudentContactAssociations != null) foreach (var item in _studentGraduationPlanAssociationStudentContactAssociations)
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
        private static readonly FullName _fullName_sample_StudentGraduationPlanAssociation = new FullName("sample", "StudentGraduationPlanAssociation");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociation> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentGraduationPlanAssociationMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentGraduationPlanAssociationMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentGraduationPlanAssociation));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentGraduationPlanAssociationAcademicSubjectIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationAcademicSubjectsItems = instance.StudentGraduationPlanAssociationAcademicSubjects.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationAcademicSubjectIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationAcademicSubjectsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationAcademicSubject", $"A supplied 'StudentGraduationPlanAssociationAcademicSubject' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationCareerPathwayCodesItems = instance.StudentGraduationPlanAssociationCareerPathwayCodes.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationCareerPathwayCodesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationCareerPathwayCode", $"A supplied 'StudentGraduationPlanAssociationCareerPathwayCode' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationDescriptionIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationDescriptionsItems = instance.StudentGraduationPlanAssociationDescriptions.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationDescriptionIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationDescriptionsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationDescription", $"A supplied 'StudentGraduationPlanAssociationDescription' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationDesignatedByIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationDesignatedBiesItems = instance.StudentGraduationPlanAssociationDesignatedBies.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationDesignatedByIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationDesignatedBiesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationDesignatedBy", $"A supplied 'StudentGraduationPlanAssociationDesignatedBy' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationIndustryCredentialIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationIndustryCredentialsItems = instance.StudentGraduationPlanAssociationIndustryCredentials.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationIndustryCredentialIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationIndustryCredentialsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationIndustryCredential", $"A supplied 'StudentGraduationPlanAssociationIndustryCredential' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationStudentContactAssociationIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationStudentContactAssociationsItems = instance.StudentGraduationPlanAssociationStudentContactAssociations.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationStudentContactAssociationIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationStudentContactAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationStudentContactAssociation", $"A supplied 'StudentGraduationPlanAssociationStudentContactAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.Value.IsStudentGraduationPlanAssociationYearsAttendedIncluded != null)
                {
                    var hasInvalidStudentGraduationPlanAssociationYearsAttendedsItems = instance.StudentGraduationPlanAssociationYearsAttendeds.Any(x => !mappingContract.Value.IsStudentGraduationPlanAssociationYearsAttendedIncluded(x));
        
                    if (hasInvalidStudentGraduationPlanAssociationYearsAttendedsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentGraduationPlanAssociationYearsAttended", $"A supplied 'StudentGraduationPlanAssociationYearsAttended' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
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

            var studentGraduationPlanAssociationStudentContactAssociationsValidator = new StudentGraduationPlanAssociationStudentContactAssociationPutPostRequestValidator();

            foreach (var item in instance.StudentGraduationPlanAssociationStudentContactAssociations)
            {
                var validationResult = studentGraduationPlanAssociationStudentContactAssociationsValidator.Validate(item);

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
    public class StudentGraduationPlanAssociationAcademicSubject : Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor.Equals(compareTo.AcademicSubjectDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationAcademicSubject).AcademicSubjectDescriptor);

            return hash.ToHashCode();
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentGraduationPlanAssociationCareerPathwayCode : Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode, IHasRequiredMembersWithMeaningfulDefaultValues
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
        
        private bool _careerPathwayCodeExplicitlyAssigned = false;
        private int _careerPathwayCode;

        /// <summary>
        /// The code representing the student's intended career pathway after graduation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="careerPathwayCode"), NaturalKeyMember]
        public int CareerPathwayCode 
        { 
            get => _careerPathwayCode;
            set 
            { 
                _careerPathwayCode = value;
                _careerPathwayCodeExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode.Equals(compareTo.CareerPathwayCode))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationCareerPathwayCode).CareerPathwayCode);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_careerPathwayCodeExplicitlyAssigned)
            {
                yield return "CareerPathwayCode";
            }
        }

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
    public class StudentGraduationPlanAssociationCTEProgram : Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationCTEProgram;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);
            return hash.ToHashCode();
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
        /// Number and description of the CIP code associated with the student's CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the student has completed the CTE program.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTE program is the student's primary CTE program.
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
    public class StudentGraduationPlanAssociationDescription : Entities.Common.Sample.IStudentGraduationPlanAssociationDescription
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description.Equals(compareTo.Description))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDescription).Description);

            return hash.ToHashCode();
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
    public class StudentGraduationPlanAssociationDesignatedBy : Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy.Equals(compareTo.DesignatedBy))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationDesignatedBy).DesignatedBy);

            return hash.ToHashCode();
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
    public class StudentGraduationPlanAssociationIndustryCredential : Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential.Equals(compareTo.IndustryCredential))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationIndustryCredential).IndustryCredential);

            return hash.ToHashCode();
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
    /// Represents a reference from the StudentGraduationPlanAssociationStudentContactAssociation entity to the StudentContactAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference
    {
        private Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation backReference;

        // Parameterless constructor for deserialization
        public StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference() { }

        // Constructor for inline initialization in parent
        public StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference(Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation backReference)
        {
            this.backReference = backReference;
        }

        // Expose back reference internally for access after JSON deserialization to enable link generation
        internal Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation BackReference
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

        [DataMember(Name="contactUniqueId"), NaturalKeyMember]
        public string ContactUniqueId { get; set; }

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
            return ContactUniqueId != default(string)
                ;
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentContactAssociation",
                Href = $"/ed-fi/studentContactAssociations/{ResourceId:n}"
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

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    }

    /// <summary>
    /// A class which represents the sample.StudentGraduationPlanAssociationStudentContactAssociation table of the StudentGraduationPlanAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentContactAssociation : Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation
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

        private bool _studentContactAssociationReferenceExplicitlyAssigned;
        private StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference _studentContactAssociationReference;
        private StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference ImplicitStudentContactAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentContactAssociationReference == null && !_studentContactAssociationReferenceExplicitlyAssigned)
                    _studentContactAssociationReference = new StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference(this);

                return _studentContactAssociationReference;
            }
        }

        [DataMember(Name="studentContactAssociationReference")][NaturalKeyMember]
        public StudentGraduationPlanAssociationStudentContactAssociationToStudentContactAssociationReference StudentContactAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentContactAssociationReference != null
                    && (_studentContactAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentContactAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentContactAssociationReference;

                return null;
            }
            set
            {
                _studentContactAssociationReferenceExplicitlyAssigned = true;
                _studentContactAssociationReference = value;
                _studentContactAssociationReference.BackReference = this;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentGraduationPlanAssociation _studentGraduationPlanAssociation;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentGraduationPlanAssociation Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation.StudentGraduationPlanAssociation
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
            if (!_studentContactAssociationReferenceExplicitlyAssigned)
            {
                ImplicitStudentContactAssociationReference.StudentUniqueId = _studentGraduationPlanAssociation.StudentUniqueId;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a contact.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation.ContactUniqueId
        {
            get
            {
                if (ImplicitStudentContactAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentContactAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentContactAssociationReference.ContactUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentContactAssociation
                _studentContactAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentContactAssociationReference.ContactUniqueId = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation).ContactUniqueId.Equals(compareTo.ContactUniqueId))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation).ContactUniqueId);
            return hash.ToHashCode();
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
            if (_studentContactAssociationReference != null)
                _studentContactAssociationReference.BackReference = this;
        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentGraduationPlanAssociationStudentContactAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentGraduationPlanAssociationStudentContactAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation.StudentContactAssociationResourceId
        {
            get { return null; }
            set { ImplicitStudentContactAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation.StudentContactAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentContactAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationStudentContactAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentGraduationPlanAssociationStudentContactAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentGraduationPlanAssociationStudentContactAssociation> context, FluentValidation.Results.ValidationResult result)
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
                    $"Supplied values for unified key property 'studentUniqueId' on 'StudentGraduationPlanAssociationStudentContactAssociation' are not consistent: {string.Join(", ", sourcesForStudentUniqueId.Select(x => $"{x.Item1} = {x.Item2}"))}"));
            }

            IEnumerable<Tuple<string, string>> GetStudentUniqueIdSources()
            {
                // Obtain value from the parent
                yield return Tuple.Create("studentUniqueId (from parent context)", (instance as Entities.Common.Sample.IStudentGraduationPlanAssociationStudentContactAssociation).StudentGraduationPlanAssociation.StudentUniqueId);

                // Obtain value from other references
                var valueFromStudentContactAssociationReference = instance.StudentContactAssociationReference?.StudentUniqueId;

                if (valueFromStudentContactAssociationReference != null)
                {
                    yield return Tuple.Create("studentContactAssociationReference.studentUniqueId", instance.StudentContactAssociationReference.StudentUniqueId);
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
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class StudentGraduationPlanAssociationYearsAttended : Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended, IHasRequiredMembersWithMeaningfulDefaultValues
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
        
        private bool _yearsAttendedExplicitlyAssigned = false;
        private short _yearsAttended;

        /// <summary>
        /// The number of years the student will have attended high school by the time of graduation.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="yearsAttended"), NaturalKeyMember]
        public short YearsAttended 
        { 
            get => _yearsAttended;
            set 
            { 
                _yearsAttended = value;
                _yearsAttendedExplicitlyAssigned = true; 
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
            var compareTo = obj as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentGraduationPlanAssociation == null || !_studentGraduationPlanAssociation.Equals(compareTo.StudentGraduationPlanAssociation))
                return false;


            // Standard Property
             if ((this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended.Equals(compareTo.YearsAttended))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentGraduationPlanAssociation != null)
                hash.Add(_studentGraduationPlanAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.Sample.IStudentGraduationPlanAssociationYearsAttended).YearsAttended);

            return hash.ToHashCode();
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

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_yearsAttendedExplicitlyAssigned)
            {
                yield return "YearsAttended";
            }
        }

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
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentSchoolAssociationExtension table of the StudentSchoolAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationExtension : Entities.Common.Sample.IStudentSchoolAssociationExtension
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
            var compareTo = obj as Entities.Common.Sample.IStudentSchoolAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentSchoolAssociation == null || !_studentSchoolAssociation.Equals(compareTo.StudentSchoolAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentSchoolAssociation != null)
                hash.Add(_studentSchoolAssociation);
            return hash.ToHashCode();
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
// Aggregate: StudentSectionAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentSectionAssociation.EdFi.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.StudentSectionAssociationExtension table of the StudentSectionAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationExtension : Entities.Common.Sample.IStudentSectionAssociationExtension
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentSectionAssociationExtension()
        {
            StudentSectionAssociationRelatedGeneralStudentProgramAssociations = new List<StudentSectionAssociationRelatedGeneralStudentProgramAssociation>();
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
        private Entities.Common.EdFi.IStudentSectionAssociation _studentSectionAssociation;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentSectionAssociation Entities.Common.Sample.IStudentSectionAssociationExtension.StudentSectionAssociation
        {
            get { return _studentSectionAssociation; }
            set { SetStudentSectionAssociation(value); }
        }

        internal Entities.Common.EdFi.IStudentSectionAssociation StudentSectionAssociation
        {
            set { SetStudentSectionAssociation(value); }
        }

        private void SetStudentSectionAssociation(Entities.Common.EdFi.IStudentSectionAssociation value)
        {
            _studentSectionAssociation = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentSectionAssociationExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentSectionAssociation == null || !_studentSectionAssociation.Equals(compareTo.StudentSectionAssociation))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentSectionAssociation != null)
                hash.Add(_studentSectionAssociation);
            return hash.ToHashCode();
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
        private ICollection<StudentSectionAssociationRelatedGeneralStudentProgramAssociation> _studentSectionAssociationRelatedGeneralStudentProgramAssociations;
        private ICollection<Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation> _studentSectionAssociationRelatedGeneralStudentProgramAssociationsCovariant;

        [DataMember(Name="relatedGeneralStudentProgramAssociations"), NoDuplicateMembers]
        public ICollection<StudentSectionAssociationRelatedGeneralStudentProgramAssociation> StudentSectionAssociationRelatedGeneralStudentProgramAssociations
        {
            get { return _studentSectionAssociationRelatedGeneralStudentProgramAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentSectionAssociationRelatedGeneralStudentProgramAssociation>(value,
                    (s, e) => ((Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation)e.Item).StudentSectionAssociationExtension = this);
                _studentSectionAssociationRelatedGeneralStudentProgramAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, StudentSectionAssociationRelatedGeneralStudentProgramAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation)e.Item).StudentSectionAssociationExtension = this;
                _studentSectionAssociationRelatedGeneralStudentProgramAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation> Entities.Common.Sample.IStudentSectionAssociationExtension.StudentSectionAssociationRelatedGeneralStudentProgramAssociations
        {
            get { return _studentSectionAssociationRelatedGeneralStudentProgramAssociationsCovariant; }
            set { StudentSectionAssociationRelatedGeneralStudentProgramAssociations = new List<StudentSectionAssociationRelatedGeneralStudentProgramAssociation>(value.Cast<StudentSectionAssociationRelatedGeneralStudentProgramAssociation>()); }
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
            if (_studentSectionAssociationRelatedGeneralStudentProgramAssociations != null) foreach (var item in _studentSectionAssociationRelatedGeneralStudentProgramAssociations)
            {
                item.StudentSectionAssociationExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentSectionAssociationExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentSectionAssociationExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentSectionAssociationExtensionMapper.MapTo(this, (Entities.Common.Sample.IStudentSectionAssociationExtension)target, null);
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
    public class StudentSectionAssociationExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentSectionAssociationExtension>
    {
        private static readonly FullName _fullName_sample_StudentSectionAssociationExtension = new FullName("sample", "StudentSectionAssociationExtension");

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentSectionAssociationExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = new Lazy<global::EdFi.Ods.Entities.Common.Sample.StudentSectionAssociationExtensionMappingContract>(() => (global::EdFi.Ods.Entities.Common.Sample.StudentSectionAssociationExtensionMappingContract) GeneratedArtifactStaticDependencies
                .MappingContractProvider
                .GetMappingContract(_fullName_sample_StudentSectionAssociationExtension));

            if (mappingContract.Value != null)
            {
                if (mappingContract.Value.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded != null)
                {
                    var hasInvalidStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItems = instance.StudentSectionAssociationRelatedGeneralStudentProgramAssociations.Any(x => !mappingContract.Value.IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded(x));
        
                    if (hasInvalidStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentSectionAssociationRelatedGeneralStudentProgramAssociation", $"A supplied 'StudentSectionAssociationRelatedGeneralStudentProgramAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }
            // -----------------------
            //  Validate unified keys
            // -----------------------

            // Recursively invoke the child collection item validators
            var studentSectionAssociationRelatedGeneralStudentProgramAssociationsValidator = new StudentSectionAssociationRelatedGeneralStudentProgramAssociationPutPostRequestValidator();

            foreach (var item in instance.StudentSectionAssociationRelatedGeneralStudentProgramAssociations)
            {
                var validationResult = studentSectionAssociationRelatedGeneralStudentProgramAssociationsValidator.Validate(item);

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
    /// Represents a reference from the StudentSectionAssociationRelatedGeneralStudentProgramAssociation entity to the GeneralStudentProgramAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference
    {
        private Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation backReference;

        // Parameterless constructor for deserialization
        public StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference() { }

        // Constructor for inline initialization in parent
        public StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference(Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation backReference)
        {
            this.backReference = backReference;
        }

        // Expose back reference internally for access after JSON deserialization to enable link generation
        internal Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation BackReference
        {
            get { return backReference; }
            set { backReference = value; }
        }

        private string _studentUniqueId;

        [DataMember(Name="studentUniqueId"), NaturalKeyMember]
        public string StudentUniqueId
        {
            get => _studentUniqueId == default(string)
                    ? BackReference.StudentSectionAssociationExtension.StudentSectionAssociation.StudentUniqueId
                    : _studentUniqueId;
            set => _studentUniqueId = value;
        }

        [DataMember(Name="beginDate"), NaturalKeyMember]
        public DateTime BeginDate { get; set; }

        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public long EducationOrganizationId { get; set; }

        [DataMember(Name="programEducationOrganizationId"), NaturalKeyMember]
        public long ProgramEducationOrganizationId { get; set; }

        [DataMember(Name="programName"), NaturalKeyMember]
        public string ProgramName { get; set; }

        [DataMember(Name="programTypeDescriptor"), NaturalKeyMember]
        public string ProgramTypeDescriptor { get; set; }

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
            return BeginDate != default(DateTime)
                && EducationOrganizationId != default(long)
                && ProgramEducationOrganizationId != default(long)
                && ProgramName != default(string)
                && ProgramTypeDescriptor != default(string)
                ;
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "GeneralStudentProgramAssociation",
                Href = $"/ed-fi/generalStudentProgramAssociations/{ResourceId:n}"
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

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    }

    /// <summary>
    /// A class which represents the sample.StudentSectionAssociationRelatedGeneralStudentProgramAssociation table of the StudentSectionAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelatedGeneralStudentProgramAssociation : Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation
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

        private bool _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned;
        private StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference _relatedGeneralStudentProgramAssociationReference;
        private StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference ImplicitRelatedGeneralStudentProgramAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_relatedGeneralStudentProgramAssociationReference == null && !_relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned)
                    _relatedGeneralStudentProgramAssociationReference = new StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference(this);

                return _relatedGeneralStudentProgramAssociationReference;
            }
        }

        [DataMember(Name="relatedGeneralStudentProgramAssociationReference")][NaturalKeyMember]
        public StudentSectionAssociationRelatedGeneralStudentProgramAssociationToGeneralStudentProgramAssociationReference RelatedGeneralStudentProgramAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference;

                return null;
            }
            set
            {
                _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned = true;
                _relatedGeneralStudentProgramAssociationReference = value;
                _relatedGeneralStudentProgramAssociationReference.BackReference = this;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.IStudentSectionAssociationExtension _studentSectionAssociationExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.IStudentSectionAssociationExtension Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.StudentSectionAssociationExtension
        {
            get { return _studentSectionAssociationExtension; }
            set { SetStudentSectionAssociationExtension(value); }
        }

        internal Entities.Common.Sample.IStudentSectionAssociationExtension StudentSectionAssociationExtension
        {
            set { SetStudentSectionAssociationExtension(value); }
        }

        private void SetStudentSectionAssociationExtension(Entities.Common.Sample.IStudentSectionAssociationExtension value)
        {
            _studentSectionAssociationExtension = value;

            // Initialize unified key values from parent context when reference is being formed by outbound mapper
            if (!_relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned)
            {
                ImplicitRelatedGeneralStudentProgramAssociationReference.StudentUniqueId = _studentSectionAssociationExtension.StudentSectionAssociation.StudentUniqueId;
            }
        }

        /// <summary>
        /// The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        DateTime Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedBeginDate
        {
            get
            {
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference.BeginDate;

                return default(DateTime);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // RelatedGeneralStudentProgramAssociation
                _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitRelatedGeneralStudentProgramAssociationReference.BeginDate = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedEducationOrganizationId
        {
            get
            {
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference.EducationOrganizationId;

                return default(long);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // RelatedGeneralStudentProgramAssociation
                _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitRelatedGeneralStudentProgramAssociationReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramEducationOrganizationId;

                return default(long);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // RelatedGeneralStudentProgramAssociation
                _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramEducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedProgramName
        {
            get
            {
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // RelatedGeneralStudentProgramAssociation
                _relatedGeneralStudentProgramAssociationReferenceExplicitlyAssigned = false;
                ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (StudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedProgramTypeDescriptor
        {
            get
            {
                if (ImplicitRelatedGeneralStudentProgramAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitRelatedGeneralStudentProgramAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitRelatedGeneralStudentProgramAssociationReference.ProgramTypeDescriptor = value;
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
            var compareTo = obj as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentSectionAssociationExtension == null || !_studentSectionAssociationExtension.Equals(compareTo.StudentSectionAssociationExtension))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedBeginDate.Equals(compareTo.RelatedBeginDate))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedEducationOrganizationId.Equals(compareTo.RelatedEducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramEducationOrganizationId.Equals(compareTo.RelatedProgramEducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramName.Equals(compareTo.RelatedProgramName))
                return false;


            // Unified Type Property
            if (!(this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramTypeDescriptor.Equals(compareTo.RelatedProgramTypeDescriptor))
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
            var hash = new HashCode();
            //Parent Property
            if (_studentSectionAssociationExtension != null)
                hash.Add(_studentSectionAssociationExtension);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedBeginDate);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedEducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramEducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramName);

            //Unified Type Property
            hash.Add((this as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).RelatedProgramTypeDescriptor);

            return hash.ToHashCode();
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
            if (_relatedGeneralStudentProgramAssociationReference != null)
                _relatedGeneralStudentProgramAssociationReference.BackReference = this;
        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.StudentSectionAssociationRelatedGeneralStudentProgramAssociationMapper.SynchronizeTo(this, (Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.StudentSectionAssociationRelatedGeneralStudentProgramAssociationMapper.MapTo(this, (Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedGeneralStudentProgramAssociationResourceId
        {
            get { return null; }
            set { ImplicitRelatedGeneralStudentProgramAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation.RelatedGeneralStudentProgramAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitRelatedGeneralStudentProgramAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationRelatedGeneralStudentProgramAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentSectionAssociationRelatedGeneralStudentProgramAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentSectionAssociationRelatedGeneralStudentProgramAssociation> context, FluentValidation.Results.ValidationResult result)
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
                    $"Supplied values for unified key property 'studentUniqueId' on 'StudentSectionAssociationRelatedGeneralStudentProgramAssociation' are not consistent: {string.Join(", ", sourcesForStudentUniqueId.Select(x => $"{x.Item1} = {x.Item2}"))}"));
            }

            IEnumerable<Tuple<string, string>> GetStudentUniqueIdSources()
            {
                // Obtain value from the parent
                yield return Tuple.Create("studentUniqueId (from parent context)", (instance as Entities.Common.Sample.IStudentSectionAssociationRelatedGeneralStudentProgramAssociation).StudentSectionAssociationExtension.StudentSectionAssociation.StudentUniqueId);

                // Obtain value from other references
                var valueFromRelatedGeneralStudentProgramAssociationReference = instance.RelatedGeneralStudentProgramAssociationReference?.StudentUniqueId;

                if (valueFromRelatedGeneralStudentProgramAssociationReference != null)
                {
                    yield return Tuple.Create("relatedGeneralStudentProgramAssociationReference.studentUniqueId", instance.RelatedGeneralStudentProgramAssociationReference.StudentUniqueId);
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

}
