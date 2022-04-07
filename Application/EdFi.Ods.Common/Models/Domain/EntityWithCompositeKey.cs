// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Common.Models.Domain
{
    [Serializable]
    public abstract class EntityWithCompositeKey : DomainObjectBase //ValidatableObject
    {
        private int? cachedHashcode;

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityWithCompositeKey;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (compareTo == null)
            {
                var compareToJson = obj as JObject;

                if (compareToJson == null)
                {
                    return false;
                }

                // Compare based on Id
                if (HasSameNonDefaultIdAs(compareToJson))
                {
                    return true;
                }

                // Compare based on domain signature
                if (HasSameObjectSignatureAs(compareToJson))
                {
                    return true;
                }

                // Not the same
                return false;
            }

            if (!GetType()
               .Equals(compareTo.GetTypeUnproxied()))
            {
                return false;
            }

            if (HasSameNonDefaultIdAs(compareTo))
            {
                return true;
            }

            // Since the Ids aren't the same, both of them must be transient to
            // compare domain signatures; because if one is transient and the
            // other is a persisted entity, then they cannot be the same object.
            return

                // this.IsTransient() && compareTo.IsTransient() &&
                HasSameObjectSignatureAs(compareTo);
        }

        public override int GetHashCode()
        {
            if (cachedHashcode.HasValue)
            {
                return cachedHashcode.Value;
            }

            var signatureProperties = GetSignatureProperties();

            var hashCode = new HashCode();

            foreach (var signatureProperty in signatureProperties)
            {
                hashCode.Add(signatureProperty.GetValue(this, null));
            }

            // If no properties were flagged as being part of the signature of the object,
            // then simply return the hashcode of the base object as the hashcode.
            cachedHashcode = signatureProperties.Any() ? hashCode.ToHashCode() : base.GetHashCode();

            return cachedHashcode.Value;
        }

        // <summary>
        //     Transient objects are not associated with an item already in storage.  For instance,
        //     a Customer is transient if its Id is 0.  It's virtual to allow NHibernate-backed
        //     objects to be lazily loaded.
        // </summary>
        public virtual bool IsTransient()
        {
            return CreateDate.Equals(default(DateTime));
        }

        /// <summary>
        ///     The property getter for SignatureProperties should ONLY compare the properties which make up
        ///     the "domain signature" of the object.
        ///     If you choose NOT to override this method (which will be the most common scenario),
        ///     then you should decorate the appropriate property(s) with [DomainSignature] and they
        ///     will be compared automatically.  This is the preferred method of managing the domain
        ///     signature of entity objects.
        /// </summary>
        /// <remarks>
        ///     This ensures that the entity has at least one property decorated with the
        ///     [DomainSignature] attribute.
        /// </remarks>
        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return GetType()
               .GetSignatureProperties();
        }

        private bool HasSameNonDefaultIdAs(JObject compareTo)
        {
            bool result = true;

            foreach (var propertyInfo in GetTypeSpecificSignatureProperties())
            {
                var thisPropertyValue = propertyInfo.GetValue(this, null);
                var thatPropertyValue = Convert.ChangeType(compareTo[propertyInfo.Name], propertyInfo.PropertyType);

                result = result && thisPropertyValue.Equals(thatPropertyValue);
            }

            return result;
        }

        /// <summary>
        ///     Returns true if self and the provided entity have the same Id values
        ///     and the Ids are not of the default Id value
        /// </summary>
        private bool HasSameNonDefaultIdAs(EntityWithCompositeKey compareTo)
        {
            var result = true; // !this.IsTransient() && !compareTo.IsTransient();

            if (result)
            {
                foreach (var propertyInfo in GetTypeSpecificSignatureProperties())
                {
                    var thisPropertyValue = propertyInfo.GetValue(this, null);
                    var thatPropertyValue = propertyInfo.GetValue(compareTo, null);

                    result = result && thisPropertyValue.Equals(thatPropertyValue);
                }
            }

            return result;
        }
    }
}
