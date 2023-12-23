// <copyright file="CreatedAtActionResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for CreatedAtAction responses.
    /// </summary>
    [TestClass]
    public class CreatedAtActionResponsesTests
    {
        /// <summary>
        /// Ensures the CreatedAtActionResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedAtActionResponse_ResponseValue_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedAtActionResponse<TestResponse>(_ => (actionName, controllerName, routeValues)).Invoke(response);

            var asResult = result as CreatedAtActionResult;

            Assert.IsInstanceOfType<CreatedAtActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.AreEqual(response, asResult?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtActionResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void CreatedAtActionResponse_ResponseFunc_IsCorrect()
        {
            const string actionName = "actionName";
            const string controllerName = "controllerName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedAtActionResponse<TestResponse>(_ => (actionName, controllerName, routeValues, response)).Invoke(response);

            var asResult = result as CreatedAtActionResult;

            Assert.IsInstanceOfType<CreatedAtActionResult>(result);
            Assert.AreEqual(actionName, asResult?.ActionName);
            Assert.AreEqual(controllerName, asResult?.ControllerName);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
            Assert.AreEqual(response, asResult?.Value);
        }
    }
}
