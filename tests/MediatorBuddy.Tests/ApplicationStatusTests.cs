namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests the <see cref="ApplicationStatus"/> class capabilities.
    /// </summary>
    [TestClass]
    public class ApplicationStatusTests
    {
        /// <summary>
        /// Ensures that all application status numbers are correct.
        /// </summary>
        [TestMethod]
        public void Values_AreCorrectValues()
        {
            Assert.AreEqual(0, ApplicationStatus.Success);
        }
    }
}
