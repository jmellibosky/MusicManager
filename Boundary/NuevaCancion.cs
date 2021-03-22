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
    public partial class NuevaCancion : Form
    {
        public NuevaCancion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = int.Parse(txtMinutos.Text);
            int segundos = int.Parse(txtSegundos.Text);
            int idBanda = int.Parse(cmbBanda.SelectedValue.ToString());
            int idAlbum = int.Parse(cmbAlbum.SelectedValue.ToString());
            int bpm = int.Parse(txtBpm.Text);

            int i = Control.LogicaCanciones.CrearNuevaCancion(nombre, minutos, segundos, idBanda, idAlbum, bpm);

            if (i == 0) { MessageBox.Show("Alta exitosa."); }
            else if (i == 1) { MessageBox.Show("Error."); }
            else { MessageBox.Show("Entrada repetida."); }

            this.Close();
        }

        private void NuevaCancion_Load(object sender, EventArgs e)
        {
            Database.AD_Bandas.CargarCombo(ref cmbBanda);
            cmbBanda.SelectedIndex = 0;
        }

        private void cmbBanda_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(cmbBanda.SelectedValue.ToString());
                Database.AD_Albumes.CargarCombo(ref cmbAlbum, id);
            }
            catch (Exception)
            {
            }
        }
    }
}
