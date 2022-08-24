using EDOSwit.AbstraccionSP;
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
    public class MarcaRepository : IMarcaServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;

        public MensajeBE Anular(MarcaBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[gspMarcaAnular]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strMarcaId", SqlDbType.Char, 2).Value = BE.strMarcaId;
                        cmd.Parameters.Add("@strMarcaUsuAnul", SqlDbType.VarChar, 50).Value = BE.strMarcaUsuAnul;
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

        public List<MensajeBE> Guardar(MarcaBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspMarcaGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strMarcaId", SqlDbType.Char, 2).Value = BE.strMarcaId;
                    cmd.Parameters.Add("@strMarcaDesc", SqlDbType.VarChar, 50).Value = BE.strMarcaDesc;
                    cmd.Parameters.Add("@strMarcaUsuCre", SqlDbType.VarChar, 50).Value = BE.strMarcaUsuCre;
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

        public List<MarcaBE> Listar()
        {
            List<MarcaBE> lstData = new List<MarcaBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspMarcaListar", con))
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
                                    lstData.Add(new MarcaBE()
                                    {
                                        strMarcaId = dr["strMarcaId"].ToString(),
                                        strMarcaDesc = dr["strMarcaDesc"].ToString(),
                                    });
                                }
                            }
                        }
                        return lstData;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

    }
}
