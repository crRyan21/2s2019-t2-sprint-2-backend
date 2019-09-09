using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
        void Cadastrar(Usuarios usuario);
        List<Usuarios> Listar();
        void Deletar(int id);
        Usuarios BuscarPorId(int id);
    }
}
