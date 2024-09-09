// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

/// <summary>
/// Implements a hint provider for custom view-based authorization based on strict naming conventions for the authorization
/// strategy and corresponding underlying view.
/// </summary>
public class CustomAuthorizationViewHintProvider : IAuthorizationViewHintProvider
{
    private readonly ICustomViewBasisEntityProvider _customViewBasisEntityProvider;

    private static readonly HashSet<string> _prepositions = new(StringComparer.OrdinalIgnoreCase)
    {
        "a", "about", "above", "across", "after", "against", "along", "among", "an", "and", "around", "as", "at", "before",
        "behind", "below", "beneath", "beside", "between", "beyond", "by", "despite", "down", "during", "except", "for", "from",
        "in", "inside", "into", "like", "near", "of", "off", "on", "onto", "opposite", "or", "out", "outside", "over", "past",
        "round", "since", "than", "the", "through", "to", "towards", "under", "underneath", "unlike", "until", "up", "upon", 
        "via", "with", "within", "without"
    };
    
    public CustomAuthorizationViewHintProvider(ICustomViewBasisEntityProvider customViewBasisEntityProvider)
    {
        _customViewBasisEntityProvider = customViewBasisEntityProvider;
    }

    public string GetFailureHint(string viewName)
    {
        // Determine if the view name, used as the authorization strategy name, satisfies the conventions for custom view-based authorization 
        string authorizationStrategyName = viewName;
        var result = _customViewBasisEntityProvider.GetBasisEntity(authorizationStrategyName);

        // If the view name fails to match an entity by name, we can provide no hint.
        if (result.entity == null)
        {
            return null;
        }

        // Parse the name of the view to construct postamble of a hint sentence.
        string displayText = viewName.NormalizeCompositeTermForDisplay(SetCasing);
        
        return $"You may need {( StartsWithVowel(displayText) ? "an" : "a")} {displayText}.";

        bool StartsWithVowel(string text)
        {
            return text[0] is 'A' or 'E' or 'I' or 'O' or 'U';
        }

        string SetCasing(string term)
        {
            // If it's a preposition
            if (_prepositions.TryGetValue(term, out string exactCaseTerm))
            {
                return exactCaseTerm;
            }

            return term;
        }
    }
}
