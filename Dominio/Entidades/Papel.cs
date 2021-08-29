using System;

namespace Dominio.Entidades
{
    public class Papel
    {
        public int PapelId { get; set; }
        public string Codigo { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public DateTime DataEmissao { get; set; }

        public Papel(string codigo, int empresaId)
        {
            this.Codigo = codigo;
            this.EmpresaId = empresaId;
            this.DataEmissao = DateTime.Now;
        }
    }
}
