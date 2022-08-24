using Canvia_DTO;
using Canvia_Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Canvia_Repository
{
    public class ProductoRepository : IProductoServices
    {
        private readonly IOptions<ConnectionRepository> cnx;
        public ProductoRepository(IOptions<ConnectionRepository> conexion)
        {
            cnx = conexion;
        }
        public bool Actualizar(Producto_DTO BE)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(cnx.Value.conexionLocal))
            {
                using (SqlCommand cmd = new SqlCommand("usp_prod_actualizar", cn))
                {
                    cn.Open();
                    try
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intProductoId", SqlDbType.Int).Value = BE.intProductoId;
                        cmd.Parameters.Add("@strProductoDesc", SqlDbType.VarChar, 50).Value = BE.strProductoDesc;
                        cmd.Parameters.Add("@intCantidad", SqlDbType.Int).Value = BE.intCantidad;
                        cmd.Parameters.Add("@decPrecio", SqlDbType.Decimal).Value = BE.decPrecio;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                    }

                }
            }
            return result;
        }
        public bool Eliminar(int intProductoId)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(cnx.Value.conexionLocal))
            {
                using (SqlCommand cmd = new SqlCommand("usp_prod_eliminar", cn))
                {
                    cn.Open();
                    try
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intProductoId", SqlDbType.Int).Value = intProductoId;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                    }

                }
            }
            return result;
        }     
        public bool Insertar(Producto_DTO BE)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(cnx.Value.conexionLocal))
            {
                using (SqlCommand cmd = new SqlCommand("usp_prod_insert", cn))
                {
                    cn.Open();
                    try
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strProductoDesc", SqlDbType.VarChar, 50).Value = BE.strProductoDesc;
                        cmd.Parameters.Add("@intCantidad", SqlDbType.Int).Value = BE.intCantidad;
                        cmd.Parameters.Add("@decPrecio", SqlDbType.Decimal).Value = BE.decPrecio;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                    }

                }
            }
            return result;
        }
        public List<Producto_DTO> Listar()
        {
            List<Producto_DTO> lista = new List<Producto_DTO>();
            using (SqlConnection cn = new SqlConnection(cnx.Value.conexionLocal))
            {
                using (SqlCommand cmd = new SqlCommand("usp_prod_listar", cn))
                {
                    try
                    {
                        cn.Open();
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Producto_DTO()
                                {
                                    intProductoId = Convert.ToInt32(dr["intProductoId"].ToString()),
                                    strProductoDesc = dr["strProductoDesc"].ToString(),
                                    intCantidad = Convert.ToInt32(dr["intCantidad"].ToString()),
                                    decPrecio = Convert.ToDecimal(dr["decPrecio"].ToString()),
                                    //bitEstado = Convert.ToBoolean(dr["bitEstado"].ToString()),

                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        cn.Dispose();
                        cmd.Dispose();
                    }
                }
            }
            return lista; throw new NotImplementedException();
        }
    }
}
