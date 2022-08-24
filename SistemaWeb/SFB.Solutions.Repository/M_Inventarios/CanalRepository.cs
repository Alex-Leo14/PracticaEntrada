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
    public class CanalRepository : ICanalServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;
        public MensajeBE Anular(CanalBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspCanalAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intCanalID", SqlDbType.Int).Value = BE.intCanalID;
                        cmd.Parameters.Add("@strCanalUsuAnul", SqlDbType.VarChar,50).Value = BE.strCanalUsuAnul;
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

        public List<MensajeBE> Guardar(CanalBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCanalGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@intCanalID", SqlDbType.Int).Value = BE.intCanalID;
                    cmd.Parameters.Add("@strCanalDesc", SqlDbType.VarChar, 50).Value = BE.strCanalDesc;
                    cmd.Parameters.Add("@strCanalUsuCre", SqlDbType.VarChar, 50).Value = BE.strCanalUsuCre;
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

        public List<CanalBE> Listar()
        {
            List<CanalBE> lstData = new List<CanalBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCanalListar", con))
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
                                    lstData.Add(new CanalBE()
                                    {
                                        intCanalID = Convert.ToInt32(dr["intCanalID"].ToString()),
                                        strCanalDesc = dr["strCanalDesc"].ToString(),
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
