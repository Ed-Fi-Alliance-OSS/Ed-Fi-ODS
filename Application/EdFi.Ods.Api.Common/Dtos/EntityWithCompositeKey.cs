// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Common.Dtos
{
    /// <summary>
    ///     For a discussion of this object, see
    ///     http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
    /// </summary>
    [Serializable]
    public abstract class EntityWithCompositeKey : DomainObjectBase //ValidatableObject
    {
        /// <summary>
        ///     To help ensure hashcode uniqueness, a carefully selected random number multiplier
        ///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
        ///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        ///     of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        ///     for more information.
        /// </summary>
        private const int HashMultiplier = 31;

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

            //if (this.IsTransient())
            //{
            //    this.cachedHashcode = base.GetHashCode();
            //}
            //else
            {
                unchecked
                {
                    // It's possible for two objects to return the same hash code based on 
                    // identically valued properties, even if they're of two different types, 
                    // so we include the object's type in the hash calculation
                    var hashCode = GetType()
                       .GetHashCode();

                    cachedHashcode = (hashCode * HashMultiplier) ^ GetSignatureHashCode();
                }
            }

            return cachedHashcode.Value;
        }

        private int GetSignatureHashCode()
        {
            unchecked
            {
                var signatureProperties = GetSignatureProperties();

                // It's possible for two objects to return the same hash code based on 
                // identically valued properties, even if they're of two different types, 
                // so we include the object's type in the hash calculation
                var hashCode = GetType()
                   .GetHashCode();

                hashCode = signatureProperties.Select(property => property.GetValue(this, null))
                                              .Where(value => value != null)
                                              .Aggregate(hashCode, (current, value) => (current * HashMultiplier) ^ value.GetHashCode());

                if (signatureProperties.Any())
                {
                    return hashCode;
                }

                // If no properties were flagged as being part of the signature of the object,
                // then simply return the hashcode of the base object as the hashcode.
                return base.GetHashCode();
            }
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
