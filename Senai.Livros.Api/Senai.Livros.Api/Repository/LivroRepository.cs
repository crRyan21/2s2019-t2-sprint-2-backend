using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Senai.Livros.Api.Domains;


namespace Senai.Livros.Api.Repository
{
    public class LivroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";

        public void Cadastrar(LivroDomain livro)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Livros(Descricao,IdAutor,IdGenero) VALUES (@Descricao,@IdAutor,@IdGenero)";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", livro.Descricao);
                cmd.Parameters.AddWithValue("@IdAutor", livro.AutorId);
                cmd.Parameters.AddWithValue("@IdGenero", livro.GeneroId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<LivroDomain> Listar()
        {
            List<LivroDomain> livros = new List<LivroDomain>();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT Livros.IdLivro,Livros.Descricao,Livros.IdAutor,Autores.Nome,Livros.IdGenero,Generos.Descricao FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        LivroDomain livro = new LivroDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Descricao = sdr["Descricao"].ToString(),
                            Autor = new AutorDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = sdr["Nome"].ToString(),
                            },
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Descricao = sdr["Descricao"].ToString()
                           }
                        };
                        livros.Add(livro);
                    }
                }
            }return livros;
        }

        public void Deletar(int id)
        {
            string Query = "Delete From Livros WHERE IdLivro = @IdLivro";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("IdLivro", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Alterar(LivroDomain livro)
        {
            string Query = "Update Livros Set Descricao = @Descricao WHERE IdLivro = @IdLivro";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Descricao", livro.Descricao);
                cmd.Parameters.AddWithValue("IdLivro", livro.IdLivro);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
