// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using MediatorBuddy.AspNet.Registration;
using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Razor
{
    /// <summary>
    /// Entry class for application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method for application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddMediatorBuddy(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("MediatorBuddy.Samples.Common")));
            builder.Services.AddSingleton<IWidgetRepository, WidgetRepository>();
            builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}