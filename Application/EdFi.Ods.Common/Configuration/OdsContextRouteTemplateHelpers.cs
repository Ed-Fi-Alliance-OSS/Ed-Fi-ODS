// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EdFi.Ods.Common.Configuration;

public static class OdsContextRouteTemplateHelpers
{
    private static readonly Regex _routeKeyRegex = new("\\{(?<RouteKey>\\w+)(:regex\\(.+?\\)|:[^}]+)?\\}", RegexOptions.Compiled);

    /// <summary>
    /// Extracts the route template keys from the supplied ODS context route template.
    /// </summary>
    /// <param name="odsContextRouteTemplate"></param>
    /// <returns>An array of route template key names.</returns>
    public static string[] GetRouteTemplateKeys(string odsContextRouteTemplate)
    {
        var matches = _routeKeyRegex.Matches(odsContextRouteTemplate);
        return matches.Select(m => m.Groups["RouteKey"].Value).ToArray();
    }
    
    /// <summary>
    /// Process the <see cref="ApiSettings.OdsContextRouteTemplate"/> and returns only the characters that are appropriate
    /// for use in building a URI template representation.
    /// </summary>
    /// <returns>An enumerable collection of path characters (to be combined into a string).</returns>
    public static IEnumerable<char> GetOdsContextPathChars(string odsContextRouteTemplate)
    {
        PathState state = PathState.PathLiteral;

        int i = 0;
        int keyConstraintDepth = 0;

        while (i < odsContextRouteTemplate.Length)
        {
            var pathChar = odsContextRouteTemplate[i];

            switch (state)
            {
                case PathState.PathLiteral:
                    if (pathChar == '{')
                    {
                        state = PathState.RouteKey;
                    }

                    yield return pathChar;
                    i++;

                    break;

                case PathState.RouteKey:
                    if (pathChar == '}')
                    {
                        state = PathState.PathLiteral;
                        yield return pathChar;
                    }
                    else if (pathChar == ':')
                    {
                        keyConstraintDepth = 1;
                        state = PathState.RouteConstraint;
                    }
                    else
                    {
                        yield return pathChar;
                    }

                    i++;

                    break;

                case PathState.RouteConstraint:
                    if (pathChar == '{')
                    {
                        keyConstraintDepth++;
                    }
                    else if (pathChar == '}')
                    {
                        keyConstraintDepth--;

                        if (keyConstraintDepth == 0)
                        {
                            yield return pathChar;
                            state = PathState.PathLiteral;
                        }
                    }

                    i++;

                    break;
            }
        }

        if (state != PathState.PathLiteral)
        {
            throw new ArgumentException("Invalid ODS context route template.");
        }
    }

    private enum PathState
    {
        PathLiteral,
        RouteKey,
        RouteConstraint
    }
}
