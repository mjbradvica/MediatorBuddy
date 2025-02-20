// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using MediatorBuddy.AspNet.Registration;
using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Mvc
{
    /// <summary>
    /// Entry point for sample razor page app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start method for sample app.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddMediatorBuddy(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("MediatorBuddy.Samples.Common")));
            builder.Services.AddSingleton<IWidgetRepository, WidgetRepository>();
            builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}