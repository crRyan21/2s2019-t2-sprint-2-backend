using Microsoft.EntityFrameworkCore;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interfaces;
using Senai.Opflix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Opflix;User Id=sa;Pwd=132;";

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
        public List<Lancamentos> ListarPorData()
        {
            List<Lancamentos> lancamentos = new List<Lancamentos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT  IdLancamento,Nome,DataLancamento from Lancamentos order by DataLancamento desc";

                con.Open();

                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Lancamentos lancamento = new Lancamentos
                        {
                           IdLancamento = Convert.ToInt32(sdr["IdLancamento"]),
                            Nome = sdr["Nome"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            
                        };
                        lancamentos.Add(lancamento);
                    }
                }
            }
            return lancamentos;
        }
        public List<Lancamentos> FiltrarPorMidia()
        {
            List<Lancamentos> lancamentos = new List<Lancamentos>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "EXEC FiltrarPorMidia";

                con.Open();

                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Lancamentos lancamento = new Lancamentos
                        {
                            IdLancamento = Convert.ToInt32(sdr["IdLancamento"]),
                            Nome = sdr["Nome"].ToString(),
                            Plataformas = new Plataformas
                            {
                                IdPlataform = Convert.ToInt32(sdr["IdPlataform"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        
                        lancamentos.Add(lancamento);
                    }
                }
            }
            return lancamentos;
        }
        public void CadastrarFavorito(ListaFavoritos favorito)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                var IdUsuario = new SqlParameter("IdUsuario",favorito.IdUsuario);
                var IdLancamento = new SqlParameter("IdLancamento", favorito.IdLancamento);
              
                ctx.Database.ExecuteSqlCommand("EXEC prAdicionaFavorito @IdUsuario,@IdLancamento",
                   IdUsuario,IdLancamento);
            }
        }
        public List<ListaFavoritos> ListarFavoritos()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.ListaFavoritos.ToList();
            }
        }
        public ListaFavoritos BuscarFavoritoPorUsuario(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.ListaFavoritos.FirstOrDefault(x => x.Usuario.IdUsuario == id);
            }
        }


    }
}
