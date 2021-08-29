﻿using System;

namespace Dominio.Entidades
{
    public class Ordem
    {
        public int Id { get; set; }
        public string CodigoPapel { get; set; }
        public decimal Valor {  get; set; }
        public TipoOrdem Tipo { get; set; }
        public StatusOrdem Status { get; set; }
        public DateTime DataEnvio { get; set; }

        public bool OrdemValida(DateTime inicioNegociacao, DateTime terminoNegociacao)
        {
            bool enviadaNoHorarioDeNegociacao = this.DataEnvio >= inicioNegociacao && this.DataEnvio <= terminoNegociacao;
            return enviadaNoHorarioDeNegociacao && StatusOrdem.Rejeitada != this.Status;
        }
    }
}