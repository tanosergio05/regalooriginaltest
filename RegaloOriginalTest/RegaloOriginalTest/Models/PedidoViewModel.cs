using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegaloOriginalTest.Models
{
    public class PedidoViewModel
    {
        public string NombrePersonaQueMasGasto { get; set; }
        public Dictionary<string, int> Pedidos { get; set; }

        public int TotalTodosLosPedidos { get; set; }
    }
}