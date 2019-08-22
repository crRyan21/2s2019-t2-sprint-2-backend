using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= M_RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();
            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT IdGenero,Nome FROM Generos ORDER BY IdGenero ASC";

                // abre a conexao com o bd
                con.Open();
                // declaro para percorrer a lista
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            // devolver a lista preenchida
            return generos;
        }

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos(Nome) VALUES(@Nome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                //abre a conexão
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos Set Nome = @Nome Where IdGenero = @idGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero,Nome FROM Generos WHERE IdGenero = @IdGenero";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if(sdr.HasRows){
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                return null;
                }
            }
        }
        

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

