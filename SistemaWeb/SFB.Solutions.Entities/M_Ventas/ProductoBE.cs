using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Entities.M_Ventas
{
    public class ProductoBE
    {
        public int intProductoId { get; set; }
        public string strProductoDesc { get; set; }
        public int intCantidad { get; set; }
        public decimal decPrecio { get; set; }
        public bool bitEstado { get; set; }
        public bool result { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
