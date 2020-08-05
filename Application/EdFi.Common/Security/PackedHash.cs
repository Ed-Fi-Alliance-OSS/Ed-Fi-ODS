// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security
{
    public class PackedHash
    {
        public byte Format { get; set; }

        public int HashAlgorithm { get; set; }

        public byte[] HashBytes { get; set; }

        public int Iterations { get; set; }

        public byte[] Salt { get; set; }
    }
}
