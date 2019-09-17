using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips;User Id=sa;Pwd=132;";

        public List<Funcionarios> Listar()
        {

            List<Funcionarios> funcionarios = new List<Funcionarios>();

            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT Funcionarios.Nome,Funcionarios.IdFuncionario,Funcionarios.CPF,Funcionarios.DataNascimento,Funcionarios.IdDepartamento,Funcionarios.IdCargo,Funcionarios.Salario,Usuarios.IdUsuario,Usuarios.Email,Usuarios.Senha,Usuarios.IdPermissao,Departamentos.IdDepartamento,Departamentos.Nome,Cargos.IdCargo,Cargos.Nome,Cargos.Ativo,Permissao.IdPermissao,Permissao.Nome FROM Funcionarios JOIN Usuarios ON Funcionarios.IdUsuario = Usuarios.IdUsuario JOIN Departamentos ON Funcionarios.IdDepartamento = Departamentos.IdDepartamento JOIN Cargos ON Funcionarios.IdCargo = Cargos.IdCargo JOIN Permissao ON Usuarios.IdPermissao = Permissao.IdPermissao";
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
                        Funcionarios funcionario = new Funcionarios
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Cpf = rdr["CPF"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]),
                            Salario = Convert.ToDouble(rdr["Salario"]),
                            IdDepartamentoNavigation = new Departamentos
                           {
                               IdDepartamento = Convert.ToInt32(rdr["IdDepartamento"]),
                               Nome = rdr["Nome"].ToString()
                           },
                            IdCargoNavigation = new Cargos
                            {
                                IdCargo = Convert.ToInt32(rdr["IdCargo"]),
                                Nome = rdr["Nome"].ToString(),
                                Ativo = Convert.ToInt32(rdr["Ativo"])
                               
                            },
                            IdUsuarioNavigation = new Usuarios
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = rdr["Email"].ToString()
                                
                            },
                            IdPermissaoNavigation = new Permissao
                            {
                                IdPermissao = Convert.ToInt32(rdr["IdPermissao"]),
                                Nome = rdr["Nome"].ToString()
                            }

                        };
                        funcionarios.Add(funcionario);
                    }

                }

            }

            // devolver a lista preenchida
            return funcionarios;
        }

        public void Cadastrar(Funcionarios funcionario)
        {
            string Query = "INSERT INTO Funcionarios(Nome, Cpf, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario) VALUES (@Nome, @Cpf, @DataNascimento, @Salario, @IdDepartamento, @IdCargo, @IdUsuario)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento.Date);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", funcionario.IdDepartamento);
                cmd.Parameters.AddWithValue("@IdCargo", funcionario.IdCargo);
                cmd.Parameters.AddWithValue("@IdUsuario", funcionario.IdUsuario); 
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(Funcionarios funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @IdFuncionario";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.IdFuncionario);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
            // conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                // executar
                cmd.ExecuteNonQuery();
            }
        }
    }
}
