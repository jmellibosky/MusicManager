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
    public partial class AcoplableCanciones : Form
    {
        public AcoplableCanciones()
        {
            InitializeComponent();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaCancion v = new NuevaCancion();
            v.ShowDialog();
            grillaCanciones.DataSource = Database.AD_Canciones.CargarGrilla();
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string input = txtNombre.Text;
            BuscarPorNombre(input);
        }

        private void BuscarPorNombre(string input)
        {
            grillaCanciones.DataSource = Control.LogicaCanciones.BuscarCancionPorNombre(input);
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void txtBanda_TextChanged(object sender, EventArgs e)
        {
            string input = txtBanda.Text;
            BuscarPorBanda(input);
        }

        private void BuscarPorBanda(string input)
        {
            grillaCanciones.DataSource = Control.LogicaCanciones.BuscarCancionPorBanda(input);
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void BuscarTiempo()
        {
            int minutos = 0;
            int segundos = 0;
            try
            {
                minutos = int.Parse(txtMinutos.Text);
            }
            catch (Exception) { }

            try
            {
                segundos = int.Parse(txtSegundos.Text);
            }
            catch (Exception) { }

            grillaCanciones.DataSource = Control.LogicaCanciones.BuscarCancionEnTiempo(minutos, segundos);
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void txtDesde_TextChanged(object sender, EventArgs e)
        {
            BuscarTiempo();
        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {
            BuscarTiempo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaCanciones.SelectedRows[0].Cells[0].Value.ToString());
            string nombre = grillaCanciones.SelectedRows[0].Cells[1].Value.ToString();
            int minutos = Control.LogicaCanciones.ObtenerMinutos(id);
            int segundos = Control.LogicaCanciones.ObtenerSegundos(id);
            int idBanda = Control.LogicaCanciones.ObtenerIdBanda(grillaCanciones.SelectedRows[0].Cells[3].Value.ToString());
            int idAlbum = Control.LogicaCanciones.ObtenerIdAlbum(grillaCanciones.SelectedRows[0].Cells[4].Value.ToString(), idBanda);
            int bpm = int.Parse(grillaCanciones.SelectedRows[0].Cells[5].Value.ToString());

            ModificarCancion v = new ModificarCancion(id, nombre, minutos, segundos, idBanda, idAlbum, bpm);
            v.ShowDialog();
            
            if (txtBanda.Text.Equals("") && txtNombre.Text.Equals(""))
            {
                grillaCanciones.DataSource = Database.AD_Canciones.CargarGrilla();
            }
            else if (!txtBanda.Text.Equals(""))
            {
                string input = txtBanda.Text;
                BuscarPorBanda(input);
            }
            else
            {
                string input = txtNombre.Text;
                BuscarPorNombre(input);
            }
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaCanciones.SelectedRows[0].Cells[0].Value.ToString());
            bool b = Control.LogicaCanciones.EliminarCancion(id);

            if (b) { MessageBox.Show("Eliminación exitosa."); }
            else { MessageBox.Show("Error."); }

            grillaCanciones.DataSource = Database.AD_Canciones.CargarGrilla();
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }

        private void grillaCanciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void AcoplableCanciones_Load(object sender, EventArgs e)
        {
            grillaCanciones.DataSource = Database.AD_Canciones.CargarGrilla();
            lblTotal.Text = grillaCanciones.Rows.Count.ToString();
        }
    }
}
