// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.ProgramAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ServiceDescriptorAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentProgramAssociationAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentTitleIPartAProgramAssociationAggregate.EdFi;
using EdFi.Ods.Repositories.NHibernate.Tests.Modules;
using EdFi.TestFixture;
using FakeItEasy;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Data;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using Test.Common.DataConstants;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [TestFixture]
    public class StudentProgramAssociationTests
    {
        public class When_upserting_student_program_and_derived_associations : TestFixtureBase
        {
            private string _studentUniqueId;

            private int _educationOrganization1;
            private int _educationOrganization2;

            private ServiceDescriptor _serviceDescriptor;
            private Program _program1;
            private Program _program2;
            private Student _student;

            // Dependencies
            private IContainer _container;
            private IUpsertEntity<Student> _studentRepo;
            private IUpsertEntity<Program> _programRepo;
            private IUpsertEntity<StudentProgramAssociation> _studentProgramAssociationRepo;
            private IUpsertEntity<StudentTitleIPartAProgramAssociation> _studentTitleIPartAProgramAssociationRepo;

            private IUpsertEntity<ServiceDescriptor> _upsertService;

            // Supplied values

            // Actual values
            private UpsertResults _actualStudentTitleIPartAUpsert1Results;
            private UpsertResults _actualStudentTitleIPartAUpsert2Results;
            private UpsertResults _actualStudentProgramAssociationUpsert1Results;
            private UpsertResults _actualStudentProgramAssociationUpsert2Results;
            private Exception _actualDeleteStudentProgramAssociationException;
            private Exception _actualDeleteStudentTitleIPartAAssociationException;
            private bool _actualServiceDeletedWithSecondUpsert;
            private bool _actualServiceDeletedWithSecondDerivedClassUpsert;
            private bool _actualProgramAssociationDeleted;
            private bool _actualTitleIProgramAssociationDeleted;

            protected override void Arrange()
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);
                RegisterDependencies();
                IDescriptorsCache cache = null;
                DescriptorsCache.GetCache = () => cache ??= _container.Resolve<IDescriptorsCache>();

                IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;

                PersonUniqueIdToUsiCache.GetCache = ()
                    => personUniqueIdToUsiCache ??= _container.Resolve<IPersonUniqueIdToUsiCache>();

                var assembly = typeof(Program).GetTypeInfo().Assembly;
                XmlConfigurator.Configure(LogManager.GetRepository(assembly));

                ClaimsPrincipal.ClaimsPrincipalSelector =
                    () => EdFiClaimsPrincipalSelector.GetClaimsPrincipal(_container.Resolve<IClaimsIdentityProvider>());

                _studentRepo = _container.Resolve<IUpsertEntity<Student>>();
                _programRepo = _container.Resolve<IUpsertEntity<Program>>();
                _studentProgramAssociationRepo = _container.Resolve<IUpsertEntity<StudentProgramAssociation>>();

                _studentTitleIPartAProgramAssociationRepo =
                    _container.Resolve<IUpsertEntity<StudentTitleIPartAProgramAssociation>>();

                _upsertService = _container.Resolve<IUpsertEntity<ServiceDescriptor>>();

                InitializeEducationOrganizationIdsForTest();

                _studentUniqueId = Guid.NewGuid()
                    .ToString("N");

                _serviceDescriptor = GetTestServiceDescriptor();
                _program1 = GetProgram1();
                _program2 = GetProgram2();
                _student = GetStudent();

                InitializeTestData();
            }

            protected override void Act()
            {
                // ----------------------------------------------------------------------
                // Create a new StudentProgramAssociation with a service
                // ----------------------------------------------------------------------
                var studentProgramAssociation = new StudentProgramAssociation
                {
                    StudentUniqueId = _student.StudentUniqueId,
                    ProgramTypeDescriptor = _program1.ProgramTypeDescriptor,
                    ProgramName = _program1.ProgramName,
                    ProgramEducationOrganizationId = _educationOrganization1,
                    BeginDate = DateTime.Today.AddDays(-60),
                    EducationOrganizationId = _educationOrganization1
                };

                var service = new StudentProgramAssociationService
                {
                    ServiceDescriptor = EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                        _serviceDescriptor.Namespace,
                        _serviceDescriptor.CodeValue),
                    PrimaryIndicator = true,
                    StudentProgramAssociation = studentProgramAssociation
                };

                studentProgramAssociation.StudentProgramAssociationServices.Add(service);

                var studentProgramAssociationUpsertResult = _studentProgramAssociationRepo.UpsertAsync(
                        studentProgramAssociation, false, CancellationToken.None)
                    .GetResultSafely();

                _actualStudentProgramAssociationUpsert1Results = new UpsertResults
                {
                    IsCreated = studentProgramAssociationUpsertResult.IsCreated,
                    IsModified = studentProgramAssociationUpsertResult.IsModified
                };

                // ----------------------------------------------------------------------
                // Update the StudentProgramAssociation, removing the service
                // ----------------------------------------------------------------------
                var studentProgramAssociation2 = new StudentProgramAssociation
                {
                    StudentUniqueId = _student.StudentUniqueId,
                    ProgramTypeDescriptor = _program1.ProgramTypeDescriptor,
                    ProgramName = _program1.ProgramName,
                    ProgramEducationOrganizationId = _educationOrganization1,
                    BeginDate = DateTime.Today.AddDays(-60),
                    ReasonExitedDescriptor = KnownDescriptors.ReasonExited.MovedOutOfState,
                    EducationOrganizationId = _educationOrganization1
                };

                studentProgramAssociationUpsertResult = _studentProgramAssociationRepo.UpsertAsync(
                        studentProgramAssociation2, false, CancellationToken.None)
                    .GetResultSafely();

                _actualStudentProgramAssociationUpsert2Results = new UpsertResults
                {
                    IsCreated = studentProgramAssociationUpsertResult.IsCreated,
                    IsModified = studentProgramAssociationUpsertResult.IsModified
                };

                var databaseEngine = DbHelper.GetDatabaseEngine();
                // Verify the service got removed
                using (var conn = GetDbConnectionForOds())
                {
                    conn.Open();

                    var cmd = DbHelper.GetCommand(databaseEngine,
                        $"SELECT COUNT(*) FROM edfi.StudentProgramAssociationService WHERE ProgramName = '{_program1.ProgramName}'",
                        conn);

                    _actualServiceDeletedWithSecondUpsert = 0 == Convert.ToInt32(cmd.ExecuteScalar());
                }

                // -------------------------------------------------------------------------------------------------------------
                // Create a new (derived class) StudentTitleIPartAProgramAssociation with a service hanging off the base class
                // -------------------------------------------------------------------------------------------------------------
                var studentTitleIPartA = new StudentTitleIPartAProgramAssociation
                {
                    // PK
                    StudentUniqueId = _student.StudentUniqueId,
                    ProgramTypeDescriptor = _program2.ProgramTypeDescriptor,
                    ProgramName = _program2.ProgramName,
                    ProgramEducationOrganizationId = _educationOrganization1,
                    BeginDate = DateTime.Today.AddDays(-60),
                    EducationOrganizationId = _educationOrganization2,

                    // Base class property
                    ReasonExitedDescriptor = KnownDescriptors.ReasonExited.MovedOutOfState,

                    // Derived class property
                    TitleIPartAParticipantDescriptor = KnownDescriptors.TitleIPartAParticipant.LocalNeglectedProgram
                };

                // Add a service to the base class
                var titleIService = new StudentTitleIPartAProgramAssociationService
                {
                    ServiceDescriptor = EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                        _serviceDescriptor.Namespace,
                        _serviceDescriptor.CodeValue),
                    PrimaryIndicator = true,
                    StudentTitleIPartAProgramAssociation = studentTitleIPartA
                };

                studentTitleIPartA.StudentTitleIPartAProgramAssociationServices.Add(titleIService);

                var studentTitleIPartAProgramAssociationUpsertResult = _studentTitleIPartAProgramAssociationRepo.UpsertAsync(
                        studentTitleIPartA, false, CancellationToken.None)
                    .GetResultSafely();

                _actualStudentTitleIPartAUpsert1Results = new UpsertResults
                {
                    IsCreated = studentTitleIPartAProgramAssociationUpsertResult.IsCreated,
                    IsModified = studentTitleIPartAProgramAssociationUpsertResult.IsModified
                };

                // -------------------------------------------------------------------------------------------------------------
                // Create a new (derived class) StudentTitleIPartAProgramAssociation with a service hanging off the base class
                // -------------------------------------------------------------------------------------------------------------
                var studentTitleIPartA2 = new StudentTitleIPartAProgramAssociation
                {
                    // PK
                    StudentUniqueId = _student.StudentUniqueId,
                    ProgramTypeDescriptor = _program2.ProgramTypeDescriptor,
                    ProgramName = _program2.ProgramName,
                    ProgramEducationOrganizationId = _educationOrganization1,
                    BeginDate = DateTime.Today.AddDays(-60),
                    EducationOrganizationId = _educationOrganization2,

                    // Base class property
                    ReasonExitedDescriptor = KnownDescriptors.ReasonExited.GraduatedWithAHighSchoolDiploma,

                    // Derived class property
                    TitleIPartAParticipantDescriptor = KnownDescriptors.TitleIPartAParticipant.PublicSchoolwideProgram
                };

                // Updating derived record, removing the service
                studentTitleIPartAProgramAssociationUpsertResult = _studentTitleIPartAProgramAssociationRepo.UpsertAsync(
                        studentTitleIPartA2, false, CancellationToken.None)
                    .GetResultSafely();

                _actualStudentTitleIPartAUpsert2Results = new UpsertResults
                {
                    IsCreated = studentTitleIPartAProgramAssociationUpsertResult.IsCreated,
                    IsModified = studentTitleIPartAProgramAssociationUpsertResult.IsModified
                };

                // Verify the service got removed
                using (var conn = GetDbConnectionForOds())
                {
                    conn.Open();

                    var cmd = DbHelper.GetCommand(
                        databaseEngine,
                        $"SELECT COUNT(*) FROM edfi.StudentProgramAssociationService WHERE ProgramName = '{_program2.ProgramName}'",
                        conn);

                    _actualServiceDeletedWithSecondDerivedClassUpsert = 0 == Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Clean up the data now
                // Delete the concrete base class (StudentProgramAssociation)
                try
                {
                    var deleteStudentProgramAssociationByKey =
                        _container.Resolve<IDeleteEntityByKey<StudentProgramAssociation>>();

                    deleteStudentProgramAssociationByKey.DeleteByKeyAsync(studentProgramAssociation, null, CancellationToken.None)
                        .WaitSafely();
                }
                catch (Exception ex)
                {
                    _actualDeleteStudentProgramAssociationException = ex;
                }

                // Verify the program association got removed
                using (var conn = GetDbConnectionForOds())
                {
                    conn.Open();

                    var cmd = DbHelper.GetCommand(
                        databaseEngine,
                        $"SELECT COUNT(*) FROM edfi.StudentProgramAssociationService WHERE ProgramName = '{_program1.ProgramName}'",
                        conn);

                    _actualProgramAssociationDeleted = 0 == Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Delete the derived class (StudentProgramAssociation)
                try
                {
                    var deletestudentTitleIPartAAssociationById =
                        _container.Resolve<IDeleteEntityById<StudentTitleIPartAProgramAssociation>>();

                    deletestudentTitleIPartAAssociationById.DeleteByIdAsync(
                            studentTitleIPartA.Id, null, CancellationToken.None)
                        .WaitSafely();
                }
                catch (Exception ex)
                {
                    _actualDeleteStudentTitleIPartAAssociationException = ex;
                }

                // Verify the TitleI program association got removed
                using (var conn = GetDbConnectionForOds())
                {
                    conn.Open();

                    var cmd = DbHelper.GetCommand(
                        databaseEngine,
                        $"SELECT COUNT(*) FROM edfi.StudentProgramAssociationService WHERE ProgramName = '{_program2.ProgramName}'",
                        conn);

                    _actualTitleIProgramAssociationDeleted = 0 == Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            private IDbConnection GetDbConnectionForOds()
            {
                var databaseConnectionString = _container.Resolve<IConfiguration>().GetConnectionString("EdFi_Ods");
                return DbHelper.GetConnection(databaseConnectionString);
            }

            private ServiceDescriptor GetTestServiceDescriptor()
            {
                return new ServiceDescriptor
                {
                    CodeValue = string.Format("{0}_Test", DateTime.Now.Ticks),
                    Description = string.Format("{0}_Test", DateTime.Now.Ticks),
                    ShortDescription = string.Format("{0}_Test", DateTime.Now.Ticks),
                    Namespace = "uri://TEST/ServiceDescriptor"
                };
            }

            private Program GetProgram1()
            {
                return new Program
                {
                    EducationOrganizationId = _educationOrganization1,
                    ProgramTypeDescriptor = KnownDescriptors.ProgramType.Athletics,
                    ProgramName = string.Format("{0}_1", DateTime.Now.Ticks)
                };
            }

            private Program GetProgram2()
            {
                return new Program
                {
                    EducationOrganizationId = _educationOrganization1,
                    ProgramTypeDescriptor = KnownDescriptors.ProgramType.CollegePreparatory,
                    ProgramName = string.Format("{0}_2", DateTime.Now.Ticks)
                };
            }

            private Student GetStudent()
            {
                return new Student
                {
                    FirstName = "Bob",
                    LastSurname = "Jones",
                    BirthDate = DateTime.Today.AddYears(-25),
                    StudentUniqueId = _studentUniqueId
                };
            }

            private void RegisterDependencies()
            {
                var builder = new ContainerBuilder();

                //var apiSettings = new ApiSettings();
                //builder.RegisterInstance(apiSettings).As<ApiSettings>()
                //    .SingleInstance();

                var databaseEngine = DbHelper.GetDatabaseEngine();

                var config = DbHelper.GetDatabaseEngineSpecificConfiguration(databaseEngine);

                config.GetSection("ConnectionStrings").GetSection("EdFi_Ods").Value =
                    config.GetConnectionString("EdFi_Ods")
                        .Replace(
                            GlobalDatabaseSetupFixture.PopulatedDatabaseName,
                            GlobalDatabaseSetupFixture.TestPopulatedDatabaseName);

                builder.RegisterInstance(config).As<IConfiguration>();

                builder.RegisterModule(new RepositoryModule());
                builder.RegisterModule(new NHibernateConfigurationModule());
                builder.RegisterModule(new RepositoryFilterProvidersModule());
                builder.RegisterModule(new OdsConnectionStringProviderModule());
                builder.RegisterModule(new EdFiCommonModule());

                var apiSettings = new ApiSettings
                {
                    Engine = databaseEngine == DatabaseEngine.SqlServer ? ApiConfigurationConstants.SqlServer : ApiConfigurationConstants.PostgreSQL,
                    Mode = ApiConfigurationConstants.Sandbox
                };

                builder.RegisterInstance(apiSettings).As<ApiSettings>();

                builder.Register(c => apiSettings.GetDatabaseEngine()).As<DatabaseEngine>();

                builder.RegisterModule(new SandboxDatabaseReplacementTokenProviderModule(apiSettings));
                builder.RegisterModule(new DbConnnectionStringBuilderAdapterFactoryModule());
                builder.RegisterModule(new ContextProviderModule());
                builder.RegisterModule(new ContextStorageModule());
                builder.RegisterModule(new UsiModule());
                builder.RegisterModule(new CachingModule());
                builder.RegisterModule(new EdFiOdsInstanceIdentificationProviderModule());
                builder.RegisterModule(new PersonIdentifiersModule());
                builder.RegisterModule(new DomainModelModule());
                builder.RegisterModule(new SqlServerSpecificModule(apiSettings));
                builder.RegisterModule(new PostgresSpecificModule(apiSettings));
                builder.RegisterModule(new DescriptorLookupProviderModule());
                builder.RegisterModule(new EdFiDescriptorReflectionModule());

                builder.Register(c => A.Fake<IETagProvider>()).As<IETagProvider>();

                _container = builder.Build();
            }

            private class UpsertResults
            {
                public bool IsModified { get; set; }

                public bool IsCreated { get; set; }
            }

            protected void InitializeTestData()
            {
                CreateTestServiceDescriptor();

                _studentRepo.UpsertAsync(_student, false, CancellationToken.None).WaitSafely();

                _programRepo.UpsertAsync(_program1, false, CancellationToken.None).WaitSafely();

                _programRepo.UpsertAsync(_program2, false, CancellationToken.None).WaitSafely();
            }

            private void InitializeEducationOrganizationIdsForTest()
            {
                // Verify the service got removed
                using (var conn = GetDbConnectionForOds())
                {
                    conn.Open();
                    var cmd = DbHelper.GetCommand(
                        DbHelper.GetDatabaseEngine(),
                        "SELECT EducationOrganizationId FROM edfi.EducationOrganization", 
                        conn);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        try
                        {
                            reader.Read();
                            _educationOrganization1 = reader.GetInt32(0);
                            reader.Read();
                            _educationOrganization2 = reader.GetInt32(0);

                            reader.Dispose();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                "Unable to load two Education Organization Ids from the configured ODS database.",
                                ex);
                        }
                    }
                }
            }

            private void CreateTestServiceDescriptor()
            {
                _upsertService.UpsertAsync(_serviceDescriptor, false, CancellationToken.None)
                    .WaitSafely();
            }

            [Test]
            public void Should_create_concrete_base_program_association_with_first_upsert()
            {
                _actualStudentProgramAssociationUpsert1Results.IsCreated.ShouldBeTrue();
            }

            [Test]
            public void Should_create_derived_student_TitleIPartA_assocation_with_first_upsert()
            {
                _actualStudentTitleIPartAUpsert1Results.IsCreated.ShouldBeTrue();
            }

            [Test]
            public void Should_delete_concrete_base_program_association_without_an_exception()
            {
                _actualDeleteStudentProgramAssociationException.ShouldBeNull();
                _actualProgramAssociationDeleted.ShouldBeTrue();
            }

            [Test]
            public void Should_delete_derived_student_TitleIPartA_association_without_an_exception()
            {
                _actualDeleteStudentTitleIPartAAssociationException.ShouldBeNull();
                _actualTitleIProgramAssociationDeleted.ShouldBeTrue();
            }

            [Test]
            public void Should_remove_associated_program_service_from_TitleIPartA_association_with_second_upsert()
            {
                _actualServiceDeletedWithSecondDerivedClassUpsert.ShouldBeTrue();
            }

            [Test]
            public void Should_remove_associated_program_service_with_second_upsert()
            {
                _actualServiceDeletedWithSecondUpsert.ShouldBeTrue();
            }

            [Test]
            public void Should_update_concrete_base_program_association_with_second_upsert()
            {
                _actualStudentProgramAssociationUpsert2Results.IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_update_derived_student_TitleIPartA_association_with_second_upsert()
            {
                _actualStudentTitleIPartAUpsert2Results.IsModified.ShouldBeTrue();
            }
        }
    }
}
