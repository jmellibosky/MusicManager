namespace Musica.Boundary
{
    partial class MainPanel
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
            this.pForm = new System.Windows.Forms.Panel();
            this.btnBandas = new System.Windows.Forms.Button();
            this.btnAlbumes = new System.Windows.Forms.Button();
            this.btnCanciones = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pForm
            // 
            this.pForm.Location = new System.Drawing.Point(0, 41);
            this.pForm.Name = "pForm";
            this.pForm.Size = new System.Drawing.Size(1088, 615);
            this.pForm.TabIndex = 0;
            // 
            // btnBandas
            // 
            this.btnBandas.Location = new System.Drawing.Point(64, 0);
            this.btnBandas.Name = "btnBandas";
            this.btnBandas.Size = new System.Drawing.Size(220, 35);
            this.btnBandas.TabIndex = 1;
            this.btnBandas.Text = "Bandas";
            this.btnBandas.UseVisualStyleBackColor = true;
            this.btnBandas.Click += new System.EventHandler(this.btnBandas_Click);
            // 
            // btnAlbumes
            // 
            this.btnAlbumes.Location = new System.Drawing.Point(290, 0);
            this.btnAlbumes.Name = "btnAlbumes";
            this.btnAlbumes.Size = new System.Drawing.Size(220, 35);
            this.btnAlbumes.TabIndex = 2;
            this.btnAlbumes.Text = "Albumes";
            this.btnAlbumes.UseVisualStyleBackColor = true;
            this.btnAlbumes.Click += new System.EventHandler(this.btnAlbumes_Click);
            // 
            // btnCanciones
            // 
            this.btnCanciones.Location = new System.Drawing.Point(516, 0);
            this.btnCanciones.Name = "btnCanciones";
            this.btnCanciones.Size = new System.Drawing.Size(220, 35);
            this.btnCanciones.TabIndex = 3;
            this.btnCanciones.Text = "Canciones";
            this.btnCanciones.UseVisualStyleBackColor = true;
            this.btnCanciones.Click += new System.EventHandler(this.btnCanciones_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1018, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Lector";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 656);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCanciones);
            this.Controls.Add(this.btnAlbumes);
            this.Controls.Add(this.btnBandas);
            this.Controls.Add(this.pForm);
            this.MaximizeBox = false;
            this.Name = "MainPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pForm;
        private System.Windows.Forms.Button btnBandas;
        private System.Windows.Forms.Button btnAlbumes;
        private System.Windows.Forms.Button btnCanciones;
        private System.Windows.Forms.Button button1;
    }
}