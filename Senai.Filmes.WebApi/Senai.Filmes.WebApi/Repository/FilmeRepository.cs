using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= M_RoteiroFilmes;User Id=sa;Pwd=132;";
        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT Filmes.Titulo,Filmes.IdFilme,Filmes.IdGenero,Generos.Nome,Generos.IdGenero FROM Filmes JOIN Generos ON Filmes.IdGenero = Generos.IdGenero ";

                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        filmes.Add(filme);
                    }
                }
            } return filmes;

        }

        public void Cadastrar(FilmeDomain filme)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Filmes(Titulo,IdGenero) VALUES = (@Titulo,@IdGenero)";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filme.GeneroId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    } }
