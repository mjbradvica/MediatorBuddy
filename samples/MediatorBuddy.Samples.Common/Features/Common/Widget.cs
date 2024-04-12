// <copyright file="Widget.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Common.Features.Common
{
    /// <summary>
    /// Sample widget object.
    /// </summary>
    public class Widget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Widget"/> class.
        /// </summary>
        /// <param name="id">The identifier for the widget.</param>
        /// <param name="name">The name for the widget.</param>
        public Widget(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the widget name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Updates a widget name.
        /// </summary>
        /// <param name="name">The new widget name.</param>
        /// <returns>An int result.</returns>
        public int UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }

            Name = name;

            return 1;
        }
    }
}
