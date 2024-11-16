using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly Conexion _conexion;
        public ProductoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Producto>> Lista(string buscar = "")
        {
            List<Producto> lista = new List<Producto>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_listaProducto",conn);
                cmd.Parameters.AddWithValue("@Buscar",buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new Producto{
                            IdProducto   = Convert.ToInt32(dr["IdProducto"]),
                            RefCategoria = new Categoria{
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Nombre      = dr["NombreCategoria"].ToString()
                            },
                            Codigo       = dr["Codigo"].ToString(),
                            Descripcion  = dr["Descripcion"].ToString(),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                            PrecioVenta  = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad     = Convert.ToInt32(dr["Cantidad"]),
                            Activo       = Convert.ToInt32(dr["Activo"])
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Crear(Producto modelo)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_crearProducto",conn);

                cmd.Parameters.AddWithValue("@Codigo",      modelo.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra",modelo.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", modelo.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad",    modelo.Cantidad);
                cmd.Parameters.AddWithValue("@IdCategoria", modelo.RefCategoria!.IdCategoria);
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

        public async Task<string> Editar(Producto modelo)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_editarProducto",conn);

                cmd.Parameters.AddWithValue("@IdProducto",  modelo.IdProducto);
                cmd.Parameters.AddWithValue("@Codigo",      modelo.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra",modelo.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", modelo.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad",    modelo.Cantidad);
                cmd.Parameters.AddWithValue("@IdCategoria", modelo.RefCategoria!.IdCategoria);
                cmd.Parameters.AddWithValue("@Activo",      modelo.Activo);
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