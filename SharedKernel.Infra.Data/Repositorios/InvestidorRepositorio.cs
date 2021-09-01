using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SharedKernel.Infra.Data.Repositorios
{
    public class InvestidorRepositorio : IInvestidorRepositorio
    {
        private readonly B3Contexto _contexto;

        public InvestidorRepositorio(B3Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<Investidor> BuscaInvestidorPeloCPF(string CPF)
        {
            return await _contexto.Investidor.FirstOrDefaultAsync(inv => inv.CPF == CPF);
        }
    }
}
