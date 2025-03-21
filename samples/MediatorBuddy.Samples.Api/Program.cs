// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using MediatorBuddy.AspNet.Registration;
using MediatorBuddy.Samples.Common.Features.Common;

namespace MediatorBuddy.Samples.Api
{
    /// <summary>
    /// Entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method.
        /// </summary>
        /// <param name="args">command line args.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddMediatorBuddy(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.Load("MediatorBuddy.Samples.Common")));
            builder.Services.AddSingleton<IWidgetRepository, WidgetRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}