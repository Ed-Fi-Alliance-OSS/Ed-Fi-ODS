// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    public class AssociationEdge : IEdge<Entity>
    {
        private readonly DomainModel _domainModel;

        public AssociationEdge(Association association, DomainModel domainModel)
        {
            _domainModel = domainModel;
            Association = association;
        }

        public Association Association { get; }

        /// <summary>
        /// Gets the source vertex
        /// </summary>
        /// <getter><ensures>Contract.Result&lt;TVertex&gt;() != null</ensures></getter>
        public Entity Source
        {
            get
            {
                try
                {
                    return _domainModel.EntityByFullName[Association.PrimaryEntityFullName];
                }
                catch (KeyNotFoundException)
                {
                    throw new Exception(
                        string.Format(
                            "AssociationEdge's Source entity '{0}' not found in domain model.",
                            Association.PrimaryEntityFullName));
                }
            }
        }

        /// <summary>
        /// Gets the target vertex
        /// </summary>
        /// <getter><ensures>Contract.Result&lt;TVertex&gt;() != null</ensures></getter>
        public Entity Target
        {
            get
            {
                try
                {
                    return _domainModel.EntityByFullName[Association.SecondaryEntityFullName];
                }
                catch (KeyNotFoundException)
                {
                    throw new Exception(
                        string.Format(
                            "AssociationEdge's Target entity '{0}' not found in domain model.",
                            Association.PrimaryEntityFullName));
                }
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Association.ToString();
        }
    }
}
