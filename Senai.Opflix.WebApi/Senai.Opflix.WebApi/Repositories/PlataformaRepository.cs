using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Cadastrar(Plataformas plataforma)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }
        }
        public List<Plataformas> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }
        public void Deletar(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Plataformas.Remove(ctx.Plataformas.Find(id));
                ctx.SaveChanges();
            }
        }
        public Plataformas BuscarPorId(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Plataformas.Find(id);
            }
        }
        public void Atualizar(Plataformas plataforma)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Plataformas plataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataform == plataforma.IdPlataform);

                plataformaBuscada.Nome = plataforma.Nome;
                ctx.Plataformas.Update(plataformaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
