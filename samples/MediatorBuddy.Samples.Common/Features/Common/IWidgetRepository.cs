// <copyright file="IWidgetRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Common.Features.Common
{
    /// <summary>
    /// Sample widget repository.
    /// </summary>
    public interface IWidgetRepository
    {
        /// <summary>
        /// Mock method for adding a widget to a database.
        /// </summary>
        /// <param name="widget">The <see cref="Widget"/> to add.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="int"/> representing the rows affected.</returns>
        Task<int> AddWidget(Widget widget);

        /// <summary>
        /// Mock method to return all widgets from a database.
        /// </summary>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> of <see cref="Widget"/>.</returns>
        Task<List<Widget>> GetAllWidgets();

        /// <summary>
        /// Mock method to return a widget by id.
        /// </summary>
        /// <param name="id">A <see cref="Guid"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="Widget"/>.</returns>
        Task<Widget?> GetById(Guid id);

        /// <summary>
        /// Mock method to delete a widget.
        /// </summary>
        /// <param name="widget">A <see cref="Widget"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="int"/> representing the rows affected.</returns>
        Task<int> DeleteWidget(Widget widget);

        /// <summary>
        /// Mock method to update a widget.
        /// </summary>
        /// <param name="widget">A <see cref="Widget"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="int"/> representing the rows affected.</returns>
        Task<int> UpdateWidget(Widget widget);
    }
}
