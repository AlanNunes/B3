using Dominio.Entidades;
using System;

namespace Ordens.Application.DTOs.ListaOrdens
{
    public class OrdemDTO
    {
        public int Id { get; set; }
        public string CodigoPapel { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public TipoOrdem Tipo { get; set; }
        public StatusOrdem Status { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
