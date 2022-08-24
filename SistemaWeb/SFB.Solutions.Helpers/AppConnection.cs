using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Helpers
{
    public static class AppConnection
    {
        public static string Conexion()
        {
            return ConfigurationManager.ConnectionStrings["MBConnectionString"].ConnectionString.ToString();
        }

        public static string ConexionEntel()
        {
            return ConfigurationManager.ConnectionStrings["CNEntel"].ConnectionString.ToString();
        }

    }
}
