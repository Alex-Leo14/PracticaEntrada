using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Almacen;
using SFB.Solutions.Helpers;
using SFB.Solutions.Sevices.M_Almacen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Repository.M_Almacen
{
    public class ProductoRepository : IProductoServices
    {


        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;

        public MensajeBE Anular(ProductoBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspProductoAnular", con))
                    {   
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strProductoId", SqlDbType.Char, 10).Value = BE.strProductoId;
                        cmd.Parameters.Add("@strProductoUsuAnul", SqlDbType.VarChar, 50).Value = BE.strProductoUsuAnul;
                        con.Open();

                        try
                        {
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {   
                                        objEntMsj = new MensajeBE();
                                        objEntMsj.MENSAJE = dr["MENSAJE"].ToString();
                                    }
                                }
                            }
                            return objEntMsj;
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MensajeBE> Guardar(ProductoBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection
                (AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspProductoGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strProductoId", SqlDbType.Char, 10).Value = BE.strProductoId;
                    //cmd.Parameters.Add("@strProductoItem", SqlDbType.Char, 3).Value = BE.strProductoItem;
                    cmd.Parameters.Add("@strMarcaId", SqlDbType.Char, 2).Value = BE.strMarcaId;
                    cmd.Parameters.Add("@strCategoriaId", SqlDbType.Char, 2).Value = BE.strCategoriaId;
                    cmd.Parameters.Add("@strSubCategoriaId", SqlDbType.Char, 3).Value = BE.strSubCategoriaId;
                    cmd.Parameters.Add("@decPrecioCosto", SqlDbType.Decimal).Value = BE.decPrecioCosto;
                    cmd.Parameters.Add("@decPrecioxMayor", SqlDbType.Decimal).Value = BE.decPrecioxMayor;
                    cmd.Parameters.Add("@decPrecioxMenor", SqlDbType.Decimal).Value = BE.decPrecioxMenor;
                    cmd.Parameters.Add("@decPrecioOferta", SqlDbType.Decimal).Value = BE.decPrecioOferta;
                    cmd.Parameters.Add("@strCodigoAlterno1", SqlDbType.Char, 10).Value = BE.strCodigoAlterno1;
                    cmd.Parameters.Add("@strCodigoAlterno2", SqlDbType.Char, 10).Value = BE.strCodigoAlterno2;
                    cmd.Parameters.Add("@strProductoDesc", SqlDbType.VarChar, 50).Value = BE.strProductoDesc;
                    cmd.Parameters.Add("@decPrecioVenta", SqlDbType.Decimal).Value = BE.decPrecioVenta;
                    cmd.Parameters.Add("@strCodigoBarras", SqlDbType.Char, 10).Value = BE.strCodigoBarras;
                    cmd.Parameters.Add("@strProductoUsuCre", SqlDbType.VarChar, 50).Value = BE.strProductoUsuCre;

                    con.Open();

                    try
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                ListMsj.Add(new MensajeBE()
                                {
                                    MENSAJE = rdr["MENSAJE"].ToString()
                                });
                            }
                        }
                        return ListMsj;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open) { con.Close(); con.Dispose(); }
                        cmd.Dispose();
                    }
                }
            }


        }
        public List<ProductoBE> Listar()
        {
            List<ProductoBE> lstData = new List<ProductoBE>();
            
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspProductoListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    lstData.Add(new ProductoBE()
                                    {
                                        strProductoId = dr["strProductoId"].ToString(),
                                        //strProductoItem = dr["strProductoItem"].ToString(),
                                        strMarcaId = dr["strMarcaId"].ToString(),
                                        strCategoriaId = dr["strCategoriaId"].ToString(),
                                        strSubCategoriaId = dr["strSubCategoriaId"].ToString(),
                                        decPrecioCosto = Convert.ToDecimal( dr["decPrecioCosto"].ToString()),
                                        decPrecioxMayor = Convert.ToDecimal(dr["decPrecioxMayor"].ToString()),
                                        decPrecioxMenor = Convert.ToDecimal(dr["decPrecioxMenor"].ToString()),
                                        decPrecioOferta = Convert.ToDecimal(dr["decPrecioOferta"].ToString()),
                                        strCodigoAlterno1 = dr["strCodigoAlterno1"].ToString(),
                                        strCodigoAlterno2 = dr["strCodigoAlterno2"].ToString(),

                                        strProductoDesc = dr["strProductoDesc"].ToString(),
                                        decPrecioVenta = Convert.ToDecimal(dr["decPrecioVenta"].ToString()),
                                        strCodigoBarras = dr["strCodigoBarras"].ToString(),
                                        //strProductoEstado = dr["strProductoEstado"].ToString(),
                                    });
                                }
                            }
                        }
                        return lstData;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

            
        }

        
    }
}

 