// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
namespace EdFi.Ods.CodeGen.Generators.Resources
{
    internal class SemanticItemPair<T>
    {
        public SemanticItemPair() { }

        public SemanticItemPair(T underlying, T current)
        {
            Underlying = underlying;
            Current = current;
        }

        /// <summary>
        /// Gets or sets the underlying semantic model item which is guaranteed to be unfiltered.
        /// </summary>
        public T Underlying { get; set; }

        /// <summary>
        /// Gets or sets the "current" semantic model item, which may or may not be filtered, but should be evaluated in making "positive" code generation decisions (i.e. about the presence [as opposed to absence] of generated artifacts).
        /// </summary>
        public T Current { get; set; }
    }
}
