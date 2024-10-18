using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly Conexion _conexion;
        public CategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Categoria>> Lista(string buscar = "")
        {
            List<Categoria> lista = new List<Categoria>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_listaCategoria",conn);
                cmd.Parameters.AddWithValue("@Buscar",buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new Categoria{
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            Nombre = dr["Nombre"].ToString(),
                            Activo = Convert.ToInt32(dr["Valor"]),
                            RefMedida = new Medida{
                                IdMedida = Convert.ToInt32(dr["IdMedida"]),
                                Nombre = dr["NombreMedida"].ToString()
                            }
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Crear(Categoria modelo)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_crearCategoria",conn);

                cmd.Parameters.AddWithValue("@Nombre",modelo.Nombre);
                cmd.Parameters.AddWithValue("@IdMedida",modelo.RefMedida.IdMedida);
                cmd.Parameters.Add("@MsjError",SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                    response = Convert.ToString(cmd.Parameters["@MsjError"].Value);
                } catch {
                    response = "Error(rp): No se pudo procesar";
                }
            }
            return response;
        }

        public async Task<string> Editar(Categoria modelo)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_editarCategoria",conn);

                cmd.Parameters.AddWithValue("@IdCategoria",modelo.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre",modelo.Nombre);
                cmd.Parameters.AddWithValue("@IdMedida",modelo.RefMedida.IdMedida);
                cmd.Parameters.AddWithValue("@Activo",modelo.Activo);
                cmd.Parameters.Add("@MsjError",SqlDbType.VarChar,100).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                    response = Convert.ToString(cmd.Parameters["@MsjError"].Value);
                } catch {
                    response = "Error(rp): No se pudo procesar";
                }
            }
            return response;
        }

    }
}