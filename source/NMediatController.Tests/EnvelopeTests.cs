﻿// <copyright file="EnvelopeTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NMediatController.Tests
{
    /// <summary>
    /// Tests the <see cref="Envelope{T}"/> class capabilities.
    /// </summary>
    [TestClass]
    public class EnvelopeTests
    {
        /// <summary>
        /// Ensures the default constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void DefaultConstructor_HasCorrectProperties()
        {
            var response = Envelope<TestResponse>.Success(new TestResponse());

            Assert.AreEqual(ApplicationStatus.Success, response.StatusCode);
        }

        /// <summary>
        /// Ensures the status code constructor has the correct properties.
        /// </summary>
        [TestMethod]
        public void StatusCodeConstructor_HasCorrectProperties()
        {
            const int statusCode = 201;

            var response = Envelope<TestResponse>.Failure(statusCode);

            Assert.AreEqual(statusCode, response.StatusCode);
        }
    }
}
