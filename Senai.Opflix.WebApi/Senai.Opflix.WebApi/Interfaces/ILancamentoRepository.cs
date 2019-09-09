using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interfaces
{
   public interface ILancamentoRepository
    {
        void Cadastrar(Lancamentos lancamentos);
        List<Lancamentos> Listar();
        void Deletar(int id);
        Lancamentos BuscarPorId(int id);
        void Atualizar(Lancamentos lancamentos);

    }
}
