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
    public class CategoriaRepository : ICategoriaServices
    {
        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;

        public MensajeBE Anular(CategoriaBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspCategoriaAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@strCategoriaId", SqlDbType.Char, 2).Value = BE.strCategoriaId;
                        cmd.Parameters.Add("@strCategoriaUsuAnul", SqlDbType.VarChar, 50).Value = BE.strCategoriaUsuAnul;
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

        public List<MensajeBE> Guardar(CategoriaBE BE)
        {
            ListMsj = new List<MensajeBE>();
            using (SqlConnection con = new SqlConnection
                (AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCategoriaGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@strCategoriaId", SqlDbType.Char,2).Value = BE.strCategoriaId;
                    cmd.Parameters.Add("@strCategoriaDesc", SqlDbType.VarChar, 50).Value = BE.strCategoriaDesc;
                    cmd.Parameters.Add("@strCategoriaUsuCre", SqlDbType.VarChar, 50).Value = BE.strCategoriaUsuCre;
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

        public List<CategoriaBE> Listar()
        {
            List<CategoriaBE> lstData = new List<CategoriaBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCategoriaListar", con))
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
                                    lstData.Add(new CategoriaBE()
                                    {
                                        strCategoriaId = dr["strCategoriaId"].ToString(),
                                        strCategoriaDesc = dr["strCategoriaDesc"].ToString(),
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
