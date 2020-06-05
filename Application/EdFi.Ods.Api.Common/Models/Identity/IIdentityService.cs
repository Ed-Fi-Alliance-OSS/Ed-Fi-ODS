// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Expando;

namespace EdFi.Ods.Api.Common.Models.Identity
{
    [Flags]
    public enum IdentityServiceCapabilities
    {
        None = 0x0,
        Create = 0x1,
        Find = 0x2,
        Search = 0x4,
        Results = Find | Search
    }

    public enum SearchResponseStatus
    {
        Incomplete,
        Complete
    }

    /// <summary>
    /// Implement this interface if the supporting service supports synchronous methods
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Which IdentityServices does the supporting service implement
        /// </summary>
        IdentityServiceCapabilities IdentityServiceCapabilities { get; }

        /// <summary>
        /// Create one or more identities
        /// </summary>
        /// <param name="createRequest">an array of identities to be created</param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest);

        /// <summary>
        /// Find existing identities by their identifiers
        /// </summary>
        /// <param name="findRequest">Unique person identifiers to look up</param>
        /// <returns>An identity response status of: Success with IdentityResponse[]</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Find(params string[] findRequest);

        /// <summary>
        /// Search for exact and potential identity matches
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Search(params IdentitySearchRequest[] searchRequest);
    }

    /// <summary>
    /// Implement this interface if the supporting service supports asynchronous methods 
    /// </summary>
    public interface IIdentityServiceAsync
    {
        /// <summary>
        /// Which IdentityServices does the supporting service implement
        /// </summary>
        IdentityServiceCapabilities IdentityServiceCapabilities { get; }

        /// <summary>
        /// Begin an asynchronous request to find existing identities by their identifiers
        /// </summary>
        /// <param name="findRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Find(params string[] findRequest);

        /// <summary>
        /// Begin an asynchronous request to search for exact and potential identity matches
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>An identity response status of: Success</returns>
        Task<IdentityResponseStatus<string>> Search(params IdentitySearchRequest[] searchRequest);

        /// <summary>
        /// Retrieve the results from a previously submitted search
        /// </summary>
        /// <param name="requestToken">a unique string representing the request</param>
        /// <returns>An identity response status of: Incomplete, Success with IdentityResponse[], or NotFound</returns>
        Task<IdentityResponseStatus<IdentitySearchResponse>> Response(string requestToken);
    }

    public class Location
    {
        public string City { get; set; }

        public string StateAbbreviation { get; set; }

        public string InternationalProvince { get; set; }

        public string Country { get; set; }
    }

    public class IdentityCreateRequest : Expando
    {
        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public Location BirthLocation { get; set; }
    }

    public class IdentitySearchRequest : Expando
    {
        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public Location BirthLocation { get; set; }
    }

    public class IdentityResponse : Expando
    {
        public string UniqueId { get; set; }

        public decimal Score { get; set; }

        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public Location BirthLocation { get; set; }
    }

    public class IdentitySearchResponses
    {
        public IdentityResponse[] Responses { get; set; }
    }

    public class IdentitySearchResponse
    {
        public SearchResponseStatus Status { get; set; }

        public IdentitySearchResponses[] SearchResponses { get; set; }
    }
}
