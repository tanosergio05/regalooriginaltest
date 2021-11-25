using RegaloOriginalTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegaloOriginalTest.Services.Concrete
{
    public class PedidoService : IPedidoService
    {
        public Dictionary<string, int> ObtenerPedidosConTotales(Dictionary<string, List<string>> pedidos)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var nombre in pedidos.Keys)
            {
                result.Add(nombre, pedidos[nombre].Count);
            }

            return result;
        }

        public string ObtenerPersonaQueMasGasto(Dictionary<string, List<string>> pedidos)
        {
            int countMayor = 0;
            string result = "";

            foreach (var nombre in pedidos.Keys)
            {
                if (pedidos[nombre].Count() > countMayor)
                {
                    result = nombre;
                }
            }

            return result;
        }

        public int ObtenerTotalTodosLosPedidos(Dictionary<string, int> pedidosConTotales)
        {
            int result = 0;

            foreach (var nombre in pedidosConTotales.Keys)
            {
                result += pedidosConTotales[nombre];
            }

            return result;
        }
    }
}
