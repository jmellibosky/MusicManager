namespace Musica.Boundary
{
    partial class NuevaCancion
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
            this.label = new System.Windows.Forms.Label();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAlbum = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBanda = new System.Windows.Forms.ComboBox();
            this.txtSegundos = new System.Windows.Forms.TextBox();
            this.txtBpm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(7, 39);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(50, 13);
            this.label.TabIndex = 18;
            this.label.Text = "Duración";
            // 
            // txtMinutos
            // 
            this.txtMinutos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinutos.Location = new System.Drawing.Point(63, 36);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(57, 20);
            this.txtMinutos.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(110, 142);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Album";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // cmbAlbum
            // 
            this.cmbAlbum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlbum.FormattingEnabled = true;
            this.cmbAlbum.Location = new System.Drawing.Point(63, 89);
            this.cmbAlbum.Name = "cmbAlbum";
            this.cmbAlbum.Size = new System.Drawing.Size(121, 21);
            this.cmbAlbum.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(63, 10);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Banda";
            // 
            // cmbBanda
            // 
            this.cmbBanda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanda.FormattingEnabled = true;
            this.cmbBanda.Location = new System.Drawing.Point(63, 62);
            this.cmbBanda.Name = "cmbBanda";
            this.cmbBanda.Size = new System.Drawing.Size(121, 21);
            this.cmbBanda.TabIndex = 4;
            this.cmbBanda.SelectedValueChanged += new System.EventHandler(this.cmbBanda_SelectedValueChanged);
            // 
            // txtSegundos
            // 
            this.txtSegundos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSegundos.Location = new System.Drawing.Point(127, 36);
            this.txtSegundos.Name = "txtSegundos";
            this.txtSegundos.Size = new System.Drawing.Size(57, 20);
            this.txtSegundos.TabIndex = 3;
            // 
            // txtBpm
            // 
            this.txtBpm.Location = new System.Drawing.Point(63, 116);
            this.txtBpm.Name = "txtBpm";
            this.txtBpm.Size = new System.Drawing.Size(121, 20);
            this.txtBpm.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "BPM";
            // 
            // NuevaCancion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 174);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBpm);
            this.Controls.Add(this.txtSegundos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBanda);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txtMinutos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAlbum);
            this.Controls.Add(this.txtNombre);
            this.Name = "NuevaCancion";
            this.Text = "NuevaCancion";
            this.Load += new System.EventHandler(this.NuevaCancion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAlbum;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBanda;
        private System.Windows.Forms.TextBox txtSegundos;
        private System.Windows.Forms.TextBox txtBpm;
        private System.Windows.Forms.Label label3;
    }
}