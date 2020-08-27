// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EdFi.Ods.Admin.Services
{
    public class EmailService : IEmailService
    {
        private readonly IRouteService _routeService;

        public EmailService(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public void SendConfirmationEmail(string emailAddress, string secret)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.AppendLine(
                @"An account has been created for email address '" + emailAddress +
                "' in Sandbox Admin.");

            messageBuilder.AppendLine();
            messageBuilder.AppendLine(@"Please follow this link to set your password:");
            messageBuilder.AppendLine();
            messageBuilder.AppendLine(_routeService.GetRouteForActivation(secret));

            var body = string.Format(messageBuilder.ToString(), secret);

            var message = new MailMessage
                          {
                              Subject = "Sandbox Account Activation", Body = body
                          };

            message.To.Add(new MailAddress(emailAddress));

            GetSmtpClientWithEnvironmentVariableExpansion()
               .Send(message);
        }

        public void SendForgotPasswordEmail(string emailAddress, string secret)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(@"You have requested a password reset for your account in Sandbox Admin.");
            messageBuilder.AppendLine();
            messageBuilder.AppendLine(@"In order to reset your password, please follow this link:");
            messageBuilder.AppendLine(_routeService.GetRouteForPasswordReset(secret));

            var body = string.Format(messageBuilder.ToString(), secret);

            var message = new MailMessage
                          {
                              Subject = "Sandbox Account Password Reset", Body = body
                          };

            message.To.Add(new MailAddress(emailAddress));

            GetSmtpClientWithEnvironmentVariableExpansion()
               .Send(message);
        }

        private static SmtpClient GetSmtpClientWithEnvironmentVariableExpansion()
        {
            var smtpClient = new SmtpClient();
            var smtpUsername = ConfigurationManager.AppSettings.Get("smtp:Username");
            var smtpPassword = ConfigurationManager.AppSettings.Get("smtp:Password");

            if (smtpUsername != null && smtpPassword != null)
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            }

            // Expand any embedded environment variables
            if (smtpClient.PickupDirectoryLocation != null)
            {
                smtpClient.PickupDirectoryLocation = Environment.ExpandEnvironmentVariables(smtpClient.PickupDirectoryLocation);

                // Try to make sure that the specified email directory exists
                try
                {
                    Directory.CreateDirectory(smtpClient.PickupDirectoryLocation);
                }
                catch { }
            }

            return smtpClient;
        }
    }
}
