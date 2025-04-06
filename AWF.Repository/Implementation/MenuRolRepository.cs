using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class MenuRolRepository
    {

        private readonly Conexion _conexion;
        public MenuRolRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<MenuRol>> Lista(int idMenu, int idRol)
        {
            List<MenuRol> lista = new List<MenuRol>();

            using (var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_obtenerMenus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMenu",  idMenu);
                cmd.Parameters.AddWithValue("@idRol",   idRol);

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync()) {
                        lista.Add(new MenuRol {
                            NombreMenu  = Convert.ToString(dr["NombreMenu"]),
                            IdMenuPadre = Convert.ToInt32(dr["IdMenuPadre"]),
                            Activo      = Convert.ToBoolean(dr["Activo"]),
                        });
                    }
                }
            }
            return lista;
        }  
        
    }
}