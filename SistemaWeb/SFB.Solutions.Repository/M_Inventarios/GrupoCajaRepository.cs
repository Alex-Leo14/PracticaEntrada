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
    public class GrupoCajaRepository : IGrupoCajaServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;
        public MensajeBE Anular(GrupoCajaBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspGrupoCajaAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intGrupoCajaID", SqlDbType.Int).Value = BE.intGrupoCajaID;
                        cmd.Parameters.Add("@strGrupoCajaUsuAnul", SqlDbType.VarChar, 50).Value = BE.strGrupoCajaUsuAnul;
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

        public List<MensajeBE> Guardar(GrupoCajaBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspGrupoCajaGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@intGrupoCajaID", SqlDbType.Int).Value = BE.intGrupoCajaID;

                    cmd.Parameters.Add("@strGrupoCajaDesc", SqlDbType.VarChar, 100).Value = BE.strGrupoCajaDesc;
                    cmd.Parameters.Add("@strGrupoCajaUsuCre", SqlDbType.VarChar, 50).Value = BE.strGrupoCajaUsuCre;
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

        public List<GrupoCajaBE> Listar()
        {
            List<GrupoCajaBE> lstData = new List<GrupoCajaBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspGrupoCajaListar", con))
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
                                    lstData.Add(new GrupoCajaBE()
                                    {
                                        intGrupoCajaID = Convert.ToInt32(dr["intGrupoCajaID"].ToString()),
                                        
                                        strGrupoCajaDesc = dr["strGrupoCajaDesc"].ToString(),
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
