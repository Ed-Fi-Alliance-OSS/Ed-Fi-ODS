// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Services
{
    //TODO:  Fix tests here.
    //    public class UserAccountManagerTests
    //    {
    //        [TestFixture]
    //        public class When_user_does_not_exist_in_database : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private StubUserAuthRepository _userRepo;
    //            private IEmailService _emailService;
    //            private DateTime _currentTime;
    //            private DateTime _expectedExpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                _currentTime = new DateTime(2012, 3, 4, 11, 0, 0);
    //                _expectedExpiration = new DateTime(2012, 3, 6, 11, 0, 0);
    //
    //                InitSystemClock(_currentTime);
    //                var email = "foo@example.com";
    //                _emailService = S<IEmailService>();
    //
    //                _userRepo = new StubUserAuthRepository()
    //                    .WithUser(null)
    //                    ;
    //
    //                IRandomUtil randomUtil = S<IRandomUtil>();
    //                randomUtil.Stub(x => x.GenerateRandomString(15)).Return("UserName123");
    //
    //                _passwordService = S<IPasswordService>();
    //                _passwordService.Stub(x => x.SetPasswordResetSecret(null))
    //                                .IgnoreArguments()
    //                                .Return("shh! secret")
    //                                .Callback<UserAuth>(ua =>
    //                                                        {
    //                                                            ua.Set(new PasswordResetRequest());
    //                                                            return true;
    //                                                        });
    //
    //                var service = new UserAccountManager(_userRepo, randomUtil, _emailService, _passwordService);
    //                _result = service.Create(new CreateLoginModel {Email = email, Name = "My Test Name"});
    //            }
    //
    //            [Test]
    //            public void Should_create_new_user()
    //            {
    //                _userRepo.CreatedUsers.Length.ShouldBe(1);
    //                _userRepo.CreatedUsers[0].Auth.Email.ShouldBe("foo@example.com");
    //                _userRepo.CreatedUsers[0].Auth.DisplayName.ShouldBe("My Test Name");
    //                _userRepo.CreatedUsers[0].Password.ShouldNotBeEmpty();
    //            }
    //
    //            [Test]
    //            public void Should_indicate_new_user_was_created()
    //            {
    //                _result.Success.ShouldBeTrue();
    //                _result.UserStatus.ShouldBe(UserStatus.Created);
    //            }
    //
    //            [Test]
    //            public void Should_send_confirmation_email_with_secret()
    //            {
    //                _emailService.AssertWasCalled(x => x.SendConfirmationEmail("foo@example.com", "shh! secret", "UserName123"));
    //            }
    //
    //            [Test]
    //            public void Should_persist_secret_in_database()
    //            {
    //                _userRepo.CreatedUsers[0].Auth.Get<PasswordResetRequest>().ShouldNotBeNull();
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_user_exists_in_database_and_is_not_active : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private StubUserAuthRepository _userRepo;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var email = "foo@example.com";
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(new UserAuth());
    //
    //                IPasswordService doNotUsePasswordService = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var service = new UserAccountManager(_userRepo, S<IRandomUtil>(), doNotUseEmail, doNotUsePasswordService);
    //                _result = service.Create(new CreateLoginModel {Email = email, Name = "My Test Name"});
    //            }
    //
    //            [Test]
    //            public void Should_not_create_new_user()
    //            {
    //                _userRepo.CreatedUsers.Length.ShouldBe(0);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_existing_user_needs_email_activation()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.NeedsEmailConfirmation);
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_user_exists_in_database_and_is_active : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private StubUserAuthRepository _userRepo;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var email = "foo@example.com";
    //
    //                UserAuth user = new UserAuth();
    //                user.Permissions.Add(Permissions.Active);
    //                //Sanity Check
    //                user.IsActive().ShouldBeTrue();
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IPasswordService doNotUsePasswordService = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var service = new UserAccountManager(_userRepo, S<IRandomUtil>(), doNotUseEmail, doNotUsePasswordService);
    //                _result = service.Create(new CreateLoginModel {Email = email, Name = "My Test Name"});
    //            }
    //
    //            [Test]
    //            public void Should_not_create_new_user()
    //            {
    //                _userRepo.CreatedUsers.Length.ShouldBe(0);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_existing_user_already_exists()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.AlreadyExists);
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_input_is_missing_name : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private StubUserAuthRepository _userRepo;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var email = "foo@example.com";
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(null);
    //
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(_userRepo, S<IRandomUtil>(), doNotUseEmail, doNotUsePasswordService);
    //                _result = service.Create(new CreateLoginModel {Email = email, Name = "   "});
    //            }
    //
    //            [Test]
    //            public void Should_not_create_new_user()
    //            {
    //                _userRepo.CreatedUsers.Length.ShouldBe(0);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_input_is_missing_name()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.Failed);
    //                _result.FailingFields.ShouldContain("name");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_input_is_missing_email : TestBase
    //        {
    //            private CreateLoginResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                IUserAuthRepository doNotUseUserRepo = null;
    //
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, S<IRandomUtil>(), doNotUseEmail, doNotUsePasswordService);
    //                _result = service.Create(new CreateLoginModel {Email = "  ", Name = "Foo"});
    //            }
    //
    //            [Test]
    //            public void Should_not_create_new_user()
    //            {
    //                //We cannot even reach the user repo
    //            }
    //
    //            [Test]
    //            public void Should_indicate_input_is_missing_email()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.Failed);
    //                _result.FailingFields.ShouldContain("email");
    //            }
    //
    //            [Test]
    //            public void Should_not_make_any_requests_of_the_user_repository()
    //            {
    //                //If the setup code hasn't exploded, this test passes
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_input_has_invalid_email_address : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private StubUserAuthRepository _userRepo;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                _userRepo = new StubUserAuthRepository().WithUser(null);
    //
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService passwordService = null;
    //
    //                var service = new UserAccountManager(_userRepo, S<IRandomUtil>(), doNotUseEmail, passwordService);
    //                _result = service.Create(new CreateLoginModel {Email = "nodomain", Name = "Foo"});
    //            }
    //
    //            [Test]
    //            public void Should_not_create_new_user()
    //            {
    //                _userRepo.CreatedUsers.Length.ShouldBe(0);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_input_is_missing_name()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.Failed);
    //                _result.FailingFields.ShouldContain("email");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_creating_the_user_causes_an_exception_in_the_user_repository : TestBase
    //        {
    //            private CreateLoginResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                InitSystemClock(DateTime.Now);
    //
    //                var userRepo = S<IUserAuthRepository>();
    //                userRepo.Stub(x => x.CreateUserAuth(null, null)).IgnoreArguments().Throw(new Exception("FooDisco"));
    //
    //                var randomUtil = S<IRandomUtil>();
    //                randomUtil.Stub(x => x.GenerateRandomString(15)).Return("foo");
    //
    //                var passwordResetService = S<IPasswordService>();
    //
    //                var service = new UserAccountManager(userRepo, randomUtil, null, passwordResetService);
    //                _result = service.Create(new CreateLoginModel {Email = "valid@example.com", Name = "Foo"});
    //            }
    //
    //            [Test]
    //            public void Should_pass_exception_message_in_result()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.UserStatus.ShouldBe(UserStatus.Failed);
    //                _result.Message.ShouldContain("FooDisco");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_resetting_password_and_password_is_missing : TestBase
    //        {
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = "MyLittleSecret", UName = "MyUname", Password = string.Empty, ConfirmPassword = "pass"});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_password_is_missing()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("Password is required.");
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_resetting_password_and_confirmation_password_is_missing : TestBase
    //        {
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService passwordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = "MyLittleSecret", UName = "MyUname", Password = "pass", ConfirmPassword = string.Empty});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_confirmation_password_is_missing()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("ConfirmPassword is required.");
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_resetting_password_and_confirmation_password_is_mismatched : TestBase
    //        {
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = "MyLittleSecret", UName = "MyUname", Password = "pass", ConfirmPassword = "something else"});
    //            }
    //
    //            [Test]
    //            public void Should_provide_a_reasonable_failure_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("Password and Confirm Password must match.");
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_password_reset_request_is_not_expired_and_user_is_active : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 2);
    //                var laterThanNow = now.AddSeconds(1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //                var password = "pass";
    //
    //                var user = new UserAuth {UserName = userName,};
    //                user.Set(new PasswordResetRequest {Secret = marker, ExpirationDate = laterThanNow});
    //                user.Permissions.Add(Permissions.Active);
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.ValidateRequest(marker, userName)).Return(PasswordResetResult.Successful);
    //                passwordService.Stub(x => x.PasswordIsStrong(password)).Return(true);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = marker, UName = userName, Password = password, ConfirmPassword = password});
    //            }
    //
    //            [Test]
    //            public void Should_not_indicate_failure()
    //            {
    //                _result.Success.ShouldBeTrue();
    //            }
    //
    //            [Test]
    //            public void Should_not_duplicate_the_can_access_permission()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(1);
    //                updateOperations[0].New.Permissions.Count.ShouldBe(1);
    //            }
    //
    //            [Test]
    //            public void Should_set_password()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(1);
    //                updateOperations[0].Password.ShouldBe("pass");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_password_is_not_strong : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 2);
    //                var laterThanNow = now.AddSeconds(1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //                var password = "pass";
    //
    //                var user = new UserAuth {UserName = userName,};
    //                user.Set(new PasswordResetRequest {Secret = marker, ExpirationDate = laterThanNow});
    //                user.Permissions.Add(Permissions.Active);
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.ValidateRequest(marker, userName)).Return(PasswordResetResult.Successful);
    //                passwordService.Stub(x => x.PasswordIsStrong(password)).Return(false);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = marker, UName = userName, Password = password, ConfirmPassword = password});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_failure()
    //            {
    //                _result.Success.ShouldBeFalse();
    //            }
    //
    //            [Test]
    //            public void Should_indicate_password_is_invalid()
    //            {
    //                _result.FailingFields.ShouldContain("password");
    //                _result.FailingFields.ShouldContain("confirmpassword");
    //                _result.Message.ShouldBe("The password you entered is invalid.");
    //                _result.ResetStatus.ShouldBe(PasswordResetStatus.BadPassword);
    //            }
    //
    //            [Test]
    //            public void Should_not_set_password()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(0);
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_user_is_resetting_password_and_the_reset_request_is_no_longer_valid : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //            private PasswordResetResult _requestValidationResult;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //                var password = "pass";
    //
    //                _requestValidationResult = new PasswordResetResult { Success = false };
    //
    //                var user = new UserAuth {UserName = userName,};
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.ValidateRequest(marker, userName)).Return(_requestValidationResult);
    //                passwordService.Stub(x => x.PasswordIsStrong(password)).Return(true);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = marker, UName = userName, Password = password, ConfirmPassword = password});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_activation_link_has_expired()
    //            {
    //                _result.ShouldBeSameAs(_requestValidationResult);
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                _userRepo.UpdatedUsers.Length.ShouldBe(0);
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_current_password_is_missing : TestBase
    //        {
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = string.Empty, NewPassword = "pass", ConfirmPassword = "pass"});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_password_is_missing()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("CurrentPassword is required.");
    //            }
    //
    //            [Test]
    //            public void Should_not_do_anything_with_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_new_password_is_missing : TestBase
    //        {
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = string.Empty, ConfirmPassword = "pass"});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_password_is_missing()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("NewPassword is required.");
    //            }
    //
    //            [Test]
    //            public void Should_not_do_anything_with_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_confirmation_password_is_missing : TestBase
    //        {
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = "pass", ConfirmPassword = string.Empty});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_confirmation_password_is_missing()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("ConfirmPassword is required.");
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_confirmation_password_is_mismatched : TestBase
    //        {
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var newPassword = "pass";
    //
    //                var user = new UserAuth
    //                               {
    //                                   UserName = "MyUname",
    //                               };
    //
    //                IUserAuthRepository doNotUseUserRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(newPassword)).Return(true);
    //
    //                var service = new UserAccountManager(doNotUseUserRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = newPassword, ConfirmPassword = "something different"});
    //            }
    //
    //            [Test]
    //            public void Should_provide_a_reasonable_failure_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("New Password and Confirm Password must match.");
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                //If the test passes, this is true since the auth repo is null
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_current_password_is_wrong : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth {UserName = "MyUname"};
    //                user.Permissions.Add(Permissions.Active);
    //                var newPassword = "pass";
    //
    //                _userRepo = new StubUserAuthRepository()
    //                    .WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(newPassword)).Return(true);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = newPassword, ConfirmPassword = newPassword, UserName = user.UserName});
    //            }
    //
    //            [Test]
    //            public void Should_return_a_failure_result_with_a_reasonable_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.FailingFields.ShouldContain("currentpassword");
    //                _result.Message.ShouldBe("The Current Password supplied is incorrect");
    //            }
    //
    //            [Test]
    //            public void Should_not_modify_the_user()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(0);
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_on_the_happy_path : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var newPassword = "pass";
    //
    //                var user = new UserAuth { UserName = "MyUname" };
    //                user.Permissions.Add(Permissions.Active);
    //                user.Set(new PasswordResetRequest {Secret = "foo secret"});
    //
    //                _userRepo = new StubUserAuthRepository()
    //                    .WithUser(user)
    //                    .AllowAuthenticationWithPassword("foo");
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(newPassword)).Return(true);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = newPassword, ConfirmPassword = newPassword, UserName = user.UserName});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_success()
    //            {
    //                _result.Success.ShouldBeTrue();
    //            }
    //
    //            [Test]
    //            public void Should_remove_the_reset_secret_from_the_user()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(1);
    //                updateOperations[0].New.Get<PasswordResetRequest>().ShouldBeNull();
    //            }
    //
    //            [Test]
    //            public void Should_not_duplicate_the_can_access_permission()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(1);
    //                updateOperations[0].New.Permissions.Count.ShouldBe(1);
    //            }
    //
    //            [Test]
    //            public void Should_set_password()
    //            {
    //                var updateOperations = _userRepo.UpdatedUsers;
    //                updateOperations.Length.ShouldBe(1);
    //                updateOperations[0].Password.ShouldBe("pass");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_new_password_is_not_valid : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var user = new UserAuth {UserName = "MyUname"};
    //                user.Permissions.Add(Permissions.Active);
    //                user.Set(new PasswordResetRequest {Secret = "foo secret"});
    //
    //                _userRepo = new StubUserAuthRepository()
    //                    .WithUser(user)
    //                    .AllowAuthenticationWithPassword("foo");
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(null))
    //                               .IgnoreArguments()
    //                               .Return(false);
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = "pass", ConfirmPassword = "pass", UserName = user.UserName});
    //            }
    //
    //            [Test]
    //            public void Should_indicate_failure()
    //            {
    //                _result.Success.ShouldBeFalse();
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_and_email_is_missing : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                IUserAuthRepository doNotUseAuthRepo = null;
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(doNotUseAuthRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ForgotPassword(new ForgotPasswordModel {Email = null});
    //            }
    //
    //            [Test]
    //            public void Should_not_succeed()
    //            {
    //                _result.Success.ShouldBeFalse();
    //            }
    //
    //            [Test]
    //            public void Should_not_send_any_email()
    //            {
    //                //Email service is null, so it could not have been used.
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_email_is_missing()
    //            {
    //                _result.Message.ShouldBe("Email is required.");
    //                _result.FailingFields.Length.ShouldBe(1);
    //                _result.FailingFields.ShouldContain("email");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_and_email_is_not_in_database : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var model = new ForgotPasswordModel {Email = "foo"};
    //
    //                var authRepo = S<IUserAuthRepository>();
    //                authRepo.Stub(x => x.GetUserAuthByUserName(model.Email)).Return(null);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                IPasswordService doNotUsePasswordService = null;
    //
    //                var service = new UserAccountManager(authRepo, doNotUseRandom, doNotUseEmail, doNotUsePasswordService);
    //                _result = service.ForgotPassword(model);
    //            }
    //
    //            [Test]
    //            public void Should_not_succeed()
    //            {
    //                _result.Success.ShouldBeFalse();
    //            }
    //
    //            [Test]
    //            public void Should_not_send_any_email()
    //            {
    //                //Email service is null, so it could not have been used.
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_email_is_not_in_the_database()
    //            {
    //                _result.Message.ShouldBe("There are no accounts with the email address 'foo'");
    //                _result.FailingFields.Length.ShouldBe(1);
    //                _result.FailingFields.ShouldContain("email");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_happy_path : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //            private IEmailService _emailService;
    //            private StubUserAuthRepository _authRepo;
    //            private DateTime _expectedEpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2012, 3, 4);
    //                _expectedEpiration = new DateTime(2012, 3, 6);
    //                InitSystemClock(now);
    //
    //                var model = new ForgotPasswordModel {Email = "foo@example.com"};
    //                var user = new UserAuth {Email = model.Email, UserName = "UserName123"};
    //
    //                _authRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                _emailService = S<IEmailService>();
    //
    //                _passwordService = S<IPasswordService>();
    //                _passwordService.Stub(x => x.SetPasswordResetSecret(user))
    //                                .Return("shh! secret")
    //                                .Callback<UserAuth>(ua =>
    //                                                        {
    //                                                            ua.Set(new PasswordResetRequest());
    //                                                            return true;
    //                                                        });
    //
    //                var service = new UserAccountManager(_authRepo, doNotUseRandom, _emailService, _passwordService);
    //                _result = service.ForgotPassword(model);
    //            }
    //
    //            [Test]
    //            public void Should_send_email_with_reset_secret()
    //            {
    //                _emailService.AssertWasCalled(x => x.SendForgotPasswordEmail("foo@example.com", "shh! secret", "UserName123"));
    //            }
    //
    //            [Test]
    //            public void Should_persist_reset_secret()
    //            {
    //                var savedUsers = _authRepo.SavedUsers;
    //                savedUsers.Length.ShouldBe(1);
    //
    //                var resetRequest = savedUsers[0].Get<PasswordResetRequest>();
    //                resetRequest.ShouldNotBeNull();
    //            }
    //
    //            [Test]
    //            public void Should_indicate_success()
    //            {
    //                _result.Success.ShouldBeTrue();
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_and_the_email_service_fails : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //            private IEmailService _emailService;
    //            private StubUserAuthRepository _authRepo;
    //            private DateTime _expectedEpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2012, 3, 4);
    //                _expectedEpiration = new DateTime(2012, 3, 6);
    //                InitSystemClock(now);
    //
    //                var model = new ForgotPasswordModel {Email = "foo@example.com"};
    //                var user = new UserAuth {Email = model.Email, UserName = "UserName123"};
    //
    //                _authRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                _emailService = S<IEmailService>();
    //                _emailService.Stub(x => x.SendForgotPasswordEmail(null, null, null))
    //                             .IgnoreArguments()
    //                             .Throw(new Exception("Something bad happened"));
    //
    //                _passwordService = S<IPasswordService>();
    //                _passwordService.Stub(x => x.SetPasswordResetSecret(user))
    //                                .Return("shh! secret")
    //                                .Callback<UserAuth>(ua =>
    //                                                        {
    //                                                            ua.Set(new PasswordResetRequest());
    //                                                            return true;
    //                                                        });
    //
    //                var service = new UserAccountManager(_authRepo, doNotUseRandom, _emailService, _passwordService);
    //                _result = service.ForgotPassword(model);
    //            }
    //
    //            [Test]
    //            public void Should_include_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("It looks like our email system is down.  Please try again in a few minutes.");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_and_the_database_fails_when_setting_the_password_secret : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //            private DateTime _expectedEpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2012, 3, 4);
    //                _expectedEpiration = new DateTime(2012, 3, 6);
    //                InitSystemClock(now);
    //
    //                var model = new ForgotPasswordModel {Email = "foo@example.com"};
    //                var user = new UserAuth {Email = model.Email, UserName = "UserName123"};
    //
    //                var _authRepo = S<IUserAuthRepository>();
    //                _authRepo.Stub(x => x.GetUserAuthByUserName(model.Email)).Return(user);
    //                _authRepo.Stub(x => x.SaveUserAuth(user))
    //                         .IgnoreArguments()
    //                         .Throw(new Exception("Something bad happened."));
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                IEmailService doNotUseEmail = null;
    //
    //                _passwordService = S<IPasswordService>();
    //                _passwordService.Stub(x => x.SetPasswordResetSecret(user))
    //                                .IgnoreArguments()
    //                                .Return("shhhhh");
    //
    //                var service = new UserAccountManager(_authRepo, doNotUseRandom, doNotUseEmail, _passwordService);
    //                _result = service.ForgotPassword(model);
    //            }
    //
    //            [Test]
    //            public void Should_include_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("The database is unreachable.  Please try again in a few minutes.");
    //            }
    //
    //            [Test]
    //            public void Should_not_send_email_with_reset_secret()
    //            {
    //                //Email service is null, so this passes if that service is not used.
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_handling_forgot_password_and_the_database_fails_when_looking_up_user : TestBase
    //        {
    //            private ForgotPasswordResetResult _result;
    //            private DateTime _expectedEpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2012, 3, 4);
    //                _expectedEpiration = new DateTime(2012, 3, 6);
    //                InitSystemClock(now);
    //
    //                var model = new ForgotPasswordModel {Email = "foo@example.com"};
    //                var user = new UserAuth {Email = model.Email, UserName = "UserName123"};
    //
    //                var _authRepo = S<IUserAuthRepository>();
    //                _authRepo.Stub(x => x.GetUserAuthByUserName(null))
    //                         .IgnoreArguments()
    //                         .Throw(new Exception("Something bad happened."));
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                IEmailService doNotUseEmail = null;
    //
    //                _passwordService = S<IPasswordService>();
    //                _passwordService.Stub(x => x.SetPasswordResetSecret(user))
    //                                .IgnoreArguments()
    //                                .Return("shhhhh");
    //
    //                var service = new UserAccountManager(_authRepo, doNotUseRandom, doNotUseEmail, _passwordService);
    //                _result = service.ForgotPassword(model);
    //            }
    //
    //            [Test]
    //            public void Should_include_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("The database is unreachable.  Please try again in a few minutes.");
    //            }
    //
    //            [Test]
    //            public void Should_not_send_email_with_reset_secret()
    //            {
    //                //Email service is null, so this passes if that service is not used.
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_changing_password_and_database_is_offline_when_looking_up_user : TestBase
    //        {
    //            private ChangePasswordResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var newPassword = "pass";
    //
    //                var user = new UserAuth { UserName = "MyUname" };
    //                user.Permissions.Add(Permissions.Active);
    //                user.Set(new PasswordResetRequest {Secret = "foo secret"});
    //
    //                var userRepo = S<IUserAuthRepository>();
    //                UserAuth userAuth;
    //                userRepo.Stub(x => x.TryAuthenticate(null, null, out userAuth))
    //                        .IgnoreArguments()
    //                        .Throw(new Exception("Something Bad Happened"));
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(newPassword)).Return(true);
    //
    //                var service = new UserAccountManager(userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ChangePassword(new ChangePasswordModel {CurrentPassword = "foo", NewPassword = newPassword, ConfirmPassword = newPassword, UserName = user.UserName});
    //            }
    //
    //            [Test]
    //            public void Should_provide_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("The database is unreachable.  Please try again in a few minutes.");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_creating_a_user_and_database_is_offline : TestBase
    //        {
    //            private CreateLoginResult _result;
    //            private IEmailService _emailService;
    //            private DateTime _currentTime;
    //            private DateTime _expectedExpiration;
    //            private IPasswordService _passwordService;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                _currentTime = new DateTime(2012, 3, 4, 11, 0, 0);
    //                _expectedExpiration = new DateTime(2012, 3, 6, 11, 0, 0);
    //
    //                InitSystemClock(_currentTime);
    //                var email = "foo@example.com";
    //                _emailService = S<IEmailService>();
    //
    //                var userRepo = S<IUserAuthRepository>();
    //                userRepo.Stub(x => x.GetUserAuthByUserName(null))
    //                        .IgnoreArguments()
    //                        .Throw(new Exception("Something bad happened"));
    //
    //                IRandomUtil randomUtil = S<IRandomUtil>();
    //                randomUtil.Stub(x => x.GenerateRandomString(15)).Return("UserName123");
    //
    //                _passwordService = S<IPasswordService>();
    //
    //                var service = new UserAccountManager(userRepo, randomUtil, _emailService, _passwordService);
    //                _result = service.Create(new CreateLoginModel {Email = email, Name = "My Test Name"});
    //            }
    //
    //            [Test]
    //            public void Should_provide_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("The database is unreachable.  Please try again in a few minutes.");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_resetting_password_and_the_database_is_offline : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 2);
    //                var laterThanNow = now.AddSeconds(1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //                var password = "pass";
    //
    //                var user = new UserAuth {UserName = userName,};
    //                user.Set(new PasswordResetRequest {Secret = marker, ExpirationDate = laterThanNow});
    //                user.Permissions.Add(Permissions.Active);
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //                IEmailService doNotUseEmail = null;
    //
    //                var passwordService = S<IPasswordService>();
    //                passwordService.Stub(x => x.PasswordIsStrong(password)).Return(true);
    //                passwordService.Stub(x => x.ValidateRequest(null, null))
    //                               .IgnoreArguments()
    //                               .Throw(new Exception("Something bad happened"));
    //
    //                var service = new UserAccountManager(_userRepo, doNotUseRandom, doNotUseEmail, passwordService);
    //                _result = service.ResetPassword(new PasswordResetModel {Marker = marker, UName = userName, Password = password, ConfirmPassword = password});
    //            }
    //
    //            [Test]
    //            public void Should_provide_a_reasonable_error_message()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.Message.ShouldBe("The database is unreachable.  Please try again in a few minutes.");
    //            }
    //        }
    //    }
}
