using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordens.Application.Interfaces;
using Ordens.Application.Services;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Validators.Requests;
using Ordens.Infra.CrossCutting.IoC.AutoMapper;
using SharedKernel.Infra.CrossCutting.IoC;
using System;

namespace Ordens.Infra.CrossCutting.IoC
{
    public static class OrdensDependencyInjection
    {
        public static void RegistraOrdensDependencias(this IServiceCollection services, string connString)
        {
            SharedKernelDependencyInjection.RegistraDependenciasSharedKernel(services, connString);
            var assembly = AppDomain.CurrentDomain.Load("Ordens.Dominio");
            services.AddMediatR(assembly);
            services.AddScoped<IOrdemAppService, OrdemAppService>();
            services.AddScoped<IValidator<EnviaOrdemRequest>, EnviaOrdemRequestValidator>();
            services.AddScoped<IValidator<CancelaOrdemRequest>, CancelaOrdemRequestValidator>();
            services.AddScoped<IValidator<ListaOrdensRequest>, ListaOrdensRequestValidator>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
