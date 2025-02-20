// <copyright file="CreatedAtRouteResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// CreatedAtRoute responses tests.
    /// </summary>
    [TestClass]
    public class CreatedAtRouteResponsesTests
    {
        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRouteResponse_ResponseValue_IsCorrect()
        {
            const string routeName = "routeName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(_ => (routeName, routeValues)).Invoke(response);

            var asResponse = result as CreatedAtRouteResult;

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            Assert.AreEqual(routeName, asResponse?.RouteName);
            Assert.AreEqual(routeValues.Count, asResponse?.RouteValues?.Count);
            Assert.AreEqual(response, asResponse?.Value);
        }

        /// <summary>
        /// Ensures the CreatedAtRouteResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void CreatedAtRouteResponse_ResponseFunc_IsCorrect()
        {
            const string routeName = "routeName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.CreatedAtRouteResponse<TestResponse>(_ => (routeName, routeValues, response)).Invoke(response);

            var asResponse = result as CreatedAtRouteResult;

            Assert.IsInstanceOfType<CreatedAtRouteResult>(result);
            Assert.AreEqual(routeName, asResponse?.RouteName);
            Assert.AreEqual(routeValues.Count, asResponse?.RouteValues?.Count);
            Assert.AreEqual(response, asResponse?.Value);
        }
    }
}
