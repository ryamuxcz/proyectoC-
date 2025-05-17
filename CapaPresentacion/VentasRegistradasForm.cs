using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class VentasRegistradasForm : Form
    {
        public VentasRegistradasForm()
        {
            InitializeComponent();
            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                var ventaCN = new VentaCN();
                DataTable dtVentas = ventaCN.ListarVentas();
                dgvVentas.DataSource = dtVentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}");
            }
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ventaId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["VentaId"].Value);
                var detalleForm = new DetalleVentaForm(ventaId);
                detalleForm.ShowDialog();
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VentasRegistradasForm_Load(object sender, EventArgs e)
        {

        }
    }
}
