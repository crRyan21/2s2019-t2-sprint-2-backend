using Senai.Livros.Api.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Livros.Api.Repository
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";

        public void Cadastrar(AutorDomain autor)
        {
            string Query = "INSERT INTO Autores(Nome, Email, DataNascimento) VALUES(@Nome,@Email,@DataNascimento)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Email", autor.Email);
                cmd.Parameters.AddWithValue("@DataNascimento",autor.DataNascimento.Date);
                con.Open();
                cmd.ExecuteNonQuery();


            }
        }

        public List<AutorDomain> Listar()
        {
            List<AutorDomain> autores = new List<AutorDomain>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdAutor,Nome,Email,Ativo As Status,DataNascimento FROM Autores";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        AutorDomain autor = new AutorDomain
                        {
                            IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Status = Convert.ToInt32(rdr["Status"]),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };
                        autores.Add(autor);
                    }
                }
            }
            return autores;
        }
    }
}
