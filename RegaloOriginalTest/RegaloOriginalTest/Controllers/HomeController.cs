using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegaloOriginalTest.Models;
using RegaloOriginalTest.Services.Concrete;

namespace RegaloOriginalTest.Controllers
{
    public class HomeController : Controller
    {
        List<string> lstItems = new List<string>();
        Dictionary<string, List<string>> dicPedidos = new Dictionary<string, List<string>>();
        public ActionResult Index()
        {
            Session["lstItems"] = lstItems;
            Session["dicPedidos"] = dicPedidos;
            return View();
        }

        [HttpPost]
        public JsonResult AgregarItem(string item)
        {
            lstItems = Session["lstItems"] as List<string>;
            lstItems.Add(item);
            Session["lstItems"] = lstItems;

            var result = "Se agrego " + item + " a la lista de pedidos!";
            return Json(result);
        }

        [HttpPost]
        public JsonResult AgregarPedido(string nombre)
        {
            lstItems = Session["lstItems"] as List<string>;
            dicPedidos = Session["dicPedidos"] as Dictionary<string, List<string>>;

            dicPedidos.Add(nombre,lstItems);
            lstItems.Clear();

            Session["lstItems"] = lstItems;
            Session["dicPedidos"] = dicPedidos;

            var result = "Se agregó el pedido de " + nombre;

            return Json(result);
        }


        public ActionResult ListarPedidos()
        {
            PedidoViewModel modelo = new PedidoViewModel();
            dicPedidos = Session["dicPedidos"] as Dictionary<string, List<string>>;

            PedidoService service = new PedidoService();
            modelo.NombrePersonaQueMasGasto = service.ObtenerPersonaQueMasGasto(dicPedidos);
            modelo.Pedidos = service.ObtenerPedidosConTotales(dicPedidos);
            modelo.TotalTodosLosPedidos = service.ObtenerTotalTodosLosPedidos(modelo.Pedidos);

            return View(modelo);
        }
    }
}