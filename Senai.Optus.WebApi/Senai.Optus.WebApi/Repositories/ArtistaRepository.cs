using Microsoft.EntityFrameworkCore;
using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        public List<Artistas> Listar()
        {
            using (M_OptusContext ctx = new M_OptusContext())
            {
                return ctx.Artistas.Include(x => x.IdEstiloNavigation).ToList();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artista"></param>
        public void Cadastrar(Artistas artista)
        {
            using (M_OptusContext ctx = new M_OptusContext())
            {
                ctx.Artistas.Add(artista);
                ctx.SaveChanges();
            }

        }
    }
}
