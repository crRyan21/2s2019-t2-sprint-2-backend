using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Jogos.ToList();
            }
        }
        public void Cadastrar(Jogos jogos)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                ctx.Jogos.Add(jogos);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogos jogo)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                Jogos jogos = ctx.Jogos.FirstOrDefault(x => x.EstudioId == jogo.EstudioId);

                jogos.NomeJogo = jogo.NomeJogo;
                jogos.Descricao = jogo.Descricao;
                jogos.DataLancamento = jogo.DataLancamento;
                jogos.Valor = jogo.Valor;
                jogos.EstudioId = jogo.EstudioId;
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }
        public List<Jogos> ListarPorData()
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Jogos.OrderBy(x => x.DataLancamento).ToList();
            }
        }
        public void Deletar(int id)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                ctx.Jogos.Remove(ctx.Jogos.Find(id));
                ctx.SaveChanges();
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Jogos.Find(id);
            }
        }
        public Jogos BuscarPorNome(string nome)
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Jogos.Find(nome);
            }
        }


        public List<Jogos> ListarPorValor()
        {
            using (InLock_Context ctx = new InLock_Context())
            {
                return ctx.Jogos.OrderBy(x => x.Valor).ToList();

            }
        }



    }
}
