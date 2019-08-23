using Senai.Livros.Api.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Livros.Api.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";

        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos(Descricao) VALUES (@Descricao)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", genero.Descricao);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Descricao FROM Generos ORDER BY IdGenero ASC";

                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Descricao = rdr["Descricao"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
    }
}
