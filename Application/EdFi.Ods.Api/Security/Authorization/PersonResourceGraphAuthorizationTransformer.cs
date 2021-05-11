// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using QuickGraph;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class PersonResourceLoadGraphTransformer : IResourceLoadGraphTransformer
    {
        public void Transform(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            ApplyStudentTransformation(resourceGraph);
            ApplyStaffTransformation(resourceGraph);
            ApplyParentTransformation(resourceGraph);
        }

        private static void ApplyStaffTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();
            
            var staffResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Staff"));

            var staffEdOrgEmployAssoc =
                resources.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationEmploymentAssociation"));

            var staffEdOrgAssignAssoc =
                resources.FirstOrDefault(
                    x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StaffEducationOrganizationAssignmentAssociation"));

            // No staff entity in the graph, nothing to do.
            if (staffResource == null)
            {
                return;
            }

            if (staffEdOrgEmployAssoc == null && staffEdOrgAssignAssoc == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform resource load graph since StaffEducationOrganizationAssignmentAssociation and" +
                    " StaffEducationOrganizationEmploymentAssociation were not found in the graph.");
            }

            // Get direct staff dependencies
            var directStaffDependencies = resourceGraph.OutEdges(staffResource)
                .Where(e => e.Target != staffEdOrgEmployAssoc && e.Target != staffEdOrgAssignAssoc)
                .ToList();
            
            // Add dependency on primaryRelationship path
            foreach (var directStaffDependency in directStaffDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directStaffDependency);
                
                resourceGraph.AddEdge(new AssociationViewEdge(staffEdOrgAssignAssoc, directStaffDependency.Target, directStaffDependency.AssociationView));
                resourceGraph.AddEdge(new AssociationViewEdge(staffEdOrgEmployAssoc, directStaffDependency.Target, directStaffDependency.AssociationView));
            }
        }

        private static void ApplyStudentTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();

            var studentResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Student"));
            var studentSchoolAssociationResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentSchoolAssociation"));

            // No student entity in the graph, nothing to do.
            if (studentResource == null)
            {
                return;
            }

            if (studentSchoolAssociationResource == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform resource load graph as StudentSchoolAssociation was not found in the graph.");
            }

            // Get direct student dependencies
            var studentDependencies = resourceGraph.OutEdges(studentResource)
                .Where(e => e.Target != studentSchoolAssociationResource)
                .ToList();

            // Add dependency on primaryRelationship path
            foreach (var directStudentDependency in studentDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directStudentDependency);
                resourceGraph.AddEdge(new AssociationViewEdge(studentSchoolAssociationResource, directStudentDependency.Target, directStudentDependency.AssociationView));
            }
        }

        private static void ApplyParentTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();

            var parentResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Parent"));
            var studentParentAssociationResource = resources.FirstOrDefault(x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "StudentParentAssociation"));

            // No parent entity in the graph, nothing to do.
            if (parentResource == null)
            {
                return;
            }

            if (studentParentAssociationResource == null)
            {
                throw new EdFiSecurityException(
                    "Unable to transform resource load graph as StudentParentAssociation was not found in the graph.");
            }

            // Get direct parent dependencies
            var directParentDependencies = resourceGraph.OutEdges(parentResource)
                .Where(e => e.Target != studentParentAssociationResource)
                .ToList();

            // Add dependency on primaryRelationship path
            foreach (var directParentDependency in directParentDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directParentDependency);
                resourceGraph.AddEdge(new AssociationViewEdge(studentParentAssociationResource, directParentDependency.Target, directParentDependency.AssociationView));
            }
        }
    }
}
