using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interfaces
{
    public interface IPlataformaRepository
    {
        void Cadastrar(Plataformas plataforma);
        List<Plataformas> Listar();
        void Deletar(int id);
        Plataformas BuscarPorId(int id);
        void Atualizar(Plataformas plataforma);
    }
}
