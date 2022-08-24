using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Inventarios;
using SFB.Solutions.Helpers;
using SFB.Solutions.Sevices.M_Inventarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Repository.M_Inventarios
{
    public class CajaRepository : ICajaServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;

        public MensajeBE Anular(CajaBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspCajaAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intIDCaja", SqlDbType.Int).Value = BE.intIDCaja;

                        cmd.Parameters.Add("@intIDGrupocaja", SqlDbType.Int).Value = BE.intIDGrupocaja;

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

        public List<MensajeBE> Guardar(CajaBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCajaGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@intIDCaja", SqlDbType.Int).Value = BE.intIDCaja;
                    cmd.Parameters.Add("@intIDGrupocaja", SqlDbType.Int).Value = BE.intIDGrupocaja;
                    cmd.Parameters.Add("@strNombCaja", SqlDbType.VarChar, 30).Value = BE.strNombCaja;
                    
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

        public List<CajaBE> Listar()
        {
            List<CajaBE> lstData = new List<CajaBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCajaListar", con))
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
                                    lstData.Add(new CajaBE()
                                    {
                                        intIDCaja = Convert.ToInt32(dr["intIDCaja"].ToString()),
                                        intIDGrupocaja = Convert.ToInt32(dr["intIDGrupocaja"].ToString()),
                                        strNombCaja = dr["strNombCaja"].ToString(),
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
