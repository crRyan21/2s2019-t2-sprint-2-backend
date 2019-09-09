using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }
        public List<Lancamentos> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }
        public void Deletar(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Lancamentos.Remove(ctx.Lancamentos.Find(id));
                ctx.SaveChanges();
            }
        }
        public Lancamentos BuscarPorId(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Lancamentos.Find(id);
            }
        }
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Lancamentos lancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);

                lancamentoBuscado.Nome = lancamento.Nome;
                lancamentoBuscado.IdTipoTitulo = lancamento.IdTipoTitulo;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                lancamentoBuscado.Duracao = lancamento.Duracao;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;
                lancamentoBuscado.IdPlataform = lancamento.IdPlataform;
                ctx.Lancamentos.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
