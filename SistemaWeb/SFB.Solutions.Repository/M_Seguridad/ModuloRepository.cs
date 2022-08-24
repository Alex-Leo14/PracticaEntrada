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
    public class ModuloRepository : IModuloServices
    {
        private List<MensajeBE> ListMsj;

        private MensajeBE objEntMsj;
        public MensajeBE Anular(ModuloBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspModuloAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                        cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                        cmd.Parameters.Add("@strModuloUsuAnul", SqlDbType.VarChar, 50).Value = BE.strModuloUsuAnul;
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
        public List<MensajeBE> Guardar(ModuloBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspModuloGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    cmd.Parameters.Add("@strModuloID", SqlDbType.Char, 4).Value = BE.strModuloID;
                    cmd.Parameters.Add("@strModuloDesc", SqlDbType.VarChar, 50).Value = BE.strModuloDesc;
                    cmd.Parameters.Add("@strModuloShort", SqlDbType.Char, 2).Value = BE.strModuloShort;
                    cmd.Parameters.Add("@strModuloUsuCre", SqlDbType.VarChar, 50).Value = BE.strModuloUsuCre;

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
        public List<ModuloBE> Listar(ModuloBE BE)
        {
            List<ModuloBE> lstData = new List<ModuloBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspModuloListar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strDominioID", SqlDbType.Char, 2).Value = BE.strDominioID;
                    con.Open();

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    lstData.Add(new ModuloBE()
                                    {
                                        strDominioID = dr["strDominioID"].ToString(),
                                        strDominioDesc = dr["strDominioDesc"].ToString(),
                                        strModuloID = dr["strModuloID"].ToString(),
                                        strModuloDesc = dr["strModuloDesc"].ToString(),
                                        strModuloShort = dr["strModuloShort"].ToString(),
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
