// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using log4net;
using QuickGraph;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class PersonResourceLoadGraphTransformer : IResourceLoadGraphTransformer
    {
        private const string TransformationErrorText = "Dependency graph transformation for security considerations failed. See log for more details.";
        private readonly ILog _logger = LogManager.GetLogger(typeof(PersonResourceLoadGraphTransformer));
        
        public void Transform(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            ApplyStudentTransformation(resourceGraph);
            ApplyStaffTransformation(resourceGraph);
            ApplyContactTransformation(resourceGraph);
        }

        private void ApplyStaffTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
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
                var message = "Unable to transform resource load graph since StaffEducationOrganizationAssignmentAssociation and StaffEducationOrganizationEmploymentAssociation were not found in the graph.";

                _logger.Error(message);

                throw new SecurityAuthorizationException(
                    detail: "scenario82.",
                    error: TransformationErrorText,
                    message: message);
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
                var message = "Unable to transform resource load graph as StudentSchoolAssociation was not found in the graph.";

                throw new SecurityAuthorizationException(
                    detail: "scenario83.",
                    error: TransformationErrorText,
                    message: message);
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

        private void ApplyContactTransformation(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph)
        {
            var resources = resourceGraph.Vertices.ToList();

            var contactResource = resources.FirstOrDefault(x => 
                x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Contact") 
                || x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, "Parent"));
            
            // No entity named Parent or Contact in the graph, nothing to do.
            if (contactResource == null)
            {
                return;
            }

            var contactStudentAssociationName = contactResource.Name switch
            {
                "Contact" => "StudentContactAssociation",
                "Parent" => "StudentParentAssociation",
                _ => LogAndThrowException()
            };

            var studentContactAssociationResource = resources.FirstOrDefault(
                x => x.FullName == new FullName(EdFiConventions.PhysicalSchemaName, contactStudentAssociationName));
            
            if (studentContactAssociationResource == null)
            {
                string message = $"Unable to transform resource load graph as {contactStudentAssociationName} was not found in the graph.";
                _logger.Error(message);

                throw new SecurityAuthorizationException(
                    detail: "scenario84.",
                    error: TransformationErrorText,
                    message: message);
            }

            // Get direct contact dependencies
            var directContactDependencies = resourceGraph.OutEdges(contactResource)
                .Where(e => e.Target != studentContactAssociationResource)
                .ToList();

            // Add dependency on primaryRelationship path
            foreach (var directContactDependency in directContactDependencies)
            {
                // Re-point the edge to the primary relationships
                resourceGraph.RemoveEdge(directContactDependency);
                resourceGraph.AddEdge(new AssociationViewEdge(studentContactAssociationResource, directContactDependency.Target, directContactDependency.AssociationView));
            }

            string LogAndThrowException()
            {
                string message = $"Unable to transform resource load graph as a student association for {contactResource.FullName} is not defined.";
                _logger.Error(message);

                throw new SecurityAuthorizationException(
                    detail: "scenario85.",
                    error: TransformationErrorText,
                    message: message);
            }
        }
    }
}
