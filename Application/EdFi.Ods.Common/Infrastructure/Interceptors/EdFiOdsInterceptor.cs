// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Security.CustomViewBased;
using log4net;
using NHibernate;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Common.Infrastructure.Interceptors
{
    public class EdFiOdsInterceptor : EmptyInterceptor
    {
        /*
        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsInterceptor));

        private const string SpaceLiteral = " ";

        private static readonly Regex regex = new(
            @$"(?<join>inner join\s+)\(?(?<basisEntity>\w+\.\w+) (?<alias>(?<aliasPrefix>{CustomViewHelpers.CustomViewAliasPrefixBase}[a-f\d]{{4}}_).*?\d_).*?(?<onClause>on[\s\(]+this_)",
            RegexOptions.Compiled);
        */

        public override bool? IsTransient(object entity)
        {
            var property = entity.GetType()
                                 .GetProperty("CreateDate");

            if (property != null)
            {
                bool isTransient = Convert.ToDateTime(property.GetValue(entity)) == default(DateTime);

                return isTransient;
            }

            return base.IsTransient(entity);
        }

        /*
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            // Determine if we need to perform custom authorization view SQL manipulation
            if (sql.IndexOf(CustomViewHelpers.CustomViewAliasPrefixBase, 0, sql.Length, StringComparison.Ordinal) >= 0)
            {
                var matches = regex.Matches(sql.ToString());

                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    var match = matches[i];
                    
                    var preamble = sql.Substring(0, match.Groups["join"].Index + match.Groups["join"].Length);
                    var viewName = CustomViewHelpers.GetViewName(match.Groups["aliasPrefix"].Value);

                    var final = new SqlString(
                        preamble,
                        SystemConventions.AuthSchema,
                        ".",
                        viewName,
                        SpaceLiteral,
                        match.Groups["alias"].Value,
                        SpaceLiteral,
                        sql.Substring(match.Groups["onClause"].Index));
                    
                    sql = final;
                }
            }

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Prepared SQL: {sql}");
            }

            return sql;
        }
        */
    }
}
