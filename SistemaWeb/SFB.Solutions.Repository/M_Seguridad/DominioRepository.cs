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
    public class DominioRepository : IDominioServices
    {
        private List<MensajeBE> ListMsj;

        private MensajeBE objEntMsj;
        public MensajeBE Anular(DominioBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspDominioAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strDominioID", SqlDbType.Char,2).Value = BE.strDominioID;
                        cmd.Parameters.Add("@strDominioUsuAnul", SqlDbType.VarChar, 50).Value = BE.strDominioUsuAnul;
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

        public List<MensajeBE> Guardar(DominioBE BE)
        {

            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspDominioGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strDominioDesc", SqlDbType.VarChar, 50).Value = BE.strDominioDesc;
                    cmd.Parameters.Add("@strDominioUsuCre", SqlDbType.VarChar, 50).Value = BE.strDominioUsuCre;

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

        public List<DominioBE> Listar()
        {
            List<DominioBE> lstData = new List<DominioBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspDominioListar", con))
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
                                    lstData.Add(new DominioBE()
                                    {
                                        strDominioID = dr["strDominioID"].ToString(),
                                        strDominioDesc = dr["strDominioDesc"].ToString(),
                                        //strDominioEstado = dr["strDominioEstado"].ToString(),
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
