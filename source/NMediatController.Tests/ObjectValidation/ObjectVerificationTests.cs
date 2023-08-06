using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMediatController.ASPNET;

namespace NMediatController.Tests.ObjectValidation
{
    [TestClass]
    public class ObjectVerificationTests
    {
        [TestMethod]
        public void Entity_WithFailedFields_ReturnsFailure()
        {
            var result = ObjectVerification.Validate(new ObjectVerificationTest());

            Assert.IsTrue(result.Failed);
        }

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
