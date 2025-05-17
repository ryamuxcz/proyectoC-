using Entidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DetalleDAL
    {
        public void Insertar(DetalleVenta detalle, SqlConnection cn, SqlTransaction tx)
        {
            var cmd = new SqlCommand(
                "INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, Subtotal) " +
                "VALUES (@VentaId, @ProductoId, @Cantidad, @Subtotal)", cn, tx);

            cmd.Parameters.AddWithValue("@VentaId", detalle.VentaId);
            cmd.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
            cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

            cmd.ExecuteNonQuery();
        }
    }
}