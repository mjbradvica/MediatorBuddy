// <copyright file="GlobalExceptionOccurredTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.Events
{
    /// <summary>
    /// Tests for the <see cref="GlobalExceptionOccurred"/> class.
    /// </summary>
    [TestClass]
    public class GlobalExceptionOccurredTests
    {
        /// <summary>
        /// Event has the correct properties.
        /// </summary>
        [TestMethod]
        public void GlobalExceptionOccurred_HasCorrectProperties()
        {
            var exception = new NullReferenceException();

            var notification = new GlobalExceptionOccurred(exception);

            Assert.AreEqual(exception, notification.Exception);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, notification.DateTimeOffset.Date);
        }
    }
}
