using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
       
        public List<Estudios> Listar()
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Estudios.ToList();
            }
        }
        public List<Estudios> ListarComDados()
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }
        public void Cadastrar(Estudios estudio)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }
        
        public void Deletar(int id)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                ctx.Estudios.Remove(ctx.Estudios.Find(id));
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Estudios.Find(id);
            }
        }
        public Estudios ListarFuncionariosDoCargoPorNome(string nome)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Estudios.Include(x => x.NomeEstudio).FirstOrDefault(x => x.NomeEstudio == nome);
            }
        }
        public void Atualizar(Estudios estudio)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                Estudios estudios = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);
                
                estudios.NomeEstudio = estudio.NomeEstudio;
                estudios.PaisOrigem = estudio.PaisOrigem;
                estudios.DataCriacao = estudio.DataCriacao;
                estudios.UsuarioId = estudio.UsuarioId;
                ctx.Estudios.Update(estudios);
                ctx.SaveChanges();
            }
        }
        public Estudios BuscarPorNome(string nome)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Estudios.Find(nome);
            }
        }

    }
}
