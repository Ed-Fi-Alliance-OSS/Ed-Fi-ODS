// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Driver;
using NHibernate.Engine;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public class EdFiNpgsqlDriver : ReflectionBasedDriver, IEmbeddedBatcherFactoryProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlDriver"/> class.
        /// </summary>
        /// <exception cref="HibernateException">
        /// Thrown when the <c>Npgsql</c> assembly can not be loaded.
        /// </exception>
        public EdFiNpgsqlDriver() : base(
            "Npgsql",
            "Npgsql",
            "Npgsql.NpgsqlConnection",
            "Npgsql.NpgsqlCommand")
        {
        }

        public override bool UseNamedPrefixInSql => true;

        public override bool UseNamedPrefixInParameter => true;

        public override string NamedPrefix => ":";

        public override bool SupportsMultipleOpenReaders => false;

        /// <remarks>
        /// NH-2267 Patrick Earl
        /// </remarks>
        protected override bool SupportsPreparingCommands => true;

        public override bool SupportsNullEnlistment => false;

        public override IResultSetsCommand GetResultSetsCommand(ISessionImplementor session)
        {
            return new BasicResultSetsCommand(session);
        }

        public override bool SupportsMultipleQueries => true;

        // ---------------------------------------------------------------------------------
        // NOTE: This is the only change from the standard NHibernate NpgsqlDriver class
        // Their decision to convert currency to decimal is based on the fact that the DbType.Currency
        // defines precision to 1/10,000th of a currency unit (aka 4 digits), while the
        // Postgres 'money' data type only has 2 digits. However, given our use case of using
        // the .NET decimal property on a resource class merely as the conduit of a JSON payload
        // on its way to/from the database, there really is no expectation that this represents
        // data loss. Therefore, we choose to use the Currency type for the Postgres model where
        // data is stored using the 'money' data type.
        // ---------------------------------------------------------------------------------
        // protected override void InitializeParameter(DbParameter dbParam, string name, SqlType sqlType)
        // {
        //     base.InitializeParameter(dbParam, name, sqlType);
        //
        //     // Since the .NET currency type has 4 decimal places, we use a decimal type in PostgreSQL instead of its native 2 decimal currency type.
        //     // if (sqlType.DbType == DbType.Currency)
        //     //     dbParam.DbType = DbType.Decimal;
        // }

        // Prior to v3, Npgsql was expecting DateTime for time.
        // https://github.com/npgsql/npgsql/issues/347
        public override bool RequiresTimeSpanForTime => (DriverVersion?.Major ?? 3) >= 3;

        public override bool HasDelayedDistributedTransactionCompletion => true;

        System.Type IEmbeddedBatcherFactoryProvider.BatcherFactoryClass => typeof(GenericBatchingBatcherFactory);
    }
}
