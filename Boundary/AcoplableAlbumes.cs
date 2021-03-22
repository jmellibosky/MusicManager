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
    public partial class AcoplableAlbumes : Form
    {
        public AcoplableAlbumes()
        {
            InitializeComponent();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtDesde.Text = "0";
            txtHasta.Text = DateTime.Now.Year.ToString();
        }

        private void AcoplableAlbumes_Load(object sender, EventArgs e)
        {
            grillaAlbumes.DataSource = Database.AD_Albumes.CargarGrilla();
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string input = txtNombre.Text;
            grillaAlbumes.DataSource = Control.LogicaAlbumes.BuscarAlbumPorNombre(input);
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void txtBanda_TextChanged(object sender, EventArgs e)
        {
            string input = txtBanda.Text;
            grillaAlbumes.DataSource = Control.LogicaAlbumes.BuscarAlbumPorBanda(input);
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void txtDesde_TextChanged(object sender, EventArgs e)
        {
            string desde = txtDesde.Text;
            string hasta = txtHasta.Text;
            grillaAlbumes.DataSource = Control.LogicaAlbumes.BuscarAlbumEnPeriodo(desde, hasta);
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {
            string desde = txtDesde.Text;
            string hasta = txtHasta.Text;
            grillaAlbumes.DataSource = Control.LogicaAlbumes.BuscarAlbumEnPeriodo(desde, hasta);
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoAlbum v = new NuevoAlbum();
            v.ShowDialog();
            grillaAlbumes.DataSource = Database.AD_Albumes.CargarGrilla();
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaAlbumes.SelectedRows[0].Cells[0].Value.ToString());
            string nombre = grillaAlbumes.SelectedRows[0].Cells[1].Value.ToString();
            int año = int.Parse(grillaAlbumes.SelectedRows[0].Cells[2].Value.ToString());
            int banda = Control.LogicaAlbumes.ObtenerIdBanda(grillaAlbumes.SelectedRows[0].Cells[3].Value.ToString());

            ModificarAlbum v = new ModificarAlbum(id, nombre, año, banda);
            v.ShowDialog();
            grillaAlbumes.DataSource = Database.AD_Albumes.CargarGrilla();
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaAlbumes.SelectedRows[0].Cells[0].Value.ToString());
            Control.LogicaAlbumes.EliminarAlbum(id);

            grillaAlbumes.DataSource = Database.AD_Albumes.CargarGrilla();
            lblTotal.Text = grillaAlbumes.Rows.Count.ToString();
        }

        private void grillaAlbumes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
