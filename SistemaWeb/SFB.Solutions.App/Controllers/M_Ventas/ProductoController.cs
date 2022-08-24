using SFB.Solutions.Entities.M_Ventas;
using SFB.Solutions.Sevices.M_Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SFB.Solutions.App.Controllers.M_Ventas
{
    public class ProductoController : Controller
    {
        WebRequestProducto _WebRequestProducto = new WebRequestProducto();

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ventas()
        {
            return View();
        }

        public ActionResult _Create()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult Listar([System.Web.Http.FromBody] ProductoBE BE)
        {
            ProductoBE _producto = new ProductoBE();
            var dtEstado = _WebRequestProducto.Listar(BE);
            return new JsonResult()
            {
                Data = dtEstado,
                MaxJsonLength = 86753090,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [HttpPost]
        public JsonResult Insert([System.Web.Http.FromBody] ProductoBE BE)
        {
            try
            {
                string Mensaje = "";
                ProductoBE _producto = new ProductoBE();

                if (BE == null) Mensaje = "El Objeto no puede ser Vacio";
                if (Mensaje != "")
                {
                    throw new Exception(Mensaje);
                }

                _producto = _WebRequestProducto.Insertar(BE);
                return Json(new
                {
                    Satisfactorio = _producto.result,
                    Titulo = "MENSAJE DEL SISTEMA",
                    Mensaje = _producto.message,
                }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Satisfactorio = false,
                    Titulo = "Error",
                    Mensaje = ex.Message,
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Act([System.Web.Http.FromBody] ProductoBE BE)
        {
            try
            {
                string Mensaje = "";
                ProductoBE _producto = new ProductoBE();

                bool flag = false;

                if (BE == null) Mensaje = "El Objeto no puede ser Vacio";
                if (Mensaje != "")
                {
                    throw new Exception(Mensaje);
                }

                _producto = _WebRequestProducto.Actualizar(BE);
                return Json(new
                {
                    Satisfactorio = true,
                    Titulo = "Excelente",
                    Mensaje = "Se Actualizo Correctamente",
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Satisfactorio = false,
                    Titulo = "Error",
                    Mensaje = ex.Message,
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Anular([System.Web.Http.FromBody] ProductoBE BE)
        {
            try
            {
                ProductoBE _producto = new ProductoBE();
                string Mensaje = "";

                if (BE == null) Mensaje = "El Objeto no puede ser Vacio";
                if (Mensaje != "")
                {
                    throw new Exception(Mensaje);
                }

                _producto = _WebRequestProducto.Anular(BE);
                return Json(new
                {
                    Satisfactorio = true,
                    Titulo = "Excelente",
                    Mensaje = "Se Grabo Correctamente",
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Satisfactorio = false,
                    Titulo = "Error",
                    Mensaje = ex.Message,
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}