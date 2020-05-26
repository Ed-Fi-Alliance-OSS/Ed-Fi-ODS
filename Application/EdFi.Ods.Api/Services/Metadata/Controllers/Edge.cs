// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;

namespace EdFi.Ods.Api.Services.Metadata.Controllers
{
    public class Edge
    {
        public string Source { get; set; }

        public string Target { get; set; }

        public override int GetHashCode() => HashHelper.GetSha256Hash(Source).ToInt32() + HashHelper.GetSha256Hash(Target).ToInt32();

        private sealed class SourceTargetEqualityComparer : IEqualityComparer<Edge>
        {
            public bool Equals(Edge x, Edge y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Source.EqualsIgnoreCase(y.Source) && x.Target.EndsWithIgnoreCase(y.Target);
            }

            public int GetHashCode(Edge obj)
            {
                unchecked
                {
                    return ((obj.Source != null
                                ? obj.Source.GetHashCode()
                                : 0) * 397) ^ (obj.Target != null
                               ? obj.Target.GetHashCode()
                               : 0);
                }
            }
        }

        public static IEqualityComparer<Edge> SourceTargetComparer { get; } = new SourceTargetEqualityComparer();
    }
}
