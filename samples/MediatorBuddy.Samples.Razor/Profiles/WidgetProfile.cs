﻿// <copyright file="WidgetProfile.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using AutoMapper;
using MediatorBuddy.Samples.Common.Features.GetById;
using MediatorBuddy.Samples.Razor.ViewModels;

namespace MediatorBuddy.Samples.Razor.Profiles
{
    /// <summary>
    /// Sample widget profile.
    /// </summary>
    public class WidgetProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetProfile"/> class.
        /// </summary>
        public WidgetProfile()
        {
            CreateMap<GetWidgetByIdResponse, WidgetViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Widget.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Widget.Name));
        }
    }
}
