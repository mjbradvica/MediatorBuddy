// <copyright file="ServiceCollectionExtensions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

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
        /// <returns>The ServiceCollection object to continue with.</returns>
        public static IServiceCollection AddMediatorBuddy(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            return services;
        }
    }
}
