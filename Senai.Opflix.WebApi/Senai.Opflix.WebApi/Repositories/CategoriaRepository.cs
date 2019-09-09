using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Cadastrar(Categorias categoria)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }
        public List<Categorias> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categorias.ToList();
            }
        }
        public void Deletar(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Categorias.Remove(ctx.Categorias.Find(id));
                ctx.SaveChanges();
            }
        }
        public Categorias BuscarPorId(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categorias.Find(id);
            }
        }
        public void Atualizar(Categorias categoria)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);

                categoriaBuscada.Nome = categoria.Nome;
                ctx.Categorias.Update(categoriaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
