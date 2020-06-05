// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public class User
    {
        public User()
        {
            ApiClients = new Collection<ApiClient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<ApiClient> ApiClients { get; set; }

        /// <summary>
        /// Create a new sandbox client
        /// </summary>
        /// <param name="name">The visible name of the sandbox</param>
        /// <param name="sandboxType">Empty, Minimal, Populated</param>
        /// <param name="key">optional parameter, value is created randomly if it is null or empty. Both Key and Secret are required if providing either.</param>
        /// <param name="secret">optional parameter, value is created randomly if it is null or empty. Both Key and Secret are required if providing either.</param>
        /// <returns>ApiClient information about the created sandbox</returns>
        public ApiClient AddSandboxClient(string name, SandboxType sandboxType, string key, string secret)
        {
            var client = new ApiClient(true)
                         {
                             Name = name, IsApproved = true, UseSandbox = true, SandboxType = sandboxType
                         };

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(secret))
            {
                client.Key = key;
                client.Secret = secret;
            }

            ApiClients.Add(client);
            return client;
        }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ProviderUserId { get; set; }
    }
}
