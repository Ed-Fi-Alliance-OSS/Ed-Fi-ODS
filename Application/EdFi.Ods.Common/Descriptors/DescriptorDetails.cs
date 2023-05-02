// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Descriptors;

public class DescriptorDetails : IEquatable<DescriptorDetails>
{
    public int DescriptorId { get; set; }

    public string Namespace { get; set; }

    public string CodeValue { get; set; }

    private string _uri;
    
    public string Uri
    {
        get => _uri ??= $"{Namespace}#{CodeValue}";
    }

    #region IEquatable members/overrides

    public bool Equals(DescriptorDetails other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _uri == other._uri && DescriptorId == other.DescriptorId;
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

        return Equals((DescriptorDetails)obj);
    }

    // ReSharper disable all NonReadonlyMemberInGetHashCode
    public override int GetHashCode()
    {
        unchecked
        {
            return ((_uri != null ? _uri.GetHashCode() : 0) * 397) ^ DescriptorId;
        }
    }

    #endregion
}
