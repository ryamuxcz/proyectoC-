using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace CapaPresentacion
{
    public partial class ProductoCP : Form
    {
        public ProductoCP()
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
        }

        private void EnlazarEventos()
        {
            btnBuscar.Click += btnBuscar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCerrar.Click += btnCerrar_Click;
            this.Load += ProductoCP_Load;
        }

        private void ProductoCP_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                ProductoCN productoCN = new ProductoCN();
                DataTable dt = productoCN.ListarProductos();
                dgvProductos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                var producto = new ProductoCN().BuscarPorId(id);
                if (producto != null)
                {
                    MessageBox.Show($"Producto encontrado:\n\nID: {producto.ProductoId}\nDescripción: {producto.Descripcion}\nPrecio: {producto.Precio:C}",
                        "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.Precio.ToString("0.00");
                }
                else
                {
                    LimpiarCampos();
                    MessageBox.Show("Producto no encontrado", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    var producto = new Producto
                    {
                        Descripcion = txtDescripcion.Text.Trim(),
                        Precio = decimal.Parse(txtPrecio.Text)
                    };

                    if (string.IsNullOrWhiteSpace(txtId.Text))
                    {
                        int nuevoId = new ProductoCN().Insertar(producto);
                        txtId.Text = nuevoId.ToString();
                        MessageBox.Show("Producto registrado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        producto.ProductoId = int.Parse(txtId.Text);
                        new ProductoCN().Actualizar(producto);
                        MessageBox.Show("Producto actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Descripción es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private static ProductoCP _instance;
        public static ProductoCP GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new ProductoCP();
            return _instance;
        }

        private void ProductoCP_Load_1(object sender, EventArgs e)
        {

        }
    }
}
