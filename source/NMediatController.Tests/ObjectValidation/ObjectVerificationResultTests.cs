// <copyright file="ObjectVerificationResultTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediatController.ASPNET;

namespace NMediatController.Tests.ObjectValidation
{
    /// <summary>
    /// Tests the <see cref="ObjectVerificationResult"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ObjectVerificationResultTests
    {
        /// <summary>
        /// Ensures the correct properties on a successful validation.
        /// </summary>
        [TestMethod]
        public void Successful_ShouldReturnWithNoErrors()
        {
            var result = ObjectVerificationResult.Successful();

            Assert.IsFalse(result.Failed);
            Assert.AreEqual(0, result.Errors.Count());
        }

        /// <summary>
        /// Ensures the correct properties on a failed validation.
        /// </summary>
        [TestMethod]
        public void Failure_ShouldReturnWithErrors()
        {
            var errors = new[] { "error" };

            var result = ObjectVerificationResult.Failure(errors);

            Assert.IsTrue(result.Failed);
            Assert.AreEqual(errors.Length, result.Errors.Count());
        }
    }
}
