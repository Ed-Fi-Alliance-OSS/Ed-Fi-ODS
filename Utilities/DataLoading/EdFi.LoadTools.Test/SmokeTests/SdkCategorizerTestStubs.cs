// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

// Stub SDK shapes that mimic openapi-generator output, used to exercise SdkCategorizer independently
// of any specific Ed-Fi Data Standard / TestSdk version. SdkCategorizer scans an assembly's exported
// types filtered by the "Apis.All" / "Models.All" namespace segments, so these are public and live in
// matching namespaces; a test points a fake ISdkLibraryFactory at this (the test) assembly.

namespace EdFi.LoadTools.Test.SmokeTests.SdkStubs.Models.All
{
    public class EdFiContact { }

    public class HomographContact { }

    public class EdFiSchool { }

    public class HomographSchool { }

    public class EdFiStudent { }

    public class EdFiPerson { }
}

namespace EdFi.LoadTools.Test.SmokeTests.SdkStubs.Apis.All
{
    using System.Threading.Tasks;
    using EdFi.LoadTools.Test.SmokeTests.SdkStubs.Models.All;

    // Homonym resources disambiguated by the generator's "_N" suffix (the EdFi.OdsApi.Sdk convention,
    // e.g. PostContact_0Async / GetContacts_0Async). Also carries the non-CRUD companions the
    // categorizer must ignore.
    public class StubContactsApi
    {
        public Task PostContactAsync(EdFiContact contact) => Task.CompletedTask;

        public Task PostContact_0Async(HomographContact contact) => Task.CompletedTask;

        public Task GetContactsAsync() => Task.CompletedTask;

        public Task GetContacts_0Async() => Task.CompletedTask;

        public Task GetContactsByIdAsync(string id) => Task.CompletedTask;

        public Task GetContactsById_0Async(string id) => Task.CompletedTask;

        public Task PutContactAsync(string id, EdFiContact contact) => Task.CompletedTask;

        public Task PutContact_0Async(string id, HomographContact contact) => Task.CompletedTask;

        public Task DeleteContactByIdAsync(string id) => Task.CompletedTask;

        public Task DeleteContactById_0Async(string id) => Task.CompletedTask;

        // The following must be ignored by the categorizer.
        public Task GetContactsPartitionsAsync() => Task.CompletedTask;

        public Task DeletesContactsAsync() => Task.CompletedTask;

        public Task KeyChangesContactsAsync() => Task.CompletedTask;

        public Task PostContactOrDefaultAsync(EdFiContact contact) => Task.CompletedTask;
    }

    // Homonym resources disambiguated by distinct name stems (the EdFi.DmsApi.TestSdk convention,
    // e.g. PostHomographSchoolAsync). POST/DELETE are singular while GET is plural.
    public class StubSchoolsApi
    {
        public Task PostSchoolAsync(EdFiSchool school) => Task.CompletedTask;

        public Task PostHomographSchoolAsync(HomographSchool school) => Task.CompletedTask;

        public Task GetSchoolsAsync() => Task.CompletedTask;

        public Task GetHomographSchoolsAsync() => Task.CompletedTask;

        public Task GetSchoolsByIdAsync(string id) => Task.CompletedTask;

        public Task GetHomographSchoolsByIdAsync(string id) => Task.CompletedTask;

        public Task PutSchoolAsync(string id, EdFiSchool school) => Task.CompletedTask;

        public Task PutHomographSchoolAsync(string id, HomographSchool school) => Task.CompletedTask;

        public Task DeleteSchoolByIdAsync(string id) => Task.CompletedTask;

        public Task DeleteHomographSchoolByIdAsync(string id) => Task.CompletedTask;
    }

    // A conventional single-resource API class.
    public class StubStudentsApi
    {
        public Task PostStudentAsync(EdFiStudent student) => Task.CompletedTask;

        public Task GetStudentsAsync() => Task.CompletedTask;

        public Task GetStudentsByIdAsync(string id) => Task.CompletedTask;

        public Task PutStudentAsync(string id, EdFiStudent student) => Task.CompletedTask;

        public Task DeleteStudentByIdAsync(string id) => Task.CompletedTask;
    }

    // A single-resource API whose resource pluralizes irregularly (Person -> People). Because there is
    // exactly one resource, the categorizer's fast path assigns every method to it without name-stem
    // matching, so the irregular plural is fully supported. (Mirrors the cached ODS PeopleApi.)
    public class StubPeopleApi
    {
        public Task PostPersonAsync(EdFiPerson person) => Task.CompletedTask;

        public Task GetPeopleAsync() => Task.CompletedTask;

        public Task GetPeopleByIdAsync(string id) => Task.CompletedTask;

        public Task PutPersonAsync(string id, EdFiPerson person) => Task.CompletedTask;

        public Task DeletePersonByIdAsync(string id) => Task.CompletedTask;
    }
}
