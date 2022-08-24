using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia_DTO
{
    public class Producto_DTO
    {
        public int intProductoId { get; set; }
        public string strProductoDesc { get; set; }
        public int intCantidad { get; set; }
        public decimal decPrecio { get; set; }
        //public bool bitEstado { get; set; }
    }
}
