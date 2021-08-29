using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordens.Application.Interfaces;
using Ordens.Application.Services;
using Ordens.Infra.CrossCutting.IoC.AutoMapper;
using System;
using System.Reflection;

namespace Ordens.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void RegistraOrdensDependencias(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Ordens.Dominio");
            services.AddMediatR(assembly);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IOrdemAppService, OrdemAppService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
