using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using(M_OptusContext ctx = new M_OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        public void Cadastrar(Estilos estilo)
        {
            using(M_OptusContext ctx = new M_OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }

        }
        public Estilos BuscarPorID(int id)
        {
            using (M_OptusContext ctx = new M_OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }

        }

        public void Atualizar(Estilos estilo)
        {
            using (M_OptusContext ctx = new M_OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);

                EstiloBuscado.Nome = estilo.Nome;

                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }

        }
        public void Deletar(int id)
        {
            using (M_OptusContext ctx = new M_OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.Find(id);

                ctx.Estilos.Remove(EstiloBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
