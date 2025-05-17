using System;
using System.Data;
using Entidades;
using CapaDatos;

namespace CapaNegocio
{
    public class ProductoCN
    {
        private readonly ProductoDAL _productoDAL = new ProductoDAL();

        
        public int Insertar(Producto producto)
        {
            try
            {
                return _productoDAL.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }
        public void Actualizar(Producto producto)
        {
            try
            {
                _productoDAL.Actualizar(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }

        
        public Producto BuscarPorId(int id)
        {
            try
            {
                return _productoDAL.Obtener(id); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar producto: " + ex.Message);
            }
        }
        public DataTable ListarProductos()
        {
            try
            {
                return _productoDAL.Listar(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }
        }
    }
}
