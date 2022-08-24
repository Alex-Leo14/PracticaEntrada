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
    public class EmpresaRepository : IEmpresaServices
    {
        public List<EmpresaBE> Listar()
        {
            List<EmpresaBE> lstData = new List<EmpresaBE>();
            using (SqlConnection con = new SqlConnection(AppConnection.Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspEmpresaListar", con))
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
                                    lstData.Add(new EmpresaBE()
                                    {
                                        strEmpresaID = dr["strEmpresaID"].ToString(),
                                        strEmpresaDesc = dr["strEmpresaDesc"].ToString(),

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
