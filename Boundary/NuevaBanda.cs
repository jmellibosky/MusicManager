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
    public partial class NuevaBanda : Form
    {
        public NuevaBanda()
        {
            InitializeComponent();
        }

        private void NuevaBanda_Load(object sender, EventArgs e)
        {
            Database.AD_Paises.CargarCombo(ref cmbPais);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int idPais = int.Parse(cmbPais.SelectedValue.ToString());
            int i = Control.LogicaBandas.CrearNuevaBanda(nombre, idPais);

            if (i == 0) { MessageBox.Show("Alta exitosa."); }
            else if (i == 1) { MessageBox.Show("Error."); }
            else { MessageBox.Show("Entrada repetida."); }
            
            this.Close();
        }
    }
}
