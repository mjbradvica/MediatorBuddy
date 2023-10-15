// <copyright file="ErrorViewModel.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Mvc.Models
{
    /// <summary>
    /// Viewmodel for error page.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request id.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request id should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}