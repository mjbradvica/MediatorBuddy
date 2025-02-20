// <copyright file="RedirectToPageResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for redirect to page responses.
    /// </summary>
    [TestClass]
    public class RedirectToPageResponsesTests
    {
        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPageResponse_NonFragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToPageResponse<TestResponse>(_ =>
                    (pageName,
                    pageHandler,
                    routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPageResponse_Fragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToPageResponse<TestResponse>(_ =>
                        (pageName,
                        pageHandler,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPagePermanentResponse_NonFragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToPagePermanentResponse<TestResponse>(_ =>
                        (pageName,
                        pageHandler,
                        routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPagePermanentResponse_Fragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToPagePermanentResponse<TestResponse>(_ =>
                        (pageName,
                        pageHandler,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPagePermanentPreserveResponse_NonFragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToPagePermanentPreserveResponse<TestResponse>(_ =>
                        (pageName,
                        pageHandler,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToPageResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToPagePreserveResponse_Fragment_IsCorrect()
        {
            const string pageName = "PageName";
            const string pageHandler = "PageHandler";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToPagePreserveResponse<TestResponse>(_ =>
                        (pageName,
                        pageHandler,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToPageResult;

            Assert.IsInstanceOfType<RedirectToPageResult>(result);
            Assert.AreEqual(pageName, asResult?.PageName);
            Assert.AreEqual(pageHandler, asResult?.PageHandler);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }
    }
}
