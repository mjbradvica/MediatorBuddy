// <copyright file="FileResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Text;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// File responses tests.
    /// </summary>
    [TestClass]
    public class FileResponsesTests
    {
        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void FileContentResponse_FileContents_IsCorrect()
        {
            var fileContents = Encoding.UTF8.GetBytes("bytes");
            const string contentType = "application/octet-stream";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.FileContentResponse<TestResponse>(_ =>
                (fileContents,
                contentType,
                lastModified,
                entityTag,
                enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as FileContentResult;

            Assert.IsInstanceOfType<FileContentResult>(result);
            Assert.AreEqual(fileContents, asResult?.FileContents);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }

        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void FileContentResponse_FileContentsWithControllerName_IsCorrect()
        {
            var fileContents = Encoding.UTF8.GetBytes("bytes");
            const string contentType = "application/octet-stream";
            const string fileDownloadName = "controllerName";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.FileContentResponse<TestResponse>(_ =>
                    (fileContents,
                    contentType,
                    fileDownloadName,
                    lastModified,
                    entityTag,
                    enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as FileContentResult;

            Assert.IsInstanceOfType<FileContentResult>(result);
            Assert.AreEqual(fileContents, asResult?.FileContents);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(fileDownloadName, asResult?.FileDownloadName);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }

        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void FileStreamResponse_StreamContents_IsCorrect()
        {
            using (var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}/test.txt", FileMode.OpenOrCreate))
            {
                const string contentType = "application/octet-stream";
                var lastModified = DateTimeOffset.UtcNow;
                var entityTag = EntityTagHeaderValue.Any;
                const bool enableRangeProcessing = false;

                var result = ResponseOptions.FileStreamResponse<TestResponse>(_ =>
                        (fileStream,
                        contentType,
                        lastModified,
                        entityTag,
                        enableRangeProcessing)).Invoke(new TestResponse());

                var asResult = result as FileStreamResult;

                Assert.IsInstanceOfType<FileStreamResult>(result);
                Assert.AreEqual(fileStream, asResult?.FileStream);
                Assert.AreEqual(contentType, asResult?.ContentType);
                Assert.AreEqual(lastModified, asResult?.LastModified);
                Assert.AreEqual(entityTag, asResult?.EntityTag);
                Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
            }
        }

        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void FileStreamResponse_StreamContentsWithControllerName_IsCorrect()
        {
            using (var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}/test.txt", FileMode.OpenOrCreate))
            {
                const string contentType = "application/octet-stream";
                const string fileDownloadName = "controllerName";
                var lastModified = DateTimeOffset.UtcNow;
                var entityTag = EntityTagHeaderValue.Any;
                const bool enableRangeProcessing = false;

                var result = ResponseOptions.FileStreamResponse<TestResponse>(_ =>
                        (fileStream,
                        contentType,
                        fileDownloadName,
                        lastModified,
                        entityTag,
                        enableRangeProcessing)).Invoke(new TestResponse());

                var asResult = result as FileStreamResult;

                Assert.IsInstanceOfType<FileStreamResult>(result);
                Assert.AreEqual(fileStream, asResult?.FileStream);
                Assert.AreEqual(contentType, asResult?.ContentType);
                Assert.AreEqual(fileDownloadName, asResult?.FileDownloadName);
                Assert.AreEqual(lastModified, asResult?.LastModified);
                Assert.AreEqual(entityTag, asResult?.EntityTag);
                Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
            }
        }

        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void VirtualFileResponse_VirtualPath_IsCorrect()
        {
            const string virtualPath = "fileName";
            const string contentType = "application/octet-stream";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.VirtualFileResponse<TestResponse>(_ =>
                (virtualPath,
                contentType,
                lastModified,
                entityTag,
                enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as VirtualFileResult;

            Assert.IsInstanceOfType<VirtualFileResult>(result);
            Assert.AreEqual(virtualPath, asResult?.FileName);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }

        /// <summary>
        /// Ensures the FileResponse has the correct properties.
        /// </summary>
        [TestMethod]
        public void VirtualFileResponse_VirtualPathWithControllerName_IsCorrect()
        {
            const string virtualPath = "fileName";
            const string contentType = "application/octet-stream";
            const string fileDownloadName = "controllerName";
            var lastModified = DateTimeOffset.UtcNow;
            var entityTag = EntityTagHeaderValue.Any;
            const bool enableRangeProcessing = false;

            var result = ResponseOptions.VirtualFileResponse<TestResponse>(_ =>
                    (virtualPath,
                    contentType,
                    fileDownloadName,
                    lastModified,
                    entityTag,
                    enableRangeProcessing)).Invoke(new TestResponse());

            var asResult = result as VirtualFileResult;

            Assert.IsInstanceOfType<VirtualFileResult>(result);
            Assert.AreEqual(virtualPath, asResult?.FileName);
            Assert.AreEqual(contentType, asResult?.ContentType);
            Assert.AreEqual(fileDownloadName, asResult?.FileDownloadName);
            Assert.AreEqual(lastModified, asResult?.LastModified);
            Assert.AreEqual(entityTag, asResult?.EntityTag);
            Assert.AreEqual(enableRangeProcessing, asResult?.EnableRangeProcessing);
        }
    }
}
