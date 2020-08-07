using Data.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DPaisesSeguidores
    {
        Conection connectionString = new Conection();
        public List<ListPaisSeguidos> return_follower_countries()
        {
            try
            {
                var listPaisSeguidos = new List<ListPaisSeguidos>();
                var salidaConsulta = new DataTable();
                var List = new ListPaisSeguidos();

                using (SqlConnection connection = new SqlConnection(connectionString.GetConnectionString()))
                {
                    connection.Open();
                    var cmd = new SqlCommand("return_follower_countries", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TRANS", "0");

                    SqlDataReader dr = cmd.ExecuteReader();
                    salidaConsulta.Load(dr);

                    for (int i = 0; i < salidaConsulta.Rows.Count; i++)
                    {
                        List = new ListPaisSeguidos();

                        List.id_Pais = Convert.ToInt32(salidaConsulta.Rows[i]["id_Pais"]);
                        List.ruta_logo = salidaConsulta.Rows[i]["ruta_logo"].ToString();
                        List.nombre = salidaConsulta.Rows[i]["nombre"].ToString();
                        List.Publicaciones = Convert.ToInt32(salidaConsulta.Rows[i]["Publicaciones"]);
                        List.Seguidores = Convert.ToInt32(salidaConsulta.Rows[i]["Seguidores"]);

                        listPaisSeguidos.Add(List);
                    }
                    return listPaisSeguidos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
