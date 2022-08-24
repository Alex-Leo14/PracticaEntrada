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
    public class SubCategoriaRepository : ISubCategoriaServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;
        public MensajeBE Anular(SubCategoriaBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[gspSubCategoriaAnular]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strSubCategoriaId", SqlDbType.Char, 2).Value = BE.strSubCategoriaId;
                        cmd.Parameters.Add("@strSubCategoriaUsuAnul", SqlDbType.VarChar, 50).Value = BE.strSubCategoriaUsuAnul;
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

        public List<MensajeBE> Guardar(SubCategoriaBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspSubCategoriaGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strSubCategoriaId", SqlDbType.Char, 2).Value = BE.strSubCategoriaId;
                    cmd.Parameters.Add("@strSubCategoriaDesc", SqlDbType.VarChar, 50).Value = BE.strSubCategoriaDesc;
                    cmd.Parameters.Add("@strSubCategoriaUsuCre", SqlDbType.VarChar, 50).Value = BE.strSubCategoriaUsuCre;
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

        public List<SubCategoriaBE> Listar()
        {
            List<SubCategoriaBE> lstData = new List<SubCategoriaBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspSubCategoriaListar", con))
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
                                    lstData.Add(new SubCategoriaBE()
                                    {

                                        strSubCategoriaId = dr["strSubCategoriaId"].ToString(),
                                        strSubCategoriaDesc = dr["strSubCategoriaDesc"].ToString(),


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
