using System;

namespace Tarea_GestionInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            bool salir = false;

            Console.WriteLine("Bienvenido al sistema de gestión de inventario.");

            while (!salir)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Agregar productos");
                Console.WriteLine("2. Filtrar y mostrar productos por precio mínimo");
                Console.WriteLine("3. Actualizar precio de un producto");
                Console.WriteLine("4. Eliminar un producto");
                Console.WriteLine("5. Contar productos por rango de precio");
                Console.WriteLine("6. Generar reporte resumido del inventario");
                Console.WriteLine("7. Salir");

                Console.Write("\nOpción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProductos(inventario);
                        break;
                    case "2":
                        FiltrarYMostrarProductos(inventario);
                        break;
                    case "3":
                        ActualizarPrecioProducto(inventario);
                        break;
                    case "4":
                        EliminarProducto(inventario);
                        break;
                    case "5":
                        inventario.ContarProductosPorRangoDePrecio();
                        break;
                    case "6":
                        inventario.GenerarReporteResumido();
                        break;
                    case "7":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }

        static bool EsNombreValido(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) && nombre.Length >= 3;
        }

        static void AgregarProductos(Inventario inventario)
        {
            Console.WriteLine("\n¿Cuántos productos desea ingresar?");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"\nProducto {i + 1}:");

                    string nombre;
                    do
                    {
                        Console.Write("Nombre (mínimo 3 caracteres): ");
                        nombre = Console.ReadLine();
                        if (!EsNombreValido(nombre))
                        {
                            Console.WriteLine("Nombre no válido. Intente nuevamente.");
                        }
                    } while (!EsNombreValido(nombre));

                    Console.Write("Precio: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal precio))
                    {
                        Producto producto = new Producto(nombre, precio);
                        inventario.AgregarProductos(producto);
                        Console.WriteLine("Producto agregado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Precio no válido, intente nuevamente.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Cantidad no válida.");
            }
        }

        static void ActualizarPrecioProducto(Inventario inventario)
        {
            string nombreProducto;
            do
            {
                Console.Write("\nIngrese el nombre del producto a actualizar (mínimo 3 caracteres): ");
                nombreProducto = Console.ReadLine();
                if (!EsNombreValido(nombreProducto))
                {
                    Console.WriteLine("Nombre no válido. Intente nuevamente.");
                }
            } while (!EsNombreValido(nombreProducto));

            Console.Write("Ingrese el nuevo precio: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
            {
                inventario.ActualizarPrecio(nombreProducto, nuevoPrecio);
            }
            else
            {
                Console.WriteLine("Precio no válido.");
            }
        }

        static void EliminarProducto(Inventario inventario)
        {
            string nombreProducto;
            do
            {
                Console.Write("\nIngrese el nombre del producto a eliminar (mínimo 3 caracteres): ");
                nombreProducto = Console.ReadLine();
                if (!EsNombreValido(nombreProducto))
                {
                    Console.WriteLine("Nombre no válido. Intente nuevamente.");
                }
            } while (!EsNombreValido(nombreProducto));

            inventario.EliminarProducto(nombreProducto);
        }

        static void FiltrarYMostrarProductos(Inventario inventario)
        {
            Console.Write("\nIngrese el precio mínimo para filtrar los productos: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precioMinimo))
            {
                var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
                Console.WriteLine("\nProductos filtrados y ordenados:");
                foreach (var producto in productosFiltrados)
                {
                    producto.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("Precio mínimo no válido.");
            }
        }
    }
}
