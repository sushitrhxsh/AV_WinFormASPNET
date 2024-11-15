using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class NegocioRepository : INegocioRepository
    {

        private readonly Conexion _conexion;
        public NegocioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<Negocio> Obtener()
        {
            Negocio lista = new Negocio();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_obtenerNegocio",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    if(await dr.ReadAsync())
                    {
                        lista = new Negocio(){
                            RazonSocial   = dr["RazonSocial"].ToString(),
                            RFC           = dr["RFC"].ToString(),
                            Direccion     = dr["Direccion"].ToString(),
                            NumCelular    = dr["NumCelular"].ToString(),
                            Correo        = dr["Correo"].ToString(),
                            SimboloMoneda = dr["SimboloMoneda"].ToString(),
                            NombreLogo    = dr["NombreLogo"].ToString(),
                            UrlLogo       = dr["UrlLogo"].ToString()
                        };
                    }
                }
            }
            return lista;
        }

        public async Task Editar(Negocio modelo)
        {
            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_editarNegocio",conn);      

                cmd.Parameters.AddWithValue("@RazonSocial",     modelo.RazonSocial);
                cmd.Parameters.AddWithValue("@RFC",             modelo.RFC);
                cmd.Parameters.AddWithValue("@Direccion",       modelo.Direccion);
                cmd.Parameters.AddWithValue("@Correo",          modelo.Correo);
                cmd.Parameters.AddWithValue("@NumCelular",      modelo.NumCelular);
                cmd.Parameters.AddWithValue("@SimboloMoneda",   modelo.SimboloMoneda);
                cmd.Parameters.AddWithValue("@NombreLogo",      modelo.NombreLogo);
                cmd.Parameters.AddWithValue("@UrlLogo",         modelo.UrlLogo);

                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                   
                } catch {
                   throw;
                }
            }
        } 

    }
}