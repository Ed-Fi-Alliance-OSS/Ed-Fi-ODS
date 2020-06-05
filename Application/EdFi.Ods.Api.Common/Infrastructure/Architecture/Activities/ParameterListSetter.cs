// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using NHibernate;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities
{
    /// <summary>
    /// Implements a default <see cref="IParameterListSetter" /> as a straight pass-through to NHibernate.
    /// </summary>
    public class ParameterListSetter : IParameterListSetter
    {
        /// <summary>
        /// Sets the value of parameter list (by name) to the supplied list of Ids.
        /// </summary>
        /// <param name="query">The NHibernate query.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="ids">The list of Ids to be assigned to the parameter's value.</param>
        public void SetParameterList(IQuery query, string name, IEnumerable ids)
        {
            query.SetParameterList(name, ids);
        }
    }
}
