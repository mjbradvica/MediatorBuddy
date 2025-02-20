// <copyright file="RedirectResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Redirect responses tests.
    /// </summary>
    [TestClass]
    public class RedirectResponsesTests
    {
        /// <summary>
        /// Ensures the redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectResponse_IsCorrect()
        {
            const string url = "https://www.test.com";

            var result = ResponseOptions.RedirectResponse<TestResponse>(_ => url).Invoke(new TestResponse());

            var asResult = result as RedirectResult;

            Assert.IsInstanceOfType<RedirectResult>(result);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectPermanentResponse_IsCorrect()
        {
            const string url = "https://www.test.com";

            var result = ResponseOptions.RedirectPermanentResponse<TestResponse>(_ => url).Invoke(new TestResponse());

            var asResult = result as RedirectResult;

            Assert.IsInstanceOfType<RedirectResult>(result);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectPermanentPreserveResponse_IsCorrect()
        {
            const string url = "https://www.test.com";

            var result = ResponseOptions.RedirectPermanentPreserveResponse<TestResponse>(_ => url).Invoke(new TestResponse());

            var asResult = result as RedirectResult;

            Assert.IsInstanceOfType<RedirectResult>(result);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
        }

        /// <summary>
        /// Ensures the redirect has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectPreserveResponse_IsCorrect()
        {
            const string url = "https://www.test.com";

            var result = ResponseOptions.RedirectPreserveResponse<TestResponse>(_ => url).Invoke(new TestResponse());

            var asResult = result as RedirectResult;

            Assert.IsInstanceOfType<RedirectResult>(result);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
        }
    }
}
