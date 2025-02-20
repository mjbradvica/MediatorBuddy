// <copyright file="LocalRedirectResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Local direct tests.
    /// </summary>
    [TestClass]
    public class LocalRedirectResponsesTests
    {
        /// <summary>
        /// Ensures the local redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void LocalRedirectResponse_IsCorrect()
        {
            const string localUrl = "https://www.test.com";

            var result = ResponseOptions.LocalRedirectResponse<TestResponse>(_ => localUrl).Invoke(new TestResponse());

            var asResult = result as LocalRedirectResult;

            Assert.IsInstanceOfType<LocalRedirectResult>(result);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the local redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void LocalRedirectPermanentResponse_IsCorrect()
        {
            const string localUrl = "https://www.test.com";

            var result = ResponseOptions.LocalRedirectPermanentResponse<TestResponse>(_ => localUrl).Invoke(new TestResponse());

            var asResult = result as LocalRedirectResult;

            Assert.IsInstanceOfType<LocalRedirectResult>(result);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the local redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void LocalRedirectPermanentPreserveResponse_IsCorrect()
        {
            const string localUrl = "https://www.test.com";

            var result = ResponseOptions.LocalRedirectPermanentPreserveResponse<TestResponse>(_ => localUrl).Invoke(new TestResponse());

            var asResult = result as LocalRedirectResult;

            Assert.IsInstanceOfType<LocalRedirectResult>(result);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the local redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void LocalRedirectPreserveResponse_IsCorrect()
        {
            const string localUrl = "https://www.test.com";

            var result = ResponseOptions.LocalRedirectPreserveResponse<TestResponse>(_ => localUrl).Invoke(new TestResponse());

            var asResult = result as LocalRedirectResult;

            Assert.IsInstanceOfType<LocalRedirectResult>(result);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
        }
    }
}
