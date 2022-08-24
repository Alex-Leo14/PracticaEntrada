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
    public class TDocumentoRepository : ITDocumentoServices
    {
        private List<MensajeBE> ListMsj;

        private MensajeBE objEntMsj;
        public MensajeBE Anular(TDocumentoBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspTDocumentoAnular", con))
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

        public List<MensajeBE> Guardar(TDocumentoBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTDocumentoGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;
                    cmd.Parameters.Add("@strTipoDocID", SqlDbType.Char, 2).Value = BE.strTipoDocID;

                    cmd.Parameters.Add("@strTipoDocName", SqlDbType.VarChar, 40).Value = BE.strTipoDocName;
                    //cmd.Parameters.Add("@bitTipoDocManejaSerie", SqlDbType.Bit).Value = BE.bitTipoDocManejaSerie;
                    cmd.Parameters.Add("@decTipoDocNumero", SqlDbType.Decimal).Value = BE.decTipoDocNumero;

                    cmd.Parameters.Add("@strTipoDocContraTipo", SqlDbType.Char,2).Value = BE.strTipoDocContraTipo;
                    //cmd.Parameters.Add("@bitVisibleAlmac", SqlDbType.Bit).Value = BE.bitVisibleAlmac;
                    //cmd.Parameters.Add("@bitAfectasStock", SqlDbType.Bit).Value = BE.bitAfectasStock;
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

        public List<TDocumentoBE> Listar(TDocumentoBE BE)
        {
            List<TDocumentoBE> lstData = new List<TDocumentoBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTDocumentoListar", con))
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
                                    lstData.Add(new TDocumentoBE()
                                    {
                                        strDominioID = dr["strDominioID"].ToString(),
                                        strLocalID = dr["strLocalID"].ToString(),
                                        strTipoDocID = dr["strTipoDocID"].ToString(),
                                        strModuloID = dr["strModuloID"].ToString(),
                                        strTipoDocName = dr["strTipoDocName"].ToString(),
                                       // bitTipoDocManejaSerie = Convert.ToDecimal(dr["bitTipoDocManejaSerie"]),
                                        decTipoDocNumero = Convert.ToDecimal(dr["decTipoDocNumero"]),
                                        strTipoDocContraTipo = dr["strTipoDocContraTipo"].ToString(),
                                        //bitVisibleAlmac = Convert.ToDecimal(dr["bitVisibleAlmac"]),
                                        //bitAfectasStock = Convert.ToDecimal(dr["bitAfectasStock"]),
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
