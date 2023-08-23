using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="GlobalExceptionOccurred"/> class capabilities.
    /// </summary>
    [TestClass]
    public class GlobalExceptionOccurredTests
    {
        /// <summary>
        /// Ensures the object has the correct default properties.
        /// </summary>
        [TestMethod]
        public void GlobalExceptionsNotification_HasCorrectDefaultProperties()
        {
            var exception = new ArgumentNullException();

            var notification = new GlobalExceptionOccurred(exception);

            Assert.AreEqual(exception, notification.Exception);
            Assert.AreEqual(DateTime.UtcNow.Date, notification.DateTime.Date);
        }
    }
}
