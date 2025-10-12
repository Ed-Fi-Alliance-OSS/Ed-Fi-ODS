// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using CommandLine;
using EdFi.OdsApi.Sdk.Apis.All;
using EdFi.OdsApi.Sdk.Client;
using EdFi.OdsApi.Sdk.Models.All;
using EdFi.OdsApi.SdkClient;

// Parse the command line arguments
var options = Parser.Default.ParseArguments<Options>(args)
    .WithNotParsed(e => e.Output()) // Show errors and help
    .Value;

if (options == default) return;

// Trust all SSL certs -- needed unless signed SSL certificates are configured.
System.Net.ServicePointManager.ServerCertificateValidationCallback =
    ((sender, certificate, chain, sslPolicyErrors) => true);

//Explicitly configures outgoing network calls to use the latest version of TLS where possible.
//Due to our reliance on some older libraries, the.NET framework won't necessarily default
//to the latest unless we explicitly request it. Some hosting environments will not allow older versions
//of TLS, and thus calls can fail without this extra configuration.
System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;

// TokenRetriever makes the oauth calls. It has RestSharp dependency
var tokenRetriever = new TokenRetriever(options.OdsApiUrl, options.ClientKey, options.ClientSecret);

// Plug Oauth access token. Tokens will need to be refreshed when they expire
var configuration = new Configuration() { AccessToken = tokenRetriever.ObtainNewBearerToken(), BasePath = $"{options.OdsApiUrl}/data/v3" };

// GET students
var apiInstance = new StudentsApi(configuration);
apiInstance.Configuration.DefaultHeaders.Add("Content-Type", "application/json");

// Fetch a single record with the totalCount flag set to true to retrieve the total number of records available
var studentWithHttpInfo = apiInstance.GetStudentsWithHttpInfo(limit: 1, offset: 0, totalCount: true);

var httpReponseCode = studentWithHttpInfo.StatusCode; // returns System.Net.HttpStatusCode.OK
Console.WriteLine("Response code is " + httpReponseCode);

// Parse the total count value out of the "Total-Count" response header
var totalCount = int.Parse(studentWithHttpInfo.Headers["Total-Count"].First());

int offset = 0;
int limit = 100;
var students = new List<EdFiStudent>();

while (offset < totalCount)
{
    Console.WriteLine($"Fetching student records {offset} through {Math.Min(offset + limit, totalCount)} of {totalCount}");
    students.AddRange(apiInstance.GetStudents(limit: limit, offset: 0));
    offset += limit;
}

Console.WriteLine();
Console.WriteLine("Student Results");

foreach (var student in students)
{
    Console.WriteLine($"Student: {student.StudentUniqueId}, {student.FirstName}, {student.LastSurname}");
}

Console.WriteLine();
Console.WriteLine("Hit ENTER key to continue...");
Console.ReadLine();