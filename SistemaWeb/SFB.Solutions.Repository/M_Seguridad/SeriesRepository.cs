using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Seguridad;
using SFB.Solutions.Helpers;
using SFB.Solutions.Sevices.M_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Repository.M_Seguridad
{
   
    public class SeriesRepository : ISeriesServices
    {
        private List<MensajeBE> ListMsj;

        private MensajeBE objEntMsj;
        public MensajeBE Anular(SeriesBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspSeriesAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                        cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                        cmd.Parameters.Add("@strTipoDocID", SqlDbType.Char, 2).Value = BE.strTipoDocID;
                        cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;

                        cmd.Parameters.Add("@strTipoDocUsuAnul", SqlDbType.VarChar, 50).Value = BE.strTipoDocUsuAnul;
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

        public List<MensajeBE> Guardar(SeriesBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspSeriesGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;
                    cmd.Parameters.Add("@strTipoDocID", SqlDbType.Char, 2).Value = BE.strTipoDocID;

                    cmd.Parameters.Add("@strSerDoc1", SqlDbType.Char, 4).Value = BE.strSerDoc1;
                    cmd.Parameters.Add("@strSerDoc2", SqlDbType.Char, 4).Value = BE.strSerDoc2;

                    cmd.Parameters.Add("@decNumero", SqlDbType.Int).Value = BE.decNumero;
                    cmd.Parameters.Add("@strSerieMaq", SqlDbType.VarChar, 50).Value = BE.strSerieMaq;

                    cmd.Parameters.Add("@strNumCaja", SqlDbType.Char, 2).Value = BE.strNumCaja;

                    cmd.Parameters.Add("@strTipoDocUsuCre", SqlDbType.VarChar, 50).Value = BE.strTipoDocUsuCre;




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

        public List<SeriesBE> Listar(SeriesBE BE)
        {
            List<SeriesBE> lstData = new List<SeriesBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspSeriesListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;

                    con.Open();

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    lstData.Add(new SeriesBE()
                                    {
                                        strDominioID = dr["strDominioID"].ToString(),
                                        strLocalID = dr["strLocalID"].ToString(),
                                        strTipoDocID = dr["strTipoDocID"].ToString(),
                                        strModuloID = dr["strModuloID"].ToString(),
                                        strSerDoc1 = dr["strSerDoc1"].ToString(),
                                        strSerDoc2 = dr["strSerDoc2"].ToString(),
                                        decNumero = Convert.ToInt32(dr["decNumero"]),
                                        strSerieMaq = dr["strSerieMaq"].ToString(),
                                        strNumCaja = dr["strNumCaja"].ToString(),

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
