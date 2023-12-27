// <copyright file="MediatorBuddyAttributeTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Attributes
{
    /// <summary>
    /// Tests for mediator buddy error response attributes.
    /// </summary>
    [TestClass]
    public class MediatorBuddyAttributeTests
    {
        /// <summary>
        /// Ensures the mediator buddy 400 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy400Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy400ErrorResponseAttribute(), StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Ensures the mediator buddy 401 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy401Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy401ErrorResponseAttribute(), StatusCodes.Status401Unauthorized);
        }

        /// <summary>
        /// Ensures the mediator buddy 403 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy403Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy403ErrorResponseAttribute(), StatusCodes.Status403Forbidden);
        }

        /// <summary>
        /// Ensures the mediator buddy 404 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy404Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy404ErrorResponseAttribute(), StatusCodes.Status404NotFound);
        }

        /// <summary>
        /// Ensures the mediator buddy 405 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy405Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy405ErrorResponseAttribute(), StatusCodes.Status405MethodNotAllowed);
        }

        /// <summary>
        /// Ensures the mediator buddy 406 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy406Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy406ErrorResponseAttribute(), StatusCodes.Status406NotAcceptable);
        }

        /// <summary>
        /// Ensures the mediator buddy 407 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy407Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy407ErrorResponseAttribute(), StatusCodes.Status407ProxyAuthenticationRequired);
        }

        /// <summary>
        /// Ensures the mediator buddy 409 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy409Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy409ErrorResponseAttribute(), StatusCodes.Status409Conflict);
        }

        /// <summary>
        /// Ensures the mediator buddy 422 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy422Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy422ErrorResponseAttribute(), StatusCodes.Status422UnprocessableEntity);
        }

        /// <summary>
        /// Ensures the mediator buddy 423 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy423Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy423ErrorResponseAttribute(), StatusCodes.Status423Locked);
        }

        /// <summary>
        /// Ensures the mediator buddy 429 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy429Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy429ErrorResponseAttribute(), StatusCodes.Status429TooManyRequests);
        }

        /// <summary>
        /// Ensures the mediator buddy 500 attribute is correct.
        /// </summary>
        [TestMethod]
        public void MediatorBuddy500Attribute_IsCorrect()
        {
            AssertIsType(new MediatorBuddy500ErrorResponseAttribute(), StatusCodes.Status500InternalServerError);
        }

        private static void AssertIsType(IApiResponseMetadataProvider attribute, int statusCode)
        {
            Assert.AreEqual(typeof(ErrorResponse), attribute.Type);
            Assert.AreEqual(statusCode, attribute.StatusCode);
        }
    }
}
