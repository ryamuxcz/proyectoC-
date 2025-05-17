using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using CapaDatos;

namespace CapaNegocio
{
    public class VentaCN
    {
        
        public int RegistrarVenta(Venta venta, DataTable detalles)
        {
            using (var cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        
                        int ventaId = new VentaDAL().Insertar(venta, cn, tx);

                        
                        foreach (DataRow row in detalles.Rows)
                        {
                            var detalle = new DetalleVenta
                            {
                                VentaId = ventaId,
                                ProductoId = (int)row["ProductoId"],
                                Cantidad = (int)row["Cantidad"],
                                Subtotal = (decimal)row["Subtotal"]
                            };
                            new DetalleDAL().Insertar(detalle, cn, tx);
                        }

                        tx.Commit();
                        return ventaId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        
        public DataTable ListarVentas()
        {
            return new VentaDAL().ListarVentas();
        }

        
        public DataTable ListarDetalleVenta(int ventaId)
        {
            return new VentaDAL().ListarDetalleVenta(ventaId);
        }
    }
}
