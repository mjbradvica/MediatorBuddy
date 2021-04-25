namespace NMediatController.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal static class TestHelper
    {
        private const string UriString = "http://www.test.com/";

        public static async Task TestControllerMethod<T>(Func<IRequest<string>, Task<IActionResult>> controllerMethod, IRequest<string> request)
        {
            var result = await controllerMethod.Invoke(request);

            AssertInstance<T>(result);
        }

        public static async Task TestControllerMethod<T>(Func<IRequest<string>, string, Task<IActionResult>> controllerMethod, string uri, IRequest<string> request)
        {
            var result = await controllerMethod.Invoke(request, uri);

            AssertUriInstance<T>(result);
        }

        public static async Task TestControllerMethod<T>(Func<IRequest<string>, Uri, Task<IActionResult>> controllerMethod, Uri uri, IRequest<string> request)
        {
            var result = await controllerMethod.Invoke(request, uri);

            AssertUriInstance<T>(result);
        }

        public static async Task TestControllerMethod<T>(Func<IRequest<object>, Task<IActionResult>> controllerMethod, IRequest<object> request)
        {
            var result = await controllerMethod.Invoke(request);

            AssertInstance<T>(result);
        }

        private static void AssertInstance<T>(IActionResult result)
        {
            Assert.IsInstanceOfType(result, typeof(T));
        }

        private static void AssertUriInstance<T>(IActionResult result)
        {
            Assert.IsInstanceOfType(result, typeof(T));

            Assert.AreEqual(UriString, GetLocation(result));
        }

        private static string GetLocation(IActionResult result)
        {
            return result.GetType().GetProperties().First(propertyInfo => propertyInfo.Name == "Location").GetValue(result) as string;
        }
    }
}
