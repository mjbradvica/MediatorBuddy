// <copyright file="PhysicalFileResponsesTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// Physical file responses tests.
    /// </summary>
    [TestClass]
    public class PhysicalFileResponsesTests
    {
        /// <summary>
        /// Ensures the PhysicalFileResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void PhysicalFileResponse_PhysicalPath_IsCorrect()
        {
            const string physicalPath = "physicalPath";
            const string contentType = "application/octet-stream";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.PhysicalFileResponse<TestResponse>(_ => (
                physicalPath,
                contentType,
                lastModified,
                entityTag,
                enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as PhysicalFileResult;

            Assert.IsInstanceOfType<PhysicalFileResult>(result);
            Assert.AreEqual(physicalPath, asResult?.FileName);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }

        /// <summary>
        /// Ensures the PhysicalFileResult has the correct properties.
        /// </summary>
        [TestMethod]
        public void PhysicalFileResponse_PhysicalPathWithControllerName_IsCorrect()
        {
            const string physicalPath = "physicalPath";
            const string contentType = "application/octet-stream";
            const string fileDownloadName = "controllerName";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.PhysicalFileResponse<TestResponse>(_ => (
                physicalPath,
                contentType,
                fileDownloadName,
                lastModified,
                entityTag,
                enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as PhysicalFileResult;

            Assert.IsInstanceOfType<PhysicalFileResult>(result);
            Assert.AreEqual(physicalPath, asResult?.FileName);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(fileDownloadName, asResult?.FileDownloadName);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }
    }
}
