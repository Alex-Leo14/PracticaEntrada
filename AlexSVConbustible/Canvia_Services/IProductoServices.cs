using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canvia_DTO;

namespace Canvia_Services
{
    public interface IProductoServices
    {
        bool Insertar(Producto_DTO BE);
        bool Eliminar(int intProductoId);
        bool Actualizar(Producto_DTO BE);
        List<Producto_DTO> Listar();

    }
}
