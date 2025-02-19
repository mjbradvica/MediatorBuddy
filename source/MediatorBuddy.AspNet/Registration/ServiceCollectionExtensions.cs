// <copyright file="ServiceCollectionExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorBuddy.AspNet.Registration
{
    /// <summary>
    /// Extensions methods that allow for easy registration of the MediatorBuddy library.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all dependencies for the MediatorBuddy library into the ServiceCollection.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="configuration">An instance of the configuration for the Mediator library.</param>
        /// <returns>The ServiceCollection object to continue with.</returns>
        public static IServiceCollection AddMediatorBuddy(this IServiceCollection services, MediatRServiceConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddMediatR(configuration);

            return services;
        }

        /// <summary>
        /// Registers all dependencies for the MediatorBuddy library into the ServiceCollection.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="configuration">An action that returns a configuration for the Mediator library.</param>
        /// <returns>The ServiceCollection object to continue with.</returns>
        public static IServiceCollection AddMediatorBuddy(this IServiceCollection services, Action<MediatRServiceConfiguration> configuration)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddMediatR(configuration);

            return services;
        }
    }
}
