using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecaRepository
    {
        List<Pecas> Listar();
        void Cadastrar(Pecas peca);
        Pecas BuscarPecasPorFornecedor(int id);
        Pecas BuscarPecasPorId(int id);
       // void Atualizar(int id);

    }
}
