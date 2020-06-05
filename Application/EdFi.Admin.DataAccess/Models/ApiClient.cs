// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace EdFi.Admin.DataAccess.Models
{
    /// <summary>
    /// Class representing EdFi client application information persisted in a data store.
    /// A Client has a list of domains that are valid for access
    /// </summary>
    public class ApiClient
    {
        public ApiClient()
        {
            ClientAccessTokens = new List<ClientAccessToken>();
            ApplicationEducationOrganizations = new Collection<ApplicationEducationOrganization>();
            Domains = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructor, optionally generating a new key and secret
        /// </summary>
        /// <param name="generateKey">true to generate a new key and secret</param>
        public ApiClient(bool generateKey = false)
            : this()
        {
            if (!generateKey)
            {
                return;
            }

            Key = GenerateRandomString(12);
            Secret = GenerateRandomString();
        }

        /// <summary>
        /// Numeric Identifier
        /// </summary>
        public int ApiClientId { get; set; }

        /// <summary>
        /// Primary lookup for the application
        /// Also known as the client_id
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        /// <summary>
        /// 128-bit crypto-strength string 
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Secret { get; set; }

        /// <summary>
        /// Indicates if the secret is hashed
        /// </summary>
        public bool SecretIsHashed { get; set; }

        /// <summary>
        /// Something friendly to display to the users
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Lock-out the application if not approved (Auto-approve in sandbox)
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Does the client API access their own database (copy of empty EdFi Ods)
        /// true - use a sandbox
        /// false - use a shared instance
        /// </summary>
        public bool UseSandbox { get; set; }

        public SandboxType SandboxType { get; set; }

        public string SandboxTypeName
        {
            get { return SandboxType.ToString(); }
        }

        [NotMapped]
        public string Status { get; set; }

        /// <summary>
        /// Indicates client access status to the key. 
        /// "Not Sent": credentials has not been sent to the client yet
        /// "Sent": challenge has been sent to the client and waiting for activation
        /// "Active": client has successfully retrieved the credentials
        /// "Locked": client has retried more than what they are supposed to
        /// </summary>
        public string KeyStatus { get; set; }

        /// <summary>
        /// A random ID to be emailed to the client to enable them to challenge activationCode
        /// </summary>
        public string ChallengeId { get; set; }

        /// <summary>
        /// Time-stamp of ChallengeId and ActivationCode generation
        /// </summary>
        public DateTime? ChallengeExpiry { get; set; }

        /// <summary>
        /// Expecting challenge answer to activate the api and send credentials
        /// </summary>
        public string ActivationCode { get; set; }

        /// <summary>
        /// Number of retries client has done to get the credentials. 
        /// </summary>
        public int? ActivationRetried { get; set; }

        /// <summary>
        /// Have a reference to OwnershipToken table ownershiptokenid for specific apiclient. 
        /// </summary>
        public virtual OwnershipToken CreatorOwnershipTokenId { get; set; }

        /// <summary>
        /// Fully namespaced URI reference to the StudentIdentificationSystemDescriptor value to use for identification mapping
        /// </summary>
        [StringLength(306)]
        public string StudentIdentificationSystemDescriptor { get; set; }

        public virtual Application Application { get; set; }

        public virtual User User { get; set; }

        public ICollection<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        public List<ClientAccessToken> ClientAccessTokens { get; set; }

        /// <summary>
        /// Key-value store of EdOrg and Domain Connection information
        /// </summary>
        /// <remarks>
        /// EdOrg is the key, Domain Connection information is the value.
        /// The end-user should never see the Data Connection information
        /// </remarks>
        public Dictionary<string, string> Domains { get; set; }

        /// <summary>
        /// Method to generate a new secret 128-bit crypto-strength random number 
        /// and returns the new secret for display or other purposes.
        /// </summary>
        /// <param name="length">The length of the string to be generated</param>
        /// <returns>Random string with only alphanumeric values (no '+' or '/')</returns>        
        private static string GenerateRandomString(int length = 24)
        {
            string result;
            var numBytes = (length + 3) / 4 * 3;
            var bytes = new byte[numBytes];

            using (var rng = new RNGCryptoServiceProvider())
            {
                do
                {
                    rng.GetBytes(bytes);
                    result = Convert.ToBase64String(bytes);
                }
                while (result.Contains("+") || result.Contains("/"));
            }

            return result.Substring(0, length);
        }

        /// <summary>
        /// Set a new secret for the Client
        /// </summary>
        /// <returns>New client secret value</returns>
        public string GenerateSecret()
        {
            return Secret = GenerateRandomString();
        }
    }
}
