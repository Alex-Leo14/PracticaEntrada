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
    public class UsuarioRepository : IUsuarioServices
    {
        

        private List<MensajeBE> ListMsj;
        private MensajeBE objEntMsj;
        public MensajeBE Anular(UsuarioBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspUsuarioAnular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDUSUARIO;
                        cmd.Parameters.Add("@USUARIOANULACION", SqlDbType.VarChar, 50).Value = BE.USUARIOANULACION;
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

        public List<MensajeBE> CambiarClave(UsuarioBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspCambioContraseña", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDUSUARIO;
                    
                    cmd.Parameters.Add("@ClaveAntigua", SqlDbType.VarChar, 100).Value = BE.ClaveAntigua;
                    cmd.Parameters.Add("@ClaveNueva", SqlDbType.VarChar, 100).Value = BE.ClaveNueva;


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

        public List<MensajeBE> Guardar(UsuarioBE BE)
        {
            ListMsj = new List<MensajeBE>();

            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspUsuarioGuardar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = BE.IDUSUARIO;
                    cmd.Parameters.Add("@TIPODOCUMENTO", SqlDbType.VarChar, 3).Value = BE.TIPODOCUMENTO;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 20).Value = BE.NRODOCUMENTO;
                    cmd.Parameters.Add("@NOMBRES", SqlDbType.VarChar, 200).Value = BE.NOMBRES;
                    cmd.Parameters.Add("@APELLIDOPATERNO", SqlDbType.VarChar, 200).Value = BE.APELLIDOPATERNO;
                    cmd.Parameters.Add("@APELLIDOMATERNO", SqlDbType.VarChar, 200).Value = BE.APELLIDOMATERNO;
                    cmd.Parameters.Add("@CORREO", SqlDbType.VarChar, 100).Value = BE.CORREO;
                    cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar, 100).Value = BE.CELULAR;
                    cmd.Parameters.Add("@SEXO", SqlDbType.Char, 10).Value = BE.SEXO;
                    cmd.Parameters.Add("@FECHANACIMIENTO", SqlDbType.DateTime).Value = BE.FECHANACIMIENTO;
                    cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 500).Value = BE.DIRECCION;
                    cmd.Parameters.Add("@CODUBIGEO", SqlDbType.VarChar, 60).Value = BE.CODUBIGEO;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = BE.USUARIO;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 100).Value = BE.CLAVE;
                    cmd.Parameters.Add("@FECHAINGRESO", SqlDbType.DateTime).Value = BE.FECHAINGRESO;
                    cmd.Parameters.Add("@FLAG", SqlDbType.Char, 1).Value = BE.FLAG;
                    cmd.Parameters.Add("@FECHACESETRABAJADOR", SqlDbType.DateTime).Value = BE.FECHACESETRABAJADOR;
                    cmd.Parameters.Add("@ES_ADMIN", SqlDbType.Char, 1).Value = BE.ES_ADMIN;
                    cmd.Parameters.Add("@DE_ESTA_CIVI", SqlDbType.VarChar, 50).Value = BE.DE_ESTA_CIVI;
                    cmd.Parameters.Add("@USUARIOCREACION", SqlDbType.VarChar, 50).Value = BE.USUARIOCREACION;
                    cmd.Parameters.Add("@FECHACREACION", SqlDbType.DateTime).Value = BE.FECHACREACION;
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

        public List<UsuarioBE> Listar()
        {
            List<UsuarioBE> lstData = new List<UsuarioBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspUsuarioListar", con))
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
                                    lstData.Add(new UsuarioBE()
                                    {
                                        IDUSUARIO = Convert.ToInt32(dr["IDUSUARIO"]),
                                        TIPODOCUMENTO = dr["TIPODOCUMENTO"].ToString(),
                                        NRODOCUMENTO = dr["NRODOCUMENTO"].ToString(),
                                        NOMBRES = dr["NOMBRES"].ToString(),
                                        APELLIDOPATERNO = dr["APELLIDOPATERNO"].ToString(),
                                        APELLIDOMATERNO = dr["APELLIDOMATERNO"].ToString(),                                     
                                        CORREO = dr["CORREO"].ToString(),
                                        CELULAR = dr["CELULAR"].ToString(),
                                        SEXO = dr["SEXO"].ToString(),
                                        FECHANACIMIENTO = dr["FECHANACIMIENTO"].ToString(),
                                        DIRECCION = dr["DIRECCION"].ToString(),
                                        //CODUBIGEO = dr["CODUBIGEO"].ToString(),
                                        USUARIO = dr["USUARIO"].ToString(),
                                        CLAVE = dr["CLAVE"].ToString(),
                                        //FECHAINGRESO = Convert.ToDateTime(dr["FECHAINGRESO"]),  
                                        DE_ESTA_CIVI= dr["DE_ESTA_CIVI"].ToString(),

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

        public MensajeBE Validar(UsuarioBE BE)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("gspUsuarioValidacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = BE.USUARIO;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = BE.CLAVE;
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
    }
}
