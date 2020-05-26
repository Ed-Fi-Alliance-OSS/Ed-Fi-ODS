// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;

namespace EdFi.Ods.Api.Services.Metadata.Controllers
{
    public class Node
    {
        public string Id { get; set; }

        public static IEqualityComparer<Node> NodeComparer { get; } = new NodeEqualityComparer();

        public override int GetHashCode() => HashHelper.GetSha256Hash(Id).ToInt32();

        private sealed class NodeEqualityComparer : IEqualityComparer<Node>
        {
            public bool Equals(Node x, Node y)
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

                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(Node obj)
            {
                return obj.Id != null
                    ? obj.Id.GetHashCode()
                    : 0;
            }
        }
    }
}
