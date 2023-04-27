// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class NHibernateRepositoryDeleteOperationBase<TEntity>
        : NHibernateRepositoryOperationBase
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IETagProvider _eTagProvider;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private ConcurrentDictionary<FullName, DbCommand> _deleteCommandByEntityFullName = new();

        public NHibernateRepositoryDeleteOperationBase(
            ISessionFactory sessionFactory,
            IETagProvider eTagProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
            : base(sessionFactory)
        {
            _eTagProvider = eTagProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        protected async Task DeleteAsync(TEntity persistedEntity, string etag, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                if (persistedEntity == null)
                {
                    throw new NotFoundException("Resource to delete was not found.");
                }

                // only check last modified data
                if (!string.IsNullOrEmpty(etag))
                {
                    var lastModifiedDate = _eTagProvider.GetDateTime(etag);

                    if (!persistedEntity.LastModifiedDate.Equals(lastModifiedDate))
                    {
                        throw new ConcurrencyException("Resource was modified by another consumer.");
                    }
                }

                using (var trans = await Session.Connection.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        Entity entity = _dataManagementResourceContextProvider.Get().Resource.Entity;

                        await DeleteRecordForEntity(trans, entity);

                        if (entity.IsDerived)
                        {
                            await DeleteRecordForEntity(trans, entity.BaseEntity);
                        }

                        await trans.CommitAsync(cancellationToken);
                    }
                    catch (Exception)
                    {
                        await trans.RollbackAsync(cancellationToken);
                        throw;
                    }
                }
            }

            async Task DeleteRecordForEntity(DbTransaction trans, Entity entity)
            {
                var templateCommand = _deleteCommandByEntityFullName.GetOrAdd(entity.FullName,
                    (fn, args) => CreateDeleteCommand(args, fn),
                    (Session.Connection, entity));

                var deleteCommand = (templateCommand as ICloneable)?.Clone() as DbCommand;

                if (deleteCommand == null)
                {
                    throw new Exception("Clone of the delete command was not successful.");
                }

                if (entity.IsDerived)
                {
                    int i = 0;
                    
                    foreach (var property in entity.Identifier.Properties)
                    {
                        // TODO ODS-5832 - Optimize using compiled lambda property access
                        // Consider use of this library: https://github.com/dadhi/FastExpressionCompiler
                        deleteCommand.Parameters[i++].Value =
                            persistedEntity.GetType().GetProperty(property.PropertyName).GetValue(persistedEntity);
                    }
                }
                else
                {
                    deleteCommand.Parameters[0].Value = persistedEntity.Id;
                }

                deleteCommand.Connection = Session.Connection;
                deleteCommand.Transaction = trans;
                await deleteCommand.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private static DbCommand CreateDeleteCommand((DbConnection connection, Entity entity) args, FullName fn)
        {
            var cmd = args.connection.CreateCommand();
            var e = args.entity;

            if (e.IsDerived)
            {
                var builder = new StringBuilder($"DELETE FROM {e.FullName} WHERE ");

                e.Identifier.Properties.ForEach(
                    (property, i, args) =>
                    {
                        var (c, sb) = args;
                        
                        if (i > 0)
                        {
                            sb.Append(" AND ");
                        }

                        sb.Append($"{property.PropertyName} = @pk{i}");

                        var idParm = c.CreateParameter();
                        idParm.ParameterName = $"pk{i}";
                        idParm.DbType = property.PropertyType.DbType;
                        c.Parameters.Add(idParm);
                    }, (cmd, builder));

                cmd.CommandText = builder.ToString();
            }
            else
            {
                cmd.CommandText = $"DELETE FROM {fn} WHERE Id = @id";

                var idParm = cmd.CreateParameter();
                idParm.ParameterName = "id";
                idParm.DbType = DbType.Guid;
                cmd.Parameters.Add(idParm);
            }

            return cmd;
        }
    }
}
