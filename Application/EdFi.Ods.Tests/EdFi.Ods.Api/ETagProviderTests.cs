// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.ETag;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api
{
    [TestFixture]
    public class ETagProviderTests
    {
        [SetUp]
        public void Setup()
        {
            _eTagProvider = new ETagProvider();

            var dateTime = DateTime.Now;
            _localDateTime = dateTime.ToLocalTime();
            _utcDateTime = dateTime.ToUniversalTime();
            _unspecifiedDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
        }

        private class DateVersionedEntity : IDateVersionedEntity
        {
            public DateVersionedEntity()
            {
                LastModifiedDate = DateTime.Now;
            }

            public DateTime LastModifiedDate { get; set; }
        }

        private class HashETag : IHasETag
        {
            public HashETag()
            {
                ETag = "123123123";
            }

            public string ETag { get; set; }
        }

        private IETagProvider _eTagProvider;

        private static DateTime _localDateTime;
        private static DateTime _utcDateTime;
        private static DateTime _unspecifiedDateTime;

        [Test]
        public void When_entity_IDateVersionedEntity_value_default_Should_return_null()
        {
            var dateversionedEntity = new DateVersionedEntity
                                      {
                                          LastModifiedDate = default(DateTime)
                                      };

            var result = _eTagProvider.GetETag(dateversionedEntity);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void When_entity_is_Date()
        {
            var expectedEtagValue1 = _eTagProvider.GetETag(_localDateTime);
            var expectedEtagValue2 = _eTagProvider.GetETag(_utcDateTime);
            var expectedEtagValue3 = _eTagProvider.GetETag(_unspecifiedDateTime);
            Assert.AreEqual(expectedEtagValue1, expectedEtagValue2, expectedEtagValue3);
        }

        [Test]
        public void When_entity_is_Guid()
        {
            var guid = Guid.NewGuid();
            var expectedEtagValue = guid.ToString("N");
            var result = _eTagProvider.GetETag(guid);
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_entity_Is_IDateVersionedEntity()
        {
            var localTimeDateVersionedEntity = new DateVersionedEntity
                                               {
                                                   LastModifiedDate = _localDateTime
                                               };

            var utcTimedateversionedEntity = new DateVersionedEntity
                                             {
                                                 LastModifiedDate = _utcDateTime
                                             };

            var unspecifiedTimeDateVersionedEntity = new DateVersionedEntity
                                                     {
                                                         LastModifiedDate = _unspecifiedDateTime
                                                     };

            var expectedEtagValue1 = _eTagProvider.GetETag(localTimeDateVersionedEntity);
            var expectedEtagValue2 = _eTagProvider.GetETag(utcTimedateversionedEntity);
            var expectedEtagValue3 = _eTagProvider.GetETag(unspecifiedTimeDateVersionedEntity);
            Assert.AreEqual(expectedEtagValue1, expectedEtagValue2, expectedEtagValue3);
        }

        [Test]
        public void When_entity_is_IHasETag()
        {
            var hashETag = new HashETag();
            var expectedEtagValue = hashETag.ETag;
            var result = _eTagProvider.GetETag(hashETag);
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_entity_is_string()
        {
            const string testString = "213123123";
            const string expectedEtagValue = testString;
            var result = _eTagProvider.GetETag(testString);
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_GetDateTime_input_invalid__throw_()
        {
            const string etag = "-0080000000000058000"; //invalid DateTime test
            Assert.Throws<BadRequestException>(() => _eTagProvider.GetDateTime(etag));
        }

        [Test]
        public void When_GetDateTime_input_null_return_defaultDate()
        {
            var expectedEtagValue = default(DateTime);
            var result = _eTagProvider.GetDateTime(null);
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_GetDateTime_input_string__return_DateTime()
        {
            var expectedEtagValue = DateTime.Now;

            var etag = expectedEtagValue.ToBinary()
                                        .ToString();

            var result = _eTagProvider.GetDateTime(etag);
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_GetDateTime_input_whiteSpace_return_defaultDate()
        {
            var expectedEtagValue = default(DateTime);
            var result = _eTagProvider.GetDateTime(" ");
            Assert.AreEqual(expectedEtagValue, result);
        }

        [Test]
        public void When_providing_null_should_return_null()
        {
            var result = _eTagProvider.GetETag(null);
            Assert.AreEqual(null, result);
        }
    }
}
