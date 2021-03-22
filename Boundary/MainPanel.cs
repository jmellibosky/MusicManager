using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Musica.Boundary
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void AbrirForm(object form)
        {
            if (this.pForm.Controls.Count > 0)
            {
                this.pForm.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pForm.Controls.Add(f);
            this.pForm.Tag = f;
            f.Show();
        }
        private void btnBandas_Click(object sender, EventArgs e)
        {
            AbrirForm(new AcoplableBandas());
        }

        private void btnAlbumes_Click(object sender, EventArgs e)
        {
            AbrirForm(new AcoplableAlbumes());
        }

        private void btnCanciones_Click(object sender, EventArgs e)
        {
            AbrirForm(new AcoplableCanciones());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new AcoplableLectorCSV());
        }
    }
}
