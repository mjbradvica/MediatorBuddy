// <copyright file="ContentResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Tests for Content responses.
    /// </summary>
    [TestClass]
    public class ContentResponsesTests
    {
        /// <summary>
        /// Ensures the ContentResponse properties are correct.
        /// </summary>
        [TestMethod]
        public void ContentResponse_IsCorrect()
        {
            const int statusCode = 129;
            const string content = "content";
            const string contentType = "contentType";

            var result = ResponseOptions.ContentResponse<TestResponse>(_ => (statusCode, content, contentType))
                .Invoke(new TestResponse());

            var asResult = result as ContentResult;

            Assert.IsInstanceOfType<ContentResult>(result);
            Assert.AreEqual(statusCode, asResult?.StatusCode);
            Assert.AreEqual(content, asResult?.Content);
            Assert.AreEqual(contentType, asResult?.ContentType);
        }
    }
}
