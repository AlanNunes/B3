using Dominio.Entidades;

namespace Ordens.Application.DTOs
{
    public class EnviaOrdemRequestDTO
    {
        public string CodigoPapel { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public string CPF { get; set; }
        public TipoOrdem TipoOrdem { get; set; }
    }
}
