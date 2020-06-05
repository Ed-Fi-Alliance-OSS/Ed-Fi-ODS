// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Common.Infrastructure.Composites
{
    /// <summary>
    /// Defines a method for parsing the "fields" expression supplied in a query string parameter.
    /// </summary>
    public interface IFieldsExpressionParser
    {
        /// <summary>
        /// Parses the supplied expression into a hierarchical list-based representation for easier consumption.
        /// </summary>
        /// <param name="fieldsExpression">The fields expression to be parsed.</param>
        /// <returns>A hierarchical list-based representation of the fields expression.</returns>
        IReadOnlyList<SelectedResourceMember> ParseFields(string fieldsExpression);
    }

    /// <summary>
    /// Provides a method for parsing the "fields" query string parameter.
    /// </summary>
    public class FieldsExpressionParser : IFieldsExpressionParser
    {
        /// <summary>
        /// Parses the supplied expression into a hierarchical list-based representation for easier consumption.
        /// </summary>
        /// <param name="fieldsExpression">The fields expression to be parsed.</param>
        /// <returns>A hierarchical list-based representation of the fields expression.</returns>
        public IReadOnlyList<SelectedResourceMember> ParseFields(string fieldsExpression)
        {
            if (string.IsNullOrEmpty(fieldsExpression))
            {
                throw new ArgumentException("Field selection expression was not supplied.");
            }

            fieldsExpression = fieldsExpression.Trim();

            int anchor = 0;
            int pos = 0;

            var state = ParseState.SeekingMember;

            var allMembers = new List<SelectedResourceMember>();

            var stack = new Stack<List<SelectedResourceMember>>();

            var members = allMembers;

            while (pos < fieldsExpression.Length || state == ParseState.ChildrenParsed)
            {
                switch (state)
                {
                    case ParseState.AllMembersIncluded:

                        if (fieldsExpression[pos] != ')')
                        {
                            throw new ArgumentException("Fields expression uses '*' without enclosing parenthesis.");
                        }

                        state = ParseState.ChildrenParsed;
                        break;

                    case ParseState.SeekingMember:

                        // Skip over leading spaces
                        if (fieldsExpression[pos] == ' ')
                        {
                            anchor = ++pos;
                        }

                        // Check for the "all" symbol
                        else if (fieldsExpression[pos] == '*')
                        {
                            state = ParseState.AllMembersIncluded;
                            pos++;
                        }

                        // Check for premature child fields closing symbol with no children listed
                        else if (fieldsExpression[pos] == ')' && !members.Any())
                        {
                            throw new ArgumentException(
                                "Fields sub-expression does not contain any field names.");
                        }
                        else
                        {
                            state = ParseState.ParsingMember;
                        }

                        break;

                    case ParseState.ParsingMember:

                        if (fieldsExpression[pos] == ',')
                        {
                            state = ParseState.MemberParsed;
                        }
                        else if (fieldsExpression[pos] == '(')
                        {
                            state = ParseState.ParsingChildren;
                        }
                        else if (fieldsExpression[pos] == ')')
                        {
                            state = ParseState.ChildrenParsed;
                        }
                        else if (fieldsExpression[pos] == ' ')
                        {
                            state = ParseState.MemberParsed;
                        }
                        else if (!(char.IsLetterOrDigit(fieldsExpression[pos]) || fieldsExpression[pos] == '_'))
                        {
                            throw new ArgumentException(
                                string.Format("Unexpected character '{0}' in member name in field selection expression.", fieldsExpression[pos]));
                        }
                        else
                        {
                            pos++;
                        }

                        break;

                    case ParseState.MemberParsed:
                        string parsedMemberName = fieldsExpression.Substring(anchor, pos - anchor);

                        if (!string.IsNullOrEmpty(parsedMemberName))
                        {
                            members.Add(new SelectedResourceMember(parsedMemberName));
                        }

                        state = ParseState.SeekingMember;
                        anchor = ++pos;
                        break;

                    case ParseState.ParsingChildren:
                        var currentMember = new SelectedResourceMember(fieldsExpression.Substring(anchor, pos - anchor));
                        members.Add(currentMember);
                        state = ParseState.SeekingMember;
                        anchor = ++pos;

                        stack.Push(members);
                        members = currentMember.Children;

                        break;

                    case ParseState.ChildrenParsed:
                        string memberName = fieldsExpression.Substring(anchor, pos - anchor);

                        if (!string.IsNullOrEmpty(memberName) && memberName != ")")
                        {
                            members.Add(new SelectedResourceMember(memberName));
                        }

                        anchor = ++pos;

                        if (!stack.Any())
                        {
                            throw new ArgumentException("Fields expression contains too many closing parenthesis.");
                        }

                        members = stack.Pop();

                        state = ParseState.SeekingMember;
                        break;
                }
            }

            string finalMemberName = fieldsExpression.Substring(anchor, pos - anchor);

            if (!string.IsNullOrEmpty(finalMemberName))
            {
                members.Add(new SelectedResourceMember(finalMemberName));
            }

            if (stack.Count != 0)
            {
                throw new ArgumentException("Fields expression contains unclosed parenthesis.");
            }

            return allMembers;
        }

        /// <summary>
        /// Defines values that represent a simplistic state machine for parsing the 'fields' query string parameter.
        /// </summary>
        private enum ParseState
        {
            SeekingMember,
            ParsingMember,
            MemberParsed,
            ParsingChildren,
            ChildrenParsed,
            AllMembersIncluded
        }
    }
}
