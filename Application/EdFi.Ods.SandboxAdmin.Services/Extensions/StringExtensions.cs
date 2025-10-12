// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Mail;

namespace EdFi.Ods.SandboxAdmin.Services.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmailAddress(this string address)
        {
            try
            {
                var ma = new MailAddress(address);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}