// <copyright file="WidgetProfile.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.Samples.Common.Features.Common;
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

            CreateMap<Widget, WidgetViewModel>();
            CreateMap<GetWidgetByIdResponse, WidgetViewModel>().ConstructUsing(response => WidgetViewModel.FromWidget(response));
        }
    }
}
