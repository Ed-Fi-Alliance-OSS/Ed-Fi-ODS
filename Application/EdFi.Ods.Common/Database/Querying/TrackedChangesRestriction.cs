// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Database.Querying
{
    /// <summary>
    /// Identifies the rows of a tracked changes table that a change query is about, so an authorization filter can
    /// restrict what it materializes to the same rows.
    /// </summary>
    /// <remarks>
    /// Deletes and key changes read the same table and are told apart by whether the new key values are present, so
    /// a filter that restricted by the table alone would treat a table holding only the other kind of change as work
    /// to be done. Carrying the two together makes that state unrepresentable, and carrying the column rather than a
    /// SQL fragment keeps predicate shape and alias qualification with the dialect that renders them.
    /// </remarks>
    public sealed class TrackedChangesRestriction
    {
        /// <summary>
        /// Initializes a restriction with what the change query knows: the table it reads and the column that tells
        /// one kind of change from the other.
        /// </summary>
        /// <param name="tableName">The tracked changes table, schema-qualified and without an alias.</param>
        /// <param name="changeKindColumnName">The column holding the new value of the resource's first key property.</param>
        /// <param name="selectsNewValues"><b>true</b> for key changes, which keep their new key values; <b>false</b> for deletes, which do not.</param>
        public TrackedChangesRestriction(string tableName, string changeKindColumnName, bool selectsNewValues)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(tableName);
            ArgumentException.ThrowIfNullOrWhiteSpace(changeKindColumnName);

            TableName = tableName;
            ChangeKindColumnName = changeKindColumnName;
            SelectsNewValues = selectsNewValues;
        }

        private TrackedChangesRestriction(TrackedChangesRestriction other, string personColumnName)
            : this(other.TableName, other.ChangeKindColumnName, other.SelectsNewValues)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(personColumnName);

            PersonColumnName = personColumnName;
        }

        public string TableName { get; }

        public string ChangeKindColumnName { get; }

        public bool SelectsNewValues { get; }

        /// <summary>
        /// Gets the tracked changes column holding the person identifier, which only the authorization filter knows.
        /// </summary>
        public string PersonColumnName { get; }

        /// <summary>
        /// Completes the restriction with the tracked changes column the authorization filter matches people on.
        /// </summary>
        public TrackedChangesRestriction ForPersonColumn(string personColumnName)
        {
            return new TrackedChangesRestriction(this, personColumnName);
        }
    }
}
