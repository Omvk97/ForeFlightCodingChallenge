using System;
using System.Reflection;
using Application.Interfaces;
using FluentValidation;
using Infrastructure.Services;
using Infrastructure.Services.ForeFlightWeatherReportApi;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRefitClient<IForeFlightWeatherReportApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://qa.foreflight.com"));
            
            services.AddTransient<IAirportWeatherReportService, AirportWeatherReportService>();

            return services;
        }
    }
}