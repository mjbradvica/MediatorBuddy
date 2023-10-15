// <copyright file="ObjectVerificationTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediatController.ASPNET;

namespace NMediatController.Tests.ObjectValidation
{
    /// <summary>
    /// Tests the <see cref="ObjectVerification"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ObjectVerificationTests
    {
        /// <summary>
        /// Ensures an object with field fields returns a failure response.
        /// </summary>
        [TestMethod]
        public void Entity_WithFailedFields_ReturnsFailure()
        {
            var result = ObjectVerification.Validate(new ObjectVerificationTest());

            Assert.IsTrue(result.Failed);
        }

        /// <summary>
        /// Ensures an object with all valid fields returns a success response.
        /// </summary>
        [TestMethod]
        public void Entity_WithValidFields_ReturnsSuccess()
        {
            var testObject = new ObjectVerificationTest
            {
                Value = "value",
            };

            var result = ObjectVerification.Validate(testObject);

            Assert.IsFalse(result.Failed);
        }
    }
}
