// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using EdFi.Ods.Api.Common.Models.Resources.Parent.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.Student.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentParentAssociation.EdFi;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using Newtonsoft.Json;

namespace EdFi.Ods.WebService.Tests._Helpers
{
    internal class PersonHelperResponse
    {
        internal HttpResponseMessage ResponseMessage { get; set; }

        internal string UniqueId { get; set; }
    }

    internal class PersonHelper
    {
        private static string CreateResource(string resourceType, string uniqueId, string lastName, string firstName)
        {
            switch (resourceType)
            {
                case "students":
                    return ResourceHelper.CreateStudent(uniqueId, lastName, firstName);
                case "parents":
                    return ResourceHelper.CreateParent(uniqueId, lastName, firstName);
                case "staffs":
                    return ResourceHelper.CreateStaff(uniqueId, lastName, firstName);
            }

            return null;
        }

        internal static PersonHelperResponse CreatePerson(HttpClient client, string resource, string lastName, string firstName)
        {
            var uniqueId = Guid.NewGuid()
                               .ToString("N");

            var createResponse = client.PostAsync(
                                            OwinUriHelper.BuildOdsUri(resource),
                                            new StringContent(
                                                CreateResource(resource, uniqueId, lastName, firstName),
                                                Encoding.UTF8,
                                                "application/json"), CancellationToken.None).GetResultSafely();

            return new PersonHelperResponse
                   {
                       ResponseMessage = createResponse, UniqueId = uniqueId
                   };
        }
    }

    internal class StudentHelper
    {
        internal static PersonHelperResponse CreateStudent(HttpClient client, string lastName, string firstName)
        {
            return PersonHelper.CreatePerson(client, "students", lastName, firstName);
        }

        internal static PersonHelperResponse CreateStudentAndAssociateToSchool(HttpClient client, string lastName, string firstName, int schoolId)
        {
            var studentResponse = CreateStudent(client, lastName, firstName);

            if (studentResponse.ResponseMessage.IsSuccessStatusCode)
            {
                client.PostAsync(
                    OwinUriHelper.BuildOdsUri("StudentSchoolAssociations"),
                    new StringContent(
                        ResourceHelper.CreateStudentSchoolAssociation(studentResponse.UniqueId, schoolId),
                        Encoding.UTF8,
                        "application/json"), CancellationToken.None).WaitSafely();
            }

            return studentResponse;
        }

        internal static HttpResponseMessage CreateStudentParentAssociation(HttpClient client, string studentUniqueId, string parentUniqueId)
        {
            var association = new StudentParentAssociation
                              {
                                  StudentReference = new StudentReference
                                                     {
                                                         StudentUniqueId = studentUniqueId
                                                     },
                                  ParentReference = new ParentReference
                                                    {
                                                        ParentUniqueId = parentUniqueId
                                                    }
                              };

            return client.PostAsync(
                              OwinUriHelper.BuildOdsUri("StudentParentAssociations"),
                              new StringContent(JsonConvert.SerializeObject(association), Encoding.UTF8, "application/json"), CancellationToken.None)
                         .GetResultSafely();
        }
    }

    internal class ParentHelper
    {
        internal static PersonHelperResponse CreateParent(HttpClient client, string lastName, string firstName)
        {
            return PersonHelper.CreatePerson(client, "parents", lastName, firstName);
        }
    }

    internal class StaffHelper
    {
        internal static PersonHelperResponse CreateStaff(HttpClient client, string lastName, string firstName)
        {
            return PersonHelper.CreatePerson(client, "staffs", lastName, firstName);
        }
    }
}
