using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace CapaPresentacion
{
    public partial class ClienteCP : Form
    {
        public ClienteCP()
        {
            InitializeComponent();
            ConfigurarFormulario();
            EnlazarEventos();
        }

        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void EnlazarEventos()
        {
            btnBuscar.Click += btnBuscar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCerrar.Click += btnCerrar_Click;
            this.Load += ClienteCP_Load;
        }

        private void ClienteCP_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                ClienteCN clienteCN = new ClienteCN();
                DataTable dt = clienteCN.ListarClientes();
                dgvClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                var cliente = new ClienteCN().BuscarPorId(id);
                if (cliente != null)
                {
                    MessageBox.Show($"Cliente encontrado:\n\nID: {cliente.ClienteId}\nNombre: {cliente.Nombre}",
                        "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = cliente.Nombre;
                }
                else
                {
                    LimpiarCampos();
                    MessageBox.Show("Cliente no encontrado", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ID inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var cliente = new Cliente
                    {
                        Nombre = txtNombre.Text.Trim()
                    };

                    if (string.IsNullOrWhiteSpace(txtId.Text))
                    {
                        int nuevoId = new ClienteCN().Insertar(cliente);
                        txtId.Text = nuevoId.ToString();
                        MessageBox.Show("Cliente registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cliente.ClienteId = int.Parse(txtId.Text);
                        new ClienteCN().Actualizar(cliente);
                        MessageBox.Show("Cliente actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtId.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private static ClienteCP _instance;
        public static ClienteCP GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new ClienteCP();
            return _instance;
        }

        private void ClienteCP_Load_1(object sender, EventArgs e)
        {

        }
    }
}
