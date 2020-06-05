// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Common.Dtos
{
    /// <summary>
    ///     Provides a standard base class for facilitating comparison of objects.
    ///     For a discussion of the implementation of Equals/GetHashCode, see
    ///     http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
    ///     and http://groups.google.com/group/sharp-architecture/browse_thread/thread/f76d1678e68e3ece?hl=en for
    ///     an in depth and conclusive resolution.
    /// </summary>
    [Serializable]
    public abstract class DomainObjectBase
    {
        /// <summary>
        ///     To help ensure hashcode uniqueness, a carefully selected random number multiplier
        ///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
        ///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        ///     of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        ///     for more information.
        /// </summary>
        private const int HashMultiplier = 31;

        /// <summary>
        ///     This static member caches the domain signature properties to avoid looking them up for
        ///     each instance of the same type.
        ///     A description of the very slick ThreadStatic attribute may be found at
        ///     http://www.dotnetjunkies.com/WebLog/chris.taylor/archive/2005/08/18/132026.aspx
        /// </summary>
        [ThreadStatic]
        private static Dictionary<Type, IEnumerable<PropertyInfo>> signaturePropertiesDictionary;

        /// <summary>
        ///     Gets or sets the date that the domain object was first created and persisted (used to identify transient objects for NHibernate).
        /// </summary>
        [IgnoreDataMember] //JsonIgnore
        public virtual DateTime CreateDate { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainObjectBase;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return compareTo != null && GetType()
                      .Equals(compareTo.GetTypeUnproxied()) &&
                   HasSameObjectSignatureAs(compareTo);
        }

        public virtual int CalculateJsonObjectHashCode(JObject source)
        {
            return GetHashCode(property => Convert.ChangeType(source[property.Name], property.PropertyType));
        }

        public override int GetHashCode()
        {
            return GetHashCode(property => property.GetValue(this, null));
        }

        /// <summary>
        ///     This is used to provide the hashcode identifier of an object using the signature
        ///     properties of the object; although it's necessary for NHibernate's use, this can
        ///     also be useful for business logic purposes and has been included in this base
        ///     class, accordingly.  Since it is recommended that GetHashCode change infrequently,
        ///     if at all, in an object's lifetime, it's important that properties are carefully
        ///     selected which truly represent the signature of an object.
        /// </summary>
        public virtual int GetHashCode(Func<PropertyInfo, object> getPropertyValue)
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

        /// <summary>
        /// </summary>
        public virtual IEnumerable<PropertyInfo> GetSignatureProperties()
        {
            IEnumerable<PropertyInfo> properties;

            // Init the signaturePropertiesDictionary here due to reasons described at 
            // http://blogs.msdn.com/jfoscoding/archive/2006/07/18/670497.aspx
            if (signaturePropertiesDictionary == null)
            {
                signaturePropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            }

            if (signaturePropertiesDictionary.TryGetValue(GetType(), out properties))
            {
                return properties;
            }

            return signaturePropertiesDictionary[GetType()] = GetTypeSpecificSignatureProperties();
        }

        /// <summary>
        ///     You may override this method to provide your own comparison routine.
        /// </summary>
        public virtual bool HasSameObjectSignatureAs(JObject compareTo)
        {
            var signatureProperties = GetSignatureProperties();

            if ((from property in signatureProperties
                 let valueOfThisObject = property.GetValue(this, null)
                 let valueToCompareTo = Convert.ChangeType(compareTo[property.Name], property.PropertyType)
                 where valueOfThisObject != null || valueToCompareTo != null
                 where (valueOfThisObject == null) ^ (valueToCompareTo == null) || !valueOfThisObject.Equals(valueToCompareTo)
                 select valueOfThisObject).Any())
            {
                return false;
            }

            // If we've gotten this far and signature properties were found, then we can
            // assume that everything matched; otherwise, if there were no signature 
            // properties, then simply return the default bahavior of Equals
            return signatureProperties.Any() || base.Equals(compareTo);
        }

        /// <summary>
        ///     You may override this method to provide your own comparison routine.
        /// </summary>
        public virtual bool HasSameObjectSignatureAs(DomainObjectBase compareTo)
        {
            var signatureProperties = GetSignatureProperties();

            if ((from property in signatureProperties
                 let valueOfThisObject = property.GetValue(this, null)
                 let valueToCompareTo = property.GetValue(compareTo, null)
                 where valueOfThisObject != null || valueToCompareTo != null
                 where (valueOfThisObject == null) ^ (valueToCompareTo == null) || !valueOfThisObject.Equals(valueToCompareTo)
                 select valueOfThisObject).Any())
            {
                return false;
            }

            // If we've gotten this far and signature properties were found, then we can
            // assume that everything matched; otherwise, if there were no signature 
            // properties, then simply return the default bahavior of Equals
            return signatureProperties.Any() || base.Equals(compareTo);
        }

        /// <summary>
        ///     Enforces the template method pattern to have child objects determine which specific
        ///     properties should and should not be included in the object signature comparison. Note
        ///     that the the BaseObject already takes care of performance caching, so this method
        ///     shouldn't worry about caching...just return the goods man!
        /// </summary>
        protected abstract IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties();

        /// <summary>
        ///     When NHibernate proxies objects, it masks the type of the actual entity object.
        ///     This wrapper burrows into the proxied object to get its actual type.
        ///     Although this assumes NHibernate is being used, it doesn't require any NHibernate
        ///     related dependencies and has no bad side effects if NHibernate isn't being used.
        ///     Related discussion is at http://groups.google.com/group/sharp-architecture/browse_thread/thread/ddd05f9baede023a ...thanks Jay Oliver!
        /// </summary>
        protected virtual Type GetTypeUnproxied()
        {
            return GetType();
        }

        public override string ToString()
        {
            var signatureProperties = GetSignatureProperties();

            string response = string.Empty;

            foreach (PropertyInfo property in signatureProperties)
            {
                object value;

                try
                {
                    value = property.GetValue(this, null);
                }
                catch
                {
                    value = "(exception)";
                }

                response += string.Format(", {0}: {1}", property.Name, value);
            }

            if (response.Length > 0)
            {
                return response.Substring(2);
            }

            return base.ToString();
        }
    }
}
