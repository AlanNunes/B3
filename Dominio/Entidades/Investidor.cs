using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Investidor
    {
        public int InvestidorId { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public IEnumerable<Ordem> Ordens { get; set; }
        public IEnumerable<DepositoAcaoInvestidor> Acoes { get; set; }
    }
}
