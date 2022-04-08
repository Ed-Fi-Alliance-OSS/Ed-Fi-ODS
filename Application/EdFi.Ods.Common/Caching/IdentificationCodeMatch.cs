// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Caching
{
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
            => HashCode.Combine(IdentificationCode, AssigningOrganizationIdentificationCode);
    }
}
