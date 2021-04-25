namespace NMediatController.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
