using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos;
        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void AgregarProductos(Producto producto)
        {
            productos.Add(producto);
        }
        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            return productos
            .Where(p => p.Precio > precioMinimo)
            .OrderBy(p => p.Precio);
        }
    }
}
