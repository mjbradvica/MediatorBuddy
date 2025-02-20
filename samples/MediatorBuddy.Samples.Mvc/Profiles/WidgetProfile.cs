// <copyright file="WidgetProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.Samples.Common.Features.AddWidget;
using MediatorBuddy.Samples.Common.Features.GetAll;
using MediatorBuddy.Samples.Common.Features.GetById;
using MediatorBuddy.Samples.Mvc.ViewModels;

namespace MediatorBuddy.Samples.Mvc.Profiles
{
    /// <summary>
    /// Sample mapping profile.
    /// </summary>
    public class WidgetProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetProfile"/> class.
        /// </summary>
        public WidgetProfile()
        {
            CreateMap<GetAllWidgetsResponse, WidgetIndexViewModel>();

            CreateMap<GetWidgetByIdResponse, WidgetViewModel>()
                .ConstructUsing(response => WidgetViewModel.FromWidget(response));

            CreateMap<AddWidgetViewModel, AddWidgetRequest>();
        }
    }
}
