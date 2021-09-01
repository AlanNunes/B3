using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infra.Data;
using SharedKernel.Infra.Data.Repositorios;

namespace SharedKernel.Infra.CrossCutting.IoC
{
    public static class SharedKernelDependencyInjection
    {
        public static void RegistraDependenciasSharedKernel(IServiceCollection services, string connString)
        {
            services.AddDbContext<B3Contexto>(options => options.UseSqlServer(connString));
            services.AddScoped<IOrdemRepositorio, OrdemRepositorio>();
            services.AddScoped<IInvestidorRepositorio, InvestidorRepositorio>();
        }
    }
}
