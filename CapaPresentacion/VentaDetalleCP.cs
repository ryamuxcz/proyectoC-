using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;

namespace CapaPresentacion
{
    public partial class VentaDetalleCP : Form
    {
        private DataTable _detallesVenta;
        private decimal _totalVenta = 0;

        public VentaDetalleCP()
        {
            InitializeComponent();
            ConfigurarFormulario();
            InicializarTablaDetalles();
        }

        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            
            txtClienteId.Location = new Point(100, 20);
            txtClienteId.Width = 150;

            txtProductoId.Location = new Point(100, 80);
            txtProductoId.Width = 150;

            txtDescripcionProducto.Location = new Point(116, 110);
            txtDescripcionProducto.Width = 250;

            txtPrecioProducto.Location = new Point(100, 140);
            txtPrecioProducto.Width = 100;

            txtCantidad.Location = new Point(100, 170);
            txtCantidad.Width = 100;

            txtClienteId.Focus();
        }

        private void InicializarTablaDetalles()
        {
            _detallesVenta = new DataTable();
            _detallesVenta.Columns.Add("ProductoId", typeof(int));
            _detallesVenta.Columns.Add("Descripcion", typeof(string));
            _detallesVenta.Columns.Add("Precio", typeof(decimal));
            _detallesVenta.Columns.Add("Cantidad", typeof(int));
            _detallesVenta.Columns.Add("Subtotal", typeof(decimal));

            dgvDetalles.DataSource = _detallesVenta;
            ActualizarTotal();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtClienteId.Text, out int clienteId))
            {
                var cliente = new ClienteCN().BuscarPorId(clienteId);
                if (cliente != null)
                {
                    lblNombreCliente.Text = cliente.Nombre;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado", "Búsqueda",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblNombreCliente.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de cliente válido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtProductoId.Text, out int productoId))
            {
                var producto = new ProductoCN().BuscarPorId(productoId);
                if (producto != null)
                {
                    txtDescripcionProducto.Text = producto.Descripcion;
                    txtPrecioProducto.Text = producto.Precio.ToString("0.00");
                    txtCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado", "Búsqueda",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControlesProducto();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de producto válido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                int productoId = int.Parse(txtProductoId.Text);
                string descripcion = txtDescripcionProducto.Text;
                decimal precio = decimal.Parse(txtPrecioProducto.Text);
                int cantidad = int.Parse(txtCantidad.Text);
                decimal subtotal = precio * cantidad;

                bool productoExistente = false;
                foreach (DataRow row in _detallesVenta.Rows)
                {
                    if ((int)row["ProductoId"] == productoId)
                    {
                        row["Cantidad"] = (int)row["Cantidad"] + cantidad;
                        row["Subtotal"] = (decimal)row["Precio"] * (int)row["Cantidad"];
                        productoExistente = true;
                        break;
                    }
                }

                if (!productoExistente)
                {
                    _detallesVenta.Rows.Add(productoId, descripcion, precio, cantidad, subtotal);
                }

                _totalVenta = CalcularTotalVenta();
                ActualizarTotal();
                LimpiarControlesProducto();
            }
        }

        private bool ValidarDetalle()
        {
            if (string.IsNullOrWhiteSpace(txtProductoId.Text))
            {
                MessageBox.Show("Seleccione un producto", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private decimal CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataRow row in _detallesVenta.Rows)
            {
                total += (decimal)row["Subtotal"];
            }
            return total;
        }

        private void ActualizarTotal()
        {
            lblTotalValor.Text = _totalVenta.ToString("C");
        }

        private void LimpiarControlesProducto()
        {
            txtProductoId.Clear();
            txtDescripcionProducto.Clear();
            txtPrecioProducto.Clear();
            txtCantidad.Clear();
            txtProductoId.Focus();
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (ValidarVenta())
            {
                try
                {
                    var venta = new Venta
                    {
                        ClienteId = int.Parse(txtClienteId.Text),
                        Fecha = DateTime.Now,
                        Total = _totalVenta
                    };

                    int ventaId = new VentaCN().RegistrarVenta(venta, _detallesVenta);

                    MessageBox.Show($"Venta registrada exitosamente\nN° Venta: {ventaId}", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar la venta:\n{ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarVenta()
        {
            if (string.IsNullOrWhiteSpace(txtClienteId.Text) || string.IsNullOrWhiteSpace(lblNombreCliente.Text))
            {
                MessageBox.Show("Seleccione un cliente válido", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_detallesVenta.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la venta", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtClienteId.Clear();
            lblNombreCliente.Text = "";
            _detallesVenta.Rows.Clear();
            _totalVenta = 0;
            ActualizarTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cancelar esta venta?", "Confirmar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormulario();
            }
        }

        
        private static VentaDetalleCP _instance;
        public static VentaDetalleCP GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new VentaDetalleCP();
            return _instance;
        }

        private void VentaDetalleCP_Load(object sender, EventArgs e)
        {
            
        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
