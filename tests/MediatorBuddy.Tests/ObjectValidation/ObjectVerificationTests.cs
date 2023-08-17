using MediatorBuddy.AspNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests.ObjectValidation
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
