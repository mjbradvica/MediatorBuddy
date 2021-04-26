namespace NMediatController.Tests.ObjectValidation
{
    using System.Linq;
    using ASPNET;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectVerificationResultTests
    {
        [TestMethod]
        public void Successful_ShouldReturnWithNoErrors()
        {
            var result = ObjectVerificationResult.Successful();

            Assert.IsFalse(result.Failed);
            Assert.IsNull(result.Errors);
        }

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
