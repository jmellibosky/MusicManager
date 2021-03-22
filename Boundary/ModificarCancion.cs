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
    public partial class ModificarCancion : Form
    {
        private int idMod;

        public ModificarCancion(int id, string nombre, int minutos, int segundos, int idBanda, int idAlbum, int bpm)
        {
            InitializeComponent();
            idMod = id;
            txtNombre.Text = nombre;
            txtMinutos.Text = minutos.ToString();
            txtSegundos.Text = segundos.ToString();
            Database.AD_Bandas.CargarCombo(ref cmbBanda);
            cmbBanda.SelectedValue = idBanda;
            txtBpm.Text = bpm.ToString();
            try
            {
                Database.AD_Albumes.CargarCombo(ref cmbAlbum, idBanda);
                cmbAlbum.SelectedValue = idAlbum;
            }
            catch (Exception) { }
        }

        private void ModificarCancion_Load(object sender, EventArgs e)
        {

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = int.Parse(txtMinutos.Text);
            int segundos = int.Parse(txtSegundos.Text);
            int idBanda = int.Parse(cmbBanda.SelectedValue.ToString());
            int idAlbum = int.Parse(cmbAlbum.SelectedValue.ToString());
            int bpm = int.Parse(txtBpm.Text);

            bool b = Control.LogicaCanciones.ModificarCancion(idMod, nombre, minutos, segundos, idBanda, idAlbum, bpm);

            if (b) { MessageBox.Show("Modificación exitosa."); }
            else { MessageBox.Show("Error."); }

            this.Close();
        }
    }
}
