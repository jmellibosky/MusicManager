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
    public partial class NuevoAlbum : Form
    {
        public NuevoAlbum()
        {
            InitializeComponent();
        }

        private void NuevoAlbum_Load(object sender, EventArgs e)
        {
            Database.AD_Bandas.CargarCombo(ref cmbBanda);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int año = int.Parse(txtAno.Text);
            int idBanda = int.Parse(cmbBanda.SelectedValue.ToString());
            int i = Control.LogicaAlbumes.CrearNuevoAlbum(nombre, año, idBanda);

            if (i == 0) { MessageBox.Show("Alta exitosa."); }
            else if (i == 1) { MessageBox.Show("Error."); }
            else { MessageBox.Show("Entrada repetida."); }

            this.Close();
        }

        private void cmbBanda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtAno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
