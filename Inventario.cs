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

        //Método para actualizar el precio de un  producto
        public void ActualizarPrecio(string nombreProducto, decimal nuevoPrecio)
        {
            var productoExistente = productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));

            if (productoExistente == null)
            {
                Console.WriteLine($"El producto '{nombreProducto}' no existe en el inventario.");
                return;
            }

            if (nuevoPrecio <= 0)
            {
                Console.WriteLine("El precio debe ser positivo.");
                return;
            }

            productoExistente.Precio = nuevoPrecio;
            Console.WriteLine($"Precio actualizado de '{productoExistente.Nombre}': {nuevoPrecio:C}");
        }
        // Metodo para eliminar un producto
        public void EliminarProducto(string nombreProducto)
        {
            int productosEliminados = productos.RemoveAll(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            if (productosEliminados > 0)
            {
                Console.WriteLine($"El producto '{nombreProducto}' ha sido eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"El producto '{nombreProducto}' no se encontró en el inventario.");
            }
        }
        // Método para contar productos en rangos preestablecidos
        public void ContarProductosPorRangoDePrecio()
        {
            var categorias = productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "menores a 100";
                if (p.Precio <= 500) return "entre 100 y 500";
                return "mayores a 500";
            })
            .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine($"Productos con precio menor a 100: {categorias.GetValueOrDefault("menores a 100", 0)}");
            Console.WriteLine($"Productos con precio entre 100 y 500: {categorias.GetValueOrDefault("entre 100 y 500", 0)}");
            Console.WriteLine($"Productos con precio mayor a 500: {categorias.GetValueOrDefault("mayores a 500", 0)}");
        }
    }
}
