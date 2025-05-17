using System;
using System.Windows.Forms;
using CapPresentacion;

namespace CapaPresentacion
{
    public partial class PrincipalMDI : Form
    {
        public PrincipalMDI()
        {
            InitializeComponent();
        }

        private void PrincipalMDI_Load(object sender, EventArgs e)
        {
            this.Text = "Sistema de Ventas - SENATI - " + DateTime.Now.ToString("yyyy");
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioSingleton<ClienteCP>();
        }

        private void menuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioSingleton<ProductoCP>();
        }

        private void menuVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioSingleton<VentaDetalleCP>();
        }

        private void menuVentasRegistradas_Click(object sender, EventArgs e)
        {
            AbrirFormularioSingleton<VentasRegistradasForm>();
        }

        private void AbrirFormularioSingleton<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.BringToFront();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            T nuevoForm = new T();
            nuevoForm.MdiParent = this;
            nuevoForm.Show();
        }
    }
}
