using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class MenuRolRepository:IMenuRolRepository
    {

        private readonly Conexion _conexion;
        public MenuRolRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<MenuRol>> Lista(int idRol)
        {
            List<MenuRol> lista = new List<MenuRol>();

            using (var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_obtenerMenus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRol",   idRol);

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync()) 
                    {
                        lista.Add(new MenuRol {
                            NombreMenu  = dr["NombreMenu"].ToString()!,
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