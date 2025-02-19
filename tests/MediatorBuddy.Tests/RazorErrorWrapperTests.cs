// <copyright file="RazorErrorWrapperTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Test for the razor error wrapper.
    /// </summary>
    [TestClass]
    public class RazorErrorWrapperTests
    {
        /// <summary>
        /// Ensures the wrapper has the correct properties.
        /// </summary>
        [TestMethod]
        public void Instantiate_HasCorrectProperties()
        {
            const int status = 182;
            const string title = "title";
            const string details = "details";

            var wrapper = RazorErrorWrapper.Instantiate(status, title, details);

            Assert.AreEqual(status, wrapper.ApplicationStatus);
            Assert.AreEqual(title, wrapper.Title);
            Assert.AreEqual(details, wrapper.Detail);
        }
    }
}
