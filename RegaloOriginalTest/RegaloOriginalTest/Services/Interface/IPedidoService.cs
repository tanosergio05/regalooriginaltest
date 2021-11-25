using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegaloOriginalTest.Services.Interface
{
    public interface IPedidoService
    {
        string ObtenerPersonaQueMasGasto(Dictionary<string, List<string>> pedidos);
        Dictionary<string, int> ObtenerPedidosConTotales(Dictionary<string, List<string>> pedidos);
        int ObtenerTotalTodosLosPedidos(Dictionary<string, int> pedidosConTotales);
    }
}