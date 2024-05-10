// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions
{
    public class DistributedCacheException : InternalServerErrorException
    {
        private const string TypePart = "distributed-cache-error";
        private const string TitleText = "Distributed Cache Error";
        public DistributedCacheException() : base() { }

        public DistributedCacheException(string message)
            : base(DefaultDetail, message) { }

        public DistributedCacheException(string message, Exception inner)
            : base(DefaultDetail, message, inner) { }
        
        // ---------------------------
        //  Boilerplate for overrides
        // ---------------------------
        public override string Title { get => TitleText; }
    
        protected override IEnumerable<string> GetTypeParts()
        {
            foreach (var part in base.GetTypeParts())
            {
                yield return part;
            }

            yield return TypePart;
        }
        // ---------------------------
    }

    public class SafeDistributedCacheException : DistributedCacheException
    {
        public override string StackTrace => "See log for details";

        public SafeDistributedCacheException(string message)
            : base(message) { }
        public SafeDistributedCacheException() : base()
        {
        }

        public SafeDistributedCacheException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}