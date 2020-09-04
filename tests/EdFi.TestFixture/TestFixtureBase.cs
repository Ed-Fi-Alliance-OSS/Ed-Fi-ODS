// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.TestFixture
{
    [TestFixture]
    public abstract class TestFixtureBase
    {
        private Exception _actualException;
        private bool _actualExceptionInspected;

        protected Exception ActualException
        {
            get
            {
                _actualExceptionInspected = true;
                return _actualException;
            }
            set
            {
                _actualExceptionInspected = false;
                _actualException = value;
            }
        }

        [OneTimeSetUp]
        public virtual void RunOnceBeforeAny()
        {
            try
            {
                //Arrange
                Arrange();
            }
            catch (Exception ex)
            {
                var handled = HandleArrangeException(ex);

                if (!handled)
                {
                    throw;
                }
            }

            //Act
            // Execute the behavior
            try
            {
                Act();
            }
            catch (Exception ex)
            {
                ActualException = ex;
            }
        }

        [OneTimeTearDown]
        public virtual void RunOnceAfterAll()
        {
            // Make sure exception was inspected.
            if (_actualException != null && !_actualExceptionInspected)
            {
                Assert.Fail(
                    $"The exception of type '{_actualException.GetType().Name}' was not inspected by the test:\r\n {_actualException}.");
            }
        }

        /// <summary>
        /// Setup tests context
        /// </summary>
        protected virtual void Arrange() { }

        /// <summary>
        /// Executes the code to be tested.
        /// </summary>
        protected virtual void Act() { }

        protected T Stub<T>()
            where T : class
        {
            return A.Fake<T>();
        }

        protected virtual bool HandleArrangeException(Exception ex)
        {
            return false;
        }
    }
}
