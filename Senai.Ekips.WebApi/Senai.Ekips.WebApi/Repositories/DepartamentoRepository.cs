using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips;User Id=sa;Pwd=132;";


        public List<Departamentos> Listar()
        {

            List<Departamentos> departamentos = new List<Departamentos>();

            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT IdDepartamento, Nome FROM Departamentos ORDER BY Nome DESC";

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
                        Departamentos departamento = new Departamentos
                        {
                            IdDepartamento = Convert.ToInt32(rdr["IdDepartamento"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        departamentos.Add(departamento);
                    }

                }

            }

            // devolver a lista preenchida
            return departamentos;
        }
        public void Cadastrar(Departamentos departamento)
        {
            string Query = "INSERT INTO Departamentos(Nome) VALUES (@Nome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", departamento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Departamentos BuscarPorId(int id)
        {
            string Query = "SELECT IdDepartamento, Nome FROM Departamentos WHERE IdDepartamento = @IdDepartamento";

            // aonde, em qual local
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdDepartamento", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Departamentos departamento = new Departamentos
                            {
                                IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return departamento;
                        }
                    }
                    return null;
                }
            }

        }
    }
}
