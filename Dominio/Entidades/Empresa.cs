using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string ClassificacaoSetorial { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<Papel> Papeis { get; set; }

        public Empresa(string nome, string CNPJ, string classificacaoSetorial)
        {
            this.Nome = nome;
            this.CNPJ = CNPJ;
            this.ClassificacaoSetorial = classificacaoSetorial;
            this.DataCadastro = DateTime.Now;
        }
    }
}
