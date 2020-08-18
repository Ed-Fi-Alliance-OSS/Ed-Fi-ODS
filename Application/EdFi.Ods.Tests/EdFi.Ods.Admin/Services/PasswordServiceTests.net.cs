// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Services
{
    //TODO:  Fix tests here.

    //    public class PasswordServiceTests
    //    {
    //        [TestFixture]
    //        public class Happy_path : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 3, 10, 0, 1);
    //                var later = now.AddSeconds(1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //
    //                var user = new UserAuth {UserName = userName,};
    //                user.Set(new PasswordResetRequest {Secret = marker, ExpirationDate = later});
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                var service = new PasswordService(_userRepo, doNotUseRandom);
    //                _result = service.ValidateRequest(marker, userName);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_request_is_valid()
    //            {
    //                _result.Success.ShouldBeTrue();
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_user_is_resetting_password_after_the_expiration_date : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 3, 10, 0, 1);
    //                var beforeNow = now.AddSeconds(-1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //
    //                var user = new UserAuth {UserName = userName,};
    //                user.Set(new PasswordResetRequest {Secret = marker, ExpirationDate = beforeNow});
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                var service = new PasswordService(_userRepo, doNotUseRandom);
    //                _result = service.ValidateRequest(marker, userName);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_activation_link_has_expired()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.ResetStatus.ShouldBe(PasswordResetStatus.RequestExpired);
    //            }
    //
    //            [Test]
    //            public void Should_not_activate_the_user()
    //            {
    //                _userRepo.UpdatedUsers.Length.ShouldBe(0);
    //            }
    //
    //            [Test]
    //            public void Should_include_a_reasonable_error_message()
    //            {
    //                _result.Message.ShouldBe("It looks like your password request has expired.  Email verification must happen within 48 hours. Use the box below to try again.");
    //            }
    //        }
    //
    //        [TestFixture]
    //        public class When_user_is_resetting_password_and_the_reset_request_has_been_remove_from_the_user_in_the_database : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var userName = "MyUname";
    //                var marker = "MyLittleSecret";
    //
    //                var user = new UserAuth { UserName = userName, };
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                var service = new PasswordService(_userRepo, doNotUseRandom);
    //                _result = service.ValidateRequest(marker, userName);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_activation_link_has_expired()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.ResetStatus.ShouldBe(PasswordResetStatus.RequestExpired);
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
    //        public class When_user_is_resetting_password_and_the_username_is_bad : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var marker = "MyLittleSecret";
    //                var username = "MyUname";
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(null);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                var service = new PasswordService(_userRepo, doNotUseRandom);
    //                _result = service.ValidateRequest(marker, username);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_username_is_bad_so_that_we_can_go_through_password_reset_by_email_again()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.ResetStatus.ShouldBe(PasswordResetStatus.BadUsername);
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
    //        public class When_user_is_resetting_password_and_the_secret_is_bad : TestBase
    //        {
    //            private StubUserAuthRepository _userRepo;
    //            private PasswordResetResult _result;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 3, 10, 0, 1);
    //                var later = now.AddSeconds(1);
    //
    //                InitSystemClock(now);
    //
    //                var userName = "MyUname";
    //                var storedMarker = "MyLittleSecret";
    //                var suppliedMarker = "Some Other Secret";
    //
    //                var user = new UserAuth { UserName = userName, };
    //                user.Set(new PasswordResetRequest { Secret = storedMarker, ExpirationDate = later });
    //
    //                _userRepo = new StubUserAuthRepository().WithUser(user);
    //
    //                IRandomUtil doNotUseRandom = null;
    //
    //                var service = new PasswordService(_userRepo, doNotUseRandom);
    //                _result = service.ValidateRequest(suppliedMarker, userName);
    //            }
    //
    //            [Test]
    //            public void Should_indicate_that_the_activation_link_has_expired()
    //            {
    //                _result.Success.ShouldBeFalse();
    //                _result.ResetStatus.ShouldBe(PasswordResetStatus.RequestExpired);
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
    //        public class When_setting_the_password_reset_secret : TestBase
    //        {
    //            private string _result;
    //            private UserAuth _user;
    //            private DateTime _expectedEpiration;
    //
    //            [OneTimeSetUp]
    //            public void Setup()
    //            {
    //                var now = new DateTime(2010, 1, 1);
    //                _expectedEpiration = new DateTime(2010, 1, 3);
    //                InitSystemClock(now);
    //
    //                IUserAuthRepository doNotUseAuthRepo = null;
    //
    //                var randomUtil = S<IRandomUtil>();
    //                randomUtil.Stub(x => x.GenerateRandomString(32)).Return("Fuh");
    //
    //                _user = new UserAuth();
    //
    //                var service = new PasswordService(doNotUseAuthRepo, randomUtil);
    //                _result = service.SetPasswordResetSecret(_user);
    //            }
    //
    //            [Test]
    //            public void Should_set_the_32_chararacter_secret()
    //            {
    //                var storedRequest = _user.Get<PasswordResetRequest>();
    //                storedRequest.ShouldNotBeNull();
    //                storedRequest.Secret.ShouldBe("Fuh");
    //            }
    //
    //            [Test]
    //            public void Should_set_the_expiration_date_for_two_days_from_now()
    //            {
    //                var storedRequest = _user.Get<PasswordResetRequest>();
    //                storedRequest.ShouldNotBeNull();
    //                storedRequest.ExpirationDate.ShouldBe(_expectedEpiration);
    //            }
    //
    //            [Test]
    //            public void Should_provide_the_secret_so_it_can_be_used_in_an_email()
    //            {
    //                _result.ShouldBe("Fuh");
    //            }
    //        }
    //    }
}
