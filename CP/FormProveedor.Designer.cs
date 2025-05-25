namespace Sistema_de_ventas_y_stock___BD.CP
{
    partial class FormProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProveedor));
            this.label7 = new System.Windows.Forms.Label();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarC = new System.Windows.Forms.Button();
            this.btnEliminarP = new System.Windows.Forms.Button();
            this.btnModificarP = new System.Windows.Forms.Button();
            this.btnGuardarP = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtNomYAp = new System.Windows.Forms.TextBox();
            this.txtIDC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(12, 767);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(409, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "¡SELECCIONE REGISTRO PARA MODIFICAR O ELIMINAR!";
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Location = new System.Drawing.Point(12, 439);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.RowHeadersWidth = 51;
            this.dgvProveedor.RowTemplate.Height = 24;
            this.dgvProveedor.Size = new System.Drawing.Size(975, 325);
            this.dgvProveedor.TabIndex = 12;
            this.dgvProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(253, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(335, 46);
            this.label6.TabIndex = 11;
            this.label6.Text = "PROVEEDORES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiarC);
            this.groupBox1.Controls.Add(this.btnEliminarP);
            this.groupBox1.Controls.Add(this.btnModificarP);
            this.groupBox1.Controls.Add(this.btnGuardarP);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.txtNomYAp);
            this.groupBox1.Controls.Add(this.txtIDC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 261);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL PROVEEDOR";
            // 
            // btnLimpiarC
            // 
            this.btnLimpiarC.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLimpiarC.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarC.Location = new System.Drawing.Point(584, 166);
            this.btnLimpiarC.Name = "btnLimpiarC";
            this.btnLimpiarC.Size = new System.Drawing.Size(351, 65);
            this.btnLimpiarC.TabIndex = 14;
            this.btnLimpiarC.Text = "Limpiar campos";
            this.btnLimpiarC.UseVisualStyleBackColor = false;
            this.btnLimpiarC.Click += new System.EventHandler(this.btnLimpiarC_Click);
            // 
            // btnEliminarP
            // 
            this.btnEliminarP.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarP.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarP.Location = new System.Drawing.Point(768, 95);
            this.btnEliminarP.Name = "btnEliminarP";
            this.btnEliminarP.Size = new System.Drawing.Size(167, 65);
            this.btnEliminarP.TabIndex = 13;
            this.btnEliminarP.Text = "Eliminar proveedor";
            this.btnEliminarP.UseVisualStyleBackColor = false;
            this.btnEliminarP.Click += new System.EventHandler(this.btnEliminarP_Click);
            // 
            // btnModificarP
            // 
            this.btnModificarP.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnModificarP.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarP.Location = new System.Drawing.Point(584, 95);
            this.btnModificarP.Name = "btnModificarP";
            this.btnModificarP.Size = new System.Drawing.Size(178, 65);
            this.btnModificarP.TabIndex = 12;
            this.btnModificarP.Text = "Modificar proveedor";
            this.btnModificarP.UseVisualStyleBackColor = false;
            this.btnModificarP.Click += new System.EventHandler(this.btnModificarP_Click);
            // 
            // btnGuardarP
            // 
            this.btnGuardarP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnGuardarP.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarP.Location = new System.Drawing.Point(584, 28);
            this.btnGuardarP.Name = "btnGuardarP";
            this.btnGuardarP.Size = new System.Drawing.Size(351, 65);
            this.btnGuardarP.TabIndex = 11;
            this.btnGuardarP.Text = "Guardar proveedor";
            this.btnGuardarP.UseVisualStyleBackColor = false;
            this.btnGuardarP.Click += new System.EventHandler(this.btnGuardarP_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(249, 198);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(310, 34);
            this.txtEmail.TabIndex = 10;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(249, 157);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(310, 34);
            this.txtTel.TabIndex = 9;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(249, 116);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(310, 34);
            this.txtDni.TabIndex = 8;
            // 
            // txtNomYAp
            // 
            this.txtNomYAp.Location = new System.Drawing.Point(249, 74);
            this.txtNomYAp.Name = "txtNomYAp";
            this.txtNomYAp.Size = new System.Drawing.Size(310, 34);
            this.txtNomYAp.TabIndex = 7;
            // 
            // txtIDC
            // 
            this.txtIDC.Location = new System.Drawing.Point(249, 28);
            this.txtIDC.Name = "txtIDC";
            this.txtIDC.Size = new System.Drawing.Size(310, 34);
            this.txtIDC.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID PROVEEDOR:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "EMAIL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "TELÉFONO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "DIRECCIÓN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOMBRE:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 802);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormProveedor";
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiarC;
        private System.Windows.Forms.Button btnEliminarP;
        private System.Windows.Forms.Button btnModificarP;
        private System.Windows.Forms.Button btnGuardarP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtNomYAp;
        private System.Windows.Forms.TextBox txtIDC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}