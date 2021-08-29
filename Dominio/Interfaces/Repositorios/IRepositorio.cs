using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : class
    {
        public void Adiciona(TEntidade entidade);
        public void Remove(TEntidade entidade);
        public void Atualiza(TEntidade entidade);
        public void BuscaPorId(object id);
        public IEnumerable<TEntidade> Busca(Expression<Func<bool, TEntidade>> expressao);
    }
}
