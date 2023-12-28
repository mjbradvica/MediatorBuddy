// <copyright file="WidgetRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace MediatorBuddy.Samples.Razor.Features.Common
{
    /// <inheritdoc />
    public class WidgetRepository : IWidgetRepository
    {
        private readonly List<Widget> _widgets;

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetRepository"/> class.
        /// </summary>
        public WidgetRepository()
        {
            _widgets = new List<Widget>
            {
                new Widget(Guid.NewGuid(), "A18-Y122"),
                new Widget(Guid.NewGuid(), "XC8-45B"),
            };
        }

        /// <inheritdoc />
        public Task<int> AddWidget(Widget widget)
        {
            _widgets.Add(widget);

            return Task.FromResult(1);
        }

        /// <inheritdoc />
        public Task<List<Widget>> GetAllWidgets()
        {
            return Task.FromResult(_widgets);
        }

        /// <inheritdoc />
        public Task<Widget?> GetById(Guid id)
        {
            return Task.FromResult(_widgets.FirstOrDefault(x => x.Id == id));
        }

        /// <inheritdoc />
        public Task<int> DeleteWidget(Widget widget)
        {
            _widgets.Remove(widget);

            return Task.FromResult(1);
        }

        /// <inheritdoc />
        public Task<int> UpdateWidget(Widget widget)
        {
            var toRemove = _widgets.First(x => x.Id == widget.Id);

            _widgets.Remove(toRemove);

            _widgets.Add(widget);

            return Task.FromResult(1);
        }
    }
}
