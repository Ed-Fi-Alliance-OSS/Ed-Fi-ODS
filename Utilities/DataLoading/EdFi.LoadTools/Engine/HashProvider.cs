// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace EdFi.LoadTools.Engine
{
    public class HashProvider : IHashProvider
    {
        private readonly ThreadLocal<HashAlgorithm> _algorithm =
            new ThreadLocal<HashAlgorithm>(SHA1.Create);

        public int Bytes => _algorithm.Value.HashSize / 8;

        public byte[] Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return _algorithm.Value.ComputeHash(bytes);
        }

        public string BytesToStr(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
