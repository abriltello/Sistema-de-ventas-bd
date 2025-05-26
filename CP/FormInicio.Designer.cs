namespace Sistema_de_ventas_y_stock___BD
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vENDERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDMINISTRACIÓNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarComprobanteCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarComprobateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cOMPRASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-54, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(706, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // vENDERToolStripMenuItem
            // 
            this.vENDERToolStripMenuItem.Name = "vENDERToolStripMenuItem";
            this.vENDERToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.vENDERToolStripMenuItem.Text = "VENTAS";
            this.vENDERToolStripMenuItem.Click += new System.EventHandler(this.vENDERToolStripMenuItem_Click);
            // 
            // aDMINISTRACIÓNToolStripMenuItem
            // 
            this.aDMINISTRACIÓNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.aDMINISTRACIÓNToolStripMenuItem.Name = "aDMINISTRACIÓNToolStripMenuItem";
            this.aDMINISTRACIÓNToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.aDMINISTRACIÓNToolStripMenuItem.Text = "ADMINISTRACIÓN";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // rEPORTESToolStripMenuItem
            // 
            this.rEPORTESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarComprobanteCompraToolStripMenuItem,
            this.buscarComprobateToolStripMenuItem,
            this.consultarPorFechaToolStripMenuItem});
            this.rEPORTESToolStripMenuItem.Name = "rEPORTESToolStripMenuItem";
            this.rEPORTESToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.rEPORTESToolStripMenuItem.Text = "REPORTES";
            // 
            // buscarComprobanteCompraToolStripMenuItem
            // 
            this.buscarComprobanteCompraToolStripMenuItem.Name = "buscarComprobanteCompraToolStripMenuItem";
            this.buscarComprobanteCompraToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.buscarComprobanteCompraToolStripMenuItem.Text = "Buscar comprobante compra";
            this.buscarComprobanteCompraToolStripMenuItem.Click += new System.EventHandler(this.buscarComprobanteCompraToolStripMenuItem_Click);
            // 
            // buscarComprobateToolStripMenuItem
            // 
            this.buscarComprobateToolStripMenuItem.Name = "buscarComprobateToolStripMenuItem";
            this.buscarComprobateToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.buscarComprobateToolStripMenuItem.Text = "Buscar comprobante venta";
            this.buscarComprobateToolStripMenuItem.Click += new System.EventHandler(this.buscarComprobateToolStripMenuItem_Click);
            // 
            // consultarPorFechaToolStripMenuItem
            // 
            this.consultarPorFechaToolStripMenuItem.Name = "consultarPorFechaToolStripMenuItem";
            this.consultarPorFechaToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.consultarPorFechaToolStripMenuItem.Text = "Consultar por fecha";
            this.consultarPorFechaToolStripMenuItem.Click += new System.EventHandler(this.consultarPorFechaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vENDERToolStripMenuItem,
            this.aDMINISTRACIÓNToolStripMenuItem,
            this.rEPORTESToolStripMenuItem,
            this.cOMPRASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(572, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cOMPRASToolStripMenuItem
            // 
            this.cOMPRASToolStripMenuItem.Name = "cOMPRASToolStripMenuItem";
            this.cOMPRASToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.cOMPRASToolStripMenuItem.Text = "COMPRAS";
            this.cOMPRASToolStripMenuItem.Click += new System.EventHandler(this.cOMPRASToolStripMenuItem_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 366);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem vENDERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDMINISTRACIÓNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarComprobateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarPorFechaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cOMPRASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarComprobanteCompraToolStripMenuItem;
    }
}

