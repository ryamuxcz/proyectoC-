using System.Data;
using Entidades;
using CapaDatos;

namespace CapaNegocio
{
    public class ClienteCN
    {
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();

        
        public Cliente BuscarPorId(int id)
        {
            return _clienteDAL.Obtener(id);
        }

        
        public int Insertar(Cliente cliente)
        {
            return _clienteDAL.Insertar(cliente);
        }

        
        public void Actualizar(Cliente cliente)
        {
            _clienteDAL.Actualizar(cliente);
        }

        
        public DataTable ListarClientes()
        {
            return _clienteDAL.ListarClientes();
        }
    }
}
