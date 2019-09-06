using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }
        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
        public Pecas BuscarPecasPorFornecedor(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.FornecedorId == id);
            }
        }
        public Pecas BuscarPecasPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Find(id);
            }
        }

        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {

                Pecas pecaBuscada = ctx.Pecas.Find(peca.PecaId);
                pecaBuscada.Descricao = peca.Descricao;
                pecaBuscada.Peso = peca.Peso;
                pecaBuscada.PrecoCusto = peca.PrecoCusto;
                pecaBuscada.PrecoVenda = peca.PrecoVenda;
                ctx.Pecas.Update(pecaBuscada);
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Remove(ctx.Pecas.FirstOrDefault(x => x.PecaId == id));
                ctx.Pecas.Remove(ctx.Pecas.Find(id));
                ctx.SaveChanges();
            }
        }


    }
}
