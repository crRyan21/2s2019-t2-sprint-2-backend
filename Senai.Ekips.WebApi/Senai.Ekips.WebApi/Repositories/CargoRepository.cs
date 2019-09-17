using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips;User Id=sa;Pwd=132;";

        public List<Cargos> Listar()
        {

            List<Cargos> cargos = new List<Cargos>();

            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT IdCargo, Nome,Ativo FROM Cargos ORDER BY Nome DESC";

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
                        Cargos cargo = new Cargos
                        {
                            IdCargo = Convert.ToInt32(rdr["IdCargo"]),
                            Nome = rdr["Nome"].ToString(),
                            Ativo = Convert.ToInt32(rdr["Ativo"])

                        };
                        cargos.Add(cargo);
                    }

                }

            }
            return cargos;
        }

        public Cargos BuscarPorId(int id)
        {
            string Query = "SELECT IdCargo, Nome, Ativo FROM Cargos WHERE IdCargo = @IdCargo";

            // aonde, em qual local
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCargo", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Cargos cargo = new Cargos
                            {
                                IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                                Nome = sdr["Nome"].ToString(),
                                Ativo = Convert.ToInt32(sdr["Ativo"])
                            };
                            return cargo;
                        }
                    }
                    return null;
                }
            }
        }
        public void Cadastrar(Cargos cargo)
        {
            string Query = "INSERT INTO Cargos(Nome) VALUES (@Nome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", cargo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(Cargos cargo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE Cargos SET Nome = @Nome WHERE IdCargo = @IdCargo";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdCargo", cargo.IdCargo);
                cmd.Parameters.AddWithValue("@Nome", cargo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
    }
}
