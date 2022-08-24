using Canvia_DTO;
using Canvia_Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioWebApiCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServices _IProductoServices;
        public ProductoController(IProductoServices IProductoServices)
        {
            this._IProductoServices = IProductoServices;
        }
        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] Producto_DTO BE)
        {
            object result;
            try
            {
                result = new { code = 101, message = "hubo un problema para registrar" };
                var res = _IProductoServices.Insertar(BE);
                if (res != null)
                {
                    result = new { code = 200, message = "Se registro correctamente", result = true, obj = res };
                }
            }
            catch (Exception ex)
            {
                result = new { code = -100, message = ex.Message };
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("ListarTodo")]
        public  IActionResult ListarTodo()
        {
            object result;
            try
            {
                //result = new { code = 101, message = "Success, id not found" };
                result = new object();

                var res = _IProductoServices.Listar();
                if (res != null)
                {
                    //result = new { code = 200, message = "Success", result = res };
                    result = res;
                }
            }
            catch (Exception ex)
            {
                result = new { code = -100, message = ex.Message };
            }

            return Ok(result);
        }


        [HttpPost]
        [Route("Eliminar")]
        public IActionResult Eliminar(Producto_DTO BE)
        {
            object result;
            try
            {
                result = new { code = 101, message = "hubo un problema para anular" };
                var res = _IProductoServices.Eliminar(BE.intProductoId);
                if (res != null)
                {
                    result = new { code = 200, message = "Se Anulo correctamente", result = true, obj = res };
                }
            }
            catch (Exception ex)
            {
                result = new { code = -100, message = ex.Message };
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar(Producto_DTO BE)
        {

            object result;
            try
            {
                result = new { code = 101, message = "hubo un problema para Actualizar" };
                var res = _IProductoServices.Actualizar(BE);
                if (res != null)
                {
                    result = new { code = 200, message = "Se Actualizo correctamente", result = true, obj = res };
                }
            }
            catch (Exception ex)
            {
                result = new { code = -100, message = ex.Message };
            }

            return Ok(result);
        }



    }
}
