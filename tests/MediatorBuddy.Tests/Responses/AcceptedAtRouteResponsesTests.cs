// <copyright file="AcceptedAtRouteResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Accepted at route responses.
    /// </summary>
    [TestClass]
    public class AcceptedAtRouteResponsesTests
    {
        /// <summary>
        /// Ensures the AcceptedAtRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtRouteResponse_ResponseValue_IsCorrect()
        {
            const string routeName = "routeName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedAtRouteResponse<TestResponse>(_ => (routeName, routeValues)).Invoke(response);

            var asResult = result as AcceptedAtRouteResult;

            Assert.IsInstanceOfType<AcceptedAtRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(response, asResult?.Value);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
        }

        /// <summary>
        /// Ensures the AcceptedAtRouteResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void AcceptedAtRouteResponse_ResponseFunc_IsCorrect()
        {
            const string routeName = "routeName";
            var routeValues = TestHelpers.RouteValueDictionary();
            var response = new TestResponse();

            var result = ResponseOptions.AcceptedAtRouteResponse<TestResponse>(_ => (routeName, routeValues, response)).Invoke(response);

            var asResult = result as AcceptedAtRouteResult;

            Assert.IsInstanceOfType<AcceptedAtRouteResult>(result);
            Assert.AreEqual(routeName, asResult?.RouteName);
            Assert.AreEqual(response, asResult?.Value);
            Assert.AreEqual(routeValues.Count, asResult?.RouteValues?.Count);
        }
    }
}
