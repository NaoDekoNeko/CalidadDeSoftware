using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    
    public interface IProducto
    {
        string Nombre { get; set; }
        decimal Precio { get; set; }
    }

    public class CarritoDeCompras
    {
        private List<IProducto> productos;

        public CarritoDeCompras()
        {
            productos = new List<IProducto>();
        }

        public void AgregarProducto(IProducto producto)
        {
            productos.Add(producto);
        }

        public void QuitarProducto(IProducto producto)
        {
            productos.Remove(producto);
        }

        public decimal Checkout()
        {
            decimal total = 0;
            foreach (var producto in productos)
            {
                total += producto.Precio;
            }
            // El carrito debe estar vacío después del checkout
            productos.Clear();
            return total;
        }
    }
}
