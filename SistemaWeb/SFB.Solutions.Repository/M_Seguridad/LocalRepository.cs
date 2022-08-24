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
    public class LocalRepository : ILocalServices
    {
        private List<MensajeBE> ListMsj;

        private MensajeBE objEntMsj;
        public MensajeBE Anular(LocalBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspLocalAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                        cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                        cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;
                        cmd.Parameters.Add("@strLocalUsuAnul", SqlDbType.VarChar, 50).Value = BE.strLocalUsuAnul;
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
        public List<MensajeBE> Guardar(LocalBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspLocalGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    cmd.Parameters.Add("@strLocalID", SqlDbType.Char, 3).Value = BE.strLocalID;
                    cmd.Parameters.Add("@strLocalName", SqlDbType.VarChar, 50).Value = BE.strLocalName;
                    cmd.Parameters.Add("@strLocalDirec", SqlDbType.VarChar, 150).Value = BE.strLocalDirec;
                    cmd.Parameters.Add("@strLocalFeuInv", SqlDbType.DateTime).Value = BE.strLocalFeuInv;
                    cmd.Parameters.Add("@strLocalUsuCre", SqlDbType.VarChar, 50).Value = BE.strLocalUsuCre;


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
        public List<LocalBE> Listar(LocalBE BE)
        {
            List<LocalBE> lstData = new List<LocalBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspLocalListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    con.Open();

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    lstData.Add(new LocalBE()
                                    {
                                        strDominioID = dr["strDominioID"].ToString(),
                                        strModuloID = dr["strModuloID"].ToString(),
                                        strLocalID = dr["strLocalID"].ToString(),
                                        strLocalName = dr["strLocalName"].ToString(),
                                        strLocalDirec = dr["strLocalDirec"].ToString(),
                                        strLocalFeuInv = dr["strLocalFeuInv"].ToString(),

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
