using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                // buscar os dados no banco e verificar se este email e senha sao validos
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                // neste cenario, precisamos incluir no join a permissao, para que tenhamos acesso ao nome dela, e nao somente ao id
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
        public void Cadastrar(Usuarios usuario)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
        public List<Usuarios> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        public void Deletar(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Usuarios.Remove(ctx.Usuarios.Find(id));
                ctx.SaveChanges();
            }
        }
        public Usuarios BuscarPorId(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Usuarios.Find(id);
            }
        }
        public void Atualizar(Usuarios usuario)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);

                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Telefone = usuario.Telefone;
                usuarioBuscado.Cep = usuario.Cep;
                usuarioBuscado.Numero = usuario.Numero;
                usuarioBuscado.Permissao = usuario.Permissao;
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
