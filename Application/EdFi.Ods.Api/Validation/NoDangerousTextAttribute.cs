// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web;

namespace EdFi.Ods.Api.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NoDangerousTextAttribute : ValidationAttribute
    {
        private static readonly Lazy<IsDangerousStringDelegate> _isDangerous =
            new Lazy<IsDangerousStringDelegate>(GetCrossSiteScriptingValidationDelegate);

        private static IsDangerousStringDelegate GetCrossSiteScriptingValidationDelegate()
        {
            // Get access to internal static class from System.Web
            var type = typeof(HttpApplication).Assembly.GetType("System.Web.CrossSiteScriptingValidation");

            if (type == null)
            {
                throw new Exception(
                    "Unable to find the cross site scripting validation component (System.Web.CrossSiteScriptingValidation) in System.Web.");
            }

            var method = type.GetMethod("IsDangerousString", BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                throw new Exception("Unable to find the 'IsDangerousString' method on the CrossSiteScriptingValidation class.");
            }

            // Create a delegate
            return (IsDangerousStringDelegate) Delegate.CreateDelegate(typeof(IsDangerousStringDelegate), method);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string s = value as string;

            if (string.IsNullOrEmpty(s))
            {
                return ValidationResult.Success;
            }

            // Execute the delegate against the internal .NET method
            int matchIndex;

            if (_isDangerous.Value(s, out matchIndex))
            {
                return new ValidationResult(string.Format("{0} contains a potentially dangerous value.", validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        private delegate bool IsDangerousStringDelegate(string s, out int matchIndex);
    }
}
