using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categorias categoria);
        List<Categorias> Listar();
        void Deletar(int id);
        Categorias BuscarPorId(int id);
        void Atualizar(Categorias categoria);
    }
}
