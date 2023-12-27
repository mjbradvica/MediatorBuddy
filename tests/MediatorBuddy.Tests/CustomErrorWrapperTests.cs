// <copyright file="CustomErrorWrapperTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using MediatorBuddy.AspNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Tests for the customer error wrapper.
    /// </summary>
    [TestClass]
    public class CustomErrorWrapperTests
    {
        /// <summary>
        /// Ensures the wrapper properties are correct.
        /// </summary>
        [TestMethod]
        public void Wrapper_HasCorrectProperties()
        {
            const int status = 829;
            const string title = "title";
            const string detail = "detail";
            var instance = new Uri("Error/Custom", UriKind.Relative);

            var wrapper = CustomErrorWrapper.Instantiate(status, title, detail, instance, new ErrorTypes());

            Assert.AreEqual(status, wrapper.Status);
            Assert.AreEqual(title, wrapper.Title);
            Assert.AreEqual(detail, wrapper.Detail);
            Assert.AreEqual(instance, wrapper.Instance);
            Assert.IsNotNull(wrapper.ErrorTypes);
        }
    }
}
