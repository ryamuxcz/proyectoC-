using System;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class DetalleVentaForm : Form
    {
        private int _ventaId;

        public DetalleVentaForm(int ventaId)
        {
            InitializeComponent();
            _ventaId = ventaId;
            CargarDetalleVenta();
        }

        private void CargarDetalleVenta()
        {
            try
            {
                var ventaCN = new VentaCN();
                DataTable dtDetalle = ventaCN.ListarDetalleVenta(_ventaId);
                dgvDetalle.DataSource = dtDetalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalle: {ex.Message}");
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
