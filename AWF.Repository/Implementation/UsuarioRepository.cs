using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Conexion _conexion;
        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Usuario>> Lista(string buscar = "")
        {
             List<Usuario> lista = new List<Usuario>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_listaUsuario",conn);
                cmd.Parameters.AddWithValue("@Buscar",buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new Usuario{
                            IdUsuario       = Convert.ToInt32(dr["IdUsuario"]),
                            RefRol = new Rol{
                                IdRol   = Convert.ToInt32(dr["IdRol"]),
                                Nombre  = dr["NombreRol"].ToString()
                            },
                            NombreCompleto  = dr["NombreCompleto"].ToString(),
                            Correo          = dr["Correo"].ToString(),
                            NombreUsuario   = dr["NombreUsuario"].ToString(),
                            Activo          = Convert.ToInt32(dr["Activo"]), 
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Crear(Usuario modelo)
        {
             string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_crearUsuario",conn);

                cmd.Parameters.AddWithValue("@IdRol",          modelo.RefRol!.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto",  modelo.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo",          modelo.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario",   modelo.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave",           modelo.Clave);
                cmd.Parameters.Add("@MsjError",SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                    response = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;

                } catch {
                    response = "Error(rp): No se pudo procesar";
                }
            }
            return response;
        }

        public async Task<string> Editar(Usuario modelo)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_editarUsuario",conn);

                cmd.Parameters.AddWithValue("@IdUsuario",       modelo.IdUsuario);
                cmd.Parameters.AddWithValue("@IdRol",           modelo.RefRol!.IdRol);
                cmd.Parameters.AddWithValue("@NombreCompleto",  modelo.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo",          modelo.Correo);
                cmd.Parameters.AddWithValue("@NombreUsuario",   modelo.NombreUsuario);
                cmd.Parameters.AddWithValue("@Activo",          modelo.Activo);
                cmd.Parameters.Add("@MsjError",SqlDbType.VarChar,100).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                    response = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                    
                } catch {
                    response = "Error(rp): No se pudo procesar";
                }
            }
            return response;
        }

    }
}