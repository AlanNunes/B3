using System;

namespace Ordens.Dominio.Commands.Responses
{
    public class EnviaOrdemResponse
    {
        public int Id { get; set; }
        public string CodigoPapel { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public string CPF { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
