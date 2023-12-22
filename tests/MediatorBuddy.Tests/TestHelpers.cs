// <copyright file="TestHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Routing;

namespace MediatorBuddy.Tests
{
    /// <summary>
    /// Test helpers.
    /// </summary>
    internal static class TestHelpers
    {
        /// <summary>
        /// Helper for route values.
        /// </summary>
        /// <returns>A route value dictionary.</returns>
        public static RouteValueDictionary RouteValueDictionary()
        {
            return new RouteValueDictionary
            {
                { "route", "value" },
            };
        }

        /// <summary>
        /// Helper for Uri locations.
        /// </summary>
        /// <returns>A uri.</returns>
        public static Uri UriLocation()
        {
            return new Uri("https://www.mylocation.com");
        }
    }
}
