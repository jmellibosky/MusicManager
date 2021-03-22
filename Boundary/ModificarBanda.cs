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
    public partial class ModificarBanda : Form
    {
        private int idMod;

        public ModificarBanda(int id, string nombre, int idPais)
        {
            InitializeComponent();
            idMod = id;
            txtNombre.Text = nombre;
            Database.AD_Paises.CargarCombo(ref cmbPais);
            cmbPais.SelectedValue = idPais;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int idPais = int.Parse(cmbPais.SelectedValue.ToString());
            bool b = Control.LogicaBandas.ModificarBanda(idMod, nombre, idPais);

            if (b) { MessageBox.Show("Modificación exitosa."); }
            else { MessageBox.Show("Error."); }

            this.Close();
        }
    }
}
