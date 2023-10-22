// <copyright file="ObjectVerificationTest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace MediatorBuddy.Tests.ObjectValidation
{
    /// <summary>
    /// Test class for object verification.
    /// </summary>
    public class ObjectVerificationTest
    {
        /// <summary>
        /// Gets or sets value to be verified by the validation methods.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; } = string.Empty;
    }
}
