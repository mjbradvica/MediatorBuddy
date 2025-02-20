// <copyright file="RedirectToActionResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Redirect to action tests.
    /// </summary>
    [TestClass]
    public class RedirectToActionResponsesTests
    {
        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionResponse_NonFragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToActionResponse<TestResponse>(_ =>
                    (actionName,
                    controllerName,
                    routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionResponse_Fragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToActionResponse<TestResponse>(_ =>
                    (actionName,
                        controllerName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionPermanentResponse_NonFragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();

            var result = ResponseOptions.RedirectToActionPermanentResponse<TestResponse>(_ =>
                    (actionName,
                        controllerName,
                        routeValues))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.IsNull(asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionPermanentResponse_Fragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToActionPermanentResponse<TestResponse>(_ =>
                    (actionName,
                        controllerName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsFalse(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionPermanentPreserveResponse_NonFragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToActionPermanentPreserveResponse<TestResponse>(_ =>
                        (actionName,
                        controllerName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsTrue(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }

        /// <summary>
        /// RedirectToActionResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void RedirectToActionPreserveResponse_Fragment_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            const string fragment = "fragment";

            var result = ResponseOptions.RedirectToActionPreserveResponse<TestResponse>(_ =>
                    (actionName,
                        controllerName,
                        routeValues,
                        fragment))
                .Invoke(new TestResponse());

            var asResult = result as RedirectToActionResult;

            Assert.IsInstanceOfType<RedirectToActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.IsFalse(asResult?.Permanent);
            Assert.IsTrue(asResult?.PreserveMethod);
            Assert.AreEqual(fragment, asResult?.Fragment);
        }
    }
}
