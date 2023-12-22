// <copyright file="AcceptedAtActionResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Accepted at action responses.
    /// </summary>
    [TestClass]
    public class AcceptedAtActionResponsesTests
    {
        /// <summary>
        /// Ensures the AcceptedAtActionEmpty has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtAction_ResponseValue_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            object routeValues = string.Empty;
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedAtActionEmpty<TestResponse>(_ => (actionName, controllerName, routeValues)).Invoke(response);

            var asResult = result as AcceptedAtActionResult;

            Assert.IsInstanceOfType<AcceptedAtActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues, asResult?.RouteValues);
            Assert.AreEqual(response, asResult?.Value);
        }

        /// <summary>
        /// Ensures the AcceptedAtActionEmpty has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtAction_ResponseFunc_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            object routeValues = string.Empty;
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedAtActionEmpty<TestResponse>(_ => (actionName, controllerName, routeValues, response)).Invoke(response);

            var asResult = result as AcceptedAtActionResult;

            Assert.IsInstanceOfType<AcceptedAtActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues, asResult?.RouteValues);
            Assert.AreEqual(response, asResult?.Value);
        }
    }
}
