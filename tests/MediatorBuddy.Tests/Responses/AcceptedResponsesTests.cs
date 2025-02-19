// <copyright file="AcceptedResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Accepted responses.
    /// </summary>
    [TestClass]
    public class AcceptedResponsesTests
    {
        /// <summary>
        /// Ensures the AcceptedResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedEmpty_IsCorrect()
        {
            var result = ResponseOptions.AcceptedEmpty<TestResponse>().Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.IsNull((result as AcceptedResult)?.Location);
            Assert.IsNull((result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocationFunc_IsCorrect()
        {
            var response = new TestResponse();
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => uri).Invoke(response);

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedUriLocationObjectFunc_IsCorrect()
        {
            object response = string.Empty;
            var uri = new Uri("https://www.mylocation.com");

            var result = ResponseOptions.AcceptedResponse<TestResponse>(_ => (uri, response)).Invoke(new TestResponse());

            Assert.IsInstanceOfType<AcceptedResult>(result);
            Assert.AreEqual(uri.ToString(), (result as AcceptedResult)?.Location);
            Assert.AreEqual(response, (result as AcceptedResult)?.Value);
        }
    }
}
