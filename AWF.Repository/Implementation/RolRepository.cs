using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class RolRepository : IRolRepository
    {

        private readonly Conexion _conexion;
        public RolRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Rol>> Lista()
        {
            List<Rol> lista = new List<Rol>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_listaRol",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new Rol {
                            IdRol   = Convert.ToInt32(dr["IdRol"]),
                            Nombre  = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

    }
}