using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace CapaDatos
{
    public class ClienteDAL
    {
        public Cliente Obtener(int clienteId)
        {
            using (var cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand("SELECT ClienteId, Nombre FROM Cliente WHERE ClienteId = @ClienteId", cn);
                cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Cliente
                        {
                            ClienteId = dr.GetInt32(0),
                            Nombre = dr.GetString(1)
                        };
                    }
                }
                return null;
            }
        }

        public int Insertar(Cliente cliente)
        {
            using (var cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Cliente (Nombre) OUTPUT INSERTED.ClienteId VALUES (@Nombre)", cn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Actualizar(Cliente cliente)
        {
            using (var cn = Conexion.Instancia.ObtenerConexion())
            {
                cn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Cliente SET Nombre = @Nombre WHERE ClienteId = @ClienteId", cn);
                cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarClientes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT ClienteId, Nombre FROM Cliente";

            using (var cn = Conexion.Instancia.ObtenerConexion())
            {
                using (var da = new SqlDataAdapter(query, cn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
