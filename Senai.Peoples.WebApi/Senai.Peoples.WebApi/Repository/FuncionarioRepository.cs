using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Peoples;User Id=sa;Pwd=132;";

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            string Query = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES(@Nome,@Sobrenome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //declara o comando com  a Query e a conexão
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                // abre a conexão
                con.Open();
                // executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT IdFuncionario,Nome,Sobrenome FROM Funcionarios ORDER BY IdFuncionario ASC";

                // abre a conexao com o bd
                con.Open();
                // declaro para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a Query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            // devolver a lista preenchida
            return funcionarios;

        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario, Nome,Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if ( sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;

                        }
                    }
                    return null;
                }
            }
        }

        public void Alterar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @IdFuncionario";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //faço o comando
                SqlCommand cmd = new SqlCommand(Query, con);
                //defino os parametros

                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);

                //abrir a conexao
                con.Open();
                //executar

                cmd.ExecuteNonQuery();
            }
        }
        public void AlterarDataNascimento(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET DataNascimento = @DataNascimento WHERE IdFuncionario =@IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionarioDomain.DataNascimento.Date);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario =@IdFuncionario";
            //conexão
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando 
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                //executar
                cmd.ExecuteNonQuery();
            }
        }
    }      
}
