namespace Presentacion
{
    partial class Principal
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
            this.lblArticulos = new System.Windows.Forms.Label();
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.pbxImagenes = new System.Windows.Forms.PictureBox();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblCampo = new System.Windows.Forms.Label();
            this.cboxCampo = new System.Windows.Forms.ComboBox();
            this.cboxCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtbFiltro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArticulos
            // 
            this.lblArticulos.AutoSize = true;
            this.lblArticulos.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulos.Location = new System.Drawing.Point(12, 32);
            this.lblArticulos.Name = "lblArticulos";
            this.lblArticulos.Size = new System.Drawing.Size(158, 23);
            this.lblArticulos.TabIndex = 0;
            this.lblArticulos.Text = "Lista de artículos";
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.Location = new System.Drawing.Point(15, 131);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.Size = new System.Drawing.Size(843, 341);
            this.dgvListaArticulos.TabIndex = 2;
            this.dgvListaArticulos.SelectionChanged += new System.EventHandler(this.dgvListaArticulos_SelectionChanged);
            // 
            // pbxImagenes
            // 
            this.pbxImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxImagenes.Location = new System.Drawing.Point(882, 131);
            this.pbxImagenes.Name = "pbxImagenes";
            this.pbxImagenes.Size = new System.Drawing.Size(344, 341);
            this.pbxImagenes.TabIndex = 3;
            this.pbxImagenes.TabStop = false;
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroRapido.Location = new System.Drawing.Point(12, 83);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(98, 21);
            this.lblFiltroRapido.TabIndex = 4;
            this.lblFiltroRapido.Text = "Filtro rápido:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(423, 20);
            this.textBox1.TabIndex = 5;
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDetalle.Location = new System.Drawing.Point(14, 478);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(111, 30);
            this.btnDetalle.TabIndex = 6;
            this.btnDetalle.Text = "Ver detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnAgregar.Location = new System.Drawing.Point(132, 478);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(111, 30);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar artículo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnModificar.Location = new System.Drawing.Point(250, 478);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(111, 30);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar artículo";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnEliminar.Location = new System.Drawing.Point(368, 478);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(111, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar artículo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblCampo
            // 
            this.lblCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCampo.AutoSize = true;
            this.lblCampo.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampo.Location = new System.Drawing.Point(12, 551);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(52, 16);
            this.lblCampo.TabIndex = 10;
            this.lblCampo.Text = "Campo:";
            // 
            // cboxCampo
            // 
            this.cboxCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCampo.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCampo.FormattingEnabled = true;
            this.cboxCampo.Location = new System.Drawing.Point(70, 548);
            this.cboxCampo.Name = "cboxCampo";
            this.cboxCampo.Size = new System.Drawing.Size(214, 24);
            this.cboxCampo.TabIndex = 11;
            // 
            // cboxCriterio
            // 
            this.cboxCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCriterio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCriterio.FormattingEnabled = true;
            this.cboxCriterio.Location = new System.Drawing.Point(356, 548);
            this.cboxCriterio.Name = "cboxCriterio";
            this.cboxCriterio.Size = new System.Drawing.Size(214, 24);
            this.cboxCriterio.TabIndex = 12;
            // 
            // lblCriterio
            // 
            this.lblCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterio.Location = new System.Drawing.Point(298, 551);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(52, 16);
            this.lblCriterio.TabIndex = 13;
            this.lblCriterio.Text = "Campo:";
            // 
            // lblFiltro
            // 
            this.lblFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(590, 551);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(39, 16);
            this.lblFiltro.TabIndex = 14;
            this.lblFiltro.Text = "Filtro:";
            // 
            // txtbFiltro
            // 
            this.txtbFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFiltro.Location = new System.Drawing.Point(628, 548);
            this.txtbFiltro.Name = "txtbFiltro";
            this.txtbFiltro.Size = new System.Drawing.Size(198, 24);
            this.txtbFiltro.TabIndex = 15;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(849, 546);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 26);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 600);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtbFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cboxCriterio);
            this.Controls.Add(this.cboxCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.pbxImagenes);
            this.Controls.Add(this.dgvListaArticulos);
            this.Controls.Add(this.lblArticulos);
            this.MinimumSize = new System.Drawing.Size(1254, 639);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de artículos";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArticulos;
        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.PictureBox pbxImagenes;
        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.ComboBox cboxCampo;
        private System.Windows.Forms.ComboBox cboxCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtbFiltro;
        private System.Windows.Forms.Button btnBuscar;
    }
}

