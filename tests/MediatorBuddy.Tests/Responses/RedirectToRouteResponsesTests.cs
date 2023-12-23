// <copyright file="RedirectToRouteResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for redirect to route responses.
    /// </summary>
    [TestClass]
    public class RedirectToRouteResponsesTests
    {
        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRouteResponse_NonFragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToRouteResponse<TestResponse>(_ =>
                    (routeName,
                    routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRouteResponse_Fragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToRouteResponse<TestResponse>(_ =>
                        (routeName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRoutePermanentResponse_NonFragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToRoutePermanentResponse<TestResponse>(_ =>
                        (routeName,
                        routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRoutePermanentResponse_Fragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToRoutePermanentResponse<TestResponse>(_ =>
                        (routeName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRoutePermanentPreserveResponse_NonFragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToRoutePermanentPreserveResponse<TestResponse>(_ =>
                        (routeName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToRoutePreserveResponse_Fragment_IsCorrect()
        {
            const string routeName = "RouteName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToRoutePreserveResponse<TestResponse>(_ =>
                        (routeName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToRouteResult;

            Assert.IsInstanceOfType<RedirectToRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }
    }
}
