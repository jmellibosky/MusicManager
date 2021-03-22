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
    public partial class ModificarAlbum : Form
    {
        private int idMod;

        public ModificarAlbum(int id, string nombre, int año, int banda)
        {
            InitializeComponent();
            idMod = id;
            txtNombre.Text = nombre;
            txtAno.Text = año.ToString();
            Database.AD_Bandas.CargarCombo(ref cmbBanda);
            cmbBanda.SelectedValue = banda;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int año = int.Parse(txtAno.Text);
            int banda = int.Parse(cmbBanda.SelectedValue.ToString());

            bool b = Control.LogicaAlbumes.ModificarAlbum(idMod, nombre, año, banda);

            if (b) { MessageBox.Show("Modificación exitosa."); }
            else { MessageBox.Show("Error."); }

            this.Close();
        }
    }
}
