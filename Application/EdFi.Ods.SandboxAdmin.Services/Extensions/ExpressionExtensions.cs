// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq.Expressions;

namespace EdFi.Ods.SandboxAdmin.Services.Extensions
{
    public static class ExpressionExtensions
    {
        public static string MemberName(this LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            var methodExpression = expression.Body as MethodCallExpression;

            if (methodExpression != null)
            {
                return methodExpression.Method.Name;
            }

            var unaryExpression = expression.Body as UnaryExpression;

            if (unaryExpression != null)
            {
                var unaryMember = unaryExpression.Operand as MemberExpression;

                if (unaryMember == null)
                {
                    throw new ArgumentException(string.Format("Strange operand in unary expression '{0}'", expression));
                }

                return unaryMember.Member.Name;
            }

            throw new ArgumentException(string.Format("Expression '{0}' of type '{1}' is not handled", expression, expression.Body.GetType()));
        }
    }
}