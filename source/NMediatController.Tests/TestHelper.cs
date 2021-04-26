namespace NMediatController.Tests
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal static class TestHelper
    {
        public static void AssertInstance<T>(IActionResult result)
        {
            Assert.IsInstanceOfType(result, typeof(T));
        }

        public static void AssertUriInstance<T>(string expected, IActionResult result)
        {
            AssertHasProperty<T>(expected, result, "Location");
        }

        public static void AssertUriInstance<T>(Uri expected, IActionResult result)
        {
            AssertUriInstance<T>(expected.ToString(), result);
        }

        public static void AssertActionNameInstance<T>(string expected, IActionResult result)
        {
            AssertHasProperty<T>(expected, result, "ActionName");
        }

        private static void AssertHasProperty<T>(string expected, IActionResult result, string propertyName)
        {
            AssertInstance<T>(result);

            Assert.AreEqual(expected, result.GetType().GetProperties().First(propertyInfo => propertyInfo.Name == propertyName).GetValue(result) as string);
        }

        private static string GetProperty(IActionResult result, string propertyName)
        {
            return result.GetType().GetProperties().First(propertyInfo => propertyInfo.Name == propertyName).GetValue(result) as string;
        }
    }
}
