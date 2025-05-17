using System.Data.SqlClient;

namespace CapaDatos
{
    public sealed class Conexion
    {
        private static Conexion _instancia = null;
        private readonly string _cadena = "Server=localhost;Database=VentaDB;User Id=sa;Password=TechSolutions2024!;";

        private Conexion() { }

        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Conexion();
                }
                return _instancia;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadena);
        }
    }
}
