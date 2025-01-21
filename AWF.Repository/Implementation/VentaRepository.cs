using System.Data;
using AWF.Repository.DB;
using AWF.Repository.Entities;
using AWF.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace AWF.Repository.Implementation
{
    public class VentaRepository : IVentaRepository
    {

        private readonly Conexion _conexion;
        public VentaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<string> Registrar(string ventaXml)
        {
            string response = "";

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_registrarVenta",conn);

                cmd.Parameters.AddWithValue("@Ventaxml", ventaXml);
                cmd.Parameters.Add("@NumeroVenta",SqlDbType.VarChar,10).Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await cmd.ExecuteNonQueryAsync();
                    response = Convert.ToString(cmd.Parameters["@NumeroVenta"].Value)!;

                } catch {
                    response = "Error(rp): No se pudo procesar";
                }
            }
            return response;
        }

        public async Task<Venta> Obtener(string numeroVenta)
        {
            Venta objeto = new Venta();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_obtenerVenta",conn);
                cmd.Parameters.AddWithValue("@NumeroVenta",numeroVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    if(await dr.ReadAsync())
                        objeto = new Venta {
                            IdVenta         = Convert.ToInt32(dr["IdVenta"]),
                            NumeroVenta     = dr["NumeroVenta"].ToString(),
                            UsuarioRegistro = new Usuario {
                                NombreUsuario = dr["NombreUsuario"].ToString()
                            },
                            NombreCliente   = dr["NombreUsuario"].ToString(),
                            PrecioTotal     = Convert.ToDecimal(dr["PrecioTotal"]),
                            PagoCon         = Convert.ToDecimal(dr["PagoCon"]),
                            Cambio          = Convert.ToDecimal(dr["Cambio"]),
                            FechaRegistro   = dr["FechaRegistro"].ToString()
                        };
                }
            }
            return objeto;
        }

        public async Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_obtenerDetalleVenta",conn);
                cmd.Parameters.AddWithValue("@NumeroVenta",numeroVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new DetalleVenta {
                            RefProducto   = new Producto {
                                Descripcion =  dr["Descripcion"].ToString(),
                                RefCategoria = new Categoria {
                                    RefMedida = new Medida {
                                        Abreviatura = dr["Abreviatura"].ToString(),
                                        Valor       = Convert.ToInt32(dr["Valor"])
                                    }
                                }
                            },
                            Cantidad    = Convert.ToInt32(dr["Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            PrecioTotal = Convert.ToInt32(dr["PrecioTotal"])
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<List<Venta>> Lista(string fechaInicio, string fechaFin, string buscar)
        {
            List<Venta> lista = new List<Venta>();

            using(var conn = _conexion.ObtenerSQLConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("sp_listaVenta",conn);
                cmd.Parameters.AddWithValue("@FechaInicio",fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin",fechaFin);
                cmd.Parameters.AddWithValue("@Buscar",buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync())
                    {
                        lista.Add(new Venta {
                            NumeroVenta   = dr["NumeroVenta"].ToString(),
                            UsuarioRegistro = new Usuario {
                                NombreUsuario = dr["NombreUsuario"].ToString()
                            },
                            NombreCliente = dr["NombreCliente"].ToString(),
                            PrecioTotal   = Convert.ToDecimal(dr["PrecioTotal"]),
                            PagoCon       = Convert.ToDecimal(dr["PagoCon"]),
                            Cambio        = Convert.ToDecimal(dr["Cambio"]),
                            FechaRegistro = dr["FechaRegistro"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

    }
}