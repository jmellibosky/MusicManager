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
    public partial class AcoplableBandas : Form
    {
        public AcoplableBandas()
        {
            InitializeComponent();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void AcoplableBandas_Load(object sender, EventArgs e)
        {
            grillaBandas.DataSource = Database.AD_Bandas.CargarGrilla();
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
            Database.AD_Paises.CargarCombo(ref cmbPais);
            cmbPais.SelectedIndex = -1;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            string input = txtNombre.Text;
            grillaBandas.DataSource = Control.LogicaBandas.BuscarBandaPorNombre(input);
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            cmbPais.SelectedIndex = -1;
            txtNombre.Text = "";
            grillaBandas.DataSource = Database.AD_Bandas.CargarGrilla();
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPais = int.Parse(cmbPais.SelectedValue.ToString());
            grillaBandas.DataSource = Control.LogicaBandas.BuscarBandaPorPais(idPais);
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaBanda v = new NuevaBanda();
            v.ShowDialog();
            grillaBandas.DataSource = Database.AD_Bandas.CargarGrilla();
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaBandas.SelectedRows[0].Cells[0].Value.ToString());
            string nombre = grillaBandas.SelectedRows[0].Cells[1].Value.ToString();
            int idPais = Control.LogicaBandas.ObtenerIdPais(grillaBandas.SelectedRows[0].Cells[2].Value.ToString());

            ModificarBanda v = new ModificarBanda(id, nombre, idPais);
            v.ShowDialog();
            grillaBandas.DataSource = Database.AD_Bandas.CargarGrilla();
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void grillaBandas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grillaBandas.SelectedRows[0].Cells[0].Value.ToString());
            bool b = Control.LogicaBandas.EliminarBanda(id);

            if (b) { MessageBox.Show("Eliminación exitosa."); }
            else { MessageBox.Show("Error."); }

            grillaBandas.DataSource = Database.AD_Bandas.CargarGrilla();
            lblTotal.Text = grillaBandas.Rows.Count.ToString();
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
