// <copyright file="ViewResponsesTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MediatorBuddy.Tests.Responses
{
    /// <summary>
    /// View responses tests.
    /// </summary>
    [TestClass]
    public class ViewResponsesTests
    {
        private readonly RazorViewData _viewData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewResponsesTests"/> class.
        /// </summary>
        public ViewResponsesTests()
        {
            _viewData = RazorViewData.Initialize(
                new Mock<ITempDataDictionary>().Object,
                new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()));
        }

        /// <summary>
        /// Ensures an empty view response is correct.
        /// </summary>
        [TestMethod]
        public void EmptyViewResponse_IsCorrect()
        {
            var response = ResponseOptions.EmptyViewResponse<TestResponse>();

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as ViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.IsNotNull(asResult?.ViewData);
            Assert.IsNotNull(asResult.TempData);
        }

        /// <summary>
        /// Ensures a view response is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_IsCorrect()
        {
            var response = ResponseOptions.ViewResponse<TestResponse>();

            var expectedResponse = new TestResponse();

            var result = response.Invoke(expectedResponse, _viewData);

            var asResult = result as ViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expectedResponse, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a view response with name parameter is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_ViewName_IsCorrect()
        {
            const string viewName = "myView";

            var response = ResponseOptions.ViewResponse<TestResponse>(viewName);

            var expectedResponse = new TestResponse();

            var result = response.Invoke(expectedResponse, _viewData);

            var asResult = result as ViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expectedResponse, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures the view response with an object func is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_ObjectFunc_IsCorrect()
        {
            object expected = new { Id = 1 };

            var response = ResponseOptions.ViewResponse<TestResponse>(_ => expected);

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as ViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures the view response with an object func is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_MappingFunc_IsCorrect()
        {
            object expected = new { Id = 1 };

            var response = ResponseOptions.ViewResponse<TestResponse, object>(_ => expected);

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as ViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a view response with a result object tuple is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_ObjectTuple_IsCorrect()
        {
            object expected = new { Id = 1 };
            const string viewName = "myView";

            var response = ResponseOptions.ViewResponse<TestResponse>(_ => (expected, viewName));

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as ViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a view response with mapping tuple is correct.
        /// </summary>
        [TestMethod]
        public void ViewResponse_MappingTuple_IsCorrect()
        {
            object expected = new { Id = 1 };
            const string viewName = "myView";

            var response = ResponseOptions.ViewResponse<TestResponse, object>(_ => (expected, viewName));

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as ViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures an empty partial view response is correct.
        /// </summary>
        [TestMethod]
        public void EmptyPartialViewResponse_IsCorrect()
        {
            var response = ResponseOptions.EmptyPartialViewResponse<TestResponse>();

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as PartialViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.IsNotNull(asResult?.ViewData);
            Assert.IsNotNull(asResult.TempData);
        }

        /// <summary>
        /// Ensures a partial view response is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_IsCorrect()
        {
            var response = ResponseOptions.PartialViewResponse<TestResponse>();

            var expected = new TestResponse();

            var result = response.Invoke(expected, _viewData);

            var asResult = result as PartialViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a partial view response is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_ViewName_IsCorrect()
        {
            const string viewName = "myView";

            var response = ResponseOptions.PartialViewResponse<TestResponse>(viewName);

            var expected = new TestResponse();

            var result = response.Invoke(expected, _viewData);

            var asResult = result as PartialViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures the view response for an object func is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_ObjectFunc_IsCorrect()
        {
            object expected = new { Id = 1 };

            var response = ResponseOptions.PartialViewResponse<TestResponse>(_ => expected);

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as PartialViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures the view response for a mapping func is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_MappingFunc_IsCorrect()
        {
            object expected = new { Id = 1 };

            var response = ResponseOptions.PartialViewResponse<TestResponse, object>(_ => expected);

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as PartialViewResult;

            Assert.IsNull(asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a partial view with object tuple is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_ObjectTuple_IsCorrect()
        {
            object expected = new { Id = 1 };
            const string viewName = "myView";

            var response = ResponseOptions.PartialViewResponse<TestResponse>(_ => (expected, viewName));

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as PartialViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }

        /// <summary>
        /// Ensures a partial view with object tuple is correct.
        /// </summary>
        [TestMethod]
        public void PartialViewResponse_MappingTuple_IsCorrect()
        {
            object expected = new { Id = 1 };
            const string viewName = "myView";

            var response = ResponseOptions.PartialViewResponse<TestResponse, object>(_ => (expected, viewName));

            var result = response.Invoke(new TestResponse(), _viewData);

            var asResult = result as PartialViewResult;

            Assert.AreEqual(viewName, asResult?.ViewName);
            Assert.AreEqual(expected, asResult?.ViewData.Model);
            Assert.IsNotNull(asResult?.TempData);
        }
    }
}
