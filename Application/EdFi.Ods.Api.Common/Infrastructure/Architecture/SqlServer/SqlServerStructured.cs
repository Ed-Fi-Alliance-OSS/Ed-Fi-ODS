// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.SqlServer
{
    /// <summary>
    /// Provides an abstract implementation of a custom NHibernate <see cref="IType"/> that provides 
    /// access to SQL Server table-valued parameters through the <see cref="SqlDbType.Structured"/> 
    /// parameter type.
    /// </summary>
    public class SqlServerStructured<T> : IType
    {
        private static readonly SqlType[] _sqlTypes =
        {
            new SqlType(DbType.Object)
        };
        private readonly string _sqlServerTypeName;

        public SqlServerStructured()
        {
            // Provide explicit support for supported SQL Server user-defined table types.
            if (typeof(T) == typeof(Guid))
            {
                _sqlServerTypeName = "UniqueIdentifierTable";
            }
            else if (typeof(T) == typeof(int))
            {
                _sqlServerTypeName = "IntTable";
            }
            else
            {
                throw new NotSupportedException($"SqlStructured support for '{GetType().FullName}' is not yet supported.");
            }
        }

        public bool IsXMLElement
        {
            get { throw new NotImplementedException(); }
        }

        public SqlType[] SqlTypes(IMapping mapping) => _sqlTypes;

        public bool IsCollectionType => true;

        public int GetColumnSpan(IMapping mapping) => 1;

        public Task NullSafeSetAsync(DbCommand st, object value, int index, ISessionImplementor session, CancellationToken cancellationToken)
        {
            return Task.Run(() => NullSafeSet(st, value, index, session), cancellationToken);
        }

        public void NullSafeSet(DbCommand st, object value, int index, ISessionImplementor session)
        {
            if (st == null)
            {
                throw new ArgumentNullException(nameof(st));
            }

            var s = st as SqlCommand;

            if (s == null)
            {
                throw new NotSupportedException(
                    $"The {GetType().Name} was expecting an IDbCommand of type '{typeof(SqlCommand).FullName}' but encountered a command of type '{st.GetType().FullName}'.");
            }

            s.Parameters[index]
             .SqlDbType = SqlDbType.Structured;

            s.Parameters[index]
             .TypeName = _sqlServerTypeName;

            s.Parameters[index]
             .Value = value;
        }

        public Type ReturnedClass => typeof(DataTable);

        public string ToLoggableString(object value, ISessionFactoryImplementor factory)
        {
            var dt = (value as DataTable);

            if (dt == null)
                return "[null]";

            return "[" + string.Join(", ", GetRows(dt).Select(r => r.ItemArray[0]?.ToString() ?? "[null]")) + "]";
        }

        private IEnumerable<DataRow> GetRows(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
                yield return row;
        }

        // Not Implemented Methods
        public Task<bool> IsDirtyAsync(object old, object current, ISessionImplementor session, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsDirtyAsync(object old, object current, bool[] checkable, ISessionImplementor session, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsModifiedAsync(
            object oldHydratedState,
            object currentState,
            bool[] checkable,
            ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> NullSafeGetAsync(
            DbDataReader rs,
            string[] names,
            ISessionImplementor session,
            object owner,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> NullSafeGetAsync(
            DbDataReader rs,
            string name,
            ISessionImplementor session,
            object owner,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task NullSafeSetAsync(
            DbCommand st,
            object value,
            int index,
            bool[] settable,
            ISessionImplementor session,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> HydrateAsync(
            DbDataReader rs,
            string[] names,
            ISessionImplementor session,
            object owner,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> ResolveIdentifierAsync(object value, ISessionImplementor session, object owner, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> SemiResolveAsync(object value, ISessionImplementor session, object owner, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> ReplaceAsync(
            object original,
            object target,
            ISessionImplementor session,
            object owner,
            IDictionary copiedAlready,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> ReplaceAsync(
            object original,
            object target,
            ISessionImplementor session,
            object owner,
            IDictionary copyCache,
            ForeignKeyDirection foreignKeyDirection,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> DisassembleAsync(object value, ISessionImplementor session, object owner, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<object> AssembleAsync(object cached, ISessionImplementor session, object owner, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task BeforeAssembleAsync(object cached, ISessionImplementor session, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public object Disassemble(object value, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public object Assemble(object cached, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public void BeforeAssemble(object cached, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        public bool IsDirty(object old, object current, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        public bool IsDirty(object old, object current, bool[] checkable, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        public bool IsModified(object oldHydratedState, object currentState, bool[] checkable, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public object NullSafeGet(DbDataReader rs, string name, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public void NullSafeSet(DbCommand st, object value, int index, bool[] settable, ISessionImplementor session)
        {
            throw new NotImplementedException();
        }

        public object DeepCopy(object val, ISessionFactoryImplementor factory)
        {
            throw new NotImplementedException();
        }

        public object Hydrate(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public object ResolveIdentifier(object value, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public object SemiResolve(object value, ISessionImplementor session, object owner)
        {
            throw new NotImplementedException();
        }

        public object Replace(object original, object target, ISessionImplementor session, object owner, IDictionary copiedAlready)
        {
            throw new NotImplementedException();
        }

        public object Replace(
            object original,
            object target,
            ISessionImplementor session,
            object owner,
            IDictionary copyCache,
            ForeignKeyDirection foreignKeyDirection)
        {
            throw new NotImplementedException();
        }

        public bool IsSame(object x, object y)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(object x, object y)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(object x, object y, ISessionFactoryImplementor factory)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(object x)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(object x, ISessionFactoryImplementor factory)
        {
            throw new NotImplementedException();
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }

        public IType GetSemiResolvedType(ISessionFactoryImplementor factory)
        {
            throw new NotImplementedException();
        }

        public bool[] ToColumnNullness(object value, IMapping mapping)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsMutable
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAssociationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsComponentType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsEntityType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAnyType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
