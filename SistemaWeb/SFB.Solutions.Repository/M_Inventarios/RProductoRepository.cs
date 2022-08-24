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
    public class RProductoRepository : IRProductoServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;
        public MensajeBE Anular(RProductoBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspProductoAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@intProductoID", SqlDbType.Int).Value = BE.intProductoID;
                        cmd.Parameters.Add("@strProductoUsuAnul", SqlDbType.VarChar, 50).Value = BE.strProductoUsuAnul;
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

        public List<MensajeBE> Guardar(RProductoBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspProductoGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@intProductoID", SqlDbType.Int).Value = BE.intProductoID;
                    cmd.Parameters.Add("@strProductoDesc", SqlDbType.VarChar, 60).Value = BE.strProductoDesc;
                    cmd.Parameters.Add("@strProductoUsuCre", SqlDbType.VarChar, 50).Value = BE.strProductoUsuCre;
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

        public List<RProductoBE> Listar()
        {
            List<RProductoBE> lstData = new List<RProductoBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.ConexionEntel()))
            {
                using (SqlCommand cmd = new SqlCommand("gspProductoListar", con))
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
                                    lstData.Add(new RProductoBE()
                                    {
                                        intProductoID = Convert.ToInt32(dr["intProductoID"].ToString()),
                                        strProductoDesc = dr["strProductoDesc"].ToString(),
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
