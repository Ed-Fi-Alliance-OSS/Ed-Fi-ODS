// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.IntegrationTests
{
    public class EdFiTuple
    {
        public int Source { get; }

        public int Target { get; }

        private EdFiTuple(int source, int target)
        {
            Source = source;
            Target = target;
        }

        public static EdFiTuple Create(int source, int target)
        {
            return new EdFiTuple(source, target);
        }
    }
}
