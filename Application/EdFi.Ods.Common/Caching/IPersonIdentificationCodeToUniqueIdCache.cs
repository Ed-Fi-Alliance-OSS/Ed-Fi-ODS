// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Caching
{
    public class UniqueIdMatch : IEquatable<UniqueIdMatch>
    {
        public string UniqueId;
        public string AssigningOrganizationIdentificationCode;

        // Resharper generated equality members
        public bool Equals(UniqueIdMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(UniqueId, other.UniqueId) &&
                   string.Equals(AssigningOrganizationIdentificationCode, other.AssigningOrganizationIdentificationCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((UniqueIdMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((UniqueId != null
                            ? UniqueId.GetHashCode()
                            : 0) * 397) ^ (AssigningOrganizationIdentificationCode != null
                           ? AssigningOrganizationIdentificationCode.GetHashCode()
                           : 0);
            }
        }
    }

    public class IdentificationCodeMatch : IEquatable<IdentificationCodeMatch>
    {
        public string IdentificationCode;
        public string AssigningOrganizationIdentificationCode;

        // Resharper generated equality members
        public bool Equals(IdentificationCodeMatch other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(IdentificationCode, other.IdentificationCode) &&
                   string.Equals(AssigningOrganizationIdentificationCode, other.AssigningOrganizationIdentificationCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((IdentificationCodeMatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((IdentificationCode != null
                            ? IdentificationCode.GetHashCode()
                            : 0) * 397) ^ (AssigningOrganizationIdentificationCode != null
                           ? AssigningOrganizationIdentificationCode.GetHashCode()
                           : 0);
            }
        }
    }

    public class IdentificationCodeToUniqueIdKey : IEquatable<IdentificationCodeToUniqueIdKey>
    {
        public string PersonType;
        public string IdentificationSystemDescriptorUri;
        public string IdentificationCodeValue;
        public int EducationOrganizationId;

        // Resharper generated equality members
        public bool Equals(IdentificationCodeToUniqueIdKey other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(PersonType, other.PersonType) &&
                   string.Equals(IdentificationSystemDescriptorUri, other.IdentificationSystemDescriptorUri) &&
                   string.Equals(IdentificationCodeValue, other.IdentificationCodeValue) &&
                   EducationOrganizationId == other.EducationOrganizationId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((IdentificationCodeToUniqueIdKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (PersonType != null
                    ? PersonType.GetHashCode()
                    : 0);

                hashCode = (hashCode * 397) ^ (IdentificationSystemDescriptorUri != null
                               ? IdentificationSystemDescriptorUri.GetHashCode()
                               : 0);

                hashCode = (hashCode * 397) ^ (IdentificationCodeValue != null
                               ? IdentificationCodeValue.GetHashCode()
                               : 0);

                hashCode = (hashCode * 397) ^ EducationOrganizationId;
                return hashCode;
            }
        }
    }

    public class UniqueIdToIdentificationCodeKey : IEquatable<UniqueIdToIdentificationCodeKey>
    {
        public string PersonType;
        public string IdentificationSystemDescriptorUri;
        public string UniqueId;
        public int EducationOrganizationId;

        // Resharper generated equality members
        public bool Equals(UniqueIdToIdentificationCodeKey other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(PersonType, other.PersonType) &&
                   string.Equals(IdentificationSystemDescriptorUri, other.IdentificationSystemDescriptorUri) &&
                   string.Equals(UniqueId, other.UniqueId) &&
                   EducationOrganizationId == other.EducationOrganizationId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((UniqueIdToIdentificationCodeKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (PersonType != null
                    ? PersonType.GetHashCode()
                    : 0);

                hashCode = (hashCode * 397) ^ (IdentificationSystemDescriptorUri != null
                               ? IdentificationSystemDescriptorUri.GetHashCode()
                               : 0);

                hashCode = (hashCode * 397) ^ (UniqueId != null
                               ? UniqueId.GetHashCode()
                               : 0);

                hashCode = (hashCode * 397) ^ EducationOrganizationId;
                return hashCode;
            }
        }
    }

    public interface IPersonIdentificationCodeToUniqueIdCache
    {
        UniqueIdMatch[] GetMatchingUniqueIds(
            string personType,
            int educationOrganizationId,
            string identificationSystemDescriptor,
            string identificationCode);

        IdentificationCodeMatch[] GetMatchingIdentificationCodes(
            string personType,
            int educationOrganizationId,
            string identificationSystemDescriptor,
            string uniqueId);
    }
}
