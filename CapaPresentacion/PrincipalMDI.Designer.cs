namespace CapaPresentacion
{
    partial class PrincipalMDI
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuArchivo;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem menuTablas;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuProductos;
        private System.Windows.Forms.ToolStripMenuItem menuProcesos;
        private System.Windows.Forms.ToolStripMenuItem menuVentas;
        private System.Windows.Forms.ToolStripMenuItem menuConsultas;
        private System.Windows.Forms.ToolStripMenuItem menuVentasRegistradas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTablas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentasRegistradas = new System.Windows.Forms.ToolStripMenuItem();

            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuArchivo,
                this.menuTablas,
                this.menuProcesos,
                this.menuConsultas});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";

            // 
            // menuArchivo
            // 
            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuSalir});
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(60, 20);
            this.menuArchivo.Text = "Archivo";

            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(96, 22);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);

            // 
            // menuTablas
            // 
            this.menuTablas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuClientes,
                this.menuProductos});
            this.menuTablas.Name = "menuTablas";
            this.menuTablas.Size = new System.Drawing.Size(55, 20);
            this.menuTablas.Text = "Tablas";

            // 
            // menuClientes
            // 
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(125, 22);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);

            // 
            // menuProductos
            // 
            this.menuProductos.Name = "menuProductos";
            this.menuProductos.Size = new System.Drawing.Size(125, 22);
            this.menuProductos.Text = "Productos";
            this.menuProductos.Click += new System.EventHandler(this.menuProductos_Click);

            // 
            // menuProcesos
            // 
            this.menuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuVentas});
            this.menuProcesos.Name = "menuProcesos";
            this.menuProcesos.Size = new System.Drawing.Size(66, 20);
            this.menuProcesos.Text = "Procesos";

            // 
            // menuVentas
            // 
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(146, 22);
            this.menuVentas.Text = "Registrar Venta";
            this.menuVentas.Click += new System.EventHandler(this.menuVentas_Click);

            // 
            // menuConsultas
            // 
            this.menuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuVentasRegistradas});
            this.menuConsultas.Name = "menuConsultas";
            this.menuConsultas.Size = new System.Drawing.Size(71, 20);
            this.menuConsultas.Text = "Consultas";

            // 
            // menuVentasRegistradas
            // 
            this.menuVentasRegistradas.Name = "menuVentasRegistradas";
            this.menuVentasRegistradas.Size = new System.Drawing.Size(172, 22);
            this.menuVentasRegistradas.Text = "Ventas Registradas";
            this.menuVentasRegistradas.Click += new System.EventHandler(this.menuVentasRegistradas_Click);

            // 
            // PrincipalMDI
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.menuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "PrincipalMDI";
            this.Text = "Sistema de Ventas - SENATI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrincipalMDI_Load);

            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
