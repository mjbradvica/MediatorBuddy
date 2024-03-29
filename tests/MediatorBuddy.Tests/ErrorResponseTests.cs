﻿// <copyright file="ErrorResponseTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using MediatorBuddy.AspNet;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="ErrorResponse"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ErrorResponseTests
    {
        /// <summary>
        /// Ensures the object has the correct properties.
        /// </summary>
        [TestMethod]
        public void ErrorResponse_HasCorrectProperties()
        {
            var type = new Uri("/errors/general", UriKind.Relative);
            const string title = "error";
            const int status = 304;
            const string detail = "an error occurred";
            var instance = new Uri("/people", UriKind.Relative);

            var errorResponse = new ErrorResponse(type, title, status, detail, instance);

            Assert.AreEqual(type, errorResponse.Type);
            Assert.AreEqual(title, errorResponse.Title);
            Assert.AreEqual(status, errorResponse.Status);
            Assert.AreEqual(detail, errorResponse.Detail);
            Assert.AreEqual(instance, errorResponse.Instance);
        }

        /// <summary>
        /// Ensures the validation error properties are correct.
        /// </summary>
        [TestMethod]
        public void ValidationError_HasCorrectProperties()
        {
            var type = new Uri("/errors/validation", UriKind.Relative);
            const string title = "Validation Error";
            var errors = new List<string> { "A validation constraint was not met." };
            const string detail = "The following errors were present: A validation constraint was not met.";
            var instance = new Uri("/people", UriKind.Relative);

            var errorResponse = ErrorResponse.ValidationError(type, errors, instance);

            Assert.AreEqual(type, errorResponse.Type);
            Assert.AreEqual(title, errorResponse.Title);
            Assert.AreEqual(StatusCodes.Status400BadRequest, errorResponse.Status);
            Assert.AreEqual(detail, errorResponse.Detail);
            Assert.AreEqual(instance, errorResponse.Instance);
        }

        /// <summary>
        /// Ensures the method returns an instance with the correct properties.
        /// </summary>
        [TestMethod]
        public void FromEnvelope_HasCorrectProperties()
        {
            var type = new Uri("/errors/general", UriKind.Relative);
            const string title = "error";
            const int status = 304;
            const string detail = "an error occurred";
            var instance = new Uri("/people", UriKind.Relative);

            var errorResponse = ErrorResponse.FromEnvelope(type, status, Envelope<TestResponse>.Failure(status, title, detail), instance);

            Assert.AreEqual(type, errorResponse.Type);
            Assert.AreEqual(title, errorResponse.Title);
            Assert.AreEqual(status, errorResponse.Status);
            Assert.AreEqual(detail, errorResponse.Detail);
            Assert.AreEqual(instance, errorResponse.Instance);
        }
    }
}
