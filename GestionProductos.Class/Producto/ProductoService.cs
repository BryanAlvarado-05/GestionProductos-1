using System;
using System.Collections.Generic;
using System.Text;
using GestionProductos.Class.Producto;

namespace GestionProductos.Class.Producto
{
    public class ProductoService
    {
        private List<ProductoListCLS> lista;

        public ProductoService()
        {
            lista = new List<ProductoListCLS>();

            lista.Add(new ProductoListCLS
            {
                idproducto = 1,
                nombre = "Laptop",
                precio = 850000,
                descripcion = "Laptop Dell 16GB RAM"
            });

            lista.Add(new ProductoListCLS
            {
                idproducto = 2,
                nombre = "Mouse",
                precio = 15000,
                descripcion = "Mouse inalámbrico Logitech"
            });

            lista.Add(new ProductoListCLS
            {
                idproducto = 3,
                nombre = "Teclado",
                precio = 25000,
                descripcion = "Teclado mecánico RGB"
            });
        }

        public async Task<List<ProductoListCLS>> listaProductos()
        {
            return lista;
        }

        public async Task<ProductoListCLS> recuperarProductoId(int idproducto)
        {
            return lista.Where(p => p.idproducto == idproducto).First();
        }

        public void agregarProducto(ProductoListCLS producto)
        {
            producto.idproducto = lista.Max(p => p.idproducto) + 1;
            lista.Add(producto);
        }

        public void actualizarProducto(ProductoListCLS producto)
        {
            var item = lista.Where(p => p.idproducto == producto.idproducto).First();
            item.nombre = producto.nombre;
            item.precio = producto.precio;
            item.descripcion = producto.descripcion;
        }

        public void eliminarProducto(int idproducto)
        {
            var item = lista.Where(p => p.idproducto == idproducto).First();
            lista.Remove(item);
        }
    }
}