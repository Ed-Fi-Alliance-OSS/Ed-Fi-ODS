// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public static class PagingHelpers
{
    public static string GetPageToken(int rangeMin, int rangeMax)
    {
        var bytes = Encoding.UTF8.GetBytes($"{rangeMin},{rangeMax}");
        string base64 = Convert.ToBase64String(bytes);

        // Replace '+' with '-', '/' with '_', and remove any '=' padding
        string pageToken = base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
        
        return pageToken;
    }

    public static (int minAggregateId, int maxAggregateId) GetAggregateIdRange(string pageToken)
    {
        // Replace '-' with '+', '_' with '/', and add padding back if necessary
        string base64 = pageToken.Replace('-', '+').Replace('_', '/');

        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        // Convert the Base64 string to bytes
        byte[] bytes = Convert.FromBase64String(base64);
        string decodedString = Encoding.UTF8.GetString(bytes);

        var minMaxAggregateIds = decodedString.Split(',');

        if (string.IsNullOrEmpty(minMaxAggregateIds[0]))
        {
            throw new BadRequestParameterException(BadRequestException.DefaultDetail, ["The page token provided was invalid."]);
        }

        try
        {
            return (
                Convert.ToInt32(minMaxAggregateIds[0]), 
                string.IsNullOrEmpty(minMaxAggregateIds[1]) ? int.MaxValue : Convert.ToInt32(minMaxAggregateIds[1]));
        }
        catch (Exception ex)
        {
            throw new BadRequestParameterException(BadRequestException.DefaultDetail, ["The page token provided was invalid."], ex);
        }
    }
}
